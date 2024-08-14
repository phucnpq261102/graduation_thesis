Imports NeptuneCSample_VBNET.NeptuneC_Interface

Public Class PopupFrameSaveForm
    Private m_refMainForm As NeptuneCSampleForm = Nothing

    Public Sub New(ByVal refMainForm As NeptuneCSampleForm)
        MyBase.New()
        InitializeComponent()
        Me.m_refMainForm = refMainForm
    End Sub

    Private Sub InitControls()

    End Sub

    Public Sub UpdateForm()
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim emOnOff As ENeptuneBoolean = ENeptuneBoolean.NEPTUNE_BOOL_FALSE
            Dim uiFrameRemained As UInt32 = 0
            Dim emErr As ENeptuneError = NeptuneC.ntcGetFrameSave(Me.m_refMainForm.m_pCameraHandle, emOnOff, uiFrameRemained)
            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                If emOnOff = ENeptuneBoolean.NEPTUNE_BOOL_TRUE Then
                    m_ckEnable.Checked = True
                Else
                    m_ckEnable.Checked = False
                End If

                m_edRemained.Text = uiFrameRemained.ToString
            Else
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetFrameSave Failed.", emErr)
            End If

        End If

    End Sub

    Private Sub PopupFrameSaveForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.UpdateForm()
    End Sub

    Private Sub PopupFrameSaveForm_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.m_refMainForm.m_formPopupFrameSave = Nothing
    End Sub

    Private Sub m_ckEnable_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles m_ckEnable.CheckedChanged
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim emOnOff As ENeptuneBoolean
            If m_ckEnable.Checked = True Then
                emOnOff = ENeptuneBoolean.NEPTUNE_BOOL_TRUE
            Else
                emOnOff = ENeptuneBoolean.NEPTUNE_BOOL_FALSE
            End If
            
            Dim emErr As ENeptuneError = NeptuneC.ntcSetFrameSave(Me.m_refMainForm.m_pCameraHandle, emOnOff, ENeptuneBoolean.NEPTUNE_BOOL_FALSE, 0)
            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                Me.UpdateForm()
            Else
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetFrameSave Failed.", emErr)
            End If

        End If
    End Sub

    Private Sub m_btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles m_btnRefresh.Click
        Me.UpdateForm()
    End Sub

    Private Sub m_btnPlay_Click(sender As System.Object, e As System.EventArgs) Handles m_btnPlay.Click
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim emOnOff As ENeptuneBoolean
            If m_ckEnable.Checked = True Then
                emOnOff = ENeptuneBoolean.NEPTUNE_BOOL_TRUE
            Else
                emOnOff = ENeptuneBoolean.NEPTUNE_BOOL_FALSE
            End If

            Dim uiFrameRemained As UInt32 = CType(m_edRecvCount.Value, UInt32)
            Dim emErr As ENeptuneError = NeptuneC.ntcSetFrameSave(Me.m_refMainForm.m_pCameraHandle, emOnOff, ENeptuneBoolean.NEPTUNE_BOOL_TRUE, uiFrameRemained)
            If (emErr <> ENeptuneError.NEPTUNE_ERR_Success) Then
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetFrameSave Failed.", emErr)
            End If

        End If
    End Sub
End Class