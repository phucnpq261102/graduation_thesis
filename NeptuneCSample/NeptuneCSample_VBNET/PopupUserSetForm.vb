Imports NeptuneCSample_VBNET.NeptuneC_Interface

Public Class PopupUserSetForm
    Private m_refMainForm As NeptuneCSampleForm = Nothing

    Public Sub New(ByVal refMainForm As NeptuneCSampleForm)
        MyBase.New()
        InitializeComponent()
        Me.m_refMainForm = refMainForm
    End Sub

    Private Sub InitControls()

    End Sub

    Public Sub UpdateForm()
        m_cbUserSet.Items.Clear()
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim stUserSet As NEPTUNE_USERSET = New NEPTUNE_USERSET
            Dim emErr As ENeptuneError = NeptuneC.ntcGetUserSet(Me.m_refMainForm.m_pCameraHandle, stUserSet)
            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                Dim i As Integer = 0
                For i = 0 To 15
                    Dim uiBit As UInt16 = CType((1 + i), UInt16)
                    If ((stUserSet.SupportUserSet And uiBit) _
                                = uiBit) Then
                        If (i = 0) Then
                            m_cbUserSet.Items.Add(New ItemData("Default", i))
                        Else
                            m_cbUserSet.Items.Add(New ItemData(("UserSet" + i.ToString), i))
                        End If

                    End If
                Next

                m_cbUserSet.SelectedIndex = CType(stUserSet.UserSetIndex, Integer)
            Else
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetUserSet Failed.", emErr)
            End If

        End If

    End Sub

    Private Sub PopupUserSetForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.InitControls()
        Me.UpdateForm()
    End Sub

    Private Sub PopupUserSetForm_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.m_refMainForm.m_formPopupUserSet = Nothing
    End Sub

    Private Sub m_btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles m_btnLoad.Click
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim stUserSet As NEPTUNE_USERSET = New NEPTUNE_USERSET
            stUserSet.UserSetIndex = CType(CType(m_cbUserSet.SelectedItem, ItemData).m_nValue, ENeptuneUserSet)
            stUserSet.Command = ENeptuneUserSetCommand.NEPTUNE_USERSET_CMD_LOAD
            Dim emErr As ENeptuneError = NeptuneC.ntcSetUserSet(Me.m_refMainForm.m_pCameraHandle, stUserSet)
            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                Me.m_refMainForm.UpdatePopupForms(False)
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, ("Load UserSet: UserSet" + CType(stUserSet.UserSetIndex, Integer).ToString))

                Me.m_refMainForm.UpdateCameraInfo()
            Else
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetUserSet Failed.", emErr)
            End If

        End If
    End Sub

    Private Sub m_btnSave_Click(sender As System.Object, e As System.EventArgs) Handles m_btnSave.Click
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim stUserSet As NEPTUNE_USERSET = New NEPTUNE_USERSET
            stUserSet.UserSetIndex = CType(CType(m_cbUserSet.SelectedItem, ItemData).m_nValue, ENeptuneUserSet)
            stUserSet.Command = ENeptuneUserSetCommand.NEPTUNE_USERSET_CMD_SAVE
            Dim emErr As ENeptuneError = NeptuneC.ntcSetUserSet(Me.m_refMainForm.m_pCameraHandle, stUserSet)
            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, ("Save UserSet: UserSet" + CType(stUserSet.UserSetIndex, Integer).ToString))
            Else
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetUserSet Failed.", emErr)
            End If

        End If
    End Sub

    Private Sub m_btnSetDefault_Click(sender As System.Object, e As System.EventArgs) Handles m_btnSetDefault.Click
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim emUserSet As ENeptuneUserSet = CType(CType(m_cbUserSet.SelectedItem, ItemData).m_nValue, ENeptuneUserSet)
            Dim emErr As ENeptuneError = NeptuneC.ntcSetPowerOnDefaultUserSet(Me.m_refMainForm.m_pCameraHandle, emUserSet)
            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, ("PowerOnDefault: UserSet" + CType(emUserSet, Integer).ToString))
            Else
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetPowerOnDefaultUserSet Failed.", emErr)
            End If

        End If
    End Sub
End Class