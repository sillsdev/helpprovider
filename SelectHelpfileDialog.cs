using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vulcan.Uczniowie.HelpProvider
{
    public partial class SelectHelpfileDialog : Form
    {
        public SelectHelpfileDialog()
        {
            InitializeComponent();
            _okButton.Click += OnOkClicked;
            _cancelButton.Click += OnCancelClicked;
            _helpfileComboBox.Items.AddRange(Directory.GetFiles(PathHelper.DefaultHelpfileFolder, "*.chm").Select(p=>Path.GetFileName(p)).ToArray());
            _helpfileComboBox.SelectionChangeCommitted += OnSelectionChangeCommitted;
            _okButton.Enabled = false;
            if(_helpfileComboBox.Items.Count>0)
            {
                _helpfileComboBox.SelectedItem = _helpfileComboBox.Items[0];
                _okButton.Enabled = true;
            }
            _infoLabel.Text = String.Format(_infoLabel.Text, PathHelper.DefaultMappingFolder, PathHelper.DefaultHelpfileFolder);
        }

        public string SelectedHelpFile { get; private set; }

        private void OnSelectionChangeCommitted(object sender, EventArgs e)
        {
            SelectedHelpFile = (string) _helpfileComboBox.SelectedItem;
        }

        private void OnCancelClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OnOkClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
