using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using translation.domain;
using translation.domain.Entity;
using translation.domain.Enum;

namespace translation.application.Common.Models
{
    public class TranslateRequestDto
    {
        public required string message { get; set; }
        public string fromLanguage { get; set; }
        public string toLanguage { get; set; }
    }
}
