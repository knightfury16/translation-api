using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using translation.domain.Entity;

namespace translation.infrastructure
{
    public interface IScriptRunner
    {
        Task<string> RunScriptAsync(string scriptFileName, string additionalArgument, params string[] arguments);
    }
}
