using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Weway.Automation.Publish.Context;

namespace Weway.Automation.Publish.Commands
{
    public sealed class DecompressCommand : CommandBase
    {
        private IApplicationContext _applicationContext;
        public DecompressCommand(string srcFileName, string desPath)
        {
            _applicationContext = new RarDecompressContext(srcFileName, desPath);
        }

        protected override IApplicationContext ApplicationContext
        {
            get { return _applicationContext; }
        }
    }
}
