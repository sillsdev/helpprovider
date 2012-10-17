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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpEditor));
            this.tvNodes = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.cbNavigator = new System.Windows.Forms.ComboBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.cbShowHelp = new System.Windows.Forms.CheckBox();
            this.lblNavi = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btSave = new System.Windows.Forms.Button();
            this.lblKontekst = new System.Windows.Forms.Label();
            this.lstContext = new System.Windows.Forms.ListView();
            this.ch1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbProperties = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this._helpfileNameLabel = new System.Windows.Forms.Label();
            this._helpfileLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btAddContext = new System.Windows.Forms.Button();
            this.btRemoveContext = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbProperties.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvNodes
            // 
            this.tvNodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvNodes.FullRowSelect = true;
            this.tvNodes.HideSelection = false;
            this.tvNodes.Location = new System.Drawing.Point(3, 16);
            this.tvNodes.Name = "tvNodes";
            this.tvNodes.Size = new System.Drawing.Size(577, 374);
            this.tvNodes.TabIndex = 3;
            this.tvNodes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvNodes_AfterSelect);
            this.tvNodes.Click += new System.EventHandler(this.tvNodes_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Form hierarchy:";
            // 
            // cbNavigator
            // 
            this.cbNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbNavigator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNavigator.FormattingEnabled = true;
            this.cbNavigator.Location = new System.Drawing.Point(65, 42);
            this.cbNavigator.Name = "cbNavigator";
            this.cbNavigator.Size = new System.Drawing.Size(723, 21);
            this.cbNavigator.TabIndex = 4;
            this.cbNavigator.Validated += new System.EventHandler(this.cbNavigator_Validated);
            // 
            // txtCategory
            // 
            this.txtCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCategory.Location = new System.Drawing.Point(65, 16);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(723, 20);
            this.txtCategory.TabIndex = 3;
            this.txtCategory.Validated += new System.EventHandler(this.txtCategory_Validated);
            // 
            // cbShowHelp
            // 
            this.cbShowHelp.AutoSize = true;
            this.cbShowHelp.Location = new System.Drawing.Point(3, 75);
            this.cbShowHelp.Name = "cbShowHelp";
            this.cbShowHelp.Size = new System.Drawing.Size(76, 17);
            this.cbShowHelp.TabIndex = 2;
            this.cbShowHelp.Text = "Show help";
            this.cbShowHelp.UseVisualStyleBackColor = true;
            this.cbShowHelp.Validated += new System.EventHandler(this.cbShowHelp_Validated);
            // 
            // lblNavi
            // 
            this.lblNavi.AutoSize = true;
            this.lblNavi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNavi.Location = new System.Drawing.Point(3, 39);
            this.lblNavi.Name = "lblNavi";
            this.lblNavi.Size = new System.Drawing.Size(56, 27);
            this.lblNavi.TabIndex = 1;
            this.lblNavi.Text = "Navigator:";
            this.lblNavi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "Category:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btSave
            // 
            this.btSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btSave.Image = ((System.Drawing.Image)(resources.GetObject("btSave.Image")));
            this.btSave.Location = new System.Drawing.Point(3, 528);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(32, 32);
            this.btSave.TabIndex = 5;
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // lblKontekst
            // 
            this.lblKontekst.AutoSize = true;
            this.lblKontekst.Location = new System.Drawing.Point(3, 0);
            this.lblKontekst.Name = "lblKontekst";
            this.lblKontekst.Size = new System.Drawing.Size(46, 13);
            this.lblKontekst.TabIndex = 7;
            this.lblKontekst.Text = "Context:";
            // 
            // lstContext
            // 
            this.lstContext.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch1});
            this.lstContext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstContext.FullRowSelect = true;
            this.lstContext.Location = new System.Drawing.Point(3, 16);
            this.lstContext.Name = "lstContext";
            this.lstContext.Size = new System.Drawing.Size(202, 339);
            this.lstContext.TabIndex = 9;
            this.lstContext.UseCompatibleStateImageBehavior = false;
            this.lstContext.View = System.Windows.Forms.View.Details;
            this.lstContext.Click += new System.EventHandler(this.lstContext_Click);
            // 
            // ch1
            // 
            this.ch1.Text = "Text";
            this.ch1.Width = 63;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gbProperties, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btSave, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(809, 563);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // gbProperties
            // 
            this.gbProperties.AutoSize = true;
            this.gbProperties.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbProperties.Controls.Add(this.tableLayoutPanel9);
            this.gbProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbProperties.Enabled = false;
            this.gbProperties.Location = new System.Drawing.Point(3, 408);
            this.gbProperties.Name = "gbProperties";
            this.gbProperties.Size = new System.Drawing.Size(803, 114);
            this.gbProperties.TabIndex = 12;
            this.gbProperties.TabStop = false;
            this.gbProperties.Text = "Properties";
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.AutoSize = true;
            this.tableLayoutPanel9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.cbShowHelp, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel7, 0, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 2;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.Size = new System.Drawing.Size(797, 95);
            this.tableLayoutPanel9.TabIndex = 14;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.lblNavi, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this._helpfileNameLabel, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this._helpfileLabel, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.cbNavigator, 1, 2);
            this.tableLayoutPanel7.Controls.Add(this.txtCategory, 1, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 3;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.Size = new System.Drawing.Size(791, 66);
            this.tableLayoutPanel7.TabIndex = 15;
            // 
            // _helpfileNameLabel
            // 
            this._helpfileNameLabel.AutoSize = true;
            this._helpfileNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._helpfileNameLabel.Location = new System.Drawing.Point(65, 0);
            this._helpfileNameLabel.Name = "_helpfileNameLabel";
            this._helpfileNameLabel.Size = new System.Drawing.Size(723, 13);
            this._helpfileNameLabel.TabIndex = 3;
            this._helpfileNameLabel.Text = "help.chm";
            this._helpfileNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _helpfileLabel
            // 
            this._helpfileLabel.AutoSize = true;
            this._helpfileLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._helpfileLabel.Location = new System.Drawing.Point(3, 0);
            this._helpfileLabel.Name = "_helpfileLabel";
            this._helpfileLabel.Size = new System.Drawing.Size(56, 13);
            this._helpfileLabel.TabIndex = 5;
            this._helpfileLabel.Text = "Helpfile:";
            this._helpfileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 214F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(803, 399);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.tvNodes, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(583, 393);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.lblKontekst, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.lstContext, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 2);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(592, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(208, 393);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.btAddContext, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.btRemoveContext, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 361);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(202, 29);
            this.tableLayoutPanel6.TabIndex = 10;
            // 
            // btAddContext
            // 
            this.btAddContext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btAddContext.Location = new System.Drawing.Point(3, 3);
            this.btAddContext.Name = "btAddContext";
            this.btAddContext.Size = new System.Drawing.Size(95, 23);
            this.btAddContext.TabIndex = 11;
            this.btAddContext.Text = "Add";
            this.btAddContext.UseVisualStyleBackColor = true;
            this.btAddContext.Click += new System.EventHandler(this.btAddContext_Click);
            // 
            // btRemoveContext
            // 
            this.btRemoveContext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btRemoveContext.Location = new System.Drawing.Point(104, 3);
            this.btRemoveContext.Name = "btRemoveContext";
            this.btRemoveContext.Size = new System.Drawing.Size(95, 23);
            this.btRemoveContext.TabIndex = 12;
            this.btRemoveContext.Text = "Remove";
            this.btRemoveContext.UseVisualStyleBackColor = true;
            this.btRemoveContext.Click += new System.EventHandler(this.btRemoveContext_Click);
            // 
            // HelpEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 563);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HelpEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HelpEditor";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.gbProperties.ResumeLayout(false);
            this.gbProperties.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvNodes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbNavigator;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.CheckBox cbShowHelp;
        private System.Windows.Forms.Label lblNavi;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label lblKontekst;
        private System.Windows.Forms.ListView lstContext;
        private System.Windows.Forms.ColumnHeader ch1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.GroupBox gbProperties;
        private System.Windows.Forms.Button btAddContext;
        private System.Windows.Forms.Button btRemoveContext;
        private System.Windows.Forms.Label _helpfileLabel;
        private System.Windows.Forms.Label _helpfileNameLabel;
    }
}