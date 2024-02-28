﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using translation.domain.Entity;

namespace translation.infrastructure.TranslatorServices
{
    public interface IAvailableLanguage
    {
        Language CheckLanguageAvailability(string language);
    }
}
