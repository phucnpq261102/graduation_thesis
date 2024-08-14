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
    public partial class PopupStrobeForm : Form
    {
        private NeptuneCSampleForm m_refMainForm = null;

        public PopupStrobeForm(NeptuneCSampleForm refMainForm)
        {
            InitializeComponent();

            m_refMainForm = refMainForm;
        }

        private void InitControls()
        {
        }

        public void UpdateForm()
        {
            m_ckStrobeEnable.Checked = false;
            m_cbStrobeMode.Items.Clear();
            m_cbStrobePolarity.Items.Clear();
            m_edStrobeDelay.Minimum = 0;
            m_edStrobeDelay.Maximum = 0;
            m_edStrobeDelay.Value = 0;
            m_edStrobeDuration.Minimum = 0;
            m_edStrobeDuration.Maximum = 0;
            m_edStrobeDuration.Value = 0;
            m_stcDelayRange.Text = "(Min ~ Max)";
            m_stcDurationRange.Text = "(Min ~ Max)";

            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                NEPTUNE_STROBE_INFO stStrobeInfo = new NEPTUNE_STROBE_INFO();
                ENeptuneError emErr = NeptuneC.ntcGetStrobeInfo(m_refMainForm.m_pCameraHandle, ref stStrobeInfo);
                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    if (stStrobeInfo.bSupport == ENeptuneBoolean.NEPTUNE_BOOL_TRUE)
                    {
                        int nFlag = (int)stStrobeInfo.nStrobeFlag;
                        for (int i = 0; i < 31; i++)
                        {
                            if ((nFlag & 0x01) == 0x01)
                            {
                                m_cbStrobeMode.Items.Add(new ItemData("Timer" + i, i));
                            }
                            nFlag = (nFlag >> 1);
                        }

                        nFlag = (int)(stStrobeInfo.nPolarityFlag >> (int)ENeptunePolarity.NEPTUNE_POLARITY_RISINGEDGE);
                        if ((nFlag & 0x01) == 0x01)
                        {
                            m_cbStrobePolarity.Items.Add(new ItemData("Rising Edge", (int)ENeptunePolarity.NEPTUNE_POLARITY_RISINGEDGE));
                        }
                        nFlag = (int)(stStrobeInfo.nPolarityFlag >> (int)ENeptunePolarity.NEPTUNE_POLARITY_FALLINGEDGE);
                        if ((nFlag & 0x01) == 0x01)
                        {
                            m_cbStrobePolarity.Items.Add(new ItemData("Falling Edge", (int)ENeptunePolarity.NEPTUNE_POLARITY_FALLINGEDGE));
                        }
                        nFlag = (int)(stStrobeInfo.nPolarityFlag >> (int)ENeptunePolarity.NEPTUNE_POLARITY_ANYEDGE);
                        if ((nFlag & 0x01) == 0x01)
                        {
                            m_cbStrobePolarity.Items.Add(new ItemData("Any Edge", (int)ENeptunePolarity.NEPTUNE_POLARITY_ANYEDGE));
                        }
                        nFlag = (int)(stStrobeInfo.nPolarityFlag >> (int)ENeptunePolarity.NEPTUNE_POLARITY_LEVELHIGH);
                        if ((nFlag & 0x01) == 0x01)
                        {
                            m_cbStrobePolarity.Items.Add(new ItemData("High Level", (int)ENeptunePolarity.NEPTUNE_POLARITY_LEVELHIGH));
                        }
                        nFlag = (int)(stStrobeInfo.nPolarityFlag >> (int)ENeptunePolarity.NEPTUNE_POLARITY_LEVELLOW);
                        if ((nFlag & 0x01) == 0x01)
                        {
                            m_cbStrobePolarity.Items.Add(new ItemData("Low Level", (int)ENeptunePolarity.NEPTUNE_POLARITY_LEVELLOW));
                        }

                        if (stStrobeInfo.nDelayMin != 0xffff && stStrobeInfo.nDelayMax != 0xffff)
                        {
                            m_edStrobeDelay.Minimum = stStrobeInfo.nDelayMin;
                            m_edStrobeDelay.Maximum = stStrobeInfo.nDelayMax;
                            m_stcDelayRange.Text = "(" + m_edStrobeDelay.Minimum + " ~ " + m_edStrobeDelay.Maximum + ")";
                        }

                        if (stStrobeInfo.nDurationMin != 0xffff && stStrobeInfo.nDurationMax != 0xffff)
                        {
                            m_edStrobeDuration.Minimum = stStrobeInfo.nDurationMin;
                            m_edStrobeDuration.Maximum = stStrobeInfo.nDurationMax;
                            m_stcDurationRange.Text = "(" + m_edStrobeDuration.Minimum + " ~ " + m_edStrobeDuration.Maximum + ")";
                        }

                        NEPTUNE_STROBE stStrobe = new NEPTUNE_STROBE();
                        emErr = NeptuneC.ntcGetStrobe(m_refMainForm.m_pCameraHandle, ref stStrobe);
                        if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                        {
                            m_ckStrobeEnable.Checked = (stStrobe.OnOff == ENeptuneBoolean.NEPTUNE_BOOL_TRUE ? true : false);

                            for (int i = 0; i < m_cbStrobeMode.Items.Count; i++)
                            {
                                if (((ItemData)m_cbStrobeMode.Items[i]).m_nValue == (int)stStrobe.Strobe)
                                {
                                    m_cbStrobeMode.SelectedIndex = i;
                                    break;
                                }
                            }

                            for (int i = 0; i < m_cbStrobePolarity.Items.Count; i++)
                            {
                                if (((ItemData)m_cbStrobePolarity.Items[i]).m_nValue == (int)stStrobe.Polarity)
                                {
                                    m_cbStrobePolarity.SelectedIndex = i;
                                    break;
                                }
                            }

                            if (stStrobe.nDelay != 0xffff)
                            {
                                m_edStrobeDelay.Value = stStrobe.nDelay;
                            }
                            else
                            {
                                m_edStrobeDelay.Enabled = false;
                            }

                            if (stStrobe.nDuration != 0xffff)
                            {
                                m_edStrobeDuration.Value = stStrobe.nDuration;
                            }
                            else
                            {
                                m_edStrobeDuration.Enabled = false;
                            }
                        }
                        else
                        {
                            m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetStrobe Failed.", emErr);
                        }
                    }
                }
                else
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetStrobeInfo Failed.", emErr);
                }
            }
        }

        private void PopupStrobeForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            InitControls();
            UpdateForm();
        }

        private void PopupStrobeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_refMainForm.m_formPopupStrobe = null;
        }

        private void m_btnApply_Click(object sender, EventArgs e)
        {
            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                NEPTUNE_STROBE stStrobe = new NEPTUNE_STROBE();
                stStrobe.OnOff = m_ckStrobeEnable.Checked ? ENeptuneBoolean.NEPTUNE_BOOL_TRUE : ENeptuneBoolean.NEPTUNE_BOOL_FALSE;
                stStrobe.Strobe = (ENeptuneStrobe)((ItemData)m_cbStrobeMode.SelectedItem).m_nValue;
                stStrobe.Polarity = (ENeptunePolarity)((ItemData)m_cbStrobePolarity.SelectedItem).m_nValue;
                if (m_edStrobeDelay.Enabled)
                {
                    stStrobe.nDelay = (ushort)m_edStrobeDelay.Value;
                }
                if (m_edStrobeDuration.Enabled)
                {
                    stStrobe.nDuration = (ushort)m_edStrobeDuration.Value;
                }
                ENeptuneError emErr = NeptuneC.ntcSetStrobe(m_refMainForm.m_pCameraHandle, stStrobe);
                if (emErr != ENeptuneError.NEPTUNE_ERR_Success)
                {
                    UpdateForm();
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetStrobe Failed.", emErr);
                }

                emErr = NeptuneC.ntcGetStrobe(m_refMainForm.m_pCameraHandle, ref stStrobe);
                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_ckStrobeEnable.Checked = (stStrobe.OnOff == ENeptuneBoolean.NEPTUNE_BOOL_TRUE ? true : false);

                    for (int i = 0; i < m_cbStrobeMode.Items.Count; i++)
                    {
                        if (((ItemData)m_cbStrobeMode.Items[i]).m_nValue == (int)stStrobe.Strobe)
                        {
                            m_cbStrobeMode.SelectedIndex = i;
                            break;
                        }
                    }

                    for (int i = 0; i < m_cbStrobePolarity.Items.Count; i++)
                    {
                        if (((ItemData)m_cbStrobePolarity.Items[i]).m_nValue == (int)stStrobe.Polarity)
                        {
                            m_cbStrobePolarity.SelectedIndex = i;
                            break;
                        }
                    }

                    if (stStrobe.nDelay != 0xffff)
                    {
                        m_edStrobeDelay.Value = stStrobe.nDelay;
                    }
                    else
                    {
                        m_edStrobeDelay.Enabled = false;
                    }

                    if (stStrobe.nDuration != 0xffff)
                    {
                        m_edStrobeDuration.Value = stStrobe.nDuration;
                    }
                    else
                    {
                        m_edStrobeDuration.Enabled = false;
                    }
                }
                else
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetStrobe Failed.", emErr);
                }
            }
        }
    }
}
