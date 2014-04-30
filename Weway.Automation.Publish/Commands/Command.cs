using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Weway.Automation.Publish.Context;

namespace Weway.Automation.Publish.Commands
{
    public sealed class Command : CommandBase
    {
        private IApplicationContext _applicationContext;
        public Command(IApplicationContext context)
        {
            _applicationContext = context;
        }
        protected override IApplicationContext ApplicationContext
        {
            get { return _applicationContext; }
        }
    }
}
