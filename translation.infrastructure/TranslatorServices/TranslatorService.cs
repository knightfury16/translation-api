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
       

        public Translation Translate(string message, TranslationServiceType translationServiceType)
        {
            //call the translation service here
            // for now 
            TranslatedMessage message = runScript(message)


            return message;
        }
    }
}
