using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Weway.Automation.Publish.Utils
{
    public class AppSettingsHelper
    {
        public static string GetValue(string key)
        {
            var config = GetConfiguration();
            var appSettings = GetAppSettingsSection(config);
            return appSettings.Settings[key] == null ? "" : appSettings.Settings[key].Value;
        }

        public static void Save(string key, string value)
        {
            var config = GetConfiguration();
            var appSettings = GetAppSettingsSection(config);
            if (!AppSettingsKeyExists(key, config)) return;
            appSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
        }

        private static Configuration GetConfiguration()
        {
            var config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            return config;
        }

        private static AppSettingsSection GetAppSettingsSection(Configuration config)
        {
            return (AppSettingsSection)config.GetSection("appSettings");
        }

        private static bool AppSettingsKeyExists(string key, Configuration config)
        {
            return config.AppSettings.Settings.AllKeys.Contains(key);
        }
    }
}