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
        private const string ArgumentsTemplate = "a -ep1 {0} {1} {2}";
        private const string ExclusiveSwitch = "-x";
        private const string CompressExtension = ".rar";
        private string _arguments;
        public RarCompressContext(
            IEnumerable<string> srcFileList,
            string desFileName,
            IEnumerable<string> exclusiveFileList = null)
        {
            var srcFiles =
                string.Join(
                    " ",
                    srcFileList.Select(file => file.SurroundByQuote()));

            var exclusiveFiles = 
                exclusiveFileList == null ? "" : string.Join(" ",
                    exclusiveFileList.Select(file => ExclusiveSwitch + file.SurroundByQuote()));

            _arguments = string.Format(
                ArgumentsTemplate,
                exclusiveFiles,
                (desFileName + CompressExtension).SurroundByQuote(),
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