Imports NeptuneCSample_VBNET.NeptuneC_Interface

Public Class PopupGrabForm
    Private m_refMainForm As NeptuneCSampleForm = Nothing

    Public Sub New(ByVal refMainForm As NeptuneCSampleForm)
        MyBase.New()
        InitializeComponent()
        Me.m_refMainForm = refMainForm
    End Sub

    Private Sub InitControls()
        m_wndFolderBrowser.SelectedPath = Application.StartupPath
        m_edSavePath.Text = m_wndFolderBrowser.SelectedPath
    End Sub

    Public Sub UpdateForm()

    End Sub

    Private Sub PopupGrabForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.UpdateForm()
        Me.InitControls()
    End Sub

    Private Sub PopupGrabForm_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.m_refMainForm.m_formPopupGrab = Nothing
    End Sub

    Private Sub m_btnBrowser_Click(sender As System.Object, e As System.EventArgs) Handles m_btnBrowser.Click
        If (m_wndFolderBrowser.ShowDialog = DialogResult.OK) Then
            m_edSavePath.Text = m_wndFolderBrowser.SelectedPath
        End If
    End Sub

    Private Sub m_btnGrab_Click(sender As System.Object, e As System.EventArgs) Handles m_btnGrab.Click
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim uiSize As UInt32 = 0
            Dim emErr As ENeptuneError = NeptuneC.ntcGetBufferSize(Me.m_refMainForm.m_pCameraHandle, uiSize)
            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                Dim arrBuffer() As Byte = New Byte((uiSize) - 1) {}
                Dim stImageInfo As NEPTUNE_IMAGE = New NEPTUNE_IMAGE
                stImageInfo.pData = System.Runtime.InteropServices.Marshal.AllocHGlobal(arrBuffer.Length)
                System.Runtime.InteropServices.Marshal.Copy(arrBuffer, 0, stImageInfo.pData, arrBuffer.Length)
                emErr = NeptuneC.ntcGrab(Me.m_refMainForm.m_pCameraHandle, stImageInfo, ENeptuneGrabFormat.NEPTUNE_GRAB_RAW, 1000)
                If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                    System.Runtime.InteropServices.Marshal.Copy(stImageInfo.pData, arrBuffer, 0, arrBuffer.Length)
                    Dim dt As DateTime = DateTime.Now
                    Dim strPathName As String = ("Grab_" + dt.ToString("HHmmss_fff.raw"))
                    strPathName = System.IO.Path.Combine(m_edSavePath.Text, strPathName)
                    Dim stream As System.IO.FileStream = New System.IO.FileStream(strPathName, System.IO.FileMode.Create, System.IO.FileAccess.Write)
                    stream.Write(arrBuffer, 0, arrBuffer.Length)
                    stream.Close()
                    Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, ("Grab Image: " + strPathName))
                Else
                    Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGrab Failed.", emErr)
                End If

                System.Runtime.InteropServices.Marshal.FreeHGlobal(stImageInfo.pData)
            Else
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetBufferSize Failed.", emErr)
            End If

        End If
    End Sub
End Class