using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using translation.application.Common.Interfaces;
using translation.domain.Entity;
using translation.domain.Enum;
using translation.domain.Translation;

namespace translation.infrastructure
{
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
                Arguments = $"{scriptPath} {additionalArgument} {string.Join(" ", arguments)}",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new Process { StartInfo = startInfo })
            {
                using (var reader = new StreamReader(process.StandardOutput.BaseStream))
                {
                    process.Start();
                    return await reader.ReadToEndAsync();
                }
            }
        }

        private string DetermineScriptInterpreter(string scriptPath)
        {
            // Add logic to determine the script interpreter based on the file extension or other criteria
            // For simplicity, this example assumes the interpreter is always "python"
            return "python";
        }
    }

    public class TranslatorService : ITranslatorService
    {
        private readonly IScriptRunner _scriptRunner;

        public TranslatorService(IScriptRunner scriptRunner)
        {
            _scriptRunner = scriptRunner;
        }

        public Translation Translate(string message, TranslationServiceType translationServiceType)
        {
            // Additional logic if needed

            // Call the script runner passing the message as an additional argument
            string result = _scriptRunner.RunScriptAsync("your_script.py", message, "arg1", "arg2").Result;

            // Additional logic to process the result

            TranslatedMessage translatedMessage = new TranslatedMessage(result);

            return translatedMessage;
        }
    }

}
