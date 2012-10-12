using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vulcan.Uczniowie.HelpProvider
{
    public partial class HelpEditor : Form
    {
        #region Konstrukcja, sk³adowe
        private HelpEditor() { }

        private readonly GraphicalOverlay _overlay = new GraphicalOverlay();

        public HelpEditor( Control Control )
        {
            InitializeComponent();

            InitializeControls();
            InitializePath();
            InitializeTreeForControl( Control );
        }

        protected override void OnFormClosing(FormClosingEventArgs args)
        {
            _overlay.Paint -= OnGraphicalOverlayPaint;
            _overlay.Unwire();
            base.OnFormClosing(args);
        }

        private void InitializeControls()
        {
            foreach ( HelpNavigator v in Enum.GetValues( typeof( HelpNavigator ) ) )
                cbNavigator.Items.Add( v );
            cbNavigator.SelectedItem = HelpNavigator.Topic;
        }

        private HelpDescription HelpDescription = ResourceHelper.HelpDescription;
        #endregion

        #region Logika
        private void InitializePath()
        {
            txtHelpFile.Text = HelpDescription.HelpFile;
        }

        private void InitializeTreeForControl( Control Control )
        {
            string ControlId = ControlHelper.GetControlID( Control );
            string[] ControlIdParts = ControlHelper.GetControlIDPath( ControlId );

            List<Control> ControlTree = ControlHelper.GetControlTree( Control );

            TreeNode Node  = null;
            foreach ( Control c in ControlTree )
            {
                TreeNode CNode  = new TreeNode( ControlHelper.GetControlDescription( c ) );
                CNode.Tag       = c;

                SetNodeProperties( CNode );

                if ( Node == null )
                    tvNodes.Nodes.Add( CNode );
                else
                    Node.Nodes.Add( CNode );                    

                Node = CNode;
            }

            tvNodes.ExpandAll();
        }

        private void SetNodeProperties( TreeNode Node )
        {
            if ( Node.Tag is Control )
            {
                ControlHelpDescription ExactDescription = HelpDescription.FindExactDescription( Node.Tag as Control );
                Node.ForeColor =
                    ExactDescription == null ||
                    string.IsNullOrEmpty( ExactDescription.HelpKeyword ) ?
                    Color.Red : SystemColors.WindowText;
            }
        }

        private void InitializeDescriptionForContext( BindingContextHelpDescription ContextHelpDescription )
        {
            txtCategory.Text = ContextHelpDescription.HelpKeyword;
            cbNavigator.SelectedItem = ContextHelpDescription.HelpNavigator;
            cbShowHelp.Checked = ContextHelpDescription.ShowHelp;
        }
        
        private void InitializeDescriptionForControl( Control Control )
        {
            /* opis w³aœciwoœci formantu */
            ControlHelpDescription Description = HelpDescription.FindExactDescription( Control );
            if ( Description != null )
            {
                txtCategory.Text = Description.HelpKeyword;
                cbNavigator.SelectedItem = Description.HelpNavigator;
                cbShowHelp.Checked = Description.ShowHelp;
            }
            else
            {
                txtCategory.Text = string.Empty;
                cbNavigator.SelectedItem = HelpNavigator.Topic;
                cbShowHelp.Checked = true;
            }

            InitializeContextList( Description );
        }

        private void InitializeContextList( ControlHelpDescription Description )
        {
            /* dodatkowy kontekst wi¹zania */
            lstContext.Items.Clear();

            if ( Description != null )
            {
                lstContext.Enabled = btAddContext.Enabled = true;
                foreach ( BindingContextHelpDescription bc in Description.BindingContext )
                {
                    ListViewItem li = lstContext.Items.Add( bc.ContextName );
                    li.Tag = bc;
                }
            }
            else
            {
                lstContext.Enabled = btAddContext.Enabled = false;
            }
        }
        #endregion

        #region  Obs³uga logiki formantów

        private void txtHelpFile_Validated( object sender, EventArgs e )
        {
            HelpDescription.HelpFile = txtHelpFile.Text;
        }

        private void txtCategory_Validated( object sender, EventArgs e )
        {
            if ( lstContext.SelectedItems.Count > 0 )
            {
                BindingContextHelpDescription bc = lstContext.SelectedItems[0].Tag as BindingContextHelpDescription;
                if ( bc != null )
                    bc.HelpKeyword = txtCategory.Text;
            }
            else
            {
                if ( SelectedDescription != null )
                    SelectedDescription.HelpKeyword = txtCategory.Text;
                SetNodeProperties( tvNodes.SelectedNode );
            }
        }

        private void cbNavigator_Validated( object sender, EventArgs e )
        {
            if ( lstContext.SelectedItems.Count > 0 )
            {
                BindingContextHelpDescription bc = lstContext.SelectedItems[0].Tag as BindingContextHelpDescription;
                if ( bc != null )
                    bc.HelpNavigator = (HelpNavigator)cbNavigator.SelectedItem;
            }
            else
            {
                if ( SelectedDescription != null )
                    SelectedDescription.HelpNavigator = (HelpNavigator)cbNavigator.SelectedItem;
                SetNodeProperties( tvNodes.SelectedNode );
            }
        }

        private void cbShowHelp_Validated( object sender, EventArgs e )
        {
            if ( lstContext.SelectedItems.Count > 0 )
            {
                BindingContextHelpDescription bc = lstContext.SelectedItems[0].Tag as BindingContextHelpDescription;
                if ( bc != null )
                    bc.ShowHelp = cbShowHelp.Checked;
            }
            else
            {
                if ( SelectedDescription != null )
                    SelectedDescription.ShowHelp = cbShowHelp.Checked;
                SetNodeProperties( tvNodes.SelectedNode );
            }
        }

        private ControlHelpDescription SelectedDescription
        {
            get
            {
                if ( tvNodes.SelectedNode.Tag is Control )
                {
                    Control Control = tvNodes.SelectedNode.Tag as Control;
                    return HelpDescription.CreateExactDescription( Control );
                }

                return null;
            }
        }

        private void btAddContext_Click( object sender, EventArgs e )
        {
            if ( tvNodes.SelectedNode != null &&
                 tvNodes.SelectedNode.Tag is Control
                )
            {
                Control c = tvNodes.SelectedNode.Tag as Control;
                string[] ContextA = ControlHelper.GetBindingContext( c );
                if ( ContextA.Length > 0 )
                {
                    string Context = ContextA[0];

                    BindingContextHelpDescription bc = new BindingContextHelpDescription();
                    bc.ContextName = Context;

                    SelectedDescription.BindingContext.Add( bc );
                    InitializeContextList( SelectedDescription );
                }
                else
                    MessageBox.Show( "Kontekst dla wskazanego na drzewie formantu jest pusty.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Information );
            }
            else
                MessageBox.Show( "W drzewie formantów nale¿y zaznaczyæ w³aœciwy formant.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Information );
        }

        private void btRemoveContext_Click( object sender, EventArgs e )
        {
            if ( lstContext.SelectedItems.Count > 0 &&
                 lstContext.SelectedItems[0].Tag is BindingContextHelpDescription
                )
            {
                SelectedDescription.BindingContext.Remove( lstContext.SelectedItems[0].Tag as BindingContextHelpDescription );
                InitializeContextList( SelectedDescription );
            }
        }

        private void btSave_Click( object sender, EventArgs e )
        {
            try
            {
                ResourceHelper.SaveHelpDescription( HelpDescription );
                Close();
            }
            catch ( Exception ex )
            {
                MessageBox.Show( "B³¹d zapisu mapowania pomocy.\r\n\r\n" + ex.Message, "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void tvNodes_Click( object sender, EventArgs e )
        {
            if ( tvNodes.SelectedNode != null && tvNodes.SelectedNode.Tag is Control)
            {
                gbProperties.Enabled = true;
                InitializeDescriptionForControl(tvNodes.SelectedNode.Tag as Control);
            }
            else
                gbProperties.Enabled = false;
        }

        private void OnGraphicalOverlayPaint(object sender, PaintEventArgs e)
        {
                var coordinates = ((Control) tvNodes.SelectedNode.Tag).Coordinates();
                using (Pen pen = new Pen(Color.Red, 5))
                    e.Graphics.DrawRectangle(pen, coordinates);
        }

        private void tvNodes_AfterSelect( object sender, TreeViewEventArgs e )
        {
            if ( e.Node != null && e.Node.Tag is Control)
            {
                //sometimes the focus seems to get left behind on a control that is not parented by the form anymore
                if (_overlay.Owner == null && tvNodes.TopNode.Tag is Form)
                {
                    _overlay.Owner = (Form) tvNodes.TopNode.Tag;
                    _overlay.Paint += OnGraphicalOverlayPaint;
                }
                if (_overlay.Owner != null)
                {
                    _overlay.Owner.Refresh();
                }
                gbProperties.Enabled = true;
                InitializeDescriptionForControl( e.Node.Tag as Control );
            }
            else
                gbProperties.Enabled = false;
        }

        private void lstContext_Click( object sender, EventArgs e )
        {
            if ( lstContext.SelectedItems.Count > 0 &&
                 lstContext.SelectedItems[0].Tag is BindingContextHelpDescription
                )
                InitializeDescriptionForContext( lstContext.SelectedItems[0].Tag as BindingContextHelpDescription );
        }

        #endregion
    }
}