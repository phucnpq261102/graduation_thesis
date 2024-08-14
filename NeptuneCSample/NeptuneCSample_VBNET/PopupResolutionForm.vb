Imports NeptuneCSample_VBNET.NeptuneC_Interface

Public Class PopupResolutionForm
    Private m_refMainForm As NeptuneCSampleForm = Nothing

    Public Sub New(ByVal refMainForm As NeptuneCSampleForm)
        InitializeComponent()
        Me.m_refMainForm = refMainForm
    End Sub

    Private Sub InitControls()

    End Sub

    Public Sub UpdateForm()
        m_stcResolution.Text = "Resolution: Width x Height"
        m_edOffsetX.Minimum = 0
        m_edOffsetX.Maximum = 0
        m_edOffsetX.Value = 0
        m_edOffsetY.Minimum = 0
        m_edOffsetY.Maximum = 0
        m_edOffsetY.Value = 0
        m_edWidth.Minimum = 0
        m_edWidth.Maximum = 0
        m_edWidth.Value = 0
        m_edHeight.Minimum = 0
        m_edHeight.Maximum = 0
        m_edHeight.Value = 0
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim stImageSize As NEPTUNE_IMAGE_SIZE = New NEPTUNE_IMAGE_SIZE
            Dim emErr As ENeptuneError = NeptuneC.ntcGetMaxImageSize(Me.m_refMainForm.m_pCameraHandle, stImageSize)
            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                m_stcResolution.Text = ("Resolution: " _
                            + (stImageSize.nSizeX.ToString + (" x " + stImageSize.nSizeY.ToString)))
                m_edOffsetX.Maximum = stImageSize.nSizeX
                m_edOffsetY.Maximum = stImageSize.nSizeY
                m_edWidth.Maximum = stImageSize.nSizeX
                m_edHeight.Maximum = stImageSize.nSizeY
                emErr = NeptuneC.ntcGetImageSize(Me.m_refMainForm.m_pCameraHandle, stImageSize)
                If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                    m_edOffsetX.Value = stImageSize.nStartX
                    m_edOffsetY.Value = stImageSize.nStartY
                    m_edWidth.Value = stImageSize.nSizeX
                    m_edHeight.Value = stImageSize.nSizeY
                Else
                    Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetImageSize Failed.", emErr)
                End If

            Else
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetMaxImageSize Failed.", emErr)
            End If

        End If

    End Sub

    Private Sub PopupResolutionForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.InitControls()
        Me.UpdateForm()
    End Sub

    Private Sub PopupResolutionForm_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.m_refMainForm.m_formPopupResolution = Nothing
    End Sub

    Private Sub m_btnApply_Click(sender As System.Object, e As System.EventArgs) Handles m_btnApply.Click
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim stImageSize As NEPTUNE_IMAGE_SIZE = New NEPTUNE_IMAGE_SIZE
            stImageSize.nStartX = CType(m_edOffsetX.Value, Int32)
            stImageSize.nStartY = CType(m_edOffsetY.Value, Int32)
            stImageSize.nSizeX = CType(m_edWidth.Value, Int32)
            stImageSize.nSizeY = CType(m_edHeight.Value, Int32)
            Dim emErr1 As ENeptuneError = NeptuneC.ntcSetImageSize(Me.m_refMainForm.m_pCameraHandle, stImageSize)
            If (emErr1 <> ENeptuneError.NEPTUNE_ERR_Success) Then
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetImageSize Failed.", emErr1)
                Me.UpdateForm()
            End If
            Dim emErr2 As ENeptuneError = NeptuneC.ntcGetMaxImageSize(Me.m_refMainForm.m_pCameraHandle, stImageSize)
            If (emErr2 = ENeptuneError.NEPTUNE_ERR_Success) Then
                m_stcResolution.Text = ("Resolution: " _
                            + (stImageSize.nSizeX.ToString + (" x " + stImageSize.nSizeY.ToString)))
                m_edOffsetX.Maximum = stImageSize.nSizeX
                m_edOffsetY.Maximum = stImageSize.nSizeY
                m_edWidth.Maximum = stImageSize.nSizeX
                m_edHeight.Maximum = stImageSize.nSizeY
                emErr2 = NeptuneC.ntcGetImageSize(Me.m_refMainForm.m_pCameraHandle, stImageSize)
                If (emErr2 = ENeptuneError.NEPTUNE_ERR_Success) Then
                    m_edOffsetX.Value = stImageSize.nStartX
                    m_edOffsetY.Value = stImageSize.nStartY
                    m_edWidth.Value = stImageSize.nSizeX
                    m_edHeight.Value = stImageSize.nSizeY
                Else
                    Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetImageSize Failed.", emErr2)
                End If

            Else
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetMaxImageSize Failed.", emErr2)
            End If
        End If
    End Sub
End Class