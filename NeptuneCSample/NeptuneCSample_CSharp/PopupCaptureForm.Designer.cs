namespace NeptuneCSample_CSharp
{
    partial class PopupCaptureForm
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
            this.m_wndFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.m_edSavePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cbImageForamt = new System.Windows.Forms.ComboBox();
            this.m_btnBrowser = new System.Windows.Forms.Button();
            this.m_btnSaveImage = new System.Windows.Forms.Button();
            this.m_btnStartRecord = new System.Windows.Forms.Button();
            this.m_btnStopRecord = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Save Path";
            // 
            // m_edSavePath
            // 
            this.m_edSavePath.Location = new System.Drawing.Point(100, 16);
            this.m_edSavePath.Name = "m_edSavePath";
            this.m_edSavePath.ReadOnly = true;
            this.m_edSavePath.Size = new System.Drawing.Size(319, 20);
            this.m_edSavePath.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Image Format";
            // 
            // m_cbImageForamt
            // 
            this.m_cbImageForamt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbImageForamt.FormattingEnabled = true;
            this.m_cbImageForamt.Location = new System.Drawing.Point(100, 51);
            this.m_cbImageForamt.Name = "m_cbImageForamt";
            this.m_cbImageForamt.Size = new System.Drawing.Size(104, 21);
            this.m_cbImageForamt.TabIndex = 3;
            this.m_cbImageForamt.SelectedIndexChanged += new System.EventHandler(this.m_cbImageForamt_SelectedIndexChanged);
            // 
            // m_btnBrowser
            // 
            this.m_btnBrowser.Location = new System.Drawing.Point(424, 15);
            this.m_btnBrowser.Name = "m_btnBrowser";
            this.m_btnBrowser.Size = new System.Drawing.Size(28, 25);
            this.m_btnBrowser.TabIndex = 4;
            this.m_btnBrowser.Text = "...";
            this.m_btnBrowser.UseVisualStyleBackColor = true;
            this.m_btnBrowser.Click += new System.EventHandler(this.m_btnBrowser_Click);
            // 
            // m_btnSaveImage
            // 
            this.m_btnSaveImage.Location = new System.Drawing.Point(91, 107);
            this.m_btnSaveImage.Name = "m_btnSaveImage";
            this.m_btnSaveImage.Size = new System.Drawing.Size(92, 25);
            this.m_btnSaveImage.TabIndex = 5;
            this.m_btnSaveImage.Text = "Save Image";
            this.m_btnSaveImage.UseVisualStyleBackColor = true;
            this.m_btnSaveImage.Click += new System.EventHandler(this.m_btnSaveImage_Click);
            // 
            // m_btnStartRecord
            // 
            this.m_btnStartRecord.Location = new System.Drawing.Point(188, 107);
            this.m_btnStartRecord.Name = "m_btnStartRecord";
            this.m_btnStartRecord.Size = new System.Drawing.Size(92, 25);
            this.m_btnStartRecord.TabIndex = 6;
            this.m_btnStartRecord.Text = "Start Record";
            this.m_btnStartRecord.UseVisualStyleBackColor = true;
            this.m_btnStartRecord.Click += new System.EventHandler(this.m_btnStartRecord_Click);
            // 
            // m_btnStopRecord
            // 
            this.m_btnStopRecord.Location = new System.Drawing.Point(285, 107);
            this.m_btnStopRecord.Name = "m_btnStopRecord";
            this.m_btnStopRecord.Size = new System.Drawing.Size(92, 25);
            this.m_btnStopRecord.TabIndex = 7;
            this.m_btnStopRecord.Text = "Stop Record";
            this.m_btnStopRecord.UseVisualStyleBackColor = true;
            this.m_btnStopRecord.Click += new System.EventHandler(this.m_btnStopRecord_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "* AVI Max Resolution: 4k (4096 x 2160)";
            // 
            // PopupCaptureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 158);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_btnStopRecord);
            this.Controls.Add(this.m_btnStartRecord);
            this.Controls.Add(this.m_btnSaveImage);
            this.Controls.Add(this.m_btnBrowser);
            this.Controls.Add(this.m_cbImageForamt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_edSavePath);
            this.Controls.Add(this.label1);
            this.Name = "PopupCaptureForm";
            this.Text = "Capture";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PopupCaptureForm_FormClosed);
            this.Load += new System.EventHandler(this.PopupCaptureForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog m_wndFolderBrowser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_edSavePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox m_cbImageForamt;
        private System.Windows.Forms.Button m_btnBrowser;
        private System.Windows.Forms.Button m_btnSaveImage;
        private System.Windows.Forms.Button m_btnStartRecord;
        private System.Windows.Forms.Button m_btnStopRecord;
        private System.Windows.Forms.Label label3;
    }
}