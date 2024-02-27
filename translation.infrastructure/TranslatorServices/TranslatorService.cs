using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private readonly IConfiguration _configuration;

        public TranslatorService(IConfiguration configuration )
        {
            _configuration = configuration;
        }
        public Translation Translate(string message, string fromLanguage, string toLanguage)
        {
            //call the translation service here
            // for now 

            //Language mapper
            
            Language originalLan= CheckLanguageAvailability(fromLanguage);
            Language translatedLan = CheckLanguageAvailability(toLanguage);
            //call service if originalLan and translated lan not null

            OriginalMessage originalMsg = new OriginalMessage(message,originalLan);
            TranslatedMessage translatedMessage = new TranslatedMessage("Valorous morrow to thee, sir thither mine cousin", translatedLan);
            Translation translation = new Translation(originalMsg, translatedMessage);

            return translation;
        }

        private Language CheckLanguageAvailability(string language)
        {
            return new Language { Name = language };
        }
    }
}
