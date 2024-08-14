using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using NeptuneC_Interface;

namespace NeptuneCSample_CSharp
{
    public partial class PopupFeatureForm : Form
    {
        private NeptuneCSampleForm m_refMainForm = null;
        private ENeptuneFeature[] m_arrMapping = new ENeptuneFeature[]
        {
            ENeptuneFeature.NEPTUNE_FEATURE_GAMMA,
            ENeptuneFeature.NEPTUNE_FEATURE_GAIN,
            ENeptuneFeature.NEPTUNE_FEATURE_RGAIN,
            ENeptuneFeature.NEPTUNE_FEATURE_GGAIN,
            ENeptuneFeature.NEPTUNE_FEATURE_BGAIN,
            ENeptuneFeature.NEPTUNE_FEATURE_AUTOGAIN_MIN,
            ENeptuneFeature.NEPTUNE_FEATURE_AUTOGAIN_MAX,
            ENeptuneFeature.NEPTUNE_FEATURE_SHUTTER,
            ENeptuneFeature.NEPTUNE_FEATURE_AUTOSHUTTER_MIN,
            ENeptuneFeature.NEPTUNE_FEATURE_AUTOSHUTTER_MAX,
            ENeptuneFeature.NEPTUNE_FEATURE_AUTOEXPOSURE,
            ENeptuneFeature.NEPTUNE_FEATURE_BLACKLEVEL,
            ENeptuneFeature.NEPTUNE_FEATURE_CONTRAST,
            ENeptuneFeature.NEPTUNE_FEATURE_HUE,
            ENeptuneFeature.NEPTUNE_FEATURE_SATURATION,
            ENeptuneFeature.NEPTUNE_FEATURE_SHARPNESS,
            ENeptuneFeature.NEPTUNE_FEATURE_TRIGNOISEFILTER,
            ENeptuneFeature.NEPTUNE_FEATURE_BRIGHTLEVELIRIS,
            ENeptuneFeature.NEPTUNE_FEATURE_SNOWNOISEREMOVE,
            ENeptuneFeature.NEPTUNE_FEATURE_OPTFILTER,
            ENeptuneFeature.NEPTUNE_FEATURE_PAN,
            ENeptuneFeature.NEPTUNE_FEATURE_TILT,
            ENeptuneFeature.NEPTUNE_FEATURE_LCD_BLUE_GAIN,
            ENeptuneFeature.NEPTUNE_FEATURE_LCD_RED_GAIN,
            ENeptuneFeature.NEPTUNE_FEATURE_WHITEBALANCE
        };
        private NEPTUNE_FEATURE[] m_arrFeatureInfo;
        private CheckBox[] m_arrCheckBox;
        private TrackBar[] m_arrTriackBar;
        private NumericUpDown[] m_arrNumUpDown;
        private Label[] m_arrLabelRange;

        public PopupFeatureForm(NeptuneCSampleForm refMainForm)
        {
            InitializeComponent();

            m_refMainForm = refMainForm;
        }

        private void InitControls()
        {
            m_arrFeatureInfo = new NEPTUNE_FEATURE[m_arrMapping.Length];
            m_arrCheckBox = new CheckBox[m_arrMapping.Length - 1];
            m_arrTriackBar = new TrackBar[m_arrMapping.Length - 1];
            m_arrNumUpDown = new NumericUpDown[m_arrMapping.Length - 1];
            m_arrLabelRange = new Label[m_arrMapping.Length - 1];
            for (int i = 0; i < (m_arrMapping.Length - 1); i++)
            {
                m_arrCheckBox[i] = Controls.Find("checkBox" + i.ToString(), true)[0] as CheckBox;
                m_arrTriackBar[i] = Controls.Find("trackBar" + i.ToString(), false)[0] as TrackBar;
                m_arrNumUpDown[i] = Controls.Find("numericUpDown" + i.ToString(), true)[0] as NumericUpDown;
                m_arrLabelRange[i] = Controls.Find("labelRange" + i.ToString(), true)[0] as Label;
            }
        }

