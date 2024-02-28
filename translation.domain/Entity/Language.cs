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
        public string Code { get; set; }

        public Language()
        {
        }

        public Language(string name)
        {
            Name = name;
        }
    }
}
