<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PopupStackedROIForm
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
        Me.label9 = New System.Windows.Forms.Label()
        Me.label8 = New System.Windows.Forms.Label()
        Me.label7 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.m_tbHeight = New System.Windows.Forms.TextBox()
        Me.m_tbWidth = New System.Windows.Forms.TextBox()
        Me.m_tbOffsetY = New System.Windows.Forms.TextBox()
        Me.m_btnSetAllWidth = New System.Windows.Forms.Button()
        Me.m_tbOffsetX = New System.Windows.Forms.TextBox()
        Me.m_btnApply = New System.Windows.Forms.Button()
        Me.m_btnSetAllOffsetX = New System.Windows.Forms.Button()
        Me.m_cbROISelector = New System.Windows.Forms.ComboBox()
        Me.m_tbAllWidth = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label6 = New System.Windows.Forms.Label()
        Me.m_tbAllOffsetX = New System.Windows.Forms.TextBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.m_ckEnable = New System.Windows.Forms.CheckBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.m_ckControl = New System.Windows.Forms.CheckBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(57, 186)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(40, 12)
        Me.label9.TabIndex = 25
        Me.label9.Text = "Height"
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(62, 156)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(35, 12)
        Me.label8.TabIndex = 24
        Me.label8.Text = "Width"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(48, 126)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(49, 12)
        Me.label7.TabIndex = 23
        Me.label7.Text = "Offset Y"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(48, 95)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(49, 12)
        Me.label5.TabIndex = 22
        Me.label5.Text = "Offset X"
        '
        'm_tbHeight
        '
        Me.m_tbHeight.Location = New System.Drawing.Point(108, 177)
        Me.m_tbHeight.Name = "m_tbHeight"
        Me.m_tbHeight.Size = New System.Drawing.Size(100, 21)
        Me.m_tbHeight.TabIndex = 21
        '
        'm_tbWidth
        '
        Me.m_tbWidth.Location = New System.Drawing.Point(108, 147)
        Me.m_tbWidth.Name = "m_tbWidth"
        Me.m_tbWidth.Size = New System.Drawing.Size(100, 21)
        Me.m_tbWidth.TabIndex = 20
        '
        'm_tbOffsetY
        '
        Me.m_tbOffsetY.Location = New System.Drawing.Point(108, 117)
        Me.m_tbOffsetY.Name = "m_tbOffsetY"
        Me.m_tbOffsetY.Size = New System.Drawing.Size(100, 21)
        Me.m_tbOffsetY.TabIndex = 19
        '
        'm_btnSetAllWidth
        '
        Me.m_btnSetAllWidth.Location = New System.Drawing.Point(237, 74)
        Me.m_btnSetAllWidth.Name = "m_btnSetAllWidth"
        Me.m_btnSetAllWidth.Size = New System.Drawing.Size(75, 23)
        Me.m_btnSetAllWidth.TabIndex = 25
        Me.m_btnSetAllWidth.Text = "Set"
        Me.m_btnSetAllWidth.UseVisualStyleBackColor = True
        '
        'm_tbOffsetX
        '
        Me.m_tbOffsetX.Location = New System.Drawing.Point(108, 86)
        Me.m_tbOffsetX.Name = "m_tbOffsetX"
        Me.m_tbOffsetX.Size = New System.Drawing.Size(100, 21)
        Me.m_tbOffsetX.TabIndex = 18
        '
        'm_btnApply
        '
        Me.m_btnApply.Location = New System.Drawing.Point(133, 207)
        Me.m_btnApply.Name = "m_btnApply"
        Me.m_btnApply.Size = New System.Drawing.Size(75, 23)
        Me.m_btnApply.TabIndex = 12
        Me.m_btnApply.Text = "Apply"
        Me.m_btnApply.UseVisualStyleBackColor = True
        '
        'm_btnSetAllOffsetX
        '
        Me.m_btnSetAllOffsetX.Location = New System.Drawing.Point(237, 44)
        Me.m_btnSetAllOffsetX.Name = "m_btnSetAllOffsetX"
        Me.m_btnSetAllOffsetX.Size = New System.Drawing.Size(75, 23)
        Me.m_btnSetAllOffsetX.TabIndex = 24
        Me.m_btnSetAllOffsetX.Text = "Set"
        Me.m_btnSetAllOffsetX.UseVisualStyleBackColor = True
        '
        'm_cbROISelector
        '
        Me.m_cbROISelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.m_cbROISelector.FormattingEnabled = True
        Me.m_cbROISelector.Location = New System.Drawing.Point(108, 28)
        Me.m_cbROISelector.Name = "m_cbROISelector"
        Me.m_cbROISelector.Size = New System.Drawing.Size(100, 20)
        Me.m_cbROISelector.TabIndex = 3
        '
        'm_tbAllWidth
        '
        Me.m_tbAllWidth.Location = New System.Drawing.Point(120, 76)
        Me.m_tbAllWidth.Name = "m_tbAllWidth"
        Me.m_tbAllWidth.Size = New System.Drawing.Size(100, 21)
        Me.m_tbAllWidth.TabIndex = 23
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(37, 31)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(60, 12)
        Me.label4.TabIndex = 6
        Me.label4.Text = "ROI index"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(53, 62)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(44, 12)
        Me.label6.TabIndex = 9
        Me.label6.Text = "Enable"
        '
        'm_tbAllOffsetX
        '
        Me.m_tbAllOffsetX.Location = New System.Drawing.Point(120, 44)
        Me.m_tbAllOffsetX.Name = "m_tbAllOffsetX"
        Me.m_tbAllOffsetX.Size = New System.Drawing.Size(100, 21)
        Me.m_tbAllOffsetX.TabIndex = 22
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(56, 85)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(53, 12)
        Me.label3.TabIndex = 21
        Me.label3.Text = "All width"
        '
        'm_ckEnable
        '
        Me.m_ckEnable.AutoSize = True
        Me.m_ckEnable.Location = New System.Drawing.Point(108, 61)
        Me.m_ckEnable.Name = "m_ckEnable"
        Me.m_ckEnable.Size = New System.Drawing.Size(40, 16)
        Me.m_ckEnable.TabIndex = 18
        Me.m_ckEnable.Text = "On"
        Me.m_ckEnable.UseVisualStyleBackColor = True
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(44, 53)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(65, 12)
        Me.label2.TabIndex = 20
        Me.label2.Text = "All offset X"
        '
        'm_ckControl
        '
        Me.m_ckControl.AutoSize = True
        Me.m_ckControl.Location = New System.Drawing.Point(120, 14)
        Me.m_ckControl.Name = "m_ckControl"
        Me.m_ckControl.Size = New System.Drawing.Size(40, 16)
        Me.m_ckControl.TabIndex = 19
        Me.m_ckControl.Text = "On"
        Me.m_ckControl.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(64, 18)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(45, 12)
        Me.label1.TabIndex = 18
        Me.label1.Text = "Control"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.label9)
        Me.groupBox1.Controls.Add(Me.label8)
        Me.groupBox1.Controls.Add(Me.label7)
        Me.groupBox1.Controls.Add(Me.label5)
        Me.groupBox1.Controls.Add(Me.m_tbHeight)
        Me.groupBox1.Controls.Add(Me.m_tbWidth)
        Me.groupBox1.Controls.Add(Me.m_tbOffsetY)
        Me.groupBox1.Controls.Add(Me.m_tbOffsetX)
        Me.groupBox1.Controls.Add(Me.m_ckEnable)
        Me.groupBox1.Controls.Add(Me.label6)
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.m_cbROISelector)
        Me.groupBox1.Controls.Add(Me.m_btnApply)
        Me.groupBox1.Location = New System.Drawing.Point(12, 111)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(300, 247)
        Me.groupBox1.TabIndex = 26
        Me.groupBox1.TabStop = False
        '
        'PopupStackedROIForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 369)
        Me.Controls.Add(Me.m_btnSetAllWidth)
        Me.Controls.Add(Me.m_btnSetAllOffsetX)
        Me.Controls.Add(Me.m_tbAllWidth)
        Me.Controls.Add(Me.m_tbAllOffsetX)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.m_ckControl)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.groupBox1)
        Me.Name = "PopupStackedROIForm"
        Me.Text = "PopupStackedROIForm"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents m_tbHeight As System.Windows.Forms.TextBox
    Private WithEvents m_tbWidth As System.Windows.Forms.TextBox
    Private WithEvents m_tbOffsetY As System.Windows.Forms.TextBox
    Private WithEvents m_btnSetAllWidth As System.Windows.Forms.Button
    Private WithEvents m_tbOffsetX As System.Windows.Forms.TextBox
    Private WithEvents m_btnApply As System.Windows.Forms.Button
    Private WithEvents m_btnSetAllOffsetX As System.Windows.Forms.Button
    Private WithEvents m_cbROISelector As System.Windows.Forms.ComboBox
    Private WithEvents m_tbAllWidth As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents m_tbAllOffsetX As System.Windows.Forms.TextBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents m_ckEnable As System.Windows.Forms.CheckBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents m_ckControl As System.Windows.Forms.CheckBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
End Class
