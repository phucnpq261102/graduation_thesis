<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NeptuneCSampleForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NeptuneCSampleForm))
        Me.m_btnClearList = New System.Windows.Forms.Button()
        Me.m_btnUserSet = New System.Windows.Forms.Button()
        Me.m_btnLUT = New System.Windows.Forms.Button()
        Me.m_btnSIOControl = New System.Windows.Forms.Button()
        Me.m_btnFrameSave = New System.Windows.Forms.Button()
        Me.m_btnResolution = New System.Windows.Forms.Button()
        Me.m_btnAutoFocus = New System.Windows.Forms.Button()
        Me.m_ckAutoScroll = New System.Windows.Forms.CheckBox()
        Me.m_btnFeature = New System.Windows.Forms.Button()
        Me.m_btnCapture = New System.Windows.Forms.Button()
        Me.m_TimerReceiveFPS = New System.Windows.Forms.Timer(Me.components)
        Me.m_btnControl = New System.Windows.Forms.Button()
        Me.label12 = New System.Windows.Forms.Label()
        Me.groupBox5 = New System.Windows.Forms.GroupBox()
        Me.label11 = New System.Windows.Forms.Label()
        Me.label10 = New System.Windows.Forms.Label()
        Me.m_btnShot = New System.Windows.Forms.Button()
        Me.m_edMultiShotCnt = New System.Windows.Forms.NumericUpDown()
        Me.label9 = New System.Windows.Forms.Label()
        Me.m_cbAcquisitionMode = New System.Windows.Forms.ComboBox()
        Me.label8 = New System.Windows.Forms.Label()
        Me.m_btnPlay = New System.Windows.Forms.Button()
        Me.m_btnStop = New System.Windows.Forms.Button()
        Me.groupBox4 = New System.Windows.Forms.GroupBox()
        Me.m_btnStackedROI = New System.Windows.Forms.Button()
        Me.m_btnATLLedControl = New System.Windows.Forms.Button()
        Me.m_btnThermalControl = New System.Windows.Forms.Button()
        Me.m_btnStrobe = New System.Windows.Forms.Button()
        Me.m_btnGrab = New System.Windows.Forms.Button()
        Me.m_btnTrigger = New System.Windows.Forms.Button()
        Me.m_stcDisplayWnd = New System.Windows.Forms.PictureBox()
        Me.m_ckMirror = New System.Windows.Forms.CheckBox()
        Me.m_ckFlip = New System.Windows.Forms.CheckBox()
        Me.m_ckFit = New System.Windows.Forms.CheckBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.m_cbBayerLayout = New System.Windows.Forms.ComboBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.m_btnRefresh = New System.Windows.Forms.Button()
        Me.m_cbPixelFormat = New System.Windows.Forms.ComboBox()
        Me.m_cbCameraList = New System.Windows.Forms.ComboBox()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.m_cbBayerConvert = New System.Windows.Forms.ComboBox()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.label6 = New System.Windows.Forms.Label()
        Me.m_stcReceiveFps = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.label7 = New System.Windows.Forms.Label()
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.m_stcReceiveFrame = New System.Windows.Forms.Label()
        Me.m_btnFpsApply = New System.Windows.Forms.Button()
        Me.m_edFPS = New System.Windows.Forms.TextBox()
        Me.m_cb1394FPS = New System.Windows.Forms.ComboBox()
        Me.m_listLog = New System.Windows.Forms.ListView()
        Me.m_TimerReceiveFrame = New System.Windows.Forms.Timer(Me.components)
        Me.groupBox5.SuspendLayout()
        CType(Me.m_edMultiShotCnt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox4.SuspendLayout()
        CType(Me.m_stcDisplayWnd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'm_btnClearList
        '
        Me.m_btnClearList.Location = New System.Drawing.Point(711, 543)
        Me.m_btnClearList.Name = "m_btnClearList"
        Me.m_btnClearList.Size = New System.Drawing.Size(75, 23)
        Me.m_btnClearList.TabIndex = 16
        Me.m_btnClearList.Text = "Clear"
        Me.m_btnClearList.UseVisualStyleBackColor = True
        '
        'm_btnUserSet
        '
        Me.m_btnUserSet.Location = New System.Drawing.Point(6, 313)
        Me.m_btnUserSet.Name = "m_btnUserSet"
        Me.m_btnUserSet.Size = New System.Drawing.Size(123, 23)
        Me.m_btnUserSet.TabIndex = 8
        Me.m_btnUserSet.Text = "User Set"
        Me.m_btnUserSet.UseVisualStyleBackColor = True
        '
        'm_btnLUT
        '
        Me.m_btnLUT.Location = New System.Drawing.Point(6, 385)
        Me.m_btnLUT.Name = "m_btnLUT"
        Me.m_btnLUT.Size = New System.Drawing.Size(123, 23)
        Me.m_btnLUT.TabIndex = 10
        Me.m_btnLUT.Text = "Look Up Table"
        Me.m_btnLUT.UseVisualStyleBackColor = True
        '
        'm_btnSIOControl
        '
        Me.m_btnSIOControl.Location = New System.Drawing.Point(6, 349)
        Me.m_btnSIOControl.Name = "m_btnSIOControl"
        Me.m_btnSIOControl.Size = New System.Drawing.Size(123, 23)
        Me.m_btnSIOControl.TabIndex = 9
        Me.m_btnSIOControl.Text = "SIO Control"
        Me.m_btnSIOControl.UseVisualStyleBackColor = True
        '
        'm_btnFrameSave
        '
        Me.m_btnFrameSave.Location = New System.Drawing.Point(7, 421)
        Me.m_btnFrameSave.Name = "m_btnFrameSave"
        Me.m_btnFrameSave.Size = New System.Drawing.Size(123, 23)
        Me.m_btnFrameSave.TabIndex = 11
        Me.m_btnFrameSave.Text = "1394 FrameSave"
        Me.m_btnFrameSave.UseVisualStyleBackColor = True
        '
        'm_btnResolution
        '
        Me.m_btnResolution.Location = New System.Drawing.Point(6, 169)
        Me.m_btnResolution.Name = "m_btnResolution"
        Me.m_btnResolution.Size = New System.Drawing.Size(123, 23)
        Me.m_btnResolution.TabIndex = 4
        Me.m_btnResolution.Text = "Resolution"
        Me.m_btnResolution.UseVisualStyleBackColor = True
        '
        'm_btnAutoFocus
        '
        Me.m_btnAutoFocus.Location = New System.Drawing.Point(6, 277)
        Me.m_btnAutoFocus.Name = "m_btnAutoFocus"
        Me.m_btnAutoFocus.Size = New System.Drawing.Size(123, 23)
        Me.m_btnAutoFocus.TabIndex = 7
        Me.m_btnAutoFocus.Text = "Auto Focus"
        Me.m_btnAutoFocus.UseVisualStyleBackColor = True
        '
        'm_ckAutoScroll
        '
        Me.m_ckAutoScroll.AutoSize = True
        Me.m_ckAutoScroll.Location = New System.Drawing.Point(711, 504)
        Me.m_ckAutoScroll.Name = "m_ckAutoScroll"
        Me.m_ckAutoScroll.Size = New System.Drawing.Size(85, 16)
        Me.m_ckAutoScroll.TabIndex = 15
        Me.m_ckAutoScroll.Text = "Auto Scroll"
        Me.m_ckAutoScroll.UseVisualStyleBackColor = True
        '
        'm_btnFeature
        '
        Me.m_btnFeature.Location = New System.Drawing.Point(6, 61)
        Me.m_btnFeature.Name = "m_btnFeature"
        Me.m_btnFeature.Size = New System.Drawing.Size(123, 23)
        Me.m_btnFeature.TabIndex = 1
        Me.m_btnFeature.Text = "Feature"
        Me.m_btnFeature.UseVisualStyleBackColor = True
        '
        'm_btnCapture
        '
        Me.m_btnCapture.Location = New System.Drawing.Point(6, 97)
        Me.m_btnCapture.Name = "m_btnCapture"
        Me.m_btnCapture.Size = New System.Drawing.Size(123, 23)
        Me.m_btnCapture.TabIndex = 2
        Me.m_btnCapture.Text = "Capture"
        Me.m_btnCapture.UseVisualStyleBackColor = True
        '
        'm_TimerReceiveFPS
        '
        Me.m_TimerReceiveFPS.Enabled = True
        Me.m_TimerReceiveFPS.Interval = 1000
        '
        'm_btnControl
        '
        Me.m_btnControl.Location = New System.Drawing.Point(7, 25)
        Me.m_btnControl.Name = "m_btnControl"
        Me.m_btnControl.Size = New System.Drawing.Size(123, 23)
        Me.m_btnControl.TabIndex = 0
        Me.m_btnControl.Text = "Control Dialog"
        Me.m_btnControl.UseVisualStyleBackColor = True
        '
        'label12
        '
        Me.label12.AutoSize = True
        Me.label12.Location = New System.Drawing.Point(6, 104)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(90, 12)
        Me.label12.TabIndex = 8
        Me.label12.Text = "One/Multi Shot"
        '
        'groupBox5
        '
        Me.groupBox5.Controls.Add(Me.label12)
        Me.groupBox5.Controls.Add(Me.label11)
        Me.groupBox5.Controls.Add(Me.label10)
        Me.groupBox5.Controls.Add(Me.m_btnShot)
        Me.groupBox5.Controls.Add(Me.m_edMultiShotCnt)
        Me.groupBox5.Controls.Add(Me.label9)
        Me.groupBox5.Controls.Add(Me.m_cbAcquisitionMode)
        Me.groupBox5.Controls.Add(Me.label8)
        Me.groupBox5.Controls.Add(Me.m_btnPlay)
        Me.groupBox5.Controls.Add(Me.m_btnStop)
        Me.groupBox5.Location = New System.Drawing.Point(498, 320)
        Me.groupBox5.Name = "groupBox5"
        Me.groupBox5.Size = New System.Drawing.Size(298, 135)
        Me.groupBox5.TabIndex = 13
        Me.groupBox5.TabStop = False
        Me.groupBox5.Text = "Acquisition"
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(223, 79)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(68, 12)
        Me.label11.TabIndex = 7
        Me.label11.Text = "(1 ~ 65535)"
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Location = New System.Drawing.Point(6, 78)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(100, 12)
        Me.label10.TabIndex = 5
        Me.label10.Text = "Multi-Shot Count"
        '
        'm_btnShot
        '
        Me.m_btnShot.Location = New System.Drawing.Point(124, 100)
        Me.m_btnShot.Name = "m_btnShot"
        Me.m_btnShot.Size = New System.Drawing.Size(167, 23)
        Me.m_btnShot.TabIndex = 9
        Me.m_btnShot.Text = "Shot"
        Me.m_btnShot.UseVisualStyleBackColor = True
        '
        'm_edMultiShotCnt
        '
        Me.m_edMultiShotCnt.Location = New System.Drawing.Point(124, 75)
        Me.m_edMultiShotCnt.Name = "m_edMultiShotCnt"
        Me.m_edMultiShotCnt.Size = New System.Drawing.Size(92, 21)
        Me.m_edMultiShotCnt.TabIndex = 6
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(6, 52)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(103, 12)
        Me.label9.TabIndex = 3
        Me.label9.Text = "Acquisition Mode"
        '
        'm_cbAcquisitionMode
        '
        Me.m_cbAcquisitionMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.m_cbAcquisitionMode.FormattingEnabled = True
        Me.m_cbAcquisitionMode.Location = New System.Drawing.Point(124, 49)
        Me.m_cbAcquisitionMode.Name = "m_cbAcquisitionMode"
        Me.m_cbAcquisitionMode.Size = New System.Drawing.Size(168, 20)
        Me.m_cbAcquisitionMode.TabIndex = 4
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(6, 26)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(99, 12)
        Me.label8.TabIndex = 0
        Me.label8.Text = "Acquisition State"
        '
        'm_btnPlay
        '
        Me.m_btnPlay.Location = New System.Drawing.Point(124, 21)
        Me.m_btnPlay.Name = "m_btnPlay"
        Me.m_btnPlay.Size = New System.Drawing.Size(75, 23)
        Me.m_btnPlay.TabIndex = 1
        Me.m_btnPlay.Text = "Start"
        Me.m_btnPlay.UseVisualStyleBackColor = True
        '
        'm_btnStop
        '
        Me.m_btnStop.Location = New System.Drawing.Point(217, 21)
        Me.m_btnStop.Name = "m_btnStop"
        Me.m_btnStop.Size = New System.Drawing.Size(75, 23)
        Me.m_btnStop.TabIndex = 2
        Me.m_btnStop.Text = "Stop"
        Me.m_btnStop.UseVisualStyleBackColor = True
        '
        'groupBox4
        '
        Me.groupBox4.Controls.Add(Me.m_btnStackedROI)
        Me.groupBox4.Controls.Add(Me.m_btnATLLedControl)
        Me.groupBox4.Controls.Add(Me.m_btnThermalControl)
        Me.groupBox4.Controls.Add(Me.m_btnUserSet)
        Me.groupBox4.Controls.Add(Me.m_btnLUT)
        Me.groupBox4.Controls.Add(Me.m_btnSIOControl)
        Me.groupBox4.Controls.Add(Me.m_btnFrameSave)
        Me.groupBox4.Controls.Add(Me.m_btnAutoFocus)
        Me.groupBox4.Controls.Add(Me.m_btnResolution)
        Me.groupBox4.Controls.Add(Me.m_btnFeature)
        Me.groupBox4.Controls.Add(Me.m_btnCapture)
        Me.groupBox4.Controls.Add(Me.m_btnControl)
        Me.groupBox4.Controls.Add(Me.m_btnStrobe)
        Me.groupBox4.Controls.Add(Me.m_btnGrab)
        Me.groupBox4.Controls.Add(Me.m_btnTrigger)
        Me.groupBox4.Location = New System.Drawing.Point(814, 12)
        Me.groupBox4.Name = "groupBox4"
        Me.groupBox4.Size = New System.Drawing.Size(136, 575)
        Me.groupBox4.TabIndex = 14
        Me.groupBox4.TabStop = False
        Me.groupBox4.Text = "Settings"
        '
        'm_btnStackedROI
        '
        Me.m_btnStackedROI.Location = New System.Drawing.Point(7, 529)
        Me.m_btnStackedROI.Name = "m_btnStackedROI"
        Me.m_btnStackedROI.Size = New System.Drawing.Size(123, 23)
        Me.m_btnStackedROI.TabIndex = 16
        Me.m_btnStackedROI.Text = "Stacked ROI Control"
        Me.m_btnStackedROI.UseVisualStyleBackColor = True
        '
        'm_btnATLLedControl
        '
        Me.m_btnATLLedControl.Location = New System.Drawing.Point(7, 493)
        Me.m_btnATLLedControl.Name = "m_btnATLLedControl"
        Me.m_btnATLLedControl.Size = New System.Drawing.Size(123, 23)
        Me.m_btnATLLedControl.TabIndex = 15
        Me.m_btnATLLedControl.Text = "ATL LED Control"
        Me.m_btnATLLedControl.UseVisualStyleBackColor = True
        '
        'm_btnThermalControl
        '
        Me.m_btnThermalControl.Location = New System.Drawing.Point(7, 457)
        Me.m_btnThermalControl.Name = "m_btnThermalControl"
        Me.m_btnThermalControl.Size = New System.Drawing.Size(123, 23)
        Me.m_btnThermalControl.TabIndex = 14
        Me.m_btnThermalControl.Text = "Thermal Control"
        Me.m_btnThermalControl.UseVisualStyleBackColor = True
        '
        'm_btnStrobe
        '
        Me.m_btnStrobe.Location = New System.Drawing.Point(6, 241)
        Me.m_btnStrobe.Name = "m_btnStrobe"
        Me.m_btnStrobe.Size = New System.Drawing.Size(123, 23)
        Me.m_btnStrobe.TabIndex = 6
        Me.m_btnStrobe.Text = "Strobe"
        Me.m_btnStrobe.UseVisualStyleBackColor = True
        '
        'm_btnGrab
        '
        Me.m_btnGrab.Location = New System.Drawing.Point(6, 133)
        Me.m_btnGrab.Name = "m_btnGrab"
        Me.m_btnGrab.Size = New System.Drawing.Size(123, 23)
        Me.m_btnGrab.TabIndex = 3
        Me.m_btnGrab.Text = "Grab"
        Me.m_btnGrab.UseVisualStyleBackColor = True
        '
        'm_btnTrigger
        '
        Me.m_btnTrigger.Location = New System.Drawing.Point(6, 205)
        Me.m_btnTrigger.Name = "m_btnTrigger"
        Me.m_btnTrigger.Size = New System.Drawing.Size(123, 23)
        Me.m_btnTrigger.TabIndex = 5
        Me.m_btnTrigger.Text = "Trigger"
        Me.m_btnTrigger.UseVisualStyleBackColor = True
        '
        'm_stcDisplayWnd
        '
        Me.m_stcDisplayWnd.Location = New System.Drawing.Point(12, 12)
        Me.m_stcDisplayWnd.Name = "m_stcDisplayWnd"
        Me.m_stcDisplayWnd.Size = New System.Drawing.Size(480, 440)
        Me.m_stcDisplayWnd.TabIndex = 9
        Me.m_stcDisplayWnd.TabStop = False
        '
        'm_ckMirror
        '
        Me.m_ckMirror.AutoSize = True
        Me.m_ckMirror.Location = New System.Drawing.Point(235, 103)
        Me.m_ckMirror.Name = "m_ckMirror"
        Me.m_ckMirror.Size = New System.Drawing.Size(57, 16)
        Me.m_ckMirror.TabIndex = 9
        Me.m_ckMirror.Text = "Mirror"
        Me.m_ckMirror.UseVisualStyleBackColor = True
        '
        'm_ckFlip
        '
        Me.m_ckFlip.AutoSize = True
        Me.m_ckFlip.Location = New System.Drawing.Point(176, 103)
        Me.m_ckFlip.Name = "m_ckFlip"
        Me.m_ckFlip.Size = New System.Drawing.Size(44, 16)
        Me.m_ckFlip.TabIndex = 8
        Me.m_ckFlip.Text = "Flip"
        Me.m_ckFlip.UseVisualStyleBackColor = True
        '
        'm_ckFit
        '
        Me.m_ckFit.AutoSize = True
        Me.m_ckFit.Location = New System.Drawing.Point(124, 103)
        Me.m_ckFit.Name = "m_ckFit"
        Me.m_ckFit.Size = New System.Drawing.Size(37, 16)
        Me.m_ckFit.TabIndex = 7
        Me.m_ckFit.Text = "Fit"
        Me.m_ckFit.UseVisualStyleBackColor = True
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(6, 104)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(83, 12)
        Me.label4.TabIndex = 6
        Me.label4.Text = "Display Mode"
        '
        'm_cbBayerLayout
        '
        Me.m_cbBayerLayout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.m_cbBayerLayout.FormattingEnabled = True
        Me.m_cbBayerLayout.Location = New System.Drawing.Point(124, 75)
        Me.m_cbBayerLayout.Name = "m_cbBayerLayout"
        Me.m_cbBayerLayout.Size = New System.Drawing.Size(168, 20)
        Me.m_cbBayerLayout.TabIndex = 5
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(6, 78)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(80, 12)
        Me.label3.TabIndex = 4
        Me.label3.Text = "Bayer Layout"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(6, 52)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(106, 12)
        Me.label2.TabIndex = 2
        Me.label2.Text = "Bayer Conversion"
        '
        'm_btnRefresh
        '
        Me.m_btnRefresh.Image = CType(resources.GetObject("m_btnRefresh.Image"), System.Drawing.Image)
        Me.m_btnRefresh.Location = New System.Drawing.Point(267, 18)
        Me.m_btnRefresh.Name = "m_btnRefresh"
        Me.m_btnRefresh.Size = New System.Drawing.Size(25, 22)
        Me.m_btnRefresh.TabIndex = 1
        Me.m_btnRefresh.UseVisualStyleBackColor = True
        '
        'm_cbPixelFormat
        '
        Me.m_cbPixelFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.m_cbPixelFormat.FormattingEnabled = True
        Me.m_cbPixelFormat.Location = New System.Drawing.Point(124, 23)
        Me.m_cbPixelFormat.Name = "m_cbPixelFormat"
        Me.m_cbPixelFormat.Size = New System.Drawing.Size(168, 20)
        Me.m_cbPixelFormat.TabIndex = 1
        '
        'm_cbCameraList
        '
        Me.m_cbCameraList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.m_cbCameraList.FormattingEnabled = True
        Me.m_cbCameraList.Location = New System.Drawing.Point(6, 20)
        Me.m_cbCameraList.Name = "m_cbCameraList"
        Me.m_cbCameraList.Size = New System.Drawing.Size(255, 20)
        Me.m_cbCameraList.TabIndex = 0
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.m_ckMirror)
        Me.groupBox2.Controls.Add(Me.m_ckFlip)
        Me.groupBox2.Controls.Add(Me.m_ckFit)
        Me.groupBox2.Controls.Add(Me.label4)
        Me.groupBox2.Controls.Add(Me.label3)
        Me.groupBox2.Controls.Add(Me.label2)
        Me.groupBox2.Controls.Add(Me.m_cbBayerLayout)
        Me.groupBox2.Controls.Add(Me.m_cbPixelFormat)
        Me.groupBox2.Controls.Add(Me.label1)
        Me.groupBox2.Controls.Add(Me.m_cbBayerConvert)
        Me.groupBox2.Location = New System.Drawing.Point(498, 70)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(298, 131)
        Me.groupBox2.TabIndex = 11
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Image Control"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(6, 26)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(76, 12)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Pixel Format"
        '
        'm_cbBayerConvert
        '
        Me.m_cbBayerConvert.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.m_cbBayerConvert.FormattingEnabled = True
        Me.m_cbBayerConvert.Location = New System.Drawing.Point(124, 49)
        Me.m_cbBayerConvert.Name = "m_cbBayerConvert"
        Me.m_cbBayerConvert.Size = New System.Drawing.Size(168, 20)
        Me.m_cbBayerConvert.TabIndex = 3
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.m_btnRefresh)
        Me.groupBox1.Controls.Add(Me.m_cbCameraList)
        Me.groupBox1.Location = New System.Drawing.Point(498, 12)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(298, 52)
        Me.groupBox1.TabIndex = 10
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Camera List"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(6, 52)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(33, 12)
        Me.label6.TabIndex = 2
        Me.label6.Text = "1394:"
        '
        'm_stcReceiveFps
        '
        Me.m_stcReceiveFps.AutoSize = True
        Me.m_stcReceiveFps.Location = New System.Drawing.Point(122, 26)
        Me.m_stcReceiveFps.Name = "m_stcReceiveFps"
        Me.m_stcReceiveFps.Size = New System.Drawing.Size(27, 12)
        Me.m_stcReceiveFps.TabIndex = 1
        Me.m_stcReceiveFps.Text = "0.00"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(6, 26)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(81, 12)
        Me.label5.TabIndex = 0
        Me.label5.Text = "Receive FPS:"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(6, 78)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(82, 12)
        Me.label7.TabIndex = 3
        Me.label7.Text = "GigE && USB3:"
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.m_stcReceiveFrame)
        Me.groupBox3.Controls.Add(Me.m_btnFpsApply)
        Me.groupBox3.Controls.Add(Me.m_edFPS)
        Me.groupBox3.Controls.Add(Me.m_cb1394FPS)
        Me.groupBox3.Controls.Add(Me.label7)
        Me.groupBox3.Controls.Add(Me.label6)
        Me.groupBox3.Controls.Add(Me.m_stcReceiveFps)
        Me.groupBox3.Controls.Add(Me.label5)
        Me.groupBox3.Location = New System.Drawing.Point(498, 207)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(298, 107)
        Me.groupBox3.TabIndex = 12
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Frame Rate"
        '
        'm_stcReceiveFrame
        '
        Me.m_stcReceiveFrame.AutoSize = True
        Me.m_stcReceiveFrame.Location = New System.Drawing.Point(222, 26)
        Me.m_stcReceiveFrame.Name = "m_stcReceiveFrame"
        Me.m_stcReceiveFrame.Size = New System.Drawing.Size(11, 12)
        Me.m_stcReceiveFrame.TabIndex = 7
        Me.m_stcReceiveFrame.Text = "0"
        '
        'm_btnFpsApply
        '
        Me.m_btnFpsApply.Location = New System.Drawing.Point(242, 49)
        Me.m_btnFpsApply.Name = "m_btnFpsApply"
        Me.m_btnFpsApply.Size = New System.Drawing.Size(50, 47)
        Me.m_btnFpsApply.TabIndex = 6
        Me.m_btnFpsApply.Text = "Apply"
        Me.m_btnFpsApply.UseVisualStyleBackColor = True
        '
        'm_edFPS
        '
        Me.m_edFPS.Location = New System.Drawing.Point(124, 75)
        Me.m_edFPS.Name = "m_edFPS"
        Me.m_edFPS.Size = New System.Drawing.Size(112, 21)
        Me.m_edFPS.TabIndex = 5
        '
        'm_cb1394FPS
        '
        Me.m_cb1394FPS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.m_cb1394FPS.FormattingEnabled = True
        Me.m_cb1394FPS.Location = New System.Drawing.Point(124, 49)
        Me.m_cb1394FPS.Name = "m_cb1394FPS"
        Me.m_cb1394FPS.Size = New System.Drawing.Size(112, 20)
        Me.m_cb1394FPS.TabIndex = 4
        '
        'm_listLog
        '
        Me.m_listLog.HideSelection = False
        Me.m_listLog.Location = New System.Drawing.Point(12, 461)
        Me.m_listLog.MultiSelect = False
        Me.m_listLog.Name = "m_listLog"
        Me.m_listLog.Size = New System.Drawing.Size(693, 126)
        Me.m_listLog.TabIndex = 17
        Me.m_listLog.UseCompatibleStateImageBehavior = False
        Me.m_listLog.View = System.Windows.Forms.View.Details
        '
        'm_TimerReceiveFrame
        '
        '
        'NeptuneCSampleForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(962, 599)
        Me.Controls.Add(Me.m_btnClearList)
        Me.Controls.Add(Me.m_ckAutoScroll)
        Me.Controls.Add(Me.groupBox5)
        Me.Controls.Add(Me.groupBox4)
        Me.Controls.Add(Me.m_stcDisplayWnd)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.groupBox3)
        Me.Controls.Add(Me.m_listLog)
        Me.Name = "NeptuneCSampleForm"
        Me.Text = "NeptuneCSample_VBNET"
        Me.groupBox5.ResumeLayout(False)
        Me.groupBox5.PerformLayout()
        CType(Me.m_edMultiShotCnt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox4.ResumeLayout(False)
        CType(Me.m_stcDisplayWnd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents m_btnClearList As System.Windows.Forms.Button
    Private WithEvents m_btnUserSet As System.Windows.Forms.Button
    Private WithEvents m_btnLUT As System.Windows.Forms.Button
    Private WithEvents m_btnSIOControl As System.Windows.Forms.Button
    Private WithEvents m_btnFrameSave As System.Windows.Forms.Button
    Private WithEvents m_btnResolution As System.Windows.Forms.Button
    Private WithEvents m_btnAutoFocus As System.Windows.Forms.Button
    Private WithEvents m_ckAutoScroll As System.Windows.Forms.CheckBox
    Private WithEvents m_btnFeature As System.Windows.Forms.Button
    Private WithEvents m_btnCapture As System.Windows.Forms.Button
    Private WithEvents m_TimerReceiveFPS As System.Windows.Forms.Timer
    Private WithEvents m_btnControl As System.Windows.Forms.Button
    Private WithEvents label12 As System.Windows.Forms.Label
    Private WithEvents groupBox5 As System.Windows.Forms.GroupBox
    Private WithEvents label11 As System.Windows.Forms.Label
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents m_btnShot As System.Windows.Forms.Button
    Private WithEvents m_edMultiShotCnt As System.Windows.Forms.NumericUpDown
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents m_cbAcquisitionMode As System.Windows.Forms.ComboBox
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents m_btnPlay As System.Windows.Forms.Button
    Private WithEvents m_btnStop As System.Windows.Forms.Button
    Private WithEvents groupBox4 As System.Windows.Forms.GroupBox
    Private WithEvents m_btnStrobe As System.Windows.Forms.Button
    Private WithEvents m_btnGrab As System.Windows.Forms.Button
    Private WithEvents m_btnTrigger As System.Windows.Forms.Button
    Private WithEvents m_stcDisplayWnd As System.Windows.Forms.PictureBox
    Private WithEvents m_ckMirror As System.Windows.Forms.CheckBox
    Private WithEvents m_ckFlip As System.Windows.Forms.CheckBox
    Private WithEvents m_ckFit As System.Windows.Forms.CheckBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents m_cbBayerLayout As System.Windows.Forms.ComboBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents m_btnRefresh As System.Windows.Forms.Button
    Private WithEvents m_cbPixelFormat As System.Windows.Forms.ComboBox
    Private WithEvents m_cbCameraList As System.Windows.Forms.ComboBox
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents m_cbBayerConvert As System.Windows.Forms.ComboBox
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents m_stcReceiveFps As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents m_btnFpsApply As System.Windows.Forms.Button
    Private WithEvents m_edFPS As System.Windows.Forms.TextBox
    Private WithEvents m_cb1394FPS As System.Windows.Forms.ComboBox
    Private WithEvents m_listLog As System.Windows.Forms.ListView
    Private WithEvents m_TimerReceiveFrame As System.Windows.Forms.Timer
    Private WithEvents m_stcReceiveFrame As System.Windows.Forms.Label
    Private WithEvents m_btnThermalControl As System.Windows.Forms.Button
    Private WithEvents m_btnATLLedControl As System.Windows.Forms.Button
    Private WithEvents m_btnStackedROI As System.Windows.Forms.Button
End Class
