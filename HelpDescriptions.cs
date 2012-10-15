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
        private HelpDescription _primaryHelpDescription;
        private List<HelpDescription> _otherDescriptions = new List<HelpDescription>();

        public HelpDescriptions(HelpDescription primaryHelpDescription, IEnumerable<HelpDescription> otherHelpMappings)
        {
            _primaryHelpDescription = primaryHelpDescription;
        }

        public bool IsEmpty
        {
            get { return _primaryHelpDescription == null && _otherDescriptions.Count == 0; }
        }

        public ControlHelpDescription CreateExactDescriptionForHelpFile(Control Control)
        {
            return _primaryHelpDescription.CreateExactDescription(Control);
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
    }
}
