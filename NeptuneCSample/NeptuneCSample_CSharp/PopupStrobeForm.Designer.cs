namespace NeptuneCSample_CSharp
{
    partial class PopupStrobeForm
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
            this.m_ckStrobeEnable = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cbStrobeMode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cbStrobePolarity = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_edStrobeDelay = new System.Windows.Forms.NumericUpDown();
            this.m_stcDelayRange = new System.Windows.Forms.Label();
            this.m_stcDurationRange = new System.Windows.Forms.Label();
            this.m_edStrobeDuration = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.m_btnApply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_edStrobeDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_edStrobeDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Strobe Enable";
            // 
            // m_ckStrobeEnable
            // 
            this.m_ckStrobeEnable.AutoSize = true;
            this.m_ckStrobeEnable.Location = new System.Drawing.Point(145, 19);
            this.m_ckStrobeEnable.Name = "m_ckStrobeEnable";
            this.m_ckStrobeEnable.Size = new System.Drawing.Size(40, 16);
            this.m_ckStrobeEnable.TabIndex = 1;
            this.m_ckStrobeEnable.Text = "On";
            this.m_ckStrobeEnable.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Strobe Mode";
            // 
            // m_cbStrobeMode
            // 
            this.m_cbStrobeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbStrobeMode.FormattingEnabled = true;
            this.m_cbStrobeMode.Location = new System.Drawing.Point(145, 47);
            this.m_cbStrobeMode.Name = "m_cbStrobeMode";
            this.m_cbStrobeMode.Size = new System.Drawing.Size(121, 20);
            this.m_cbStrobeMode.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Strobe Polarity";
            // 
            // m_cbStrobePolarity
            // 
            this.m_cbStrobePolarity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbStrobePolarity.FormattingEnabled = true;
            this.m_cbStrobePolarity.Location = new System.Drawing.Point(145, 79);
            this.m_cbStrobePolarity.Name = "m_cbStrobePolarity";
            this.m_cbStrobePolarity.Size = new System.Drawing.Size(121, 20);
            this.m_cbStrobePolarity.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Strobe Delay";
            // 
            // m_edStrobeDelay
            // 
            this.m_edStrobeDelay.Location = new System.Drawing.Point(145, 111);
            this.m_edStrobeDelay.Name = "m_edStrobeDelay";
            this.m_edStrobeDelay.Size = new System.Drawing.Size(120, 21);
            this.m_edStrobeDelay.TabIndex = 7;
            // 
            // m_stcDelayRange
            // 
            this.m_stcDelayRange.AutoSize = true;
            this.m_stcDelayRange.Location = new System.Drawing.Point(277, 116);
            this.m_stcDelayRange.Name = "m_stcDelayRange";
            this.m_stcDelayRange.Size = new System.Drawing.Size(78, 12);
            this.m_stcDelayRange.TabIndex = 8;
            this.m_stcDelayRange.Text = "(Min ~ Max)";
            // 
            // m_stcDurationRange
            // 
            this.m_stcDurationRange.AutoSize = true;
            this.m_stcDurationRange.Location = new System.Drawing.Point(277, 148);
            this.m_stcDurationRange.Name = "m_stcDurationRange";
            this.m_stcDurationRange.Size = new System.Drawing.Size(78, 12);
            this.m_stcDurationRange.TabIndex = 11;
            this.m_stcDurationRange.Text = "(Min ~ Max)";
            // 
            // m_edStrobeDuration
            // 
            this.m_edStrobeDuration.Location = new System.Drawing.Point(145, 143);
            this.m_edStrobeDuration.Name = "m_edStrobeDuration";
            this.m_edStrobeDuration.Size = new System.Drawing.Size(120, 21);
            this.m_edStrobeDuration.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "Strobe Duration";
            // 
            // m_btnApply
            // 
            this.m_btnApply.Location = new System.Drawing.Point(149, 185);
            this.m_btnApply.Name = "m_btnApply";
            this.m_btnApply.Size = new System.Drawing.Size(75, 23);
            this.m_btnApply.TabIndex = 12;
            this.m_btnApply.Text = "Apply";
            this.m_btnApply.UseVisualStyleBackColor = true;
            this.m_btnApply.Click += new System.EventHandler(this.m_btnApply_Click);
            // 
            // PopupStrobeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 222);
            this.Controls.Add(this.m_btnApply);
            this.Controls.Add(this.m_stcDurationRange);
            this.Controls.Add(this.m_edStrobeDuration);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_stcDelayRange);
            this.Controls.Add(this.m_edStrobeDelay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_cbStrobePolarity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_cbStrobeMode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_ckStrobeEnable);
            this.Controls.Add(this.label1);
            this.Name = "PopupStrobeForm";
            this.Text = "Strobe";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PopupStrobeForm_FormClosed);
            this.Load += new System.EventHandler(this.PopupStrobeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_edStrobeDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_edStrobeDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox m_ckStrobeEnable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox m_cbStrobeMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox m_cbStrobePolarity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown m_edStrobeDelay;
        private System.Windows.Forms.Label m_stcDelayRange;
        private System.Windows.Forms.Label m_stcDurationRange;
        private System.Windows.Forms.NumericUpDown m_edStrobeDuration;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button m_btnApply;
    }
}