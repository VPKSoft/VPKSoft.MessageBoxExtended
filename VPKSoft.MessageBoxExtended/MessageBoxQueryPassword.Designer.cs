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
            this.pbColorSlide = new System.Windows.Forms.PictureBox();
            this.pnColorSlide = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbMessageBoxIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColorSlide)).BeginInit();
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
            // pbColorSlide
            // 
            this.pbColorSlide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbColorSlide.Image = global::VPKSoft.MessageBoxExtended.Properties.Resources.color_slide;
            this.pbColorSlide.Location = new System.Drawing.Point(16, 64);
            this.pbColorSlide.Margin = new System.Windows.Forms.Padding(0);
            this.pbColorSlide.Name = "pbColorSlide";
            this.pbColorSlide.Size = new System.Drawing.Size(423, 4);
            this.pbColorSlide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbColorSlide.TabIndex = 10;
            this.pbColorSlide.TabStop = false;
            this.pbColorSlide.Visible = false;
            // 
            // pnColorSlide
            // 
            this.pnColorSlide.Location = new System.Drawing.Point(16, 64);
            this.pnColorSlide.Margin = new System.Windows.Forms.Padding(0);
            this.pnColorSlide.Name = "pnColorSlide";
            this.pnColorSlide.Size = new System.Drawing.Size(423, 4);
            this.pnColorSlide.TabIndex = 11;
            // 
            // MessageBoxQueryPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(451, 119);
            this.Controls.Add(this.pnColorSlide);
            this.Controls.Add(this.pbColorSlide);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lbInvalidPasswordComplaint);
            this.Name = "MessageBoxQueryPassword";
            this.Text = "MessageBoxQueryPassword";
            this.Shown += new System.EventHandler(this.MessageBoxQueryPassword_Shown);
            this.Controls.SetChildIndex(this.pbMessageBoxIcon, 0);
            this.Controls.SetChildIndex(this.lbText, 0);
            this.Controls.SetChildIndex(this.lbInvalidPasswordComplaint, 0);
            this.Controls.SetChildIndex(this.tbPassword, 0);
            this.Controls.SetChildIndex(this.pbColorSlide, 0);
            this.Controls.SetChildIndex(this.pnColorSlide, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbMessageBoxIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColorSlide)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbInvalidPasswordComplaint;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.PictureBox pbColorSlide;
        private System.Windows.Forms.Panel pnColorSlide;
    }
}
