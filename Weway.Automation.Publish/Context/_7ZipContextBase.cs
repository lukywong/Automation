using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Weway.Automation.Publish.Utils;

namespace Weway.Automation.Publish.Context
{
    public abstract class _7ZipContextBase : IApplicationContext
    {
        private const string Name = "7z.exe";
        public string ApplicationName
        {
            get 
            {
                var path = ApplicationHelper.GetApplicationPath(Application._7zFM);
                return Path.Combine(path, Name).SurroundByQuote();
            }
        }
        public abstract string Arguments { get; }
    }
}
