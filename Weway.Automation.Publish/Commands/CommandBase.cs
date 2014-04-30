using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Weway.Automation.Publish.Context;
using Weway.Automation.Publish.Utils;

namespace Weway.Automation.Publish.Commands
{
    public abstract class CommandBase : ICommand
    {
        protected abstract IApplicationContext ApplicationContext { get; }

        public bool Execute()
        {
            var flag = false;

            var startInfo = new ProcessStartInfo
            {
                CreateNoWindow = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                FileName = ApplicationContext.ApplicationName,
                Arguments = ApplicationContext.Arguments,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            var process = new Process { StartInfo = startInfo };

            LogHelper.Info(
                    "Executing command: " +
                    ApplicationContext.ApplicationName + " " +
                    ApplicationContext.Arguments);

            try
            {
                process.Start();

                var output = process.StandardOutput.ReadToEnd();
                var error = process.StandardError.ReadToEnd();

                if (!string.IsNullOrEmpty(output)) LogHelper.Info(output);
                if (!string.IsNullOrEmpty(error)) LogHelper.Error(error);

                process.WaitForExit();

                flag = process.HasExited;

                process.Close();
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message + Environment.NewLine + ex.StackTrace);
            }
            finally
            {
                process.Close();
            }
            return flag;
        }
    }
}
