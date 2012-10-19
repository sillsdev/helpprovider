using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vulcan.Uczniowie.HelpProvider
{
    public static class PathHelper
    {

        #region Œcie¿ki
        public static string FallBackFile
        {
            get
            {
                return "default.helpmap";
            }
        }

        public static bool HelpFileExists(string helpFileName)
        {
            return File.Exists(Path.Combine(DefaultHelpfileFolder, helpFileName));
        }

        public static string DefaultHelpfileFolder
        {
            get { return Application.StartupPath; }
        }

        public static string DefaultMappingFolder
        {
            get { return System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); }
        }

        #endregion
    }
}
