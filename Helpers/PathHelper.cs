using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Vulcan.Uczniowie.HelpProvider
{
    public class PathHelper
    {
        private static readonly List<string> _otherHelpFileMappings = new List<string>();
        private static string _primaryHelpFileMapping;

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

        public static string PrimaryHelpMappingPath
        {
            get { return _primaryHelpFileMapping; } 
            set 
            { 
                if(_primaryHelpFileMapping != null)
                {
                    throw new ArgumentException("The primary mapping should only ever be set once.");
                }
                _primaryHelpFileMapping = value;
            }
        }

        public static IEnumerable<string> OtherHelpMappingPaths
        {
            get { return _otherHelpFileMappings; }
        }

        public void RegisterHelpmappingPath(string path)
        {
            _otherHelpFileMappings.Add(path);
        }

        #endregion
    }
}
