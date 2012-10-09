using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Vulcan.Uczniowie.HelpProvider
{
    public class ControlHelper
    {
        #region Kontekst wi¹zania
        /// <summary>
        /// Pobierz kontekst wi¹zania, mo¿e to byæ ca³a œcie¿ka - przydatne do drzew
        /// 
        /// </summary>
        /// <param name="Control"></param>
        /// <returns></returns>
        public static string[] GetBindingContext( Control Control )
        {
            /* obs³uga szczególnych typów formantów */

            #region TreeView
            if ( Control is ListView )
            {
                ListView l = Control as ListView;
                if ( l.SelectedItems.Count > 0 &&
                     l.SelectedItems[0].Tag != null
                    )
                    return new string[] { string.Format( "element {0}", l.SelectedItems[0].Tag.GetType().Name ) };
                else
                    return new string[] { string.Empty };
            }

            if ( Control is TreeView )
            {
                TreeView t = Control as TreeView;
                if ( t.SelectedNode != null )
                    return BuildBindingContext( t.SelectedNode );
                else
                    return new string[] { string.Empty };
            }
            #endregion

            #region TabControl
            if ( Control is TabControl )
            {
                TabControl tb = Control as TabControl;
                if ( tb.SelectedTab != null )
                    return new string[] { tb.SelectedTab.Text };
                else
                    return new string[] { string.Empty };
            }
            #endregion

            return new string[] { Control.Text };
        }

        private static string[] BuildBindingContext( TreeNode treeNode )
        {
            List<string> ret = new List<string>();

            BuildBindingContext( treeNode, ret );

            return ret.ToArray();
        }

        private static void BuildBindingContext( TreeNode treeNode, List<string> ret )
        {
            if ( treeNode != null )
            {
                ret.Add( treeNode.Text );
                BuildBindingContext( treeNode.Parent, ret );
            }
        }

        public static bool IsBindingTextMatch( Control Control, ControlHelpDescription Description )
        {
//            return string.IsNullOrEmpty( Description.BindingText ) ||
//                   Description.BindingText.Trim() == GetBindingText( Control ).Trim();
            return false;
        }
        #endregion

        #region Control ID
        public static string GetControlShortID( Control Control )
        {
            if ( Control is Form ||
                 Control.Parent == null
                )
                return Control.GetType().FullName;
            else
                return Control.Name;
        }

        public static string GetControlID( Control Control )
        {
            if ( Control is Form ||
                 Control.Parent == null
                )
                return Control.GetType().FullName;
            else

                return string.Format( "{0}/{1}", GetControlID( Control.Parent ), Control.Name );
        }

        public static string[] GetControlIDPath( Control Control )
        {
            return GetControlIDPath( GetControlID( Control ) );
        }

        public static string[] GetControlIDPath( string ControlID )
        {
            return ControlID.Split( '/' );
        }

        public static List<Control> GetControlTree( Control Control )
        {
            List<Control> ret = new List<Control>();

            ret = GetControlTree( Control, ret );
            ret.Reverse();

            return ret;
        }

        private static List<Control> GetControlTree( Control Control, List<Control> ret )
        {
            if ( Control == null )
                return ret;

            ret.Add( Control );
            return GetControlTree( Control.Parent, ret );
        }

        public static string GetControlDescription( Control Control )
        {
            if ( Control == null ) return "[pusty]";

            if ( Control is Form )
                return string.Format( "{0}", Control.GetType().FullName );
            else
                return string.Format( "{0} [{1}]", Control.Name, Control.GetType().Name );
        }
        #endregion
    }
}
