using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using translation.domain;
using translation.domain.Entity;
using translation.domain.Enum;
using translation.domain.Translation;

namespace translation.application
{
    public class Translator : ITranslator
    {

        private readonly ITranslatorService _translatorService;

        public Translator(ITranslatorService translatorServie)
        {
            _translatorService = translatorServie;
        }

        public Translation AutoTranslate(Message originalText)
        {
            throw new NotImplementedException();
        }

        public Translation Translate(OriginalMessage originalText, TranslationServiceType translationService)
        {
            return _translatorService.Translate(originalText, translationService);
        }
    }
}