        public void UpdateForm()
        {
            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                for (int i = 0; i < m_arrMapping.Length; i++)
                {
                    if (m_arrMapping[i] == ENeptuneFeature.NEPTUNE_FEATURE_GAMMA)
                    {
                        NEPTUNE_XML_NODE_INFO stNodeInfo = new NEPTUNE_XML_NODE_INFO();
                        NeptuneC.ntcGetNodeInfo(m_refMainForm.m_pCameraHandle, "Gamma", ref stNodeInfo);
                        if (stNodeInfo.Type == ENeptuneNodeType.NEPTUNE_NODE_TYPE_INT)
                        {
                            NEPTUNE_XML_INT_VALUE_INFO stIntValue = new NEPTUNE_XML_INT_VALUE_INFO();
                            if (NeptuneC.ntcGetNodeInt(m_refMainForm.m_pCameraHandle, "Gamma", ref stIntValue) == ENeptuneError.NEPTUNE_ERR_Success)
                            {
                                m_arrTriackBar[i].SetRange((int)stIntValue.nMin, (int)stIntValue.nMax);
                                m_arrTriackBar[i].Value = (int)stIntValue.nValue;
                                m_arrTriackBar[i].Enabled = (stIntValue.AccessMode == ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_RW || stIntValue.AccessMode == ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_WO);
                                m_arrNumUpDown[i].Minimum = stIntValue.nMin;
                                m_arrNumUpDown[i].Maximum = stIntValue.nMax;
                                m_arrNumUpDown[i].Value = stIntValue.nValue;
                                m_arrNumUpDown[i].Enabled = (stIntValue.AccessMode == ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_RW || stIntValue.AccessMode == ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_WO);
                                m_arrLabelRange[i].Text = "(" + stIntValue.nMin.ToString() + " ~ " + stIntValue.nMax.ToString() + ")";
                            }
                            else
                            {
                                m_arrTriackBar[i].Enabled = false;
                                m_arrNumUpDown[i].Enabled = false;
                                m_arrLabelRange[i].Enabled = false;
                            }
                        }
                        else
                        {
                            NEPTUNE_XML_FLOAT_VALUE_INFO stFloatValue = new NEPTUNE_XML_FLOAT_VALUE_INFO();
                            if (NeptuneC.ntcGetNodeFloat(m_refMainForm.m_pCameraHandle, "Gamma", ref stFloatValue) == ENeptuneError.NEPTUNE_ERR_Success)
                            {
                                m_arrTriackBar[i].SetRange((int)(stFloatValue.dMin * 1000), (int)(stFloatValue.dMax * 1000));
                                m_arrTriackBar[i].Value = (int)(stFloatValue.dValue * 1000);
                                m_arrTriackBar[i].Enabled = (stFloatValue.AccessMode == ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_RW || stFloatValue.AccessMode == ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_WO);
                                m_arrNumUpDown[i].DecimalPlaces = 3;
                                m_arrNumUpDown[i].Increment = Convert.ToDecimal(stFloatValue.dInc);
                                m_arrNumUpDown[i].Minimum = Convert.ToDecimal(stFloatValue.dMin);
                                m_arrNumUpDown[i].Maximum = Convert.ToDecimal(stFloatValue.dMax);
                                m_arrNumUpDown[i].Value = Convert.ToDecimal(stFloatValue.dValue);
                                m_arrNumUpDown[i].Enabled = (stFloatValue.AccessMode == ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_RW || stFloatValue.AccessMode == ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_WO);
                                m_arrLabelRange[i].Text = "(" + stFloatValue.dMin.ToString() + " ~ " + stFloatValue.dMax.ToString() + ")";
                            }
                            else
                            {
                                m_arrTriackBar[i].Enabled = false;
                                m_arrNumUpDown[i].Enabled = false;
                                m_arrLabelRange[i].Enabled = false;
                            }
                        }
                        m_arrCheckBox[i].Visible = false;
                    }
                    else
                    {
                        if (m_arrMapping[i] == ENeptuneFeature.NEPTUNE_FEATURE_WHITEBALANCE)
                        {
                            m_cbWhiteBal.Enabled = true;
                        }
                        else
                        {
                            m_arrCheckBox[i].Visible = true;
                            m_arrTriackBar[i].Enabled = true;
                            m_arrNumUpDown[i].Enabled = true;
                            m_arrLabelRange[i].Enabled = true;
                        }

                        if (NeptuneC.ntcGetFeature(m_refMainForm.m_pCameraHandle, m_arrMapping[i], ref m_arrFeatureInfo[i]) == ENeptuneError.NEPTUNE_ERR_Success)
                        {
                            if (m_arrMapping[i] == ENeptuneFeature.NEPTUNE_FEATURE_WHITEBALANCE)
                            {
                                m_cbWhiteBal.Items.Clear();
                                if ((m_arrFeatureInfo[i].SupportAutoModes & 0x1) == 0x1)
                                {
                                    m_cbWhiteBal.Items.Add("Off");
                                }
                                if ((m_arrFeatureInfo[i].SupportAutoModes & 0x2) == 0x2)
                                {
                                    m_cbWhiteBal.Items.Add("Once");
                                }
                                if ((m_arrFeatureInfo[i].SupportAutoModes & 0x4) == 0x4)
                                {
                                    m_cbWhiteBal.Items.Add("Continuous");
                                }
                                m_cbWhiteBal.SelectedIndex = (int)m_arrFeatureInfo[i].AutoMode;
                            }
                            else
                            {
                                if (m_arrFeatureInfo[i].SupportAutoModes != 0 &&
                                    m_arrMapping[i] != ENeptuneFeature.NEPTUNE_FEATURE_RGAIN &&
                                    m_arrMapping[i] != ENeptuneFeature.NEPTUNE_FEATURE_GGAIN &&
                                    m_arrMapping[i] != ENeptuneFeature.NEPTUNE_FEATURE_BGAIN)
                                {
                                    m_arrCheckBox[i].Checked = (m_arrFeatureInfo[i].AutoMode == ENeptuneAutoMode.NEPTUNE_AUTO_CONTINUOUS ? true : false);
                                }
                                else
                                {
                                    if (m_arrMapping[i] == ENeptuneFeature.NEPTUNE_FEATURE_SNOWNOISEREMOVE)
                                    {
                                        m_arrCheckBox[i].Text = "On";
                                        m_arrCheckBox[i].Checked = (m_arrFeatureInfo[i].bOnOff == ENeptuneBoolean.NEPTUNE_BOOL_TRUE ? true : false);
                                    }
                                    else
                                    {
                                        m_arrCheckBox[i].Visible = false;
                                    }
                                }

                                if (m_arrFeatureInfo[i].Value != -1)
                                {
                                    m_arrTriackBar[i].SetRange(m_arrFeatureInfo[i].Min, m_arrFeatureInfo[i].Max);
                                    m_arrTriackBar[i].Value = m_arrFeatureInfo[i].Value;
                                    m_arrTriackBar[i].Enabled = (m_arrFeatureInfo[i].ValueAccessMode == ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_RW || m_arrFeatureInfo[i].ValueAccessMode == ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_WO);
                                    m_arrNumUpDown[i].Minimum = m_arrFeatureInfo[i].Min;
                                    m_arrNumUpDown[i].Maximum = m_arrFeatureInfo[i].Max;
                                    m_arrNumUpDown[i].Value = m_arrFeatureInfo[i].Value;
                                    m_arrNumUpDown[i].Enabled = (m_arrFeatureInfo[i].ValueAccessMode == ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_RW || m_arrFeatureInfo[i].ValueAccessMode == ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_WO);
                                    m_arrLabelRange[i].Text = "(" + m_arrFeatureInfo[i].Min + " ~ " + m_arrFeatureInfo[i].Max + ")";

                                    if (m_arrMapping[i] == ENeptuneFeature.NEPTUNE_FEATURE_SNOWNOISEREMOVE)
                                    {
                                        m_arrTriackBar[i].Enabled = (m_arrTriackBar[i].Enabled && m_arrCheckBox[i].Checked);
                                        m_arrNumUpDown[i].Enabled = (m_arrNumUpDown[i].Enabled && m_arrCheckBox[i].Checked);
                                    }
                                }
                                else
                                {
                                    m_arrTriackBar[i].Enabled = false;
                                    m_arrNumUpDown[i].Enabled = false;
                                    m_arrLabelRange[i].Enabled = false;
                                }
                            }
                        }
                        else
                        {
                            if (m_arrMapping[i] == ENeptuneFeature.NEPTUNE_FEATURE_WHITEBALANCE)
                            {
                                m_cbWhiteBal.Enabled = false;
                            }
                            else
                            {
                                m_arrCheckBox[i].Visible = false;
                                m_arrTriackBar[i].Enabled = false;
                                m_arrNumUpDown[i].Enabled = false;
                                m_arrLabelRange[i].Enabled = false;
                            }
                        }
                    }
                }

                // Auto Mode 상태에 따른 UI Update
                checkBox0_Click(checkBox1, null);   // Gain
                checkBox0_Click(checkBox7, null);   // Shutter

                for (int j = 0; j < (m_arrMapping.Length - 1); j++)
                {
                    if (m_arrMapping[j] == ENeptuneFeature.NEPTUNE_FEATURE_RGAIN ||
                        m_arrMapping[j] == ENeptuneFeature.NEPTUNE_FEATURE_GGAIN ||
                        m_arrMapping[j] == ENeptuneFeature.NEPTUNE_FEATURE_BGAIN)
                    {
                        NEPTUNE_FEATURE stInfoEx = new NEPTUNE_FEATURE();
                        NeptuneC.ntcGetFeature(m_refMainForm.m_pCameraHandle, m_arrMapping[j], ref stInfoEx);
                        bool bIsAccess = (stInfoEx.ValueAccessMode == ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_RW || stInfoEx.ValueAccessMode == ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_WO);
                        m_arrTriackBar[j].Enabled = bIsAccess;
                        m_arrNumUpDown[j].Enabled = bIsAccess;
                    }
                }
            }
        }

