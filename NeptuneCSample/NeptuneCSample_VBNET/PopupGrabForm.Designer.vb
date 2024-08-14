<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PopupGrabForm
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
        Me.m_btnGrab = New System.Windows.Forms.Button()
        Me.m_btnBrowser = New System.Windows.Forms.Button()
        Me.m_edSavePath = New System.Windows.Forms.TextBox()
        Me.m_wndFolderBrowser = New System.Windows.Forms.FolderBrowserDialog()
        Me.label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'm_btnGrab
        '
        Me.m_btnGrab.Location = New System.Drawing.Point(223, 53)
        Me.m_btnGrab.Name = "m_btnGrab"
        Me.m_btnGrab.Size = New System.Drawing.Size(102, 23)
        Me.m_btnGrab.TabIndex = 12
        Me.m_btnGrab.Text = "Grab Image"
        Me.m_btnGrab.UseVisualStyleBackColor = True
        '
        'm_btnBrowser
        '
        Me.m_btnBrowser.Location = New System.Drawing.Point(497, 12)
        Me.m_btnBrowser.Name = "m_btnBrowser"
        Me.m_btnBrowser.Size = New System.Drawing.Size(33, 23)
        Me.m_btnBrowser.TabIndex = 11
        Me.m_btnBrowser.Text = "..."
        Me.m_btnBrowser.UseVisualStyleBackColor = True
        '
        'm_edSavePath
        '
        Me.m_edSavePath.Location = New System.Drawing.Point(119, 13)
        Me.m_edSavePath.Name = "m_edSavePath"
        Me.m_edSavePath.ReadOnly = True
        Me.m_edSavePath.Size = New System.Drawing.Size(372, 21)
        Me.m_edSavePath.TabIndex = 10
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(14, 18)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(62, 12)
        Me.label1.TabIndex = 9
        Me.label1.Text = "Save Path"
        '
        'PopupGrabForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(545, 89)
        Me.Controls.Add(Me.m_btnGrab)
        Me.Controls.Add(Me.m_btnBrowser)
        Me.Controls.Add(Me.m_edSavePath)
        Me.Controls.Add(Me.label1)
        Me.Name = "PopupGrabForm"
        Me.Text = "PopupGrabForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents m_btnGrab As System.Windows.Forms.Button
    Private WithEvents m_btnBrowser As System.Windows.Forms.Button
    Private WithEvents m_edSavePath As System.Windows.Forms.TextBox
    Private WithEvents m_wndFolderBrowser As System.Windows.Forms.FolderBrowserDialog
    Private WithEvents label1 As System.Windows.Forms.Label
End Class
