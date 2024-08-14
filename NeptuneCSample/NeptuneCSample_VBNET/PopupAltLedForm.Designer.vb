<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PopupAltLedForm
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
        Me.m_btnUpdateTable = New System.Windows.Forms.Button()
        Me.m_btnSampleFill = New System.Windows.Forms.Button()
        Me.m_btnZeroFill = New System.Windows.Forms.Button()
        Me.label2 = New System.Windows.Forms.Label()
        Me.m_btnSet = New System.Windows.Forms.Button()
        Me.m_tbStartIndex = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.m_btnAutoRun = New System.Windows.Forms.CheckBox()
        Me.m_rbDirect = New System.Windows.Forms.RadioButton()
        Me.m_rbIndex = New System.Windows.Forms.RadioButton()
        Me.m_gridTable = New System.Windows.Forms.DataGridView()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.m_gridTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'm_btnUpdateTable
        '
        Me.m_btnUpdateTable.Location = New System.Drawing.Point(446, 154)
        Me.m_btnUpdateTable.Name = "m_btnUpdateTable"
        Me.m_btnUpdateTable.Size = New System.Drawing.Size(94, 23)
        Me.m_btnUpdateTable.TabIndex = 23
        Me.m_btnUpdateTable.Text = "Update Table"
        Me.m_btnUpdateTable.UseVisualStyleBackColor = True
        '
        'm_btnSampleFill
        '
        Me.m_btnSampleFill.Location = New System.Drawing.Point(339, 154)
        Me.m_btnSampleFill.Name = "m_btnSampleFill"
        Me.m_btnSampleFill.Size = New System.Drawing.Size(94, 23)
        Me.m_btnSampleFill.TabIndex = 22
        Me.m_btnSampleFill.Text = "Sample Fill"
        Me.m_btnSampleFill.UseVisualStyleBackColor = True
        '
        'm_btnZeroFill
        '
        Me.m_btnZeroFill.Location = New System.Drawing.Point(240, 154)
        Me.m_btnZeroFill.Name = "m_btnZeroFill"
        Me.m_btnZeroFill.Size = New System.Drawing.Size(94, 23)
        Me.m_btnZeroFill.TabIndex = 21
        Me.m_btnZeroFill.Text = "Zero Fill"
        Me.m_btnZeroFill.UseVisualStyleBackColor = True
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(215, 99)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(64, 12)
        Me.label2.TabIndex = 19
        Me.label2.Text = "( 0 ~ 254 )"
        '
        'm_btnSet
        '
        Me.m_btnSet.Location = New System.Drawing.Point(298, 93)
        Me.m_btnSet.Name = "m_btnSet"
        Me.m_btnSet.Size = New System.Drawing.Size(75, 23)
        Me.m_btnSet.TabIndex = 18
        Me.m_btnSet.Text = "Set"
        Me.m_btnSet.UseVisualStyleBackColor = True
        '
        'm_tbStartIndex
        '
        Me.m_tbStartIndex.Location = New System.Drawing.Point(109, 94)
        Me.m_tbStartIndex.Name = "m_tbStartIndex"
        Me.m_tbStartIndex.Size = New System.Drawing.Size(100, 21)
        Me.m_tbStartIndex.TabIndex = 17
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(37, 100)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(65, 12)
        Me.label1.TabIndex = 16
        Me.label1.Text = "Start Index"
        '
        'm_btnAutoRun
        '
        Me.m_btnAutoRun.AutoSize = True
        Me.m_btnAutoRun.Location = New System.Drawing.Point(37, 63)
        Me.m_btnAutoRun.Name = "m_btnAutoRun"
        Me.m_btnAutoRun.Size = New System.Drawing.Size(102, 16)
        Me.m_btnAutoRun.TabIndex = 15
        Me.m_btnAutoRun.Text = "LED Auto Run"
        Me.m_btnAutoRun.UseVisualStyleBackColor = True
        '
        'm_rbDirect
        '
        Me.m_rbDirect.AutoSize = True
        Me.m_rbDirect.Location = New System.Drawing.Point(144, 32)
        Me.m_rbDirect.Name = "m_rbDirect"
        Me.m_rbDirect.Size = New System.Drawing.Size(65, 16)
        Me.m_rbDirect.TabIndex = 14
        Me.m_rbDirect.TabStop = True
        Me.m_rbDirect.Text = "Direct 0"
        Me.m_rbDirect.UseVisualStyleBackColor = True
        '
        'm_rbIndex
        '
        Me.m_rbIndex.AutoSize = True
        Me.m_rbIndex.Location = New System.Drawing.Point(37, 32)
        Me.m_rbIndex.Name = "m_rbIndex"
        Me.m_rbIndex.Size = New System.Drawing.Size(90, 16)
        Me.m_rbIndex.TabIndex = 13
        Me.m_rbIndex.TabStop = True
        Me.m_rbIndex.Text = "Index Table"
        Me.m_rbIndex.UseVisualStyleBackColor = True
        '
        'm_gridTable
        '
        Me.m_gridTable.AllowUserToDeleteRows = False
        Me.m_gridTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.m_gridTable.Location = New System.Drawing.Point(13, 183)
        Me.m_gridTable.Name = "m_gridTable"
        Me.m_gridTable.RowTemplate.Height = 23
        Me.m_gridTable.Size = New System.Drawing.Size(527, 327)
        Me.m_gridTable.TabIndex = 12
        '
        'groupBox1
        '
        Me.groupBox1.Location = New System.Drawing.Point(13, 12)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(401, 124)
        Me.groupBox1.TabIndex = 20
        Me.groupBox1.TabStop = False
        '
        'PopupAltLedForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(552, 523)
        Me.Controls.Add(Me.m_btnUpdateTable)
        Me.Controls.Add(Me.m_btnSampleFill)
        Me.Controls.Add(Me.m_btnZeroFill)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.m_btnSet)
        Me.Controls.Add(Me.m_tbStartIndex)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.m_btnAutoRun)
        Me.Controls.Add(Me.m_rbDirect)
        Me.Controls.Add(Me.m_rbIndex)
        Me.Controls.Add(Me.m_gridTable)
        Me.Controls.Add(Me.groupBox1)
        Me.Name = "PopupAltLedForm"
        Me.Text = "PopupAltLedForm"
        CType(Me.m_gridTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents m_btnUpdateTable As System.Windows.Forms.Button
    Private WithEvents m_btnSampleFill As System.Windows.Forms.Button
    Private WithEvents m_btnZeroFill As System.Windows.Forms.Button
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents m_btnSet As System.Windows.Forms.Button
    Private WithEvents m_tbStartIndex As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents m_btnAutoRun As System.Windows.Forms.CheckBox
    Private WithEvents m_rbDirect As System.Windows.Forms.RadioButton
    Private WithEvents m_rbIndex As System.Windows.Forms.RadioButton
    Private WithEvents m_gridTable As System.Windows.Forms.DataGridView
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
End Class
