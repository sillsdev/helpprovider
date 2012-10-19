using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace Vulcan.Uczniowie.HelpProvider
{
    [XmlRoot( "XmlHelp", Namespace="http://vulcan.edu.pl/HelpDescription" )]
    public class HelpDescription
    {
        [XmlAttribute( "HelpFile" )]
        public string HelpFile;

        [XmlElement( "Control", typeof( ControlHelpDescription ) )]
        public List<ControlHelpDescription> TopicDescription = new List<ControlHelpDescription>();

        private string _mappingFile;

        #region Public properties
        public string HelpFilePath
        {
            get
            {
                return Path.Combine( PathHelper.DefaultHelpfileFolder, HelpFile );
            }
        }
        #endregion

        #region Description
        public ControlHelpDescription CreateExactDescription( Control Control)
        {
            return CreateExactDescription( ControlHelper.GetControlIDPath( Control ) );
        }

        public ControlHelpDescription CreateExactDescription( string[] ControlPath )
        {
            ControlHelpDescription Description = FindExactDescription( ControlPath );

            if ( Description == null )
                return CreateExactDescription( TopicDescription, ControlPath );
            
            return Description;
        }

        private ControlHelpDescription CreateExactDescription( List<ControlHelpDescription> TopicDescription, string[] ControlPath )
        {
            ControlHelpDescription ChildDescription = null;
            // szukaj opisu pasuj¹cego do prefiksu opisu
            foreach ( ControlHelpDescription Description in TopicDescription )
                if ( Description.Name == ControlPath[0] )
                    ChildDescription = Description;
            // jeœli nie znaleziono to twórz
            if ( ChildDescription == null )
            {
                ChildDescription = new ControlHelpDescription();
                ChildDescription.Name = ControlPath[0];

                TopicDescription.Add( ChildDescription );
            }
            // rekursja
            if ( ControlPath.Length > 1 )
                return CreateExactDescription( ChildDescription.TopicDescription, (string[])ArrayHelper.CreateSubArray( ControlPath, 1, ControlPath.Length - 1 ) );
            else
                return ChildDescription;
        }

        /// <summary>
        /// Funkcja wyszukuje dok³adny obiekt wi¹¿¹cy formant z zagadnieniem pomocy
        /// </summary>
        /// <param name="Control"></param>
        /// <returns></returns>
        public ControlHelpDescription FindExactDescription( Control Control )
        {
            return FindExactDescription( ControlHelper.GetControlIDPath( Control ) );
        }

        public ControlHelpDescription FindExactDescription( string[] ControlPath )
        {
            return FindExactDescription( TopicDescription, ControlPath );
        }

        private ControlHelpDescription FindExactDescription( List<ControlHelpDescription> TopicDescription, string[] ControlPath )
        {
            if ( ControlPath.Length > 0 )
            {
                foreach ( ControlHelpDescription Description in TopicDescription )
                    if ( Description.Name == ControlPath[0] 
                        )
                    {
                        if ( ControlPath.Length == 1 )
                            return Description;
                        else
                            return FindExactDescription( Description.TopicDescription, (string[])ArrayHelper.CreateSubArray( ControlPath, 1, ControlPath.Length - 1 ) );
                    }
            }

            return null;
        }

        /// <summary>
        /// Funkcja wyszukuje temat pomocy w³aœciwy do pokazania tematu pomocy dla formantu.
        /// 
        /// Temat mo¿e dotyczyæ formantu nadrzêdnego, w wypadku braku tematu dok³adnego zwi¹zanego
        /// z danym formantem.
        /// </summary>
        public ControlHelpDescription FindDescription( string[] ControlPath )
        {
            return FindDescription( TopicDescription, null, ControlPath );
        }

        private ControlHelpDescription FindDescription( List<ControlHelpDescription> TopicDescription, ControlHelpDescription LastNonEmpty, string[] ControlPath )
        {
            if ( ControlPath.Length > 0 )
            {
                foreach ( ControlHelpDescription Description in TopicDescription )
                    if ( Description.Name == ControlPath[0] )                         
                    {
                        if ( !string.IsNullOrEmpty( Description.HelpKeyword ) )
                            LastNonEmpty = Description;

                        ControlHelpDescription ChildDescription = FindDescription( Description.TopicDescription, LastNonEmpty, (string[])ArrayHelper.CreateSubArray( ControlPath, 1, ControlPath.Length - 1 ) );
                        if ( ChildDescription != null )
                            return ChildDescription;
                        else
                            return LastNonEmpty; // Description;
                    }
            }

            return null;
        }

        public static HelpDescription Empty
        {
            get
            {
                return new HelpDescription();
            }
        }

        public string MappingFile
        {
            get
            {
                return _mappingFile;
            } 
            set
            {
                if(!String.IsNullOrEmpty(_mappingFile))
                {
                    throw new InvalidOperationException("The mapping file can only be set once and should be done immediately after deserialization.");
                }
                _mappingFile = value;
            }
        }

        #endregion
    }

    /// <summary>
    /// Klasa opisuj¹ca wi¹zanie formantów z tematami pomocy
    /// </summary>
    public class ControlHelpDescription
    {
        [XmlAttribute( "Name" )]
        public string Name;
        [XmlAttribute("HelpKeyword")]
        public string HelpKeyword;
        [XmlAttribute( "HelpNavigator" )]
        public HelpNavigator HelpNavigator = HelpNavigator.Topic;
        [XmlAttribute( "ShowHelp" )]
        public bool ShowHelp = true;

        [XmlElement( "Control", typeof( ControlHelpDescription ) )]
        public List<ControlHelpDescription> TopicDescription = new List<ControlHelpDescription>();
        [XmlElement( "BindingContext", typeof( BindingContextHelpDescription ) )]
        public List<BindingContextHelpDescription> BindingContext = new List<BindingContextHelpDescription>();
    }

    /// <summary>
    /// Klasa opisuj¹ca wi¹zanie kontekstu formantu z tematami pomocy
    /// </summary>
    public class BindingContextHelpDescription
    {
        [XmlAttribute( "ContextName" )]
        public string ContextName;
        [XmlAttribute( "HelpKeyword" )]
        public string HelpKeyword;
        [XmlAttribute( "HelpNavigator" )]
        public HelpNavigator HelpNavigator = HelpNavigator.Topic;
        [XmlAttribute( "ShowHelp" )]
        public bool ShowHelp = true;
    }
}
