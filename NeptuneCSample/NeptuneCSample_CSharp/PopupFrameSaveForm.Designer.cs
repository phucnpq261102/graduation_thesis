namespace NeptuneCSample_CSharp
{
    partial class PopupFrameSaveForm
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
            this.m_ckEnable = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_edRemained = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_edRecvCount = new System.Windows.Forms.NumericUpDown();
            this.m_btnPlay = new System.Windows.Forms.Button();
            this.m_btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_edRecvCount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enable";
            // 
            // m_ckEnable
            // 
            this.m_ckEnable.AutoSize = true;
            this.m_ckEnable.Location = new System.Drawing.Point(232, 23);
            this.m_ckEnable.Name = "m_ckEnable";
            this.m_ckEnable.Size = new System.Drawing.Size(40, 16);
            this.m_ckEnable.TabIndex = 1;
            this.m_ckEnable.Text = "On";
            this.m_ckEnable.UseVisualStyleBackColor = true;
            this.m_ckEnable.CheckedChanged += new System.EventHandler(this.m_ckEnable_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Remained Image (Camera Buffer)";
            // 
            // m_edRemained
            // 
            this.m_edRemained.Location = new System.Drawing.Point(232, 49);
            this.m_edRemained.Name = "m_edRemained";
            this.m_edRemained.ReadOnly = true;
            this.m_edRemained.Size = new System.Drawing.Size(80, 21);
            this.m_edRemained.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Receive Image (Camera to PC)";
            // 
            // m_edRecvCount
            // 
            this.m_edRecvCount.Location = new System.Drawing.Point(232, 80);
            this.m_edRecvCount.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.m_edRecvCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_edRecvCount.Name = "m_edRecvCount";
            this.m_edRecvCount.Size = new System.Drawing.Size(80, 21);
            this.m_edRecvCount.TabIndex = 6;
            this.m_edRecvCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // m_btnPlay
            // 
            this.m_btnPlay.Image = global::NeptuneCSample_CSharp.Properties.Resources.icon_play;
            this.m_btnPlay.Location = new System.Drawing.Point(318, 80);
            this.m_btnPlay.Name = "m_btnPlay";
            this.m_btnPlay.Size = new System.Drawing.Size(25, 22);
            this.m_btnPlay.TabIndex = 7;
            this.m_btnPlay.Text = ">";
            this.m_btnPlay.UseVisualStyleBackColor = true;
            this.m_btnPlay.Click += new System.EventHandler(this.m_btnPlay_Click);
            // 
            // m_btnRefresh
            // 
            this.m_btnRefresh.Image = global::NeptuneCSample_CSharp.Properties.Resources.icon_refresh;
            this.m_btnRefresh.Location = new System.Drawing.Point(318, 49);
            this.m_btnRefresh.Name = "m_btnRefresh";
            this.m_btnRefresh.Size = new System.Drawing.Size(25, 22);
            this.m_btnRefresh.TabIndex = 4;
            this.m_btnRefresh.UseVisualStyleBackColor = true;
            this.m_btnRefresh.Click += new System.EventHandler(this.m_btnRefresh_Click);
            // 
            // PopupFrameSaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 115);
            this.Controls.Add(this.m_btnPlay);
            this.Controls.Add(this.m_edRecvCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_btnRefresh);
            this.Controls.Add(this.m_edRemained);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_ckEnable);
            this.Controls.Add(this.label1);
            this.Name = "PopupFrameSaveForm";
            this.Text = "Frame Save";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PopupFrameSaveForm_FormClosed);
            this.Load += new System.EventHandler(this.PopupFrameSaveForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_edRecvCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox m_ckEnable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_edRemained;
        private System.Windows.Forms.Button m_btnRefresh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown m_edRecvCount;
        private System.Windows.Forms.Button m_btnPlay;
    }
}