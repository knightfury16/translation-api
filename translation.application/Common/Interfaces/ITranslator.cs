﻿using translation.application.Common.Models;
using translation.domain;
using translation.domain.Entity;
using translation.domain.Enum;
using translation.domain.Translation;

namespace translation.application.Common.Interfaces;

public interface ITranslator
{
    Translation Translate(TranslateRequestDto request);
    Translation AutoTranslate(AutoTranslateRequestDto request);
}
