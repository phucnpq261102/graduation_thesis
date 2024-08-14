Imports System.Runtime.InteropServices
Imports NeptuneCSample_VBNET.NeptuneC_Interface

Public Class PopupLUTForm
    Private m_refMainForm As NeptuneCSampleForm = Nothing

    Private m_arrPointX() As NumericUpDown

    Private m_arrPointY() As NumericUpDown

    Private m_nMinRange As Int32 = 0

    Private m_nMaxRange As Int32 = 4095

    Private m_nRadius As Int32 = 4

    Private m_nSelectIndex As Int32 = -1

    Private m_bClickDown As Boolean = False

    Public Sub New(ByVal refMainForm As NeptuneCSampleForm)
        InitializeComponent()
        Me.m_refMainForm = refMainForm
    End Sub

    Private Sub InitControls()
        m_wndFileBrowser.InitialDirectory = Application.StartupPath
        Me.m_arrPointX = New NumericUpDown() {m_edPointX1, m_edPointX2, m_edPointX3, m_edPointX4}
        Me.m_arrPointY = New NumericUpDown() {m_edPointY1, m_edPointY2, m_edPointY3, m_edPointY4}
        Dim i As Integer = 0
        For i = 0 To Me.m_arrPointX.Length - 1
            Me.m_arrPointX(i).Minimum = Me.m_nMinRange
            Me.m_arrPointY(i).Minimum = Me.m_nMinRange
            Me.m_arrPointX(i).Maximum = Me.m_nMaxRange
            Me.m_arrPointY(i).Maximum = Me.m_nMaxRange
        Next

    End Sub

    Public Sub UpdateForm()
        m_ckEnableLUT.Checked = False
        Dim i As Integer
        For i = 0 To Me.m_arrPointX.Length - 1
            Me.m_arrPointX(i).Value = Me.m_nMinRange
            Me.m_arrPointY(i).Value = Me.m_nMinRange
        Next

        m_ckEnableUserLUT.Checked = False
        m_cbUserLUT.Items.Clear()
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim stKneeLUT As NEPTUNE_KNEE_LUT = New NEPTUNE_KNEE_LUT
            Dim emErr As ENeptuneError = NeptuneC.ntcGetKneeLUT(Me.m_refMainForm.m_pCameraHandle, stKneeLUT)
            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                If stKneeLUT.bEnable = ENeptuneBoolean.NEPTUNE_BOOL_TRUE Then
                    m_ckEnableLUT.Checked = True
                Else
                    m_ckEnableLUT.Checked = False
                End If

                For i = 0 To Me.m_arrPointX.Length - 1
                    Me.m_arrPointX(i).Value = stKneeLUT.Points(i).x
                    Me.m_arrPointY(i).Value = stKneeLUT.Points(i).y
                Next
            Else
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetKneeLUT Failed.", emErr)
            End If

            Dim stUserLUT As NEPTUNE_USER_LUT = New NEPTUNE_USER_LUT
            emErr = NeptuneC.ntcGetUserLUT(Me.m_refMainForm.m_pCameraHandle, stUserLUT)
            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                If stUserLUT.bEnable = ENeptuneBoolean.NEPTUNE_BOOL_TRUE Then
                    m_ckEnableUserLUT.Checked = True
                Else
                    m_ckEnableUserLUT.Checked = False
                End If

                For i = 0 To 15
                    If ((stUserLUT.SupportLUT >> i) And &H1) = &H1 Then
                        m_cbUserLUT.Items.Add(New ItemData(("LUT" + i.ToString), i))
                    End If
                Next

                m_cbUserLUT.SelectedIndex = stUserLUT.LUTIndex
            Else
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetUserLUT Failed.", emErr)
            End If

        End If

    End Sub

    Private Sub PopupLUTForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.InitControls()
        Me.UpdateForm()
    End Sub

    Private Sub PopupLUTForm_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.m_refMainForm.m_formPopupLUT = Nothing
    End Sub

    Private Sub m_wndGraph_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles m_wndGraph.Paint
        Dim pen As Pen = New Pen(Color.Black)
        pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot
        Dim nBlockCnt As Integer = 8
        Dim fWidthUnit As Single = (m_wndGraph.Size.Width / nBlockCnt)
        Dim fHeightUnit As Single = (m_wndGraph.Size.Height / nBlockCnt)
        Dim i As Integer = 0
        For i = 0 To nBlockCnt - 2
            e.Graphics.DrawLine(pen, ((i + 1) _
                            * fWidthUnit), 0, ((i + 1) _
                            * fWidthUnit), m_wndGraph.Size.Height)
            e.Graphics.DrawLine(pen, 0, ((i + 1) _
                            * fHeightUnit), m_wndGraph.Size.Height, ((i + 1) _
                            * fHeightUnit))
        Next

        pen.Width = 2
        pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Dim brush As Brush = New SolidBrush(Color.Red)
        Dim fPrevX As Single = 0
        Dim fPrevY As Single = m_wndGraph.Size.Height

        For i = 0 To Me.m_arrPointX.Length - 1
            Dim fPointX As Single = (CType(Me.m_arrPointX(i).Value, Int32) _
                        * (m_wndGraph.Size.Width / Me.m_nMaxRange))
            Dim fPointY As Single = (m_wndGraph.Size.Height _
                        - (CType(Me.m_arrPointY(i).Value, Int32) _
                        * (m_wndGraph.Size.Height / Me.m_nMaxRange)))
            e.Graphics.DrawLine(pen, fPrevX, fPrevY, fPointX, fPointY)
            e.Graphics.FillEllipse(brush, (fPointX - Me.m_nRadius), (fPointY - Me.m_nRadius), (Me.m_nRadius * 2), (Me.m_nRadius * 2))
            fPrevX = fPointX
            fPrevY = fPointY
        Next
            
        e.Graphics.DrawLine(pen, fPrevX, fPrevY, m_wndGraph.Size.Width, 0)
    End Sub

    Private Sub m_wndGraph_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles m_wndGraph.MouseDown
        Me.m_nSelectIndex = -1
        Dim i As Int32 = 0
        For i = 0 To Me.m_arrPointX.Length - 1
            Dim fPointX As Single = (CType(Me.m_arrPointX(i).Value, Int32) _
                        * (m_wndGraph.Size.Width / Me.m_nMaxRange))
            Dim fPointY As Single = (m_wndGraph.Size.Height _
                        - (CType(Me.m_arrPointY(i).Value, Int32) _
                        * (m_wndGraph.Size.Height / Me.m_nMaxRange)))
            If ((e.X _
                        >= (fPointX - Me.m_nRadius)) _
                        AndAlso ((e.X _
                        <= (fPointX + Me.m_nRadius)) _
                        AndAlso ((e.Y _
                        >= (fPointY - Me.m_nRadius)) _
                        AndAlso (e.Y _
                        <= (fPointY + Me.m_nRadius))))) Then
                Me.m_nSelectIndex = i
                Me.m_bClickDown = True
                Exit For
            End If
        Next
    End Sub

    Private Sub m_wndGraph_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles m_wndGraph.MouseMove
        If (Me.m_bClickDown = True) Then
            Dim fPointX As Single = (e.X _
                        * (Me.m_nMaxRange / m_wndGraph.Size.Width))
            Dim fPointY As Single = ((m_wndGraph.Size.Height - e.Y) _
                        * (Me.m_nMaxRange / m_wndGraph.Size.Height))
            Me.InsertPointValue(Me.m_nSelectIndex, CType(fPointX, Int32), CType(fPointY, Int32))
        End If
    End Sub

    Private Sub m_wndGraph_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles m_wndGraph.MouseUp
        Me.m_bClickDown = False
        Me.m_nSelectIndex = -1
    End Sub

    Private Sub m_btnLinearLUT_Click(sender As System.Object, e As System.EventArgs) Handles m_btnLinearLUT.Click
        Dim nPointX As Int32 = 1000
        Dim nPointY As Int32 = 1000
        Dim i As Int32 = 0
        For i = 0 To Me.m_arrPointX.Length - 1
            Me.InsertPointValue(i, nPointX, nPointY)
            nPointX = (nPointX + 500)
            nPointY = (nPointY + 500)
        Next
    End Sub

    Private Sub m_btnApplyLUT_Click(sender As System.Object, e As System.EventArgs) Handles m_btnApplyLUT.Click
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim stKneeLUT As NEPTUNE_KNEE_LUT = New NEPTUNE_KNEE_LUT
            If m_ckEnableLUT.Checked = True Then
                stKneeLUT.bEnable = ENeptuneBoolean.NEPTUNE_BOOL_TRUE
            Else
                stKneeLUT.bEnable = ENeptuneBoolean.NEPTUNE_BOOL_FALSE
            End If

            stKneeLUT.Points = New NEPTUNE_POINT((4) - 1) {}
            Dim i As Integer = 0
            For i = 0 To stKneeLUT.Points.Length - 1
                stKneeLUT.Points(i).x = CType(Me.m_arrPointX(i).Value, UInt32)
                stKneeLUT.Points(i).y = CType(Me.m_arrPointY(i).Value, UInt32)
            Next

            Dim emErr As ENeptuneError = NeptuneC.ntcSetKneeLUT(Me.m_refMainForm.m_pCameraHandle, stKneeLUT)
            If (emErr <> ENeptuneError.NEPTUNE_ERR_Success) Then
                Me.UpdateForm()
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetKneeLUT Failed.", emErr)
            End If

        End If
    End Sub

    Private Sub m_btnSaveUserLUT_Click(sender As System.Object, e As System.EventArgs) Handles m_btnSaveUserLUT.Click
        If (m_wndFileBrowser.ShowDialog = DialogResult.OK) Then
            If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
                Dim stUserLUT As NEPTUNE_USER_LUT = New NEPTUNE_USER_LUT
                stUserLUT.LUTIndex = CType(CType(m_cbUserLUT.SelectedItem, ItemData).m_nValue, UInt16)
                stUserLUT.Data = New UInt16((4096) - 1) {}
                Dim nBufSize As Int32 = (Marshal.SizeOf(stUserLUT.Data(0)) * stUserLUT.Data.Length)
                Dim arrBuf() As Byte = New Byte((nBufSize) - 1) {}
                Dim strFilePathName As String = m_wndFileBrowser.FileName
                Dim stream As System.IO.FileStream = New System.IO.FileStream(strFilePathName, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                stream.Read(arrBuf, 0, arrBuf.Length)
                stream.Close()
                Buffer.BlockCopy(arrBuf, 0, stUserLUT.Data, 0, arrBuf.Length)
                Dim emErr As ENeptuneError = NeptuneC.ntcSetUserLUT(Me.m_refMainForm.m_pCameraHandle, stUserLUT)
                If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                    Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, ("Write Data: LUT" + stUserLUT.LUTIndex.ToString))
                Else
                    Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetUserLUT Failed.", emErr)
                End If

            End If

        End If
    End Sub

    Private Sub m_btnApplyUserLUT_Click(sender As System.Object, e As System.EventArgs) Handles m_btnApplyUserLUT.Click
        If (Me.m_refMainForm.m_pCameraHandle <> IntPtr.Zero) Then
            Dim stUserLUT As NEPTUNE_USER_LUT = New NEPTUNE_USER_LUT
            If m_ckEnableUserLUT.Checked = True Then
                stUserLUT.bEnable = ENeptuneBoolean.NEPTUNE_BOOL_TRUE
            Else
                stUserLUT.bEnable = ENeptuneBoolean.NEPTUNE_BOOL_FALSE
            End If

            stUserLUT.LUTIndex = CType(CType(m_cbUserLUT.SelectedItem, ItemData).m_nValue, UInt16)
            Dim emErr As ENeptuneError = NeptuneC.ntcSetUserLUT(Me.m_refMainForm.m_pCameraHandle, stUserLUT)
            If (emErr <> ENeptuneError.NEPTUNE_ERR_Success) Then
                Me.m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetUserLUT Failed.", emErr)
            End If

        End If
    End Sub

    Private Sub InsertPointValue(ByVal nIndex As Int32, ByVal nPointX As Int32, ByVal nPointY As Int32)
        If (nPointX < CType(Me.m_arrPointX(nIndex).Minimum, Int32)) Then
            nPointX = CType(Me.m_arrPointX(nIndex).Minimum, Int32)
        End If

        If (nPointX > CType(Me.m_arrPointX(nIndex).Maximum, Int32)) Then
            nPointX = CType(Me.m_arrPointX(nIndex).Maximum, Int32)
        End If

        If (nPointY < CType(Me.m_arrPointY(nIndex).Minimum, Int32)) Then
            nPointY = CType(Me.m_arrPointY(nIndex).Minimum, Int32)
        End If

        If (nPointY > CType(Me.m_arrPointY(nIndex).Maximum, Int32)) Then
            nPointY = CType(Me.m_arrPointY(nIndex).Maximum, Int32)
        End If

        Me.m_arrPointX(nIndex).Value = nPointX
        Me.m_arrPointY(nIndex).Value = nPointY
        m_wndGraph.Invalidate()
    End Sub
End Class