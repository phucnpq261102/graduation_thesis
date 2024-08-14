Imports System.Runtime.InteropServices
Imports NeptuneCSample_VBNET.NeptuneC_Interface

Public Class PopupAltLedForm
    Private m_refMainForm As NeptuneCSampleForm = Nothing

    Private m_iTableItemCnt As Int32
    Private m_iTableSubItemCnt As Int32

    Public Sub New(ByVal refMainForm As NeptuneCSampleForm)
        MyBase.New()
        InitializeComponent()
        m_refMainForm = refMainForm

        m_iTableItemCnt = 255
        m_iTableSubItemCnt = 64
    End Sub

    Public Sub UpdateForm()
        Dim bEnable As Boolean = False
        Dim eDeviceType As ENeptuneDevType = ENeptuneDevType.NEPTUNE_DEV_TYPE_UNKNOWN
        If (NeptuneC.ntcGetCameraType(m_refMainForm.m_pCameraHandle, eDeviceType) = ENeptuneError.NEPTUNE_ERR_Success) Then
            If eDeviceType = ENeptuneDevType.NEPTUNE_DEV_TYPE_USB3 Then
                Dim emErr As ENeptuneError = NeptuneC.ntcInitCam4AltLed(m_refMainForm.m_pCameraHandle)
                If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                    bEnable = True
                Else
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcInitCam4AltLed Failed.", emErr)
                End If
            End If
        End If

        Enabled = bEnable
        If (bEnable) Then
            ZeroFillTable()

            m_rbIndex.Checked = True
            m_btnAutoRun.Checked = True
            m_tbStartIndex.Text = "0"
            m_gridTable.Rows(0).Selected = True
        End If
    End Sub

    Private Sub InitControls()
        m_gridTable.MultiSelect = False
        m_gridTable.AllowUserToAddRows = False
        m_gridTable.RowHeadersWidth = 60

        Dim strColumnName As String
        Dim i As Int32
        For i = 1 To m_iTableSubItemCnt
            strColumnName = "Ch" + i.ToString()
            Dim iIndex As Int32 = m_gridTable.Columns.Add(strColumnName, strColumnName)
            m_gridTable.Columns(iIndex).Width = 60
        Next


        For i = 0 To m_iTableItemCnt - 1
            m_gridTable.Rows.Add()
        Next

        For Each row As DataGridViewRow In m_gridTable.Rows
            row.HeaderCell.Value = row.Index.ToString()
        Next
    End Sub

    Private Sub PopupAltLedForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        InitControls()
        UpdateForm()
    End Sub

    Private Sub PopupAltLedForm_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        m_refMainForm.m_formPopupAltLed = Nothing
    End Sub

    Private Sub m_btnSet_Click(sender As System.Object, e As System.EventArgs) Handles m_btnSet.Click
        If m_rbIndex.Checked Then
            Dim bAutoRun As ENeptuneBoolean
            If m_btnAutoRun.Checked Then
                bAutoRun = ENeptuneBoolean.NEPTUNE_BOOL_TRUE
            Else
                bAutoRun = ENeptuneBoolean.NEPTUNE_BOOL_FALSE
            End If

            Dim iStart As Int32 = Convert.ToInt32(m_tbStartIndex.Text)
            If (iStart < 0) Then
                iStart = 0
            ElseIf (iStart > 254) Then
                iStart = 254
            End If

            m_tbStartIndex.Text = iStart.ToString()

            Dim emErr As ENeptuneError = NeptuneC.ntcSetCam4AltLedIndex(m_refMainForm.m_pCameraHandle, bAutoRun, iStart, 254)
            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "Set Alt LED Index.", emErr)
            Else
                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetCam4AltLedIndex Failed.", emErr)
            End If
        Else
            Dim emErr As ENeptuneError = NeptuneC.ntcSetCam4AltLedDirect(m_refMainForm.m_pCameraHandle, m_gridTable.CurrentCell.RowIndex)
            If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
                Dim strText As String = "Set Alt LED Direct " + m_gridTable.CurrentCell.RowIndex + "."
                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, strText, emErr)
            Else
                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetCam4AltLedDirect Failed.", emErr)
            End If
        End If
    End Sub

    Private Sub m_btnUpdateTable_Click(sender As System.Object, e As System.EventArgs) Handles m_btnUpdateTable.Click
        Cursor.Current = Cursors.WaitCursor

        Dim pTable() As Int32 = New Int32(m_iTableItemCnt * m_iTableSubItemCnt) {}
        Dim iSize As Int32 = m_iTableItemCnt * m_iTableSubItemCnt * Marshal.SizeOf(New Int32)
        
        Dim iIndex As Int32 = 0

        Dim i As Int32
        For i = 0 To m_iTableItemCnt - 1
            Dim nSubItem As Int32
            For nSubItem = 0 To m_iTableSubItemCnt - 1
                iIndex = i * m_iTableSubItemCnt + nSubItem
                pTable(iIndex) = Convert.ToInt32(m_gridTable.Rows(i).Cells(nSubItem).Value)
            Next
        Next

        Dim emErr As ENeptuneError = NeptuneC.ntcUpdateCam4AltLedTable(m_refMainForm.m_pCameraHandle, pTable, iSize)
        If (emErr = ENeptuneError.NEPTUNE_ERR_Success) Then
            m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, "Set Update ALT LED Table.", emErr)
        Else
            m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcUpdateCam4AltLedTable Failed.", emErr)
        End If

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub m_btnZeroFill_Click(sender As System.Object, e As System.EventArgs) Handles m_btnZeroFill.Click
        ZeroFillTable()
    End Sub

    Private Sub m_btnSampleFill_Click(sender As System.Object, e As System.EventArgs) Handles m_btnSampleFill.Click
        SampleFillTable()
    End Sub

    Private Sub ZeroFillTable()
        For Each row As DataGridViewRow In m_gridTable.Rows
            For Each cell As DataGridViewCell In row.Cells
                cell.Value = 0
            Next
        Next
    End Sub

    Private Sub SampleFillTable()
        ZeroFillTable()

        Dim bForward As Boolean = True

        Dim iOffsetX As Int32 = -1

        Dim i As Int32
        For i = 0 To m_iTableItemCnt - 1
            If (bForward) Then
                iOffsetX = iOffsetX + 1
            Else
                iOffsetX = iOffsetX - 1
            End If

            Dim x As Int32
            For x = iOffsetX To m_iTableSubItemCnt - 1 Step 8
                m_gridTable.Rows(i).Cells(x).Value = i + 1
            Next

            If (i <> 0) Then
                If (iOffsetX = 0 Or iOffsetX = 7) Then
                    If bForward Then
                        bForward = False
                    Else
                        bForward = True
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub m_gridTable_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles m_gridTable.SelectionChanged
        m_rbDirect.Text = "Direct " + m_gridTable.CurrentCell.RowIndex.ToString()
    End Sub

    Private Sub m_rbIndex_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles m_rbIndex.CheckedChanged
        m_btnAutoRun.Enabled = True
        m_tbStartIndex.Enabled = True
    End Sub

    Private Sub m_rbDirect_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles m_rbDirect.CheckedChanged
        m_btnAutoRun.Enabled = False
        m_tbStartIndex.Enabled = False
    End Sub

    Private Sub m_gridTable_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles m_gridTable.CellValueChanged
        Dim iRow As Int32 = e.RowIndex
        Dim iCol As Int32 = e.ColumnIndex

        If (iRow >= 0 AndAlso iCol >= 0) Then
            Dim iValue As Int32 = Convert.ToInt32(m_gridTable.Rows(iRow).Cells(iCol).Value)
            If (iValue < 0) Then
                iValue = 0
                m_gridTable.Rows(iRow).Cells(iCol).Value = iValue
            ElseIf (iValue > 255) Then
                iValue = 255
                m_gridTable.Rows(iRow).Cells(iCol).Value = iValue
            End If
        End If
    End Sub
End Class