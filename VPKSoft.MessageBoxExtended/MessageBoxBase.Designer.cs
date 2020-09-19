namespace VPKSoft.MessageBoxExtended
{
    partial class MessageBoxBase
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
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.lbText = new System.Windows.Forms.Label();
            this.pbMessageBoxIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMessageBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // flpButtons
            // 
            this.flpButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpButtons.BackColor = System.Drawing.SystemColors.Control;
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpButtons.Location = new System.Drawing.Point(0, 91);
            this.flpButtons.Margin = new System.Windows.Forms.Padding(0);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Padding = new System.Windows.Forms.Padding(10);
            this.flpButtons.Size = new System.Drawing.Size(451, 46);
            this.flpButtons.TabIndex = 7;
            // 
            // lbText
            // 
            this.lbText.Location = new System.Drawing.Point(64, 8);
            this.lbText.Margin = new System.Windows.Forms.Padding(3);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(375, 32);
            this.lbText.TabIndex = 6;
            this.lbText.Text = "The text is to be displayed here.";
            // 
            // pbMessageBoxIcon
            // 
            this.pbMessageBoxIcon.Location = new System.Drawing.Point(16, 8);
            this.pbMessageBoxIcon.Name = "pbMessageBoxIcon";
            this.pbMessageBoxIcon.Size = new System.Drawing.Size(32, 32);
            this.pbMessageBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbMessageBoxIcon.TabIndex = 5;
            this.pbMessageBoxIcon.TabStop = false;
            // 
            // MessageBoxBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(451, 137);
            this.Controls.Add(this.flpButtons);
            this.Controls.Add(this.lbText);
            this.Controls.Add(this.pbMessageBoxIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageBoxBase";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MessageBoxBase";
            ((System.ComponentModel.ISupportInitialize)(this.pbMessageBoxIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region ProtectedFields
        protected System.Windows.Forms.FlowLayoutPanel flpButtons;
        protected System.Windows.Forms.Label lbText;
        protected System.Windows.Forms.PictureBox pbMessageBoxIcon;
        #endregion
    }
}