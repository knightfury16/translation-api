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
        public async Task<Message> RunScriptAsync(string scriptPath, params string[] args)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = DetermineScriptInterpreter(scriptPath),
                Arguments = $"\"{scriptPath}\" {string.Join(" ", args)}",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new Process { StartInfo = startInfo })
            {
                using (var reader = new StreamReader(process.StandardOutput.BaseStream))
                {
                    process.Start();
                    string translatedMessage = await reader.ReadToEndAsync();

                    return new Message(text: translatedMessage);
                }
            }
        }

        private string DetermineScriptInterpreter(string scriptPath)
        {
            // logic to figure out script language
            return "python";
        }
    }
}
