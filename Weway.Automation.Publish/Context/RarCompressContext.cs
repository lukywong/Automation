using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Weway.Automation.Publish.Utils;

namespace Weway.Automation.Publish.Context
{
    public class RarCompressContext : RarContextBase, ICompressContext
    {
        private const string ArgumentsTemplate = "a -ep1 {0} {1} {2}";
        private const string ExclusiveSwitch = "-x";
        private const string CompressExtension = ".rar";

        public RarCompressContext()
        {
        }

        public RarCompressContext(
            IEnumerable<string> srcFileList,
            string desFileName,
            IEnumerable<string> exclusiveFileList = null)
        {
            SourceFileList = srcFileList;
            DesFileName = desFileName;
            ExclusiveFileList = exclusiveFileList;
        }

        public IEnumerable<string> SourceFileList { get; set; }
        public string DesFileName { get; set; }
        public IEnumerable<string> ExclusiveFileList { get; set; }

        public override string Arguments
        {
            get
            {
                var srcFiles =
                string.Join(
                    " ",
                    SourceFileList.Select(file => file.SurroundByQuote()));

                var exclusiveFiles =
                    ExclusiveFileList == null ? "" : string.Join(" ",
                        ExclusiveFileList.Select(file => ExclusiveSwitch + file.SurroundByQuote()));

                var arguments = string.Format(
                    ArgumentsTemplate,
                    exclusiveFiles,
                    (DesFileName + CompressExtension).SurroundByQuote(),
                    srcFiles);

                return arguments;
            }
        }
    }
}