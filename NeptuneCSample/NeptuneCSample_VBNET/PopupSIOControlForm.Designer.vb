<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PopupSIOControlForm
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
        Me.label6 = New System.Windows.Forms.Label()
        Me.m_btnReceive = New System.Windows.Forms.Button()
        Me.m_btnSend = New System.Windows.Forms.Button()
        Me.m_edData = New System.Windows.Forms.TextBox()
        Me.m_btnApply = New System.Windows.Forms.Button()
        Me.m_ckEnable = New System.Windows.Forms.CheckBox()
        Me.label5 = New System.Windows.Forms.Label()
        Me.m_cbStopBits = New System.Windows.Forms.ComboBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.m_cbDataBits = New System.Windows.Forms.ComboBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.m_cbParityBits = New System.Windows.Forms.ComboBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.m_cbBaudRate = New System.Windows.Forms.ComboBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(15, 224)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(30, 12)
        Me.label6.TabIndex = 26
        Me.label6.Text = "Data"
        '
        'm_btnReceive
        '
        Me.m_btnReceive.Location = New System.Drawing.Point(148, 303)
        Me.m_btnReceive.Name = "m_btnReceive"
        Me.m_btnReceive.Size = New System.Drawing.Size(125, 23)
        Me.m_btnReceive.TabIndex = 29
        Me.m_btnReceive.Text = "Receive Data (RX)"
        Me.m_btnReceive.UseVisualStyleBackColor = True
        '
        'm_btnSend
        '
        Me.m_btnSend.Location = New System.Drawing.Point(17, 303)
        Me.m_btnSend.Name = "m_btnSend"
        Me.m_btnSend.Size = New System.Drawing.Size(125, 23)
        Me.m_btnSend.TabIndex = 28
        Me.m_btnSend.Text = "Send Data (TX)"
        Me.m_btnSend.UseVisualStyleBackColor = True
        '
        'm_edData
        '
        Me.m_edData.Location = New System.Drawing.Point(74, 221)
        Me.m_edData.Multiline = True
        Me.m_edData.Name = "m_edData"
        Me.m_edData.Size = New System.Drawing.Size(199, 76)
        Me.m_edData.TabIndex = 27
        '
        'm_btnApply
        '
        Me.m_btnApply.Location = New System.Drawing.Point(198, 175)
        Me.m_btnApply.Name = "m_btnApply"
        Me.m_btnApply.Size = New System.Drawing.Size(75, 23)
        Me.m_btnApply.TabIndex = 25
        Me.m_btnApply.Text = "Apply"
        Me.m_btnApply.UseVisualStyleBackColor = True
        '
        'm_ckEnable
        '
        Me.m_ckEnable.AutoSize = True
        Me.m_ckEnable.Location = New System.Drawing.Point(152, 15)
        Me.m_ckEnable.Name = "m_ckEnable"
        Me.m_ckEnable.Size = New System.Drawing.Size(40, 16)
        Me.m_ckEnable.TabIndex = 16
        Me.m_ckEnable.Text = "On"
        Me.m_ckEnable.UseVisualStyleBackColor = True
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(15, 18)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(44, 12)
        Me.label5.TabIndex = 15
        Me.label5.Text = "Enable"
        '
        'm_cbStopBits
        '
        Me.m_cbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.m_cbStopBits.FormattingEnabled = True
        Me.m_cbStopBits.Location = New System.Drawing.Point(152, 140)
        Me.m_cbStopBits.Name = "m_cbStopBits"
        Me.m_cbStopBits.Size = New System.Drawing.Size(121, 20)
        Me.m_cbStopBits.TabIndex = 24
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(15, 146)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(55, 12)
        Me.label4.TabIndex = 23
        Me.label4.Text = "Stop Bits"
        '
        'm_cbDataBits
        '
        Me.m_cbDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.m_cbDataBits.FormattingEnabled = True
        Me.m_cbDataBits.Location = New System.Drawing.Point(152, 108)
        Me.m_cbDataBits.Name = "m_cbDataBits"
        Me.m_cbDataBits.Size = New System.Drawing.Size(121, 20)
        Me.m_cbDataBits.TabIndex = 22
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(15, 114)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(55, 12)
        Me.label3.TabIndex = 21
        Me.label3.Text = "Data Bits"
        '
        'm_cbParityBits
        '
        Me.m_cbParityBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.m_cbParityBits.FormattingEnabled = True
        Me.m_cbParityBits.Location = New System.Drawing.Point(152, 76)
        Me.m_cbParityBits.Name = "m_cbParityBits"
        Me.m_cbParityBits.Size = New System.Drawing.Size(121, 20)
        Me.m_cbParityBits.TabIndex = 20
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(15, 82)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(62, 12)
        Me.label2.TabIndex = 19
        Me.label2.Text = "Parity Bits"
        '
        'm_cbBaudRate
        '
        Me.m_cbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.m_cbBaudRate.FormattingEnabled = True
        Me.m_cbBaudRate.Location = New System.Drawing.Point(152, 44)
        Me.m_cbBaudRate.Name = "m_cbBaudRate"
        Me.m_cbBaudRate.Size = New System.Drawing.Size(121, 20)
        Me.m_cbBaudRate.TabIndex = 18
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(15, 50)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(63, 12)
        Me.label1.TabIndex = 17
        Me.label1.Text = "Baud Rate"
        '
        'PopupSIOControlForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(289, 340)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.m_btnReceive)
        Me.Controls.Add(Me.m_btnSend)
        Me.Controls.Add(Me.m_edData)
        Me.Controls.Add(Me.m_btnApply)
        Me.Controls.Add(Me.m_ckEnable)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.m_cbStopBits)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.m_cbDataBits)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.m_cbParityBits)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.m_cbBaudRate)
        Me.Controls.Add(Me.label1)
        Me.Name = "PopupSIOControlForm"
        Me.Text = "PopupSIOControlForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents m_btnReceive As System.Windows.Forms.Button
    Private WithEvents m_btnSend As System.Windows.Forms.Button
    Private WithEvents m_edData As System.Windows.Forms.TextBox
    Private WithEvents m_btnApply As System.Windows.Forms.Button
    Private WithEvents m_ckEnable As System.Windows.Forms.CheckBox
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents m_cbStopBits As System.Windows.Forms.ComboBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents m_cbDataBits As System.Windows.Forms.ComboBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents m_cbParityBits As System.Windows.Forms.ComboBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents m_cbBaudRate As System.Windows.Forms.ComboBox
    Private WithEvents label1 As System.Windows.Forms.Label
End Class
