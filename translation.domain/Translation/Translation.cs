using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using translation.domain.Entity;
using translation.domain.Enum;

namespace translation.domain.Translation
{
    public class Translation
    {
        public Guid Id { get; set; }
        public OriginalMessage OriginalText { get; private set;}
        public TranslatedMessage TranslatedText { get; private set;}

        

        private Translation() 
        {
            
        }

        public Translation(OriginalMessage originalText, TranslatedMessage translatedText)
        {
            Id = Guid.NewGuid();
            OriginalText = originalText;
            TranslatedText = translatedText;
        }
    }
}
