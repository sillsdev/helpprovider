using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Vulcan.Uczniowie.HelpProvider
{
    public static class ResourceHelper
    {
        #region Zasób z informacj¹ o helpie - klient
        private static HelpDescriptions _helpDescriptions;
        private static HelpDescription _primaryHelpDescription;
        /// <summary>
        /// Kolejnoœæ ³adowania opisu:
        /// 
        /// 1. plik w zasobach aplikacji
        /// 2. plik przy execu aplikacji
        /// </summary>
        public static HelpDescriptions HelpDescriptions
        {
            get
            {
                if ( _helpDescriptions == null)
                {
                    _primaryHelpDescription = LoadHelpDescriptionFromFile(PathHelper.PrimaryHelpMapping);
                    var otherHelpMappings = new List<HelpDescription>(PathHelper.SecondaryHelpMappings.Select(o=>LoadHelpDescriptionFromFile(o)));
                    _helpDescriptions = new HelpDescriptions(_primaryHelpDescription, otherHelpMappings);
                }
                return _helpDescriptions;
            }
        }

        public static bool PrimaryHelpMapAlreadyLoaded
        {
            get { return _primaryHelpDescription != null; }
        }

        #endregion

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
            }
            catch { }
            return helpDescription;
        }

        #region Zasób z informacj¹ o helpie - builder
        public static void SaveHelpDescription()
        {
            if ( HelpDescriptions != null )
            {
                using ( FileStream fs = File.Create( PathHelper.WritableHelpmappingPath ) )
                {
                    XmlSerializer xs = new XmlSerializer( typeof( HelpDescription ) );
                    xs.Serialize(fs, _primaryHelpDescription);
                }
            }
        }
        #endregion

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
    }
}
