using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using translation.domain.Entity;

namespace translation.infrastructure
{
    internal interface IAvailableLanguage
    {
        Language? CheckLanguageAvailability(string language);
        List<Language>? GetAvailableLanguage();

    }
}
