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
    public partial class PopupResolutionForm : Form
    {
        private NeptuneCSampleForm m_refMainForm = null;

        public PopupResolutionForm(NeptuneCSampleForm refMainForm)
        {
            InitializeComponent();

            m_refMainForm = refMainForm;
        }

        private void InitControls()
        {
        }

        public void UpdateForm()
        {
            m_stcResolution.Text = "Resolution: Width x Height";
            m_edOffsetX.Minimum = 0;
            m_edOffsetX.Maximum = 0;
            m_edOffsetX.Value = 0;
            m_edOffsetY.Minimum = 0;
            m_edOffsetY.Maximum = 0;
            m_edOffsetY.Value = 0;
            m_edWidth.Minimum = 0;
            m_edWidth.Maximum = 0;
            m_edWidth.Value = 0;
            m_edHeight.Minimum = 0;
            m_edHeight.Maximum = 0;
            m_edHeight.Value = 0;

            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                NEPTUNE_IMAGE_SIZE stImageSize = new NEPTUNE_IMAGE_SIZE();
                ENeptuneError emErr = NeptuneC.ntcGetMaxImageSize(m_refMainForm.m_pCameraHandle, ref stImageSize);
                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_stcResolution.Text = "Resolution: " + stImageSize.nSizeX.ToString() + " x " + stImageSize.nSizeY.ToString();
                    m_edOffsetX.Maximum = stImageSize.nSizeX;
                    m_edOffsetY.Maximum = stImageSize.nSizeY;
                    m_edWidth.Maximum = stImageSize.nSizeX;
                    m_edHeight.Maximum = stImageSize.nSizeY;
                    emErr = NeptuneC.ntcGetImageSize(m_refMainForm.m_pCameraHandle, ref stImageSize);
                    if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                    {
                        m_edOffsetX.Value = stImageSize.nStartX;
                        m_edOffsetY.Value = stImageSize.nStartY;
                        m_edWidth.Value = stImageSize.nSizeX;
                        m_edHeight.Value = stImageSize.nSizeY;
                    }
                    else
                    {
                        m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetImageSize Failed.", emErr);
                    }
                }
                else
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetMaxImageSize Failed.", emErr);
                }
            }
        }

        private void PopupResolutionForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            InitControls();
            UpdateForm();
        }

        private void PopupResolutionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_refMainForm.m_formPopupResolution = null;
        }

        private void m_btnApply_Click(object sender, EventArgs e)
        {
            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                NEPTUNE_IMAGE_SIZE stImageSize = new NEPTUNE_IMAGE_SIZE();
                stImageSize.nStartX = (Int32)m_edOffsetX.Value;
                stImageSize.nStartY = (Int32)m_edOffsetY.Value;
                stImageSize.nSizeX = (Int32)m_edWidth.Value;
                stImageSize.nSizeY = (Int32)m_edHeight.Value;
                ENeptuneError emErr = NeptuneC.ntcSetImageSize(m_refMainForm.m_pCameraHandle, stImageSize);
                if (emErr != ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetImageSize Failed.", emErr);
                    UpdateForm();
                }
                emErr = NeptuneC.ntcGetMaxImageSize(m_refMainForm.m_pCameraHandle, ref stImageSize);
                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_stcResolution.Text = "Resolution: " + stImageSize.nSizeX.ToString() + " x " + stImageSize.nSizeY.ToString();
                    m_edOffsetX.Maximum = stImageSize.nSizeX;
                    m_edOffsetY.Maximum = stImageSize.nSizeY;
                    m_edWidth.Maximum = stImageSize.nSizeX;
                    m_edHeight.Maximum = stImageSize.nSizeY;
                    emErr = NeptuneC.ntcGetImageSize(m_refMainForm.m_pCameraHandle, ref stImageSize);
                    if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                    {
                        m_edOffsetX.Value = stImageSize.nStartX;
                        m_edOffsetY.Value = stImageSize.nStartY;
                        m_edWidth.Value = stImageSize.nSizeX;
                        m_edHeight.Value = stImageSize.nSizeY;
                    }
                    else
                    {
                        m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetImageSize Failed.", emErr);
                    }
                }
                else
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetMaxImageSize Failed.", emErr);
                }
            }
        }
    }
}
