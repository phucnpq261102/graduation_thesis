<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PopupAutoFocusForm
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
        Me.m_btnOneStepBackward = New System.Windows.Forms.Button()
        Me.m_btnOneStepForward = New System.Windows.Forms.Button()
        Me.m_btnOnePush = New System.Windows.Forms.Button()
        Me.m_btnOriginal = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'm_btnOneStepBackward
        '
        Me.m_btnOneStepBackward.Location = New System.Drawing.Point(12, 99)
        Me.m_btnOneStepBackward.Name = "m_btnOneStepBackward"
        Me.m_btnOneStepBackward.Size = New System.Drawing.Size(194, 23)
        Me.m_btnOneStepBackward.TabIndex = 7
        Me.m_btnOneStepBackward.Text = "One-Step Backward"
        Me.m_btnOneStepBackward.UseVisualStyleBackColor = True
        '
        'm_btnOneStepForward
        '
        Me.m_btnOneStepForward.Location = New System.Drawing.Point(12, 70)
        Me.m_btnOneStepForward.Name = "m_btnOneStepForward"
        Me.m_btnOneStepForward.Size = New System.Drawing.Size(194, 23)
        Me.m_btnOneStepForward.TabIndex = 6
        Me.m_btnOneStepForward.Text = "One-Step Forward"
        Me.m_btnOneStepForward.UseVisualStyleBackColor = True
        '
        'm_btnOnePush
        '
        Me.m_btnOnePush.Location = New System.Drawing.Point(12, 41)
        Me.m_btnOnePush.Name = "m_btnOnePush"
        Me.m_btnOnePush.Size = New System.Drawing.Size(194, 23)
        Me.m_btnOnePush.TabIndex = 5
        Me.m_btnOnePush.Text = "One Push Auto"
        Me.m_btnOnePush.UseVisualStyleBackColor = True
        '
        'm_btnOriginal
        '
        Me.m_btnOriginal.Location = New System.Drawing.Point(12, 12)
        Me.m_btnOriginal.Name = "m_btnOriginal"
        Me.m_btnOriginal.Size = New System.Drawing.Size(194, 23)
        Me.m_btnOriginal.TabIndex = 4
        Me.m_btnOriginal.Text = "Origin Point"
        Me.m_btnOriginal.UseVisualStyleBackColor = True
        '
        'PopupAutoFocusForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(219, 134)
        Me.Controls.Add(Me.m_btnOneStepBackward)
        Me.Controls.Add(Me.m_btnOneStepForward)
        Me.Controls.Add(Me.m_btnOnePush)
        Me.Controls.Add(Me.m_btnOriginal)
        Me.Name = "PopupAutoFocusForm"
        Me.Text = "Auto Focus"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents m_btnOneStepBackward As System.Windows.Forms.Button
    Private WithEvents m_btnOneStepForward As System.Windows.Forms.Button
    Private WithEvents m_btnOnePush As System.Windows.Forms.Button
    Private WithEvents m_btnOriginal As System.Windows.Forms.Button
End Class
