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
    public class ResourceHelper
    {
        #region Zasób z informacj¹ o helpie - klient
        private static HelpDescriptions _helpDescriptions;
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
                if ( _helpDescriptions == null )
                {
                    var primaryHelpMapping = LoadHelpDescriptionFromFile(PathHelper.PrimaryHelpMappingPath);
                    var otherHelpMappings = new List<HelpDescription>(PathHelper.OtherHelpMappingPaths.Select(o=>LoadHelpDescriptionFromFile(o)));
                    _helpDescriptions = new HelpDescriptions(primaryHelpMapping, otherHelpMappings);
                }
                return _helpDescriptions;
            }
        }
        #endregion

        private static HelpDescription LoadHelpDescriptionFromFile(string pathToFileToLoad)
        {

            var helpDescription = HelpDescription.Empty;

            try
            {
                Stream stream = null;
                // próbuj z pliku przy aplikacji
                try
                {
                    stream = File.Open(PathHelper.ClientLocalHelpFilePath, FileMode.Open);
                }
                catch { }
                // próbuj z zasobów
                if (stream == null)
                    stream = ResourceHelper.GetApplicationStream(PathHelper.BareFile);

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
        public static void SaveHelpDescription( HelpDescription HelpDescription )
        {
            if ( HelpDescription != null )
            {
                using ( FileStream fs = File.Create( PathHelper.ClientLocalHelpFilePath ) )
                {
                    XmlSerializer xs = new XmlSerializer( typeof( HelpDescription ) );
                    xs.Serialize( fs, HelpDescription );
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
