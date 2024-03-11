using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using translation.application.Common.Interfaces;
using translation.application.Common.Models;
using translation.domain;
using translation.domain.Entity;
using translation.domain.Enum;
using translation.domain.Translation;

namespace translation.application
{
    internal class Translator : ITranslator
    {

        private readonly ITranslatorService _translatorService;

        public Translator(ITranslatorService translatorService)
        {
            _translatorService = translatorService;
        }

        public Translation Translate(TranslateRequestDto request)
        {
            //unpacking
            string message = request.message;
            string fromLanguage = request.fromLanguage;
            string toLanguage = request.toLanguage;

            //calling the service
            var translation = _translatorService.Translate(message, fromLanguage, toLanguage);

            return translation;
        }

        public Translation AutoTranslate(AutoTranslateRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}
