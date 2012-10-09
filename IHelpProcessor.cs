using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Vulcan.Uczniowie.HelpProvider
{
    public interface IHelpProcessor
    {
        void ProcessControlHelp( Control Control );
    }
}
