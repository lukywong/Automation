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
        private IApplicationContext _applicationContext;

        public CompressCommand(
            IEnumerable<string> srcFileList,
            string desFileName,
            IEnumerable<string> exclusiveFileList = null)
        {
            _applicationContext = 
                new RarCompressContext(srcFileList, desFileName, exclusiveFileList);
        }

        protected override IApplicationContext ApplicationContext
        {
            get { return _applicationContext; }
        }
    }
}
