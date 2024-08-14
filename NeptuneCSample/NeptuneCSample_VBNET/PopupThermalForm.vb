Imports NeptuneCSample_VBNET.NeptuneC_Interface

Public Class PopupThermalForm
    Private m_refMainForm As NeptuneCSampleForm = Nothing

    Private m_stXmlPalette As NEPTUNE_XML_ENUM_LIST

    Private m_stXmlNucMode As NEPTUNE_XML_ENUM_LIST
    Private m_stXmlNucAutoTime As NEPTUNE_XML_INT_VALUE_INFO
    Private m_stXmlNucAutoTemperature As NEPTUNE_XML_INT_VALUE_INFO

    Private m_stXmlAlarmDetectPixelCnt As NEPTUNE_XML_INT_VALUE_INFO
    Private m_stXmlAlarmDetectStartDelay As NEPTUNE_XML_FLOAT_VALUE_INFO
    Private m_stXmlAlarmDetectStopDelay As NEPTUNE_XML_FLOAT_VALUE_INFO
    Private m_stXmlAlarmDetectOutputEnable As NEPTUNE_XML_ENUM_LIST
    Private m_stXmlAlarmDetectOutputPolarity As NEPTUNE_XML_ENUM_LIST

    Private m_stXmlPrivacySelect As NEPTUNE_XML_ENUM_LIST
    Private m_stXmlPrivacyEnable As NEPTUNE_XML_ENUM_LIST
    Private m_stXmlPrivacyLeft As NEPTUNE_XML_INT_VALUE_INFO
    Private m_stXmlPrivacyTop As NEPTUNE_XML_INT_VALUE_INFO
    Private m_stXmlPrivacyWidth As NEPTUNE_XML_INT_VALUE_INFO
    Private m_stXmlPrivacyHeight As NEPTUNE_XML_INT_VALUE_INFO

    Private m_stXmlPointSelect As NEPTUNE_XML_ENUM_LIST
    Private m_stXmlPointEnable As NEPTUNE_XML_ENUM_LIST
    Private m_stXmlPointLeft As NEPTUNE_XML_INT_VALUE_INFO
    Private m_stXmlPointTop As NEPTUNE_XML_INT_VALUE_INFO

    Private m_stXmlAlarmSelect As NEPTUNE_XML_ENUM_LIST
    Private m_stXmlAlarmEnable As NEPTUNE_XML_ENUM_LIST
    Private m_stXmlAlarmLeft As NEPTUNE_XML_INT_VALUE_INFO
    Private m_stXmlAlarmTop As NEPTUNE_XML_INT_VALUE_INFO
    Private m_stXmlAlarmWidth As NEPTUNE_XML_INT_VALUE_INFO
    Private m_stXmlAlarmHeight As NEPTUNE_XML_INT_VALUE_INFO
    Private m_stXmlAlarmCondition As NEPTUNE_XML_ENUM_LIST
    Private m_stXmlAlarmTemperature As NEPTUNE_XML_FLOAT_VALUE_INFO
    Private m_stXmlAlarmTransparency As NEPTUNE_XML_ENUM_LIST
    Private m_stXmlAlarmColor As NEPTUNE_XML_ENUM_LIST

    Public Sub New(ByVal refMainForm As NeptuneCSampleForm)
        MyBase.New()
        InitializeComponent()
        m_refMainForm = refMainForm

        m_stXmlPalette = NEPTUNE_XML_ENUM_LIST.Create()

        m_stXmlNucMode = NEPTUNE_XML_ENUM_LIST.Create()
        m_stXmlNucAutoTime = New NEPTUNE_XML_INT_VALUE_INFO()
        m_stXmlNucAutoTemperature = New NEPTUNE_XML_INT_VALUE_INFO()

        m_stXmlAlarmDetectPixelCnt = New NEPTUNE_XML_INT_VALUE_INFO()
        m_stXmlAlarmDetectStartDelay = New NEPTUNE_XML_FLOAT_VALUE_INFO()
        m_stXmlAlarmDetectStopDelay = New NEPTUNE_XML_FLOAT_VALUE_INFO()
        m_stXmlAlarmDetectOutputEnable = NEPTUNE_XML_ENUM_LIST.Create()
        m_stXmlAlarmDetectOutputPolarity = NEPTUNE_XML_ENUM_LIST.Create()

        m_stXmlPrivacySelect = NEPTUNE_XML_ENUM_LIST.Create()
        m_stXmlPrivacyEnable = NEPTUNE_XML_ENUM_LIST.Create()
        m_stXmlPrivacyLeft = New NEPTUNE_XML_INT_VALUE_INFO()
        m_stXmlPrivacyTop = New NEPTUNE_XML_INT_VALUE_INFO()
        m_stXmlPrivacyWidth = New NEPTUNE_XML_INT_VALUE_INFO()
        m_stXmlPrivacyHeight = New NEPTUNE_XML_INT_VALUE_INFO()

        m_stXmlPointSelect = NEPTUNE_XML_ENUM_LIST.Create()
        m_stXmlPointEnable = NEPTUNE_XML_ENUM_LIST.Create()
        m_stXmlPointLeft = New NEPTUNE_XML_INT_VALUE_INFO()
        m_stXmlPointTop = New NEPTUNE_XML_INT_VALUE_INFO()

        m_stXmlAlarmSelect = NEPTUNE_XML_ENUM_LIST.Create()
        m_stXmlAlarmEnable = NEPTUNE_XML_ENUM_LIST.Create()
        m_stXmlAlarmLeft = New NEPTUNE_XML_INT_VALUE_INFO()
        m_stXmlAlarmTop = New NEPTUNE_XML_INT_VALUE_INFO()
        m_stXmlAlarmWidth = New NEPTUNE_XML_INT_VALUE_INFO()
        m_stXmlAlarmHeight = New NEPTUNE_XML_INT_VALUE_INFO()
        m_stXmlAlarmCondition = NEPTUNE_XML_ENUM_LIST.Create()
        m_stXmlAlarmTemperature = New NEPTUNE_XML_FLOAT_VALUE_INFO()
        m_stXmlAlarmTransparency = NEPTUNE_XML_ENUM_LIST.Create()
        m_stXmlAlarmColor = NEPTUNE_XML_ENUM_LIST.Create()
    End Sub

    Public Sub UpdateForm()
        Dim bEnable As Boolean = False
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim stNodeInfo As NEPTUNE_XML_NODE_INFO = New NEPTUNE_XML_NODE_INFO()
            If (NeptuneC.ntcGetNodeInfo(m_refMainForm.m_pCameraHandle, "Temperatures", stNodeInfo) = ENeptuneError.NEPTUNE_ERR_Success) Then
                bEnable = True
            End If
        End If

        Enabled = bEnable
        If (bEnable) Then
            GetYuvPaletteInfo()
            GetNucInfo()
            GetAlarmDetectInfo()
            GetImagePrivacyMaskSelect()
            GetPointTemperatureSelect()
            GetAlarmSelect()
        End If
    End Sub

    Private Function GetNodeValue(ByVal strNodeName As String, ByRef cbo As ComboBox, ByRef xmlValue As NEPTUNE_XML_ENUM_LIST) As Boolean
        Dim bRet As Boolean = False

        Dim emErr As ENeptuneError = NeptuneC.ntcGetNodeEnum(m_refMainForm.m_pCameraHandle, strNodeName, xmlValue)
        If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
            bRet = True
        Else
            Dim strLog As String = "ntcGetNodeEnum '" + strNodeName + "' Failed."
            Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, strLog, emErr)
        End If

        cbo.Items.Clear()
        cbo.Enabled = bRet
        If bRet Then
            Dim i As Int32
            For i = 0 To xmlValue.nCount - 1
                cbo.Items.Add(xmlValue.pstrList(i))
            Next

            cbo.SelectedIndex = xmlValue.nIndex
        End If

        Return bRet
    End Function

    Private Function GetNodeValue(ByVal strNodeName As String, ByRef tb As TextBox, ByRef xmlValue As NEPTUNE_XML_INT_VALUE_INFO) As Boolean
        Dim bRet As Boolean = False

        Dim emErr As ENeptuneError = NeptuneC.ntcGetNodeInt(m_refMainForm.m_pCameraHandle, strNodeName, xmlValue)
        If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
            bRet = True
        Else
            Dim strLog As String = "ntcGetNodeInt '" + strNodeName + "' Failed."
            Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, strLog, emErr)
        End If

        tb.Enabled = bRet
        If (bRet) Then
            tb.Text = xmlValue.nValue.ToString()
        End If

        Return bRet
    End Function

    Private Function GetNodeValue(ByVal strNodeName As String, ByRef tb As TextBox, ByRef xmlValue As NEPTUNE_XML_FLOAT_VALUE_INFO) As Boolean
        Dim bRet As Boolean = False

        Dim emErr As ENeptuneError = NeptuneC.ntcGetNodeFloat(m_refMainForm.m_pCameraHandle, strNodeName, xmlValue)
        If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
            bRet = True
        Else
            Dim strLog As String = "ntcGetNodeFloat '" + strNodeName + "' Failed."
            Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, strLog, emErr)
        End If

        tb.Enabled = bRet
        If (bRet) Then
            tb.Text = xmlValue.dValue.ToString("N3")
        End If

        Return bRet
    End Function

    Private Function SetNodeValue(ByVal strNodeName As String, ByRef cbo As ComboBox, ByRef xmlValue As NEPTUNE_XML_ENUM_LIST) As Boolean
        Dim bRet As Boolean = False

        Dim iCurSel As Int32 = cbo.SelectedIndex
        If (iCurSel <> -1) Then
            Dim strValue As String = cbo.SelectedItem.ToString()
            Dim emErr As ENeptuneError = NeptuneC.ntcSetNodeEnum(m_refMainForm.m_pCameraHandle, strNodeName, strValue)
            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                bRet = True
            Else
                Dim strLog As String = "ntcSetNodeEnum '" + strNodeName + "' Failed."
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, strLog, emErr)
            End If

            If (bRet) Then
                xmlValue.nIndex = iCurSel
            Else
                cbo.SelectedIndex = xmlValue.nIndex
            End If
        End If

        Return bRet
    End Function

    Private Function SetNodeValue(ByVal strNodeName As String, ByRef tb As TextBox, ByRef xmlValue As NEPTUNE_XML_INT_VALUE_INFO) As Boolean
        Dim bRet As Boolean = False

        Dim strText As String = tb.Text
        strText.Trim()

        Dim iVal As Int64 = Convert.ToInt64(strText)
        Dim iNewVal As Int64 = iVal
        If (iNewVal < xmlValue.nMin) Then
            iNewVal = xmlValue.nMin
        ElseIf (iNewVal > xmlValue.nMax) Then
            iNewVal = xmlValue.nMax
        End If

        Dim iShare As Int64 = iNewVal / xmlValue.nInc
        iNewVal = iShare * xmlValue.nInc

        If (iNewVal <> iVal) Then
            strText = iNewVal.ToString()
            tb.Text = strText
        End If

        Dim emErr As ENeptuneError = NeptuneC.ntcSetNodeInt(m_refMainForm.m_pCameraHandle, strNodeName, iNewVal)
        If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
            bRet = True
        Else
            Dim strLog As String = "ntcSetNodeInt '" + strNodeName + "' Failed."
            Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, strLog, emErr)
        End If

        If (bRet) Then
            xmlValue.nValue = iNewVal
        Else
            strText = xmlValue.nValue.ToString()
            tb.Text = strText
        End If

        Return bRet
    End Function

    Private Function SetNodeValue(ByVal strNodeName As String, ByRef tb As TextBox, ByRef xmlValue As NEPTUNE_XML_FLOAT_VALUE_INFO) As Boolean
        Dim bRet As Boolean = False

        Dim strText As String = tb.Text
        strText.Trim()

        Dim dblVal As Double = Convert.ToDouble(strText)
        Dim dblNewVal As Double = dblVal

        If (dblNewVal < xmlValue.dMin) Then
            dblNewVal = xmlValue.dMin
        ElseIf (dblNewVal > xmlValue.dMax) Then
            dblNewVal = xmlValue.dMax
        End If

        Dim fShare As Double = dblNewVal / xmlValue.dInc
        Dim iShare As Int64 = Math.Round(fShare)
        dblNewVal = iShare * xmlValue.dInc

        If (dblNewVal <> dblVal) Then
            strText = dblNewVal.ToString("N3")
            tb.Text = strText
        End If

        Dim emErr As ENeptuneError = NeptuneC.ntcSetNodeFloat(m_refMainForm.m_pCameraHandle, strNodeName, dblNewVal)
        If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
            bRet = True
        Else
            Dim strLog As String = "ntcSetNodeFloat '" + strNodeName + "' Failed."
            Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, strLog, emErr)
        End If

        If (bRet) Then
            xmlValue.dValue = dblNewVal
        Else
            strText = xmlValue.dValue.ToString("N3")
            tb.Text = strText
        End If

        Return bRet
    End Function

    Private Sub PopupThermalForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        UpdateForm()
    End Sub

    Private Sub PopupThermalForm_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        m_refMainForm.m_formPopupThermal = Nothing
    End Sub

    Private Sub GetYuvPaletteInfo()
        GetNodeValue("ImageColorPalette", cbPalette, m_stXmlPalette)
    End Sub

    Private Sub GetNucInfo()
        GetNodeValue("NUCMode", cbNucMode, m_stXmlNucMode)
        GetNodeValue("NUCAutoPeriodicTime", tbNucAutoTime, m_stXmlNucAutoTime)
        GetNodeValue("NUCAutoTemperature", tbNucAutoTemperature, m_stXmlNucAutoTemperature)
    End Sub

    Private Sub GetAlarmDetectInfo()
        GetNodeValue("AlarmDetectionPixelCount", tbAlarmDetectPixelCnt, m_stXmlAlarmDetectPixelCnt)
        GetNodeValue("AlarmDetectionStartDelayTime", tbAlarmDetectStartDelay, m_stXmlAlarmDetectStartDelay)
        GetNodeValue("AlarmDetectionStopDelayTime", tbAlarmDetectStopDelay, m_stXmlAlarmDetectStopDelay)
        GetNodeValue("AlarmDetectionOutputEnable", cbAlarmDetectOutputEnable, m_stXmlAlarmDetectOutputEnable)
        GetNodeValue("AlarmDetectionOutputPolarity", cbAlarmDetectOutputPolarity, m_stXmlAlarmDetectOutputPolarity)
    End Sub

    Private Sub GetImagePrivacyMaskSelect()
        If (GetNodeValue("PrivacySelector", cbPrivacySelect, m_stXmlPrivacySelect)) Then
            GetImagePrivacyMaskInfo()
        End If
    End Sub

    Private Sub GetPointTemperatureSelect()
        If (GetNodeValue("PointTemperatureSelector", cbPointSelect, m_stXmlPointSelect)) Then
            GetPointTemperatureInfo()
        End If
    End Sub

    Private Sub GetAlarmSelect()
        If (GetNodeValue("AlarmSelector", cbAlarmSelect, m_stXmlAlarmSelect)) Then
            GetAlarmInfo()
        End If
    End Sub

    Private Sub GetImagePrivacyMaskInfo()
        GetNodeValue("SelectedPrivacyOnOff", cbPrivacyEnable, m_stXmlPrivacyEnable)
        GetNodeValue("PrivacyAreaLeft", tbPrivacyLeft, m_stXmlPrivacyLeft)
        GetNodeValue("PrivacyAreaTop", tbPrivacyTop, m_stXmlPrivacyTop)
        GetNodeValue("PrivacyAreaWidth", tbPrivacyWidth, m_stXmlPrivacyWidth)
        GetNodeValue("PrivacyAreaHeight", tbPrivacyHeight, m_stXmlPrivacyHeight)
    End Sub

    Private Sub GetPointTemperatureInfo()
        GetNodeValue("SelectedPointTemperatureOnOff", cbPointEnable, m_stXmlPointEnable)
        GetNodeValue("PointTemperatureLeft", tbPointLeft, m_stXmlPointLeft)
        GetNodeValue("PointTemperatureTop", tbPointTop, m_stXmlPointTop)

        GetPoint()
    End Sub

    Private Sub GetAlarmInfo()
        GetNodeValue("SelectedAlarmAreaOnOff", cbAlarmEnable, m_stXmlAlarmEnable)
        GetNodeValue("AlarmAreaLeft", tbAlarmLeft, m_stXmlAlarmLeft)
        GetNodeValue("AlarmAreaTop", tbAlarmTop, m_stXmlAlarmTop)
        GetNodeValue("AlarmAreaWidth", tbAlarmWidth, m_stXmlAlarmWidth)
        GetNodeValue("AlarmAreaHeight", tbAlarmHeight, m_stXmlAlarmHeight)

        GetNodeValue("AlarmCondition", cbAlarmCondition, m_stXmlAlarmCondition)
        GetNodeValue("AlarmReferenceTemperature", tbAlarmTemperature, m_stXmlAlarmTemperature)
        GetNodeValue("AlarmColorTransparencyOnOff", cbAlarmTransparency, m_stXmlAlarmTransparency)
        GetNodeValue("AlarmColor", cbAlarmColor, m_stXmlAlarmColor)

        GetAlarm()
    End Sub

    Private Sub btnGetPoint_Click(sender As System.Object, e As System.EventArgs) Handles btnGetPoint.Click
        GetPoint()
    End Sub

    Private Sub btnGetAlarm_Click(sender As System.Object, e As System.EventArgs) Handles btnGetAlarm.Click
        GetAlarm()
    End Sub

    Private Sub GetPoint()
        Dim xmlValue As NEPTUNE_XML_FLOAT_VALUE_INFO = New NEPTUNE_XML_FLOAT_VALUE_INFO()
        GetNodeValue("SelectedPointTemperature", tbPointTemperature, xmlValue)
    End Sub

    Private Sub GetAlarm()
        Dim xmlValue As NEPTUNE_XML_ENUM_LIST = New NEPTUNE_XML_ENUM_LIST()
        GetNodeValue("SelectedAlarmDetectionStatus", cbAlarmStatus, xmlValue)
        cbAlarmStatus.Enabled = False
    End Sub

    Private Sub cbPrivacySelect_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbPrivacySelect.SelectedIndexChanged
        If (SetNodeValue("PrivacySelector", cbPrivacySelect, m_stXmlPrivacySelect)) Then
            GetImagePrivacyMaskInfo()
        End If
    End Sub

    Private Sub cbPointSelect_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbPointSelect.SelectedIndexChanged
        If (SetNodeValue("PointTemperatureSelector", cbPointSelect, m_stXmlPointSelect)) Then
            GetPointTemperatureInfo()
        End If
    End Sub

    Private Sub cbAlarmSelect_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbAlarmSelect.SelectedIndexChanged
        If (SetNodeValue("AlarmSelector", cbAlarmSelect, m_stXmlAlarmSelect)) Then
            GetAlarmInfo()
        End If
    End Sub

    Private Sub btnSetPalette_Click(sender As System.Object, e As System.EventArgs) Handles btnSetPalette.Click
        SetNodeValue("ImageColorPalette", cbPalette, m_stXmlPalette)
    End Sub

    Private Sub btnSetNuc_Click(sender As System.Object, e As System.EventArgs) Handles btnSetNuc.Click
        SetNodeValue("NUCMode", cbNucMode, m_stXmlNucMode)
        SetNodeValue("NUCAutoPeriodicTime", tbNucAutoTime, m_stXmlNucAutoTime)
        SetNodeValue("NUCAutoTemperature", tbNucAutoTemperature, m_stXmlNucAutoTemperature)
    End Sub

    Private Sub btnSetDetect_Click(sender As System.Object, e As System.EventArgs) Handles btnSetDetect.Click
        SetNodeValue("AlarmDetectionPixelCount", tbAlarmDetectPixelCnt, m_stXmlAlarmDetectPixelCnt)
        SetNodeValue("AlarmDetectionStartDelayTime", tbAlarmDetectStartDelay, m_stXmlAlarmDetectStartDelay)
        SetNodeValue("AlarmDetectionStopDelayTime", tbAlarmDetectStopDelay, m_stXmlAlarmDetectStopDelay)
        SetNodeValue("AlarmDetectionOutputEnable", cbAlarmDetectOutputEnable, m_stXmlAlarmDetectOutputEnable)
        SetNodeValue("AlarmDetectionOutputPolarity", cbAlarmDetectOutputPolarity, m_stXmlAlarmDetectOutputPolarity)
    End Sub

    Private Sub btnSetPrivacy_Click(sender As System.Object, e As System.EventArgs) Handles btnSetPrivacy.Click
        SetNodeValue("SelectedPrivacyOnOff", cbPrivacyEnable, m_stXmlPrivacyEnable)
        SetNodeValue("PrivacyAreaLeft", tbPrivacyLeft, m_stXmlPrivacyLeft)
        SetNodeValue("PrivacyAreaTop", tbPrivacyTop, m_stXmlPrivacyTop)
        SetNodeValue("PrivacyAreaWidth", tbPrivacyWidth, m_stXmlPrivacyWidth)
        SetNodeValue("PrivacyAreaHeight", tbPrivacyHeight, m_stXmlPrivacyHeight)
    End Sub

    Private Sub btnSetPoint_Click(sender As System.Object, e As System.EventArgs) Handles btnSetPoint.Click
        SetNodeValue("SelectedPointTemperatureOnOff", cbPointEnable, m_stXmlPointEnable)
        SetNodeValue("PointTemperatureLeft", tbPointLeft, m_stXmlPointLeft)
        SetNodeValue("PointTemperatureTop", tbPointTop, m_stXmlPointTop)
    End Sub

    Private Sub btnSetAlarm_Click(sender As System.Object, e As System.EventArgs) Handles btnSetAlarm.Click
        SetNodeValue("SelectedAlarmAreaOnOff", cbAlarmEnable, m_stXmlAlarmEnable)
        SetNodeValue("AlarmAreaLeft", tbAlarmLeft, m_stXmlAlarmLeft)
        SetNodeValue("AlarmAreaTop", tbAlarmTop, m_stXmlAlarmTop)
        SetNodeValue("AlarmAreaWidth", tbAlarmWidth, m_stXmlAlarmWidth)
        SetNodeValue("AlarmAreaHeight", tbAlarmHeight, m_stXmlAlarmHeight)
        SetNodeValue("AlarmCondition", cbAlarmCondition, m_stXmlAlarmCondition)
        SetNodeValue("AlarmReferenceTemperature", tbAlarmTemperature, m_stXmlAlarmTemperature)
        SetNodeValue("AlarmColorTransparencyOnOff", cbAlarmTransparency, m_stXmlAlarmTransparency)
        SetNodeValue("AlarmColor", cbAlarmColor, m_stXmlAlarmColor)
    End Sub

    Private Sub btnReqNUC_Click(sender As System.Object, e As System.EventArgs) Handles btnReqNUC.Click
        Dim emErr As ENeptuneError = NeptuneC.ntcSetNodeCommand(m_refMainForm.m_pCameraHandle, "NUCManualRun")
        If (emErr <> ENeptuneError.NEPTUNE_ERR_Success) Then
            Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetNodeCommand 'NUCManualRun' Failed.", emErr)
        End If
    End Sub
End Class