        private void PopupFeatureForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            InitControls();
            UpdateForm();
        }

        private void PopupFeatureForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_refMainForm.m_formPopupFeature = null;
        }

        private void checkBox0_Click(object sender, EventArgs e)
        {
            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                for (int i = 0; i < (m_arrMapping.Length - 1); i++)
                {
                    if (m_arrCheckBox[i] == sender)
                    {
                        if (m_arrMapping[i] == ENeptuneFeature.NEPTUNE_FEATURE_SNOWNOISEREMOVE)
                        {
                            NEPTUNE_FEATURE stInfo = new NEPTUNE_FEATURE();
                            stInfo = m_arrFeatureInfo[i];
                            stInfo.bOnOff = (m_arrCheckBox[i].Checked ? ENeptuneBoolean.NEPTUNE_BOOL_TRUE : ENeptuneBoolean.NEPTUNE_BOOL_FALSE);
                            ENeptuneError emErr = NeptuneC.ntcSetFeature(m_refMainForm.m_pCameraHandle, m_arrMapping[i], stInfo);
                            if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                            {
                                m_arrFeatureInfo[i] = stInfo;
                                m_arrTriackBar[i].Enabled = (m_arrFeatureInfo[i].bOnOff == ENeptuneBoolean.NEPTUNE_BOOL_TRUE);
                                m_arrNumUpDown[i].Enabled = (m_arrFeatureInfo[i].bOnOff == ENeptuneBoolean.NEPTUNE_BOOL_TRUE);
                            }
                            else
                            {
                                m_arrCheckBox[i].Checked = (m_arrFeatureInfo[i].AutoMode == ENeptuneAutoMode.NEPTUNE_AUTO_CONTINUOUS ? true : false);
                                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetFeature Failed.", emErr);
                            }
                        }
                        else
                        {
                            NEPTUNE_FEATURE stInfo = new NEPTUNE_FEATURE();
                            stInfo = m_arrFeatureInfo[i];
                            if (m_arrCheckBox[i].Checked)
                            {
                                stInfo.AutoMode = ENeptuneAutoMode.NEPTUNE_AUTO_CONTINUOUS;
                            }
                            else
                            {
                                NeptuneC.ntcGetFeature(m_refMainForm.m_pCameraHandle, m_arrMapping[i], ref stInfo);
                                stInfo.AutoMode = ENeptuneAutoMode.NEPTUNE_AUTO_OFF;

                                bool bIsAvailable = true;
                                if (stInfo.ValueAccessMode == ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_NI || stInfo.ValueAccessMode == ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_UNDEFINED)
                                {
                                    bIsAvailable = false;
                                }

                                if (bIsAvailable)
                                {
                                    m_arrTriackBar[i].Value = stInfo.Value;
                                    m_arrNumUpDown[i].Value = stInfo.Value;
                                }
                            }
                            
                            ENeptuneError emErr = NeptuneC.ntcSetFeature(m_refMainForm.m_pCameraHandle, m_arrMapping[i], stInfo);
                            if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                            {
                                m_arrFeatureInfo[i] = stInfo;

                                bool bEnable = (m_arrFeatureInfo[i].AutoMode == ENeptuneAutoMode.NEPTUNE_AUTO_OFF);
                                m_arrTriackBar[i].Enabled = bEnable;
                                m_arrNumUpDown[i].Enabled = bEnable;
                            }
                            else
                            {
                                m_arrCheckBox[i].Checked = (m_arrFeatureInfo[i].AutoMode == ENeptuneAutoMode.NEPTUNE_AUTO_CONTINUOUS ? true : false);
                                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetFeature Failed.", emErr);
                            }
                        }
                        break;
                    }
                }
            }
        }

        private void trackBar0_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                for (int i = 0; i < (m_arrMapping.Length - 1); i++)
                {
                    if (m_arrTriackBar[i] == sender)
                    {
                        if (m_arrMapping[i] == ENeptuneFeature.NEPTUNE_FEATURE_GAMMA)
                        {
                            NEPTUNE_XML_NODE_INFO stNodeInfo = new NEPTUNE_XML_NODE_INFO();
                            NeptuneC.ntcGetNodeInfo(m_refMainForm.m_pCameraHandle, "Gamma", ref stNodeInfo);
                            if (stNodeInfo.Type == ENeptuneNodeType.NEPTUNE_NODE_TYPE_INT)
                            {
                                NeptuneC.ntcSetNodeInt(m_refMainForm.m_pCameraHandle, "Gamma", m_arrTriackBar[i].Value);
                                m_arrNumUpDown[i].Value = m_arrTriackBar[i].Value;
                            }
                            else
                            {
                                double dbGamma = (double)m_arrTriackBar[i].Value / 1000.0;
                                NeptuneC.ntcSetNodeFloat(m_refMainForm.m_pCameraHandle, "Gamma", dbGamma);
                                m_arrNumUpDown[i].Value = Convert.ToDecimal(dbGamma);
                            }
                        }
                        else
                        {
                            NEPTUNE_FEATURE stInfo = new NEPTUNE_FEATURE();
                            stInfo = m_arrFeatureInfo[i];
                            stInfo.Value = m_arrTriackBar[i].Value;
                            ENeptuneError emErr = NeptuneC.ntcSetFeature(m_refMainForm.m_pCameraHandle, m_arrMapping[i], stInfo);
                            if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                            {
                                m_arrFeatureInfo[i] = stInfo;
                                m_arrNumUpDown[i].Value = m_arrFeatureInfo[i].Value;
                            }
                            else
                            {
                                m_arrTriackBar[i].Value = m_arrFeatureInfo[i].Value;
                                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetFeature Failed.", emErr);
                            }
                        }
                        break;
                    }
                }
            }
        }

        private void numericUpDown0_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (Int32)Keys.Enter)
            {
                if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
                {
                    for (int i = 0; i < (m_arrMapping.Length - 1); i++)
                    {
                        if (m_arrNumUpDown[i] == sender)
                        {
                            if (m_arrMapping[i] == ENeptuneFeature.NEPTUNE_FEATURE_GAMMA)
                            {
                                NEPTUNE_XML_NODE_INFO stNodeInfo = new NEPTUNE_XML_NODE_INFO();
                                NeptuneC.ntcGetNodeInfo(m_refMainForm.m_pCameraHandle, "Gamma", ref stNodeInfo);
                                if (stNodeInfo.Type == ENeptuneNodeType.NEPTUNE_NODE_TYPE_INT)
                                {
                                    NeptuneC.ntcSetNodeInt(m_refMainForm.m_pCameraHandle, "Gamma", (int)m_arrNumUpDown[i].Value);
                                    m_arrTriackBar[i].Value = (int)m_arrNumUpDown[i].Value;
                                }
                                else
                                {
                                    NeptuneC.ntcSetNodeFloat(m_refMainForm.m_pCameraHandle, "Gamma", (double)m_arrNumUpDown[i].Value);
                                    m_arrTriackBar[i].Value = (int)(m_arrNumUpDown[i].Value * 1000);
                                }
                            }
                            else
                            {
                                NEPTUNE_FEATURE stInfo = new NEPTUNE_FEATURE();
                                stInfo = m_arrFeatureInfo[i];
                                stInfo.Value = (int)m_arrNumUpDown[i].Value;
                                ENeptuneError emErr = NeptuneC.ntcSetFeature(m_refMainForm.m_pCameraHandle, m_arrMapping[i], stInfo);
                                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                                {
                                    m_arrFeatureInfo[i] = stInfo;
                                    m_arrTriackBar[i].Value = m_arrFeatureInfo[i].Value;
                                }
                                else
                                {
                                    m_arrNumUpDown[i].Value = m_arrFeatureInfo[i].Value;
                                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetFeature Failed.", emErr);
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }

        private void numericUpDown0_Click(object sender, EventArgs e)
        {
            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                for (int i = 0; i < (m_arrMapping.Length - 1); i++)
                {
                    if (m_arrNumUpDown[i] == sender)
                    {
                        if (m_arrMapping[i] == ENeptuneFeature.NEPTUNE_FEATURE_GAMMA)
                        {
                            NEPTUNE_XML_NODE_INFO stNodeInfo = new NEPTUNE_XML_NODE_INFO();
                            NeptuneC.ntcGetNodeInfo(m_refMainForm.m_pCameraHandle, "Gamma", ref stNodeInfo);
                            if (stNodeInfo.Type == ENeptuneNodeType.NEPTUNE_NODE_TYPE_INT)
                            {
                                NeptuneC.ntcSetNodeInt(m_refMainForm.m_pCameraHandle, "Gamma", (int)m_arrNumUpDown[i].Value);
                                m_arrTriackBar[i].Value = (int)m_arrNumUpDown[i].Value;
                            }
                            else
                            {
                                NeptuneC.ntcSetNodeFloat(m_refMainForm.m_pCameraHandle, "Gamma", (double)m_arrNumUpDown[i].Value);
                                m_arrTriackBar[i].Value = (int)(m_arrNumUpDown[i].Value * 1000);
                            }
                        }
                        else
                        {
                            NEPTUNE_FEATURE stInfo = new NEPTUNE_FEATURE();
                            stInfo = m_arrFeatureInfo[i];
                            stInfo.Value = (int)m_arrNumUpDown[i].Value;
                            ENeptuneError emErr = NeptuneC.ntcSetFeature(m_refMainForm.m_pCameraHandle, m_arrMapping[i], stInfo);
                            if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                            {
                                m_arrFeatureInfo[i] = stInfo;
                                m_arrTriackBar[i].Value = m_arrFeatureInfo[i].Value;
                            }
                            else
                            {
                                m_arrNumUpDown[i].Value = m_arrFeatureInfo[i].Value;
                                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetFeature Failed.", emErr);
                            }
                        }
                        break;
                    }
                }
            }
        }

        private void m_cbWhiteBal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                NEPTUNE_FEATURE stInfo = new NEPTUNE_FEATURE();
                stInfo = m_arrFeatureInfo[m_arrMapping.Length - 1];
                stInfo.AutoMode = (ENeptuneAutoMode)m_cbWhiteBal.SelectedIndex;
                if (stInfo.AutoMode != m_arrFeatureInfo[m_arrMapping.Length - 1].AutoMode)
                {
                    ENeptuneError emErr = NeptuneC.ntcSetFeature(m_refMainForm.m_pCameraHandle, m_arrMapping[m_arrMapping.Length - 1], stInfo);
                    if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                    {
                        if (stInfo.AutoMode == ENeptuneAutoMode.NEPTUNE_AUTO_ONCE)
                        {
                            stInfo.AutoMode = ENeptuneAutoMode.NEPTUNE_AUTO_OFF;
                            m_cbWhiteBal.SelectedIndex = (int)stInfo.AutoMode;
                        }
                        m_arrFeatureInfo[m_arrMapping.Length - 1] = stInfo;

                        for (int j = 0; j < (m_arrMapping.Length - 1); j++)
                        {
                            if (m_arrMapping[j] == ENeptuneFeature.NEPTUNE_FEATURE_RGAIN ||
                                m_arrMapping[j] == ENeptuneFeature.NEPTUNE_FEATURE_GGAIN ||
                                m_arrMapping[j] == ENeptuneFeature.NEPTUNE_FEATURE_BGAIN)
                            {
                                NEPTUNE_FEATURE stInfoEx = new NEPTUNE_FEATURE();
                                NeptuneC.ntcGetFeature(m_refMainForm.m_pCameraHandle, m_arrMapping[j], ref stInfoEx);
                                bool bIsAccess = (stInfoEx.ValueAccessMode == ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_RW || stInfoEx.ValueAccessMode == ENeptuneNodeAccessMode.NEPTUNE_NODE_ACCESSMODE_WO);
                                m_arrTriackBar[j].Enabled = bIsAccess;
                                m_arrNumUpDown[j].Enabled = bIsAccess;
                            }
                        }
                    }
                    else
                    {
                        m_cbWhiteBal.SelectedIndex = (int)m_arrFeatureInfo[m_arrMapping.Length - 1].AutoMode;
                        m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetFeature Failed.", emErr);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                NEPTUNE_USERSET stUserSet = new NEPTUNE_USERSET();
                stUserSet.Command = ENeptuneUserSetCommand.NEPTUNE_USERSET_CMD_LOAD;
                stUserSet.UserSetIndex = ENeptuneUserSet.NEPTUNE_USERSET_DEFAULT;
                ENeptuneError emErr = NeptuneC.ntcSetUserSet(m_refMainForm.m_pCameraHandle, stUserSet);
                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    UpdateForm();
                }
                else
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetUserSet Failed.", emErr);
                }
            }
        }
    }
}
