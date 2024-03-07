using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace translation.domain.Entity
{
    public class Language
    {
        public required string Name { get; set; }
        public string Code { get; set; } = String.Empty;

        public Language()
        {
        }

        public Language(string name, string code)
        {
            Name = name;
            Code = code;
        }
    }
}
