Imports NeptuneCSample_VBNET.NeptuneC_Interface

Public Class PopupStackedROIForm
    Private m_refMainForm As NeptuneCSampleForm = Nothing

    Public Sub New(ByVal refMainForm As NeptuneCSampleForm)
        MyBase.New()
        InitializeComponent()
        Me.m_refMainForm = refMainForm
    End Sub

    Private Sub InitControls()
        Dim i As Int32
        For i = 0 To 7
            m_cbROISelector.Items.Add(i.ToString())
        Next
    End Sub

    Private Sub GetStackedROIControl()
        Dim bControl As ENeptuneBoolean = ENeptuneBoolean.NEPTUNE_BOOL_FALSE
        Dim err As ENeptuneError = NeptuneC.ntcGetStackedRoiControl(m_refMainForm.m_pCameraHandle, bControl)
        If (err <> ENeptuneError.NEPTUNE_ERR_Success) Then
            m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetStackedRoiControl Failed", err)
        End If

        If bControl = ENeptuneBoolean.NEPTUNE_BOOL_TRUE Then
            m_ckControl.Checked = True
        Else
            m_ckControl.Checked = False
        End If
    End Sub

    Private Sub GetStackedROIOffsetX()
        Dim err As ENeptuneError = ENeptuneError.NEPTUNE_ERR_Success

        Dim uiOffsetX As UInt32 = 0

        Dim iSel As Int32 = m_cbROISelector.SelectedIndex
        Dim iCnt As Int32 = m_cbROISelector.Items.Count

        Dim i As Int32
        For i = 0 To iCnt - 1
            err = NeptuneC.ntcSetStackedRoiSelector(m_refMainForm.m_pCameraHandle, Convert.ToUInt32(i))
            If (err = ENeptuneError.NEPTUNE_ERR_Success) Then
                Dim bEnable As ENeptuneBoolean = ENeptuneBoolean.NEPTUNE_BOOL_FALSE
                err = NeptuneC.ntcGetStackedRoiSelectedEnable(m_refMainForm.m_pCameraHandle, bEnable)
                If (err = ENeptuneError.NEPTUNE_ERR_Success) Then
                    If (bEnable = ENeptuneBoolean.NEPTUNE_BOOL_TRUE) Then
                        err = NeptuneC.ntcGetStackedRoiOffsetX(m_refMainForm.m_pCameraHandle, uiOffsetX)
                        If (err = ENeptuneError.NEPTUNE_ERR_Success) Then
                            Exit For
                        End If
                    End If
                End If
            End If
        Next

        NeptuneC.ntcSetStackedRoiSelector(m_refMainForm.m_pCameraHandle, Convert.ToUInt32(iSel))
        m_tbAllOffsetX.Text = uiOffsetX.ToString()

    End Sub

    Private Sub GetStackedROIWidth()
        Dim err As ENeptuneError = ENeptuneError.NEPTUNE_ERR_Success

        Dim uiWidth As UInt32 = 0

        Dim iSel As Int32 = m_cbROISelector.SelectedIndex
        Dim iCnt As Int32 = m_cbROISelector.Items.Count

        Dim i As Int32
        For i = 0 To iCnt - 1
            err = NeptuneC.ntcSetStackedRoiSelector(m_refMainForm.m_pCameraHandle, Convert.ToUInt32(i))
            If (err = ENeptuneError.NEPTUNE_ERR_Success) Then
                Dim bEnable As ENeptuneBoolean = ENeptuneBoolean.NEPTUNE_BOOL_FALSE
                err = NeptuneC.ntcGetStackedRoiSelectedEnable(m_refMainForm.m_pCameraHandle, bEnable)
                If (err = ENeptuneError.NEPTUNE_ERR_Success) Then
                    If (bEnable = ENeptuneBoolean.NEPTUNE_BOOL_TRUE) Then
                        err = NeptuneC.ntcGetStackedRoiWidth(m_refMainForm.m_pCameraHandle, uiWidth)
                        If (err = ENeptuneError.NEPTUNE_ERR_Success) Then
                            Exit For
                        End If
                    End If
                End If
            End If
        Next

        NeptuneC.ntcSetStackedRoiSelector(m_refMainForm.m_pCameraHandle, Convert.ToUInt32(iSel))
        m_tbAllWidth.Text = uiWidth.ToString()
    End Sub

    Private Sub GetSelectedStackedROI()

        Dim uiIdx As UInt32 = 0
        Dim err As ENeptuneError = NeptuneC.ntcGetStackedRoiSelector(m_refMainForm.m_pCameraHandle, uiIdx)
        If (err <> ENeptuneError.NEPTUNE_ERR_Success) Then
            m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetStackedRoiSelector Failed", err)
        End If

        m_cbROISelector.SelectedIndex = Convert.ToInt32(uiIdx)
    End Sub

    Private Sub GetSelectedStackedROIInfo()
        Dim bEnable As ENeptuneBoolean = ENeptuneBoolean.NEPTUNE_BOOL_FALSE
        Dim uiOffsetX As UInt32 = 0
        Dim uiOffsetY As UInt32 = 0
        Dim uiWidth As UInt32 = 0
        Dim uiHeight As UInt32 = 0
        Dim err As ENeptuneError = ENeptuneError.NEPTUNE_ERR_Success

        err = NeptuneC.ntcGetStackedRoiSelectedEnable(m_refMainForm.m_pCameraHandle, bEnable)
        If (err <> ENeptuneError.NEPTUNE_ERR_Success) Then
            m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetStackedRoiSelectedEnable Failed", err)
        End If


        err = NeptuneC.ntcGetStackedRoiOffsetX(m_refMainForm.m_pCameraHandle, uiOffsetX)
        If (err <> ENeptuneError.NEPTUNE_ERR_Success) Then
            m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetStackedRoiOffsetX Failed", err)
        End If


        err = NeptuneC.ntcGetStackedRoiOffsetY(m_refMainForm.m_pCameraHandle, uiOffsetY)
        If (err <> ENeptuneError.NEPTUNE_ERR_Success) Then
            m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetStackedRoiOffsetY Failed", err)
        End If


        err = NeptuneC.ntcGetStackedRoiWidth(m_refMainForm.m_pCameraHandle, uiWidth)
        If (err <> ENeptuneError.NEPTUNE_ERR_Success) Then
            m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetStackedRoiWidth Failed", err)
        End If


        err = NeptuneC.ntcGetStackedRoiHeight(m_refMainForm.m_pCameraHandle, uiHeight)
        If (err <> ENeptuneError.NEPTUNE_ERR_Success) Then
            m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetStackedRoiHeight Failed", err)
        End If

        If bEnable = ENeptuneBoolean.NEPTUNE_BOOL_TRUE Then
            m_ckEnable.Checked = True
        Else
            m_ckEnable.Checked = False
        End If
        m_tbOffsetX.Text = uiOffsetX.ToString()
        m_tbOffsetY.Text = uiOffsetY.ToString()
        m_tbWidth.Text = uiWidth.ToString()
        m_tbHeight.Text = uiHeight.ToString()

        If (bEnable = ENeptuneBoolean.NEPTUNE_BOOL_TRUE) Then
            GetStackedROIOffsetX()
            GetStackedROIWidth()
        End If
    End Sub


    Public Sub UpdateForm()
        GetStackedROIControl()
        GetSelectedStackedROI()
        GetStackedROIOffsetX()
        GetStackedROIWidth()
        GetSelectedStackedROIInfo()
    End Sub

    Private Sub PopupStackedROIForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.InitControls()
        Me.UpdateForm()
    End Sub

    Private Sub PopupStackedROIForm_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.m_refMainForm.m_formPopupStrobe = Nothing
    End Sub

    Private Sub m_ckControl_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles m_ckControl.CheckedChanged
        Using continuePlay As CNeptuneContinuePlay = New CNeptuneContinuePlay(m_refMainForm.m_pCameraHandle)
            Dim bControl As ENeptuneBoolean = ENeptuneBoolean.NEPTUNE_BOOL_FALSE
            If (m_ckControl.Checked) Then
                bControl = ENeptuneBoolean.NEPTUNE_BOOL_TRUE
            End If

            Dim err As ENeptuneError = NeptuneC.ntcSetStackedRoiControl(m_refMainForm.m_pCameraHandle, bControl)
            If (err <> ENeptuneError.NEPTUNE_ERR_Success) Then
                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetStackedRoiControl Failed", err)
                GetStackedROIControl()
            End If
        End Using
    End Sub

    Private Sub m_btnSetAllOffsetX_Click(sender As System.Object, e As System.EventArgs) Handles m_btnSetAllOffsetX.Click
        Using continuePlay As CNeptuneContinuePlay = New CNeptuneContinuePlay(m_refMainForm.m_pCameraHandle)
            Dim iOffsetX As UInt32 = Convert.ToUInt32(m_tbAllOffsetX.Text)
            Dim err As ENeptuneError = NeptuneC.ntcSetStackedRoiOffsetXAll(m_refMainForm.m_pCameraHandle, iOffsetX)
            If (err = ENeptuneError.NEPTUNE_ERR_Success) Then
                GetSelectedStackedROIInfo()
            Else
                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetStackedRoiOffsetXAll Failed", err)
            End If

            GetStackedROIOffsetX()
        End Using
    End Sub

    Private Sub m_btnSetAllWidth_Click(sender As System.Object, e As System.EventArgs) Handles m_btnSetAllWidth.Click
        Using continuePlay As CNeptuneContinuePlay = New CNeptuneContinuePlay(m_refMainForm.m_pCameraHandle)
            Dim iWidth As UInt32 = Convert.ToUInt32(m_tbAllWidth.Text)
            Dim err As ENeptuneError = NeptuneC.ntcSetStackedRoiWidthAll(m_refMainForm.m_pCameraHandle, iWidth)
            If (err = ENeptuneError.NEPTUNE_ERR_Success) Then
                GetSelectedStackedROIInfo()
            Else
                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetStackedRoiWidthAll Failed", err)
            End If

            GetStackedROIWidth()
        End Using
    End Sub

    Private Sub m_cbROISelector_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles m_cbROISelector.SelectedIndexChanged
        Dim iSel As Int32 = m_cbROISelector.SelectedIndex
        If (iSel >= 0) Then
            Dim err As ENeptuneError = NeptuneC.ntcSetStackedRoiSelector(m_refMainForm.m_pCameraHandle, Convert.ToUInt32(iSel))
            If (err = ENeptuneError.NEPTUNE_ERR_Success) Then
                GetSelectedStackedROIInfo()
            Else
                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetStackedRoiSelector Failed", err)
                GetSelectedStackedROI()
            End If
        End If

    End Sub

    Private Sub m_btnApply_Click(sender As System.Object, e As System.EventArgs) Handles m_btnApply.Click
        Using continuePlay As CNeptuneContinuePlay = New CNeptuneContinuePlay(m_refMainForm.m_pCameraHandle)
            Dim uiOffsetX As UInt32 = Convert.ToUInt32(m_tbOffsetX.Text)
            Dim uiOffsetY As UInt32 = Convert.ToUInt32(m_tbOffsetY.Text)
            Dim uiWidth As UInt32 = Convert.ToUInt32(m_tbWidth.Text)
            Dim uiHeight As UInt32 = Convert.ToUInt32(m_tbHeight.Text)

            Dim bEnable As ENeptuneBoolean = ENeptuneBoolean.NEPTUNE_BOOL_FALSE
            If m_ckEnable.Checked Then
                bEnable = ENeptuneBoolean.NEPTUNE_BOOL_TRUE
            End If

            Dim err As ENeptuneError = ENeptuneError.NEPTUNE_ERR_Success

            err = NeptuneC.ntcSetStackedRoiOffsetX(m_refMainForm.m_pCameraHandle, uiOffsetX)
            If (err <> ENeptuneError.NEPTUNE_ERR_Success) Then
                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetStackedRoiOffsetX Failed", err)
            End If

            err = NeptuneC.ntcSetStackedRoiOffsetY(m_refMainForm.m_pCameraHandle, uiOffsetY)
            If (err <> ENeptuneError.NEPTUNE_ERR_Success) Then
                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetStackedRoiOffsetY Failed", err)
            End If

            err = NeptuneC.ntcSetStackedRoiWidth(m_refMainForm.m_pCameraHandle, uiWidth)
            If (err <> ENeptuneError.NEPTUNE_ERR_Success) Then
                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetStackedRoiWidth Failed", err)
            End If

            err = NeptuneC.ntcSetStackedRoiHeight(m_refMainForm.m_pCameraHandle, uiHeight)
            If (err <> ENeptuneError.NEPTUNE_ERR_Success) Then
                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetStackedRoiHeight Failed", err)
            End If

            err = NeptuneC.ntcSetStackedRoiSelectedEnable(m_refMainForm.m_pCameraHandle, bEnable)
            If (err <> ENeptuneError.NEPTUNE_ERR_Success) Then
                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetStackedRoiSelectedEnable Failed", err)
            End If

            GetSelectedStackedROIInfo()
            GetStackedROIOffsetX()
            GetStackedROIWidth()
        End Using
    End Sub
End Class