using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weway.Automation.Publish.Commands;
using Weway.Automation.Publish.Context;
using Weway.Automation.Publish.Utils;

namespace Weway.Automation.Publish.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var srcPath = AppSettingsHelper.GetValue("srcPath");
            var desPath = AppSettingsHelper.GetValue("desPath");
            LogHelper.LogPath = Directory.GetCurrentDirectory();
            ICommand cmd = new DecompressCommand(srcPath, desPath);
            cmd.Execute();
        }
    }
}
