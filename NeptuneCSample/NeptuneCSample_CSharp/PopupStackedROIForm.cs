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
    public partial class PopupStackedROIForm : Form
    {
        private NeptuneCSampleForm m_refMainForm = null;

        public PopupStackedROIForm(NeptuneCSampleForm refMainForm)
        {
            InitializeComponent();

            m_refMainForm = refMainForm;
        }

        private void InitControls()
        {
            for (int i = 0; i < 8; i++ )
            {
                m_cbROISelector.Items.Add(i.ToString());
            }
        }

        private void GetStackedROIControl()
        {
            ENeptuneBoolean bControl = ENeptuneBoolean.NEPTUNE_BOOL_FALSE;
            ENeptuneError err = NeptuneC.ntcGetStackedRoiControl(m_refMainForm.m_pCameraHandle, ref bControl);
            if (err != ENeptuneError.NEPTUNE_ERR_Success)
            {
                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetStackedRoiControl Failed", err);
            }
            m_ckControl.Checked = bControl == ENeptuneBoolean.NEPTUNE_BOOL_TRUE;
        }

        private void GetStackedROIOffsetX()
        {
            ENeptuneError err = ENeptuneError.NEPTUNE_ERR_Success;

	        UInt32 uiOffsetX = 0;

            Int32 iSel = m_cbROISelector.SelectedIndex;
            Int32 iCnt = m_cbROISelector.Items.Count;

            for (Int32 i = 0; i < iCnt; i++)
	        {
                err = NeptuneC.ntcSetStackedRoiSelector(m_refMainForm.m_pCameraHandle, (UInt32)i);
                if (err == ENeptuneError.NEPTUNE_ERR_Success)
		        {
                    ENeptuneBoolean bEnable = ENeptuneBoolean.NEPTUNE_BOOL_FALSE;
                    err = NeptuneC.ntcGetStackedRoiSelectedEnable(m_refMainForm.m_pCameraHandle, ref bEnable);
                    if (err == ENeptuneError.NEPTUNE_ERR_Success)
			        {
                        if (bEnable == ENeptuneBoolean.NEPTUNE_BOOL_TRUE)
				        {
                            err = NeptuneC.ntcGetStackedRoiOffsetX(m_refMainForm.m_pCameraHandle, ref uiOffsetX);
                            if (err == ENeptuneError.NEPTUNE_ERR_Success)
					        {
						        break;
					        }
				        }
			        }
		        }
	        }
            NeptuneC.ntcSetStackedRoiSelector(m_refMainForm.m_pCameraHandle, (UInt32)iSel);

            m_tbAllOffsetX.Text = uiOffsetX.ToString();
        }

        private void GetStackedROIWidth()
        {
            ENeptuneError err = ENeptuneError.NEPTUNE_ERR_Success;

	        UInt32 uiWidth = 0;

            Int32 iSel = m_cbROISelector.SelectedIndex;
            Int32 iCnt = m_cbROISelector.Items.Count;

            for (Int32 i = 0; i < iCnt; i++)
	        {
                err = NeptuneC.ntcSetStackedRoiSelector(m_refMainForm.m_pCameraHandle, (UInt32)i);
                if (err == ENeptuneError.NEPTUNE_ERR_Success)
		        {
                    ENeptuneBoolean bEnable = ENeptuneBoolean.NEPTUNE_BOOL_FALSE;
                    err = NeptuneC.ntcGetStackedRoiSelectedEnable(m_refMainForm.m_pCameraHandle, ref bEnable);
                    if (err == ENeptuneError.NEPTUNE_ERR_Success)
			        {
                        if (bEnable == ENeptuneBoolean.NEPTUNE_BOOL_TRUE)
				        {

                            err = NeptuneC.ntcGetStackedRoiWidth(m_refMainForm.m_pCameraHandle, ref uiWidth);
                            if (err == ENeptuneError.NEPTUNE_ERR_Success)
					        {
						        break;
					        }
				        }
			        }
		        }
	        }
            NeptuneC.ntcSetStackedRoiSelector(m_refMainForm.m_pCameraHandle, (UInt32)iSel);

            m_tbAllWidth.Text = uiWidth.ToString();
        }

        private void GetSelectedStackedROI()
        {
            UInt32 uiIdx = 0;
	        ENeptuneError err = NeptuneC.ntcGetStackedRoiSelector(m_refMainForm.m_pCameraHandle, ref uiIdx);
            if (err != ENeptuneError.NEPTUNE_ERR_Success)
	        {
                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetStackedRoiSelector Failed", err);
	        }
	        m_cbROISelector.SelectedIndex = (Int32)uiIdx;
        }

        private void GetSelectedStackedROIInfo()
        {
            ENeptuneBoolean bEnable = ENeptuneBoolean.NEPTUNE_BOOL_FALSE;
	        UInt32 uiOffsetX = 0;
            UInt32 uiOffsetY = 0;
            UInt32 uiWidth = 0;
            UInt32 uiHeight = 0;
            ENeptuneError err = ENeptuneError.NEPTUNE_ERR_Success;

            err = NeptuneC.ntcGetStackedRoiSelectedEnable(m_refMainForm.m_pCameraHandle, ref bEnable);
            if (err != ENeptuneError.NEPTUNE_ERR_Success)
	        {
                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetStackedRoiSelectedEnable Failed", err);
	        }

            err = NeptuneC.ntcGetStackedRoiOffsetX(m_refMainForm.m_pCameraHandle, ref uiOffsetX);
            if (err != ENeptuneError.NEPTUNE_ERR_Success)
	        {
                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetStackedRoiOffsetX Failed", err);
	        }

            err = NeptuneC.ntcGetStackedRoiOffsetY(m_refMainForm.m_pCameraHandle, ref uiOffsetY);
            if (err != ENeptuneError.NEPTUNE_ERR_Success)
	        {
                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetStackedRoiOffsetY Failed", err);
	        }

            err = NeptuneC.ntcGetStackedRoiWidth(m_refMainForm.m_pCameraHandle, ref uiWidth);
            if (err != ENeptuneError.NEPTUNE_ERR_Success)
	        {
                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetStackedRoiWidth Failed", err);
	        }

            err = NeptuneC.ntcGetStackedRoiHeight(m_refMainForm.m_pCameraHandle, ref uiHeight);
            if (err != ENeptuneError.NEPTUNE_ERR_Success)
	        {
                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetStackedRoiHeight Failed", err);
	        }

            m_ckEnable.Checked = bEnable == ENeptuneBoolean.NEPTUNE_BOOL_TRUE;
            m_tbOffsetX.Text = uiOffsetX.ToString();
            m_tbOffsetY.Text = uiOffsetY.ToString();
            m_tbWidth.Text = uiWidth.ToString();
            m_tbHeight.Text = uiHeight.ToString();

            if (bEnable == ENeptuneBoolean.NEPTUNE_BOOL_TRUE)
	        {
		        GetStackedROIOffsetX();
		        GetStackedROIWidth();
	        }
        }

        public void UpdateForm()
        {
            GetStackedROIControl();
            GetSelectedStackedROI();
            GetStackedROIOffsetX();
            GetStackedROIWidth();
            GetSelectedStackedROIInfo();
        }

        private void PopupStackedROIForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            InitControls();
            UpdateForm();
        }

        private void PopupStackedROIForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_refMainForm.m_formPopupStackedROI = null;
        }

        private void m_ckControl_CheckedChanged(object sender, EventArgs e)
        {
            using (CNeptuneContinuePlay continuePlay = new CNeptuneContinuePlay(m_refMainForm.m_pCameraHandle))
            {
                ENeptuneBoolean bControl = m_ckControl.Checked ? ENeptuneBoolean.NEPTUNE_BOOL_TRUE : ENeptuneBoolean.NEPTUNE_BOOL_FALSE;
                ENeptuneError err = NeptuneC.ntcSetStackedRoiControl(m_refMainForm.m_pCameraHandle, bControl);
                if (err != ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetStackedRoiControl Failed", err);
                    GetStackedROIControl();
                }
            }
        }

        private void m_btnSetAllOffsetX_Click(object sender, EventArgs e)
        {
            using (CNeptuneContinuePlay continuePlay = new CNeptuneContinuePlay(m_refMainForm.m_pCameraHandle))
            {
                UInt32 iOffsetX = Convert.ToUInt32(m_tbAllOffsetX.Text);
                ENeptuneError err = NeptuneC.ntcSetStackedRoiOffsetXAll(m_refMainForm.m_pCameraHandle, iOffsetX);
                if (err == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    GetSelectedStackedROIInfo();
                }
                else
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetStackedRoiOffsetXAll Failed", err);
                }

                GetStackedROIOffsetX();
            }
        }

        private void m_btnSetAllWidth_Click(object sender, EventArgs e)
        {
            using (CNeptuneContinuePlay continuePlay = new CNeptuneContinuePlay(m_refMainForm.m_pCameraHandle))
            {
                UInt32 iWidth = Convert.ToUInt32(m_tbAllWidth.Text);
                ENeptuneError err = NeptuneC.ntcSetStackedRoiWidthAll(m_refMainForm.m_pCameraHandle, iWidth);
                if (err == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    GetSelectedStackedROIInfo();
                }
                else
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetStackedRoiWidthAll Failed", err);
                }

                GetStackedROIWidth();
            }
        }

        private void m_cbROISelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 iSel = m_cbROISelector.SelectedIndex;
            if (iSel >= 0)
            {
                ENeptuneError err = NeptuneC.ntcSetStackedRoiSelector(m_refMainForm.m_pCameraHandle, (UInt32)iSel);
                if (err == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    GetSelectedStackedROIInfo();
                }
                else
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetStackedRoiSelector Failed", err);
                    GetSelectedStackedROI();
                }
            }
        }

        private void m_btnApply_Click(object sender, EventArgs e)
        {
            using (CNeptuneContinuePlay continuePlay = new CNeptuneContinuePlay(m_refMainForm.m_pCameraHandle))
            {
                UInt32 uiOffsetX = Convert.ToUInt32(m_tbOffsetX.Text);
                UInt32 uiOffsetY = Convert.ToUInt32(m_tbOffsetY.Text);                
                UInt32 uiWidth = Convert.ToUInt32(m_tbWidth.Text);
                UInt32 uiHeight = Convert.ToUInt32(m_tbHeight.Text);

                ENeptuneBoolean bEnable = m_ckEnable.Checked ? ENeptuneBoolean.NEPTUNE_BOOL_TRUE : ENeptuneBoolean.NEPTUNE_BOOL_FALSE;

                ENeptuneError err = ENeptuneError.NEPTUNE_ERR_Success;

                err = NeptuneC.ntcSetStackedRoiOffsetX(m_refMainForm.m_pCameraHandle, uiOffsetX);
                if (err != ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetStackedRoiOffsetX Failed", err);
                }

                err = NeptuneC.ntcSetStackedRoiOffsetY(m_refMainForm.m_pCameraHandle, uiOffsetY);
                if (err != ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetStackedRoiOffsetY Failed", err);
                }

                err = NeptuneC.ntcSetStackedRoiWidth(m_refMainForm.m_pCameraHandle, uiWidth);
                if (err != ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetStackedRoiWidth Failed", err);
                }

                err = NeptuneC.ntcSetStackedRoiHeight(m_refMainForm.m_pCameraHandle, uiHeight);
                if (err != ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetStackedRoiHeight Failed", err);
                }

                err = NeptuneC.ntcSetStackedRoiSelectedEnable(m_refMainForm.m_pCameraHandle, bEnable);
                if (err != ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetStackedRoiSelectedEnable Failed", err);
                }

                GetSelectedStackedROIInfo();
                GetStackedROIOffsetX();
                GetStackedROIWidth();
            }
        }

    }
}
