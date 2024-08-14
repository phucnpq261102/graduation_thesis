Imports NeptuneCSample_VBNET.NeptuneC_Interface

Public Class PopupFeatureForm
    Private m_refMainForm As NeptuneCSampleForm = Nothing

    Private m_arrMapping() As ENeptuneFeature = {
        ENeptuneFeature.NEPTUNE_FEATURE_GAMMA,
        ENeptuneFeature.NEPTUNE_FEATURE_GAIN,
        ENeptuneFeature.NEPTUNE_FEATURE_RGAIN,
        ENeptuneFeature.NEPTUNE_FEATURE_GGAIN,
        ENeptuneFeature.NEPTUNE_FEATURE_BGAIN,
        ENeptuneFeature.NEPTUNE_FEATURE_AUTOGAIN_MIN,
        ENeptuneFeature.NEPTUNE_FEATURE_AUTOGAIN_MAX,
        ENeptuneFeature.NEPTUNE_FEATURE_SHUTTER,
        ENeptuneFeature.NEPTUNE_FEATURE_AUTOSHUTTER_MIN,
        ENeptuneFeature.NEPTUNE_FEATURE_AUTOSHUTTER_MAX,
        ENeptuneFeature.NEPTUNE_FEATURE_AUTOEXPOSURE,
        ENeptuneFeature.NEPTUNE_FEATURE_BLACKLEVEL,
        ENeptuneFeature.NEPTUNE_FEATURE_CONTRAST,
        ENeptuneFeature.NEPTUNE_FEATURE_HUE,
        ENeptuneFeature.NEPTUNE_FEATURE_SATURATION,
        ENeptuneFeature.NEPTUNE_FEATURE_SHARPNESS,
        ENeptuneFeature.NEPTUNE_FEATURE_TRIGNOISEFILTER,
        ENeptuneFeature.NEPTUNE_FEATURE_BRIGHTLEVELIRIS,
        ENeptuneFeature.NEPTUNE_FEATURE_SNOWNOISEREMOVE,
        ENeptuneFeature.NEPTUNE_FEATURE_OPTFILTER,
        ENeptuneFeature.NEPTUNE_FEATURE_PAN,
        ENeptuneFeature.NEPTUNE_FEATURE_TILT,
        ENeptuneFeature.NEPTUNE_FEATURE_LCD_BLUE_GAIN,
        ENeptuneFeature.NEPTUNE_FEATURE_LCD_RED_GAIN,
        ENeptuneFeature.NEPTUNE_FEATURE_WHITEBALANCE
    }

    Private m_arrFeatureInfo() As NEPTUNE_FEATURE

    Private m_arrCheckBox() As CheckBox

    Private m_arrTriackBar() As TrackBar

    Private m_arrNumUpDown() As NumericUpDown

    Private m_arrLabelRange() As Label

    Public Sub New(ByVal refMainForm As NeptuneCSampleForm)
        MyBase.New()
        InitializeComponent()
        Me.m_refMainForm = refMainForm
    End Sub

    Private Sub InitControls()
        Me.m_arrFeatureInfo = New NEPTUNE_FEATURE(Me.m_arrMapping.Length - 1) {}
        Me.m_arrCheckBox = New CheckBox(((Me.m_arrMapping.Length - 1)) - 1) {}
        Me.m_arrTriackBar = New TrackBar(((Me.m_arrMapping.Length - 1)) - 1) {}
        Me.m_arrNumUpDown = New NumericUpDown(((Me.m_arrMapping.Length - 1)) - 1) {}
        Me.m_arrLabelRange = New Label(((Me.m_arrMapping.Length - 1)) - 1) {}
        Dim i As Integer = 0
        For i = 0 To Me.m_arrMapping.Length - 2
            Me.m_arrCheckBox(i) = CType(Controls.Find(("checkBox" + i.ToString), True)(0), CheckBox)
            Me.m_arrTriackBar(i) = CType(Controls.Find(("trackBar" + i.ToString), False)(0), TrackBar)
            Me.m_arrNumUpDown(i) = CType(Controls.Find(("numericUpDown" + i.ToString), True)(0), NumericUpDown)
            Me.m_arrLabelRange(i) = CType(Controls.Find(("labelRange" + i.ToString), True)(0), Label)
        Next
    End Sub

    Public Sub UpdateForm()
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim i As Integer = 0
            For i = 0 To Me.m_arrMapping.Length - 1
                If (Me.m_arrMapping(i) = ENeptuneFeature.NEPTUNE_FEATURE_GAMMA) Then

                    Dim stNodeInfo As NEPTUNE_XML_NODE_INFO = New NEPTUNE_XML_NODE_INFO
                    NeptuneC.ntcGetNodeInfo(Me.m_refMainForm.m_pCameraHandle, "Gamma", stNodeInfo)
                    If (stNodeInfo.Type = ENeptuneNodeType.NEPTUNE_NODE_TYPE_INT) Then
                        Dim stIntValue As NEPTUNE_XML_INT_VALUE_INFO = New NEPTUNE_XML_INT_VALUE_INFO
                        If (NeptuneC.ntcGetNodeInt(Me.m_refMainForm.m_pCameraHandle, "Gamma", stIntValue) = ENeptuneError.NEPTUNE_ERR_Success) Then
                            Me.m_arrTriackBar(i).SetRange(stIntValue.nMin, stIntValue.nMax)
                            Me.m_arrTriackBar(i).Value = stIntValue.nValue
                            Me.m_arrTriackBar(i).Enabled = ((stIntValue.AccessMode = ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_RW) _
                                        OrElse (stIntValue.AccessMode = ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_WO))
                            Me.m_arrNumUpDown(i).Minimum = stIntValue.nMin
                            Me.m_arrNumUpDown(i).Maximum = stIntValue.nMax
                            Me.m_arrNumUpDown(i).Value = stIntValue.nValue
                            Me.m_arrNumUpDown(i).Enabled = ((stIntValue.AccessMode = ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_RW) _
                                        OrElse (stIntValue.AccessMode = ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_WO))
                            Me.m_arrLabelRange(i).Text = ("(" _
                                        + (stIntValue.nMin.ToString() + (" ~ " _
                                        + (stIntValue.nMax.ToString() + ")"))))
                        Else
                            Me.m_arrTriackBar(i).Enabled = False
                            Me.m_arrNumUpDown(i).Enabled = False
                            Me.m_arrLabelRange(i).Enabled = False
                        End If
                    Else
                        Dim stFloatValue As NEPTUNE_XML_FLOAT_VALUE_INFO = New NEPTUNE_XML_FLOAT_VALUE_INFO
                        If (NeptuneC.ntcGetNodeFloat(Me.m_refMainForm.m_pCameraHandle, "Gamma", stFloatValue) = ENeptuneError.NEPTUNE_ERR_Success) Then
                            Me.m_arrTriackBar(i).SetRange(stFloatValue.dMin * 1000, stFloatValue.dMax * 1000)
                            Me.m_arrTriackBar(i).Value = stFloatValue.dValue * 1000
                            Me.m_arrTriackBar(i).Enabled = ((stFloatValue.AccessMode = ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_RW) _
                                        OrElse (stFloatValue.AccessMode = ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_WO))
                            Me.m_arrNumUpDown(i).DecimalPlaces = 3
                            Me.m_arrNumUpDown(i).Increment = stFloatValue.dInc
                            Me.m_arrNumUpDown(i).Minimum = stFloatValue.dMin
                            Me.m_arrNumUpDown(i).Maximum = stFloatValue.dMax
                            Me.m_arrNumUpDown(i).Value = stFloatValue.dValue
                            Me.m_arrNumUpDown(i).Enabled = ((stFloatValue.AccessMode = ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_RW) _
                                        OrElse (stFloatValue.AccessMode = ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_WO))
                            Me.m_arrLabelRange(i).Text = ("(" _
                                        + (stFloatValue.dMin.ToString() + (" ~ " _
                                        + (stFloatValue.dMax.ToString() + ")"))))
                        Else
                            Me.m_arrTriackBar(i).Enabled = False
                            Me.m_arrNumUpDown(i).Enabled = False
                            Me.m_arrLabelRange(i).Enabled = False
                        End If
                    End If
                    Me.m_arrCheckBox(i).Visible = False

                Else

                    If (Me.m_arrMapping(i) = ENeptuneFeature.NEPTUNE_FEATURE_WHITEBALANCE) Then
                        m_cbWhiteBal.Enabled = True
                    Else
                        Me.m_arrCheckBox(i).Visible = True
                        Me.m_arrTriackBar(i).Enabled = True
                        Me.m_arrNumUpDown(i).Enabled = True
                        Me.m_arrLabelRange(i).Enabled = True
                    End If

                    If (NeptuneC.ntcGetFeature(Me.m_refMainForm.m_pCameraHandle, Me.m_arrMapping(i), Me.m_arrFeatureInfo(i)) = ENeptuneError.NEPTUNE_ERR_Success) Then
                        If (Me.m_arrMapping(i) = ENeptuneFeature.NEPTUNE_FEATURE_WHITEBALANCE) Then
                            m_cbWhiteBal.Items.Clear()
                            If ((Me.m_arrFeatureInfo(i).SupportAutoModes And 1) _
                                        = 1) Then
                                m_cbWhiteBal.Items.Add("Off")
                            End If

                            If ((Me.m_arrFeatureInfo(i).SupportAutoModes And 2) _
                                        = 2) Then
                                m_cbWhiteBal.Items.Add("Once")
                            End If

                            If ((Me.m_arrFeatureInfo(i).SupportAutoModes And 4) _
                                        = 4) Then
                                m_cbWhiteBal.Items.Add("Continuous")
                            End If

                            m_cbWhiteBal.SelectedIndex = CType(Me.m_arrFeatureInfo(i).AutoMode, Integer)
                        Else
                            If ((Me.m_arrFeatureInfo(i).SupportAutoModes <> 0) _
                                        AndAlso ((Me.m_arrMapping(i) <> ENeptuneFeature.NEPTUNE_FEATURE_RGAIN) _
                                        AndAlso ((Me.m_arrMapping(i) <> ENeptuneFeature.NEPTUNE_FEATURE_GGAIN) _
                                        AndAlso (Me.m_arrMapping(i) <> ENeptuneFeature.NEPTUNE_FEATURE_BGAIN)))) Then
                                If Me.m_arrFeatureInfo(i).AutoMode = ENeptuneAutoMode.NEPTUNE_AUTO_CONTINUOUS Then
                                    Me.m_arrCheckBox(i).Checked = True
                                Else
                                    Me.m_arrCheckBox(i).Checked = False
                                End If
                            Else
                                Me.m_arrCheckBox(i).Visible = False
                            End If

                            If (Me.m_arrFeatureInfo(i).Value <> -1) Then
                                Me.m_arrTriackBar(i).SetRange(Me.m_arrFeatureInfo(i).Min, Me.m_arrFeatureInfo(i).Max)
                                Me.m_arrTriackBar(i).Value = Me.m_arrFeatureInfo(i).Value
                                Me.m_arrTriackBar(i).Enabled = ((Me.m_arrFeatureInfo(i).ValueAccessMode = ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_RW) _
                                            OrElse (Me.m_arrFeatureInfo(i).ValueAccessMode = ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_WO))
                                Me.m_arrNumUpDown(i).Minimum = Me.m_arrFeatureInfo(i).Min
                                Me.m_arrNumUpDown(i).Maximum = Me.m_arrFeatureInfo(i).Max
                                Me.m_arrNumUpDown(i).Value = Me.m_arrFeatureInfo(i).Value
                                Me.m_arrNumUpDown(i).Enabled = ((Me.m_arrFeatureInfo(i).ValueAccessMode = ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_RW) _
                                            OrElse (Me.m_arrFeatureInfo(i).ValueAccessMode = ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_WO))
                                Me.m_arrLabelRange(i).Text = ("(" _
                                            + (Me.m_arrFeatureInfo(i).Min.ToString() + (" ~ " _
                                            + (Me.m_arrFeatureInfo(i).Max.ToString() + ")"))))
                            Else
                                Me.m_arrTriackBar(i).Enabled = False
                                Me.m_arrNumUpDown(i).Enabled = False
                                Me.m_arrLabelRange(i).Enabled = False
                            End If

                        End If

                    ElseIf (Me.m_arrMapping(i) = ENeptuneFeature.NEPTUNE_FEATURE_WHITEBALANCE) Then
                        m_cbWhiteBal.Enabled = False
                    Else
                        Me.m_arrCheckBox(i).Visible = False
                        Me.m_arrTriackBar(i).Enabled = False
                        Me.m_arrNumUpDown(i).Enabled = False
                        Me.m_arrLabelRange(i).Enabled = False
                    End If

                End If
                
            Next

            Me.checkBox0_Click(checkBox1, Nothing)
            Me.checkBox0_Click(checkBox7, Nothing)

            Dim j As Integer = 0
            For j = 0 To Me.m_arrMapping.Length - 2
                If ((Me.m_arrMapping(j) = ENeptuneFeature.NEPTUNE_FEATURE_RGAIN) _
                            OrElse ((Me.m_arrMapping(j) = ENeptuneFeature.NEPTUNE_FEATURE_GGAIN) _
                            OrElse (Me.m_arrMapping(j) = ENeptuneFeature.NEPTUNE_FEATURE_BGAIN))) Then
                    Dim stInfoEx As NEPTUNE_FEATURE = New NEPTUNE_FEATURE
                    NeptuneC.ntcGetFeature(Me.m_refMainForm.m_pCameraHandle, Me.m_arrMapping(j), stInfoEx)
                    Dim bIsAccess As Boolean = ((stInfoEx.ValueAccessMode = ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_RW) _
                            OrElse (stInfoEx.ValueAccessMode = ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_WO))
                    Me.m_arrTriackBar(j).Enabled = bIsAccess
                    Me.m_arrNumUpDown(j).Enabled = bIsAccess
                End If
            Next

        End If

    End Sub

    Private Sub PopupFeatureForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.InitControls()
        Me.UpdateForm()
    End Sub

    Private Sub PopupFeatureForm_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.m_refMainForm.m_formPopupFeature = Nothing
    End Sub


    Private Sub checkBox0_Click(sender As System.Object, e As System.EventArgs) Handles checkBox0.Click, checkBox9.Click, checkBox8.Click, checkBox7.Click, checkBox6.Click, checkBox5.Click, checkBox4.Click, checkBox3.Click, checkBox23.Click, checkBox22.Click, checkBox21.Click, checkBox20.Click, checkBox2.Click, checkBox19.Click, checkBox18.Click, checkBox17.Click, checkBox16.Click, checkBox15.Click, checkBox14.Click, checkBox13.Click, checkBox12.Click, checkBox11.Click, checkBox10.Click, checkBox1.Click
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim i As Integer = 0

            For i = 0 To Me.m_arrMapping.Length - 2
                If Equals(Me.m_arrCheckBox(i), sender) = True Then
                    Dim stInfo As NEPTUNE_FEATURE = New NEPTUNE_FEATURE
                    stInfo = Me.m_arrFeatureInfo(i)

                    If Me.m_arrCheckBox(i).Checked = True Then
                        stInfo.AutoMode = ENeptuneAutoMode.NEPTUNE_AUTO_CONTINUOUS
                    Else
                        NeptuneC.ntcGetFeature(Me.m_refMainForm.m_pCameraHandle, Me.m_arrMapping(i), stInfo)
                        stInfo.AutoMode = ENeptuneAutoMode.NEPTUNE_AUTO_OFF

                        Dim bIsAvailable As Boolean = True
                        If stInfo.ValueAccessMode = ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_NI Or stInfo.ValueAccessMode = ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_UNDEFINED Then
                            bIsAvailable = False
                        End If

                        If bIsAvailable Then
                            Me.m_arrTriackBar(i).Value = stInfo.Value
                            Me.m_arrNumUpDown(i).Value = stInfo.Value
                        End If

                        End If

                        Dim emErr As ENeptuneError = NeptuneC.ntcSetFeature(Me.m_refMainForm.m_pCameraHandle, Me.m_arrMapping(i), stInfo)
                        If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                            Me.m_arrFeatureInfo(i) = stInfo
                            Dim bEnable As Boolean = (Me.m_arrFeatureInfo(i).AutoMode = ENeptuneAutoMode.NEPTUNE_AUTO_OFF)
                            Me.m_arrTriackBar(i).Enabled = bEnable
                            Me.m_arrNumUpDown(i).Enabled = bEnable
                        Else
                            If Me.m_arrFeatureInfo(i).AutoMode = ENeptuneAutoMode.NEPTUNE_AUTO_CONTINUOUS Then
                                Me.m_arrCheckBox(i).Checked = True
                            Else
                                Me.m_arrCheckBox(i).Checked = False
                            End If

                            Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetFeature Failed.", emErr)
                        End If

                        Exit For
                End If
            Next
        End If
    End Sub

    Private Sub trackBar0_MouseCaptureChanged(sender As System.Object, e As System.EventArgs) Handles trackBar0.MouseCaptureChanged, trackBar9.MouseCaptureChanged, trackBar8.MouseCaptureChanged, trackBar7.MouseCaptureChanged, trackBar6.MouseCaptureChanged, trackBar5.MouseCaptureChanged, trackBar4.MouseCaptureChanged, trackBar3.MouseCaptureChanged, trackBar22.MouseCaptureChanged, trackBar21.MouseCaptureChanged, trackBar20.MouseCaptureChanged, trackBar2.MouseCaptureChanged, trackBar19.MouseCaptureChanged, trackBar18.MouseCaptureChanged, trackBar17.MouseCaptureChanged, trackBar16.MouseCaptureChanged, trackBar15.MouseCaptureChanged, trackBar14.MouseCaptureChanged, trackBar13.MouseCaptureChanged, trackBar12.MouseCaptureChanged, trackBar11.MouseCaptureChanged, trackBar10.MouseCaptureChanged, trackBar1.MouseCaptureChanged
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim i As Integer = 0

            For i = 0 To Me.m_arrMapping.Length - 2
                If Equals(Me.m_arrTriackBar(i), sender) = True Then

                    If (Me.m_arrMapping(i) = ENeptuneFeature.NEPTUNE_FEATURE_GAMMA) Then

                        Dim stNodeInfo As NEPTUNE_XML_NODE_INFO = New NEPTUNE_XML_NODE_INFO
                        NeptuneC.ntcGetNodeInfo(Me.m_refMainForm.m_pCameraHandle, "Gamma", stNodeInfo)
                        If (stNodeInfo.Type = ENeptuneNodeType.NEPTUNE_NODE_TYPE_INT) Then
                            NeptuneC.ntcSetNodeInt(Me.m_refMainForm.m_pCameraHandle, "Gamma", Me.m_arrTriackBar(i).Value)
                            Me.m_arrNumUpDown(i).Value = Me.m_arrTriackBar(i).Value
                        Else
                            Dim dbGamma As Double = Me.m_arrTriackBar(i).Value / 1000.0
                            NeptuneC.ntcSetNodeFloat(Me.m_refMainForm.m_pCameraHandle, "Gamma", dbGamma)
                            Me.m_arrNumUpDown(i).Value = dbGamma
                        End If

                    Else

                        Dim stInfo As NEPTUNE_FEATURE = New NEPTUNE_FEATURE
                        stInfo = Me.m_arrFeatureInfo(i)
                        stInfo.Value = Me.m_arrTriackBar(i).Value
                        Dim emErr As ENeptuneError = NeptuneC.ntcSetFeature(Me.m_refMainForm.m_pCameraHandle, Me.m_arrMapping(i), stInfo)
                        If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                            Me.m_arrFeatureInfo(i) = stInfo
                            Me.m_arrNumUpDown(i).Value = Me.m_arrFeatureInfo(i).Value
                        Else
                            Me.m_arrTriackBar(i).Value = Me.m_arrFeatureInfo(i).Value
                            Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetFeature Failed.", emErr)
                        End If

                    End If

                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub numericUpDown0_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles numericUpDown0.KeyDown, numericUpDown9.KeyDown, numericUpDown8.KeyDown, numericUpDown7.KeyDown, numericUpDown6.KeyDown, numericUpDown5.KeyDown, numericUpDown4.KeyDown, numericUpDown3.KeyDown, numericUpDown23.KeyDown, numericUpDown22.KeyDown, numericUpDown21.KeyDown, numericUpDown20.KeyDown, numericUpDown2.KeyDown, numericUpDown19.KeyDown, numericUpDown18.KeyDown, numericUpDown17.KeyDown, numericUpDown16.KeyDown, numericUpDown15.KeyDown, numericUpDown14.KeyDown, numericUpDown13.KeyDown, numericUpDown12.KeyDown, numericUpDown11.KeyDown, numericUpDown10.KeyDown, numericUpDown1.KeyDown
        If (e.KeyValue = CType(Keys.Enter, Int32)) Then
            If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
                Dim i As Integer = 0

                For i = 0 To Me.m_arrMapping.Length - 2
                    If Equals(Me.m_arrNumUpDown(i), sender) = True Then

                        If (Me.m_arrMapping(i) = ENeptuneFeature.NEPTUNE_FEATURE_GAMMA) Then

                            Dim stNodeInfo As NEPTUNE_XML_NODE_INFO = New NEPTUNE_XML_NODE_INFO
                            NeptuneC.ntcGetNodeInfo(Me.m_refMainForm.m_pCameraHandle, "Gamma", stNodeInfo)
                            If (stNodeInfo.Type = ENeptuneNodeType.NEPTUNE_NODE_TYPE_INT) Then
                                NeptuneC.ntcSetNodeInt(Me.m_refMainForm.m_pCameraHandle, "Gamma", Me.m_arrNumUpDown(i).Value)
                                Me.m_arrTriackBar(i).Value = Me.m_arrNumUpDown(i).Value
                            Else
                                NeptuneC.ntcSetNodeFloat(Me.m_refMainForm.m_pCameraHandle, "Gamma", Me.m_arrNumUpDown(i).Value)
                                Me.m_arrTriackBar(i).Value = Me.m_arrNumUpDown(i).Value * 1000
                            End If

                        Else

                            Dim stInfo As NEPTUNE_FEATURE = New NEPTUNE_FEATURE
                            stInfo = Me.m_arrFeatureInfo(i)
                            stInfo.Value = CType(Me.m_arrNumUpDown(i).Value, Integer)
                            Dim emErr As ENeptuneError = NeptuneC.ntcSetFeature(Me.m_refMainForm.m_pCameraHandle, Me.m_arrMapping(i), stInfo)
                            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                                Me.m_arrFeatureInfo(i) = stInfo
                                Me.m_arrTriackBar(i).Value = Me.m_arrFeatureInfo(i).Value
                            Else
                                Me.m_arrNumUpDown(i).Value = Me.m_arrFeatureInfo(i).Value
                                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetFeature Failed.", emErr)
                            End If

                        End If

                        Exit For
                    End If
                Next
            End If

        End If
    End Sub

    Private Sub numericUpDown0_Click(sender As System.Object, e As System.EventArgs) Handles numericUpDown0.Click, numericUpDown9.Click, numericUpDown8.Click, numericUpDown7.Click, numericUpDown6.Click, numericUpDown5.Click, numericUpDown4.Click, numericUpDown3.Click, numericUpDown23.Click, numericUpDown22.Click, numericUpDown21.Click, numericUpDown20.Click, numericUpDown2.Click, numericUpDown19.Click, numericUpDown18.Click, numericUpDown17.Click, numericUpDown16.Click, numericUpDown15.Click, numericUpDown14.Click, numericUpDown13.Click, numericUpDown12.Click, numericUpDown11.Click, numericUpDown10.Click, numericUpDown1.Click
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim i As Integer = 0

            For i = 0 To Me.m_arrMapping.Length - 2
                If Equals(Me.m_arrNumUpDown(i), sender) = True Then

                    If (Me.m_arrMapping(i) = ENeptuneFeature.NEPTUNE_FEATURE_GAMMA) Then

                        Dim stNodeInfo As NEPTUNE_XML_NODE_INFO = New NEPTUNE_XML_NODE_INFO
                        NeptuneC.ntcGetNodeInfo(Me.m_refMainForm.m_pCameraHandle, "Gamma", stNodeInfo)
                        If (stNodeInfo.Type = ENeptuneNodeType.NEPTUNE_NODE_TYPE_INT) Then
                            NeptuneC.ntcSetNodeInt(Me.m_refMainForm.m_pCameraHandle, "Gamma", Me.m_arrNumUpDown(i).Value)
                            Me.m_arrTriackBar(i).Value = Me.m_arrNumUpDown(i).Value
                        Else
                            NeptuneC.ntcSetNodeFloat(Me.m_refMainForm.m_pCameraHandle, "Gamma", Me.m_arrNumUpDown(i).Value)
                            Me.m_arrTriackBar(i).Value = Me.m_arrNumUpDown(i).Value * 1000
                        End If

                    Else

                        Dim stInfo As NEPTUNE_FEATURE = New NEPTUNE_FEATURE
                        stInfo = Me.m_arrFeatureInfo(i)
                        stInfo.Value = CType(Me.m_arrNumUpDown(i).Value, Integer)
                        Dim emErr As ENeptuneError = NeptuneC.ntcSetFeature(Me.m_refMainForm.m_pCameraHandle, Me.m_arrMapping(i), stInfo)
                        If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                            Me.m_arrFeatureInfo(i) = stInfo
                            Me.m_arrTriackBar(i).Value = Me.m_arrFeatureInfo(i).Value
                        Else
                            Me.m_arrNumUpDown(i).Value = Me.m_arrFeatureInfo(i).Value
                            Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetFeature Failed.", emErr)
                        End If

                    End If

                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub m_cbWhiteBal_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles m_cbWhiteBal.SelectedIndexChanged
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim stInfo As NEPTUNE_FEATURE = New NEPTUNE_FEATURE
            stInfo = Me.m_arrFeatureInfo((Me.m_arrMapping.Length - 1))
            stInfo.AutoMode = CType(m_cbWhiteBal.SelectedIndex, ENeptuneAutoMode)
            If (stInfo.AutoMode <> Me.m_arrFeatureInfo((Me.m_arrMapping.Length - 1)).AutoMode) Then
                Dim emErr As ENeptuneError = NeptuneC.ntcSetFeature(Me.m_refMainForm.m_pCameraHandle, Me.m_arrMapping((Me.m_arrMapping.Length - 1)), stInfo)
                If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                    If (stInfo.AutoMode = ENeptuneAutoMode.NEPTUNE_AUTO_ONCE) Then
                        stInfo.AutoMode = ENeptuneAutoMode.NEPTUNE_AUTO_OFF
                        m_cbWhiteBal.SelectedIndex = CType(stInfo.AutoMode, Integer)
                    End If

                    Me.m_arrFeatureInfo((Me.m_arrMapping.Length - 1)) = stInfo

                    Dim j As Integer = 0
                    For j = 0 To Me.m_arrMapping.Length - 2
                        If ((Me.m_arrMapping(j) = ENeptuneFeature.NEPTUNE_FEATURE_RGAIN) _
                                    OrElse ((Me.m_arrMapping(j) = ENeptuneFeature.NEPTUNE_FEATURE_GGAIN) _
                                    OrElse (Me.m_arrMapping(j) = ENeptuneFeature.NEPTUNE_FEATURE_BGAIN))) Then
                            Dim stInfoEx As NEPTUNE_FEATURE = New NEPTUNE_FEATURE
                            NeptuneC.ntcGetFeature(Me.m_refMainForm.m_pCameraHandle, Me.m_arrMapping(j), stInfoEx)
                            Dim bIsAccess As Boolean = ((stInfoEx.ValueAccessMode = ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_RW) _
                                    OrElse (stInfoEx.ValueAccessMode = ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_WO))
                            Me.m_arrTriackBar(j).Enabled = bIsAccess
                            Me.m_arrNumUpDown(j).Enabled = bIsAccess
                        End If
                    Next

                Else
                    m_cbWhiteBal.SelectedIndex = CType(Me.m_arrFeatureInfo((Me.m_arrMapping.Length - 1)).AutoMode, Integer)
                    Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetFeature Failed.", emErr)
                End If

            End If

        End If
    End Sub

    Private Sub button1_Click(sender As System.Object, e As System.EventArgs) Handles button1.Click
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim stUserSet As NEPTUNE_USERSET = New NEPTUNE_USERSET
            stUserSet.Command = ENeptuneUserSetCommand.NEPTUNE_USERSET_CMD_LOAD
            stUserSet.UserSetIndex = ENeptuneUserSet.NEPTUNE_USERSET_DEFAULT
            Dim emErr As ENeptuneError = NeptuneC.ntcSetUserSet(Me.m_refMainForm.m_pCameraHandle, stUserSet)
            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                Me.UpdateForm()
            Else
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetUserSet Failed.", emErr)
            End If

        End If
    End Sub
End Class