using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using translation.application.Common.Interfaces;
using translation.domain;
using translation.domain.Entity;
using translation.domain.Enum;
using translation.domain.Translation;

namespace translation.infrastructure.TranslatorServices
{
    public class TranslatorService : ITranslatorService
    {
        private readonly IScriptRunner _scriptRunner;
        private readonly string scriptName = "myscript.py"; //TODO: add this to config file 

        public TranslatorService()
        {
            _scriptRunner = new ScriptRunner();
        }

        public async Task<Translation?> Translate(string message, TranslationServiceType translationServiceType)
        {

            string translationObj = await _scriptRunner.RunScriptAsync(scriptName, message, translationServiceType.ToString());

            var translatedText = GetTranslatedText(translationObj);

            if(translatedText != null) { 
                TranslatedMessage translatedMessage = new TranslatedMessage(translatedText,translationServiceType);
                OriginalMessage originalMessage = new OriginalMessage(message);

                var translation = new Translation(originalMessage, translatedMessage);

                return translation;
            }

            return null;
        }

        private string? GetTranslatedText(string translationObj)
        {
            string pattern = @"Translated Text = (.+)";
            Match match = Regex.Match(translationObj, pattern);

            if (match.Success && match.Groups.Count > 1)
            {
                return match.Groups[1].Value.Trim();
            }

            return null;
        }
    }
}
