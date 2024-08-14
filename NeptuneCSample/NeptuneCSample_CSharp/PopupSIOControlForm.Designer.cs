namespace NeptuneCSample_CSharp
{
    partial class PopupSIOControlForm
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
            this.m_cbBaudRate = new System.Windows.Forms.ComboBox();
            this.m_cbParityBits = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cbDataBits = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cbStopBits = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_ckEnable = new System.Windows.Forms.CheckBox();
            this.m_btnApply = new System.Windows.Forms.Button();
            this.m_edData = new System.Windows.Forms.TextBox();
            this.m_btnSend = new System.Windows.Forms.Button();
            this.m_btnReceive = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Baud Rate";
            // 
            // m_cbBaudRate
            // 
            this.m_cbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbBaudRate.FormattingEnabled = true;
            this.m_cbBaudRate.Location = new System.Drawing.Point(149, 46);
            this.m_cbBaudRate.Name = "m_cbBaudRate";
            this.m_cbBaudRate.Size = new System.Drawing.Size(121, 20);
            this.m_cbBaudRate.TabIndex = 3;
            // 
            // m_cbParityBits
            // 
            this.m_cbParityBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbParityBits.FormattingEnabled = true;
            this.m_cbParityBits.Location = new System.Drawing.Point(149, 78);
            this.m_cbParityBits.Name = "m_cbParityBits";
            this.m_cbParityBits.Size = new System.Drawing.Size(121, 20);
            this.m_cbParityBits.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Parity Bits";
            // 
            // m_cbDataBits
            // 
            this.m_cbDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbDataBits.FormattingEnabled = true;
            this.m_cbDataBits.Location = new System.Drawing.Point(149, 110);
            this.m_cbDataBits.Name = "m_cbDataBits";
            this.m_cbDataBits.Size = new System.Drawing.Size(121, 20);
            this.m_cbDataBits.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Data Bits";
            // 
            // m_cbStopBits
            // 
            this.m_cbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbStopBits.FormattingEnabled = true;
            this.m_cbStopBits.Location = new System.Drawing.Point(149, 142);
            this.m_cbStopBits.Name = "m_cbStopBits";
            this.m_cbStopBits.Size = new System.Drawing.Size(121, 20);
            this.m_cbStopBits.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "Stop Bits";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "Enable";
            // 
            // m_ckEnable
            // 
            this.m_ckEnable.AutoSize = true;
            this.m_ckEnable.Location = new System.Drawing.Point(149, 17);
            this.m_ckEnable.Name = "m_ckEnable";
            this.m_ckEnable.Size = new System.Drawing.Size(40, 16);
            this.m_ckEnable.TabIndex = 1;
            this.m_ckEnable.Text = "On";
            this.m_ckEnable.UseVisualStyleBackColor = true;
            // 
            // m_btnApply
            // 
            this.m_btnApply.Location = new System.Drawing.Point(195, 177);
            this.m_btnApply.Name = "m_btnApply";
            this.m_btnApply.Size = new System.Drawing.Size(75, 23);
            this.m_btnApply.TabIndex = 10;
            this.m_btnApply.Text = "Apply";
            this.m_btnApply.UseVisualStyleBackColor = true;
            this.m_btnApply.Click += new System.EventHandler(this.m_btnApply_Click);
            // 
            // m_edData
            // 
            this.m_edData.Location = new System.Drawing.Point(71, 223);
            this.m_edData.Multiline = true;
            this.m_edData.Name = "m_edData";
            this.m_edData.Size = new System.Drawing.Size(199, 76);
            this.m_edData.TabIndex = 12;
            // 
            // m_btnSend
            // 
            this.m_btnSend.Location = new System.Drawing.Point(14, 305);
            this.m_btnSend.Name = "m_btnSend";
            this.m_btnSend.Size = new System.Drawing.Size(125, 23);
            this.m_btnSend.TabIndex = 13;
            this.m_btnSend.Text = "Send Data (TX)";
            this.m_btnSend.UseVisualStyleBackColor = true;
            this.m_btnSend.Click += new System.EventHandler(this.m_btnSend_Click);
            // 
            // m_btnReceive
            // 
            this.m_btnReceive.Location = new System.Drawing.Point(145, 305);
            this.m_btnReceive.Name = "m_btnReceive";
            this.m_btnReceive.Size = new System.Drawing.Size(125, 23);
            this.m_btnReceive.TabIndex = 14;
            this.m_btnReceive.Text = "Receive Data (RX)";
            this.m_btnReceive.UseVisualStyleBackColor = true;
            this.m_btnReceive.Click += new System.EventHandler(this.m_btnReceive_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "Data";
            // 
            // PopupSIOControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 340);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_btnReceive);
            this.Controls.Add(this.m_btnSend);
            this.Controls.Add(this.m_edData);
            this.Controls.Add(this.m_btnApply);
            this.Controls.Add(this.m_ckEnable);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_cbStopBits);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_cbDataBits);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_cbParityBits);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_cbBaudRate);
            this.Controls.Add(this.label1);
            this.Name = "PopupSIOControlForm";
            this.Text = "SIO Control";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PopupSIOControlForm_FormClosed);
            this.Load += new System.EventHandler(this.PopupSIOControlForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox m_cbBaudRate;
        private System.Windows.Forms.ComboBox m_cbParityBits;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox m_cbDataBits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox m_cbStopBits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox m_ckEnable;
        private System.Windows.Forms.Button m_btnApply;
        private System.Windows.Forms.TextBox m_edData;
        private System.Windows.Forms.Button m_btnSend;
        private System.Windows.Forms.Button m_btnReceive;
        private System.Windows.Forms.Label label6;
    }
}