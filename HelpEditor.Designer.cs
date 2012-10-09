namespace Vulcan.Uczniowie.HelpProvider
{
    partial class HelpEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( HelpEditor ) );
            this.label1 = new System.Windows.Forms.Label();
            this.txtHelpFile = new System.Windows.Forms.TextBox();
            this.tvNodes = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.gbProperties = new System.Windows.Forms.GroupBox();
            this.cbNavigator = new System.Windows.Forms.ComboBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.cbShowHelp = new System.Windows.Forms.CheckBox();
            this.lblNavi = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btSave = new System.Windows.Forms.Button();
            this.lblKontekst = new System.Windows.Forms.Label();
            this.btAddContext = new System.Windows.Forms.Button();
            this.lstContext = new System.Windows.Forms.ListView();
            this.ch1 = new System.Windows.Forms.ColumnHeader();
            this.btRemoveContext = new System.Windows.Forms.Button();
            this.gbProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 9, 21 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 108, 13 );
            this.label1.TabIndex = 1;
            this.label1.Text = "Nazwa pliku pomocy:";
            // 
            // txtHelpFile
            // 
            this.txtHelpFile.Location = new System.Drawing.Point( 123, 18 );
            this.txtHelpFile.Name = "txtHelpFile";
            this.txtHelpFile.Size = new System.Drawing.Size( 315, 20 );
            this.txtHelpFile.TabIndex = 2;
            this.txtHelpFile.Validated += new System.EventHandler( this.txtHelpFile_Validated );
            // 
            // tvNodes
            // 
            this.tvNodes.FullRowSelect = true;
            this.tvNodes.HideSelection = false;
            this.tvNodes.Location = new System.Drawing.Point( 12, 70 );
            this.tvNodes.Name = "tvNodes";
            this.tvNodes.Size = new System.Drawing.Size( 426, 134 );
            this.tvNodes.TabIndex = 3;
            this.tvNodes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.tvNodes_AfterSelect );
            this.tvNodes.Click += new System.EventHandler( this.tvNodes_Click );
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 9, 54 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 48, 13 );
            this.label2.TabIndex = 4;
            this.label2.Text = "Formant:";
            // 
            // gbProperties
            // 
            this.gbProperties.Controls.Add( this.cbNavigator );
            this.gbProperties.Controls.Add( this.txtCategory );
            this.gbProperties.Controls.Add( this.cbShowHelp );
            this.gbProperties.Controls.Add( this.lblNavi );
            this.gbProperties.Controls.Add( this.label3 );
            this.gbProperties.Enabled = false;
            this.gbProperties.Location = new System.Drawing.Point( 12, 206 );
            this.gbProperties.Name = "gbProperties";
            this.gbProperties.Size = new System.Drawing.Size( 618, 97 );
            this.gbProperties.TabIndex = 5;
            this.gbProperties.TabStop = false;
            this.gbProperties.Text = "W³aœciwoœci:";
            // 
            // cbNavigator
            // 
            this.cbNavigator.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.cbNavigator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNavigator.FormattingEnabled = true;
            this.cbNavigator.Location = new System.Drawing.Point( 74, 45 );
            this.cbNavigator.Name = "cbNavigator";
            this.cbNavigator.Size = new System.Drawing.Size( 538, 21 );
            this.cbNavigator.TabIndex = 4;
            this.cbNavigator.Validated += new System.EventHandler( this.cbNavigator_Validated );
            // 
            // txtCategory
            // 
            this.txtCategory.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.txtCategory.Location = new System.Drawing.Point( 74, 19 );
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size( 538, 20 );
            this.txtCategory.TabIndex = 3;
            this.txtCategory.Validated += new System.EventHandler( this.txtCategory_Validated );
            // 
            // cbShowHelp
            // 
            this.cbShowHelp.AutoSize = true;
            this.cbShowHelp.Location = new System.Drawing.Point( 74, 72 );
            this.cbShowHelp.Name = "cbShowHelp";
            this.cbShowHelp.Size = new System.Drawing.Size( 91, 17 );
            this.cbShowHelp.TabIndex = 2;
            this.cbShowHelp.Text = "Poka¿ pomoc";
            this.cbShowHelp.UseVisualStyleBackColor = true;
            this.cbShowHelp.Validated += new System.EventHandler( this.cbShowHelp_Validated );
            // 
            // lblNavi
            // 
            this.lblNavi.AutoSize = true;
            this.lblNavi.Location = new System.Drawing.Point( 13, 48 );
            this.lblNavi.Name = "lblNavi";
            this.lblNavi.Size = new System.Drawing.Size( 58, 13 );
            this.lblNavi.TabIndex = 1;
            this.lblNavi.Text = "Nawigator:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 13, 22 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 55, 13 );
            this.label3.TabIndex = 0;
            this.label3.Text = "Kategoria:";
            // 
            // btSave
            // 
            this.btSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btSave.Image = ( (System.Drawing.Image)( resources.GetObject( "btSave.Image" ) ) );
            this.btSave.Location = new System.Drawing.Point( 598, 18 );
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size( 32, 32 );
            this.btSave.TabIndex = 5;
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler( this.btSave_Click );
            // 
            // lblKontekst
            // 
            this.lblKontekst.AutoSize = true;
            this.lblKontekst.Location = new System.Drawing.Point( 441, 54 );
            this.lblKontekst.Name = "lblKontekst";
            this.lblKontekst.Size = new System.Drawing.Size( 52, 13 );
            this.lblKontekst.TabIndex = 7;
            this.lblKontekst.Text = "Kontekst:";
            // 
            // btAddContext
            // 
            this.btAddContext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btAddContext.Location = new System.Drawing.Point( 606, 70 );
            this.btAddContext.Name = "btAddContext";
            this.btAddContext.Size = new System.Drawing.Size( 24, 75 );
            this.btAddContext.TabIndex = 8;
            this.btAddContext.Text = "+";
            this.btAddContext.UseVisualStyleBackColor = true;
            this.btAddContext.Click += new System.EventHandler( this.btAddContext_Click );
            // 
            // lstContext
            // 
            this.lstContext.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.ch1} );
            this.lstContext.FullRowSelect = true;
            this.lstContext.Location = new System.Drawing.Point( 445, 70 );
            this.lstContext.Name = "lstContext";
            this.lstContext.Size = new System.Drawing.Size( 163, 134 );
            this.lstContext.TabIndex = 9;
            this.lstContext.UseCompatibleStateImageBehavior = false;
            this.lstContext.View = System.Windows.Forms.View.Details;
            this.lstContext.Click += new System.EventHandler( this.lstContext_Click );
            // 
            // ch1
            // 
            this.ch1.Text = "Tekst";
            this.ch1.Width = 158;
            // 
            // btRemoveContext
            // 
            this.btRemoveContext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btRemoveContext.Location = new System.Drawing.Point( 606, 144 );
            this.btRemoveContext.Name = "btRemoveContext";
            this.btRemoveContext.Size = new System.Drawing.Size( 24, 60 );
            this.btRemoveContext.TabIndex = 10;
            this.btRemoveContext.Text = "-";
            this.btRemoveContext.UseVisualStyleBackColor = true;
            this.btRemoveContext.Click += new System.EventHandler( this.btRemoveContext_Click );
            // 
            // HelpEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 645, 310 );
            this.Controls.Add( this.btRemoveContext );
            this.Controls.Add( this.btAddContext );
            this.Controls.Add( this.lstContext );
            this.Controls.Add( this.lblKontekst );
            this.Controls.Add( this.btSave );
            this.Controls.Add( this.gbProperties );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.tvNodes );
            this.Controls.Add( this.txtHelpFile );
            this.Controls.Add( this.label1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HelpEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HelpEditor";
            this.gbProperties.ResumeLayout( false );
            this.gbProperties.PerformLayout();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHelpFile;
        private System.Windows.Forms.TreeView tvNodes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbProperties;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbNavigator;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.CheckBox cbShowHelp;
        private System.Windows.Forms.Label lblNavi;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label lblKontekst;
        private System.Windows.Forms.Button btAddContext;
        private System.Windows.Forms.ListView lstContext;
        private System.Windows.Forms.ColumnHeader ch1;
        private System.Windows.Forms.Button btRemoveContext;
    }
}