using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weway.Automation.Publish.Commands
{
    public interface ICommand
    {
        bool Execute();
    }
}
