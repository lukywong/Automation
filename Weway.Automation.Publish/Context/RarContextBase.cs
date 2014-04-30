using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Weway.Automation.Publish.Utils;

namespace Weway.Automation.Publish.Context
{
    public abstract class RarContextBase : IApplicationContext
    {
        private const string Name = "Rar.exe";
        public string ApplicationName
        {
            get
            {
                var path = ApplicationHelper.GetApplicationPath(Application.WinRAR);
                return Path.Combine(path, Name).SurroundWithQuote();
            }
        }
        public abstract string Arguments { get; }
    }
}
