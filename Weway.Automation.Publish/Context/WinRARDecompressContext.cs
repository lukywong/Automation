using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Weway.Automation.Publish.Utils;

namespace Weway.Automation.Publish.Context
{
    public class WinRARDecompressContext : WinRARContextBase, IDecompressContext
    {
        private const string ArgumentsTemplate = "-y x {0} {1}";//"-inul -o+ -p- x {0} {1}"

        public WinRARDecompressContext(string srcFileName, string desPath)
        {
            SrcFileName = srcFileName;
            DesPath = desPath;
        }

        public string SrcFileName { get; set; }

        public string DesPath { get; set; }

        public override string Arguments
        {
            get
            {
                var arguments =
                    string.Format(
                        ArgumentsTemplate,
                        SrcFileName.SurroundByQuote(),
                        DesPath.SurroundByQuote());
                return arguments;
            }
        }
    }
}
