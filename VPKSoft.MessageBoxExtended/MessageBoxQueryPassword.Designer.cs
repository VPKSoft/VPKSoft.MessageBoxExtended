namespace VPKSoft.MessageBoxExtended
{
    partial class MessageBoxQueryPassword
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
            this.lbInvalidPasswordComplaint = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMessageBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMessageBoxIcon
            // 
            this.pbMessageBoxIcon.Image = global::VPKSoft.MessageBoxExtended.Properties.Resources.password;
            // 
            // lbInvalidPasswordComplaint
            // 
            this.lbInvalidPasswordComplaint.AutoSize = true;
            this.lbInvalidPasswordComplaint.ForeColor = System.Drawing.Color.Red;
            this.lbInvalidPasswordComplaint.Location = new System.Drawing.Point(13, 69);
            this.lbInvalidPasswordComplaint.Name = "lbInvalidPasswordComplaint";
            this.lbInvalidPasswordComplaint.Size = new System.Drawing.Size(253, 13);
            this.lbInvalidPasswordComplaint.TabIndex = 8;
            this.lbInvalidPasswordComplaint.Text = "The given password was incorrect. Please try again.";
            this.lbInvalidPasswordComplaint.Visible = false;
            // 
            // tbPassword
            // 
            this.tbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPassword.Location = new System.Drawing.Point(16, 46);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(423, 20);
            this.tbPassword.TabIndex = 9;
            this.tbPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPassword.UseSystemPasswordChar = true;
            this.tbPassword.TextChanged += new System.EventHandler(this.tbPassword_TextChanged);
            // 
            // MessageBoxQueryPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(451, 119);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lbInvalidPasswordComplaint);
            this.Name = "MessageBoxQueryPassword";
            this.Text = "MessageBoxQueryPassword";
            this.Shown += new System.EventHandler(this.MessageBoxQueryPassword_Shown);
            this.Controls.SetChildIndex(this.pbMessageBoxIcon, 0);
            this.Controls.SetChildIndex(this.lbText, 0);
            this.Controls.SetChildIndex(this.lbInvalidPasswordComplaint, 0);
            this.Controls.SetChildIndex(this.tbPassword, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbMessageBoxIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbInvalidPasswordComplaint;
        private System.Windows.Forms.TextBox tbPassword;
    }
}
