using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using translation.application;
using translation.domain;
using translation.domain.Entity;
using translation.domain.Enum;
using translation.domain.Translation;

namespace translation.infrastructure.TranslatorServices
{
    public class TranslatorService : ITranslatorService
    {
       

        public Translation Translate(OriginalMessage originalMessage, TranslationServiceType translationServiceType)
        {
            //call the translation service here
            // for now 
            TranslatedMessage translatedMessage = new TranslatedMessage("Valorous morrow to thee, sir thither mine cousin", translationServiceType);
            Translation translation = new Translation(originalMessage, translatedMessage);

            return translation;
        }
    }
}
