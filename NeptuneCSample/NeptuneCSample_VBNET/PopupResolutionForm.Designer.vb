<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PopupResolutionForm
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
        Me.m_edHeight = New System.Windows.Forms.NumericUpDown()
        Me.label4 = New System.Windows.Forms.Label()
        Me.m_edOffsetY = New System.Windows.Forms.NumericUpDown()
        Me.label3 = New System.Windows.Forms.Label()
        Me.m_edWidth = New System.Windows.Forms.NumericUpDown()
        Me.label2 = New System.Windows.Forms.Label()
        Me.m_edOffsetX = New System.Windows.Forms.NumericUpDown()
        Me.label1 = New System.Windows.Forms.Label()
        Me.m_stcResolution = New System.Windows.Forms.Label()
        CType(Me.m_edHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_edOffsetY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_edWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_edOffsetX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'm_btnApply
        '
        Me.m_btnApply.Location = New System.Drawing.Point(127, 135)
        Me.m_btnApply.Name = "m_btnApply"
        Me.m_btnApply.Size = New System.Drawing.Size(75, 23)
        Me.m_btnApply.TabIndex = 19
        Me.m_btnApply.Text = "Apply"
        Me.m_btnApply.UseVisualStyleBackColor = True
        '
        'm_edHeight
        '
        Me.m_edHeight.Location = New System.Drawing.Point(231, 87)
        Me.m_edHeight.Name = "m_edHeight"
        Me.m_edHeight.Size = New System.Drawing.Size(67, 21)
        Me.m_edHeight.TabIndex = 18
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(176, 91)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(40, 12)
        Me.label4.TabIndex = 17
        Me.label4.Text = "Height"
        '
        'm_edOffsetY
        '
        Me.m_edOffsetY.Location = New System.Drawing.Point(81, 87)
        Me.m_edOffsetY.Name = "m_edOffsetY"
        Me.m_edOffsetY.Size = New System.Drawing.Size(67, 21)
        Me.m_edOffsetY.TabIndex = 16
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(18, 91)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(49, 12)
        Me.label3.TabIndex = 15
        Me.label3.Text = "Offset Y"
        '
        'm_edWidth
        '
        Me.m_edWidth.Location = New System.Drawing.Point(231, 45)
        Me.m_edWidth.Name = "m_edWidth"
        Me.m_edWidth.Size = New System.Drawing.Size(67, 21)
        Me.m_edWidth.TabIndex = 14
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(176, 49)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(35, 12)
        Me.label2.TabIndex = 13
        Me.label2.Text = "Width"
        '
        'm_edOffsetX
        '
        Me.m_edOffsetX.Location = New System.Drawing.Point(81, 45)
        Me.m_edOffsetX.Name = "m_edOffsetX"
        Me.m_edOffsetX.Size = New System.Drawing.Size(67, 21)
        Me.m_edOffsetX.TabIndex = 12
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(18, 49)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(49, 12)
        Me.label1.TabIndex = 11
        Me.label1.Text = "Offset X"
        '
        'm_stcResolution
        '
        Me.m_stcResolution.AutoSize = True
        Me.m_stcResolution.Location = New System.Drawing.Point(18, 16)
        Me.m_stcResolution.Name = "m_stcResolution"
        Me.m_stcResolution.Size = New System.Drawing.Size(152, 12)
        Me.m_stcResolution.TabIndex = 10
        Me.m_stcResolution.Text = "Resolution: Width x Height"
        '
        'PopupResolutionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(316, 175)
        Me.Controls.Add(Me.m_btnApply)
        Me.Controls.Add(Me.m_edHeight)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.m_edOffsetY)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.m_edWidth)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.m_edOffsetX)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.m_stcResolution)
        Me.Name = "PopupResolutionForm"
        Me.Text = "PopupResolutionForm"
        CType(Me.m_edHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_edOffsetY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_edWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_edOffsetX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents m_btnApply As System.Windows.Forms.Button
    Private WithEvents m_edHeight As System.Windows.Forms.NumericUpDown
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents m_edOffsetY As System.Windows.Forms.NumericUpDown
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents m_edWidth As System.Windows.Forms.NumericUpDown
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents m_edOffsetX As System.Windows.Forms.NumericUpDown
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents m_stcResolution As System.Windows.Forms.Label
End Class
