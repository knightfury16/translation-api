﻿using System;
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
    public class Translator : ITranslator
    {

        private readonly ITranslatorService _translatorService;

        public Translator(ITranslatorService translatorService)
        {
            _translatorService = translatorService;
        }

        public async Task<Translation?> Translate(TranslateRequestDto request)
        {
            //unpacking
            string message = request.message.ToString();
            TranslationServiceType translationService = request.translationServiceType;

            //calling the service
            var translation = await _translatorService.Translate(message, translationService);

            return translation;
        }

        public Translation AutoTranslate(TranslateRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}
