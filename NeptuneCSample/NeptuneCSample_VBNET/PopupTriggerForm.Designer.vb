<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PopupTriggerForm
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
        Me.m_stcParamRange = New System.Windows.Forms.Label()
        Me.m_btnApply = New System.Windows.Forms.Button()
        Me.m_btnSWTrigger = New System.Windows.Forms.Button()
        Me.m_edTriggerParam = New System.Windows.Forms.NumericUpDown()
        Me.label5 = New System.Windows.Forms.Label()
        Me.m_cbTriggerPolarity = New System.Windows.Forms.ComboBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.m_cbTriggerSource = New System.Windows.Forms.ComboBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.m_cbTriggerMode = New System.Windows.Forms.ComboBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.m_ckTriggerEnable = New System.Windows.Forms.CheckBox()
        Me.label1 = New System.Windows.Forms.Label()
        CType(Me.m_edTriggerParam, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'm_stcParamRange
        '
        Me.m_stcParamRange.AutoSize = True
        Me.m_stcParamRange.Location = New System.Drawing.Point(285, 145)
        Me.m_stcParamRange.Name = "m_stcParamRange"
        Me.m_stcParamRange.Size = New System.Drawing.Size(78, 12)
        Me.m_stcParamRange.TabIndex = 30
        Me.m_stcParamRange.Text = "(Min ~ Max)"
        '
        'm_btnApply
        '
        Me.m_btnApply.Location = New System.Drawing.Point(174, 181)
        Me.m_btnApply.Name = "m_btnApply"
        Me.m_btnApply.Size = New System.Drawing.Size(75, 23)
        Me.m_btnApply.TabIndex = 31
        Me.m_btnApply.Text = "Apply"
        Me.m_btnApply.UseVisualStyleBackColor = True
        '
        'm_btnSWTrigger
        '
        Me.m_btnSWTrigger.Location = New System.Drawing.Point(287, 75)
        Me.m_btnSWTrigger.Name = "m_btnSWTrigger"
        Me.m_btnSWTrigger.Size = New System.Drawing.Size(118, 23)
        Me.m_btnSWTrigger.TabIndex = 25
        Me.m_btnSWTrigger.Text = "Run S/W Trigger"
        Me.m_btnSWTrigger.UseVisualStyleBackColor = True
        '
        'm_edTriggerParam
        '
        Me.m_edTriggerParam.Location = New System.Drawing.Point(148, 141)
        Me.m_edTriggerParam.Name = "m_edTriggerParam"
        Me.m_edTriggerParam.Size = New System.Drawing.Size(120, 21)
        Me.m_edTriggerParam.TabIndex = 29
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(14, 145)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(107, 12)
        Me.label5.TabIndex = 28
        Me.label5.Text = "Trigger Parameter"
        '
        'm_cbTriggerPolarity
        '
        Me.m_cbTriggerPolarity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.m_cbTriggerPolarity.FormattingEnabled = True
        Me.m_cbTriggerPolarity.Location = New System.Drawing.Point(147, 108)
        Me.m_cbTriggerPolarity.Name = "m_cbTriggerPolarity"
        Me.m_cbTriggerPolarity.Size = New System.Drawing.Size(121, 20)
        Me.m_cbTriggerPolarity.TabIndex = 27
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(14, 113)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(91, 12)
        Me.label4.TabIndex = 26
        Me.label4.Text = "Trigger Polarity"
        '
        'm_cbTriggerSource
        '
        Me.m_cbTriggerSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.m_cbTriggerSource.FormattingEnabled = True
        Me.m_cbTriggerSource.Location = New System.Drawing.Point(147, 76)
        Me.m_cbTriggerSource.Name = "m_cbTriggerSource"
        Me.m_cbTriggerSource.Size = New System.Drawing.Size(121, 20)
        Me.m_cbTriggerSource.TabIndex = 24
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(14, 81)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(89, 12)
        Me.label3.TabIndex = 23
        Me.label3.Text = "Trigger Source"
        '
        'm_cbTriggerMode
        '
        Me.m_cbTriggerMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.m_cbTriggerMode.FormattingEnabled = True
        Me.m_cbTriggerMode.Location = New System.Drawing.Point(147, 44)
        Me.m_cbTriggerMode.Name = "m_cbTriggerMode"
        Me.m_cbTriggerMode.Size = New System.Drawing.Size(121, 20)
        Me.m_cbTriggerMode.TabIndex = 22
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(14, 49)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(81, 12)
        Me.label2.TabIndex = 21
        Me.label2.Text = "Trigger Mode"
        '
        'm_ckTriggerEnable
        '
        Me.m_ckTriggerEnable.AutoSize = True
        Me.m_ckTriggerEnable.Location = New System.Drawing.Point(147, 16)
        Me.m_ckTriggerEnable.Name = "m_ckTriggerEnable"
        Me.m_ckTriggerEnable.Size = New System.Drawing.Size(40, 16)
        Me.m_ckTriggerEnable.TabIndex = 20
        Me.m_ckTriggerEnable.Text = "On"
        Me.m_ckTriggerEnable.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(14, 17)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(88, 12)
        Me.label1.TabIndex = 19
        Me.label1.Text = "Trigger Enable"
        '
        'PopupTriggerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 220)
        Me.Controls.Add(Me.m_stcParamRange)
        Me.Controls.Add(Me.m_btnApply)
        Me.Controls.Add(Me.m_btnSWTrigger)
        Me.Controls.Add(Me.m_edTriggerParam)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.m_cbTriggerPolarity)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.m_cbTriggerSource)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.m_cbTriggerMode)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.m_ckTriggerEnable)
        Me.Controls.Add(Me.label1)
        Me.Name = "PopupTriggerForm"
        Me.Text = "PopupTriggerForm"
        CType(Me.m_edTriggerParam, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents m_stcParamRange As System.Windows.Forms.Label
    Private WithEvents m_btnApply As System.Windows.Forms.Button
    Private WithEvents m_btnSWTrigger As System.Windows.Forms.Button
    Private WithEvents m_edTriggerParam As System.Windows.Forms.NumericUpDown
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents m_cbTriggerPolarity As System.Windows.Forms.ComboBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents m_cbTriggerSource As System.Windows.Forms.ComboBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents m_cbTriggerMode As System.Windows.Forms.ComboBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents m_ckTriggerEnable As System.Windows.Forms.CheckBox
    Private WithEvents label1 As System.Windows.Forms.Label
End Class
