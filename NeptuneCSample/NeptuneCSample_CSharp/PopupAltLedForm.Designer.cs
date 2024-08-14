namespace NeptuneCSample_CSharp
{
    partial class PopupAltLedForm
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
            this.m_gridTable = new System.Windows.Forms.DataGridView();
            this.m_rbIndex = new System.Windows.Forms.RadioButton();
            this.m_rbDirect = new System.Windows.Forms.RadioButton();
            this.m_btnAutoRun = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_tbStartIndex = new System.Windows.Forms.TextBox();
            this.m_btnSet = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_btnZeroFill = new System.Windows.Forms.Button();
            this.m_btnSampleFill = new System.Windows.Forms.Button();
            this.m_btnUpdateTable = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_gridTable)).BeginInit();
            this.SuspendLayout();
            // 
            // m_gridTable
            // 
            this.m_gridTable.AllowUserToDeleteRows = false;
            this.m_gridTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_gridTable.Location = new System.Drawing.Point(13, 184);
            this.m_gridTable.Name = "m_gridTable";
            this.m_gridTable.RowTemplate.Height = 23;
            this.m_gridTable.Size = new System.Drawing.Size(527, 327);
            this.m_gridTable.TabIndex = 0;
            this.m_gridTable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_gridTable_CellValueChanged);
            this.m_gridTable.SelectionChanged += new System.EventHandler(this.m_gridTable_SelectionChanged);
            // 
            // m_rbIndex
            // 
            this.m_rbIndex.AutoSize = true;
            this.m_rbIndex.Location = new System.Drawing.Point(37, 33);
            this.m_rbIndex.Name = "m_rbIndex";
            this.m_rbIndex.Size = new System.Drawing.Size(90, 16);
            this.m_rbIndex.TabIndex = 1;
            this.m_rbIndex.TabStop = true;
            this.m_rbIndex.Text = "Index Table";
            this.m_rbIndex.UseVisualStyleBackColor = true;
            this.m_rbIndex.CheckedChanged += new System.EventHandler(this.m_rbIndex_CheckedChanged);
            // 
            // m_rbDirect
            // 
            this.m_rbDirect.AutoSize = true;
            this.m_rbDirect.Location = new System.Drawing.Point(144, 33);
            this.m_rbDirect.Name = "m_rbDirect";
            this.m_rbDirect.Size = new System.Drawing.Size(65, 16);
            this.m_rbDirect.TabIndex = 2;
            this.m_rbDirect.TabStop = true;
            this.m_rbDirect.Text = "Direct 0";
            this.m_rbDirect.UseVisualStyleBackColor = true;
            this.m_rbDirect.CheckedChanged += new System.EventHandler(this.m_rbDirect_CheckedChanged);
            // 
            // m_btnAutoRun
            // 
            this.m_btnAutoRun.AutoSize = true;
            this.m_btnAutoRun.Location = new System.Drawing.Point(37, 64);
            this.m_btnAutoRun.Name = "m_btnAutoRun";
            this.m_btnAutoRun.Size = new System.Drawing.Size(102, 16);
            this.m_btnAutoRun.TabIndex = 3;
            this.m_btnAutoRun.Text = "LED Auto Run";
            this.m_btnAutoRun.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Start Index";
            // 
            // m_tbStartIndex
            // 
            this.m_tbStartIndex.Location = new System.Drawing.Point(109, 95);
            this.m_tbStartIndex.Name = "m_tbStartIndex";
            this.m_tbStartIndex.Size = new System.Drawing.Size(100, 21);
            this.m_tbStartIndex.TabIndex = 5;
            // 
            // m_btnSet
            // 
            this.m_btnSet.Location = new System.Drawing.Point(298, 94);
            this.m_btnSet.Name = "m_btnSet";
            this.m_btnSet.Size = new System.Drawing.Size(75, 23);
            this.m_btnSet.TabIndex = 6;
            this.m_btnSet.Text = "Set";
            this.m_btnSet.UseVisualStyleBackColor = true;
            this.m_btnSet.Click += new System.EventHandler(this.m_btnSet_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "( 0 ~ 254 )";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 124);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // m_btnZeroFill
            // 
            this.m_btnZeroFill.Location = new System.Drawing.Point(240, 155);
            this.m_btnZeroFill.Name = "m_btnZeroFill";
            this.m_btnZeroFill.Size = new System.Drawing.Size(94, 23);
            this.m_btnZeroFill.TabIndex = 9;
            this.m_btnZeroFill.Text = "Zero Fill";
            this.m_btnZeroFill.UseVisualStyleBackColor = true;
            this.m_btnZeroFill.Click += new System.EventHandler(this.m_btnZeroFill_Click);
            // 
            // m_btnSampleFill
            // 
            this.m_btnSampleFill.Location = new System.Drawing.Point(339, 155);
            this.m_btnSampleFill.Name = "m_btnSampleFill";
            this.m_btnSampleFill.Size = new System.Drawing.Size(94, 23);
            this.m_btnSampleFill.TabIndex = 10;
            this.m_btnSampleFill.Text = "Sample Fill";
            this.m_btnSampleFill.UseVisualStyleBackColor = true;
            this.m_btnSampleFill.Click += new System.EventHandler(this.m_btnSampleFill_Click);
            // 
            // m_btnUpdateTable
            // 
            this.m_btnUpdateTable.Location = new System.Drawing.Point(446, 155);
            this.m_btnUpdateTable.Name = "m_btnUpdateTable";
            this.m_btnUpdateTable.Size = new System.Drawing.Size(94, 23);
            this.m_btnUpdateTable.TabIndex = 11;
            this.m_btnUpdateTable.Text = "Update Table";
            this.m_btnUpdateTable.UseVisualStyleBackColor = true;
            this.m_btnUpdateTable.Click += new System.EventHandler(this.m_btnUpdateTable_Click);
            // 
            // PopupAltLedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 523);
            this.Controls.Add(this.m_btnUpdateTable);
            this.Controls.Add(this.m_btnSampleFill);
            this.Controls.Add(this.m_btnZeroFill);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_btnSet);
            this.Controls.Add(this.m_tbStartIndex);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_btnAutoRun);
            this.Controls.Add(this.m_rbDirect);
            this.Controls.Add(this.m_rbIndex);
            this.Controls.Add(this.m_gridTable);
            this.Controls.Add(this.groupBox1);
            this.Name = "PopupAltLedForm";
            this.Text = "ATL LED Control";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PopupAltLedForm_FormClosed);
            this.Load += new System.EventHandler(this.PopupAltLedForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_gridTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView m_gridTable;
        private System.Windows.Forms.RadioButton m_rbIndex;
        private System.Windows.Forms.RadioButton m_rbDirect;
        private System.Windows.Forms.CheckBox m_btnAutoRun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_tbStartIndex;
        private System.Windows.Forms.Button m_btnSet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button m_btnZeroFill;
        private System.Windows.Forms.Button m_btnSampleFill;
        private System.Windows.Forms.Button m_btnUpdateTable;
    }
}