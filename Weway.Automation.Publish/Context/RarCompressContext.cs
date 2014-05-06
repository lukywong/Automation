using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Weway.Automation.Publish.Utils;

namespace Weway.Automation.Publish.Context
{
    public class RarCompressContext : RarContextBase
    {
        private const string ArgumentsTemplate = "a {0} {1}";
        private string _arguments;
        public RarCompressContext(string srcFiles, string desFileName)
        {
            _arguments = string.Format(
                ArgumentsTemplate,
                desFileName.SurroundByQuote(),
                srcFiles);
        }
        public override string Arguments
        {
            get
            {
                return _arguments;
            }
        }
    }
}
