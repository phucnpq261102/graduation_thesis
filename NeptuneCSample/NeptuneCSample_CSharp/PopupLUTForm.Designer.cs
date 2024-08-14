namespace NeptuneCSample_CSharp
{
    partial class PopupLUTForm
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
            this.m_wndGraph = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_btnApplyLUT = new System.Windows.Forms.Button();
            this.m_btnLinearLUT = new System.Windows.Forms.Button();
            this.m_edPointY4 = new System.Windows.Forms.NumericUpDown();
            this.m_edPointX4 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.m_edPointY3 = new System.Windows.Forms.NumericUpDown();
            this.m_edPointX3 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.m_edPointY2 = new System.Windows.Forms.NumericUpDown();
            this.m_edPointX2 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.m_edPointY1 = new System.Windows.Forms.NumericUpDown();
            this.m_edPointX1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_ckEnableLUT = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_btnApplyUserLUT = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.m_btnSaveUserLUT = new System.Windows.Forms.Button();
            this.m_cbUserLUT = new System.Windows.Forms.ComboBox();
            this.m_ckEnableUserLUT = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.m_wndFileBrowser = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.m_wndGraph)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_edPointY4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_edPointX4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_edPointY3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_edPointX3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_edPointY2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_edPointX2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_edPointY1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_edPointX1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_wndGraph
            // 
            this.m_wndGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_wndGraph.Location = new System.Drawing.Point(42, 12);
            this.m_wndGraph.Name = "m_wndGraph";
            this.m_wndGraph.Size = new System.Drawing.Size(300, 300);
            this.m_wndGraph.TabIndex = 0;
            this.m_wndGraph.TabStop = false;
            this.m_wndGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.m_wndGraph_Paint);
            this.m_wndGraph.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_wndGraph_MouseDown);
            this.m_wndGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_wndGraph_MouseMove);
            this.m_wndGraph.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_wndGraph_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_btnApplyLUT);
            this.groupBox1.Controls.Add(this.m_btnLinearLUT);
            this.groupBox1.Controls.Add(this.m_edPointY4);
            this.groupBox1.Controls.Add(this.m_edPointX4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.m_edPointY3);
            this.groupBox1.Controls.Add(this.m_edPointX3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.m_edPointY2);
            this.groupBox1.Controls.Add(this.m_edPointX2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.m_edPointY1);
            this.groupBox1.Controls.Add(this.m_edPointX1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.m_ckEnableLUT);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(348, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(207, 210);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "4Step LUT";
            // 
            // m_btnApplyLUT
            // 
            this.m_btnApplyLUT.Location = new System.Drawing.Point(138, 176);
            this.m_btnApplyLUT.Name = "m_btnApplyLUT";
            this.m_btnApplyLUT.Size = new System.Drawing.Size(53, 23);
            this.m_btnApplyLUT.TabIndex = 17;
            this.m_btnApplyLUT.Text = "Apply";
            this.m_btnApplyLUT.UseVisualStyleBackColor = true;
            this.m_btnApplyLUT.Click += new System.EventHandler(this.m_btnApplyLUT_Click);
            // 
            // m_btnLinearLUT
            // 
            this.m_btnLinearLUT.Location = new System.Drawing.Point(14, 176);
            this.m_btnLinearLUT.Name = "m_btnLinearLUT";
            this.m_btnLinearLUT.Size = new System.Drawing.Size(118, 23);
            this.m_btnLinearLUT.TabIndex = 16;
            this.m_btnLinearLUT.Text = "Set to Linear";
            this.m_btnLinearLUT.UseVisualStyleBackColor = true;
            this.m_btnLinearLUT.Click += new System.EventHandler(this.m_btnLinearLUT_Click);
            // 
            // m_edPointY4
            // 
            this.m_edPointY4.Location = new System.Drawing.Point(138, 149);
            this.m_edPointY4.Name = "m_edPointY4";
            this.m_edPointY4.Size = new System.Drawing.Size(53, 21);
            this.m_edPointY4.TabIndex = 15;
            // 
            // m_edPointX4
            // 
            this.m_edPointX4.Location = new System.Drawing.Point(79, 149);
            this.m_edPointX4.Name = "m_edPointX4";
            this.m_edPointX4.Size = new System.Drawing.Size(53, 21);
            this.m_edPointX4.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "Point4";
            // 
            // m_edPointY3
            // 
            this.m_edPointY3.Location = new System.Drawing.Point(138, 122);
            this.m_edPointY3.Name = "m_edPointY3";
            this.m_edPointY3.Size = new System.Drawing.Size(53, 21);
            this.m_edPointY3.TabIndex = 12;
            // 
            // m_edPointX3
            // 
            this.m_edPointX3.Location = new System.Drawing.Point(79, 122);
            this.m_edPointX3.Name = "m_edPointX3";
            this.m_edPointX3.Size = new System.Drawing.Size(53, 21);
            this.m_edPointX3.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "Point3";
            // 
            // m_edPointY2
            // 
            this.m_edPointY2.Location = new System.Drawing.Point(138, 95);
            this.m_edPointY2.Name = "m_edPointY2";
            this.m_edPointY2.Size = new System.Drawing.Size(53, 21);
            this.m_edPointY2.TabIndex = 9;
            // 
            // m_edPointX2
            // 
            this.m_edPointX2.Location = new System.Drawing.Point(79, 95);
            this.m_edPointX2.Name = "m_edPointX2";
            this.m_edPointX2.Size = new System.Drawing.Size(53, 21);
            this.m_edPointX2.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "Point2";
            // 
            // m_edPointY1
            // 
            this.m_edPointY1.Location = new System.Drawing.Point(138, 68);
            this.m_edPointY1.Name = "m_edPointY1";
            this.m_edPointY1.Size = new System.Drawing.Size(53, 21);
            this.m_edPointY1.TabIndex = 6;
            // 
            // m_edPointX1
            // 
            this.m_edPointX1.Location = new System.Drawing.Point(79, 68);
            this.m_edPointX1.Name = "m_edPointX1";
            this.m_edPointX1.Size = new System.Drawing.Size(53, 21);
            this.m_edPointX1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "Point1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "X";
            // 
            // m_ckEnableLUT
            // 
            this.m_ckEnableLUT.AutoSize = true;
            this.m_ckEnableLUT.Location = new System.Drawing.Point(79, 23);
            this.m_ckEnableLUT.Name = "m_ckEnableLUT";
            this.m_ckEnableLUT.Size = new System.Drawing.Size(40, 16);
            this.m_ckEnableLUT.TabIndex = 1;
            this.m_ckEnableLUT.Text = "On";
            this.m_ckEnableLUT.UseVisualStyleBackColor = true;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_btnApplyUserLUT);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.m_btnSaveUserLUT);
            this.groupBox2.Controls.Add(this.m_cbUserLUT);
            this.groupBox2.Controls.Add(this.m_ckEnableUserLUT);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(348, 228);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(207, 106);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User LUT";
            // 
            // m_btnApplyUserLUT
            // 
            this.m_btnApplyUserLUT.Location = new System.Drawing.Point(138, 71);
            this.m_btnApplyUserLUT.Name = "m_btnApplyUserLUT";
            this.m_btnApplyUserLUT.Size = new System.Drawing.Size(53, 23);
            this.m_btnApplyUserLUT.TabIndex = 5;
            this.m_btnApplyUserLUT.Text = "Apply";
            this.m_btnApplyUserLUT.UseVisualStyleBackColor = true;
            this.m_btnApplyUserLUT.Click += new System.EventHandler(this.m_btnApplyUserLUT_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "LUT Index";
            // 
            // m_btnSaveUserLUT
            // 
            this.m_btnSaveUserLUT.Location = new System.Drawing.Point(14, 71);
            this.m_btnSaveUserLUT.Name = "m_btnSaveUserLUT";
            this.m_btnSaveUserLUT.Size = new System.Drawing.Size(118, 23);
            this.m_btnSaveUserLUT.TabIndex = 4;
            this.m_btnSaveUserLUT.Text = "SaveData in Index";
            this.m_btnSaveUserLUT.UseVisualStyleBackColor = true;
            this.m_btnSaveUserLUT.Click += new System.EventHandler(this.m_btnSaveUserLUT_Click);
            // 
            // m_cbUserLUT
            // 
            this.m_cbUserLUT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbUserLUT.FormattingEnabled = true;
            this.m_cbUserLUT.Location = new System.Drawing.Point(79, 45);
            this.m_cbUserLUT.Name = "m_cbUserLUT";
            this.m_cbUserLUT.Size = new System.Drawing.Size(112, 20);
            this.m_cbUserLUT.TabIndex = 3;
            // 
            // m_ckEnableUserLUT
            // 
            this.m_ckEnableUserLUT.AutoSize = true;
            this.m_ckEnableUserLUT.Location = new System.Drawing.Point(79, 23);
            this.m_ckEnableUserLUT.Name = "m_ckEnableUserLUT";
            this.m_ckEnableUserLUT.Size = new System.Drawing.Size(40, 16);
            this.m_ckEnableUserLUT.TabIndex = 1;
            this.m_ckEnableUserLUT.Text = "On";
            this.m_ckEnableUserLUT.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "Enable";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "4095";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 322);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 3;
            this.label11.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(313, 322);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 4;
            this.label12.Text = "4095";
            // 
            // m_wndFileBrowser
            // 
            this.m_wndFileBrowser.Filter = "Data Files (*.dat)|*.dat|All Files (*.*)|*.*||";
            // 
            // PopupLUTForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 343);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_wndGraph);
            this.Name = "PopupLUTForm";
            this.Text = "Look Up Table";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PopupLUTForm_FormClosed);
            this.Load += new System.EventHandler(this.PopupLUTForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_wndGraph)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_edPointY4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_edPointX4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_edPointY3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_edPointX3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_edPointY2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_edPointX2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_edPointY1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_edPointX1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox m_wndGraph;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button m_btnApplyLUT;
        private System.Windows.Forms.Button m_btnLinearLUT;
        private System.Windows.Forms.NumericUpDown m_edPointY4;
        private System.Windows.Forms.NumericUpDown m_edPointX4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown m_edPointY3;
        private System.Windows.Forms.NumericUpDown m_edPointX3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown m_edPointY2;
        private System.Windows.Forms.NumericUpDown m_edPointX2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown m_edPointY1;
        private System.Windows.Forms.NumericUpDown m_edPointX1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox m_ckEnableLUT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button m_btnSaveUserLUT;
        private System.Windows.Forms.ComboBox m_cbUserLUT;
        private System.Windows.Forms.CheckBox m_ckEnableUserLUT;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button m_btnApplyUserLUT;
        private System.Windows.Forms.OpenFileDialog m_wndFileBrowser;
    }
}