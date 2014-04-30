using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weway.Automation.Publish.Utils
{
    public static class DateTimeExtensions
    {
        public static string ToLogTimeString(this DateTime time)
        {
            return time.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }
    }
}
