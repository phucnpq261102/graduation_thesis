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
    public partial class PopupFrameSaveForm : Form
    {
        private NeptuneCSampleForm m_refMainForm = null;

        public PopupFrameSaveForm(NeptuneCSampleForm refMainForm)
        {
            InitializeComponent();

            m_refMainForm = refMainForm;
        }

        private void InitControls()
        {
        }

        public void UpdateForm()
        {
            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                ENeptuneBoolean emOnOff = ENeptuneBoolean.NEPTUNE_BOOL_FALSE;
                UInt32 uiFrameRemained = 0;
                ENeptuneError emErr = NeptuneC.ntcGetFrameSave(m_refMainForm.m_pCameraHandle, ref emOnOff, ref uiFrameRemained);
                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_ckEnable.Checked = (emOnOff == ENeptuneBoolean.NEPTUNE_BOOL_TRUE ? true : false);
                    m_edRemained.Text = uiFrameRemained.ToString();
                }
                else
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetFrameSave Failed.", emErr);
                }
            }
        }

        private void PopupFrameSaveForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            UpdateForm();
        }

        private void PopupFrameSaveForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_refMainForm.m_formPopupFrameSave = null;
        }

        private void m_ckEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                ENeptuneBoolean emOnOff = (m_ckEnable.Checked ? ENeptuneBoolean.NEPTUNE_BOOL_TRUE : ENeptuneBoolean.NEPTUNE_BOOL_FALSE);
                ENeptuneError emErr = NeptuneC.ntcSetFrameSave(m_refMainForm.m_pCameraHandle, emOnOff, ENeptuneBoolean.NEPTUNE_BOOL_FALSE, 0);
                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    UpdateForm();
                }
                else
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetFrameSave Failed.", emErr);
                }
            }
        }

        private void m_btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void m_btnPlay_Click(object sender, EventArgs e)
        {
            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                ENeptuneBoolean emOnOff = (m_ckEnable.Checked ? ENeptuneBoolean.NEPTUNE_BOOL_TRUE : ENeptuneBoolean.NEPTUNE_BOOL_FALSE);
                UInt32 uiFrameRemained = (UInt32)m_edRecvCount.Value;
                ENeptuneError emErr = NeptuneC.ntcSetFrameSave(m_refMainForm.m_pCameraHandle, emOnOff, ENeptuneBoolean.NEPTUNE_BOOL_TRUE, uiFrameRemained);
                if (emErr != ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetFrameSave Failed.", emErr);
                }
            }
        }
    }
}
