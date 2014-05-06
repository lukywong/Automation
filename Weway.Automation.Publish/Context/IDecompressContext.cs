using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weway.Automation.Publish.Context
{
    public interface IDecompressContext
    {
        string SrcFileName { get; set; }

        string DesPath { get; set; }
    }
}
