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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabDialogTest = new System.Windows.Forms.TabPage();
            this.tabControlTest = new System.Windows.Forms.TabPage();
            this.btAddQueryDialog = new System.Windows.Forms.Button();
            this.messageBoxStackTest = new VPKSoft.MessageBoxExtended.Controls.MessageBoxControlStack();
            this.tcMain.SuspendLayout();
            this.tabDialogTest.SuspendLayout();
            this.tabControlTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 64);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 93);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMain.Controls.Add(this.tabDialogTest);
            this.tcMain.Controls.Add(this.tabControlTest);
            this.tcMain.Location = new System.Drawing.Point(12, 12);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(685, 396);
            this.tcMain.TabIndex = 4;
            // 
            // tabDialogTest
            // 
            this.tabDialogTest.Controls.Add(this.button1);
            this.tabDialogTest.Controls.Add(this.button3);
            this.tabDialogTest.Controls.Add(this.button4);
            this.tabDialogTest.Controls.Add(this.button2);
            this.tabDialogTest.Location = new System.Drawing.Point(4, 22);
            this.tabDialogTest.Name = "tabDialogTest";
            this.tabDialogTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabDialogTest.Size = new System.Drawing.Size(677, 370);
            this.tabDialogTest.TabIndex = 0;
            this.tabDialogTest.Text = "Dialog test";
            this.tabDialogTest.UseVisualStyleBackColor = true;
            // 
            // tabControlTest
            // 
            this.tabControlTest.Controls.Add(this.btAddQueryDialog);
            this.tabControlTest.Controls.Add(this.messageBoxStackTest);
            this.tabControlTest.Location = new System.Drawing.Point(4, 22);
            this.tabControlTest.Name = "tabControlTest";
            this.tabControlTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabControlTest.Size = new System.Drawing.Size(677, 370);
            this.tabControlTest.TabIndex = 1;
            this.tabControlTest.Text = "Control test";
            this.tabControlTest.UseVisualStyleBackColor = true;
            // 
            // btAddQueryDialog
            // 
            this.btAddQueryDialog.Location = new System.Drawing.Point(6, 341);
            this.btAddQueryDialog.Name = "btAddQueryDialog";
            this.btAddQueryDialog.Size = new System.Drawing.Size(162, 23);
            this.btAddQueryDialog.TabIndex = 1;
            this.btAddQueryDialog.Text = "Add query dialog";
            this.btAddQueryDialog.UseVisualStyleBackColor = true;
            this.btAddQueryDialog.Click += new System.EventHandler(this.btAddQueryDialog_Click);
            // 
            // messageBoxStackTest
            // 
            this.messageBoxStackTest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageBoxStackTest.CloseButtonHoverImage = ((System.Drawing.Image)(resources.GetObject("messageBoxStackTest.CloseButtonHoverImage")));
            this.messageBoxStackTest.CloseButtonImage = ((System.Drawing.Image)(resources.GetObject("messageBoxStackTest.CloseButtonImage")));
            this.messageBoxStackTest.DialogCloseButtonBackground = System.Drawing.SystemColors.Window;
            this.messageBoxStackTest.DialogCloseButtonHoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.messageBoxStackTest.Location = new System.Drawing.Point(6, 6);
            this.messageBoxStackTest.Name = "messageBoxStackTest";
            this.messageBoxStackTest.Size = new System.Drawing.Size(665, 272);
            this.messageBoxStackTest.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 420);
            this.Controls.Add(this.tcMain);
            this.Name = "FormMain";
            this.Text = "A test application for the VPKSoft.MessageBoxExtended library.";
            this.tcMain.ResumeLayout(false);
            this.tabDialogTest.ResumeLayout(false);
            this.tabControlTest.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabDialogTest;
        private System.Windows.Forms.TabPage tabControlTest;
        private System.Windows.Forms.Button btAddQueryDialog;
        private VPKSoft.MessageBoxExtended.Controls.MessageBoxControlStack messageBoxStackTest;
    }
}

