namespace NeptuneCSample_CSharp
{
    partial class PopupTriggerForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.m_ckTriggerEnable = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cbTriggerMode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cbTriggerSource = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_cbTriggerPolarity = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_edTriggerParam = new System.Windows.Forms.NumericUpDown();
            this.m_btnSWTrigger = new System.Windows.Forms.Button();
            this.m_btnApply = new System.Windows.Forms.Button();
            this.m_stcParamRange = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_edTriggerParam)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trigger Enable";
            // 
            // m_ckTriggerEnable
            // 
            this.m_ckTriggerEnable.AutoSize = true;
            this.m_ckTriggerEnable.Location = new System.Drawing.Point(145, 19);
            this.m_ckTriggerEnable.Name = "m_ckTriggerEnable";
            this.m_ckTriggerEnable.Size = new System.Drawing.Size(40, 16);
            this.m_ckTriggerEnable.TabIndex = 1;
            this.m_ckTriggerEnable.Text = "On";
            this.m_ckTriggerEnable.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Trigger Mode";
            // 
            // m_cbTriggerMode
            // 
            this.m_cbTriggerMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbTriggerMode.FormattingEnabled = true;
            this.m_cbTriggerMode.Location = new System.Drawing.Point(145, 47);
            this.m_cbTriggerMode.Name = "m_cbTriggerMode";
            this.m_cbTriggerMode.Size = new System.Drawing.Size(121, 20);
            this.m_cbTriggerMode.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Trigger Source";
            // 
            // m_cbTriggerSource
            // 
            this.m_cbTriggerSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbTriggerSource.FormattingEnabled = true;
            this.m_cbTriggerSource.Location = new System.Drawing.Point(145, 79);
            this.m_cbTriggerSource.Name = "m_cbTriggerSource";
            this.m_cbTriggerSource.Size = new System.Drawing.Size(121, 20);
            this.m_cbTriggerSource.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Trigger Polarity";
            // 
            // m_cbTriggerPolarity
            // 
            this.m_cbTriggerPolarity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbTriggerPolarity.FormattingEnabled = true;
            this.m_cbTriggerPolarity.Location = new System.Drawing.Point(145, 111);
            this.m_cbTriggerPolarity.Name = "m_cbTriggerPolarity";
            this.m_cbTriggerPolarity.Size = new System.Drawing.Size(121, 20);
            this.m_cbTriggerPolarity.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "Trigger Parameter";
            // 
            // m_edTriggerParam
            // 
            this.m_edTriggerParam.Location = new System.Drawing.Point(146, 144);
            this.m_edTriggerParam.Name = "m_edTriggerParam";
            this.m_edTriggerParam.Size = new System.Drawing.Size(120, 21);
            this.m_edTriggerParam.TabIndex = 10;
            // 
            // m_btnSWTrigger
            // 
            this.m_btnSWTrigger.Location = new System.Drawing.Point(285, 78);
            this.m_btnSWTrigger.Name = "m_btnSWTrigger";
            this.m_btnSWTrigger.Size = new System.Drawing.Size(118, 23);
            this.m_btnSWTrigger.TabIndex = 6;
            this.m_btnSWTrigger.Text = "Run S/W Trigger";
            this.m_btnSWTrigger.UseVisualStyleBackColor = true;
            this.m_btnSWTrigger.Click += new System.EventHandler(this.m_btnSWTrigger_Click);
            // 
            // m_btnApply
            // 
            this.m_btnApply.Location = new System.Drawing.Point(172, 184);
            this.m_btnApply.Name = "m_btnApply";
            this.m_btnApply.Size = new System.Drawing.Size(75, 23);
            this.m_btnApply.TabIndex = 18;
            this.m_btnApply.Text = "Apply";
            this.m_btnApply.UseVisualStyleBackColor = true;
            this.m_btnApply.Click += new System.EventHandler(this.m_btnApply_Click);
            // 
            // m_stcParamRange
            // 
            this.m_stcParamRange.AutoSize = true;
            this.m_stcParamRange.Location = new System.Drawing.Point(283, 148);
            this.m_stcParamRange.Name = "m_stcParamRange";
            this.m_stcParamRange.Size = new System.Drawing.Size(78, 12);
            this.m_stcParamRange.TabIndex = 11;
            this.m_stcParamRange.Text = "(Min ~ Max)";
            // 
            // PopupTriggerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 220);
            this.Controls.Add(this.m_stcParamRange);
            this.Controls.Add(this.m_btnApply);
            this.Controls.Add(this.m_btnSWTrigger);
            this.Controls.Add(this.m_edTriggerParam);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_cbTriggerPolarity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_cbTriggerSource);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_cbTriggerMode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_ckTriggerEnable);
            this.Controls.Add(this.label1);
            this.Name = "PopupTriggerForm";
            this.Text = "Trigger";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PopupTriggerForm_FormClosed);
            this.Load += new System.EventHandler(this.PopupTriggerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_edTriggerParam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox m_ckTriggerEnable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox m_cbTriggerMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox m_cbTriggerSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox m_cbTriggerPolarity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown m_edTriggerParam;
        private System.Windows.Forms.Button m_btnSWTrigger;
        private System.Windows.Forms.Button m_btnApply;
        private System.Windows.Forms.Label m_stcParamRange;
    }
}