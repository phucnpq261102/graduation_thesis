Imports NeptuneCSample_VBNET.NeptuneC_Interface

Public Class NeptuneCSampleForm
    Public m_pCameraHandle As IntPtr = IntPtr.Zero
    Private DeviceCheckCallbackInst As NeptuneC_Interface.NeptuneCDevCheckCallback
    Private DeviceUnplugCallbackInst As NeptuneC_Interface.NeptuneCUnplugCallback
    Private FrameCallbackInst As NeptuneC_Interface.NeptuneCFrameCallback
    Private FrameDropCallbackInst As NeptuneC_Interface.NeptuneCFrameDropCallback
    Public m_formPopupFeature As PopupFeatureForm = Nothing
    Public m_formPopupCapture As PopupCaptureForm = Nothing
    Public m_formPopupGrab As PopupGrabForm = Nothing
    Public m_formPopupResolution As PopupResolutionForm = Nothing
    Public m_formPopupTrigger As PopupTriggerForm = Nothing
    Public m_formPopupStrobe As PopupStrobeForm = Nothing
    Public m_formPopupAutoFocus As PopupAutoFocusForm = Nothing
    Public m_formPopupFrameSave As PopupFrameSaveForm = Nothing
    Public m_formPopupSIOControl As PopupSIOControlForm = Nothing
    Public m_formPopupLUT As PopupLUTForm = Nothing
    Public m_formPopupUserSet As PopupUserSetForm = Nothing
    Public m_formPopupThermal As PopupThermalForm = Nothing
    Public m_formPopupAltLed As PopupAltLedForm = Nothing
    Public m_formPopupStackedROI As PopupStackedROIForm = Nothing
    Private m_bFrameRateSupport As Boolean = True
    Private m_uiTotalFrameCount As UInt64 = 0

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.

    End Sub

    Private Sub DeviceCheckCallbackFunc(ByVal emState As ENeptuneDeviceChangeState, ByVal pContext As IntPtr)


        ' 크로스 스레드 작업 오류에 대한 임시방편
        CheckForIllegalCrossThreadCalls = False
        Me.InitCameraList()

        Dim strMsg As String

        If emState = ENeptuneDeviceChangeState.NEPTUNE_DEVICE_ADDED Then
            strMsg = "Device has been added."
        Else
            strMsg = "Device has been removed."
        End If

        Me.InsertLog(EM_LOG_LEVEL.TYPE_EVENT, strMsg)
    End Sub

    Private Sub NeptuneCSampleForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        m_listLog.Columns.Clear()
        m_listLog.Columns.Add("Time", 120)
        m_listLog.Columns.Add("Type", 80)
        m_listLog.Columns.Add("Message", 280)
        m_listLog.Columns.Add("Return", 200)
        m_listLog.FullRowSelect = True
        NeptuneC.ntcInit()
        Me.DeviceCheckCallbackInst = AddressOf DeviceCheckCallbackFunc
        Me.DeviceUnplugCallbackInst = AddressOf DeviceUnplugCallbackFunc
        Me.FrameCallbackInst = AddressOf FrameCallbackFunc
        NeptuneC.ntcSetDeviceCheckCallback(Me.DeviceCheckCallbackInst, Me.Handle)

        Me.InitFixedItemList()
        Me.InitCameraList()
        Me.UpdateControlActivate()
    End Sub

    Private Sub NeptuneCSampleForm_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.CloseCameraHandle()
        NeptuneC.ntcUninit()
    End Sub



    Private Sub DeviceUnplugCallbackFunc(ByVal pContext As IntPtr)
        ' l\? ?? ?? $X? \ ??)?
        CheckForIllegalCrossThreadCalls = False
        Me.InitCameraList()
        Me.InsertLog(EM_LOG_LEVEL.TYPE_EVENT, "Selected camera was unplugged.")
    End Sub

    Private Sub CloseCameraHandle()
        If (Me.m_pCameraHandle <> IntPtr.Zero) Then
            Dim bStatus As ENeptuneBoolean = ENeptuneBoolean.NEPTUNE_BOOL_FALSE
            If (NeptuneC.ntcGetAcquisition(Me.m_pCameraHandle, bStatus) = ENeptuneError.NEPTUNE_ERR_Success) Then
                If (bStatus = ENeptuneBoolean.NEPTUNE_BOOL_TRUE) Then
                    NeptuneC.ntcSetAcquisition(Me.m_pCameraHandle, ENeptuneBoolean.NEPTUNE_BOOL_FALSE)
                End If

            End If

            NeptuneC.ntcClose(Me.m_pCameraHandle)
            Me.m_pCameraHandle = IntPtr.Zero
        End If

    End Sub

    Public Sub UpdatePopupForms(ByVal bDelete As Boolean)
        If bDelete Then
            If (Not (Me.m_formPopupFeature) Is Nothing) Then
                Me.m_formPopupFeature.Close()
            End If

            If (Not (Me.m_formPopupCapture) Is Nothing) Then
                Me.m_formPopupCapture.Close()
            End If

            If (Not (Me.m_formPopupGrab) Is Nothing) Then
                Me.m_formPopupGrab.Close()
            End If

            If (Not (Me.m_formPopupResolution) Is Nothing) Then
                Me.m_formPopupResolution.Close()
            End If

            If (Not (Me.m_formPopupTrigger) Is Nothing) Then
                Me.m_formPopupTrigger.Close()
            End If

            If (Not (Me.m_formPopupStrobe) Is Nothing) Then
                Me.m_formPopupStrobe.Close()
            End If

            If (Not (Me.m_formPopupAutoFocus) Is Nothing) Then
                Me.m_formPopupAutoFocus.Close()
            End If

            If (Not (Me.m_formPopupFrameSave) Is Nothing) Then
                Me.m_formPopupFrameSave.Close()
            End If

            If (Not (Me.m_formPopupSIOControl) Is Nothing) Then
                Me.m_formPopupSIOControl.Close()
            End If

            If (Not (Me.m_formPopupLUT) Is Nothing) Then
                Me.m_formPopupLUT.Close()
            End If

            If (Not (Me.m_formPopupUserSet) Is Nothing) Then
                Me.m_formPopupUserSet.Close()
            End If

            If (Not (Me.m_formPopupThermal) Is Nothing) Then
                Me.m_formPopupThermal.Close()
            End If

            If (Not (Me.m_formPopupAltLed) Is Nothing) Then
                Me.m_formPopupAltLed.Close()
            End If

            If (Not (Me.m_formPopupStackedROI) Is Nothing) Then
                Me.m_formPopupStackedROI.Close()
            End If

        Else
            If (Not (Me.m_formPopupFeature) Is Nothing) Then
                Me.m_formPopupFeature.UpdateForm()
            End If

            If (Not (Me.m_formPopupCapture) Is Nothing) Then
                Me.m_formPopupCapture.UpdateForm()
            End If

            If (Not (Me.m_formPopupGrab) Is Nothing) Then
                Me.m_formPopupGrab.UpdateForm()
            End If

            If (Not (Me.m_formPopupResolution) Is Nothing) Then
                Me.m_formPopupResolution.UpdateForm()
            End If

            If (Not (Me.m_formPopupTrigger) Is Nothing) Then
                Me.m_formPopupTrigger.UpdateForm()
            End If

            If (Not (Me.m_formPopupStrobe) Is Nothing) Then
                Me.m_formPopupStrobe.UpdateForm()
            End If

            If (Not (Me.m_formPopupAutoFocus) Is Nothing) Then
                Me.m_formPopupAutoFocus.UpdateForm()
            End If

            If (Not (Me.m_formPopupFrameSave) Is Nothing) Then
                Me.m_formPopupFrameSave.UpdateForm()
            End If

            If (Not (Me.m_formPopupSIOControl) Is Nothing) Then
                Me.m_formPopupSIOControl.UpdateForm()
            End If

            If (Not (Me.m_formPopupLUT) Is Nothing) Then
                Me.m_formPopupLUT.UpdateForm()
            End If

            If (Not (Me.m_formPopupUserSet) Is Nothing) Then
                Me.m_formPopupUserSet.UpdateForm()
            End If

            If (Not (Me.m_formPopupThermal) Is Nothing) Then
                Me.m_formPopupThermal.UpdateForm()
            End If

            If (Not (Me.m_formPopupAltLed) Is Nothing) Then
                Me.m_formPopupAltLed.UpdateForm()
            End If

            If (Not (Me.m_formPopupStackedROI) Is Nothing) Then
                Me.m_formPopupStackedROI.UpdateForm()
            End If

        End If

    End Sub

    Private Function IsThermalType() As Boolean
        Dim bRet As Boolean = False

        Dim stNodeInfo As NEPTUNE_XML_NODE_INFO = New NEPTUNE_XML_NODE_INFO()
        If (NeptuneC.ntcGetNodeInfo(m_pCameraHandle, "Temperatures", stNodeInfo) = ENeptuneError.NEPTUNE_ERR_Success) Then
            bRet = True
        End If

        Return bRet
    End Function

    Private Function IsSupportStackedROI() As Boolean
        Dim bRet As Boolean = False

        Dim stNodeInfo As NEPTUNE_XML_NODE_INFO = New NEPTUNE_XML_NODE_INFO()
        If (NeptuneC.ntcGetNodeInfo(m_pCameraHandle, "StackedROIEnable", stNodeInfo) = ENeptuneError.NEPTUNE_ERR_Success) Then
            bRet = True
        End If

        Return bRet
    End Function

    Private Sub UpdateControlActivate()
        Dim bSelCam As Boolean = False
        Dim b1394Type As Boolean = False
        Dim bUsb3Type As Boolean = False
        Dim bPlay As Boolean = False
        Dim bContinuous As Boolean = False
        Dim bMultishot As Boolean = False
        Dim bIsThermal As Boolean = False
        Dim bSupportedSRoi As Boolean = False

        If (Me.m_pCameraHandle <> IntPtr.Zero) Then
            bSelCam = True
            Dim eDeviceType As ENeptuneDevType = ENeptuneDevType.NEPTUNE_DEV_TYPE_UNKNOWN
            If (NeptuneC.ntcGetCameraType(Me.m_pCameraHandle, eDeviceType) = ENeptuneError.NEPTUNE_ERR_Success) Then
                If eDeviceType = ENeptuneDevType.NEPTUNE_DEV_TYPE_1394 Then
                    b1394Type = True
                Else
                    b1394Type = False
                End If

                If eDeviceType = ENeptuneDevType.NEPTUNE_DEV_TYPE_USB3 Then
                    bUsb3Type = True
                Else
                    bUsb3Type = False
                End If
            End If

            Dim bStatus As ENeptuneBoolean = ENeptuneBoolean.NEPTUNE_BOOL_FALSE
            If (NeptuneC.ntcGetAcquisition(Me.m_pCameraHandle, bStatus) = ENeptuneError.NEPTUNE_ERR_Success) Then
                If bStatus = ENeptuneBoolean.NEPTUNE_BOOL_TRUE Then
                    bPlay = True
                Else
                    bPlay = False
                End If
            End If

            Dim emAcqMode As ENeptuneAcquisitionMode = ENeptuneAcquisitionMode.NEPTUNE_ACQ_CONTINUOUS
            Dim uiFrames As UInt32 = 0
            If (NeptuneC.ntcGetAcquisitionMode(Me.m_pCameraHandle, emAcqMode, uiFrames) = ENeptuneError.NEPTUNE_ERR_Success) Then
                If emAcqMode = ENeptuneAcquisitionMode.NEPTUNE_ACQ_CONTINUOUS Then
                    bContinuous = True
                Else
                    bContinuous = False
                End If

                If emAcqMode = ENeptuneAcquisitionMode.NEPTUNE_ACQ_MULTIFRAME Then
                    bMultishot = True
                Else
                    bMultishot = False
                End If
            End If

            bIsThermal = IsThermalType()

            bSupportedSRoi = IsSupportStackedROI()

        End If

        m_cbPixelFormat.Enabled = bSelCam
        m_cbBayerConvert.Enabled = bSelCam
        m_cbBayerLayout.Enabled = bSelCam
        m_ckFit.Enabled = True
        m_ckFlip.Enabled = bSelCam
        m_ckMirror.Enabled = bSelCam
        m_cb1394FPS.Enabled = (bSelCam _
                    AndAlso (Not bPlay _
                    AndAlso (b1394Type AndAlso Me.m_bFrameRateSupport)))
        m_edFPS.Enabled = (bSelCam _
                    AndAlso (Not bPlay _
                    AndAlso Not b1394Type))
        m_btnFpsApply.Enabled = (m_cb1394FPS.Enabled OrElse m_edFPS.Enabled)
        m_btnPlay.Enabled = (bSelCam _
                    AndAlso Not bPlay)
        m_btnStop.Enabled = (bSelCam AndAlso bPlay)
        m_cbAcquisitionMode.Enabled = bSelCam
        m_edMultiShotCnt.Enabled = (bSelCam AndAlso bMultishot)
        m_btnShot.Enabled = (bSelCam _
                    AndAlso (bPlay _
                    AndAlso Not bContinuous))
        m_btnControl.Enabled = bSelCam
        m_btnFeature.Enabled = bSelCam
        m_btnCapture.Enabled = bSelCam
        m_btnGrab.Enabled = bSelCam
        m_btnResolution.Enabled = bSelCam
        m_btnTrigger.Enabled = bSelCam
        m_btnStrobe.Enabled = bSelCam
        m_btnAutoFocus.Enabled = bSelCam
        m_btnUserSet.Enabled = bSelCam
        m_btnSIOControl.Enabled = bSelCam
        m_btnLUT.Enabled = bSelCam
        m_btnFrameSave.Enabled = (bSelCam AndAlso b1394Type)
        m_btnThermalControl.Enabled = (bSelCam AndAlso bIsThermal)
        m_btnATLLedControl.Enabled = (bSelCam AndAlso bUsb3Type)
        m_btnStackedROI.Enabled = (bSelCam AndAlso bSupportedSRoi)
    End Sub

    Private Sub InitFixedItemList()
        m_cbBayerConvert.Items.Clear()
        m_cbBayerConvert.Items.Add(New ItemData("None", CType(ENeptuneBayerMethod.NEPTUNE_BAYER_METHOD_NONE, Int32)))
        m_cbBayerConvert.Items.Add(New ItemData("Bilinear", CType(ENeptuneBayerMethod.NEPTUNE_BAYER_METHOD_BILINEAR, Int32)))
        m_cbBayerConvert.Items.Add(New ItemData("HQ", CType(ENeptuneBayerMethod.NEPTUNE_BAYER_METHOD_HQ, Int32)))
        m_cbBayerConvert.Items.Add(New ItemData("Nearest", CType(ENeptuneBayerMethod.NEPTUNE_BAYER_METHOD_NEAREST, Int32)))
        m_cbBayerLayout.Items.Clear()
        m_cbBayerLayout.Items.Add(New ItemData("GB/RG", CType(ENeptuneBayerLayout.NEPTUNE_BAYER_GB_RG, Int32)))
        m_cbBayerLayout.Items.Add(New ItemData("BG/GR", CType(ENeptuneBayerLayout.NEPTUNE_BAYER_BG_GR, Int32)))
        m_cbBayerLayout.Items.Add(New ItemData("RG/GB", CType(ENeptuneBayerLayout.NEPTUNE_BAYER_RG_GB, Int32)))
        m_cbBayerLayout.Items.Add(New ItemData("RG/BG", CType(ENeptuneBayerLayout.NEPTUNE_BAYER_GR_BG, Int32)))
        m_cbAcquisitionMode.Items.Clear()
        m_cbAcquisitionMode.Items.Add(New ItemData("Continuous", CType(ENeptuneAcquisitionMode.NEPTUNE_ACQ_CONTINUOUS, Int32)))
        m_cbAcquisitionMode.Items.Add(New ItemData("One-Shot", CType(ENeptuneAcquisitionMode.NEPTUNE_ACQ_SINGLEFRAME, Int32)))
        m_cbAcquisitionMode.Items.Add(New ItemData("Multi-Shot", CType(ENeptuneAcquisitionMode.NEPTUNE_ACQ_MULTIFRAME, Int32)))
        m_edMultiShotCnt.Minimum = 1
        m_edMultiShotCnt.Maximum = 65535
    End Sub

    Private Sub InitCameraList()
        Dim CurSelItem As ItemData = CType(m_cbCameraList.SelectedItem, ItemData)
        m_cbCameraList.Items.Clear()
        Dim uiCount As UInt32 = 0
        If (NeptuneC.ntcGetCameraCount(uiCount) = ENeptuneError.NEPTUNE_ERR_Success) Then
            If (uiCount > 0) Then
                Dim pCameraInfo(uiCount - 1) As NEPTUNE_CAM_INFO
                Dim emErr As ENeptuneError = NeptuneC.ntcGetCameraInfo(pCameraInfo, uiCount)
                If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                    Dim i As UInt32 = 0
                    For i = 0 To uiCount - 1
                        Dim nItem As Int32 = m_cbCameraList.Items.Add(New ItemData(pCameraInfo(i)))
                        If (Not (CurSelItem) Is Nothing) Then
                            If (CType(m_cbCameraList.Items(nItem), ItemData).m_stCameraInfo.strSerial.Equals(CurSelItem.m_stCameraInfo.strSerial) = True) Then
                                m_cbCameraList.SelectedIndex = nItem
                            End If

                        End If
                    Next
                Else
                    Me.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetCameraInfo Failed.", emErr)
                End If

            End If

        End If

        If ((Not (CurSelItem) Is Nothing) _
                    AndAlso (m_cbCameraList.SelectedIndex = -1)) Then
            m_TimerReceiveFrame.Stop()
            m_TimerReceiveFPS.Stop()
            Me.CloseCameraHandle()
            Me.UpdateControlActivate()
            Me.UpdatePopupForms(True)
        End If

    End Sub

    Private Sub InitPixelFormatList()
        m_cbPixelFormat.Items.Clear()
        If (Me.m_pCameraHandle <> IntPtr.Zero) Then
            Dim puiSize As UInt32 = 0
            NeptuneC.ntcGetPixelFormatList(Me.m_pCameraHandle, Nothing, puiSize)
            If (puiSize > 0) Then
                Dim emPixelList() As ENeptunePixelFormat = New ENeptunePixelFormat((puiSize) - 1) {}
                Dim emErr As ENeptuneError = NeptuneC.ntcGetPixelFormatList(Me.m_pCameraHandle, emPixelList, puiSize)
                If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                    Dim emCurPixelFormat As ENeptunePixelFormat = ENeptunePixelFormat.Unknown_PixelFormat
                    emErr = NeptuneC.ntcGetPixelFormat(Me.m_pCameraHandle, emCurPixelFormat)
                    If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                        Dim pOutString() As Char = New Char((64) - 1) {}

                        '                        Dim i As Int32 = 0
                        '                        For i = 0 To emPixelList.Length - 1
                        '                            Array.Clear(pOutString, 0, pOutString.Length)
                        '                            If (NeptuneC.ntcGetPixelFormatString(Me.m_pCameraHandle, emPixelList(i), pOutString, CType(pOutString.Length, UInt32)) = ENeptuneError.NEPTUNE_ERR_Success) Then
                        '                                Dim strLabel As String = New String(pOutString)
                        '                                Dim nItem As Int32 = m_cbPixelFormat.Items.Add(New ItemData(strLabel, CType(emPixelList(i), Int32)))
                        '                                If (emCurPixelFormat = emPixelList(i)) Then
                        '                                    m_cbPixelFormat.SelectedIndex = nItem
                        '                                End If
                        '
                        '                            End If
                        '                        Next

                        For Each emPixel As ENeptunePixelFormat In emPixelList
                            Array.Clear(pOutString, 0, pOutString.Length)
                            If (NeptuneC.ntcGetPixelFormatString(Me.m_pCameraHandle, emPixel, pOutString, CType(pOutString.Length, UInt32)) = ENeptuneError.NEPTUNE_ERR_Success) Then
                                Dim strLabel As String = New String(pOutString)
                                Dim nItem As Int32 = m_cbPixelFormat.Items.Add(New ItemData(strLabel, CType(emPixel, Int32)))
                                If (emCurPixelFormat = emPixel) Then
                                    m_cbPixelFormat.SelectedIndex = nItem
                                End If

                            End If
                        Next
                    Else
                        Me.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetPixelFormatList Failed.", emErr)
                    End If

                Else
                    Me.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetPixelFormatList Failed.", emErr)
                End If

            End If

        End If

    End Sub

    Private Sub InitBayerMethodList()
        If (Me.m_pCameraHandle <> IntPtr.Zero) Then
            Dim emMethod As ENeptuneBayerMethod = ENeptuneBayerMethod.NEPTUNE_BAYER_METHOD_NONE
            If (NeptuneC.ntcGetBayerConvert(Me.m_pCameraHandle, emMethod) = ENeptuneError.NEPTUNE_ERR_Success) Then
                Dim i As Int32 = 0
                For i = 0 To m_cbBayerConvert.Items.Count - 1
                    If (emMethod = CType(CType(m_cbBayerConvert.Items(i), ItemData).m_nValue, ENeptuneBayerMethod)) Then
                        m_cbBayerConvert.SelectedIndex = i
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub InitBayerLayoutList()
        If (Me.m_pCameraHandle <> IntPtr.Zero) Then
            Dim emLayout As ENeptuneBayerLayout = ENeptuneBayerLayout.NEPTUNE_BAYER_GB_RG
            If (NeptuneC.ntcGetBayerLayout(Me.m_pCameraHandle, emLayout) = ENeptuneError.NEPTUNE_ERR_Success) Then
                Dim i As Int32 = 0
                For i = 0 To m_cbBayerLayout.Items.Count - 1
                    If (emLayout = CType(CType(m_cbBayerLayout.Items(i), ItemData).m_nValue, ENeptuneBayerLayout)) Then
                        m_cbBayerLayout.SelectedIndex = i
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub InitEffectState()
        Dim emDisplayOpt As ENeptuneDisplayOption = ENeptuneDisplayOption.NEPTUNE_DISPLAY_OPTION_FIT
        NeptuneC.ntcGetDisplayOption(emDisplayOpt)
        m_ckFit.Checked = (emDisplayOpt = ENeptuneDisplayOption.NEPTUNE_DISPLAY_OPTION_FIT)
        If (Me.m_pCameraHandle <> IntPtr.Zero) Then
            Dim nEffectFlag As Int32 = 0
            If (NeptuneC.ntcGetEffect(Me.m_pCameraHandle, nEffectFlag) = ENeptuneError.NEPTUNE_ERR_Success) Then
                If (nEffectFlag And CType(ENeptuneEffect.NEPTUNE_EFFECT_FLIP, Int32)) = CType(ENeptuneEffect.NEPTUNE_EFFECT_FLIP, Int32) Then
                    m_ckFlip.Checked = True
                Else
                    m_ckFlip.Checked = False
                End If

                If (nEffectFlag And CType(ENeptuneEffect.NEPTUNE_EFFECT_MIRROR, Int32)) = CType(ENeptuneEffect.NEPTUNE_EFFECT_MIRROR, Int32) Then
                    m_ckMirror.Checked = True
                Else
                    m_ckMirror.Checked = False
                End If
            Else
                ' log
            End If

        End If

    End Sub

    Private Function IsFrameRateSupported() As Boolean
        Dim bRet As Boolean = True
        Dim emPixelFormat As ENeptunePixelFormat = ENeptunePixelFormat.Unknown_PixelFormat
        If (NeptuneC.ntcGetPixelFormat(Me.m_pCameraHandle, emPixelFormat) = ENeptuneError.NEPTUNE_ERR_Success) Then
            If ((emPixelFormat >= ENeptunePixelFormat.Format7_Mode0_Mono8) _
                        AndAlso (emPixelFormat <= ENeptunePixelFormat.Format7_Mode2_Raw12)) Then
                bRet = False
            End If

        End If

        Me.m_bFrameRateSupport = bRet
        Return bRet
    End Function

    Private Sub InitFrameRateList()
        m_cb1394FPS.Items.Clear()
        m_edFPS.Text = ""
        If (Me.m_pCameraHandle <> IntPtr.Zero) Then
            If Me.IsFrameRateSupported Then
                Dim em1394FPS As ENeptuneFrameRate = ENeptuneFrameRate.FPS_UNKNOWN
                Dim dbValue As Double = 0
                Dim emErr As ENeptuneError = NeptuneC.ntcGetFrameRate(Me.m_pCameraHandle, em1394FPS, dbValue)
                If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                    If ((em1394FPS = ENeptuneFrameRate.FPS_VALUE) _
                                OrElse (em1394FPS = ENeptuneFrameRate.FPS_UNKNOWN)) Then
                        m_edFPS.Text = dbValue.ToString
                    Else
                        Dim uiSize As UInt32 = 0
                        NeptuneC.ntcGetFrameRateList(Me.m_pCameraHandle, Nothing, uiSize)
                        If (uiSize > 0) Then
                            Dim p1394FpsList() As ENeptuneFrameRate = New ENeptuneFrameRate((uiSize) - 1) {}
                            emErr = NeptuneC.ntcGetFrameRateList(Me.m_pCameraHandle, p1394FpsList, uiSize)
                            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                                Dim pOutString() As Char = New Char((64) - 1) {}
                                '                                Dim i As Int32 = 0
                                '                                For i = 0 To p1394FpsList.Length - 1
                                '                                    Array.Clear(pOutString, 0, pOutString.Length)
                                '                                    If (NeptuneC.ntcGetFrameRateString(Me.m_pCameraHandle, p1394FpsList(i), pOutString, CType(pOutString.Length, UInt32)) = ENeptuneError.NEPTUNE_ERR_Success) Then
                                '                                        Dim strLabel As String = New String(pOutString)
                                '                                        Dim nItem As Int32 = m_cb1394FPS.Items.Add(New ItemData(strLabel, CType(p1394FpsList(i), Int32)))
                                '                                        If (em1394FPS = p1394FpsList(i)) Then
                                '                                            m_cb1394FPS.SelectedIndex = nItem
                                '                                        End If
                                '
                                '                                    End If
                                '                                Next

                                For Each emFps As ENeptuneFrameRate In p1394FpsList
                                    Array.Clear(pOutString, 0, pOutString.Length)
                                    If (NeptuneC.ntcGetFrameRateString(Me.m_pCameraHandle, emFps, pOutString, CType(pOutString.Length, UInt32)) = ENeptuneError.NEPTUNE_ERR_Success) Then
                                        Dim strLabel As String = New String(pOutString)
                                        Dim nItem As Int32 = m_cb1394FPS.Items.Add(New ItemData(strLabel, CType(emFps, Int32)))
                                        If (em1394FPS = emFps) Then
                                            m_cb1394FPS.SelectedIndex = nItem
                                        End If

                                    End If
                                Next
                            Else
                                Me.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetFrameRateList Failed.", emErr)
                            End If

                        End If

                    End If

                Else
                    Me.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetFrameRate Failed.", emErr)
                End If

            End If

        End If

    End Sub

    Private Sub InitAcquisitionMode()
        If (Me.m_pCameraHandle <> IntPtr.Zero) Then
            Dim emAcqMode As ENeptuneAcquisitionMode = ENeptuneAcquisitionMode.NEPTUNE_ACQ_CONTINUOUS
            Dim uiFrames As UInt32 = 0
            Dim emErr As ENeptuneError = NeptuneC.ntcGetAcquisitionMode(Me.m_pCameraHandle, emAcqMode, uiFrames)
            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                m_edMultiShotCnt.Value = uiFrames
                Dim i As Int32 = 0
                For i = 0 To m_cbAcquisitionMode.Items.Count - 1
                    If (emAcqMode = CType(CType(m_cbBayerLayout.Items(i), ItemData).m_nValue, ENeptuneAcquisitionMode)) Then
                        m_cbAcquisitionMode.SelectedIndex = i
                        Exit For
                    End If
                Next
            Else
                Me.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetAcquisitionMode Failed.", emErr)
            End If
        End If
    End Sub

    Public Sub InsertLog(ByVal emLogLevel As EM_LOG_LEVEL, ByVal strMessage As String, Optional ByVal emReturn As ENeptuneError = ENeptuneError.NEPTUNE_ERR_Success)
        Dim dt As DateTime = DateTime.Now
        Dim strItem As String = ""
        Select Case (emLogLevel)
            Case EM_LOG_LEVEL.TYPE_ERROR
                strItem = "Error"
            Case EM_LOG_LEVEL.TYPE_EVENT
                strItem = "Event"
            Case EM_LOG_LEVEL.TYPE_INFORMATION
                strItem = "Information"
        End Select

        Dim lvItem As ListViewItem = New ListViewItem(dt.ToString("MM/dd HH:mm:ss.fff"))
        lvItem.SubItems.Add(strItem)
        lvItem.SubItems.Add(strMessage)
        lvItem.SubItems.Add(emReturn.ToString)
        m_listLog.Items.Add(lvItem)
        If (m_ckAutoScroll.Checked = True) Then
            m_listLog.EnsureVisible((m_listLog.Items.Count - 1))
        End If

    End Sub

    Public Sub UpdateCameraInfo()
        Me.InitPixelFormatList()
        Me.InitBayerMethodList()
        Me.InitBayerLayoutList()
        Me.InitEffectState()
        Me.InitFrameRateList()
        Me.InitAcquisitionMode()
        Me.UpdateControlActivate()
        If m_cbCameraList.SelectedIndex = -1 Then
            Me.UpdatePopupForms(True)
        Else
            Me.UpdatePopupForms(False)
        End If
    End Sub

    Private Sub m_btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles m_btnRefresh.Click
        Me.InitCameraList()
    End Sub

    Private Sub m_cbCameraList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles m_cbCameraList.SelectedIndexChanged
        If CType(sender, ComboBox).Focused Then
            Me.CloseCameraHandle()
            If (m_cbCameraList.SelectedIndex <> -1) Then
                Dim emErr As ENeptuneError = NeptuneC.ntcOpen(CType(m_cbCameraList.SelectedItem, ItemData).m_stCameraInfo.strCamID, Me.m_pCameraHandle, ENeptuneDevAccess.NEPTUNE_DEV_ACCESS_EXCLUSIVE)
                If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                    NeptuneC.ntcSetDisplay(Me.m_pCameraHandle, m_stcDisplayWnd.Handle)
                    NeptuneC.ntcSetUnplugCallback(Me.m_pCameraHandle, Me.DeviceUnplugCallbackInst, Me.Handle)
                    NeptuneC.ntcSetFrameCallback(Me.m_pCameraHandle, Me.FrameCallbackInst, Me.Handle)
                Else
                    m_cbCameraList.SelectedIndex = -1
                    Me.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcOpen Failed.", emErr)
                End If

                Me.UpdateCameraInfo()
            End If

        End If
    End Sub

    Private Sub m_cbPixelFormat_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles m_cbPixelFormat.SelectedIndexChanged
        If CType(sender, ComboBox).Focused Then
            If ((m_cbPixelFormat.SelectedIndex <> -1) _
                        AndAlso (Me.m_pCameraHandle <> IntPtr.Zero)) Then
                Dim emErr As ENeptuneError = NeptuneC.ntcSetPixelFormat(Me.m_pCameraHandle, CType(CType(m_cbPixelFormat.SelectedItem, ItemData).m_nValue, ENeptunePixelFormat))
                If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                    Dim emDevType As ENeptuneDevType = ENeptuneDevType.NEPTUNE_DEV_TYPE_UNKNOWN
                    If (NeptuneC.ntcGetCameraType(Me.m_pCameraHandle, emDevType) = ENeptuneError.NEPTUNE_ERR_Success) Then
                        If (emDevType = ENeptuneDevType.NEPTUNE_DEV_TYPE_1394) Then
                            Me.InitFrameRateList()
                            Me.UpdateControlActivate()
                        End If

                    End If

                Else
                    Me.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetPixelFormat Failed.", emErr)
                End If

            End If

        End If
    End Sub

    Private Sub m_cbBayerConvert_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles m_cbBayerConvert.SelectedIndexChanged
        If CType(sender, ComboBox).Focused Then
            If ((m_cbBayerConvert.SelectedIndex <> -1) _
                        AndAlso (Me.m_pCameraHandle <> IntPtr.Zero)) Then
                Dim emErr As ENeptuneError = NeptuneC.ntcSetBayerConvert(Me.m_pCameraHandle, CType(CType(m_cbBayerConvert.SelectedItem, ItemData).m_nValue, ENeptuneBayerMethod))
                If (emErr <> ENeptuneError.NEPTUNE_ERR_Success) Then
                    Me.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetBayerConvert Failed.", emErr)
                End If

            End If

        End If
    End Sub

    Private Sub m_cbBayerLayout_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles m_cbBayerLayout.SelectedIndexChanged
        If CType(sender, ComboBox).Focused Then
            If ((m_cbBayerLayout.SelectedIndex <> -1) _
                        AndAlso (Me.m_pCameraHandle <> IntPtr.Zero)) Then
                Dim emErr As ENeptuneError = NeptuneC.ntcSetBayerLayout(Me.m_pCameraHandle, CType(CType(m_cbBayerLayout.SelectedItem, ItemData).m_nValue, ENeptuneBayerLayout))
                If (emErr <> ENeptuneError.NEPTUNE_ERR_Success) Then
                    Me.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetBayerLayout Failed.", emErr)
                End If

            End If

        End If
    End Sub

    Private Sub m_ckFit_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles m_ckFit.CheckedChanged
        Dim emOpt As ENeptuneDisplayOption

        If m_ckFit.Checked = True Then
            emOpt = ENeptuneDisplayOption.NEPTUNE_DISPLAY_OPTION_FIT
        Else
            emOpt = ENeptuneDisplayOption.NEPTUNE_DISPLAY_OPTION_ORIGINAL_CENTER
        End If

        Dim emErr As ENeptuneError = NeptuneC.ntcSetDisplayOption(emOpt)

        If (emErr <> ENeptuneError.NEPTUNE_ERR_Success) Then
            Me.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetDisplayOption Failed.", emErr)
        End If
    End Sub

    Private Sub m_ckFlip_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles m_ckFlip.CheckedChanged
        If (Me.m_pCameraHandle <> IntPtr.Zero) Then
            Dim nEffectFlags As Int32 = 0
            If (NeptuneC.ntcGetEffect(Me.m_pCameraHandle, nEffectFlags) = ENeptuneError.NEPTUNE_ERR_Success) Then
                If m_ckFlip.Checked Then
                    nEffectFlags = (nEffectFlags Or CType(ENeptuneEffect.NEPTUNE_EFFECT_FLIP, Int32))
                Else
                    nEffectFlags = (nEffectFlags And (Not CType(ENeptuneEffect.NEPTUNE_EFFECT_FLIP, Int32)))
                End If

                Dim emErr As ENeptuneError = NeptuneC.ntcSetEffect(Me.m_pCameraHandle, nEffectFlags)
                If (emErr <> ENeptuneError.NEPTUNE_ERR_Success) Then
                    Me.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetEffect Failed.", emErr)
                End If

            End If

        End If
    End Sub

    Private Sub m_ckMirror_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles m_ckMirror.CheckedChanged
        If (Me.m_pCameraHandle <> IntPtr.Zero) Then
            Dim nEffectFlags As Int32 = 0
            If (NeptuneC.ntcGetEffect(Me.m_pCameraHandle, nEffectFlags) = ENeptuneError.NEPTUNE_ERR_Success) Then
                If m_ckMirror.Checked Then
                    nEffectFlags = (nEffectFlags Or CType(ENeptuneEffect.NEPTUNE_EFFECT_MIRROR, Int32))
                Else
                    nEffectFlags = (nEffectFlags And (Not CType(ENeptuneEffect.NEPTUNE_EFFECT_MIRROR, Int32)))
                End If

                Dim emErr As ENeptuneError = NeptuneC.ntcSetEffect(Me.m_pCameraHandle, nEffectFlags)
                If (emErr <> ENeptuneError.NEPTUNE_ERR_Success) Then
                    Me.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetEffect Failed.", emErr)
                End If

            End If

        End If
    End Sub

    Private Sub m_TimerReceiveFPS_Tick(sender As System.Object, e As System.EventArgs) Handles m_TimerReceiveFPS.Tick
        If (Me.m_pCameraHandle <> IntPtr.Zero) Then
            Dim fFps As Single = 0
            If (NeptuneC.ntcGetReceiveFrameRate(Me.m_pCameraHandle, fFps) = ENeptuneError.NEPTUNE_ERR_Success) Then
                m_stcReceiveFps.Text = fFps.ToString
            End If

        End If
    End Sub

    Private Sub m_btnFpsApply_Click(sender As System.Object, e As System.EventArgs) Handles m_btnFpsApply.Click
        If (Me.m_pCameraHandle <> IntPtr.Zero) Then
            Dim emDevType As ENeptuneDevType = ENeptuneDevType.NEPTUNE_DEV_TYPE_UNKNOWN
            If (NeptuneC.ntcGetCameraType(Me.m_pCameraHandle, emDevType) = ENeptuneError.NEPTUNE_ERR_Success) Then
                Dim em1394FPS As ENeptuneFrameRate = ENeptuneFrameRate.FPS_UNKNOWN
                Dim dbValue As Double = 0
                If (emDevType = ENeptuneDevType.NEPTUNE_DEV_TYPE_1394) Then
                    If (m_cb1394FPS.SelectedIndex <> -1) Then
                        em1394FPS = CType(CType(m_cb1394FPS.SelectedItem, ItemData).m_nValue, ENeptuneFrameRate)
                    End If

                Else
                    dbValue = Convert.ToDouble(m_edFPS.Text)
                End If

                Dim emErr As ENeptuneError = NeptuneC.ntcSetFrameRate(Me.m_pCameraHandle, em1394FPS, dbValue)
                If (emErr <> ENeptuneError.NEPTUNE_ERR_Success) Then
                    Me.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetCameraType Failed.", emErr)
                End If

            End If

        End If
    End Sub

    Private Sub m_btnPlay_Click(sender As System.Object, e As System.EventArgs) Handles m_btnPlay.Click
        If (Me.m_pCameraHandle <> IntPtr.Zero) Then
            Dim emErr As ENeptuneError = NeptuneC.ntcSetAcquisition(Me.m_pCameraHandle, ENeptuneBoolean.NEPTUNE_BOOL_TRUE)
            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                m_TimerReceiveFrame.Start()
                m_TimerReceiveFPS.Start()
                Me.UpdateControlActivate()
            Else
                Me.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetAcquisition Failed.", emErr)
            End If

        End If
    End Sub

    Private Sub m_btnStop_Click(sender As System.Object, e As System.EventArgs) Handles m_btnStop.Click
        If (Me.m_pCameraHandle <> IntPtr.Zero) Then
            m_uiTotalFrameCount = 0
            Dim emErr As ENeptuneError = NeptuneC.ntcSetAcquisition(Me.m_pCameraHandle, ENeptuneBoolean.NEPTUNE_BOOL_FALSE)
            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                m_TimerReceiveFrame.Stop()
                m_TimerReceiveFPS.Stop()
                Me.UpdateControlActivate()
            Else
                Me.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetAcquisition Failed.", emErr)
            End If

        End If
    End Sub

    Private Sub m_cbAcquisitionMode_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles m_cbAcquisitionMode.SelectedIndexChanged
        If CType(sender, ComboBox).Focused Then
            If ((m_cbAcquisitionMode.SelectedIndex <> -1) _
                        AndAlso (Me.m_pCameraHandle <> IntPtr.Zero)) Then
                Dim emErr As ENeptuneError = NeptuneC.ntcSetAcquisitionMode(Me.m_pCameraHandle, CType(CType(m_cbAcquisitionMode.SelectedItem, ItemData).m_nValue, ENeptuneAcquisitionMode), CType(m_edMultiShotCnt.Value, UInt32))
                If (emErr <> ENeptuneError.NEPTUNE_ERR_Success) Then
                    Me.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetAcquisitionMode Failed.", emErr)
                End If

                Me.UpdateControlActivate()
            End If

        End If
    End Sub

    Private Sub m_btnShot_Click(sender As System.Object, e As System.EventArgs) Handles m_btnShot.Click
        If ((m_cbAcquisitionMode.SelectedIndex <> -1) _
                        AndAlso (Me.m_pCameraHandle <> IntPtr.Zero)) Then
            Dim emCurSel As ENeptuneAcquisitionMode = CType(CType(m_cbAcquisitionMode.SelectedItem, ItemData).m_nValue, ENeptuneAcquisitionMode)
            If (emCurSel = ENeptuneAcquisitionMode.NEPTUNE_ACQ_SINGLEFRAME) Then
                Dim emErr As ENeptuneError = NeptuneC.ntcOneShot(Me.m_pCameraHandle)
                If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                    Me.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, "One-Shot.")
                Else
                    Me.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcOneShot Failed.", emErr)
                End If

            ElseIf (emCurSel = ENeptuneAcquisitionMode.NEPTUNE_ACQ_MULTIFRAME) Then
                If (NeptuneC.ntcSetAcquisitionMode(Me.m_pCameraHandle, emCurSel, CType(m_edMultiShotCnt.Value, UInt32)) = ENeptuneError.NEPTUNE_ERR_Success) Then
                    Dim emErr As ENeptuneError = NeptuneC.ntcMultiShot(Me.m_pCameraHandle)
                    If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                        Me.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, "Multi-Shot.")
                    Else
                        Me.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcMultiShot Failed.", emErr)
                    End If

                End If

            End If

        End If
    End Sub

    Private Sub m_btnClearList_Click(sender As System.Object, e As System.EventArgs) Handles m_btnClearList.Click
        m_listLog.Items.Clear()
    End Sub

    Private Sub m_btnControl_Click(sender As System.Object, e As System.EventArgs) Handles m_btnControl.Click
        If (Me.m_pCameraHandle <> IntPtr.Zero) Then
            Dim emErr As ENeptuneError = NeptuneC.ntcShowControlDialog(Me.m_pCameraHandle)
            If (emErr <> ENeptuneError.NEPTUNE_ERR_Success) Then
                Me.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcShowControlDialog Failed.", emErr)
            End If

        End If
    End Sub

    Private Sub m_btnFeature_Click(sender As System.Object, e As System.EventArgs) Handles m_btnFeature.Click
        If (Me.m_formPopupFeature Is Nothing) Then
            Me.m_formPopupFeature = New PopupFeatureForm(Me)
            Me.m_formPopupFeature.Owner = Nothing
            Me.m_formPopupFeature.Show()
        Else
            Me.m_formPopupFeature.Show()
            Me.m_formPopupFeature.Focus()
            Me.m_formPopupFeature.UpdateForm()
        End If
    End Sub

    Private Sub m_btnCapture_Click(sender As System.Object, e As System.EventArgs) Handles m_btnCapture.Click
        If (Me.m_formPopupCapture Is Nothing) Then
            Me.m_formPopupCapture = New PopupCaptureForm(Me)
            Me.m_formPopupCapture.Owner = Nothing
            Me.m_formPopupCapture.Show()
        Else
            Me.m_formPopupCapture.Show()
            Me.m_formPopupCapture.Focus()
            Me.m_formPopupCapture.UpdateForm()
        End If
    End Sub

    Private Sub m_btnGrab_Click(sender As System.Object, e As System.EventArgs) Handles m_btnGrab.Click
        If (Me.m_formPopupGrab Is Nothing) Then
            Me.m_formPopupGrab = New PopupGrabForm(Me)
            Me.m_formPopupGrab.Owner = Nothing
            Me.m_formPopupGrab.Show()
        Else
            Me.m_formPopupGrab.Show()
            Me.m_formPopupGrab.Focus()
            Me.m_formPopupGrab.UpdateForm()
        End If
    End Sub

    Private Sub m_btnResolution_Click(sender As System.Object, e As System.EventArgs) Handles m_btnResolution.Click
        If (Me.m_formPopupResolution Is Nothing) Then
            Me.m_formPopupResolution = New PopupResolutionForm(Me)
            Me.m_formPopupResolution.Owner = Nothing
            Me.m_formPopupResolution.Show()
        Else
            Me.m_formPopupResolution.Show()
            Me.m_formPopupResolution.Focus()
            Me.m_formPopupResolution.UpdateForm()
        End If
    End Sub

    Private Sub m_btnTrigger_Click(sender As System.Object, e As System.EventArgs) Handles m_btnTrigger.Click
        If (Me.m_formPopupTrigger Is Nothing) Then
            Me.m_formPopupTrigger = New PopupTriggerForm(Me)
            Me.m_formPopupTrigger.Owner = Nothing
            Me.m_formPopupTrigger.Show()
        Else
            Me.m_formPopupTrigger.Show()
            Me.m_formPopupTrigger.Focus()
            Me.m_formPopupTrigger.UpdateForm()
        End If
    End Sub

    Private Sub m_btnStrobe_Click(sender As System.Object, e As System.EventArgs) Handles m_btnStrobe.Click
        If (Me.m_formPopupStrobe Is Nothing) Then
            Me.m_formPopupStrobe = New PopupStrobeForm(Me)
            Me.m_formPopupStrobe.Owner = Nothing
            Me.m_formPopupStrobe.Show()
        Else
            Me.m_formPopupStrobe.Show()
            Me.m_formPopupStrobe.Focus()
            Me.m_formPopupStrobe.UpdateForm()
        End If
    End Sub

    Private Sub m_btnThermalControl_Click(sender As System.Object, e As System.EventArgs) Handles m_btnThermalControl.Click
        If (Me.m_formPopupThermal Is Nothing) Then
            Me.m_formPopupThermal = New PopupThermalForm(Me)
            Me.m_formPopupThermal.Owner = Nothing
            Me.m_formPopupThermal.Show()
        Else
            Me.m_formPopupThermal.Show()
            Me.m_formPopupThermal.Focus()
            Me.m_formPopupThermal.UpdateForm()
        End If
    End Sub

    Private Sub m_btnAutoFocus_Click(sender As System.Object, e As System.EventArgs) Handles m_btnAutoFocus.Click
        If (Me.m_formPopupAutoFocus Is Nothing) Then
            Me.m_formPopupAutoFocus = New PopupAutoFocusForm(Me)
            Me.m_formPopupAutoFocus.Owner = Nothing
            Me.m_formPopupAutoFocus.Show()
        Else
            Me.m_formPopupAutoFocus.Show()
            Me.m_formPopupAutoFocus.Focus()
            Me.m_formPopupAutoFocus.UpdateForm()
        End If
    End Sub

    Private Sub m_btnFrameSave_Click(sender As System.Object, e As System.EventArgs) Handles m_btnFrameSave.Click
        If (Me.m_formPopupFrameSave Is Nothing) Then
            Me.m_formPopupFrameSave = New PopupFrameSaveForm(Me)
            Me.m_formPopupFrameSave.Owner = Nothing
            Me.m_formPopupFrameSave.Show()
        Else
            Me.m_formPopupFrameSave.Show()
            Me.m_formPopupFrameSave.Focus()
            Me.m_formPopupFrameSave.UpdateForm()
        End If
    End Sub

    Private Sub m_btnSIOControl_Click(sender As System.Object, e As System.EventArgs) Handles m_btnSIOControl.Click
        If (Me.m_formPopupSIOControl Is Nothing) Then
            Me.m_formPopupSIOControl = New PopupSIOControlForm(Me)
            Me.m_formPopupSIOControl.Owner = Nothing
            Me.m_formPopupSIOControl.Show()
        Else
            Me.m_formPopupSIOControl.Show()
            Me.m_formPopupSIOControl.Focus()
            Me.m_formPopupSIOControl.UpdateForm()
        End If
    End Sub

    Private Sub m_btnLUT_Click(sender As System.Object, e As System.EventArgs) Handles m_btnLUT.Click
        If (Me.m_formPopupLUT Is Nothing) Then
            Me.m_formPopupLUT = New PopupLUTForm(Me)
            Me.m_formPopupLUT.Owner = Nothing
            Me.m_formPopupLUT.Show()
        Else
            Me.m_formPopupLUT.Show()
            Me.m_formPopupLUT.Focus()
            Me.m_formPopupLUT.UpdateForm()
        End If
    End Sub

    Private Sub m_btnUserSet_Click(sender As System.Object, e As System.EventArgs) Handles m_btnUserSet.Click
        If (Me.m_formPopupUserSet Is Nothing) Then
            Me.m_formPopupUserSet = New PopupUserSetForm(Me)
            Me.m_formPopupUserSet.Owner = Nothing
            Me.m_formPopupUserSet.Show()
        Else
            Me.m_formPopupUserSet.Show()
            Me.m_formPopupUserSet.Focus()
            Me.m_formPopupUserSet.UpdateForm()
        End If
    End Sub

    Private Sub m_btnATLLedControl_Click(sender As System.Object, e As System.EventArgs) Handles m_btnATLLedControl.Click
        If (Me.m_formPopupAltLed Is Nothing) Then
            Me.m_formPopupAltLed = New PopupAltLedForm(Me)
            Me.m_formPopupAltLed.Owner = Nothing
            Me.m_formPopupAltLed.Show()
        Else
            Me.m_formPopupAltLed.Show()
            Me.m_formPopupAltLed.Focus()
            Me.m_formPopupAltLed.UpdateForm()
        End If
    End Sub

    Private Sub m_btnStackedROI_Click(sender As System.Object, e As System.EventArgs) Handles m_btnStackedROI.Click
        If (Me.m_formPopupStackedROI Is Nothing) Then
            Me.m_formPopupStackedROI = New PopupStackedROIForm(Me)
            Me.m_formPopupStackedROI.Owner = Nothing
            Me.m_formPopupStackedROI.Show()
        Else
            Me.m_formPopupStackedROI.Show()
            Me.m_formPopupStackedROI.Focus()
            Me.m_formPopupStackedROI.UpdateForm()
        End If
    End Sub

    Private Sub m_TimerReceiveFrame_Tick(sender As System.Object, e As System.EventArgs) Handles m_TimerReceiveFrame.Tick
        Me.m_stcReceiveFrame.Text = m_uiTotalFrameCount.ToString()
    End Sub

    Private Sub FrameCallbackFunc(ByRef stImage As NEPTUNE_IMAGE, ByVal pContext As IntPtr)
        m_uiTotalFrameCount = m_uiTotalFrameCount + 1
    End Sub

    Private Sub m_ckAutoScroll_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles m_ckAutoScroll.CheckedChanged

    End Sub

End Class

Public Class ItemData

    Public m_strLabel As String = ""

    Public m_nValue As Int32 = 0

    Public m_stCameraInfo As NEPTUNE_CAM_INFO

    Public Sub New(ByVal strLabel As String, ByVal nValue As Int32)
        Me.m_strLabel = strLabel
        Me.m_nValue = nValue
    End Sub

    Public Sub New(ByVal stCameraInfo As NEPTUNE_CAM_INFO)
        Me.m_stCameraInfo = stCameraInfo
        Me.m_strLabel = (Me.m_stCameraInfo.strVendor + (": [" _
                    + (Me.m_stCameraInfo.strSerial + ("] " + Me.m_stCameraInfo.strModel))))
    End Sub

    Public Overrides Function ToString() As String
        Return Me.m_strLabel
    End Function
End Class

Public Enum EM_LOG_LEVEL

    TYPE_ERROR

    TYPE_EVENT

    TYPE_INFORMATION
End Enum