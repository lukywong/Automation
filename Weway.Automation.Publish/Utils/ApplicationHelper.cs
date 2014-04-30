using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Win32;

namespace Weway.Automation.Publish.Utils
{
    public class ApplicationHelper
    {
        private static readonly string AppPathTemplate;

        static ApplicationHelper()
        {
            AppPathTemplate =
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\{0}.exe";
        }

        public static bool TryGetApplication(Application application, out string app)
        {
            return TryGetAppPath(application, out app);
        }

        public static string GetApplication(Application application)
        {
            var app = string.Empty;
            var flag = TryGetApplication(application, out app);
            if (!flag)
            {
                throw new Exception("Get application failed!");
            }
            return app;
        }

        public static bool TryGetApplicationPath(Application application, out string path)
        {
            return TryGetAppPath(application, out path, "Path");
        }

        public static string GetApplicationPath(Application application)
        {
            var path = string.Empty;
            var flag = TryGetApplicationPath(application, out path);
            if (!flag)
            {
                throw new Exception("Get application failed!");
            }
            return path;
        }

        private static bool TryGetAppPath(
            Application application,
            out string path,
            string name = "")
        {
            var result = string.Empty;

            RegistryKey subKey = null;

            try
            {
                var subKeyName = 
                    string.Format(AppPathTemplate, application.ToString().Trim('_'));
                subKey = Registry.LocalMachine.OpenSubKey(subKeyName);

                var valueKind = subKey.GetValueKind(name);

                if (valueKind == RegistryValueKind.String)
                {
                    result = subKey.GetValue(name).ToString();
                }
            }
            catch (SecurityException ex)
            {
                LogHelper.Error(ex.Message + Environment.NewLine + ex.StackTrace);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message + Environment.NewLine + ex.StackTrace);
            }
            finally
            {
                if (subKey != null)
                {
                    subKey.Close();
                }
            }
            path = result;
            return !string.IsNullOrEmpty(result);
        }
    }

    public enum Application
    {
        WinRAR,
        Rar,
        _7zFM,
        WinZip32,
        WinZip64
    }
}
