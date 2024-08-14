<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PopupUserSetForm
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
        Me.m_btnSetDefault = New System.Windows.Forms.Button()
        Me.m_btnSave = New System.Windows.Forms.Button()
        Me.m_btnLoad = New System.Windows.Forms.Button()
        Me.m_cbUserSet = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'm_btnSetDefault
        '
        Me.m_btnSetDefault.Location = New System.Drawing.Point(13, 97)
        Me.m_btnSetDefault.Name = "m_btnSetDefault"
        Me.m_btnSetDefault.Size = New System.Drawing.Size(166, 23)
        Me.m_btnSetDefault.TabIndex = 7
        Me.m_btnSetDefault.Text = "Set Power On Default"
        Me.m_btnSetDefault.UseVisualStyleBackColor = True
        '
        'm_btnSave
        '
        Me.m_btnSave.Location = New System.Drawing.Point(13, 68)
        Me.m_btnSave.Name = "m_btnSave"
        Me.m_btnSave.Size = New System.Drawing.Size(166, 23)
        Me.m_btnSave.TabIndex = 6
        Me.m_btnSave.Text = "UserSet Save"
        Me.m_btnSave.UseVisualStyleBackColor = True
        '
        'm_btnLoad
        '
        Me.m_btnLoad.Location = New System.Drawing.Point(13, 39)
        Me.m_btnLoad.Name = "m_btnLoad"
        Me.m_btnLoad.Size = New System.Drawing.Size(166, 23)
        Me.m_btnLoad.TabIndex = 5
        Me.m_btnLoad.Text = "UserSet Load"
        Me.m_btnLoad.UseVisualStyleBackColor = True
        '
        'm_cbUserSet
        '
        Me.m_cbUserSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.m_cbUserSet.FormattingEnabled = True
        Me.m_cbUserSet.Location = New System.Drawing.Point(13, 13)
        Me.m_cbUserSet.Name = "m_cbUserSet"
        Me.m_cbUserSet.Size = New System.Drawing.Size(166, 20)
        Me.m_cbUserSet.TabIndex = 4
        '
        'PopupUserSetForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(192, 132)
        Me.Controls.Add(Me.m_btnSetDefault)
        Me.Controls.Add(Me.m_btnSave)
        Me.Controls.Add(Me.m_btnLoad)
        Me.Controls.Add(Me.m_cbUserSet)
        Me.Name = "PopupUserSetForm"
        Me.Text = "PopupUserSetForm"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents m_btnSetDefault As System.Windows.Forms.Button
    Private WithEvents m_btnSave As System.Windows.Forms.Button
    Private WithEvents m_btnLoad As System.Windows.Forms.Button
    Private WithEvents m_cbUserSet As System.Windows.Forms.ComboBox
End Class
