using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Vulcan.Uczniowie.HelpProvider
{
    public class HelpDescriptions
    {
        private HelpDescription _primaryHelpDescription;
        private readonly List<HelpDescription> _otherHelpDescriptions = new List<HelpDescription>();
        private static HelpDescriptions _singleton;

        private HelpDescriptions(HelpDescription primaryHelpDescription)
        {
            _primaryHelpDescription = primaryHelpDescription;
        }
        
        public static HelpDescriptions Singleton
        {
            get
            {
                if(_singleton == null)
                {
                    _singleton = new HelpDescriptions(LoadHelpDescriptionFromFile(PathHelper.FallBackFile));
                }
                return _singleton;
            }
        }

        public bool IsEmpty
        {
            get { return _primaryHelpDescription.TopicDescription.Count == 0 && _otherHelpDescriptions.Count == 0; }
        }

        public string PrimaryHelpFile
        {
            get { return Singleton._primaryHelpDescription.HelpFile; }
            set 
            { _primaryHelpDescription = LoadHelpDescriptionFromFile(value); }
        }
        public string PrimaryHelpFilePath
        {
            get { return _primaryHelpDescription.HelpFilePath; }
        }

        public void RegisterSecondaryHelpMapping(string helpFileMapping)
        {
            var secondaryHelpDescription = LoadHelpDescriptionFromFile(helpFileMapping);
            //if we actually found a mapping file then use it
            if (!string.IsNullOrEmpty(secondaryHelpDescription.HelpFile) && _otherHelpDescriptions.All(hd => hd.HelpFile != secondaryHelpDescription.HelpFile))
            {
                _otherHelpDescriptions.Add(secondaryHelpDescription);
            }
        }

        public bool FoundHelpMapping
        {
            get 
            { 
                return _primaryHelpDescription.TopicDescription.Count > 0 || _otherHelpDescriptions.Any(o=>o.TopicDescription.Count > 0);
            }
        }

        public IEnumerable<string> AllHelpFilePaths
        {
            get { return AllHelpDescriptions.Select(hd=>hd.HelpFilePath); }
        }

        public IEnumerable<string> AllHelpFiles
        {
            get { return AllHelpDescriptions.Select(hd => hd.HelpFile); }
        }

        private IEnumerable<HelpDescription> AllHelpDescriptions
        {
            get { return new[]{_primaryHelpDescription}.Concat(_otherHelpDescriptions); }
        }

        public string GetMappingNameForHelpFile(string helpfileName)
        {
            return AllHelpDescriptions.SingleOrDefault(hd => hd.HelpFile == helpfileName).MappingFile;
        }

        public ControlHelpDescription CreateExactDescription(Control Control, string mappingFile)
        {
            return AllHelpDescriptions.Single(hd=>hd.MappingFile == mappingFile).CreateExactDescription(Control);
        }

        public ControlHelpDescription FindExactDescription(Control control)
        {
            return FindExactDescription(ControlHelper.GetControlIDPath(control));
        }

        /// <summary>
        /// Funkcja wyszukuje dok³adny obiekt wi¹¿¹cy formant z zagadnieniem pomocy
        /// </summary>
        /// <param name="Control"></param>
        /// <returns></returns>
        public ControlHelpDescription FindExactDescription(string[] Control)
        {
            //Always prefer descriptions found in the primary helpdescription, otherwise just grab the first description if there even is one
            var description = _primaryHelpDescription.FindExactDescription(Control);
            if (description == null || String.IsNullOrEmpty(description.HelpKeyword))
            {
                foreach (var otherHelpDescription in _otherHelpDescriptions)
                {
                    var otherDescription = otherHelpDescription.FindExactDescription(Control);
                    if (otherDescription != null && !String.IsNullOrEmpty(otherDescription.HelpKeyword))
                    {
                        return otherDescription;
                    }
                }
            }
            return description;
        }

        /// <summary>
        /// Funkcja wyszukuje dok³adny obiekt wi¹¿¹cy formant z zagadnieniem pomocy
        /// </summary>
        /// <param name="controlIdParts"></param>
        /// <returns></returns>
        public ControlHelpDescription FindDescription(string[] controlPath)
        {
            var controlPathCopy = new List<string>(controlPath);
            while(controlPathCopy.Count > 0)
            {
                var description = FindExactDescription(controlPathCopy.ToArray());
                if (description == null || string.IsNullOrEmpty(description.HelpKeyword))
                {
                    controlPathCopy.RemoveAt(controlPathCopy.Count-1);
                }
                else
                {
                    return description;
                }
            }
            return null;
        }

        /// <summary>
        /// Funkcja wyszukuje dok³adny obiekt wi¹¿¹cy formant z zagadnieniem pomocy
        /// </summary>
        /// <param name="Control"></param>
        /// <returns></returns>
        public string GetHelpFileDescription(ControlHelpDescription description)
        {
            return AllHelpDescriptions.Single(d => d.TopicDescription.Contains(description)).HelpFile;
        }

        /// <summary>
        /// Maj¹c ju¿ w rêku zagadnienie z pomocy dla zadanej kontrolki nale¿y
        /// w ³añcuchu dziedziczenia kontrolek znaleŸæ tê dla której znaleziono temat pomocy
        /// </summary>
        /// <param name="ChildControl"></param>
        /// <param name="HelpDescription"></param>
        /// <returns></returns>
        public Control FindParentControlForHelpDescription(Control ChildControl, ControlHelpDescription HelpDescription)
        {
            if (HelpDescription != null)
            {
                List<Control> ControlsChain = ControlHelper.GetControlTree(ChildControl);
                foreach (Control AControl in ControlsChain)
                    if (ControlHelper.GetControlShortID(AControl) == HelpDescription.Name)
                        return AControl;
            }

            return null;
        }

        /// <summary>
        /// Maj¹c ju¿ zagadnienie pomocy, funkcja ta pozwala znaleŸæ dok³adniejszy kontekst wi¹zania
        /// jeœli taki wystêpuje
        /// </summary>
        /// <param name="Control"></param>
        /// <param name="HelpDescription"></param>
        /// <returns></returns>
        public BindingContextHelpDescription FindExactBindingContext(Control Control, ControlHelpDescription HelpDescription)
        {
            string[] ControlContext = ControlHelper.GetBindingContext(Control);

            if (HelpDescription != null && ControlContext != null && ControlContext.Length > 0)
                foreach (string ControlContextContent in ControlContext)
                    foreach (BindingContextHelpDescription bc in HelpDescription.BindingContext)
                        if (bc.ContextName == ControlContextContent)
                            return bc;

            return null;
        }

        public string HelpFileForControl(Control Control)
        {
            return Path.GetFileName(HelpFilePathForControl(Control));
        }

        public string HelpFilePathForControl(Control Control)
        {
            //Always prefer the primary help file, otherwise just grab the first help file that maps the control if there even is one.
            var description = _primaryHelpDescription.FindExactDescription(ControlHelper.GetControlIDPath(Control));
            if (description != null && !String.IsNullOrEmpty(description.HelpKeyword))
            {
                return _primaryHelpDescription.HelpFilePath;
            }
            foreach (var otherHelpDescription in _otherHelpDescriptions)
            {
                var otherDescription = otherHelpDescription.FindExactDescription(ControlHelper.GetControlIDPath(Control));
                if ( otherDescription != null && !String.IsNullOrEmpty(otherDescription.HelpKeyword))
                {
                    return otherHelpDescription.HelpFilePath;
                }
            }
            return "";
        }

        public void Save()
        {
            foreach (var helpDescription in AllHelpDescriptions)
            {
                if(!Directory.Exists(PathHelper.DefaultMappingFolder))
                {
                    Directory.CreateDirectory(PathHelper.DefaultMappingFolder);
                }
                using (FileStream fs = File.Create(Path.Combine(PathHelper.DefaultMappingFolder, helpDescription.MappingFile)))
                {
                    var xs = new XmlSerializer( typeof( HelpDescription ) );
                    xs.Serialize(fs, helpDescription);
                }
            }
        }

        private static HelpDescription LoadHelpDescriptionFromFile(string fileToLoad)
        {

            var helpDescription = HelpDescription.Empty;

            try
            {
                Stream stream = null;
                // próbuj z pliku przy aplikacji
                try
                {
                    stream = File.Open(Path.Combine(PathHelper.DefaultMappingFolder, fileToLoad), FileMode.Open);
                }
                catch { }
                // próbuj z zasobów
                if (stream == null)
                    stream = GetApplicationStream(fileToLoad);

                // serializer
                XmlSerializer xs = new XmlSerializer(typeof(HelpDescription));

                if (stream != null)
                {
                    helpDescription = (HelpDescription)xs.Deserialize(stream);
                    stream.Dispose();
                }
                helpDescription.MappingFile = fileToLoad;
            }
            catch { }
            return helpDescription;
        }

        #region Zasoby
        static List<string> examinedAssemblies = new List<string>();
        private static Stream GetApplicationStream( string ResourceName )
        {
            examinedAssemblies.Clear();
            return GetResource( Assembly.GetEntryAssembly(), ResourceName );
        }
        #endregion

        #region Logika
        private static Stream GetResource( Assembly TheAssembly, string ResourceName )
        {
            // szukaj w zasobach bie¿¹cego modu³u
            foreach ( string resName in TheAssembly.GetManifestResourceNames() )
                if ( resName.EndsWith( ResourceName ) )
                    return TheAssembly.GetManifestResourceStream( resName );

            // szukaj w zasobach podmodu³ów
            foreach ( AssemblyName RefAssembly in TheAssembly.GetReferencedAssemblies() )
            {
                if ( !examinedAssemblies.Contains( RefAssembly.FullName ) )
                {
                    examinedAssemblies.Add( RefAssembly.FullName );
                    try
                    {
                        Assembly ChildAssembly = Assembly.Load( RefAssembly );
                        if ( ChildAssembly != null )
                        {
                            Stream resStream = GetResource( ChildAssembly, ResourceName );
                            if ( resStream != null )
                                return resStream;
                        }
                    }
                    catch { }
                }
            }

            return null;
        }
        #endregion

        public void LoadHelpMapBasedOnAssemblyInfoIfPossible(Assembly callingAssembly)
        {
            var attributes = callingAssembly.GetCustomAttributes(typeof(AssemblyHelpMapFileNameAttribute), false);
            if (attributes.Length != 0)
            {
                var helpMap = ((AssemblyHelpMapFileNameAttribute)attributes[0]).HelpMapFileName;
                RegisterSecondaryHelpMapping(helpMap);
            }
        }
    }
}
