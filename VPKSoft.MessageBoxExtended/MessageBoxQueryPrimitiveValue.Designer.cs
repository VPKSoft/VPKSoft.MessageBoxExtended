namespace VPKSoft.MessageBoxExtended
{
    partial class MessageBoxQueryPrimitiveValue
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
            this.tbStringValue = new System.Windows.Forms.TextBox();
            this.dtpDateTimeValue = new System.Windows.Forms.DateTimePicker();
            this.lbInvalidValidationText = new System.Windows.Forms.Label();
            this.nudNumericValue = new System.Windows.Forms.NumericUpDown();
            this.cmbDropDownValue = new System.Windows.Forms.ComboBox();
            this.cbBooleanValue = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMessageBoxIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumericValue)).BeginInit();
            this.SuspendLayout();
            // 
            // tbStringValue
            // 
            this.tbStringValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStringValue.Location = new System.Drawing.Point(16, 46);
            this.tbStringValue.Name = "tbStringValue";
            this.tbStringValue.Size = new System.Drawing.Size(423, 20);
            this.tbStringValue.TabIndex = 10;
            this.tbStringValue.Visible = false;
            this.tbStringValue.TextChanged += new System.EventHandler(this.genericValue_Changed);
            // 
            // dtpDateTimeValue
            // 
            this.dtpDateTimeValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDateTimeValue.Location = new System.Drawing.Point(16, 46);
            this.dtpDateTimeValue.Name = "dtpDateTimeValue";
            this.dtpDateTimeValue.Size = new System.Drawing.Size(423, 20);
            this.dtpDateTimeValue.TabIndex = 11;
            this.dtpDateTimeValue.Visible = false;
            this.dtpDateTimeValue.ValueChanged += new System.EventHandler(this.genericValue_Changed);
            // 
            // lbInvalidValidationText
            // 
            this.lbInvalidValidationText.AutoSize = true;
            this.lbInvalidValidationText.ForeColor = System.Drawing.Color.Red;
            this.lbInvalidValidationText.Location = new System.Drawing.Point(13, 66);
            this.lbInvalidValidationText.Name = "lbInvalidValidationText";
            this.lbInvalidValidationText.Size = new System.Drawing.Size(198, 13);
            this.lbInvalidValidationText.TabIndex = 12;
            this.lbInvalidValidationText.Text = "An invalid validation error text goes here.";
            // 
            // nudNumericValue
            // 
            this.nudNumericValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudNumericValue.Location = new System.Drawing.Point(16, 46);
            this.nudNumericValue.Name = "nudNumericValue";
            this.nudNumericValue.Size = new System.Drawing.Size(423, 20);
            this.nudNumericValue.TabIndex = 13;
            this.nudNumericValue.Visible = false;
            this.nudNumericValue.ValueChanged += new System.EventHandler(this.genericValue_Changed);
            // 
            // cmbDropDownValue
            // 
            this.cmbDropDownValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDropDownValue.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDropDownValue.FormattingEnabled = true;
            this.cmbDropDownValue.Location = new System.Drawing.Point(16, 45);
            this.cmbDropDownValue.Name = "cmbDropDownValue";
            this.cmbDropDownValue.Size = new System.Drawing.Size(423, 21);
            this.cmbDropDownValue.TabIndex = 14;
            this.cmbDropDownValue.Visible = false;
            this.cmbDropDownValue.SelectedValueChanged += new System.EventHandler(this.genericValue_Changed);
            // 
            // cbBooleanValue
            // 
            this.cbBooleanValue.AutoSize = true;
            this.cbBooleanValue.Location = new System.Drawing.Point(16, 47);
            this.cbBooleanValue.Name = "cbBooleanValue";
            this.cbBooleanValue.Size = new System.Drawing.Size(15, 14);
            this.cbBooleanValue.TabIndex = 15;
            this.cbBooleanValue.UseVisualStyleBackColor = true;
            this.cbBooleanValue.Visible = false;
            this.cbBooleanValue.CheckedChanged += new System.EventHandler(this.genericValue_Changed);
            // 
            // MessageBoxQueryPrimitiveValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(451, 119);
            this.Controls.Add(this.cbBooleanValue);
            this.Controls.Add(this.cmbDropDownValue);
            this.Controls.Add(this.nudNumericValue);
            this.Controls.Add(this.lbInvalidValidationText);
            this.Controls.Add(this.dtpDateTimeValue);
            this.Controls.Add(this.tbStringValue);
            this.Name = "MessageBoxQueryPrimitiveValue";
            this.Shown += new System.EventHandler(this.MessageBoxQueryPrimitiveValue_Shown);
            this.Controls.SetChildIndex(this.tbStringValue, 0);
            this.Controls.SetChildIndex(this.pbMessageBoxIcon, 0);
            this.Controls.SetChildIndex(this.lbText, 0);
            this.Controls.SetChildIndex(this.dtpDateTimeValue, 0);
            this.Controls.SetChildIndex(this.lbInvalidValidationText, 0);
            this.Controls.SetChildIndex(this.nudNumericValue, 0);
            this.Controls.SetChildIndex(this.cmbDropDownValue, 0);
            this.Controls.SetChildIndex(this.cbBooleanValue, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbMessageBoxIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumericValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbStringValue;
        private System.Windows.Forms.DateTimePicker dtpDateTimeValue;
        private System.Windows.Forms.Label lbInvalidValidationText;
        private System.Windows.Forms.NumericUpDown nudNumericValue;
        private System.Windows.Forms.ComboBox cmbDropDownValue;
        private System.Windows.Forms.CheckBox cbBooleanValue;
    }
}
