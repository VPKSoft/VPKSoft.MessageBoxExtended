namespace VPKSoft.MessageBoxExtended.Controls
{
    partial class MessageBoxContainerToolset
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageBoxContainerToolset));
            this.pnMain = new System.Windows.Forms.Panel();
            this.messageBoxControlStackMain = new VPKSoft.MessageBoxExtended.Controls.MessageBoxControlStack();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbExpandCollapseDialogs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tslOrderByTime = new System.Windows.Forms.ToolStripLabel();
            this.tsbOrderByTime = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tslOrderByPriority = new System.Windows.Forms.ToolStripLabel();
            this.tsbOrderByPriority = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tslOrderByType = new System.Windows.Forms.ToolStripLabel();
            this.tsbOrderByType = new System.Windows.Forms.ToolStripButton();
            this.pnMain.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnMain
            // 
            this.pnMain.Controls.Add(this.messageBoxControlStackMain);
            this.pnMain.Controls.Add(this.tsMain);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(0, 0);
            this.pnMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(435, 185);
            this.pnMain.TabIndex = 1;
            // 
            // messageBoxControlStackMain
            // 
            this.messageBoxControlStackMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageBoxControlStackMain.CloseButtonHoverImage = ((System.Drawing.Image)(resources.GetObject("messageBoxControlStackMain.CloseButtonHoverImage")));
            this.messageBoxControlStackMain.CloseButtonImage = ((System.Drawing.Image)(resources.GetObject("messageBoxControlStackMain.CloseButtonImage")));
            this.messageBoxControlStackMain.DefaultCloseResult = VPKSoft.MessageBoxExtended.DialogResultExtended.None;
            this.messageBoxControlStackMain.DialogCloseButtonBackground = System.Drawing.SystemColors.Control;
            this.messageBoxControlStackMain.DialogCloseButtonHoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.messageBoxControlStackMain.DialogCountChanged = null;
            this.messageBoxControlStackMain.DialogExpandButtonBackground = System.Drawing.SystemColors.Control;
            this.messageBoxControlStackMain.DialogExpandButtonHoverBackground = System.Drawing.SystemColors.ControlDark;
            this.messageBoxControlStackMain.DialogTextForeColor = System.Drawing.SystemColors.ControlText;
            this.messageBoxControlStackMain.DialogTimeButtonBackground = System.Drawing.SystemColors.Control;
            this.messageBoxControlStackMain.DialogTimeButtonHoverBackground = System.Drawing.SystemColors.Control;
            this.messageBoxControlStackMain.DialogTitleExpandedForeColor = System.Drawing.SystemColors.ControlText;
            this.messageBoxControlStackMain.DialogTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.messageBoxControlStackMain.ExpandButtonHoverImage = ((System.Drawing.Image)(resources.GetObject("messageBoxControlStackMain.ExpandButtonHoverImage")));
            this.messageBoxControlStackMain.ExpandButtonImage = ((System.Drawing.Image)(resources.GetObject("messageBoxControlStackMain.ExpandButtonImage")));
            this.messageBoxControlStackMain.ExpandButtonImageHoverMinimize = ((System.Drawing.Image)(resources.GetObject("messageBoxControlStackMain.ExpandButtonImageHoverMinimize")));
            this.messageBoxControlStackMain.ExpandButtonImageMinimize = ((System.Drawing.Image)(resources.GetObject("messageBoxControlStackMain.ExpandButtonImageMinimize")));
            this.messageBoxControlStackMain.FontDialogText = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageBoxControlStackMain.FontDialogTitle = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.messageBoxControlStackMain.FontDialogTitleExpanded = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageBoxControlStackMain.Location = new System.Drawing.Point(3, 28);
            this.messageBoxControlStackMain.Name = "messageBoxControlStackMain";
            this.messageBoxControlStackMain.Size = new System.Drawing.Size(429, 157);
            this.messageBoxControlStackMain.TabIndex = 1;
            this.messageBoxControlStackMain.TimeFormat = "G";
            this.messageBoxControlStackMain.TimeInfoButtonHoverImage = ((System.Drawing.Image)(resources.GetObject("messageBoxControlStackMain.TimeInfoButtonHoverImage")));
            this.messageBoxControlStackMain.TimeInfoButtonImage = ((System.Drawing.Image)(resources.GetObject("messageBoxControlStackMain.TimeInfoButtonImage")));
            this.messageBoxControlStackMain.TitleHeight = 30;
            this.messageBoxControlStackMain.TitleIconAreaWidth = 30;
            this.messageBoxControlStackMain.TitleIconSize = new System.Drawing.Size(24, 24);
            // 
            // tsMain
            // 
            this.tsMain.CanOverflow = false;
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExpandCollapseDialogs,
            this.toolStripSeparator1,
            this.tslOrderByTime,
            this.tsbOrderByTime,
            this.toolStripSeparator2,
            this.tslOrderByPriority,
            this.tsbOrderByPriority,
            this.toolStripSeparator3,
            this.tslOrderByType,
            this.tsbOrderByType});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(435, 25);
            this.tsMain.TabIndex = 4;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbExpandCollapseDialogs
            // 
            this.tsbExpandCollapseDialogs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExpandCollapseDialogs.Image = global::VPKSoft.MessageBoxExtended.Properties.Resources.collapse_expand;
            this.tsbExpandCollapseDialogs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExpandCollapseDialogs.Name = "tsbExpandCollapseDialogs";
            this.tsbExpandCollapseDialogs.Size = new System.Drawing.Size(23, 22);
            this.tsbExpandCollapseDialogs.Text = "Collapse/Expand";
            this.tsbExpandCollapseDialogs.Click += new System.EventHandler(this.tsbExpandCollapseDialogs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tslOrderByTime
            // 
            this.tslOrderByTime.Image = global::VPKSoft.MessageBoxExtended.Properties.Resources.clock_icon;
            this.tslOrderByTime.Name = "tslOrderByTime";
            this.tslOrderByTime.Size = new System.Drawing.Size(96, 22);
            this.tslOrderByTime.Text = "Order by time";
            // 
            // tsbOrderByTime
            // 
            this.tsbOrderByTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOrderByTime.Image = global::VPKSoft.MessageBoxExtended.Properties.Resources.up_down_gray;
            this.tsbOrderByTime.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOrderByTime.Name = "tsbOrderByTime";
            this.tsbOrderByTime.Size = new System.Drawing.Size(23, 22);
            this.tsbOrderByTime.Tag = "False";
            this.tsbOrderByTime.Text = "Order by time";
            this.tsbOrderByTime.Click += new System.EventHandler(this.tsbOrderByTime_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tslOrderByPriority
            // 
            this.tslOrderByPriority.Image = global::VPKSoft.MessageBoxExtended.Properties.Resources.priority_order;
            this.tslOrderByPriority.Name = "tslOrderByPriority";
            this.tslOrderByPriority.Size = new System.Drawing.Size(110, 22);
            this.tslOrderByPriority.Text = "Order by priority";
            // 
            // tsbOrderByPriority
            // 
            this.tsbOrderByPriority.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOrderByPriority.Image = ((System.Drawing.Image)(resources.GetObject("tsbOrderByPriority.Image")));
            this.tsbOrderByPriority.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOrderByPriority.Name = "tsbOrderByPriority";
            this.tsbOrderByPriority.Size = new System.Drawing.Size(23, 22);
            this.tsbOrderByPriority.Text = "Order by priority";
            this.tsbOrderByPriority.Click += new System.EventHandler(this.tsbOrderByTime_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tslOrderByType
            // 
            this.tslOrderByType.Image = global::VPKSoft.MessageBoxExtended.Properties.Resources.sort_dialog_type;
            this.tslOrderByType.Name = "tslOrderByType";
            this.tslOrderByType.Size = new System.Drawing.Size(95, 22);
            this.tslOrderByType.Text = "Order by type";
            // 
            // tsbOrderByType
            // 
            this.tsbOrderByType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOrderByType.Image = global::VPKSoft.MessageBoxExtended.Properties.Resources.up_down_gray;
            this.tsbOrderByType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOrderByType.Name = "tsbOrderByType";
            this.tsbOrderByType.Size = new System.Drawing.Size(23, 22);
            this.tsbOrderByType.Text = "Order by type";
            this.tsbOrderByType.Click += new System.EventHandler(this.tsbOrderByTime_Click);
            // 
            // MessageBoxContainerToolset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnMain);
            this.Name = "MessageBoxContainerToolset";
            this.Size = new System.Drawing.Size(435, 185);
            this.pnMain.ResumeLayout(false);
            this.pnMain.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbExpandCollapseDialogs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel tslOrderByTime;
        private System.Windows.Forms.ToolStripButton tsbOrderByTime;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel tslOrderByPriority;
        private System.Windows.Forms.ToolStripButton tsbOrderByPriority;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel tslOrderByType;
        private System.Windows.Forms.ToolStripButton tsbOrderByType;
        private MessageBoxControlStack messageBoxControlStackMain;
    }
}
