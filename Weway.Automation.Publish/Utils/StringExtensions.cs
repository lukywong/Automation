using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weway.Automation.Publish.Utils
{
    public static class StringExtensions
    {
        public static string SurroundBy(this string s, string text)
        {
            if (string.IsNullOrEmpty(s))
            {
                return text + text;
            }
            return text + s + text;
        }

        public static string SurroundByQuote(this string s)
        {
            return s.SurroundBy("\"");
        }
    }
}
