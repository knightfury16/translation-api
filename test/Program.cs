using System.Diagnostics;

namespace test;
public interface IScriptRunner
{
    Task<string> RunScriptAsync(string scriptFileName, string additionalArgument, params string[] arguments);
}

public class ScriptRunner : IScriptRunner
{
    public async Task<string> RunScriptAsync(string scriptFileName, string additionalArgument, params string[] arguments)
    {
        string scriptPath = Path.Combine(Directory.GetCurrentDirectory(), scriptFileName);

        var startInfo = new ProcessStartInfo
        {
            FileName = DetermineScriptInterpreter(scriptPath),
            Arguments = $"\"{scriptPath}\" \"{additionalArgument}\" {string.Join(" ", arguments)}",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardError = true
        };

        Console.WriteLine(startInfo.Arguments);

        using (var process = new Process { StartInfo = startInfo })
        {
            process.Start();

            // Read both standard output and standard error asynchronously
            var outputTask = process.StandardOutput.ReadToEndAsync();
            var errorTask = process.StandardError.ReadToEndAsync();

            // Wait for both tasks to complete
            await Task.WhenAll(outputTask, errorTask);

            // Check if there was any error
            if (!string.IsNullOrEmpty(errorTask.Result))
            {
                Console.WriteLine($"Error from script: {errorTask.Result}");
            }

            return outputTask.Result;
        }
    }

    private string DetermineScriptInterpreter(string scriptPath)
    {
        // Add logic to determine the script interpreter based on the file extension or other criteria
        // For simplicity, this example assumes the interpreter is always "python"
        return "python";
    }
}
class Program
{
    static async Task Main(string[] args)
    {
        var scriptRunner = new ScriptRunner();

        var result = await scriptRunner.RunScriptAsync("myscript.py", "hello there my friend", "shakespeare");
        Console.WriteLine(result);
        Console.ReadLine();
    }
}
