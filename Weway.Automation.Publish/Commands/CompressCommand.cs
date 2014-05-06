using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weway.Automation.Publish.Context;
using Weway.Automation.Publish.Utils;

namespace Weway.Automation.Publish.Commands
{
    public class CompressCommand : CommandBase
    {
        public CompressCommand()
        {
        }

        public CompressCommand(
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

        protected override IApplicationContext ApplicationContext
        {
            get
            {
                var applicationContext =
                    new RarCompressContext(SourceFileList, DesFileName, ExclusiveFileList);
                return applicationContext;
            }
        }
    }
}
