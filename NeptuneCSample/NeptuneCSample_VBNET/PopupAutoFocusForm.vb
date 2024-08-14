Imports NeptuneCSample_VBNET.NeptuneC_Interface

Public Class PopupAutoFocusForm

    Private m_refMainForm As NeptuneCSampleForm = Nothing

    Public Sub New(ByVal refMainForm As NeptuneCSampleForm)
        InitializeComponent()
        Me.m_refMainForm = refMainForm
    End Sub

    Private Sub InitControls()

    End Sub

    Public Sub UpdateForm()

    End Sub

    Private Sub PopupAutoFocusForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.InitControls()
        Me.UpdateForm()
    End Sub

    Private Sub PopupAutoFocusForm_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.m_refMainForm.m_formPopupAutoFocus = Nothing
    End Sub

    Private Sub m_btnOriginal_Click(sender As System.Object, e As System.EventArgs) Handles m_btnOriginal.Click
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim emErr As ENeptuneError = NeptuneC.ntcSetAFControl(Me.m_refMainForm.m_pCameraHandle, ENeptuneAFMode.NEPTUNE_AF_ORIGIN)
            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, "Set Auto Focus: ORIGIN.")
            Else
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetAFControl Failed.", emErr)
            End If
        End If
    End Sub

    Private Sub m_btnOnePush_Click(sender As System.Object, e As System.EventArgs) Handles m_btnOnePush.Click
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim emErr As ENeptuneError = NeptuneC.ntcSetAFControl(Me.m_refMainForm.m_pCameraHandle, ENeptuneAFMode.NEPTUNE_AF_ONEPUSH)
            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, "Set Auto Focus: ONEPUSH.")
            Else
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetAFControl Failed.", emErr)
            End If
        End If
    End Sub

    Private Sub m_btnOneStepForward_Click(sender As System.Object, e As System.EventArgs) Handles m_btnOneStepForward.Click
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim emErr As ENeptuneError = NeptuneC.ntcSetAFControl(Me.m_refMainForm.m_pCameraHandle, ENeptuneAFMode.NEPTUNE_AF_STEP_FORWARD)
            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, "Set Auto Focus: STEP FORWARD.")
            Else
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetAFControl Failed.", emErr)
            End If
        End If
    End Sub

    Private Sub m_btnOneStepBackward_Click(sender As System.Object, e As System.EventArgs) Handles m_btnOneStepBackward.Click
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim emErr As ENeptuneError = NeptuneC.ntcSetAFControl(Me.m_refMainForm.m_pCameraHandle, ENeptuneAFMode.NEPTUNE_AF_STEP_BACKWARD)
            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, "Set Auto Focus: STEP BACKWARD.")
            Else
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetAFControl Failed.", emErr)
            End If
        End If
    End Sub
End Class