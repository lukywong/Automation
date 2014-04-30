using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weway.Automation.Publish.Utils
{
    public static class LogHelper
    {
        private const string LogFileName = "Log.dat";                

        public static string LogPath { get; set; }

        public static void Info(string log)
        {
            WriteLogWithHeader(log);
        }

        public static void Error(string log)
        {
            WriteLogWithHeader(log, LogType.Error);
        }

        private static void WriteLogWithHeader(string log, LogType type = LogType.Info)
        {
            WriteLog(GetLogHeader(type) + log);
        }
        public static void WriteLog(string log)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                var logFileName = LogFileName;
                if (!string.IsNullOrEmpty(LogPath))
                {
                    logFileName = Path.Combine(LogPath, LogFileName);
                }
                if (!File.Exists(LogPath))
                {
                    Directory.CreateDirectory(LogPath);
                }
                using (fs = new FileStream(logFileName, FileMode.Append, FileAccess.Write))
                {
                    sw = new StreamWriter(fs);
                    sw.WriteLine(log);
                    sw.Close();
                }
            }
            catch
            {
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }
        private static string GetLogHeader(LogType type = LogType.Info)
        {
            var line = new string('*', 100);
            var sb = new StringBuilder();
            sb.AppendLine(line);
            sb.AppendLine(type.ToString() + new string(' ', 5) + DateTime.Now.ToLogTimeString());
            sb.AppendLine(line);
            return sb.ToString();
        }
    }

    enum LogType
    {
        Info,
        Error,
        Warn,
        Fatal
    }
}
