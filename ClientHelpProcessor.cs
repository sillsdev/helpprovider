using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;

namespace Vulcan.Uczniowie.HelpProvider
{
    public class ClientHelpProcessor : IHelpProcessor
    {
        #region IHelpProcessor Members
        public void ProcessControlHelp( System.Windows.Forms.Control Control )
        {
            string ControlId = ControlHelper.GetControlID( Control );
            string[] ControlIdParts = ControlHelper.GetControlIDPath( ControlId );

            if ( !ResourceHelper.HelpDescriptions.IsEmpty )
            {
                // zagadnienie pomocy
                ControlHelpDescription TopicDescription = ResourceHelper.HelpDescriptions.FindDescription( ControlIdParts );
                // kontrolka, której to zagadnienie dotyczy
                Control HelpControl = ResourceHelper.HelpDescriptions.FindParentControlForHelpDescription( Control, TopicDescription );

                if ( TopicDescription != null )
                {
                    /* a mo¿e jest œciœlejszy kontekst dla kontrolki dla której znaleziono temat pomocy? */
                    BindingContextHelpDescription Bc = ResourceHelper.HelpDescriptions.FindExactBindingContext( HelpControl, TopicDescription );
                    if (  Bc != null && 
                         !string.IsNullOrEmpty( Bc.HelpKeyword ) &&
                          Bc.ShowHelp )
                        Help.ShowHelp(Control, ResourceHelper.HelpDescriptions.HelpFilePathForControl(HelpControl), Bc.HelpNavigator, Bc.HelpKeyword);
                    else
                        Help.ShowHelp(Control, ResourceHelper.HelpDescriptions.HelpFilePathForControl(HelpControl), TopicDescription.HelpNavigator, TopicDescription.HelpKeyword);
                }
                else
                    if ( !string.IsNullOrEmpty ( ResourceHelper.HelpDescriptions.PrimaryHelpFile ) )
                        Help.ShowHelp( Control, ResourceHelper.HelpDescriptions.PrimaryHelpFilePath );
            }
        }
        #endregion
    }
}
