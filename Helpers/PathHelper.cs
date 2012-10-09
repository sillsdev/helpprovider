using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Vulcan.Uczniowie.HelpProvider
{
    public class PathHelper
    {
        #region Œcie¿ki
        public static string BareFile
        {
            get
            {
                return "help.mapping";
            }
        }

        public static string ClientLocalHelpFilePath
        {
            get
            {
                return Path.Combine( Application.StartupPath, BareFile );
            }
        }
        #endregion
    }
}
