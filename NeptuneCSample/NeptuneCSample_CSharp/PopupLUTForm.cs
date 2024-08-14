using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using NeptuneC_Interface;

namespace NeptuneCSample_CSharp
{
    public partial class PopupLUTForm : Form
    {
        private NeptuneCSampleForm m_refMainForm = null;

        private NumericUpDown[] m_arrPointX;
        private NumericUpDown[] m_arrPointY;

        private Int32 m_nMinRange = 0;
        private Int32 m_nMaxRange = 4095;
        private Int32 m_nRadius = 4;
        private Int32 m_nSelectIndex = -1;
        private bool m_bClickDown = false;

        public PopupLUTForm(NeptuneCSampleForm refMainForm)
        {
            InitializeComponent();

            m_refMainForm = refMainForm;
        }

        private void InitControls()
        {
            m_wndFileBrowser.InitialDirectory = Application.StartupPath;
            m_arrPointX = new NumericUpDown[] {m_edPointX1, m_edPointX2, m_edPointX3, m_edPointX4};
            m_arrPointY = new NumericUpDown[] {m_edPointY1, m_edPointY2, m_edPointY3, m_edPointY4};
            for (int i = 0; i < m_arrPointX.Length; i++)
            {
                m_arrPointX[i].Minimum = m_nMinRange;
                m_arrPointY[i].Minimum = m_nMinRange;
                m_arrPointX[i].Maximum = m_nMaxRange;
                m_arrPointY[i].Maximum = m_nMaxRange;
            }
        }

        public void UpdateForm()
        {
            m_ckEnableLUT.Checked = false;
            for (int i = 0; i < m_arrPointX.Length; i++)
            {
                m_arrPointX[i].Value = m_nMinRange;
                m_arrPointY[i].Value = m_nMinRange;
            }
            m_ckEnableUserLUT.Checked = false;
            m_cbUserLUT.Items.Clear();

            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                NEPTUNE_KNEE_LUT stKneeLUT = new NEPTUNE_KNEE_LUT();
                ENeptuneError emErr = NeptuneC.ntcGetKneeLUT(m_refMainForm.m_pCameraHandle, ref stKneeLUT);
                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_ckEnableLUT.Checked = (stKneeLUT.bEnable == ENeptuneBoolean.NEPTUNE_BOOL_TRUE ? true : false);
                    for (int i = 0; i < m_arrPointX.Length; i++)
                    {
                        m_arrPointX[i].Value = stKneeLUT.Points[i].x;
                        m_arrPointY[i].Value = stKneeLUT.Points[i].y;
                    }
                }
                else
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetKneeLUT Failed.", emErr);
                }

