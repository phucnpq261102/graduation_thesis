namespace NeptuneCSample_CSharp
{
    partial class PopupStackedROIForm
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
            this.m_ckControl = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cbROISelector = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_tbAllOffsetX = new System.Windows.Forms.TextBox();
            this.m_tbAllWidth = new System.Windows.Forms.TextBox();
            this.m_btnSetAllOffsetX = new System.Windows.Forms.Button();
            this.m_btnSetAllWidth = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_tbHeight = new System.Windows.Forms.TextBox();
            this.m_tbWidth = new System.Windows.Forms.TextBox();
            this.m_tbOffsetY = new System.Windows.Forms.TextBox();
            this.m_tbOffsetX = new System.Windows.Forms.TextBox();
            this.m_ckEnable = new System.Windows.Forms.CheckBox();
            this.m_btnApply = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Control";
            // 
            // m_ckControl
            // 
            this.m_ckControl.AutoSize = true;
            this.m_ckControl.Location = new System.Drawing.Point(120, 19);
            this.m_ckControl.Name = "m_ckControl";
            this.m_ckControl.Size = new System.Drawing.Size(40, 16);
            this.m_ckControl.TabIndex = 1;
            this.m_ckControl.Text = "On";
            this.m_ckControl.UseVisualStyleBackColor = true;
            this.m_ckControl.CheckedChanged += new System.EventHandler(this.m_ckControl_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "All offset X";
            // 
            // m_cbROISelector
            // 
            this.m_cbROISelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbROISelector.FormattingEnabled = true;
            this.m_cbROISelector.Location = new System.Drawing.Point(108, 28);
            this.m_cbROISelector.Name = "m_cbROISelector";
            this.m_cbROISelector.Size = new System.Drawing.Size(100, 20);
            this.m_cbROISelector.TabIndex = 3;
            this.m_cbROISelector.SelectedIndexChanged += new System.EventHandler(this.m_cbROISelector_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "All width";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "ROI index";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "Enable";
            // 
            // m_tbAllOffsetX
            // 
            this.m_tbAllOffsetX.Location = new System.Drawing.Point(120, 49);
            this.m_tbAllOffsetX.Name = "m_tbAllOffsetX";
            this.m_tbAllOffsetX.Size = new System.Drawing.Size(100, 21);
            this.m_tbAllOffsetX.TabIndex = 13;
            // 
            // m_tbAllWidth
            // 
            this.m_tbAllWidth.Location = new System.Drawing.Point(120, 81);
            this.m_tbAllWidth.Name = "m_tbAllWidth";
            this.m_tbAllWidth.Size = new System.Drawing.Size(100, 21);
            this.m_tbAllWidth.TabIndex = 14;
            // 
            // m_btnSetAllOffsetX
            // 
            this.m_btnSetAllOffsetX.Location = new System.Drawing.Point(237, 49);
            this.m_btnSetAllOffsetX.Name = "m_btnSetAllOffsetX";
            this.m_btnSetAllOffsetX.Size = new System.Drawing.Size(75, 23);
            this.m_btnSetAllOffsetX.TabIndex = 15;
            this.m_btnSetAllOffsetX.Text = "Set";
            this.m_btnSetAllOffsetX.UseVisualStyleBackColor = true;
            this.m_btnSetAllOffsetX.Click += new System.EventHandler(this.m_btnSetAllOffsetX_Click);
            // 
            // m_btnSetAllWidth
            // 
            this.m_btnSetAllWidth.Location = new System.Drawing.Point(237, 79);
            this.m_btnSetAllWidth.Name = "m_btnSetAllWidth";
            this.m_btnSetAllWidth.Size = new System.Drawing.Size(75, 23);
            this.m_btnSetAllWidth.TabIndex = 16;
            this.m_btnSetAllWidth.Text = "Set";
            this.m_btnSetAllWidth.UseVisualStyleBackColor = true;
            this.m_btnSetAllWidth.Click += new System.EventHandler(this.m_btnSetAllWidth_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.m_tbHeight);
            this.groupBox1.Controls.Add(this.m_tbWidth);
            this.groupBox1.Controls.Add(this.m_tbOffsetY);
            this.groupBox1.Controls.Add(this.m_tbOffsetX);
            this.groupBox1.Controls.Add(this.m_ckEnable);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.m_cbROISelector);
            this.groupBox1.Controls.Add(this.m_btnApply);
            this.groupBox1.Location = new System.Drawing.Point(12, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 247);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(57, 186);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 12);
            this.label9.TabIndex = 25;
            this.label9.Text = "Height";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(62, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 24;
            this.label8.Text = "Width";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 12);
            this.label7.TabIndex = 23;
            this.label7.Text = "Offset Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "Offset X";
            // 
            // m_tbHeight
            // 
            this.m_tbHeight.Location = new System.Drawing.Point(108, 177);
            this.m_tbHeight.Name = "m_tbHeight";
            this.m_tbHeight.Size = new System.Drawing.Size(100, 21);
            this.m_tbHeight.TabIndex = 21;
            // 
            // m_tbWidth
            // 
            this.m_tbWidth.Location = new System.Drawing.Point(108, 147);
            this.m_tbWidth.Name = "m_tbWidth";
            this.m_tbWidth.Size = new System.Drawing.Size(100, 21);
            this.m_tbWidth.TabIndex = 20;
            // 
            // m_tbOffsetY
            // 
            this.m_tbOffsetY.Location = new System.Drawing.Point(108, 117);
            this.m_tbOffsetY.Name = "m_tbOffsetY";
            this.m_tbOffsetY.Size = new System.Drawing.Size(100, 21);
            this.m_tbOffsetY.TabIndex = 19;
            // 
            // m_tbOffsetX
            // 
            this.m_tbOffsetX.Location = new System.Drawing.Point(108, 86);
            this.m_tbOffsetX.Name = "m_tbOffsetX";
            this.m_tbOffsetX.Size = new System.Drawing.Size(100, 21);
            this.m_tbOffsetX.TabIndex = 18;
            // 
            // m_ckEnable
            // 
            this.m_ckEnable.AutoSize = true;
            this.m_ckEnable.Location = new System.Drawing.Point(108, 61);
            this.m_ckEnable.Name = "m_ckEnable";
            this.m_ckEnable.Size = new System.Drawing.Size(40, 16);
            this.m_ckEnable.TabIndex = 18;
            this.m_ckEnable.Text = "On";
            this.m_ckEnable.UseVisualStyleBackColor = true;
            // 
            // m_btnApply
            // 
            this.m_btnApply.Location = new System.Drawing.Point(133, 207);
            this.m_btnApply.Name = "m_btnApply";
            this.m_btnApply.Size = new System.Drawing.Size(75, 23);
            this.m_btnApply.TabIndex = 12;
            this.m_btnApply.Text = "Apply";
            this.m_btnApply.UseVisualStyleBackColor = true;
            this.m_btnApply.Click += new System.EventHandler(this.m_btnApply_Click);
            // 
            // PopupStackedROIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 376);
            this.Controls.Add(this.m_btnSetAllWidth);
            this.Controls.Add(this.m_btnSetAllOffsetX);
            this.Controls.Add(this.m_tbAllWidth);
            this.Controls.Add(this.m_tbAllOffsetX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_ckControl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "PopupStackedROIForm";
            this.Text = "Stacked ROI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PopupStackedROIForm_FormClosed);
            this.Load += new System.EventHandler(this.PopupStackedROIForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox m_ckControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox m_cbROISelector;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox m_tbAllOffsetX;
        private System.Windows.Forms.TextBox m_tbAllWidth;
        private System.Windows.Forms.Button m_btnSetAllOffsetX;
        private System.Windows.Forms.Button m_btnSetAllWidth;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox m_ckEnable;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox m_tbHeight;
        private System.Windows.Forms.TextBox m_tbWidth;
        private System.Windows.Forms.TextBox m_tbOffsetY;
        private System.Windows.Forms.TextBox m_tbOffsetX;
        private System.Windows.Forms.Button m_btnApply;
    }
}