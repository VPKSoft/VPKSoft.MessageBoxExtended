namespace VPKSoft.MessageBoxExtended.Controls
{
    partial class MessageBoxControlStack
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnStackDialog = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnStackDialog
            // 
            this.pnStackDialog.AutoScroll = true;
            this.pnStackDialog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnStackDialog.Location = new System.Drawing.Point(0, 0);
            this.pnStackDialog.Name = "pnStackDialog";
            this.pnStackDialog.Size = new System.Drawing.Size(561, 177);
            this.pnStackDialog.TabIndex = 0;
            this.pnStackDialog.Resize += new System.EventHandler(this.pnStackDialog_Resize);
            // 
            // MessageBoxControlStack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnStackDialog);
            this.Name = "MessageBoxControlStack";
            this.Size = new System.Drawing.Size(561, 177);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnStackDialog;
    }
}
