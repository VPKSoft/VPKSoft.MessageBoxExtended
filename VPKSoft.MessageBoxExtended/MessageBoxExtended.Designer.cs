namespace VPKSoft.MessageBoxExtended
{
    partial class MessageBoxExtended
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
            this.cbRememberAnswer = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMessageBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // cbRememberAnswer
            // 
            this.cbRememberAnswer.AutoSize = true;
            this.cbRememberAnswer.Location = new System.Drawing.Point(16, 54);
            this.cbRememberAnswer.Name = "cbRememberAnswer";
            this.cbRememberAnswer.Size = new System.Drawing.Size(114, 17);
            this.cbRememberAnswer.TabIndex = 8;
            this.cbRememberAnswer.Text = "Remember answer";
            this.cbRememberAnswer.UseVisualStyleBackColor = true;
            // 
            // MessageBoxExtended
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(451, 137);
            this.Controls.Add(this.cbRememberAnswer);
            this.Name = "MessageBoxExtended";
            this.Shown += new System.EventHandler(this.MessageBoxExtended_Shown);
            this.Controls.SetChildIndex(this.pbMessageBoxIcon, 0);
            this.Controls.SetChildIndex(this.lbText, 0);
            this.Controls.SetChildIndex(this.cbRememberAnswer, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbMessageBoxIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbRememberAnswer;
    }
}
