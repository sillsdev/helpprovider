using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vulcan.Uczniowie.HelpProvider
{
    public partial class HelpEditor : Form
    {
        #region Konstrukcja, sk³adowe
        private HelpEditor() { }

        private readonly GraphicalOverlay _overlay = new GraphicalOverlay();
        private HelpFileDisplayAdaptor[] _comboBoxItems;
        private HelpDescriptions HelpDescriptions = ResourceHelper.HelpDescriptions;

        public HelpEditor( Control Control )
        {
            InitializeComponent();
            GetHelpfileToUseIfNecessary();
            InitializeControls();
            InitializePath();
            InitializeTreeForControl( Control );
        }

        private void GetHelpfileToUseIfNecessary()
        {
            if (String.IsNullOrEmpty(ResourceHelper.HelpDescriptions.PrimaryHelpFile))
            {
                using (var selectHelpFileDialog = new SelectPrimaryHelpfileDialog())
                {
                    var dialogResult = selectHelpFileDialog.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        HelpDescriptions.PrimaryHelpFile = selectHelpFileDialog.SelectedHelpFile;
                    }
                    else
                    {
                        Close();
                    }
                }
            }
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

            _comboBoxItems = HelpDescriptions.AllHelpFiles.Select(
                     hf => new HelpFileDisplayAdaptor(hf, HelpDescriptions.GetMappingNameForHelpFile(hf))).ToArray();
            _helpfilesComboBox.Items.AddRange(_comboBoxItems);
            _helpfilesComboBox.SelectedItem = _helpfilesComboBox.Items[0];
            _helpfilesComboBox.SelectionChangeCommitted += OnHelpfilesComboBoxSelectionChangeCommitted;
        }

        private void OnHelpfilesComboBoxSelectionChangeCommitted(object sender, EventArgs e)
        {
            SaveFormDataToControlHelpDescription();
        }

        #endregion

        #region Logika
        private void InitializePath()
        {
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
                ControlHelpDescription ExactDescription = HelpDescriptions.FindExactDescription( Node.Tag as Control );
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
        }
        
        private void InitializeDescriptionForControl( Control Control )
        {
            /* opis w³aœciwoœci formantu */
            ControlHelpDescription Description = HelpDescriptions.FindExactDescription( Control );
            if ( Description != null )
            {
                string helpFile = HelpDescriptions.HelpFileForControl(Control);
                if(!String.IsNullOrEmpty(helpFile))
                {
                    _helpfilesComboBox.SelectedItem = _comboBoxItems.Single(i => i.HelpFile == helpFile);
                }
                gbProperties.Enabled = true;
                txtCategory.Text = Description.HelpKeyword;
                cbNavigator.SelectedItem = Description.HelpNavigator;
            }
            else
            {
                _helpfilesComboBox.SelectedItem = _comboBoxItems.Single(i => i.HelpFile == HelpDescriptions.PrimaryHelpFile);
                txtCategory.Text = string.Empty;
                cbNavigator.SelectedItem = HelpNavigator.Topic;
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

        private void txtCategory_Validated( object sender, EventArgs e )
        {
            SaveFormDataToControlHelpDescription();
        }

        private void SaveFormDataToControlHelpDescription()
        {
            if (lstContext.SelectedItems.Count > 0)
            {
                BindingContextHelpDescription bc = lstContext.SelectedItems[0].Tag as BindingContextHelpDescription;
                if (bc != null)
                    bc.HelpKeyword = txtCategory.Text;
            }
            else
            {
                if (SelectedDescription != null)
                {
                    SelectedDescription.HelpKeyword = txtCategory.Text;
                }
                SetNodeProperties(tvNodes.SelectedNode);
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

        private ControlHelpDescription SelectedDescription
        {
            get
            {
                if ( tvNodes.SelectedNode.Tag is Control )
                {
                    Control Control = tvNodes.SelectedNode.Tag as Control;
                    return HelpDescriptions.CreateExactDescription( Control , ((HelpFileDisplayAdaptor) _helpfilesComboBox.SelectedItem).MappingFile);
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
                ResourceHelper.SaveHelpDescriptions();
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

        private class HelpFileDisplayAdaptor
        {
            private readonly string _helpFile;
            private readonly string _mappingFile;

            public HelpFileDisplayAdaptor(string helpFile, string mappingFile)
            {
                _helpFile = helpFile;
                _mappingFile = mappingFile;
            }

            public string HelpFile
            {
                get { return _helpFile; }
            }

            public string MappingFile
            {
                get { return _mappingFile; }
            }

            public override string ToString()
            {
                return String.Format("{0} ({1})", _helpFile, _mappingFile);
            }
        }
    }
}