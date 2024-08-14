using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using NeptuneC_Interface;

namespace NeptuneCSample_CSharp
{
    public partial class PopupAltLedForm : Form
    {
        private NeptuneCSampleForm m_refMainForm = null;

        private Int32 m_iTableItemCnt;
        private Int32 m_iTableSubItemCnt;

        public PopupAltLedForm(NeptuneCSampleForm refMainForm)
        {
            InitializeComponent();

            m_refMainForm = refMainForm;

            m_iTableItemCnt = 255;
            m_iTableSubItemCnt = 64;
        }

        public void UpdateForm()
        {
            bool bEnable = false;
            if (m_refMainForm.m_pCameraHandle != null)
            {
                ENeptuneDevType emDevType = ENeptuneDevType.NEPTUNE_DEV_TYPE_UNKNOWN;
                if (NeptuneC.ntcGetCameraType(m_refMainForm.m_pCameraHandle, ref emDevType) == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    if (emDevType == ENeptuneDevType.NEPTUNE_DEV_TYPE_USB3)
                    {
                        ENeptuneError emErr = NeptuneC.ntcInitCam4AltLed(m_refMainForm.m_pCameraHandle);
                        if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                        {
                            bEnable = true;
                        }
                        else
                        {
                            m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcInitCam4AltLed Failed.", emErr);
                        }
                    }
                }
            }

            Enabled = bEnable;
            if (bEnable)
            {
                ZeroFillTable();

                m_rbIndex.Checked = true;
                m_btnAutoRun.Checked = true;
                m_tbStartIndex.Text = "0";
                m_gridTable.Rows[0].Selected = true;
            }
        }

        public void InitControls()
        {
            m_gridTable.MultiSelect = false;
            m_gridTable.AllowUserToAddRows = false;
            m_gridTable.RowHeadersWidth = 60;

            String strColumnName;
            for (Int32 i=1; i<=m_iTableSubItemCnt; i++)
            {
                strColumnName = "Ch"+i.ToString();
                Int32 iIndex = m_gridTable.Columns.Add(strColumnName, strColumnName);
                m_gridTable.Columns[iIndex].Width = 60;
            }

            for (Int32 i=0; i<m_iTableItemCnt; i++)
            {
                m_gridTable.Rows.Add();
            }

            foreach (DataGridViewRow row in m_gridTable.Rows)
            {
                row.HeaderCell.Value = row.Index.ToString();
            }
        }

        private void PopupAltLedForm_Load(object sender, EventArgs e)
        {
            InitControls();
            UpdateForm();
        }

        private void PopupAltLedForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_refMainForm.m_formPopupAltLed = null;
        }

        private void m_btnSet_Click(object sender, EventArgs e)
        {
            if (m_rbIndex.Checked)
            {
                ENeptuneBoolean bAutoRun = m_btnAutoRun.Checked ? ENeptuneBoolean.NEPTUNE_BOOL_TRUE : ENeptuneBoolean.NEPTUNE_BOOL_FALSE;

                Int32 iStart = Convert.ToInt32(m_tbStartIndex.Text);
                if (iStart < 0)
                {
                    iStart = 0;
                }
                else if (iStart > 254)
                {
                    iStart = 254;
                }

                m_tbStartIndex.Text = iStart.ToString();

                ENeptuneError emErr = NeptuneC.ntcSetCam4AltLedIndex(m_refMainForm.m_pCameraHandle, bAutoRun, iStart, 254);
                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, "Set Alt LED Index.", emErr);
                }
                else
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetCam4AltLedIndex Failed.", emErr);
                }
            }
            else
            {
                ENeptuneError emErr = NeptuneC.ntcSetCam4AltLedDirect(m_refMainForm.m_pCameraHandle, m_gridTable.CurrentCell.RowIndex);
                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    String strText = "Set Alt LED Direct " + m_gridTable.CurrentCell.RowIndex + ".";
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, strText, emErr);
                }
                else
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetCam4AltLedDirect Failed.", emErr);
                }
            }
        }

        private void m_btnUpdateTable_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Int32[] pTable = new Int32[m_iTableItemCnt * m_iTableSubItemCnt];
            Int32 iSize = m_iTableItemCnt * m_iTableSubItemCnt * sizeof(Int32);

            Int32 iIndex = 0;
            for (Int32 i = 0; i < m_iTableItemCnt; i++)
            {
                for (Int32 nSubItem = 0; nSubItem < m_iTableSubItemCnt; nSubItem++)
                {
                    iIndex = i * m_iTableSubItemCnt + nSubItem;

                    pTable[iIndex] = Convert.ToInt32(m_gridTable.Rows[i].Cells[nSubItem].Value);
                }
            }

            ENeptuneError emErr = NeptuneC.ntcUpdateCam4AltLedTable(m_refMainForm.m_pCameraHandle, pTable, iSize);
            if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
            {
                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, "Set Update ALT LED Table.", emErr);
            }
            else
            {
                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcUpdateCam4AltLedTable Failed.", emErr);
            }

            Cursor.Current = Cursors.Default;
        }

        private void m_btnZeroFill_Click(object sender, EventArgs e)
        {
            ZeroFillTable();
        }

        private void m_btnSampleFill_Click(object sender, EventArgs e)
        {
            SampleFillTable();
        }

        private void ZeroFillTable()
        {
            foreach (DataGridViewRow row in this.m_gridTable.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Value = 0;
                }
            }
        }
        private void SampleFillTable()
        {
            ZeroFillTable();

            bool bForward = true;

            Int32 iOffsetX = -1;
            for (Int32 i = 0; i < m_iTableItemCnt; i++)
            {
                if (bForward)
                {
                    iOffsetX++;
                }
                else
                {
                    iOffsetX--;
                }

                for (Int32 x = iOffsetX; x < m_iTableSubItemCnt; x += 8)
                {
                    m_gridTable.Rows[i].Cells[x].Value = i+1;
                }

                if (i != 0)
                {
                    if (iOffsetX == 0 || iOffsetX == 7)
                    {
                        bForward = !bForward;
                    }
                }
            }
        }

        private void m_gridTable_SelectionChanged(object sender, EventArgs e)
        {
            m_rbDirect.Text = "Direct " + m_gridTable.CurrentCell.RowIndex;
        }

        private void m_rbIndex_CheckedChanged(object sender, EventArgs e)
        {
            m_btnAutoRun.Enabled = true;
            m_tbStartIndex.Enabled = true;
        }

        private void m_rbDirect_CheckedChanged(object sender, EventArgs e)
        {
            m_btnAutoRun.Enabled = false;
            m_tbStartIndex.Enabled = false;
        }

        private void m_gridTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Int32 iRow = e.RowIndex;
            Int32 iCol = e.ColumnIndex;

            if (iRow >= 0 && iCol >= 0)
            {
                Int32 iValue = Convert.ToInt32(m_gridTable.Rows[iRow].Cells[iCol].Value);
                if (iValue < 0)
                {
                    iValue = 0;
                    m_gridTable.Rows[iRow].Cells[iCol].Value = iValue;
                }
                else if (iValue > 255)
                {
                    iValue = 255;
                    m_gridTable.Rows[iRow].Cells[iCol].Value = iValue;
                }
            }
        }

    }
}
