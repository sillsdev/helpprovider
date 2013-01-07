using System;

namespace Vulcan.Uczniowie.HelpProvider
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class AssemblyHelpMapFileNameAttribute : System.Attribute
    {
        private readonly string _helpMapFileName;

        public AssemblyHelpMapFileNameAttribute(string helpMapFileName)
        {
            _helpMapFileName = helpMapFileName;
        }

        public string HelpMapFileName
        {
            get { return _helpMapFileName; }
        }
    }
}
