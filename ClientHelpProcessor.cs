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

            if ( !HelpDescriptions.Singleton.IsEmpty )
            {
                // zagadnienie pomocy
                ControlHelpDescription TopicDescription = HelpDescriptions.Singleton.FindDescription( ControlIdParts );
                // kontrolka, której to zagadnienie dotyczy
                Control HelpControl = HelpDescriptions.Singleton.FindParentControlForHelpDescription( Control, TopicDescription );

                if ( TopicDescription != null )
                {
                    /* a mo¿e jest œciœlejszy kontekst dla kontrolki dla której znaleziono temat pomocy? */
                    BindingContextHelpDescription Bc = HelpDescriptions.Singleton.FindExactBindingContext( HelpControl, TopicDescription );
                    if (  Bc != null && 
                         !string.IsNullOrEmpty( Bc.HelpKeyword ) &&
                          Bc.ShowHelp )
                        Help.ShowHelp(Control, HelpDescriptions.Singleton.HelpFilePathForControl(HelpControl), Bc.HelpNavigator, Bc.HelpKeyword);
                    else
                        Help.ShowHelp(Control, HelpDescriptions.Singleton.HelpFilePathForControl(HelpControl), TopicDescription.HelpNavigator, TopicDescription.HelpKeyword);
                }
                else
                    if ( !string.IsNullOrEmpty ( HelpDescriptions.Singleton.PrimaryHelpFile ) )
                        Help.ShowHelp( Control, HelpDescriptions.Singleton.PrimaryHelpFilePath );
            }
        }
        #endregion
    }
}
