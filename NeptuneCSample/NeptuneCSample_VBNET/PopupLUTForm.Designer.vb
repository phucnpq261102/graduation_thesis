<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PopupLUTForm
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.m_btnApplyLUT = New System.Windows.Forms.Button()
        Me.m_wndGraph = New System.Windows.Forms.PictureBox()
        Me.m_ckEnableUserLUT = New System.Windows.Forms.CheckBox()
        Me.m_btnLinearLUT = New System.Windows.Forms.Button()
        Me.label8 = New System.Windows.Forms.Label()
        Me.m_edPointY4 = New System.Windows.Forms.NumericUpDown()
        Me.label10 = New System.Windows.Forms.Label()
        Me.label7 = New System.Windows.Forms.Label()
        Me.m_cbUserLUT = New System.Windows.Forms.ComboBox()
        Me.m_edPointX4 = New System.Windows.Forms.NumericUpDown()
        Me.m_edPointY3 = New System.Windows.Forms.NumericUpDown()
        Me.m_btnSaveUserLUT = New System.Windows.Forms.Button()
        Me.m_edPointX3 = New System.Windows.Forms.NumericUpDown()
        Me.label11 = New System.Windows.Forms.Label()
        Me.label6 = New System.Windows.Forms.Label()
        Me.label12 = New System.Windows.Forms.Label()
        Me.m_edPointY2 = New System.Windows.Forms.NumericUpDown()
        Me.m_edPointX2 = New System.Windows.Forms.NumericUpDown()
        Me.label9 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.m_edPointY1 = New System.Windows.Forms.NumericUpDown()
        Me.m_edPointX1 = New System.Windows.Forms.NumericUpDown()
        Me.label4 = New System.Windows.Forms.Label()
        Me.m_btnApplyUserLUT = New System.Windows.Forms.Button()
        Me.label3 = New System.Windows.Forms.Label()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.m_ckEnableLUT = New System.Windows.Forms.CheckBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.m_wndFileBrowser = New System.Windows.Forms.OpenFileDialog()
        CType(Me.m_wndGraph, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_edPointY4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_edPointX4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_edPointY3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_edPointX3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_edPointY2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_edPointX2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_edPointY1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_edPointX1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox1.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'm_btnApplyLUT
        '
        Me.m_btnApplyLUT.Location = New System.Drawing.Point(138, 176)
        Me.m_btnApplyLUT.Name = "m_btnApplyLUT"
        Me.m_btnApplyLUT.Size = New System.Drawing.Size(53, 23)
        Me.m_btnApplyLUT.TabIndex = 17
        Me.m_btnApplyLUT.Text = "Apply"
        Me.m_btnApplyLUT.UseVisualStyleBackColor = True
        '
        'm_wndGraph
        '
        Me.m_wndGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.m_wndGraph.Location = New System.Drawing.Point(44, 10)
        Me.m_wndGraph.Name = "m_wndGraph"
        Me.m_wndGraph.Size = New System.Drawing.Size(300, 300)
        Me.m_wndGraph.TabIndex = 6
        Me.m_wndGraph.TabStop = False
        '
        'm_ckEnableUserLUT
        '
        Me.m_ckEnableUserLUT.AutoSize = True
        Me.m_ckEnableUserLUT.Location = New System.Drawing.Point(79, 23)
        Me.m_ckEnableUserLUT.Name = "m_ckEnableUserLUT"
        Me.m_ckEnableUserLUT.Size = New System.Drawing.Size(40, 16)
        Me.m_ckEnableUserLUT.TabIndex = 1
        Me.m_ckEnableUserLUT.Text = "On"
        Me.m_ckEnableUserLUT.UseVisualStyleBackColor = True
        '
        'm_btnLinearLUT
        '
        Me.m_btnLinearLUT.Location = New System.Drawing.Point(14, 176)
        Me.m_btnLinearLUT.Name = "m_btnLinearLUT"
        Me.m_btnLinearLUT.Size = New System.Drawing.Size(118, 23)
        Me.m_btnLinearLUT.TabIndex = 16
        Me.m_btnLinearLUT.Text = "Set to Linear"
        Me.m_btnLinearLUT.UseVisualStyleBackColor = True
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(12, 24)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(44, 12)
        Me.label8.TabIndex = 0
        Me.label8.Text = "Enable"
        '
        'm_edPointY4
        '
        Me.m_edPointY4.Location = New System.Drawing.Point(138, 149)
        Me.m_edPointY4.Name = "m_edPointY4"
        Me.m_edPointY4.Size = New System.Drawing.Size(53, 21)
        Me.m_edPointY4.TabIndex = 15
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Location = New System.Drawing.Point(9, 10)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(29, 12)
        Me.label10.TabIndex = 8
        Me.label10.Text = "4095"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(12, 154)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(39, 12)
        Me.label7.TabIndex = 13
        Me.label7.Text = "Point4"
        '
        'm_cbUserLUT
        '
        Me.m_cbUserLUT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.m_cbUserLUT.FormattingEnabled = True
        Me.m_cbUserLUT.Location = New System.Drawing.Point(79, 45)
        Me.m_cbUserLUT.Name = "m_cbUserLUT"
        Me.m_cbUserLUT.Size = New System.Drawing.Size(112, 20)
        Me.m_cbUserLUT.TabIndex = 3
        '
        'm_edPointX4
        '
        Me.m_edPointX4.Location = New System.Drawing.Point(79, 149)
        Me.m_edPointX4.Name = "m_edPointX4"
        Me.m_edPointX4.Size = New System.Drawing.Size(53, 21)
        Me.m_edPointX4.TabIndex = 14
        '
        'm_edPointY3
        '
        Me.m_edPointY3.Location = New System.Drawing.Point(138, 122)
        Me.m_edPointY3.Name = "m_edPointY3"
        Me.m_edPointY3.Size = New System.Drawing.Size(53, 21)
        Me.m_edPointY3.TabIndex = 12
        '
        'm_btnSaveUserLUT
        '
        Me.m_btnSaveUserLUT.Location = New System.Drawing.Point(14, 71)
        Me.m_btnSaveUserLUT.Name = "m_btnSaveUserLUT"
        Me.m_btnSaveUserLUT.Size = New System.Drawing.Size(118, 23)
        Me.m_btnSaveUserLUT.TabIndex = 4
        Me.m_btnSaveUserLUT.Text = "SaveData in Index"
        Me.m_btnSaveUserLUT.UseVisualStyleBackColor = True
        '
        'm_edPointX3
        '
        Me.m_edPointX3.Location = New System.Drawing.Point(79, 122)
        Me.m_edPointX3.Name = "m_edPointX3"
        Me.m_edPointX3.Size = New System.Drawing.Size(53, 21)
        Me.m_edPointX3.TabIndex = 11
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(27, 320)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(11, 12)
        Me.label11.TabIndex = 9
        Me.label11.Text = "0"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(12, 127)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(39, 12)
        Me.label6.TabIndex = 10
        Me.label6.Text = "Point3"
        '
        'label12
        '
        Me.label12.AutoSize = True
        Me.label12.Location = New System.Drawing.Point(315, 320)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(29, 12)
        Me.label12.TabIndex = 10
        Me.label12.Text = "4095"
        '
        'm_edPointY2
        '
        Me.m_edPointY2.Location = New System.Drawing.Point(138, 95)
        Me.m_edPointY2.Name = "m_edPointY2"
        Me.m_edPointY2.Size = New System.Drawing.Size(53, 21)
        Me.m_edPointY2.TabIndex = 9
        '
        'm_edPointX2
        '
        Me.m_edPointX2.Location = New System.Drawing.Point(79, 95)
        Me.m_edPointX2.Name = "m_edPointX2"
        Me.m_edPointX2.Size = New System.Drawing.Size(53, 21)
        Me.m_edPointX2.TabIndex = 8
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(12, 49)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(63, 12)
        Me.label9.TabIndex = 2
        Me.label9.Text = "LUT Index"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(12, 100)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(39, 12)
        Me.label5.TabIndex = 7
        Me.label5.Text = "Point2"
        '
        'm_edPointY1
        '
        Me.m_edPointY1.Location = New System.Drawing.Point(138, 68)
        Me.m_edPointY1.Name = "m_edPointY1"
        Me.m_edPointY1.Size = New System.Drawing.Size(53, 21)
        Me.m_edPointY1.TabIndex = 6
        '
        'm_edPointX1
        '
        Me.m_edPointX1.Location = New System.Drawing.Point(79, 68)
        Me.m_edPointX1.Name = "m_edPointX1"
        Me.m_edPointX1.Size = New System.Drawing.Size(53, 21)
        Me.m_edPointX1.TabIndex = 5
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(12, 73)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(39, 12)
        Me.label4.TabIndex = 4
        Me.label4.Text = "Point1"
        '
        'm_btnApplyUserLUT
        '
        Me.m_btnApplyUserLUT.Location = New System.Drawing.Point(138, 71)
        Me.m_btnApplyUserLUT.Name = "m_btnApplyUserLUT"
        Me.m_btnApplyUserLUT.Size = New System.Drawing.Size(53, 23)
        Me.m_btnApplyUserLUT.TabIndex = 5
        Me.m_btnApplyUserLUT.Text = "Apply"
        Me.m_btnApplyUserLUT.UseVisualStyleBackColor = True
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(154, 48)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(13, 12)
        Me.label3.TabIndex = 3
        Me.label3.Text = "Y"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.m_btnApplyLUT)
        Me.groupBox1.Controls.Add(Me.m_btnLinearLUT)
        Me.groupBox1.Controls.Add(Me.m_edPointY4)
        Me.groupBox1.Controls.Add(Me.m_edPointX4)
        Me.groupBox1.Controls.Add(Me.label7)
        Me.groupBox1.Controls.Add(Me.m_edPointY3)
        Me.groupBox1.Controls.Add(Me.m_edPointX3)
        Me.groupBox1.Controls.Add(Me.label6)
        Me.groupBox1.Controls.Add(Me.m_edPointY2)
        Me.groupBox1.Controls.Add(Me.m_edPointX2)
        Me.groupBox1.Controls.Add(Me.label5)
        Me.groupBox1.Controls.Add(Me.m_edPointY1)
        Me.groupBox1.Controls.Add(Me.m_edPointX1)
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.m_ckEnableLUT)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Location = New System.Drawing.Point(350, 10)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(207, 210)
        Me.groupBox1.TabIndex = 5
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "4Step LUT"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(97, 48)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(13, 12)
        Me.label2.TabIndex = 2
        Me.label2.Text = "X"
        '
        'm_ckEnableLUT
        '
        Me.m_ckEnableLUT.AutoSize = True
        Me.m_ckEnableLUT.Location = New System.Drawing.Point(79, 23)
        Me.m_ckEnableLUT.Name = "m_ckEnableLUT"
        Me.m_ckEnableLUT.Size = New System.Drawing.Size(40, 16)
        Me.m_ckEnableLUT.TabIndex = 1
        Me.m_ckEnableLUT.Text = "On"
        Me.m_ckEnableLUT.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 24)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(44, 12)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Enable"
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.m_btnApplyUserLUT)
        Me.groupBox2.Controls.Add(Me.label9)
        Me.groupBox2.Controls.Add(Me.m_btnSaveUserLUT)
        Me.groupBox2.Controls.Add(Me.m_cbUserLUT)
        Me.groupBox2.Controls.Add(Me.m_ckEnableUserLUT)
        Me.groupBox2.Controls.Add(Me.label8)
        Me.groupBox2.Location = New System.Drawing.Point(350, 226)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(207, 106)
        Me.groupBox2.TabIndex = 7
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "User LUT"
        '
        'm_wndFileBrowser
        '
        Me.m_wndFileBrowser.Filter = "Data Files (*.dat)|*.dat|All Files (*.*)|*.*||"
        '
        'PopupLUTForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(566, 343)
        Me.Controls.Add(Me.m_wndGraph)
        Me.Controls.Add(Me.label10)
        Me.Controls.Add(Me.label11)
        Me.Controls.Add(Me.label12)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.groupBox2)
        Me.Name = "PopupLUTForm"
        Me.Text = "PopupLUTForm"
        CType(Me.m_wndGraph, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_edPointY4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_edPointX4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_edPointY3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_edPointX3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_edPointY2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_edPointX2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_edPointY1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_edPointX1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents m_btnApplyLUT As System.Windows.Forms.Button
    Private WithEvents m_wndGraph As System.Windows.Forms.PictureBox
    Private WithEvents m_ckEnableUserLUT As System.Windows.Forms.CheckBox
    Private WithEvents m_btnLinearLUT As System.Windows.Forms.Button
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents m_edPointY4 As System.Windows.Forms.NumericUpDown
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents m_cbUserLUT As System.Windows.Forms.ComboBox
    Private WithEvents m_edPointX4 As System.Windows.Forms.NumericUpDown
    Private WithEvents m_edPointY3 As System.Windows.Forms.NumericUpDown
    Private WithEvents m_btnSaveUserLUT As System.Windows.Forms.Button
    Private WithEvents m_edPointX3 As System.Windows.Forms.NumericUpDown
    Private WithEvents label11 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents label12 As System.Windows.Forms.Label
    Private WithEvents m_edPointY2 As System.Windows.Forms.NumericUpDown
    Private WithEvents m_edPointX2 As System.Windows.Forms.NumericUpDown
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents m_edPointY1 As System.Windows.Forms.NumericUpDown
    Private WithEvents m_edPointX1 As System.Windows.Forms.NumericUpDown
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents m_btnApplyUserLUT As System.Windows.Forms.Button
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents m_ckEnableLUT As System.Windows.Forms.CheckBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents m_wndFileBrowser As System.Windows.Forms.OpenFileDialog
End Class
