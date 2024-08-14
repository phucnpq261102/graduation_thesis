Imports NeptuneCSample_VBNET.NeptuneC_Interface

Public Class PopupTriggerForm
    Private m_refMainForm As NeptuneCSampleForm = Nothing

    Public Sub New(ByVal refMainForm As NeptuneCSampleForm)
        InitializeComponent()
        Me.m_refMainForm = refMainForm
    End Sub

    Private Sub InitControls()

    End Sub

    Public Sub UpdateForm()
        m_ckTriggerEnable.Checked = False
        m_cbTriggerMode.Items.Clear()
        m_cbTriggerSource.Items.Clear()
        m_cbTriggerPolarity.Items.Clear()
        m_edTriggerParam.Minimum = 0
        m_edTriggerParam.Maximum = 0
        m_edTriggerParam.Value = 0
        m_btnSWTrigger.Enabled = False
        m_stcParamRange.Text = "(Min ~ Max)"
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim stTriggerInfo As NEPTUNE_TRIGGER_INFO = New NEPTUNE_TRIGGER_INFO
            Dim emErr As ENeptuneError = NeptuneC.ntcGetTriggerInfo(Me.m_refMainForm.m_pCameraHandle, stTriggerInfo)
            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                If (stTriggerInfo.bSupport = ENeptuneBoolean.NEPTUNE_BOOL_TRUE) Then
                    Dim nFlag As Integer = CType(stTriggerInfo.nModeFlag, Integer)
                    Dim i As Integer = 0
                    For i = 0 To 30
                        If (nFlag And &H1) = &H1 Then
                            m_cbTriggerMode.Items.Add(New ItemData(("Mode" + i.ToString()), i))
                        End If

                        nFlag = (nFlag >> 1)
                    Next

                    nFlag = CType((stTriggerInfo.nSourceFlag >> CType(ENeptuneTriggerSource.NEPTUNE_TRIGGER_SOURCE_LINE1, Integer)), Integer)
                    If ((nFlag And 1) _
                                = 1) Then
                        m_cbTriggerSource.Items.Add(New ItemData("Line1", CType(ENeptuneTriggerSource.NEPTUNE_TRIGGER_SOURCE_LINE1, Integer)))
                    End If

                    nFlag = CType((stTriggerInfo.nSourceFlag >> CType(ENeptuneTriggerSource.NEPTUNE_TRIGGER_SOURCE_SW, Integer)), Integer)
                    If ((nFlag And 1) _
                                = 1) Then
                        m_cbTriggerSource.Items.Add(New ItemData("Software", CType(ENeptuneTriggerSource.NEPTUNE_TRIGGER_SOURCE_SW, Integer)))
                    End If

                    nFlag = CType((stTriggerInfo.nPolarityFlag >> CType(ENeptunePolarity.NEPTUNE_POLARITY_RISINGEDGE, Integer)), Integer)
                    If ((nFlag And 1) _
                                = 1) Then
                        m_cbTriggerPolarity.Items.Add(New ItemData("Rising Edge", CType(ENeptunePolarity.NEPTUNE_POLARITY_RISINGEDGE, Integer)))
                    End If

                    nFlag = CType((stTriggerInfo.nPolarityFlag >> CType(ENeptunePolarity.NEPTUNE_POLARITY_FALLINGEDGE, Integer)), Integer)
                    If ((nFlag And 1) _
                                = 1) Then
                        m_cbTriggerPolarity.Items.Add(New ItemData("Falling Edge", CType(ENeptunePolarity.NEPTUNE_POLARITY_FALLINGEDGE, Integer)))
                    End If

                    nFlag = CType((stTriggerInfo.nPolarityFlag >> CType(ENeptunePolarity.NEPTUNE_POLARITY_ANYEDGE, Integer)), Integer)
                    If ((nFlag And 1) _
                                = 1) Then
                        m_cbTriggerPolarity.Items.Add(New ItemData("Any Edge", CType(ENeptunePolarity.NEPTUNE_POLARITY_ANYEDGE, Integer)))
                    End If

                    nFlag = CType((stTriggerInfo.nPolarityFlag >> CType(ENeptunePolarity.NEPTUNE_POLARITY_LEVELHIGH, Integer)), Integer)
                    If ((nFlag And 1) _
                                = 1) Then
                        m_cbTriggerPolarity.Items.Add(New ItemData("High Level", CType(ENeptunePolarity.NEPTUNE_POLARITY_LEVELHIGH, Integer)))
                    End If

                    nFlag = CType((stTriggerInfo.nPolarityFlag >> CType(ENeptunePolarity.NEPTUNE_POLARITY_LEVELLOW, Integer)), Integer)
                    If ((nFlag And 1) _
                                = 1) Then
                        m_cbTriggerPolarity.Items.Add(New ItemData("Low Level", CType(ENeptunePolarity.NEPTUNE_POLARITY_LEVELLOW, Integer)))
                    End If

                    m_edTriggerParam.Minimum = stTriggerInfo.nParamMin
                    m_edTriggerParam.Maximum = stTriggerInfo.nParamMax
                    m_stcParamRange.Text = ("(" _
                                + (m_edTriggerParam.Minimum.ToString() + (" ~ " _
                                + (m_edTriggerParam.Maximum.ToString() + ")"))))
                    Dim stTrigger As NEPTUNE_TRIGGER = New NEPTUNE_TRIGGER
                    emErr = NeptuneC.ntcGetTrigger(Me.m_refMainForm.m_pCameraHandle, stTrigger)
                    If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                        If stTrigger.OnOff = ENeptuneBoolean.NEPTUNE_BOOL_TRUE Then
                            m_ckTriggerEnable.Checked = True
                        Else
                            m_ckTriggerEnable.Checked = False
                        End If

                        For i = 0 To m_cbTriggerMode.Items.Count - 1
                            If (CType(m_cbTriggerMode.Items(i), ItemData).m_nValue = CType(stTrigger.Mode, Integer)) Then
                                m_cbTriggerMode.SelectedIndex = i
                                Exit For
                            End If
                        Next

                        For i = 0 To m_cbTriggerSource.Items.Count - 1
                            If (CType(m_cbTriggerSource.Items(i), ItemData).m_nValue = CType(stTrigger.Source, Integer)) Then
                                m_cbTriggerSource.SelectedIndex = i
                                Exit For
                            End If
                        Next

                        For i = 0 To m_cbTriggerPolarity.Items.Count - 1
                            If (CType(m_cbTriggerPolarity.Items(i), ItemData).m_nValue = CType(stTrigger.Polarity, Integer)) Then
                                m_cbTriggerPolarity.SelectedIndex = i
                                Exit For
                            End If
                        Next

                        m_edTriggerParam.Value = stTrigger.nParam
                        m_btnSWTrigger.Enabled = ((stTrigger.Source = ENeptuneTriggerSource.NEPTUNE_TRIGGER_SOURCE_SW) _
                                    AndAlso (stTrigger.OnOff = ENeptuneBoolean.NEPTUNE_BOOL_TRUE))
                    Else
                        Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetTrigger Failed.", emErr)
                    End If

                End If

            Else
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetTriggerInfo Failed.", emErr)
            End If

        End If

    End Sub

    Private Sub PopupTriggerForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.InitControls()
        Me.UpdateForm()
    End Sub

    Private Sub PopupTriggerForm_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.m_refMainForm.m_formPopupTrigger = Nothing
    End Sub

    Private Sub m_btnApply_Click(sender As System.Object, e As System.EventArgs) Handles m_btnApply.Click
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim stTrigger As NEPTUNE_TRIGGER = New NEPTUNE_TRIGGER
            If m_ckTriggerEnable.Checked = True Then
                stTrigger.OnOff = ENeptuneBoolean.NEPTUNE_BOOL_TRUE
            Else
                stTrigger.OnOff = ENeptuneBoolean.NEPTUNE_BOOL_FALSE
            End If

            stTrigger.Mode = CType(CType(m_cbTriggerMode.SelectedItem, ItemData).m_nValue, ENeptuneTriggerMode)
            stTrigger.Source = CType(CType(m_cbTriggerSource.SelectedItem, ItemData).m_nValue, ENeptuneTriggerSource)
            stTrigger.Polarity = CType(CType(m_cbTriggerPolarity.SelectedItem, ItemData).m_nValue, ENeptunePolarity)
            stTrigger.nParam = CType(m_edTriggerParam.Value, System.UInt16)
            Dim emErr As ENeptuneError = NeptuneC.ntcSetTrigger(Me.m_refMainForm.m_pCameraHandle, stTrigger)
            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                m_btnSWTrigger.Enabled = ((stTrigger.Source = ENeptuneTriggerSource.NEPTUNE_TRIGGER_SOURCE_SW) _
                            AndAlso (stTrigger.OnOff = ENeptuneBoolean.NEPTUNE_BOOL_TRUE))
            Else
                Me.UpdateForm()
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetTrigger Failed.", emErr)
            End If

        End If
    End Sub

    Private Sub m_btnSWTrigger_Click(sender As System.Object, e As System.EventArgs) Handles m_btnSWTrigger.Click
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            NeptuneC.ntcRunSWTrigger(Me.m_refMainForm.m_pCameraHandle)
        End If
    End Sub
End Class