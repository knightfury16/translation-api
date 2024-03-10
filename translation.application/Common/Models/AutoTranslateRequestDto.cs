using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace translation.application.Common.Models
{
    public class AutoTranslateRequestDto
    {
        public required string message { get; set; }
        public required string toLanguage { get; set; }

    }
}
