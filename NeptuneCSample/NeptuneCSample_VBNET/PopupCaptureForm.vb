Imports NeptuneCSample_VBNET.NeptuneC_Interface

Public Class PopupCaptureForm
    Private m_refMainForm As NeptuneCSampleForm = Nothing
    Private bRecording As Boolean = False

    Public Sub New(ByVal refMainForm As NeptuneCSampleForm)
        InitializeComponent()
        Me.m_refMainForm = refMainForm
    End Sub

    Private Sub InitControls()
        m_wndFolderBrowser.SelectedPath = Application.StartupPath
        m_edSavePath.Text = m_wndFolderBrowser.SelectedPath
        m_cbImageForamt.Items.Clear()
        m_cbImageForamt.Items.Add("RGB")
        m_cbImageForamt.Items.Add("BMP")
        m_cbImageForamt.Items.Add("JPG")
        m_cbImageForamt.Items.Add("TIF")
        m_cbImageForamt.Items.Add("AVI")
        m_cbImageForamt.SelectedIndex = 0
    End Sub

    Public Sub UpdateForm()

    End Sub

    Private Sub PopupCaptureForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.InitControls()
        Me.UpdateForm()
    End Sub

    Private Sub PopupCaptureForm_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.m_refMainForm.m_formPopupCapture = Nothing
    End Sub

    Private Sub m_btnBrowser_Click(sender As System.Object, e As System.EventArgs) Handles m_btnBrowser.Click
        If (m_wndFolderBrowser.ShowDialog = DialogResult.OK) Then
            m_edSavePath.Text = m_wndFolderBrowser.SelectedPath
        End If
    End Sub

    Private Sub m_cbImageForamt_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles m_cbImageForamt.SelectedIndexChanged
        If (m_cbImageForamt.SelectedIndex <> -1) Then
            m_btnSaveImage.Enabled = Not m_cbImageForamt.SelectedItem.Equals("AVI")
            m_btnStartRecord.Enabled = m_cbImageForamt.SelectedItem.Equals("AVI")
            m_btnStopRecord.Enabled = False
            If (Not m_cbImageForamt.SelectedItem.Equals("AVI") _
                        AndAlso Me.bRecording) Then
                m_btnStopRecord.PerformClick()
            End If

        End If
    End Sub

    Private Sub m_btnSaveImage_Click(sender As System.Object, e As System.EventArgs) Handles m_btnSaveImage.Click
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim dt As DateTime = DateTime.Now
            Dim strPathName As String = ("Capture_" _
                        + (dt.ToString("HHmmss_fff.") + m_cbImageForamt.SelectedItem.ToString))
            strPathName = System.IO.Path.Combine(m_edSavePath.Text, strPathName)

            Dim emErr As ENeptuneError = ENeptuneError.NEPTUNE_ERR_Fail
            If (m_cbImageForamt.SelectedItem.Equals("RGB")) Then
                Dim stImageSize As NEPTUNE_IMAGE_SIZE = New NEPTUNE_IMAGE_SIZE
                emErr = NeptuneC.ntcGetImageSize(Me.m_refMainForm.m_pCameraHandle, stImageSize)
                If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                    Dim uiBufSize As UInt32 = (stImageSize.nSizeX * stImageSize.nSizeY * 3)
                    Dim arrBuffer() As Byte = New Byte((uiBufSize) - 1) {}
                    emErr = NeptuneC.ntcGetRGBData(Me.m_refMainForm.m_pCameraHandle, arrBuffer, uiBufSize)
                    If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                        Dim stream As System.IO.FileStream = New System.IO.FileStream(strPathName, System.IO.FileMode.Create, System.IO.FileAccess.Write)
                        stream.Write(arrBuffer, 0, arrBuffer.Length)
                        stream.Close()
                    End If
                Else
                    emErr = NeptuneC.ntcSaveImage(Me.m_refMainForm.m_pCameraHandle, strPathName, 100)
                End If

                If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                    Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, ("Save Image: " + strPathName))
                Else
                    Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSaveImage Failed.", emErr)
                End If
            End If
        End If
    End Sub

    Private Sub m_btnStartRecord_Click(sender As System.Object, e As System.EventArgs) Handles m_btnStartRecord.Click
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim dt As DateTime = DateTime.Now
            Dim strPathName As String = ("Capture_" _
                        + (dt.ToString("HHmmss_fff.") + m_cbImageForamt.SelectedItem.ToString))
            strPathName = System.IO.Path.Combine(m_edSavePath.Text, strPathName)
            Dim emErr As ENeptuneError = NeptuneC.ntcStartStreamCapture(Me.m_refMainForm.m_pCameraHandle, strPathName, ENeptuneBoolean.NEPTUNE_BOOL_TRUE, 4000, 1.0)
            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                m_btnStartRecord.Enabled = False
                m_btnStopRecord.Enabled = True
                Me.bRecording = True
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, ("Start Recording: " + strPathName))
            Else
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcStartStreamCapture Failed.", emErr)
            End If

        End If
    End Sub

    Private Sub m_btnStopRecord_Click(sender As System.Object, e As System.EventArgs) Handles m_btnStopRecord.Click
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim emErr As ENeptuneError = NeptuneC.ntcStopStreamCapture(Me.m_refMainForm.m_pCameraHandle)
            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                m_btnStartRecord.Enabled = True
                m_btnStopRecord.Enabled = False
                Me.bRecording = False
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, "Stop Recording.")
            Else
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcStopStreamCapture Failed.", emErr)
            End If

        End If
    End Sub
End Class