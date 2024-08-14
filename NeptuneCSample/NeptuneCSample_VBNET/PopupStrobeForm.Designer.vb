<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PopupStrobeForm
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
        Me.m_btnApply = New System.Windows.Forms.Button()
        Me.m_stcDurationRange = New System.Windows.Forms.Label()
        Me.m_edStrobeDuration = New System.Windows.Forms.NumericUpDown()
        Me.label6 = New System.Windows.Forms.Label()
        Me.m_stcDelayRange = New System.Windows.Forms.Label()
        Me.m_edStrobeDelay = New System.Windows.Forms.NumericUpDown()
        Me.label4 = New System.Windows.Forms.Label()
        Me.m_cbStrobePolarity = New System.Windows.Forms.ComboBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.m_cbStrobeMode = New System.Windows.Forms.ComboBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.m_ckStrobeEnable = New System.Windows.Forms.CheckBox()
        Me.label1 = New System.Windows.Forms.Label()
        CType(Me.m_edStrobeDuration, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_edStrobeDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'm_btnApply
        '
        Me.m_btnApply.Location = New System.Drawing.Point(152, 183)
        Me.m_btnApply.Name = "m_btnApply"
        Me.m_btnApply.Size = New System.Drawing.Size(75, 23)
        Me.m_btnApply.TabIndex = 25
        Me.m_btnApply.Text = "Apply"
        Me.m_btnApply.UseVisualStyleBackColor = True
        '
        'm_stcDurationRange
        '
        Me.m_stcDurationRange.AutoSize = True
        Me.m_stcDurationRange.Location = New System.Drawing.Point(280, 146)
        Me.m_stcDurationRange.Name = "m_stcDurationRange"
        Me.m_stcDurationRange.Size = New System.Drawing.Size(78, 12)
        Me.m_stcDurationRange.TabIndex = 24
        Me.m_stcDurationRange.Text = "(Min ~ Max)"
        '
        'm_edStrobeDuration
        '
        Me.m_edStrobeDuration.Location = New System.Drawing.Point(148, 141)
        Me.m_edStrobeDuration.Name = "m_edStrobeDuration"
        Me.m_edStrobeDuration.Size = New System.Drawing.Size(120, 21)
        Me.m_edStrobeDuration.TabIndex = 23
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(15, 146)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(91, 12)
        Me.label6.TabIndex = 22
        Me.label6.Text = "Strobe Duration"
        '
        'm_stcDelayRange
        '
        Me.m_stcDelayRange.AutoSize = True
        Me.m_stcDelayRange.Location = New System.Drawing.Point(280, 114)
        Me.m_stcDelayRange.Name = "m_stcDelayRange"
        Me.m_stcDelayRange.Size = New System.Drawing.Size(78, 12)
        Me.m_stcDelayRange.TabIndex = 21
        Me.m_stcDelayRange.Text = "(Min ~ Max)"
        '
        'm_edStrobeDelay
        '
        Me.m_edStrobeDelay.Location = New System.Drawing.Point(148, 109)
        Me.m_edStrobeDelay.Name = "m_edStrobeDelay"
        Me.m_edStrobeDelay.Size = New System.Drawing.Size(120, 21)
        Me.m_edStrobeDelay.TabIndex = 20
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(15, 114)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(77, 12)
        Me.label4.TabIndex = 19
        Me.label4.Text = "Strobe Delay"
        '
        'm_cbStrobePolarity
        '
        Me.m_cbStrobePolarity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.m_cbStrobePolarity.FormattingEnabled = True
        Me.m_cbStrobePolarity.Location = New System.Drawing.Point(148, 77)
        Me.m_cbStrobePolarity.Name = "m_cbStrobePolarity"
        Me.m_cbStrobePolarity.Size = New System.Drawing.Size(121, 20)
        Me.m_cbStrobePolarity.TabIndex = 18
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(15, 82)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(87, 12)
        Me.label3.TabIndex = 17
        Me.label3.Text = "Strobe Polarity"
        '
        'm_cbStrobeMode
        '
        Me.m_cbStrobeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.m_cbStrobeMode.FormattingEnabled = True
        Me.m_cbStrobeMode.Location = New System.Drawing.Point(148, 45)
        Me.m_cbStrobeMode.Name = "m_cbStrobeMode"
        Me.m_cbStrobeMode.Size = New System.Drawing.Size(121, 20)
        Me.m_cbStrobeMode.TabIndex = 16
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(15, 50)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(77, 12)
        Me.label2.TabIndex = 15
        Me.label2.Text = "Strobe Mode"
        '
        'm_ckStrobeEnable
        '
        Me.m_ckStrobeEnable.AutoSize = True
        Me.m_ckStrobeEnable.Location = New System.Drawing.Point(148, 17)
        Me.m_ckStrobeEnable.Name = "m_ckStrobeEnable"
        Me.m_ckStrobeEnable.Size = New System.Drawing.Size(40, 16)
        Me.m_ckStrobeEnable.TabIndex = 14
        Me.m_ckStrobeEnable.Text = "On"
        Me.m_ckStrobeEnable.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(15, 18)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(84, 12)
        Me.label1.TabIndex = 13
        Me.label1.Text = "Strobe Enable"
        '
        'PopupStrobeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(372, 222)
        Me.Controls.Add(Me.m_btnApply)
        Me.Controls.Add(Me.m_stcDurationRange)
        Me.Controls.Add(Me.m_edStrobeDuration)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.m_stcDelayRange)
        Me.Controls.Add(Me.m_edStrobeDelay)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.m_cbStrobePolarity)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.m_cbStrobeMode)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.m_ckStrobeEnable)
        Me.Controls.Add(Me.label1)
        Me.Name = "PopupStrobeForm"
        Me.Text = "PopupStrobeForm"
        CType(Me.m_edStrobeDuration, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_edStrobeDelay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents m_btnApply As System.Windows.Forms.Button
    Private WithEvents m_stcDurationRange As System.Windows.Forms.Label
    Private WithEvents m_edStrobeDuration As System.Windows.Forms.NumericUpDown
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents m_stcDelayRange As System.Windows.Forms.Label
    Private WithEvents m_edStrobeDelay As System.Windows.Forms.NumericUpDown
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents m_cbStrobePolarity As System.Windows.Forms.ComboBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents m_cbStrobeMode As System.Windows.Forms.ComboBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents m_ckStrobeEnable As System.Windows.Forms.CheckBox
    Private WithEvents label1 As System.Windows.Forms.Label
End Class
