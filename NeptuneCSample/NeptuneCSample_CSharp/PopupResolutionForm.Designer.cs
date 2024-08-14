namespace NeptuneCSample_CSharp
{
    partial class PopupResolutionForm
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
            this.m_stcResolution = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_edOffsetX = new System.Windows.Forms.NumericUpDown();
            this.m_edWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.m_edOffsetY = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.m_edHeight = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.m_btnApply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_edOffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_edWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_edOffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_edHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // m_stcResolution
            // 
            this.m_stcResolution.AutoSize = true;
            this.m_stcResolution.Location = new System.Drawing.Point(12, 20);
            this.m_stcResolution.Name = "m_stcResolution";
            this.m_stcResolution.Size = new System.Drawing.Size(152, 12);
            this.m_stcResolution.TabIndex = 0;
            this.m_stcResolution.Text = "Resolution: Width x Height";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Offset X";
            // 
            // m_edOffsetX
            // 
            this.m_edOffsetX.Location = new System.Drawing.Point(75, 49);
            this.m_edOffsetX.Name = "m_edOffsetX";
            this.m_edOffsetX.Size = new System.Drawing.Size(67, 21);
            this.m_edOffsetX.TabIndex = 2;
            // 
            // m_edWidth
            // 
            this.m_edWidth.Location = new System.Drawing.Point(225, 49);
            this.m_edWidth.Name = "m_edWidth";
            this.m_edWidth.Size = new System.Drawing.Size(67, 21);
            this.m_edWidth.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Width";
            // 
            // m_edOffsetY
            // 
            this.m_edOffsetY.Location = new System.Drawing.Point(75, 91);
            this.m_edOffsetY.Name = "m_edOffsetY";
            this.m_edOffsetY.Size = new System.Drawing.Size(67, 21);
            this.m_edOffsetY.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Offset Y";
            // 
            // m_edHeight
            // 
            this.m_edHeight.Location = new System.Drawing.Point(225, 91);
            this.m_edHeight.Name = "m_edHeight";
            this.m_edHeight.Size = new System.Drawing.Size(67, 21);
            this.m_edHeight.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Height";
            // 
            // m_btnApply
            // 
            this.m_btnApply.Location = new System.Drawing.Point(121, 139);
            this.m_btnApply.Name = "m_btnApply";
            this.m_btnApply.Size = new System.Drawing.Size(75, 23);
            this.m_btnApply.TabIndex = 9;
            this.m_btnApply.Text = "Apply";
            this.m_btnApply.UseVisualStyleBackColor = true;
            this.m_btnApply.Click += new System.EventHandler(this.m_btnApply_Click);
            // 
            // PopupResolutionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 175);
            this.Controls.Add(this.m_btnApply);
            this.Controls.Add(this.m_edHeight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_edOffsetY);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_edWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_edOffsetX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_stcResolution);
            this.Name = "PopupResolutionForm";
            this.Text = "Resolution";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PopupResolutionForm_FormClosed);
            this.Load += new System.EventHandler(this.PopupResolutionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_edOffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_edWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_edOffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_edHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_stcResolution;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown m_edOffsetX;
        private System.Windows.Forms.NumericUpDown m_edWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown m_edOffsetY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown m_edHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button m_btnApply;
    }
}