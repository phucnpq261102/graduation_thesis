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
    public partial class PopupAutoFocusForm : Form
    {
        private NeptuneCSampleForm m_refMainForm = null;

        public PopupAutoFocusForm(NeptuneCSampleForm refMainForm)
        {
            InitializeComponent();

            m_refMainForm = refMainForm;
        }

        private void InitControls()
        {
        }

        public void UpdateForm()
        {
        }

        private void PopupAutoFocusForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            InitControls();
            UpdateForm();
        }

        private void PopupAutoFocusForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_refMainForm.m_formPopupAutoFocus = null;
        }

        private void m_btnOriginal_Click(object sender, EventArgs e)
        {
            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                ENeptuneError emErr = NeptuneC.ntcSetAFControl(m_refMainForm.m_pCameraHandle, ENeptuneAFMode.NEPTUNE_AF_ORIGIN);
                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, "Set Auto Focus: ORIGIN.");
                }
                else
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetAFControl Failed.", emErr);
                }
            }
        }
        
        private void m_btnOnePush_Click(object sender, EventArgs e)
        {
            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                ENeptuneError emErr = NeptuneC.ntcSetAFControl(m_refMainForm.m_pCameraHandle, ENeptuneAFMode.NEPTUNE_AF_ONEPUSH);
                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, "Set Auto Focus: ONEPUSH.");
                }
                else
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetAFControl Failed.", emErr);
                }
            }
        }

        private void m_btnOneStepForward_Click(object sender, EventArgs e)
        {
            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                ENeptuneError emErr = NeptuneC.ntcSetAFControl(m_refMainForm.m_pCameraHandle, ENeptuneAFMode.NEPTUNE_AF_STEP_FORWARD);
                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, "Set Auto Focus: STEP FORWARD.");
                }
                else
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetAFControl Failed.", emErr);
                }
            }
        }

        private void m_btnOneStepBackward_Click(object sender, EventArgs e)
        {
            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                ENeptuneError emErr = NeptuneC.ntcSetAFControl(m_refMainForm.m_pCameraHandle, ENeptuneAFMode.NEPTUNE_AF_STEP_BACKWARD);
                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, "Set Auto Focus: STEP BACKWARD.");
                }
                else
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetAFControl Failed.", emErr);
                }
            }
        }
    }
}
