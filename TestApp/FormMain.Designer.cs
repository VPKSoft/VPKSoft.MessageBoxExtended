namespace TestApp
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btTestErrorMessage = new System.Windows.Forms.Button();
            this.btTestPasswordDialog = new System.Windows.Forms.Button();
            this.btStringQueryTest = new System.Windows.Forms.Button();
            this.btTestDropDownSelect = new System.Windows.Forms.Button();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabDialogTest = new System.Windows.Forms.TabPage();
            this.tabResizeDialogContainer = new System.Windows.Forms.TabPage();
            this.messageBoxContainerResize = new VPKSoft.MessageBoxExtended.Controls.MessageBoxContainerToolset();
            this.tabExpandStack = new System.Windows.Forms.TabPage();
            this.messageBoxExpandStack = new VPKSoft.MessageBoxExtended.Controls.MessageBoxExpandStack();
            this.lbDialogTitle = new System.Windows.Forms.Label();
            this.lbDialogText = new System.Windows.Forms.Label();
            this.tbDialogTitle = new System.Windows.Forms.TextBox();
            this.tbDialogText = new System.Windows.Forms.TextBox();
            this.lbDialogType = new System.Windows.Forms.Label();
            this.cmbDialogType = new System.Windows.Forms.ComboBox();
            this.cmbDialogButtons = new System.Windows.Forms.ComboBox();
            this.lbDialogButtons = new System.Windows.Forms.Label();
            this.btAddDialog = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.pnTabPageFirst = new System.Windows.Forms.Panel();
            this.cmbLocale = new System.Windows.Forms.ComboBox();
            this.lbLocalize = new System.Windows.Forms.Label();
            this.tcMain.SuspendLayout();
            this.tabDialogTest.SuspendLayout();
            this.tabResizeDialogContainer.SuspendLayout();
            this.tabExpandStack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.pnTabPageFirst.SuspendLayout();
            this.SuspendLayout();
            // 
            // btTestErrorMessage
            // 
            this.btTestErrorMessage.Location = new System.Drawing.Point(6, 6);
            this.btTestErrorMessage.Name = "btTestErrorMessage";
            this.btTestErrorMessage.Size = new System.Drawing.Size(243, 23);
            this.btTestErrorMessage.TabIndex = 0;
            this.btTestErrorMessage.Text = "Test error message";
            this.btTestErrorMessage.UseVisualStyleBackColor = true;
            this.btTestErrorMessage.Click += new System.EventHandler(this.btTestErrorMessage_Click);
            // 
            // btTestPasswordDialog
            // 
            this.btTestPasswordDialog.Location = new System.Drawing.Point(6, 35);
            this.btTestPasswordDialog.Name = "btTestPasswordDialog";
            this.btTestPasswordDialog.Size = new System.Drawing.Size(243, 23);
            this.btTestPasswordDialog.TabIndex = 1;
            this.btTestPasswordDialog.Text = "Password dialog test";
            this.btTestPasswordDialog.UseVisualStyleBackColor = true;
            this.btTestPasswordDialog.Click += new System.EventHandler(this.btTestPasswordDialog_Click);
            // 
            // btStringQueryTest
            // 
            this.btStringQueryTest.Location = new System.Drawing.Point(6, 64);
            this.btStringQueryTest.Name = "btStringQueryTest";
            this.btStringQueryTest.Size = new System.Drawing.Size(243, 23);
            this.btStringQueryTest.TabIndex = 2;
            this.btStringQueryTest.Text = "Query string input (with validation)";
            this.btStringQueryTest.UseVisualStyleBackColor = true;
            this.btStringQueryTest.Click += new System.EventHandler(this.btStringQueryTest_Click);
            // 
            // btTestDropDownSelect
            // 
            this.btTestDropDownSelect.Location = new System.Drawing.Point(6, 93);
            this.btTestDropDownSelect.Name = "btTestDropDownSelect";
            this.btTestDropDownSelect.Size = new System.Drawing.Size(243, 23);
            this.btTestDropDownSelect.TabIndex = 3;
            this.btTestDropDownSelect.Text = "A dropdown list selection test";
            this.btTestDropDownSelect.UseVisualStyleBackColor = true;
            this.btTestDropDownSelect.Click += new System.EventHandler(this.btTestDropDownSelect_Click);
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMain.Controls.Add(this.tabDialogTest);
            this.tcMain.Controls.Add(this.tabResizeDialogContainer);
            this.tcMain.Controls.Add(this.tabExpandStack);
            this.tcMain.Location = new System.Drawing.Point(12, 12);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(685, 335);
            this.tcMain.TabIndex = 4;
            this.tcMain.Selected += new System.Windows.Forms.TabControlEventHandler(this.tcMain_Selected);
            // 
            // tabDialogTest
            // 
            this.tabDialogTest.Controls.Add(this.btTestErrorMessage);
            this.tabDialogTest.Controls.Add(this.btStringQueryTest);
            this.tabDialogTest.Controls.Add(this.btTestDropDownSelect);
            this.tabDialogTest.Controls.Add(this.btTestPasswordDialog);
            this.tabDialogTest.Location = new System.Drawing.Point(4, 22);
            this.tabDialogTest.Name = "tabDialogTest";
            this.tabDialogTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabDialogTest.Size = new System.Drawing.Size(677, 309);
            this.tabDialogTest.TabIndex = 0;
            this.tabDialogTest.Text = "Dialog test";
            this.tabDialogTest.UseVisualStyleBackColor = true;
            // 
            // tabResizeDialogContainer
            // 
            this.tabResizeDialogContainer.Controls.Add(this.messageBoxContainerResize);
            this.tabResizeDialogContainer.Location = new System.Drawing.Point(4, 22);
            this.tabResizeDialogContainer.Name = "tabResizeDialogContainer";
            this.tabResizeDialogContainer.Padding = new System.Windows.Forms.Padding(3);
            this.tabResizeDialogContainer.Size = new System.Drawing.Size(677, 309);
            this.tabResizeDialogContainer.TabIndex = 2;
            this.tabResizeDialogContainer.Text = "Dialog container";
            this.tabResizeDialogContainer.UseVisualStyleBackColor = true;
            // 
            // messageBoxContainerResize
            // 
            this.messageBoxContainerResize.DialogCountChanged = null;
            this.messageBoxContainerResize.ImageSortingTypeAscending = ((System.Drawing.Image)(resources.GetObject("messageBoxContainerResize.ImageSortingTypeAscending")));
            this.messageBoxContainerResize.ImageSortingTypeDescending = ((System.Drawing.Image)(resources.GetObject("messageBoxContainerResize.ImageSortingTypeDescending")));
            this.messageBoxContainerResize.ImageSortingTypeNone = ((System.Drawing.Image)(resources.GetObject("messageBoxContainerResize.ImageSortingTypeNone")));
            this.messageBoxContainerResize.ImageToolStripLabelOrderByPriority = ((System.Drawing.Image)(resources.GetObject("messageBoxContainerResize.ImageToolStripLabelOrderByPriority")));
            this.messageBoxContainerResize.ImageToolStripLabelOrderByTime = ((System.Drawing.Image)(resources.GetObject("messageBoxContainerResize.ImageToolStripLabelOrderByTime")));
            this.messageBoxContainerResize.ImageToolStripLabelOrderByType = ((System.Drawing.Image)(resources.GetObject("messageBoxContainerResize.ImageToolStripLabelOrderByType")));
            this.messageBoxContainerResize.ImageToolStripOrderByPriority = ((System.Drawing.Image)(resources.GetObject("messageBoxContainerResize.ImageToolStripOrderByPriority")));
            this.messageBoxContainerResize.ImageToolStripOrderByTime = ((System.Drawing.Image)(resources.GetObject("messageBoxContainerResize.ImageToolStripOrderByTime")));
            this.messageBoxContainerResize.ImageToolStripOrderByType = ((System.Drawing.Image)(resources.GetObject("messageBoxContainerResize.ImageToolStripOrderByType")));
            this.messageBoxContainerResize.ImageToolStripToggleExpand = ((System.Drawing.Image)(resources.GetObject("messageBoxContainerResize.ImageToolStripToggleExpand")));
            this.messageBoxContainerResize.Location = new System.Drawing.Point(6, 6);
            this.messageBoxContainerResize.Name = "messageBoxContainerResize";
            this.messageBoxContainerResize.Resizable = true;
            this.messageBoxContainerResize.Size = new System.Drawing.Size(665, 297);
            this.messageBoxContainerResize.SortingPriority = System.Windows.Forms.SortOrder.None;
            this.messageBoxContainerResize.SortingTime = System.Windows.Forms.SortOrder.None;
            this.messageBoxContainerResize.SortingType = System.Windows.Forms.SortOrder.None;
            this.messageBoxContainerResize.TabIndex = 0;
            this.messageBoxContainerResize.TextToolStripLabelOrderByPriority = "Order by priority";
            this.messageBoxContainerResize.TextToolStripLabelOrderByTime = "Order by time";
            this.messageBoxContainerResize.TextToolStripLabelOrderByType = "Order by type";
            // 
            // tabExpandStack
            // 
            this.tabExpandStack.Controls.Add(this.messageBoxExpandStack);
            this.tabExpandStack.Location = new System.Drawing.Point(4, 22);
            this.tabExpandStack.Name = "tabExpandStack";
            this.tabExpandStack.Padding = new System.Windows.Forms.Padding(3);
            this.tabExpandStack.Size = new System.Drawing.Size(677, 309);
            this.tabExpandStack.TabIndex = 3;
            this.tabExpandStack.Text = "Expand dialogs";
            this.tabExpandStack.UseVisualStyleBackColor = true;
            // 
            // messageBoxExpandStack
            // 
            this.messageBoxExpandStack.BackColor = System.Drawing.SystemColors.Control;
            this.messageBoxExpandStack.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.messageBoxExpandStack.ImageOpenDownwards = ((System.Drawing.Image)(resources.GetObject("messageBoxExpandStack.ImageOpenDownwards")));
            this.messageBoxExpandStack.ImageOpenUpwards = ((System.Drawing.Image)(resources.GetObject("messageBoxExpandStack.ImageOpenUpwards")));
            this.messageBoxExpandStack.LabelDialogCounterBackColor = System.Drawing.SystemColors.Control;
            this.messageBoxExpandStack.LabelDialogCounterFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageBoxExpandStack.LabelDialogCounterForeColor = System.Drawing.SystemColors.ControlText;
            this.messageBoxExpandStack.Location = new System.Drawing.Point(6, 273);
            this.messageBoxExpandStack.MessageBoxContainerControlExpandSize = new System.Drawing.Size(650, 250);
            this.messageBoxExpandStack.Name = "messageBoxExpandStack";
            this.messageBoxExpandStack.OpenDownWards = false;
            this.messageBoxExpandStack.Padding = new System.Windows.Forms.Padding(2);
            this.messageBoxExpandStack.Size = new System.Drawing.Size(216, 30);
            this.messageBoxExpandStack.TabIndex = 0;
            this.messageBoxExpandStack.MessageBoxClosed += new VPKSoft.MessageBoxExtended.Controls.MessageBoxControlBase.OnDialogBoxClosed(this.messageBoxExpandStack_MessageBoxClosed);
            // 
            // lbDialogTitle
            // 
            this.lbDialogTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbDialogTitle.AutoSize = true;
            this.lbDialogTitle.Location = new System.Drawing.Point(9, 356);
            this.lbDialogTitle.Name = "lbDialogTitle";
            this.lbDialogTitle.Size = new System.Drawing.Size(59, 13);
            this.lbDialogTitle.TabIndex = 5;
            this.lbDialogTitle.Text = "Dialog title:";
            // 
            // lbDialogText
            // 
            this.lbDialogText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbDialogText.AutoSize = true;
            this.lbDialogText.Location = new System.Drawing.Point(246, 356);
            this.lbDialogText.Name = "lbDialogText";
            this.lbDialogText.Size = new System.Drawing.Size(78, 13);
            this.lbDialogText.TabIndex = 6;
            this.lbDialogText.Text = "Dialog caption:";
            // 
            // tbDialogTitle
            // 
            this.tbDialogTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbDialogTitle.Location = new System.Drawing.Point(74, 353);
            this.tbDialogTitle.Name = "tbDialogTitle";
            this.tbDialogTitle.Size = new System.Drawing.Size(156, 20);
            this.tbDialogTitle.TabIndex = 7;
            this.tbDialogTitle.Text = "The title #N1#";
            // 
            // tbDialogText
            // 
            this.tbDialogText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbDialogText.Location = new System.Drawing.Point(341, 353);
            this.tbDialogText.Name = "tbDialogText";
            this.tbDialogText.Size = new System.Drawing.Size(356, 20);
            this.tbDialogText.TabIndex = 8;
            this.tbDialogText.Text = "The dialog caption";
            // 
            // lbDialogType
            // 
            this.lbDialogType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbDialogType.AutoSize = true;
            this.lbDialogType.Location = new System.Drawing.Point(9, 382);
            this.lbDialogType.Name = "lbDialogType";
            this.lbDialogType.Size = new System.Drawing.Size(63, 13);
            this.lbDialogType.TabIndex = 9;
            this.lbDialogType.Text = "Dialog type:";
            // 
            // cmbDialogType
            // 
            this.cmbDialogType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbDialogType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDialogType.FormattingEnabled = true;
            this.cmbDialogType.Location = new System.Drawing.Point(74, 379);
            this.cmbDialogType.Name = "cmbDialogType";
            this.cmbDialogType.Size = new System.Drawing.Size(156, 21);
            this.cmbDialogType.TabIndex = 10;
            // 
            // cmbDialogButtons
            // 
            this.cmbDialogButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbDialogButtons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDialogButtons.FormattingEnabled = true;
            this.cmbDialogButtons.Location = new System.Drawing.Point(341, 379);
            this.cmbDialogButtons.Name = "cmbDialogButtons";
            this.cmbDialogButtons.Size = new System.Drawing.Size(220, 21);
            this.cmbDialogButtons.TabIndex = 12;
            // 
            // lbDialogButtons
            // 
            this.lbDialogButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbDialogButtons.AutoSize = true;
            this.lbDialogButtons.Location = new System.Drawing.Point(246, 382);
            this.lbDialogButtons.Name = "lbDialogButtons";
            this.lbDialogButtons.Size = new System.Drawing.Size(89, 13);
            this.lbDialogButtons.TabIndex = 11;
            this.lbDialogButtons.Text = "Dialog buttons(s):";
            // 
            // btAddDialog
            // 
            this.btAddDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddDialog.Location = new System.Drawing.Point(622, 403);
            this.btAddDialog.Name = "btAddDialog";
            this.btAddDialog.Size = new System.Drawing.Size(75, 23);
            this.btAddDialog.TabIndex = 13;
            this.btAddDialog.Text = "Add dialog";
            this.btAddDialog.UseVisualStyleBackColor = true;
            this.btAddDialog.Click += new System.EventHandler(this.btAddDialog_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 410);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Running numer 1, #N1#:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown1.Location = new System.Drawing.Point(166, 406);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(78, 20);
            this.numericUpDown1.TabIndex = 15;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown2.Location = new System.Drawing.Point(419, 406);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(78, 20);
            this.numericUpDown2.TabIndex = 17;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 410);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Running numer 2, #N2#:";
            // 
            // pnTabPageFirst
            // 
            this.pnTabPageFirst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnTabPageFirst.Controls.Add(this.cmbLocale);
            this.pnTabPageFirst.Controls.Add(this.lbLocalize);
            this.pnTabPageFirst.Location = new System.Drawing.Point(12, 349);
            this.pnTabPageFirst.Name = "pnTabPageFirst";
            this.pnTabPageFirst.Size = new System.Drawing.Size(685, 77);
            this.pnTabPageFirst.TabIndex = 18;
            // 
            // cmbLocale
            // 
            this.cmbLocale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocale.FormattingEnabled = true;
            this.cmbLocale.Items.AddRange(new object[] {
            "Finnish / fi-FI",
            "English (United States) / en-US"});
            this.cmbLocale.Location = new System.Drawing.Point(74, 4);
            this.cmbLocale.Name = "cmbLocale";
            this.cmbLocale.Size = new System.Drawing.Size(224, 21);
            this.cmbLocale.TabIndex = 1;
            this.cmbLocale.SelectedIndexChanged += new System.EventHandler(this.cmbLocale_SelectedIndexChanged);
            // 
            // lbLocalize
            // 
            this.lbLocalize.AutoSize = true;
            this.lbLocalize.Location = new System.Drawing.Point(7, 7);
            this.lbLocalize.Name = "lbLocalize";
            this.lbLocalize.Size = new System.Drawing.Size(61, 13);
            this.lbLocalize.TabIndex = 0;
            this.lbLocalize.Text = "Localize to:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 435);
            this.Controls.Add(this.pnTabPageFirst);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btAddDialog);
            this.Controls.Add(this.cmbDialogButtons);
            this.Controls.Add(this.lbDialogButtons);
            this.Controls.Add(this.cmbDialogType);
            this.Controls.Add(this.lbDialogType);
            this.Controls.Add(this.tbDialogText);
            this.Controls.Add(this.tbDialogTitle);
            this.Controls.Add(this.lbDialogText);
            this.Controls.Add(this.lbDialogTitle);
            this.Controls.Add(this.tcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "A test application for the VPKSoft.MessageBoxExtended library.";
            this.tcMain.ResumeLayout(false);
            this.tabDialogTest.ResumeLayout(false);
            this.tabResizeDialogContainer.ResumeLayout(false);
            this.tabExpandStack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.pnTabPageFirst.ResumeLayout(false);
            this.pnTabPageFirst.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btTestErrorMessage;
        private System.Windows.Forms.Button btTestPasswordDialog;
        private System.Windows.Forms.Button btStringQueryTest;
        private System.Windows.Forms.Button btTestDropDownSelect;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabDialogTest;
        private System.Windows.Forms.TabPage tabResizeDialogContainer;
        private VPKSoft.MessageBoxExtended.Controls.MessageBoxContainerToolset messageBoxContainerResize;
        private System.Windows.Forms.TabPage tabExpandStack;
        private VPKSoft.MessageBoxExtended.Controls.MessageBoxExpandStack messageBoxExpandStack;
        private System.Windows.Forms.Label lbDialogTitle;
        private System.Windows.Forms.Label lbDialogText;
        private System.Windows.Forms.TextBox tbDialogTitle;
        private System.Windows.Forms.TextBox tbDialogText;
        private System.Windows.Forms.Label lbDialogType;
        private System.Windows.Forms.ComboBox cmbDialogType;
        private System.Windows.Forms.ComboBox cmbDialogButtons;
        private System.Windows.Forms.Label lbDialogButtons;
        private System.Windows.Forms.Button btAddDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnTabPageFirst;
        private System.Windows.Forms.ComboBox cmbLocale;
        private System.Windows.Forms.Label lbLocalize;
    }
}

