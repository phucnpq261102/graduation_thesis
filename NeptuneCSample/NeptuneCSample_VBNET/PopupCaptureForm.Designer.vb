<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PopupCaptureForm
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
        Me.m_btnStopRecord = New System.Windows.Forms.Button()
        Me.m_btnStartRecord = New System.Windows.Forms.Button()
        Me.m_wndFolderBrowser = New System.Windows.Forms.FolderBrowserDialog()
        Me.m_btnSaveImage = New System.Windows.Forms.Button()
        Me.m_btnBrowser = New System.Windows.Forms.Button()
        Me.m_cbImageForamt = New System.Windows.Forms.ComboBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.m_edSavePath = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'm_btnStopRecord
        '
        Me.m_btnStopRecord.Location = New System.Drawing.Point(332, 99)
        Me.m_btnStopRecord.Name = "m_btnStopRecord"
        Me.m_btnStopRecord.Size = New System.Drawing.Size(107, 23)
        Me.m_btnStopRecord.TabIndex = 15
        Me.m_btnStopRecord.Text = "Stop Record"
        Me.m_btnStopRecord.UseVisualStyleBackColor = True
        '
        'm_btnStartRecord
        '
        Me.m_btnStartRecord.Location = New System.Drawing.Point(219, 99)
        Me.m_btnStartRecord.Name = "m_btnStartRecord"
        Me.m_btnStartRecord.Size = New System.Drawing.Size(107, 23)
        Me.m_btnStartRecord.TabIndex = 14
        Me.m_btnStartRecord.Text = "Start Record"
        Me.m_btnStartRecord.UseVisualStyleBackColor = True
        '
        'm_btnSaveImage
        '
        Me.m_btnSaveImage.Location = New System.Drawing.Point(106, 99)
        Me.m_btnSaveImage.Name = "m_btnSaveImage"
        Me.m_btnSaveImage.Size = New System.Drawing.Size(107, 23)
        Me.m_btnSaveImage.TabIndex = 13
        Me.m_btnSaveImage.Text = "Save Image"
        Me.m_btnSaveImage.UseVisualStyleBackColor = True
        '
        'm_btnBrowser
        '
        Me.m_btnBrowser.Location = New System.Drawing.Point(497, 16)
        Me.m_btnBrowser.Name = "m_btnBrowser"
        Me.m_btnBrowser.Size = New System.Drawing.Size(33, 23)
        Me.m_btnBrowser.TabIndex = 12
        Me.m_btnBrowser.Text = "..."
        Me.m_btnBrowser.UseVisualStyleBackColor = True
        '
        'm_cbImageForamt
        '
        Me.m_cbImageForamt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.m_cbImageForamt.FormattingEnabled = True
        Me.m_cbImageForamt.Location = New System.Drawing.Point(119, 49)
        Me.m_cbImageForamt.Name = "m_cbImageForamt"
        Me.m_cbImageForamt.Size = New System.Drawing.Size(121, 20)
        Me.m_cbImageForamt.TabIndex = 11
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(14, 54)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(83, 12)
        Me.label2.TabIndex = 10
        Me.label2.Text = "Image Format"
        '
        'm_edSavePath
        '
        Me.m_edSavePath.Location = New System.Drawing.Point(119, 17)
        Me.m_edSavePath.Name = "m_edSavePath"
        Me.m_edSavePath.ReadOnly = True
        Me.m_edSavePath.Size = New System.Drawing.Size(372, 21)
        Me.m_edSavePath.TabIndex = 9
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(14, 22)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(62, 12)
        Me.label1.TabIndex = 8
        Me.label1.Text = "Save Path"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(117, 80)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(223, 12)
        Me.label3.TabIndex = 16
        Me.label3.Text = "* AVI Max Resolution: 4k (4096 x 2160)"
        '
        'PopupCaptureForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(545, 134)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.m_btnStopRecord)
        Me.Controls.Add(Me.m_btnStartRecord)
        Me.Controls.Add(Me.m_btnSaveImage)
        Me.Controls.Add(Me.m_btnBrowser)
        Me.Controls.Add(Me.m_cbImageForamt)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.m_edSavePath)
        Me.Controls.Add(Me.label1)
        Me.Name = "PopupCaptureForm"
        Me.Text = "PopupCaptureForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents m_btnStopRecord As System.Windows.Forms.Button
    Private WithEvents m_btnStartRecord As System.Windows.Forms.Button
    Private WithEvents m_wndFolderBrowser As System.Windows.Forms.FolderBrowserDialog
    Private WithEvents m_btnSaveImage As System.Windows.Forms.Button
    Private WithEvents m_btnBrowser As System.Windows.Forms.Button
    Private WithEvents m_cbImageForamt As System.Windows.Forms.ComboBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents m_edSavePath As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
End Class
