Imports NeptuneCSample_VBNET.NeptuneC_Interface

Public Class PopupSIOControlForm
    Private m_refMainForm As NeptuneCSampleForm = Nothing

    Public Sub New(ByVal refMainForm As NeptuneCSampleForm)
        InitializeComponent()
        Me.m_refMainForm = refMainForm
    End Sub

    Private Sub InitControls()
        m_cbBaudRate.Items.Clear()
        m_cbBaudRate.Items.Add(New ItemData("300", 300))
        m_cbBaudRate.Items.Add(New ItemData("600", 600))
        m_cbBaudRate.Items.Add(New ItemData("1200", 1200))
        m_cbBaudRate.Items.Add(New ItemData("2400", 2400))
        m_cbBaudRate.Items.Add(New ItemData("4800", 4800))
        m_cbBaudRate.Items.Add(New ItemData("9600", 9600))
        m_cbBaudRate.Items.Add(New ItemData("19200", 19200))
        m_cbBaudRate.Items.Add(New ItemData("38400", 38400))
        m_cbBaudRate.Items.Add(New ItemData("57600", 57600))
        m_cbBaudRate.Items.Add(New ItemData("115200", 115200))
        m_cbBaudRate.Items.Add(New ItemData("230400", 230400))
        m_cbBaudRate.SelectedIndex = 7
        m_cbParityBits.Items.Clear()
        m_cbParityBits.Items.Add(New ItemData("None", CType(ENeptuneSIOParity.NEPTUNE_SIO_PARITY_NONE, Integer)))
        m_cbParityBits.Items.Add(New ItemData("Odd", CType(ENeptuneSIOParity.NEPTUNE_SIO_PARITY_ODD, Integer)))
        m_cbParityBits.Items.Add(New ItemData("Even", CType(ENeptuneSIOParity.NEPTUNE_SIO_PARITY_EVEN, Integer)))
        m_cbParityBits.SelectedIndex = 0
        m_cbDataBits.Items.Clear()
        m_cbDataBits.Items.Add(New ItemData("7", 7))
        m_cbDataBits.Items.Add(New ItemData("8", 8))
        m_cbDataBits.SelectedIndex = 1
        m_cbStopBits.Items.Clear()
        m_cbStopBits.Items.Add(New ItemData("1", 1))
        m_cbStopBits.Items.Add(New ItemData("2", 2))
        m_cbStopBits.SelectedIndex = 0
    End Sub

    Public Sub UpdateForm()

    End Sub

    Private Sub PopupSIOControlForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.InitControls()
        Me.UpdateForm()
    End Sub

    Private Sub PopupSIOControlForm_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.m_refMainForm.m_formPopupSIOControl = Nothing
    End Sub

    Private Sub m_btnApply_Click(sender As System.Object, e As System.EventArgs) Handles m_btnApply.Click
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim stProperty As NEPTUNE_SIO_PROPERTY = New NEPTUNE_SIO_PROPERTY
            If m_ckEnable.Checked = True Then
                stProperty.bEnable = ENeptuneBoolean.NEPTUNE_BOOL_TRUE
            Else
                stProperty.bEnable = ENeptuneBoolean.NEPTUNE_BOOL_FALSE
            End If

            stProperty.Baudrate = CType(CType(m_cbBaudRate.SelectedItem, ItemData).m_nValue, UInt32)
            stProperty.Parity = CType(CType(m_cbParityBits.SelectedItem, ItemData).m_nValue, ENeptuneSIOParity)
            stProperty.DataBit = CType(CType(m_cbDataBits.SelectedItem, ItemData).m_nValue, UInt32)
            stProperty.StopBit = CType(CType(m_cbStopBits.SelectedItem, ItemData).m_nValue, UInt32)
            Dim emErr As ENeptuneError = NeptuneC.ntcSetSIO(Me.m_refMainForm.m_pCameraHandle, stProperty)
            If (emErr <> ENeptuneError.NEPTUNE_ERR_Success) Then
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetSIO Failed.", emErr)
            End If

        End If
    End Sub

    Private Sub m_btnSend_Click(sender As System.Object, e As System.EventArgs) Handles m_btnSend.Click
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim stSIO As NEPTUNE_SIO = New NEPTUNE_SIO
            stSIO.strText = m_edData.Text
            Dim emErr As ENeptuneError = NeptuneC.ntcWriteSIO(Me.m_refMainForm.m_pCameraHandle, stSIO)
            If (emErr <> ENeptuneError.NEPTUNE_ERR_Success) Then
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcWriteSIO Failed.", emErr)
            End If

        End If
    End Sub

    Private Sub m_btnReceive_Click(sender As System.Object, e As System.EventArgs) Handles m_btnReceive.Click
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim stSIO As NEPTUNE_SIO = New NEPTUNE_SIO
            Dim emErr As ENeptuneError = NeptuneC.ntcReadSIO(Me.m_refMainForm.m_pCameraHandle, stSIO)
            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                m_edData.Text = stSIO.strText
            Else
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcReadSIO Failed.", emErr)
            End If

        End If
    End Sub
End Class