using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using translation.domain.Entity;

namespace translation.infrastructure
{
    public class ScriptRunner : IScriptRunner
    {
        public async Task<string> RunScriptAsync(string scriptFileName, string additionalArgument, params string[] arguments)
        {
            string scriptPath = "C:\\p_projects\\translation-api\\translation.infrastructure";
            //scriptPath = Path.Combine(Directory.GetCurrentDirectory(), scriptFileName);
            scriptPath = Path.Combine(scriptPath, scriptFileName); //TODO: Get current directory gets the directory of the api...make it dynamic

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
            // For simplicity, this example assumes the interpreter  is always "python"
            var python = "C:\\Users\\suhaib\\AppData\\Local\\miniconda3\\python.exe";
            return python;
        }
    }
}
