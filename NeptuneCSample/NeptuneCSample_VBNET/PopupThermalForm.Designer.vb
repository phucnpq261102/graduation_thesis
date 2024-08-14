<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PopupThermalForm
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
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnSetDetect = New System.Windows.Forms.Button()
        Me.cbAlarmDetectOutputPolarity = New System.Windows.Forms.ComboBox()
        Me.cbAlarmDetectOutputEnable = New System.Windows.Forms.ComboBox()
        Me.tbAlarmDetectStopDelay = New System.Windows.Forms.TextBox()
        Me.tbAlarmDetectStartDelay = New System.Windows.Forms.TextBox()
        Me.tbAlarmDetectPixelCnt = New System.Windows.Forms.TextBox()
        Me.label12 = New System.Windows.Forms.Label()
        Me.label11 = New System.Windows.Forms.Label()
        Me.label10 = New System.Windows.Forms.Label()
        Me.label9 = New System.Windows.Forms.Label()
        Me.label8 = New System.Windows.Forms.Label()
        Me.label7 = New System.Windows.Forms.Label()
        Me.label6 = New System.Windows.Forms.Label()
        Me.btnSetPrivacy = New System.Windows.Forms.Button()
        Me.btnReqNUC = New System.Windows.Forms.Button()
        Me.btnSetNuc = New System.Windows.Forms.Button()
        Me.tbPointTemperature = New System.Windows.Forms.TextBox()
        Me.cbPrivacySelect = New System.Windows.Forms.ComboBox()
        Me.tbNucAutoTemperature = New System.Windows.Forms.TextBox()
        Me.label18 = New System.Windows.Forms.Label()
        Me.btnSetPoint = New System.Windows.Forms.Button()
        Me.label17 = New System.Windows.Forms.Label()
        Me.tbNucAutoTime = New System.Windows.Forms.TextBox()
        Me.label16 = New System.Windows.Forms.Label()
        Me.label23 = New System.Windows.Forms.Label()
        Me.btnGetPoint = New System.Windows.Forms.Button()
        Me.groupBox4 = New System.Windows.Forms.GroupBox()
        Me.tbPrivacyHeight = New System.Windows.Forms.TextBox()
        Me.tbPrivacyWidth = New System.Windows.Forms.TextBox()
        Me.tbPrivacyTop = New System.Windows.Forms.TextBox()
        Me.tbPrivacyLeft = New System.Windows.Forms.TextBox()
        Me.cbPrivacyEnable = New System.Windows.Forms.ComboBox()
        Me.label15 = New System.Windows.Forms.Label()
        Me.label14 = New System.Windows.Forms.Label()
        Me.label13 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.cbNucMode = New System.Windows.Forms.ComboBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.cbAlarmStatus = New System.Windows.Forms.ComboBox()
        Me.btnGetAlarm = New System.Windows.Forms.Button()
        Me.label34 = New System.Windows.Forms.Label()
        Me.label22 = New System.Windows.Forms.Label()
        Me.cbAlarmColor = New System.Windows.Forms.ComboBox()
        Me.label33 = New System.Windows.Forms.Label()
        Me.tbAlarmTemperature = New System.Windows.Forms.TextBox()
        Me.label32 = New System.Windows.Forms.Label()
        Me.label31 = New System.Windows.Forms.Label()
        Me.cbAlarmTransparency = New System.Windows.Forms.ComboBox()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSetPalette = New System.Windows.Forms.Button()
        Me.cbPalette = New System.Windows.Forms.ComboBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.groupBox6 = New System.Windows.Forms.GroupBox()
        Me.cbAlarmCondition = New System.Windows.Forms.ComboBox()
        Me.label30 = New System.Windows.Forms.Label()
        Me.btnSetAlarm = New System.Windows.Forms.Button()
        Me.tbAlarmHeight = New System.Windows.Forms.TextBox()
        Me.tbAlarmWidth = New System.Windows.Forms.TextBox()
        Me.tbAlarmTop = New System.Windows.Forms.TextBox()
        Me.tbAlarmLeft = New System.Windows.Forms.TextBox()
        Me.cbAlarmEnable = New System.Windows.Forms.ComboBox()
        Me.cbAlarmSelect = New System.Windows.Forms.ComboBox()
        Me.label24 = New System.Windows.Forms.Label()
        Me.label25 = New System.Windows.Forms.Label()
        Me.label26 = New System.Windows.Forms.Label()
        Me.label27 = New System.Windows.Forms.Label()
        Me.label28 = New System.Windows.Forms.Label()
        Me.label29 = New System.Windows.Forms.Label()
        Me.label19 = New System.Windows.Forms.Label()
        Me.label20 = New System.Windows.Forms.Label()
        Me.tbPointTop = New System.Windows.Forms.TextBox()
        Me.tbPointLeft = New System.Windows.Forms.TextBox()
        Me.cbPointEnable = New System.Windows.Forms.ComboBox()
        Me.cbPointSelect = New System.Windows.Forms.ComboBox()
        Me.label21 = New System.Windows.Forms.Label()
        Me.groupBox5 = New System.Windows.Forms.GroupBox()
        Me.groupBox3.SuspendLayout()
        Me.groupBox4.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.groupBox6.SuspendLayout()
        Me.groupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.btnSetDetect)
        Me.groupBox3.Controls.Add(Me.cbAlarmDetectOutputPolarity)
        Me.groupBox3.Controls.Add(Me.cbAlarmDetectOutputEnable)
        Me.groupBox3.Controls.Add(Me.tbAlarmDetectStopDelay)
        Me.groupBox3.Controls.Add(Me.tbAlarmDetectStartDelay)
        Me.groupBox3.Controls.Add(Me.tbAlarmDetectPixelCnt)
        Me.groupBox3.Controls.Add(Me.label12)
        Me.groupBox3.Controls.Add(Me.label11)
        Me.groupBox3.Controls.Add(Me.label10)
        Me.groupBox3.Controls.Add(Me.label9)
        Me.groupBox3.Controls.Add(Me.label8)
        Me.groupBox3.Controls.Add(Me.label7)
        Me.groupBox3.Controls.Add(Me.label6)
        Me.groupBox3.Location = New System.Drawing.Point(311, 14)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(303, 251)
        Me.groupBox3.TabIndex = 14
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Alarm Detection"
        '
        'btnSetDetect
        '
        Me.btnSetDetect.Location = New System.Drawing.Point(167, 174)
        Me.btnSetDetect.Name = "btnSetDetect"
        Me.btnSetDetect.Size = New System.Drawing.Size(75, 23)
        Me.btnSetDetect.TabIndex = 11
        Me.btnSetDetect.Text = "Set Value"
        Me.btnSetDetect.UseVisualStyleBackColor = True
        '
        'cbAlarmDetectOutputPolarity
        '
        Me.cbAlarmDetectOutputPolarity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAlarmDetectOutputPolarity.FormattingEnabled = True
        Me.cbAlarmDetectOutputPolarity.Location = New System.Drawing.Point(121, 132)
        Me.cbAlarmDetectOutputPolarity.Name = "cbAlarmDetectOutputPolarity"
        Me.cbAlarmDetectOutputPolarity.Size = New System.Drawing.Size(121, 20)
        Me.cbAlarmDetectOutputPolarity.TabIndex = 20
        '
        'cbAlarmDetectOutputEnable
        '
        Me.cbAlarmDetectOutputEnable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAlarmDetectOutputEnable.FormattingEnabled = True
        Me.cbAlarmDetectOutputEnable.Location = New System.Drawing.Point(121, 101)
        Me.cbAlarmDetectOutputEnable.Name = "cbAlarmDetectOutputEnable"
        Me.cbAlarmDetectOutputEnable.Size = New System.Drawing.Size(121, 20)
        Me.cbAlarmDetectOutputEnable.TabIndex = 11
        '
        'tbAlarmDetectStopDelay
        '
        Me.tbAlarmDetectStopDelay.Location = New System.Drawing.Point(121, 74)
        Me.tbAlarmDetectStopDelay.Name = "tbAlarmDetectStopDelay"
        Me.tbAlarmDetectStopDelay.Size = New System.Drawing.Size(121, 21)
        Me.tbAlarmDetectStopDelay.TabIndex = 19
        '
        'tbAlarmDetectStartDelay
        '
        Me.tbAlarmDetectStartDelay.Location = New System.Drawing.Point(121, 47)
        Me.tbAlarmDetectStartDelay.Name = "tbAlarmDetectStartDelay"
        Me.tbAlarmDetectStartDelay.Size = New System.Drawing.Size(121, 21)
        Me.tbAlarmDetectStartDelay.TabIndex = 18
        '
        'tbAlarmDetectPixelCnt
        '
        Me.tbAlarmDetectPixelCnt.Location = New System.Drawing.Point(121, 20)
        Me.tbAlarmDetectPixelCnt.Name = "tbAlarmDetectPixelCnt"
        Me.tbAlarmDetectPixelCnt.Size = New System.Drawing.Size(121, 21)
        Me.tbAlarmDetectPixelCnt.TabIndex = 11
        '
        'label12
        '
        Me.label12.AutoSize = True
        Me.label12.Location = New System.Drawing.Point(251, 79)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(26, 12)
        Me.label12.TabIndex = 17
        Me.label12.Text = "sec"
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(251, 54)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(26, 12)
        Me.label11.TabIndex = 16
        Me.label11.Text = "sec"
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Location = New System.Drawing.Point(25, 135)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(87, 12)
        Me.label10.TabIndex = 15
        Me.label10.Text = "Output Polarity"
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(25, 107)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(81, 12)
        Me.label9.TabIndex = 14
        Me.label9.Text = "Ouput Enable"
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(25, 79)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(66, 12)
        Me.label8.TabIndex = 13
        Me.label8.Text = "Stop Delay"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(25, 54)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(66, 12)
        Me.label7.TabIndex = 12
        Me.label7.Text = "Start Delay"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(25, 26)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(70, 12)
        Me.label6.TabIndex = 11
        Me.label6.Text = "Pixel Count"
        '
        'btnSetPrivacy
        '
        Me.btnSetPrivacy.Location = New System.Drawing.Point(106, 192)
        Me.btnSetPrivacy.Name = "btnSetPrivacy"
        Me.btnSetPrivacy.Size = New System.Drawing.Size(75, 23)
        Me.btnSetPrivacy.TabIndex = 21
        Me.btnSetPrivacy.Text = "Set Value"
        Me.btnSetPrivacy.UseVisualStyleBackColor = True
        '
        'btnReqNUC
        '
        Me.btnReqNUC.Location = New System.Drawing.Point(69, 97)
        Me.btnReqNUC.Name = "btnReqNUC"
        Me.btnReqNUC.Size = New System.Drawing.Size(75, 23)
        Me.btnReqNUC.TabIndex = 10
        Me.btnReqNUC.Text = "Request NUC"
        Me.btnReqNUC.UseVisualStyleBackColor = True
        '
        'btnSetNuc
        '
        Me.btnSetNuc.Location = New System.Drawing.Point(157, 97)
        Me.btnSetNuc.Name = "btnSetNuc"
        Me.btnSetNuc.Size = New System.Drawing.Size(75, 23)
        Me.btnSetNuc.TabIndex = 3
        Me.btnSetNuc.Text = "Set Value"
        Me.btnSetNuc.UseVisualStyleBackColor = True
        '
        'tbPointTemperature
        '
        Me.tbPointTemperature.Location = New System.Drawing.Point(135, 211)
        Me.tbPointTemperature.Name = "tbPointTemperature"
        Me.tbPointTemperature.ReadOnly = True
        Me.tbPointTemperature.Size = New System.Drawing.Size(51, 21)
        Me.tbPointTemperature.TabIndex = 39
        '
        'cbPrivacySelect
        '
        Me.cbPrivacySelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPrivacySelect.FormattingEnabled = True
        Me.cbPrivacySelect.Location = New System.Drawing.Point(60, 26)
        Me.cbPrivacySelect.Name = "cbPrivacySelect"
        Me.cbPrivacySelect.Size = New System.Drawing.Size(121, 20)
        Me.cbPrivacySelect.TabIndex = 11
        '
        'tbNucAutoTemperature
        '
        Me.tbNucAutoTemperature.Location = New System.Drawing.Point(132, 70)
        Me.tbNucAutoTemperature.Name = "tbNucAutoTemperature"
        Me.tbNucAutoTemperature.Size = New System.Drawing.Size(100, 21)
        Me.tbNucAutoTemperature.TabIndex = 9
        '
        'label18
        '
        Me.label18.AutoSize = True
        Me.label18.Location = New System.Drawing.Point(14, 164)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(40, 12)
        Me.label18.TabIndex = 26
        Me.label18.Text = "Height"
        '
        'btnSetPoint
        '
        Me.btnSetPoint.Location = New System.Drawing.Point(112, 135)
        Me.btnSetPoint.Name = "btnSetPoint"
        Me.btnSetPoint.Size = New System.Drawing.Size(75, 23)
        Me.btnSetPoint.TabIndex = 31
        Me.btnSetPoint.Text = "Set Value"
        Me.btnSetPoint.UseVisualStyleBackColor = True
        '
        'label17
        '
        Me.label17.AutoSize = True
        Me.label17.Location = New System.Drawing.Point(14, 135)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(35, 12)
        Me.label17.TabIndex = 25
        Me.label17.Text = "Width"
        '
        'tbNucAutoTime
        '
        Me.tbNucAutoTime.Location = New System.Drawing.Point(132, 44)
        Me.tbNucAutoTime.Name = "tbNucAutoTime"
        Me.tbNucAutoTime.Size = New System.Drawing.Size(100, 21)
        Me.tbNucAutoTime.TabIndex = 8
        '
        'label16
        '
        Me.label16.AutoSize = True
        Me.label16.Location = New System.Drawing.Point(14, 108)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(27, 12)
        Me.label16.TabIndex = 24
        Me.label16.Text = "Top"
        '
        'label23
        '
        Me.label23.AutoSize = True
        Me.label23.Location = New System.Drawing.Point(5, 214)
        Me.label23.Name = "label23"
        Me.label23.Size = New System.Drawing.Size(130, 12)
        Me.label23.TabIndex = 38
        Me.label23.Text = "Selected Temperature"
        '
        'btnGetPoint
        '
        Me.btnGetPoint.Location = New System.Drawing.Point(112, 246)
        Me.btnGetPoint.Name = "btnGetPoint"
        Me.btnGetPoint.Size = New System.Drawing.Size(75, 23)
        Me.btnGetPoint.TabIndex = 40
        Me.btnGetPoint.Text = "Get Value"
        Me.btnGetPoint.UseVisualStyleBackColor = True
        '
        'groupBox4
        '
        Me.groupBox4.Controls.Add(Me.btnSetPrivacy)
        Me.groupBox4.Controls.Add(Me.tbPrivacyHeight)
        Me.groupBox4.Controls.Add(Me.tbPrivacyWidth)
        Me.groupBox4.Controls.Add(Me.tbPrivacyTop)
        Me.groupBox4.Controls.Add(Me.tbPrivacyLeft)
        Me.groupBox4.Controls.Add(Me.cbPrivacyEnable)
        Me.groupBox4.Controls.Add(Me.cbPrivacySelect)
        Me.groupBox4.Controls.Add(Me.label18)
        Me.groupBox4.Controls.Add(Me.label17)
        Me.groupBox4.Controls.Add(Me.label16)
        Me.groupBox4.Controls.Add(Me.label15)
        Me.groupBox4.Controls.Add(Me.label14)
        Me.groupBox4.Controls.Add(Me.label13)
        Me.groupBox4.Location = New System.Drawing.Point(14, 283)
        Me.groupBox4.Name = "groupBox4"
        Me.groupBox4.Size = New System.Drawing.Size(191, 418)
        Me.groupBox4.TabIndex = 15
        Me.groupBox4.TabStop = False
        Me.groupBox4.Text = "Image Privacy Mask"
        '
        'tbPrivacyHeight
        '
        Me.tbPrivacyHeight.Location = New System.Drawing.Point(60, 159)
        Me.tbPrivacyHeight.Name = "tbPrivacyHeight"
        Me.tbPrivacyHeight.Size = New System.Drawing.Size(121, 21)
        Me.tbPrivacyHeight.TabIndex = 30
        '
        'tbPrivacyWidth
        '
        Me.tbPrivacyWidth.Location = New System.Drawing.Point(60, 132)
        Me.tbPrivacyWidth.Name = "tbPrivacyWidth"
        Me.tbPrivacyWidth.Size = New System.Drawing.Size(121, 21)
        Me.tbPrivacyWidth.TabIndex = 29
        '
        'tbPrivacyTop
        '
        Me.tbPrivacyTop.Location = New System.Drawing.Point(60, 105)
        Me.tbPrivacyTop.Name = "tbPrivacyTop"
        Me.tbPrivacyTop.Size = New System.Drawing.Size(121, 21)
        Me.tbPrivacyTop.TabIndex = 28
        '
        'tbPrivacyLeft
        '
        Me.tbPrivacyLeft.Location = New System.Drawing.Point(60, 78)
        Me.tbPrivacyLeft.Name = "tbPrivacyLeft"
        Me.tbPrivacyLeft.Size = New System.Drawing.Size(121, 21)
        Me.tbPrivacyLeft.TabIndex = 11
        '
        'cbPrivacyEnable
        '
        Me.cbPrivacyEnable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPrivacyEnable.FormattingEnabled = True
        Me.cbPrivacyEnable.Location = New System.Drawing.Point(60, 52)
        Me.cbPrivacyEnable.Name = "cbPrivacyEnable"
        Me.cbPrivacyEnable.Size = New System.Drawing.Size(121, 20)
        Me.cbPrivacyEnable.TabIndex = 27
        '
        'label15
        '
        Me.label15.AutoSize = True
        Me.label15.Location = New System.Drawing.Point(14, 56)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(44, 12)
        Me.label15.TabIndex = 23
        Me.label15.Text = "Enable"
        '
        'label14
        '
        Me.label14.AutoSize = True
        Me.label14.Location = New System.Drawing.Point(14, 82)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(25, 12)
        Me.label14.TabIndex = 22
        Me.label14.Text = "Left"
        '
        'label13
        '
        Me.label13.AutoSize = True
        Me.label13.Location = New System.Drawing.Point(14, 29)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(40, 12)
        Me.label13.TabIndex = 21
        Me.label13.Text = "Select"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(13, 73)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(106, 12)
        Me.label4.TabIndex = 6
        Me.label4.Text = "Auto Temperature"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(238, 53)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(26, 12)
        Me.label5.TabIndex = 7
        Me.label5.Text = "min"
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.btnReqNUC)
        Me.groupBox2.Controls.Add(Me.btnSetNuc)
        Me.groupBox2.Controls.Add(Me.tbNucAutoTemperature)
        Me.groupBox2.Controls.Add(Me.tbNucAutoTime)
        Me.groupBox2.Controls.Add(Me.label5)
        Me.groupBox2.Controls.Add(Me.label4)
        Me.groupBox2.Controls.Add(Me.label3)
        Me.groupBox2.Controls.Add(Me.cbNucMode)
        Me.groupBox2.Controls.Add(Me.label2)
        Me.groupBox2.Location = New System.Drawing.Point(14, 135)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(269, 130)
        Me.groupBox2.TabIndex = 13
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Non-uniformity correction"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(14, 47)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(113, 12)
        Me.label3.TabIndex = 5
        Me.label3.Text = "Auto Periodic Time"
        '
        'cbNucMode
        '
        Me.cbNucMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbNucMode.FormattingEnabled = True
        Me.cbNucMode.Location = New System.Drawing.Point(83, 20)
        Me.cbNucMode.Name = "cbNucMode"
        Me.cbNucMode.Size = New System.Drawing.Size(149, 20)
        Me.cbNucMode.TabIndex = 4
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(13, 23)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(37, 12)
        Me.label2.TabIndex = 3
        Me.label2.Text = "Mode"
        '
        'cbAlarmStatus
        '
        Me.cbAlarmStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAlarmStatus.FormattingEnabled = True
        Me.cbAlarmStatus.Location = New System.Drawing.Point(91, 358)
        Me.cbAlarmStatus.Name = "cbAlarmStatus"
        Me.cbAlarmStatus.Size = New System.Drawing.Size(89, 20)
        Me.cbAlarmStatus.TabIndex = 54
        '
        'btnGetAlarm
        '
        Me.btnGetAlarm.Location = New System.Drawing.Point(105, 389)
        Me.btnGetAlarm.Name = "btnGetAlarm"
        Me.btnGetAlarm.Size = New System.Drawing.Size(75, 23)
        Me.btnGetAlarm.TabIndex = 53
        Me.btnGetAlarm.Text = "Get Value"
        Me.btnGetAlarm.UseVisualStyleBackColor = True
        '
        'label34
        '
        Me.label34.AutoSize = True
        Me.label34.Location = New System.Drawing.Point(8, 343)
        Me.label34.Name = "label34"
        Me.label34.Size = New System.Drawing.Size(130, 12)
        Me.label34.TabIndex = 52
        Me.label34.Text = "Selected Alarm Status"
        '
        'label22
        '
        Me.label22.AutoSize = True
        Me.label22.Location = New System.Drawing.Point(13, 29)
        Me.label22.Name = "label22"
        Me.label22.Size = New System.Drawing.Size(40, 12)
        Me.label22.TabIndex = 32
        Me.label22.Text = "Select"
        '
        'cbAlarmColor
        '
        Me.cbAlarmColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAlarmColor.FormattingEnabled = True
        Me.cbAlarmColor.Location = New System.Drawing.Point(91, 270)
        Me.cbAlarmColor.Name = "cbAlarmColor"
        Me.cbAlarmColor.Size = New System.Drawing.Size(89, 20)
        Me.cbAlarmColor.TabIndex = 51
        '
        'label33
        '
        Me.label33.AutoSize = True
        Me.label33.Location = New System.Drawing.Point(8, 274)
        Me.label33.Name = "label33"
        Me.label33.Size = New System.Drawing.Size(35, 12)
        Me.label33.TabIndex = 50
        Me.label33.Text = "Color"
        '
        'tbAlarmTemperature
        '
        Me.tbAlarmTemperature.Location = New System.Drawing.Point(91, 214)
        Me.tbAlarmTemperature.Name = "tbAlarmTemperature"
        Me.tbAlarmTemperature.Size = New System.Drawing.Size(89, 21)
        Me.tbAlarmTemperature.TabIndex = 49
        '
        'label32
        '
        Me.label32.AutoSize = True
        Me.label32.Location = New System.Drawing.Point(8, 219)
        Me.label32.Name = "label32"
        Me.label32.Size = New System.Drawing.Size(77, 12)
        Me.label32.TabIndex = 48
        Me.label32.Text = "Temperature"
        '
        'label31
        '
        Me.label31.AutoSize = True
        Me.label31.Location = New System.Drawing.Point(8, 246)
        Me.label31.Name = "label31"
        Me.label31.Size = New System.Drawing.Size(84, 12)
        Me.label31.TabIndex = 46
        Me.label31.Text = "Transparency"
        '
        'cbAlarmTransparency
        '
        Me.cbAlarmTransparency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAlarmTransparency.FormattingEnabled = True
        Me.cbAlarmTransparency.Location = New System.Drawing.Point(91, 242)
        Me.cbAlarmTransparency.Name = "cbAlarmTransparency"
        Me.cbAlarmTransparency.Size = New System.Drawing.Size(89, 20)
        Me.cbAlarmTransparency.TabIndex = 47
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.btnSetPalette)
        Me.groupBox1.Controls.Add(Me.cbPalette)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Location = New System.Drawing.Point(14, 14)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(269, 77)
        Me.groupBox1.TabIndex = 12
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "YUV Image"
        '
        'btnSetPalette
        '
        Me.btnSetPalette.Location = New System.Drawing.Point(157, 44)
        Me.btnSetPalette.Name = "btnSetPalette"
        Me.btnSetPalette.Size = New System.Drawing.Size(75, 23)
        Me.btnSetPalette.TabIndex = 2
        Me.btnSetPalette.Text = "Set Value"
        Me.btnSetPalette.UseVisualStyleBackColor = True
        '
        'cbPalette
        '
        Me.cbPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPalette.FormattingEnabled = True
        Me.cbPalette.Location = New System.Drawing.Point(56, 18)
        Me.cbPalette.Name = "cbPalette"
        Me.cbPalette.Size = New System.Drawing.Size(176, 20)
        Me.cbPalette.TabIndex = 1
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(7, 21)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(43, 12)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Palette"
        '
        'groupBox6
        '
        Me.groupBox6.Controls.Add(Me.cbAlarmStatus)
        Me.groupBox6.Controls.Add(Me.btnGetAlarm)
        Me.groupBox6.Controls.Add(Me.label34)
        Me.groupBox6.Controls.Add(Me.cbAlarmColor)
        Me.groupBox6.Controls.Add(Me.label33)
        Me.groupBox6.Controls.Add(Me.tbAlarmTemperature)
        Me.groupBox6.Controls.Add(Me.label32)
        Me.groupBox6.Controls.Add(Me.cbAlarmTransparency)
        Me.groupBox6.Controls.Add(Me.label31)
        Me.groupBox6.Controls.Add(Me.cbAlarmCondition)
        Me.groupBox6.Controls.Add(Me.label30)
        Me.groupBox6.Controls.Add(Me.btnSetAlarm)
        Me.groupBox6.Controls.Add(Me.tbAlarmHeight)
        Me.groupBox6.Controls.Add(Me.tbAlarmWidth)
        Me.groupBox6.Controls.Add(Me.tbAlarmTop)
        Me.groupBox6.Controls.Add(Me.tbAlarmLeft)
        Me.groupBox6.Controls.Add(Me.cbAlarmEnable)
        Me.groupBox6.Controls.Add(Me.cbAlarmSelect)
        Me.groupBox6.Controls.Add(Me.label24)
        Me.groupBox6.Controls.Add(Me.label25)
        Me.groupBox6.Controls.Add(Me.label26)
        Me.groupBox6.Controls.Add(Me.label27)
        Me.groupBox6.Controls.Add(Me.label28)
        Me.groupBox6.Controls.Add(Me.label29)
        Me.groupBox6.Location = New System.Drawing.Point(414, 283)
        Me.groupBox6.Name = "groupBox6"
        Me.groupBox6.Size = New System.Drawing.Size(200, 418)
        Me.groupBox6.TabIndex = 17
        Me.groupBox6.TabStop = False
        Me.groupBox6.Text = "Region Alarm"
        '
        'cbAlarmCondition
        '
        Me.cbAlarmCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAlarmCondition.FormattingEnabled = True
        Me.cbAlarmCondition.Location = New System.Drawing.Point(91, 188)
        Me.cbAlarmCondition.Name = "cbAlarmCondition"
        Me.cbAlarmCondition.Size = New System.Drawing.Size(89, 20)
        Me.cbAlarmCondition.TabIndex = 45
        '
        'label30
        '
        Me.label30.AutoSize = True
        Me.label30.Location = New System.Drawing.Point(8, 192)
        Me.label30.Name = "label30"
        Me.label30.Size = New System.Drawing.Size(58, 12)
        Me.label30.TabIndex = 44
        Me.label30.Text = "Condition"
        '
        'btnSetAlarm
        '
        Me.btnSetAlarm.Location = New System.Drawing.Point(105, 296)
        Me.btnSetAlarm.Name = "btnSetAlarm"
        Me.btnSetAlarm.Size = New System.Drawing.Size(75, 23)
        Me.btnSetAlarm.TabIndex = 34
        Me.btnSetAlarm.Text = "Set Value"
        Me.btnSetAlarm.UseVisualStyleBackColor = True
        '
        'tbAlarmHeight
        '
        Me.tbAlarmHeight.Location = New System.Drawing.Point(59, 159)
        Me.tbAlarmHeight.Name = "tbAlarmHeight"
        Me.tbAlarmHeight.Size = New System.Drawing.Size(121, 21)
        Me.tbAlarmHeight.TabIndex = 43
        '
        'tbAlarmWidth
        '
        Me.tbAlarmWidth.Location = New System.Drawing.Point(59, 132)
        Me.tbAlarmWidth.Name = "tbAlarmWidth"
        Me.tbAlarmWidth.Size = New System.Drawing.Size(121, 21)
        Me.tbAlarmWidth.TabIndex = 42
        '
        'tbAlarmTop
        '
        Me.tbAlarmTop.Location = New System.Drawing.Point(59, 105)
        Me.tbAlarmTop.Name = "tbAlarmTop"
        Me.tbAlarmTop.Size = New System.Drawing.Size(121, 21)
        Me.tbAlarmTop.TabIndex = 41
        '
        'tbAlarmLeft
        '
        Me.tbAlarmLeft.Location = New System.Drawing.Point(59, 78)
        Me.tbAlarmLeft.Name = "tbAlarmLeft"
        Me.tbAlarmLeft.Size = New System.Drawing.Size(121, 21)
        Me.tbAlarmLeft.TabIndex = 31
        '
        'cbAlarmEnable
        '
        Me.cbAlarmEnable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAlarmEnable.FormattingEnabled = True
        Me.cbAlarmEnable.Location = New System.Drawing.Point(59, 52)
        Me.cbAlarmEnable.Name = "cbAlarmEnable"
        Me.cbAlarmEnable.Size = New System.Drawing.Size(121, 20)
        Me.cbAlarmEnable.TabIndex = 40
        '
        'cbAlarmSelect
        '
        Me.cbAlarmSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAlarmSelect.FormattingEnabled = True
        Me.cbAlarmSelect.Location = New System.Drawing.Point(59, 26)
        Me.cbAlarmSelect.Name = "cbAlarmSelect"
        Me.cbAlarmSelect.Size = New System.Drawing.Size(121, 20)
        Me.cbAlarmSelect.TabIndex = 32
        '
        'label24
        '
        Me.label24.AutoSize = True
        Me.label24.Location = New System.Drawing.Point(8, 164)
        Me.label24.Name = "label24"
        Me.label24.Size = New System.Drawing.Size(40, 12)
        Me.label24.TabIndex = 39
        Me.label24.Text = "Height"
        '
        'label25
        '
        Me.label25.AutoSize = True
        Me.label25.Location = New System.Drawing.Point(8, 135)
        Me.label25.Name = "label25"
        Me.label25.Size = New System.Drawing.Size(35, 12)
        Me.label25.TabIndex = 38
        Me.label25.Text = "Width"
        '
        'label26
        '
        Me.label26.AutoSize = True
        Me.label26.Location = New System.Drawing.Point(8, 108)
        Me.label26.Name = "label26"
        Me.label26.Size = New System.Drawing.Size(27, 12)
        Me.label26.TabIndex = 37
        Me.label26.Text = "Top"
        '
        'label27
        '
        Me.label27.AutoSize = True
        Me.label27.Location = New System.Drawing.Point(8, 56)
        Me.label27.Name = "label27"
        Me.label27.Size = New System.Drawing.Size(44, 12)
        Me.label27.TabIndex = 36
        Me.label27.Text = "Enable"
        '
        'label28
        '
        Me.label28.AutoSize = True
        Me.label28.Location = New System.Drawing.Point(8, 82)
        Me.label28.Name = "label28"
        Me.label28.Size = New System.Drawing.Size(25, 12)
        Me.label28.TabIndex = 35
        Me.label28.Text = "Left"
        '
        'label29
        '
        Me.label29.AutoSize = True
        Me.label29.Location = New System.Drawing.Point(8, 29)
        Me.label29.Name = "label29"
        Me.label29.Size = New System.Drawing.Size(40, 12)
        Me.label29.TabIndex = 33
        Me.label29.Text = "Select"
        '
        'label19
        '
        Me.label19.AutoSize = True
        Me.label19.Location = New System.Drawing.Point(13, 108)
        Me.label19.Name = "label19"
        Me.label19.Size = New System.Drawing.Size(27, 12)
        Me.label19.TabIndex = 35
        Me.label19.Text = "Top"
        '
        'label20
        '
        Me.label20.AutoSize = True
        Me.label20.Location = New System.Drawing.Point(13, 56)
        Me.label20.Name = "label20"
        Me.label20.Size = New System.Drawing.Size(44, 12)
        Me.label20.TabIndex = 34
        Me.label20.Text = "Enable"
        '
        'tbPointTop
        '
        Me.tbPointTop.Location = New System.Drawing.Point(67, 105)
        Me.tbPointTop.Name = "tbPointTop"
        Me.tbPointTop.Size = New System.Drawing.Size(121, 21)
        Me.tbPointTop.TabIndex = 37
        '
        'tbPointLeft
        '
        Me.tbPointLeft.Location = New System.Drawing.Point(67, 78)
        Me.tbPointLeft.Name = "tbPointLeft"
        Me.tbPointLeft.Size = New System.Drawing.Size(121, 21)
        Me.tbPointLeft.TabIndex = 29
        '
        'cbPointEnable
        '
        Me.cbPointEnable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPointEnable.FormattingEnabled = True
        Me.cbPointEnable.Location = New System.Drawing.Point(67, 52)
        Me.cbPointEnable.Name = "cbPointEnable"
        Me.cbPointEnable.Size = New System.Drawing.Size(121, 20)
        Me.cbPointEnable.TabIndex = 36
        '
        'cbPointSelect
        '
        Me.cbPointSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPointSelect.FormattingEnabled = True
        Me.cbPointSelect.Location = New System.Drawing.Point(67, 26)
        Me.cbPointSelect.Name = "cbPointSelect"
        Me.cbPointSelect.Size = New System.Drawing.Size(121, 20)
        Me.cbPointSelect.TabIndex = 30
        '
        'label21
        '
        Me.label21.AutoSize = True
        Me.label21.Location = New System.Drawing.Point(13, 82)
        Me.label21.Name = "label21"
        Me.label21.Size = New System.Drawing.Size(25, 12)
        Me.label21.TabIndex = 33
        Me.label21.Text = "Left"
        '
        'groupBox5
        '
        Me.groupBox5.Controls.Add(Me.btnGetPoint)
        Me.groupBox5.Controls.Add(Me.tbPointTemperature)
        Me.groupBox5.Controls.Add(Me.label23)
        Me.groupBox5.Controls.Add(Me.btnSetPoint)
        Me.groupBox5.Controls.Add(Me.tbPointTop)
        Me.groupBox5.Controls.Add(Me.tbPointLeft)
        Me.groupBox5.Controls.Add(Me.cbPointEnable)
        Me.groupBox5.Controls.Add(Me.cbPointSelect)
        Me.groupBox5.Controls.Add(Me.label19)
        Me.groupBox5.Controls.Add(Me.label20)
        Me.groupBox5.Controls.Add(Me.label21)
        Me.groupBox5.Controls.Add(Me.label22)
        Me.groupBox5.Location = New System.Drawing.Point(211, 283)
        Me.groupBox5.Name = "groupBox5"
        Me.groupBox5.Size = New System.Drawing.Size(197, 418)
        Me.groupBox5.TabIndex = 16
        Me.groupBox5.TabStop = False
        Me.groupBox5.Text = "Point Temperature"
        '
        'PopupThermalForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(628, 714)
        Me.Controls.Add(Me.groupBox3)
        Me.Controls.Add(Me.groupBox4)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.groupBox6)
        Me.Controls.Add(Me.groupBox5)
        Me.Name = "PopupThermalForm"
        Me.Text = "PopupThermalForm"
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        Me.groupBox4.ResumeLayout(False)
        Me.groupBox4.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.groupBox6.ResumeLayout(False)
        Me.groupBox6.PerformLayout()
        Me.groupBox5.ResumeLayout(False)
        Me.groupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents btnSetDetect As System.Windows.Forms.Button
    Private WithEvents cbAlarmDetectOutputPolarity As System.Windows.Forms.ComboBox
    Private WithEvents cbAlarmDetectOutputEnable As System.Windows.Forms.ComboBox
    Private WithEvents tbAlarmDetectStopDelay As System.Windows.Forms.TextBox
    Private WithEvents tbAlarmDetectStartDelay As System.Windows.Forms.TextBox
    Private WithEvents tbAlarmDetectPixelCnt As System.Windows.Forms.TextBox
    Private WithEvents label12 As System.Windows.Forms.Label
    Private WithEvents label11 As System.Windows.Forms.Label
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents btnSetPrivacy As System.Windows.Forms.Button
    Private WithEvents btnReqNUC As System.Windows.Forms.Button
    Private WithEvents btnSetNuc As System.Windows.Forms.Button
    Private WithEvents tbPointTemperature As System.Windows.Forms.TextBox
    Private WithEvents cbPrivacySelect As System.Windows.Forms.ComboBox
    Private WithEvents tbNucAutoTemperature As System.Windows.Forms.TextBox
    Private WithEvents label18 As System.Windows.Forms.Label
    Private WithEvents btnSetPoint As System.Windows.Forms.Button
    Private WithEvents label17 As System.Windows.Forms.Label
    Private WithEvents tbNucAutoTime As System.Windows.Forms.TextBox
    Private WithEvents label16 As System.Windows.Forms.Label
    Private WithEvents label23 As System.Windows.Forms.Label
    Private WithEvents btnGetPoint As System.Windows.Forms.Button
    Private WithEvents groupBox4 As System.Windows.Forms.GroupBox
    Private WithEvents tbPrivacyHeight As System.Windows.Forms.TextBox
    Private WithEvents tbPrivacyWidth As System.Windows.Forms.TextBox
    Private WithEvents tbPrivacyTop As System.Windows.Forms.TextBox
    Private WithEvents tbPrivacyLeft As System.Windows.Forms.TextBox
    Private WithEvents cbPrivacyEnable As System.Windows.Forms.ComboBox
    Private WithEvents label15 As System.Windows.Forms.Label
    Private WithEvents label14 As System.Windows.Forms.Label
    Private WithEvents label13 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents cbNucMode As System.Windows.Forms.ComboBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents cbAlarmStatus As System.Windows.Forms.ComboBox
    Private WithEvents btnGetAlarm As System.Windows.Forms.Button
    Private WithEvents label34 As System.Windows.Forms.Label
    Private WithEvents label22 As System.Windows.Forms.Label
    Private WithEvents cbAlarmColor As System.Windows.Forms.ComboBox
    Private WithEvents label33 As System.Windows.Forms.Label
    Private WithEvents tbAlarmTemperature As System.Windows.Forms.TextBox
    Private WithEvents label32 As System.Windows.Forms.Label
    Private WithEvents label31 As System.Windows.Forms.Label
    Private WithEvents cbAlarmTransparency As System.Windows.Forms.ComboBox
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents btnSetPalette As System.Windows.Forms.Button
    Private WithEvents cbPalette As System.Windows.Forms.ComboBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents groupBox6 As System.Windows.Forms.GroupBox
    Private WithEvents cbAlarmCondition As System.Windows.Forms.ComboBox
    Private WithEvents label30 As System.Windows.Forms.Label
    Private WithEvents btnSetAlarm As System.Windows.Forms.Button
    Private WithEvents tbAlarmHeight As System.Windows.Forms.TextBox
    Private WithEvents tbAlarmWidth As System.Windows.Forms.TextBox
    Private WithEvents tbAlarmTop As System.Windows.Forms.TextBox
    Private WithEvents tbAlarmLeft As System.Windows.Forms.TextBox
    Private WithEvents cbAlarmEnable As System.Windows.Forms.ComboBox
    Private WithEvents cbAlarmSelect As System.Windows.Forms.ComboBox
    Private WithEvents label24 As System.Windows.Forms.Label
    Private WithEvents label25 As System.Windows.Forms.Label
    Private WithEvents label26 As System.Windows.Forms.Label
    Private WithEvents label27 As System.Windows.Forms.Label
    Private WithEvents label28 As System.Windows.Forms.Label
    Private WithEvents label29 As System.Windows.Forms.Label
    Private WithEvents label19 As System.Windows.Forms.Label
    Private WithEvents label20 As System.Windows.Forms.Label
    Private WithEvents tbPointTop As System.Windows.Forms.TextBox
    Private WithEvents tbPointLeft As System.Windows.Forms.TextBox
    Private WithEvents cbPointEnable As System.Windows.Forms.ComboBox
    Private WithEvents cbPointSelect As System.Windows.Forms.ComboBox
    Private WithEvents label21 As System.Windows.Forms.Label
    Private WithEvents groupBox5 As System.Windows.Forms.GroupBox
End Class
