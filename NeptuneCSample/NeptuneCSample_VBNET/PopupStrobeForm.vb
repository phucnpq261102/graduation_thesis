Imports NeptuneCSample_VBNET.NeptuneC_Interface

Public Class PopupStrobeForm
    Private m_refMainForm As NeptuneCSampleForm = Nothing

    Public Sub New(ByVal refMainForm As NeptuneCSampleForm)
        MyBase.New()
        InitializeComponent()
        Me.m_refMainForm = refMainForm
    End Sub

    Private Sub InitControls()

    End Sub

    Public Sub UpdateForm()
        m_ckStrobeEnable.Checked = False
        m_cbStrobeMode.Items.Clear()
        m_cbStrobePolarity.Items.Clear()
        m_edStrobeDelay.Minimum = 0
        m_edStrobeDelay.Maximum = 0
        m_edStrobeDelay.Value = 0
        m_edStrobeDuration.Minimum = 0
        m_edStrobeDuration.Maximum = 0
        m_edStrobeDuration.Value = 0
        m_stcDelayRange.Text = "(Min ~ Max)"
        m_stcDurationRange.Text = "(Min ~ Max)"
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim stStrobeInfo As NEPTUNE_STROBE_INFO = New NEPTUNE_STROBE_INFO
            Dim emErr As ENeptuneError = NeptuneC.ntcGetStrobeInfo(Me.m_refMainForm.m_pCameraHandle, stStrobeInfo)
            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                If (stStrobeInfo.bSupport = ENeptuneBoolean.NEPTUNE_BOOL_TRUE) Then
                    Dim nFlag As Integer = CType(stStrobeInfo.nStrobeFlag, Integer)
                    Dim i As Int32 = 0
                    For i = 0 To 30
                        If (nFlag And &H1) = &H1 Then
                            Dim strItem As String = "Timer" + i.ToString()
                            m_cbStrobeMode.Items.Add(New ItemData(strItem, i))
                        End If

                        nFlag = (nFlag >> 1)
                    Next

                    nFlag = CType((stStrobeInfo.nPolarityFlag >> CType(ENeptunePolarity.NEPTUNE_POLARITY_RISINGEDGE, Integer)), Integer)
                    If ((nFlag And 1) _
                                = 1) Then
                        m_cbStrobePolarity.Items.Add(New ItemData("Rising Edge", CType(ENeptunePolarity.NEPTUNE_POLARITY_RISINGEDGE, Integer)))
                    End If

                    nFlag = CType((stStrobeInfo.nPolarityFlag >> CType(ENeptunePolarity.NEPTUNE_POLARITY_FALLINGEDGE, Integer)), Integer)
                    If ((nFlag And 1) _
                                = 1) Then
                        m_cbStrobePolarity.Items.Add(New ItemData("Falling Edge", CType(ENeptunePolarity.NEPTUNE_POLARITY_FALLINGEDGE, Integer)))
                    End If

                    nFlag = CType((stStrobeInfo.nPolarityFlag >> CType(ENeptunePolarity.NEPTUNE_POLARITY_ANYEDGE, Integer)), Integer)
                    If ((nFlag And 1) _
                                = 1) Then
                        m_cbStrobePolarity.Items.Add(New ItemData("Any Edge", CType(ENeptunePolarity.NEPTUNE_POLARITY_ANYEDGE, Integer)))
                    End If

                    nFlag = CType((stStrobeInfo.nPolarityFlag >> CType(ENeptunePolarity.NEPTUNE_POLARITY_LEVELHIGH, Integer)), Integer)
                    If ((nFlag And 1) _
                                = 1) Then
                        m_cbStrobePolarity.Items.Add(New ItemData("High Level", CType(ENeptunePolarity.NEPTUNE_POLARITY_LEVELHIGH, Integer)))
                    End If

                    nFlag = CType((stStrobeInfo.nPolarityFlag >> CType(ENeptunePolarity.NEPTUNE_POLARITY_LEVELLOW, Integer)), Integer)
                    If ((nFlag And 1) _
                                = 1) Then
                        m_cbStrobePolarity.Items.Add(New ItemData("Low Level", CType(ENeptunePolarity.NEPTUNE_POLARITY_LEVELLOW, Integer)))
                    End If

                    If ((stStrobeInfo.nDelayMin <> UShort.MaxValue) AndAlso (stStrobeInfo.nDelayMax <> UShort.MaxValue)) Then
                        m_edStrobeDelay.Minimum = stStrobeInfo.nDelayMin
                        m_edStrobeDelay.Maximum = stStrobeInfo.nDelayMax
                        m_stcDelayRange.Text = ("(" _
                                    + (m_edStrobeDelay.Minimum.ToString() + (" ~ " _
                                    + (m_edStrobeDelay.Maximum.ToString() + ")"))))
                    End If

                    If ((stStrobeInfo.nDurationMin <> UShort.MaxValue) AndAlso (stStrobeInfo.nDurationMax <> UShort.MaxValue)) Then
                        m_edStrobeDuration.Minimum = stStrobeInfo.nDurationMin
                        m_edStrobeDuration.Maximum = stStrobeInfo.nDurationMax
                        m_stcDurationRange.Text = ("(" _
                                    + (m_edStrobeDuration.Minimum.ToString() + (" ~ " _
                                    + (m_edStrobeDuration.Maximum.ToString() + ")"))))
                    End If
                    
                    Dim stStrobe As NEPTUNE_STROBE = New NEPTUNE_STROBE
                    emErr = NeptuneC.ntcGetStrobe(Me.m_refMainForm.m_pCameraHandle, stStrobe)
                    If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                        If stStrobe.OnOff = ENeptuneBoolean.NEPTUNE_BOOL_TRUE Then
                            m_ckStrobeEnable.Checked = True
                        Else
                            m_ckStrobeEnable.Checked = False
                        End If

                        For i = 0 To m_cbStrobeMode.Items.Count - 1
                            If (CType(m_cbStrobeMode.Items(i), ItemData).m_nValue = CType(stStrobe.Strobe, Integer)) Then
                                m_cbStrobeMode.SelectedIndex = i
                                Exit For
                            End If
                        Next

                        For i = 0 To m_cbStrobePolarity.Items.Count - 1
                            If (CType(m_cbStrobePolarity.Items(i), ItemData).m_nValue = CType(stStrobe.Polarity, Integer)) Then
                                m_cbStrobePolarity.SelectedIndex = i
                                Exit For
                            End If
                        Next

                        If (stStrobe.nDelay <> UShort.MaxValue) Then
                            m_edStrobeDelay.Value = stStrobe.nDelay
                        Else
                            m_edStrobeDelay.Enabled = False
                        End If

                        If (stStrobe.nDuration <> UShort.MaxValue) Then
                            m_edStrobeDuration.Value = stStrobe.nDuration
                        Else
                            m_edStrobeDuration.Enabled = False
                        End If
                    Else
                        Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetStrobe Failed.", emErr)
                    End If

                End If

            Else
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetStrobeInfo Failed.", emErr)
            End If

        End If

    End Sub

    Private Sub PopupStrobeForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.InitControls()
        Me.UpdateForm()
    End Sub

    Private Sub PopupStrobeForm_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.m_refMainForm.m_formPopupStrobe = Nothing
    End Sub

    Private Sub m_btnApply_Click(sender As System.Object, e As System.EventArgs) Handles m_btnApply.Click
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim stStrobe As NEPTUNE_STROBE = New NEPTUNE_STROBE
            If m_ckStrobeEnable.Checked = True Then
                stStrobe.OnOff = ENeptuneBoolean.NEPTUNE_BOOL_TRUE
            Else
                stStrobe.OnOff = ENeptuneBoolean.NEPTUNE_BOOL_FALSE
            End If

            stStrobe.Strobe = CType(CType(m_cbStrobeMode.SelectedItem, ItemData).m_nValue, ENeptuneStrobe)
            stStrobe.Polarity = CType(CType(m_cbStrobePolarity.SelectedItem, ItemData).m_nValue, ENeptunePolarity)
            If (m_edStrobeDelay.Enabled = True) Then
                stStrobe.nDelay = CType(m_edStrobeDelay.Value, System.UInt16)
            End If
            If (m_edStrobeDuration.Enabled = True) Then
                stStrobe.nDuration = CType(m_edStrobeDuration.Value, System.UInt16)
            End If
            Dim emErr As ENeptuneError = NeptuneC.ntcSetStrobe(Me.m_refMainForm.m_pCameraHandle, stStrobe)
            If (emErr <> ENeptuneError.NEPTUNE_ERR_Success) Then
                Me.UpdateForm()
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetStrobe Failed.", emErr)
            End If

            emErr = NeptuneC.ntcGetStrobe(Me.m_refMainForm.m_pCameraHandle, stStrobe)
            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                If stStrobe.OnOff = ENeptuneBoolean.NEPTUNE_BOOL_TRUE Then
                    m_ckStrobeEnable.Checked = True
                Else
                    m_ckStrobeEnable.Checked = False
                End If

                For i = 0 To m_cbStrobeMode.Items.Count - 1
                    If (CType(m_cbStrobeMode.Items(i), ItemData).m_nValue = CType(stStrobe.Strobe, Integer)) Then
                        m_cbStrobeMode.SelectedIndex = i
                        Exit For
                    End If
                Next

                For i = 0 To m_cbStrobePolarity.Items.Count - 1
                    If (CType(m_cbStrobePolarity.Items(i), ItemData).m_nValue = CType(stStrobe.Polarity, Integer)) Then
                        m_cbStrobePolarity.SelectedIndex = i
                        Exit For
                    End If
                Next

                If (stStrobe.nDelay <> UShort.MaxValue) Then
                    m_edStrobeDelay.Value = stStrobe.nDelay
                Else
                    m_edStrobeDelay.Enabled = False
                End If

                If (stStrobe.nDuration <> UShort.MaxValue) Then
                    m_edStrobeDuration.Value = stStrobe.nDuration
                Else
                    m_edStrobeDuration.Enabled = False
                End If
            Else
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetStrobe Failed.", emErr)
            End If
        End If
    End Sub
End Class