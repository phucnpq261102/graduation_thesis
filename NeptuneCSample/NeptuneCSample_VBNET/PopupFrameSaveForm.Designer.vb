<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PopupFrameSaveForm
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
        Me.m_btnPlay = New System.Windows.Forms.Button()
        Me.m_edRecvCount = New System.Windows.Forms.NumericUpDown()
        Me.label3 = New System.Windows.Forms.Label()
        Me.m_btnRefresh = New System.Windows.Forms.Button()
        Me.m_edRemained = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.m_ckEnable = New System.Windows.Forms.CheckBox()
        Me.label1 = New System.Windows.Forms.Label()
        CType(Me.m_edRecvCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'm_btnPlay
        '
        Me.m_btnPlay.Location = New System.Drawing.Point(319, 75)
        Me.m_btnPlay.Name = "m_btnPlay"
        Me.m_btnPlay.Size = New System.Drawing.Size(25, 22)
        Me.m_btnPlay.TabIndex = 15
        Me.m_btnPlay.Text = ">"
        Me.m_btnPlay.UseVisualStyleBackColor = True
        '
        'm_edRecvCount
        '
        Me.m_edRecvCount.Location = New System.Drawing.Point(233, 75)
        Me.m_edRecvCount.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.m_edRecvCount.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.m_edRecvCount.Name = "m_edRecvCount"
        Me.m_edRecvCount.Size = New System.Drawing.Size(80, 21)
        Me.m_edRecvCount.TabIndex = 14
        Me.m_edRecvCount.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(13, 79)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(183, 12)
        Me.label3.TabIndex = 13
        Me.label3.Text = "Receive Image (Camera to PC)"
        '
        'm_btnRefresh
        '
        Me.m_btnRefresh.Location = New System.Drawing.Point(319, 44)
        Me.m_btnRefresh.Name = "m_btnRefresh"
        Me.m_btnRefresh.Size = New System.Drawing.Size(25, 22)
        Me.m_btnRefresh.TabIndex = 12
        Me.m_btnRefresh.UseVisualStyleBackColor = True
        '
        'm_edRemained
        '
        Me.m_edRemained.Location = New System.Drawing.Point(233, 44)
        Me.m_edRemained.Name = "m_edRemained"
        Me.m_edRemained.ReadOnly = True
        Me.m_edRemained.Size = New System.Drawing.Size(80, 21)
        Me.m_edRemained.TabIndex = 11
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(13, 49)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(196, 12)
        Me.label2.TabIndex = 10
        Me.label2.Text = "Remained Image (Camera Buffer)"
        '
        'm_ckEnable
        '
        Me.m_ckEnable.AutoSize = True
        Me.m_ckEnable.Location = New System.Drawing.Point(233, 18)
        Me.m_ckEnable.Name = "m_ckEnable"
        Me.m_ckEnable.Size = New System.Drawing.Size(40, 16)
        Me.m_ckEnable.TabIndex = 9
        Me.m_ckEnable.Text = "On"
        Me.m_ckEnable.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(13, 19)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(44, 12)
        Me.label1.TabIndex = 8
        Me.label1.Text = "Enable"
        '
        'PopupFrameSaveForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(356, 115)
        Me.Controls.Add(Me.m_btnPlay)
        Me.Controls.Add(Me.m_edRecvCount)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.m_btnRefresh)
        Me.Controls.Add(Me.m_edRemained)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.m_ckEnable)
        Me.Controls.Add(Me.label1)
        Me.Name = "PopupFrameSaveForm"
        Me.Text = "PopupFrameSaveForm"
        CType(Me.m_edRecvCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents m_btnPlay As System.Windows.Forms.Button
    Private WithEvents m_edRecvCount As System.Windows.Forms.NumericUpDown
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents m_btnRefresh As System.Windows.Forms.Button
    Private WithEvents m_edRemained As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents m_ckEnable As System.Windows.Forms.CheckBox
    Private WithEvents label1 As System.Windows.Forms.Label
End Class
