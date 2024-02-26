using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using translation.domain.Enum;

namespace translation.domain.Entity
{
    public class TranslatedMessage: Message
    {
        public TranslationServiceType  TranslatedUsingService { get; set; }

        public TranslatedMessage(string text, TranslationServiceType translationServiceType) : base(text)
        {
            TranslatedUsingService = translationServiceType;
        }

    }
}   
