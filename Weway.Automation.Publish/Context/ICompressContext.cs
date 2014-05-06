using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weway.Automation.Publish.Context
{
    public interface ICompressContext
    {
        IEnumerable<string> SourceFileList { get; set; }
        string DesFileName { get; set; }
        IEnumerable<string> ExclusiveFileList { get; set; }
    }
}
