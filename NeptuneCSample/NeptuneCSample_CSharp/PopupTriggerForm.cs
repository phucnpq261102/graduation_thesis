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
    public partial class PopupTriggerForm : Form
    {
        private NeptuneCSampleForm m_refMainForm = null;

        public PopupTriggerForm(NeptuneCSampleForm refMainForm)
        {
            InitializeComponent();

            m_refMainForm = refMainForm;
        }

        private void InitControls()
        {
        }

        public void UpdateForm()
        {
            m_ckTriggerEnable.Checked = false;
            m_cbTriggerMode.Items.Clear();
            m_cbTriggerSource.Items.Clear();
            m_cbTriggerPolarity.Items.Clear();
            m_edTriggerParam.Minimum = 0;
            m_edTriggerParam.Maximum = 0;
            m_edTriggerParam.Value = 0;
            m_btnSWTrigger.Enabled = false;
            m_stcParamRange.Text = "(Min ~ Max)";

            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                NEPTUNE_TRIGGER_INFO stTriggerInfo = new NEPTUNE_TRIGGER_INFO();
                ENeptuneError emErr = NeptuneC.ntcGetTriggerInfo(m_refMainForm.m_pCameraHandle, ref stTriggerInfo);
                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    if (stTriggerInfo.bSupport == ENeptuneBoolean.NEPTUNE_BOOL_TRUE)
                    {
                        int nFlag = (int)stTriggerInfo.nModeFlag;
                        for (int i = 0; i < 31; i++)
                        {
                            if ((nFlag & 0x01) == 0x01)
                            {
                                m_cbTriggerMode.Items.Add(new ItemData("Mode" + i, i));
                            }
                            nFlag = (nFlag >> 1);
                        }

                        nFlag = (int)(stTriggerInfo.nSourceFlag >> (int)ENeptuneTriggerSource.NEPTUNE_TRIGGER_SOURCE_LINE1);
                        if ((nFlag & 0x01) == 0x01)
                        {
                            m_cbTriggerSource.Items.Add(new ItemData("Line1", (int)ENeptuneTriggerSource.NEPTUNE_TRIGGER_SOURCE_LINE1));
                        }
                        nFlag = (int)(stTriggerInfo.nSourceFlag >> (int)ENeptuneTriggerSource.NEPTUNE_TRIGGER_SOURCE_SW);
                        if ((nFlag & 0x01) == 0x01)
                        {
                            m_cbTriggerSource.Items.Add(new ItemData("Software", (int)ENeptuneTriggerSource.NEPTUNE_TRIGGER_SOURCE_SW));
                        }
                        
                        nFlag = (int)(stTriggerInfo.nPolarityFlag >> (int)ENeptunePolarity.NEPTUNE_POLARITY_RISINGEDGE);
                        if ((nFlag & 0x01) == 0x01)
                        {
                            m_cbTriggerPolarity.Items.Add(new ItemData("Rising Edge", (int)ENeptunePolarity.NEPTUNE_POLARITY_RISINGEDGE));
                        }
                        nFlag = (int)(stTriggerInfo.nPolarityFlag >> (int)ENeptunePolarity.NEPTUNE_POLARITY_FALLINGEDGE);
                        if ((nFlag & 0x01) == 0x01)
                        {
                            m_cbTriggerPolarity.Items.Add(new ItemData("Falling Edge", (int)ENeptunePolarity.NEPTUNE_POLARITY_FALLINGEDGE));
                        }
                        nFlag = (int)(stTriggerInfo.nPolarityFlag >> (int)ENeptunePolarity.NEPTUNE_POLARITY_ANYEDGE);
                        if ((nFlag & 0x01) == 0x01)
                        {
                            m_cbTriggerPolarity.Items.Add(new ItemData("Any Edge", (int)ENeptunePolarity.NEPTUNE_POLARITY_ANYEDGE));
                        }
                        nFlag = (int)(stTriggerInfo.nPolarityFlag >> (int)ENeptunePolarity.NEPTUNE_POLARITY_LEVELHIGH);
                        if ((nFlag & 0x01) == 0x01)
                        {
                            m_cbTriggerPolarity.Items.Add(new ItemData("High Level", (int)ENeptunePolarity.NEPTUNE_POLARITY_LEVELHIGH));
                        }
                        nFlag = (int)(stTriggerInfo.nPolarityFlag >> (int)ENeptunePolarity.NEPTUNE_POLARITY_LEVELLOW);
                        if ((nFlag & 0x01) == 0x01)
                        {
                            m_cbTriggerPolarity.Items.Add(new ItemData("Low Level", (int)ENeptunePolarity.NEPTUNE_POLARITY_LEVELLOW));
                        }

                        m_edTriggerParam.Minimum = stTriggerInfo.nParamMin;
                        m_edTriggerParam.Maximum = stTriggerInfo.nParamMax;
                        m_stcParamRange.Text = "(" +  m_edTriggerParam.Minimum + " ~ " + m_edTriggerParam.Maximum + ")";

                        NEPTUNE_TRIGGER stTrigger = new NEPTUNE_TRIGGER();
                        emErr = NeptuneC.ntcGetTrigger(m_refMainForm.m_pCameraHandle, ref stTrigger);
                        if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                        {
                            m_ckTriggerEnable.Checked = (stTrigger.OnOff == ENeptuneBoolean.NEPTUNE_BOOL_TRUE ? true : false);
                            
                            for (int i = 0; i < m_cbTriggerMode.Items.Count; i++)
                            {
                                if (((ItemData)m_cbTriggerMode.Items[i]).m_nValue == (int)stTrigger.Mode)
                                {
                                    m_cbTriggerMode.SelectedIndex = i;
                                    break;
                                }
                            }

                            for (int i = 0; i < m_cbTriggerSource.Items.Count; i++)
                            {
                                if (((ItemData)m_cbTriggerSource.Items[i]).m_nValue == (int)stTrigger.Source)
                                {
                                    m_cbTriggerSource.SelectedIndex = i;
                                    break;
                                }
                            }

                            for (int i = 0; i < m_cbTriggerPolarity.Items.Count; i++)
                            {
                                if (((ItemData)m_cbTriggerPolarity.Items[i]).m_nValue == (int)stTrigger.Polarity)
                                {
                                    m_cbTriggerPolarity.SelectedIndex = i;
                                    break;
                                }
                            }

                            m_edTriggerParam.Value = stTrigger.nParam;

                            m_btnSWTrigger.Enabled = ((stTrigger.Source == ENeptuneTriggerSource.NEPTUNE_TRIGGER_SOURCE_SW) && (stTrigger.OnOff == ENeptuneBoolean.NEPTUNE_BOOL_TRUE));
                        }
                        else
                        {
                            m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetTrigger Failed.", emErr);
                        }
                    }
                }
                else
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetTriggerInfo Failed.", emErr);
                }
            }
        }

        private void PopupTriggerForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            InitControls();
            UpdateForm();
        }

        private void PopupTriggerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_refMainForm.m_formPopupTrigger = null;
        }

        private void m_btnApply_Click(object sender, EventArgs e)
        {
            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                NEPTUNE_TRIGGER stTrigger = new NEPTUNE_TRIGGER();
                stTrigger.OnOff = (m_ckTriggerEnable.Checked ? ENeptuneBoolean.NEPTUNE_BOOL_TRUE : ENeptuneBoolean.NEPTUNE_BOOL_FALSE);
                stTrigger.Mode = (ENeptuneTriggerMode)((ItemData)m_cbTriggerMode.SelectedItem).m_nValue;
                stTrigger.Source = (ENeptuneTriggerSource)((ItemData)m_cbTriggerSource.SelectedItem).m_nValue;
                stTrigger.Polarity = (ENeptunePolarity)((ItemData)m_cbTriggerPolarity.SelectedItem).m_nValue;
                stTrigger.nParam = (ushort)m_edTriggerParam.Value;
                ENeptuneError emErr = NeptuneC.ntcSetTrigger(m_refMainForm.m_pCameraHandle, stTrigger);
                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_btnSWTrigger.Enabled = ((stTrigger.Source == ENeptuneTriggerSource.NEPTUNE_TRIGGER_SOURCE_SW) && (stTrigger.OnOff == ENeptuneBoolean.NEPTUNE_BOOL_TRUE));
                }
                else
                {
                    UpdateForm();
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetTrigger Failed.", emErr);
                }
            }
        }

        private void m_btnSWTrigger_Click(object sender, EventArgs e)
        {
            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                NeptuneC.ntcRunSWTrigger(m_refMainForm.m_pCameraHandle);
            }
        }
    }
}