                NEPTUNE_USER_LUT stUserLUT = new NEPTUNE_USER_LUT();
                emErr = NeptuneC.ntcGetUserLUT(m_refMainForm.m_pCameraHandle, ref stUserLUT);
                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_ckEnableUserLUT.Checked = (stUserLUT.bEnable == ENeptuneBoolean.NEPTUNE_BOOL_TRUE ? true : false);
                    for (int i = 0; i < 16; i++)
                    {
                        if (((stUserLUT.SupportLUT >> i) & 0x01) == 0x01)
                        {
                            m_cbUserLUT.Items.Add(new ItemData("LUT" + i.ToString(), i));
                        }
                    }
                    m_cbUserLUT.SelectedIndex = stUserLUT.LUTIndex;
                }
                else
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetUserLUT Failed.", emErr);
                }
            }
        }

        private void PopupLUTForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            InitControls();
            UpdateForm();
        }

        private void PopupLUTForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_refMainForm.m_formPopupLUT = null;
        }

        private void m_wndGraph_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            
            int nBlockCnt = 8;
            float fWidthUnit = m_wndGraph.Size.Width / nBlockCnt;
            float fHeightUnit = m_wndGraph.Size.Height / nBlockCnt;
            for (int i = 0; i < (nBlockCnt - 1); i++)
            {
                e.Graphics.DrawLine(pen, (i + 1) * fWidthUnit, 0, (i + 1) * fWidthUnit, m_wndGraph.Size.Height);
                e.Graphics.DrawLine(pen, 0, (i + 1) * fHeightUnit, m_wndGraph.Size.Height, (i + 1) * fHeightUnit);
            }

            pen.Width = 2;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            Brush brush = new SolidBrush(Color.Red);
            
            float fPrevX = 0;
            float fPrevY = m_wndGraph.Size.Height;
            for (Int32 i = 0; i < m_arrPointX.Length; i++)
            {
                float fPointX = (Int32)m_arrPointX[i].Value * m_wndGraph.Size.Width / m_nMaxRange;
                float fPointY = m_wndGraph.Size.Height - ((Int32)m_arrPointY[i].Value * m_wndGraph.Size.Height / m_nMaxRange);
                e.Graphics.DrawLine(pen, fPrevX, fPrevY, fPointX, fPointY);
                e.Graphics.FillEllipse(brush, fPointX - m_nRadius, fPointY - m_nRadius, m_nRadius * 2, m_nRadius * 2);
                fPrevX = fPointX;
                fPrevY = fPointY;
            }
            e.Graphics.DrawLine(pen, fPrevX, fPrevY, m_wndGraph.Size.Width, 0);
        }

        private void m_wndGraph_MouseDown(object sender, MouseEventArgs e)
        {
            m_nSelectIndex = -1;
            for (Int32 i = 0; i < m_arrPointX.Length; i++)
            {
                float fPointX = (Int32)m_arrPointX[i].Value * m_wndGraph.Size.Width / m_nMaxRange;
                float fPointY = m_wndGraph.Size.Height - ((Int32)m_arrPointY[i].Value * m_wndGraph.Size.Height / m_nMaxRange);
                if (e.X >= (fPointX - m_nRadius) && e.X <= (fPointX + m_nRadius) && e.Y >= (fPointY - m_nRadius) && e.Y <= (fPointY + m_nRadius))
                {
                    m_nSelectIndex = i;
                    m_bClickDown = true;
                    break;
                }
            }
        }

        private void m_wndGraph_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_bClickDown == true)
            {
                float fPointX = e.X * m_nMaxRange / m_wndGraph.Size.Width;
                float fPointY = (m_wndGraph.Size.Height - e.Y) * m_nMaxRange / m_wndGraph.Size.Height;
                InsertPointValue(m_nSelectIndex, (Int32)fPointX, (Int32)fPointY);
            }
        }

        private void m_wndGraph_MouseUp(object sender, MouseEventArgs e)
        {
            m_bClickDown = false;
            m_nSelectIndex = -1;
        }

        private void m_btnLinearLUT_Click(object sender, EventArgs e)
        {
            Int32 nPointX = 1000;
            Int32 nPointY = 1000;
            for (Int32 i = 0; i < m_arrPointX.Length; i++)
            {
                InsertPointValue(i, nPointX, nPointY);
                nPointX += 500;
                nPointY += 500;
            }
        }

        private void m_btnApplyLUT_Click(object sender, EventArgs e)
        {
            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                NEPTUNE_KNEE_LUT stKneeLUT = new NEPTUNE_KNEE_LUT();
                stKneeLUT.bEnable = (m_ckEnableLUT.Checked ? ENeptuneBoolean.NEPTUNE_BOOL_TRUE : ENeptuneBoolean.NEPTUNE_BOOL_FALSE);
                stKneeLUT.Points = new NEPTUNE_POINT[4];
                for (int i = 0; i < stKneeLUT.Points.Length; i++)
                {
                    stKneeLUT.Points[i].x = (UInt32)m_arrPointX[i].Value;
                    stKneeLUT.Points[i].y = (UInt32)m_arrPointY[i].Value;
                }
                ENeptuneError emErr = NeptuneC.ntcSetKneeLUT(m_refMainForm.m_pCameraHandle, stKneeLUT);
                if (emErr != ENeptuneError.NEPTUNE_ERR_Success)
                {
                    UpdateForm();
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetKneeLUT Failed.", emErr);
                }
            }
        }

        private void m_btnSaveUserLUT_Click(object sender, EventArgs e)
        {
            if (m_wndFileBrowser.ShowDialog() == DialogResult.OK)
            {
                if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
                {
                    NEPTUNE_USER_LUT stUserLUT = new NEPTUNE_USER_LUT();
                    stUserLUT.LUTIndex = (UInt16)((ItemData)m_cbUserLUT.SelectedItem).m_nValue;
                    stUserLUT.Data = new UInt16[4096];

                    Int32 nBufSize = Marshal.SizeOf(stUserLUT.Data[0]) * stUserLUT.Data.Length;
                    Byte[] arrBuf = new Byte[nBufSize];

                    String strFilePathName = m_wndFileBrowser.FileName;
                    System.IO.FileStream stream = new System.IO.FileStream(strFilePathName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                    stream.Read(arrBuf, 0, arrBuf.Length);
                    stream.Close();

                    Buffer.BlockCopy(arrBuf, 0, stUserLUT.Data, 0, arrBuf.Length);

                    ENeptuneError emErr = NeptuneC.ntcSetUserLUT(m_refMainForm.m_pCameraHandle, stUserLUT);
                    if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                    {
                        m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, "Write Data: LUT" + stUserLUT.LUTIndex.ToString());
                    }
                    else
                    {
                        m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetUserLUT Failed.", emErr);
                    }
                }
            }
        }

        private void m_btnApplyUserLUT_Click(object sender, EventArgs e)
        {
            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                NEPTUNE_USER_LUT stUserLUT = new NEPTUNE_USER_LUT();
                stUserLUT.bEnable = (m_ckEnableUserLUT.Checked ? ENeptuneBoolean.NEPTUNE_BOOL_TRUE : ENeptuneBoolean.NEPTUNE_BOOL_FALSE);
                stUserLUT.LUTIndex = (UInt16)((ItemData)m_cbUserLUT.SelectedItem).m_nValue;
                ENeptuneError emErr = NeptuneC.ntcSetUserLUT(m_refMainForm.m_pCameraHandle, stUserLUT);
                if (emErr != ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetUserLUT Failed.", emErr);
                }
            }
        }

        private void InsertPointValue(Int32 nIndex, Int32 nPointX, Int32 nPointY)
        {
            if (nPointX < (Int32)m_arrPointX[nIndex].Minimum)
            {
                nPointX = (Int32)m_arrPointX[nIndex].Minimum;
            }
            if (nPointX > (Int32)m_arrPointX[nIndex].Maximum)
            {
                nPointX = (Int32)m_arrPointX[nIndex].Maximum;
            }
            if (nPointY < (Int32)m_arrPointY[nIndex].Minimum)
            {
                nPointY = (Int32)m_arrPointY[nIndex].Minimum;
            }
            if (nPointY > (Int32)m_arrPointY[nIndex].Maximum)
            {
                nPointY = (Int32)m_arrPointY[nIndex].Maximum;
            }
            m_arrPointX[nIndex].Value = nPointX;
            m_arrPointY[nIndex].Value = nPointY;
            m_wndGraph.Invalidate();
        }
    }
}
