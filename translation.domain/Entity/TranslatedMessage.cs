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
        public TranslatedMessage(string text, Language language) : base(text, language)
        {
        }

    }
}
