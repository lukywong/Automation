﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Weway.Automation.Publish.Utils;

namespace Weway.Automation.Publish.Context
{
    public class WinRARDecompressContext : WinRARContextBase
    {
        private const string ArgumentsTemplate = "-y x {0} {1}";//"-inul -o+ -p- x {0} {1}"
        private string _arguments;

        public WinRARDecompressContext(string srcFileName, string desPath)
        {
            _arguments = string.Format(
                ArgumentsTemplate,
                srcFileName.SurroundWithQuote(),
                desPath.SurroundWithQuote());
        }
        public override string Arguments
        {
            get
            {
                return _arguments;
            }
        }
    }
}