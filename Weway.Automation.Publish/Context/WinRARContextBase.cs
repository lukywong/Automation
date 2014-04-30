using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Weway.Automation.Publish.Utils;

namespace Weway.Automation.Publish.Context
{
    public abstract class WinRARContextBase : IApplicationContext
    {
        public string ApplicationName
        {
            get
            {
                return ApplicationHelper
                    .GetApplication(Application.WinRAR)
                    .SurroundWithQuote();
            }
        }
        public abstract string Arguments { get; }
    }
}
