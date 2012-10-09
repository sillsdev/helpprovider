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

            if ( ResourceHelper.HelpDescription != HelpDescription.Empty )
            {
                // zagadnienie pomocy
                ControlHelpDescription TopicDescription = ResourceHelper.HelpDescription.FindDescription( ControlIdParts );
                // kontrolka, której to zagadnienie dotyczy
                Control HelpControl = ResourceHelper.HelpDescription.FindParentControlForHelpDescription( Control, TopicDescription );

                if ( TopicDescription != null )
                {
                    /* a mo¿e jest œciœlejszy kontekst dla kontrolki dla której znaleziono temat pomocy? */
                    BindingContextHelpDescription Bc = ResourceHelper.HelpDescription.FindExactBindingContext( HelpControl, TopicDescription );
                    if (  Bc != null && 
                         !string.IsNullOrEmpty( Bc.HelpKeyword ) &&
                          Bc.ShowHelp )
                        Help.ShowHelp( Control, ResourceHelper.HelpDescription.HelpFilePath, Bc.HelpNavigator, Bc.HelpKeyword );
                    else
                    if ( TopicDescription.ShowHelp )
                        Help.ShowHelp( Control, ResourceHelper.HelpDescription.HelpFilePath, TopicDescription.HelpNavigator, TopicDescription.HelpKeyword );
                }
                else
                    if ( !string.IsNullOrEmpty ( ResourceHelper.HelpDescription.HelpFile ) )
                        Help.ShowHelp( Control, ResourceHelper.HelpDescription.HelpFilePath );
            }
        }
        #endregion
    }
}
