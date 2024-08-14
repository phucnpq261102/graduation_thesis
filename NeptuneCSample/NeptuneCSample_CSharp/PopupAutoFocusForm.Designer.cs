namespace NeptuneCSample_CSharp
{
    partial class PopupAutoFocusForm
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
            this.m_btnOriginal = new System.Windows.Forms.Button();
            this.m_btnOnePush = new System.Windows.Forms.Button();
            this.m_btnOneStepForward = new System.Windows.Forms.Button();
            this.m_btnOneStepBackward = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_btnOriginal
            // 
            this.m_btnOriginal.Location = new System.Drawing.Point(12, 12);
            this.m_btnOriginal.Name = "m_btnOriginal";
            this.m_btnOriginal.Size = new System.Drawing.Size(194, 23);
            this.m_btnOriginal.TabIndex = 0;
            this.m_btnOriginal.Text = "Origin Point";
            this.m_btnOriginal.UseVisualStyleBackColor = true;
            this.m_btnOriginal.Click += new System.EventHandler(this.m_btnOriginal_Click);
            // 
            // m_btnOnePush
            // 
            this.m_btnOnePush.Location = new System.Drawing.Point(12, 41);
            this.m_btnOnePush.Name = "m_btnOnePush";
            this.m_btnOnePush.Size = new System.Drawing.Size(194, 23);
            this.m_btnOnePush.TabIndex = 1;
            this.m_btnOnePush.Text = "One Push Auto";
            this.m_btnOnePush.UseVisualStyleBackColor = true;
            this.m_btnOnePush.Click += new System.EventHandler(this.m_btnOnePush_Click);
            // 
            // m_btnOneStepForward
            // 
            this.m_btnOneStepForward.Location = new System.Drawing.Point(12, 70);
            this.m_btnOneStepForward.Name = "m_btnOneStepForward";
            this.m_btnOneStepForward.Size = new System.Drawing.Size(194, 23);
            this.m_btnOneStepForward.TabIndex = 2;
            this.m_btnOneStepForward.Text = "One-Step Forward";
            this.m_btnOneStepForward.UseVisualStyleBackColor = true;
            this.m_btnOneStepForward.Click += new System.EventHandler(this.m_btnOneStepForward_Click);
            // 
            // m_btnOneStepBackward
            // 
            this.m_btnOneStepBackward.Location = new System.Drawing.Point(12, 99);
            this.m_btnOneStepBackward.Name = "m_btnOneStepBackward";
            this.m_btnOneStepBackward.Size = new System.Drawing.Size(194, 23);
            this.m_btnOneStepBackward.TabIndex = 3;
            this.m_btnOneStepBackward.Text = "One-Step Backward";
            this.m_btnOneStepBackward.UseVisualStyleBackColor = true;
            this.m_btnOneStepBackward.Click += new System.EventHandler(this.m_btnOneStepBackward_Click);
            // 
            // PopupAutoFocusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 134);
            this.Controls.Add(this.m_btnOneStepBackward);
            this.Controls.Add(this.m_btnOneStepForward);
            this.Controls.Add(this.m_btnOnePush);
            this.Controls.Add(this.m_btnOriginal);
            this.Name = "PopupAutoFocusForm";
            this.Text = "Auto Focus";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PopupAutoFocusForm_FormClosed);
            this.Load += new System.EventHandler(this.PopupAutoFocusForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_btnOriginal;
        private System.Windows.Forms.Button m_btnOnePush;
        private System.Windows.Forms.Button m_btnOneStepForward;
        private System.Windows.Forms.Button m_btnOneStepBackward;
    }
}