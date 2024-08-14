namespace NeptuneCSample_CSharp
{
    partial class PopupUserSetForm
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
            this.m_cbUserSet = new System.Windows.Forms.ComboBox();
            this.m_btnLoad = new System.Windows.Forms.Button();
            this.m_btnSave = new System.Windows.Forms.Button();
            this.m_btnSetDefault = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_cbUserSet
            // 
            this.m_cbUserSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbUserSet.FormattingEnabled = true;
            this.m_cbUserSet.Location = new System.Drawing.Point(12, 12);
            this.m_cbUserSet.Name = "m_cbUserSet";
            this.m_cbUserSet.Size = new System.Drawing.Size(166, 20);
            this.m_cbUserSet.TabIndex = 0;
            // 
            // m_btnLoad
            // 
            this.m_btnLoad.Location = new System.Drawing.Point(12, 38);
            this.m_btnLoad.Name = "m_btnLoad";
            this.m_btnLoad.Size = new System.Drawing.Size(166, 23);
            this.m_btnLoad.TabIndex = 1;
            this.m_btnLoad.Text = "UserSet Load";
            this.m_btnLoad.UseVisualStyleBackColor = true;
            this.m_btnLoad.Click += new System.EventHandler(this.m_btnLoad_Click);
            // 
            // m_btnSave
            // 
            this.m_btnSave.Location = new System.Drawing.Point(12, 67);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Size = new System.Drawing.Size(166, 23);
            this.m_btnSave.TabIndex = 2;
            this.m_btnSave.Text = "UserSet Save";
            this.m_btnSave.UseVisualStyleBackColor = true;
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_btnSetDefault
            // 
            this.m_btnSetDefault.Location = new System.Drawing.Point(12, 96);
            this.m_btnSetDefault.Name = "m_btnSetDefault";
            this.m_btnSetDefault.Size = new System.Drawing.Size(166, 23);
            this.m_btnSetDefault.TabIndex = 3;
            this.m_btnSetDefault.Text = "Set Power On Default";
            this.m_btnSetDefault.UseVisualStyleBackColor = true;
            this.m_btnSetDefault.Click += new System.EventHandler(this.m_btnSetDefault_Click);
            // 
            // PopupUserSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 132);
            this.Controls.Add(this.m_btnSetDefault);
            this.Controls.Add(this.m_btnSave);
            this.Controls.Add(this.m_btnLoad);
            this.Controls.Add(this.m_cbUserSet);
            this.Name = "PopupUserSetForm";
            this.Text = "User Set";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PopupUserSetForm_FormClosed);
            this.Load += new System.EventHandler(this.PopupUserSetForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox m_cbUserSet;
        private System.Windows.Forms.Button m_btnLoad;
        private System.Windows.Forms.Button m_btnSave;
        private System.Windows.Forms.Button m_btnSetDefault;
    }
}