namespace VPKSoft.MessageBoxExtended.Controls
{
    partial class MessageBoxExpandStack
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.lbText = new System.Windows.Forms.Label();
            this.pnToggleImage = new System.Windows.Forms.Panel();
            this.lbDialogCounter = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.SystemColors.Control;
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpMain.Controls.Add(this.lbDialogCounter, 0, 0);
            this.tlpMain.Controls.Add(this.lbText, 1, 0);
            this.tlpMain.Controls.Add(this.pnToggleImage, 2, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(2, 2);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(301, 26);
            this.tlpMain.TabIndex = 1;
            // 
            // lbText
            // 
            this.lbText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbText.Location = new System.Drawing.Point(45, 0);
            this.lbText.Margin = new System.Windows.Forms.Padding(0);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(210, 26);
            this.lbText.TabIndex = 0;
            this.lbText.Text = "label1";
            this.lbText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbText.Click += new System.EventHandler(this.pnToggleImage_Click);
            // 
            // pnToggleImage
            // 
            this.pnToggleImage.BackgroundImage = global::VPKSoft.MessageBoxExtended.Properties.Resources.arrow_up;
            this.pnToggleImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnToggleImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnToggleImage.Location = new System.Drawing.Point(255, 0);
            this.pnToggleImage.Margin = new System.Windows.Forms.Padding(0);
            this.pnToggleImage.Name = "pnToggleImage";
            this.pnToggleImage.Size = new System.Drawing.Size(46, 26);
            this.pnToggleImage.TabIndex = 1;
            this.pnToggleImage.Click += new System.EventHandler(this.pnToggleImage_Click);
            // 
            // lbDialogCounter
            // 
            this.lbDialogCounter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDialogCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDialogCounter.Location = new System.Drawing.Point(0, 0);
            this.lbDialogCounter.Margin = new System.Windows.Forms.Padding(0);
            this.lbDialogCounter.Name = "lbDialogCounter";
            this.lbDialogCounter.Size = new System.Drawing.Size(45, 26);
            this.lbDialogCounter.TabIndex = 2;
            this.lbDialogCounter.Text = "0";
            this.lbDialogCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MessageBoxExpandStack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.tlpMain);
            this.Name = "MessageBoxExpandStack";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(305, 30);
            this.tlpMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lbText;
        private System.Windows.Forms.Panel pnToggleImage;
        private System.Windows.Forms.Label lbDialogCounter;
    }
}
