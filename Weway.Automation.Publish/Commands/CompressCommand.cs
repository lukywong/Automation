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
        public CompressCommand(IEnumerable<string> srcFileList, string desFileName)
        {
            var srcFiles =
                string.Join(
                    " ", 
                    srcFileList.Select(file => file.SurroundByQuote()));
            _applicationContext = new RarCompressContext(srcFiles, desFileName);
        }

        protected override IApplicationContext ApplicationContext
        {
            get { return _applicationContext; }
        }
    }
}
