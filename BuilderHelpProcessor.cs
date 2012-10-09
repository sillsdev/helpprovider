using System;
using System.Collections.Generic;
using System.Text;

namespace Vulcan.Uczniowie.HelpProvider
{
    public class BuilderHelpProcessor : IHelpProcessor
    {
        #region IHelpProcessor Members
        public void ProcessControlHelp( System.Windows.Forms.Control Control )
        {
            ( new HelpEditor( Control ) ).ShowDialog();
        }
        #endregion
    }
}
