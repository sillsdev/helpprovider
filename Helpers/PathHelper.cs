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
        private static readonly List<string> _secondaryHelpFileMappings = new List<string>();
        private static string _primaryHelpFileMapping;

        #region Œcie¿ki
        private static string FallBackFile
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

        public static string PrimaryHelpMapping
        {
            get
            {
                if(String.IsNullOrEmpty(_primaryHelpFileMapping))
                {
                    return FallBackFile;
                }
                return _primaryHelpFileMapping;
            }
        }

        public static IEnumerable<string> SecondaryHelpMappings
        {
            get { return _secondaryHelpFileMappings; }
        }

        public static string WritableHelpmappingPath
        {
            get
            {
                return Path.Combine(DefaultMappingFolder, PrimaryHelpMapping);
            }
        }

        public static string DefaultMappingFolder
        {
            get { return System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); }
        }

        public static void RegisterSecondaryHelpMapping(string path)
        {
            _secondaryHelpFileMappings.Add(path);
        }

        public static void RegisterPrimaryHelpMapping(string path)
        { 
                _primaryHelpFileMapping = path;
        }

        #endregion
    }
}
