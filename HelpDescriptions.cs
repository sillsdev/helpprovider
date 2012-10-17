using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Vulcan.Uczniowie.HelpProvider
{
    public class HelpDescriptions
    {
        private readonly HelpDescription _primaryHelpDescription;
        private readonly List<HelpDescription> _otherDescriptions = new List<HelpDescription>();

        public HelpDescriptions(HelpDescription primaryHelpDescription, IEnumerable<HelpDescription> otherHelpMappings)
        {
            _primaryHelpDescription = primaryHelpDescription;
            _otherDescriptions.AddRange(otherHelpMappings);
        }

        public bool IsEmpty
        {
            get { return _primaryHelpDescription.TopicDescription.Count == 0 && _otherDescriptions.Count == 0; }
        }

        public string PrimaryHelpFile
        {
            get { return _primaryHelpDescription.HelpFile; }
            set { _primaryHelpDescription.HelpFile = value; }
        }

        public string PrimaryHelpFilePath
        {
            get { return _primaryHelpDescription.HelpFilePath; }
        }

        public bool FoundHelpMapping
        {
            get 
            { 
                return _primaryHelpDescription.TopicDescription.Count > 0 || _otherDescriptions.Any(o=>o.TopicDescription.Count > 0);
            }
        }

        public IEnumerable<string> AllHelpFilePaths
        {
            get { return new[]{_primaryHelpDescription}.Concat(_otherDescriptions).Select(hd=>hd.HelpFilePath); }
        }

        public ControlHelpDescription CreateExactDescriptionForHelpFile(Control Control)
        {
            return _primaryHelpDescription.CreateExactDescription(Control);
        }

        /// <summary>
        /// Funkcja wyszukuje dok³adny obiekt wi¹¿¹cy formant z zagadnieniem pomocy
        /// </summary>
        /// <param name="Control"></param>
        /// <returns></returns>
        public ControlHelpDescription FindExactDescription(Control Control)
        {
            //Always prefer descriptions found in the primary helpdescription, otherwise just grab the first description if there even is one
            var description = _primaryHelpDescription.FindExactDescription(Control);
            if (description == null || String.IsNullOrEmpty(description.HelpKeyword))
            {
                foreach (var otherDescription in _otherDescriptions)
                {
                    description = otherDescription.FindExactDescription(Control);
                    if (description != null)
                    {
                        break;
                    }
                }
            }
            return description;
        }

        public ControlHelpDescription FindDescription(string[] controlIdParts)
        {
            //Always prefer descriptions found in the primary helpdescription, otherwise just grab the first description if there even is one
            var description =_primaryHelpDescription.FindDescription(controlIdParts);
            if( description == null)
            {
                foreach (var otherDescription in _otherDescriptions)
                {
                    description = otherDescription.FindDescription(controlIdParts);
                    if( description != null)
                    {
                        break;
                    }
                }
            }
            return description;
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

            if (HelpDescription != null &&
                 ControlContext.Length > 0
                )
                foreach (string ControlContextContent in ControlContext)
                    foreach (BindingContextHelpDescription bc in HelpDescription.BindingContext)
                        if (bc.ContextName == ControlContextContent)
                            return bc;

            return null;
        }

        public string HelpFilePathForControl(Control Control)
        {
            //Always prefer the primary help file, otherwise just grab the first help file that maps the control if there even is one.
            if(_primaryHelpDescription.FindDescription(ControlHelper.GetControlIDPath(Control)) != null)
            {
                return _primaryHelpDescription.HelpFilePath;
            }
            foreach (var otherDescription in _otherDescriptions)
            {
                if (otherDescription.FindDescription(ControlHelper.GetControlIDPath(Control)) != null)
                {
                    return otherDescription.HelpFilePath;
                }
            }
            return "";
        }

        public string HelpFileForControl(Control Control)
        {
            //Always prefer the primary help file, otherwise just grab the first help file that maps the control if there even is one.
            if (_primaryHelpDescription.FindDescription(ControlHelper.GetControlIDPath(Control)) != null)
            {
                return _primaryHelpDescription.HelpFile;
            }
            foreach (var otherDescription in _otherDescriptions)
            {
                if (otherDescription.FindDescription(ControlHelper.GetControlIDPath(Control)) != null)
                {
                    return otherDescription.HelpFile;
                }
            }
            return "";
        }

        public ControlHelpDescription CreateExactDescription(Control control)
        {
            return _primaryHelpDescription.CreateExactDescription(control);
        }
    }
}
