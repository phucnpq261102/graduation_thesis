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
    public partial class PopupThermalForm : Form
    {
        private NeptuneCSampleForm m_refMainForm = null;

        private NEPTUNE_XML_ENUM_LIST m_stXmlPalette;

        private NEPTUNE_XML_ENUM_LIST m_stXmlNucMode;
        private NEPTUNE_XML_INT_VALUE_INFO m_stXmlNucAutoTime;
        private NEPTUNE_XML_INT_VALUE_INFO m_stXmlNucAutoTemperature;

        private NEPTUNE_XML_INT_VALUE_INFO m_stXmlAlarmDetectPixelCnt;
        private NEPTUNE_XML_FLOAT_VALUE_INFO m_stXmlAlarmDetectStartDelay;
        private NEPTUNE_XML_FLOAT_VALUE_INFO m_stXmlAlarmDetectStopDelay;
        private NEPTUNE_XML_ENUM_LIST m_stXmlAlarmDetectOutputEnable;
        private NEPTUNE_XML_ENUM_LIST m_stXmlAlarmDetectOutputPolarity;

        private NEPTUNE_XML_ENUM_LIST m_stXmlPrivacySelect;
        private NEPTUNE_XML_ENUM_LIST m_stXmlPrivacyEnable;
        private NEPTUNE_XML_INT_VALUE_INFO m_stXmlPrivacyLeft;
        private NEPTUNE_XML_INT_VALUE_INFO m_stXmlPrivacyTop;
        private NEPTUNE_XML_INT_VALUE_INFO m_stXmlPrivacyWidth;
        private NEPTUNE_XML_INT_VALUE_INFO m_stXmlPrivacyHeight;

        private NEPTUNE_XML_ENUM_LIST m_stXmlPointSelect;
        private NEPTUNE_XML_ENUM_LIST m_stXmlPointEnable;
        private NEPTUNE_XML_INT_VALUE_INFO m_stXmlPointLeft;
        private NEPTUNE_XML_INT_VALUE_INFO m_stXmlPointTop;

        private NEPTUNE_XML_ENUM_LIST m_stXmlAlarmSelect;
        private NEPTUNE_XML_ENUM_LIST m_stXmlAlarmEnable;
        private NEPTUNE_XML_INT_VALUE_INFO m_stXmlAlarmLeft;
        private NEPTUNE_XML_INT_VALUE_INFO m_stXmlAlarmTop;
        private NEPTUNE_XML_INT_VALUE_INFO m_stXmlAlarmWidth;
        private NEPTUNE_XML_INT_VALUE_INFO m_stXmlAlarmHeight;
        private NEPTUNE_XML_ENUM_LIST m_stXmlAlarmCondition;
        private NEPTUNE_XML_FLOAT_VALUE_INFO m_stXmlAlarmTemperature;
        private NEPTUNE_XML_ENUM_LIST m_stXmlAlarmTransparency;
        private NEPTUNE_XML_ENUM_LIST m_stXmlAlarmColor;

        public PopupThermalForm(NeptuneCSampleForm refMainForm)
        {
            InitializeComponent();

            m_refMainForm = refMainForm;

            m_stXmlPalette = NEPTUNE_XML_ENUM_LIST.Create();

            m_stXmlNucMode = NEPTUNE_XML_ENUM_LIST.Create();
            m_stXmlNucAutoTime = new NEPTUNE_XML_INT_VALUE_INFO();
            m_stXmlNucAutoTemperature = new NEPTUNE_XML_INT_VALUE_INFO();

            m_stXmlAlarmDetectPixelCnt = new NEPTUNE_XML_INT_VALUE_INFO();
            m_stXmlAlarmDetectStartDelay = new NEPTUNE_XML_FLOAT_VALUE_INFO();
            m_stXmlAlarmDetectStopDelay = new NEPTUNE_XML_FLOAT_VALUE_INFO();
            m_stXmlAlarmDetectOutputEnable = NEPTUNE_XML_ENUM_LIST.Create();
            m_stXmlAlarmDetectOutputPolarity = NEPTUNE_XML_ENUM_LIST.Create();

            m_stXmlPrivacySelect = NEPTUNE_XML_ENUM_LIST.Create();
            m_stXmlPrivacyEnable = NEPTUNE_XML_ENUM_LIST.Create();
            m_stXmlPrivacyLeft = new NEPTUNE_XML_INT_VALUE_INFO();
            m_stXmlPrivacyTop = new NEPTUNE_XML_INT_VALUE_INFO();
            m_stXmlPrivacyWidth = new NEPTUNE_XML_INT_VALUE_INFO();
            m_stXmlPrivacyHeight = new NEPTUNE_XML_INT_VALUE_INFO();

            m_stXmlPointSelect = NEPTUNE_XML_ENUM_LIST.Create();
            m_stXmlPointEnable = NEPTUNE_XML_ENUM_LIST.Create();
            m_stXmlPointLeft = new NEPTUNE_XML_INT_VALUE_INFO();
            m_stXmlPointTop = new NEPTUNE_XML_INT_VALUE_INFO();

            m_stXmlAlarmSelect = NEPTUNE_XML_ENUM_LIST.Create();
            m_stXmlAlarmEnable = NEPTUNE_XML_ENUM_LIST.Create();
            m_stXmlAlarmLeft = new NEPTUNE_XML_INT_VALUE_INFO();
            m_stXmlAlarmTop = new NEPTUNE_XML_INT_VALUE_INFO();
            m_stXmlAlarmWidth = new NEPTUNE_XML_INT_VALUE_INFO();
            m_stXmlAlarmHeight = new NEPTUNE_XML_INT_VALUE_INFO();
            m_stXmlAlarmCondition = NEPTUNE_XML_ENUM_LIST.Create();
            m_stXmlAlarmTemperature = new NEPTUNE_XML_FLOAT_VALUE_INFO();
            m_stXmlAlarmTransparency = NEPTUNE_XML_ENUM_LIST.Create();
            m_stXmlAlarmColor = NEPTUNE_XML_ENUM_LIST.Create();
        }

        public void UpdateForm()
        {
            bool bEnable = false;
            if (m_refMainForm.m_pCameraHandle != null)
            {
                NEPTUNE_XML_NODE_INFO stNodeInfo = new NEPTUNE_XML_NODE_INFO();
                if (NeptuneC.ntcGetNodeInfo(m_refMainForm.m_pCameraHandle, "Temperatures", ref stNodeInfo) == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    bEnable = true;
                }
            }

            Enabled = bEnable;
            if (bEnable)
            {
                GetYuvPaletteInfo();
                GetNucInfo();
                GetAlarmDetectInfo();
                GetImagePrivacyMaskSelect();
                GetPointTemperatureSelect();
                GetAlarmSelect();
            }
        }

        private bool GetNodeValue(String strNodeName, ref ComboBox cbo, ref NEPTUNE_XML_ENUM_LIST xmlValue)
        {
            bool bRet = false;

            ENeptuneError emErr = NeptuneC.ntcGetNodeEnum(m_refMainForm.m_pCameraHandle, strNodeName, ref xmlValue);
            if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
            {
                bRet = true;
            }
            else
            {
                String strLog;
                strLog = "ntcGetNodeEnum '" + strNodeName +"' Failed.";
                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, strLog, emErr);
            }

            cbo.Items.Clear();
            cbo.Enabled = bRet;
            if (bRet)
            {
                
                for (int i = 0; i < xmlValue.nCount; i++)
                {
                    cbo.Items.Add(xmlValue.pstrList[i]);
                }
                cbo.SelectedIndex = (Int32)xmlValue.nIndex;
            }

            return bRet;
        }

        private bool GetNodeValue(String strNodeName, ref TextBox tb, ref NEPTUNE_XML_INT_VALUE_INFO xmlValue)
        {
            bool bRet = false;

            ENeptuneError emErr = NeptuneC.ntcGetNodeInt(m_refMainForm.m_pCameraHandle, strNodeName, ref xmlValue);
            if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
            {
                bRet = true;
            }
            else
            {
                String strLog;
                strLog = "ntcGetNodeInt '" + strNodeName + "' Failed.";
                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, strLog, emErr);
            }

            tb.Enabled = bRet;
            if (bRet)
            {
                tb.Text = xmlValue.nValue.ToString();
            }

            return bRet;
        }

        private bool GetNodeValue(String strNodeName, ref TextBox tb, ref NEPTUNE_XML_FLOAT_VALUE_INFO xmlValue)
        {
            bool bRet = false;

            ENeptuneError emErr = NeptuneC.ntcGetNodeFloat(m_refMainForm.m_pCameraHandle, strNodeName, ref xmlValue);
            if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
            {
                bRet = true;
            }
            else
            {
                String strLog;
                strLog = "ntcGetNodeFloat '" + strNodeName + "' Failed.";
                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, strLog, emErr);
            }

            tb.Enabled = bRet;
            if (bRet)
            {
                tb.Text = xmlValue.dValue.ToString("N3");
            }

            return bRet;
        }

        private bool SetNodeValue(String strNodeName, ref ComboBox cbo, ref NEPTUNE_XML_ENUM_LIST xmlValue)
        {
            bool bRet = false;

            Int32 iCurSel = cbo.SelectedIndex;
            if (iCurSel != -1)
            {
                String strValue = cbo.SelectedItem.ToString();

                ENeptuneError emErr = NeptuneC.ntcSetNodeEnum(m_refMainForm.m_pCameraHandle, strNodeName, strValue);
                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    bRet = true;
                }
                else
                {
                    String strLog;
                    strLog = "ntcSetNodeEnum '" + strNodeName + "' Failed.";
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, strLog, emErr);
                }
                
                if (bRet)
                {
                    xmlValue.nIndex = (UInt32)iCurSel;
                }
                else
                {
                    cbo.SelectedIndex = (Int32)xmlValue.nIndex;
                }
            }

            return bRet;
        }

        private bool SetNodeValue(String strNodeName, ref TextBox tb, ref NEPTUNE_XML_INT_VALUE_INFO xmlValue)
        {
            bool bRet = false;

            String strText;
            strText = tb.Text;
            strText.Trim();

            Int64 iVal = (Int64)Convert.ToDecimal(strText);
            Int64 iNewVal = iVal;
            if (iNewVal < xmlValue.nMin)
            {
                iNewVal = xmlValue.nMin;
            }
            else if (iNewVal > xmlValue.nMax)
            {
                iNewVal = xmlValue.nMax;
            }

            Int64 iShare = iNewVal / xmlValue.nInc;
            iNewVal = iShare * xmlValue.nInc;

            if (iNewVal != iVal)
            {
                strText = iNewVal.ToString();
                tb.Text = strText;
            }

            ENeptuneError emErr = NeptuneC.ntcSetNodeInt(m_refMainForm.m_pCameraHandle, strNodeName, iNewVal);
            if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
            {
                bRet = true;
            }
            else
            {
                String strLog;
                strLog = "ntcSetNodeInt '" + strNodeName + "' Failed.";
                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, strLog, emErr);
            }

            if (bRet)
            {
                xmlValue.nValue = iNewVal;
            }
            else
            {
                strText = xmlValue.nValue.ToString();
                tb.Text = strText;
            }

            return bRet;
        }

        private bool SetNodeValue(String strNodeName, ref TextBox tb, ref NEPTUNE_XML_FLOAT_VALUE_INFO xmlValue)
        {
            bool bRet = false;

            String strText;
            strText = tb.Text;
            strText.Trim();

            Double dblVal = Convert.ToDouble(strText);
            Double dblNewVal = dblVal;

            if (dblNewVal < xmlValue.dMin)
            {
                dblNewVal = xmlValue.dMin;
            }
            else if (dblNewVal > xmlValue.dMax)
            {
                dblNewVal = xmlValue.dMax;
            }

            Double fShare = dblNewVal / xmlValue.dInc;
            Int64 iShare = (Int32)Math.Round(fShare);
            dblNewVal = iShare * xmlValue.dInc;

            if (dblNewVal != dblVal)
            {
                strText = dblNewVal.ToString("N3");
                tb.Text = strText;
            }

            ENeptuneError emErr = NeptuneC.ntcSetNodeFloat(m_refMainForm.m_pCameraHandle, strNodeName, dblNewVal);
            if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
            {
                bRet = true;
            }
            else
            {
                String strLog;
                strLog = "ntcSetNodeFloat '" + strNodeName + "' Failed.";
                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, strLog, emErr);
            }

            if (bRet)
            {
                xmlValue.dValue = dblNewVal;
            }
            else
            {
                strText = xmlValue.dValue.ToString("N3");
                tb.Text = strText;
            }

            return bRet;
        }

        private void PopupThermalForm_Load(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void PopupThermalForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_refMainForm.m_formPopupStrobe = null;
        }

        private void GetYuvPaletteInfo()
        {
            GetNodeValue("ImageColorPalette", ref cbPalette, ref m_stXmlPalette);
        }

        private void GetNucInfo()
        {
            GetNodeValue("NUCMode", ref cbNucMode, ref m_stXmlNucMode);
            GetNodeValue("NUCAutoPeriodicTime", ref tbNucAutoTime, ref m_stXmlNucAutoTime);
            GetNodeValue("NUCAutoTemperature", ref tbNucAutoTemperature, ref m_stXmlNucAutoTemperature);
        }

        private void GetAlarmDetectInfo()
        {
            GetNodeValue("AlarmDetectionPixelCount", ref tbAlarmDetectPixelCnt, ref m_stXmlAlarmDetectPixelCnt);
            GetNodeValue("AlarmDetectionStartDelayTime", ref tbAlarmDetectStartDelay, ref m_stXmlAlarmDetectStartDelay);
            GetNodeValue("AlarmDetectionStopDelayTime", ref tbAlarmDetectStopDelay, ref m_stXmlAlarmDetectStopDelay);
            GetNodeValue("AlarmDetectionOutputEnable", ref cbAlarmDetectOutputEnable, ref m_stXmlAlarmDetectOutputEnable);
            GetNodeValue("AlarmDetectionOutputPolarity", ref cbAlarmDetectOutputPolarity, ref m_stXmlAlarmDetectOutputPolarity);
        }

        private void GetImagePrivacyMaskSelect()
        {
            if (GetNodeValue("PrivacySelector", ref cbPrivacySelect, ref m_stXmlPrivacySelect))
            {
                GetImagePrivacyMaskInfo();
            }
        }

        private void GetPointTemperatureSelect()
        {
            if (GetNodeValue("PointTemperatureSelector", ref cbPointSelect, ref m_stXmlPointSelect))
            {
                GetPointTemperatureInfo();
            }
        }

        private void GetAlarmSelect()
        {
            if (GetNodeValue("AlarmSelector", ref cbAlarmSelect, ref m_stXmlAlarmSelect))
            {
                GetAlarmInfo();
            }
        }

        private void GetImagePrivacyMaskInfo()
        {
            GetNodeValue("SelectedPrivacyOnOff", ref cbPrivacyEnable, ref m_stXmlPrivacyEnable);
            GetNodeValue("PrivacyAreaLeft", ref tbPrivacyLeft, ref m_stXmlPrivacyLeft);
            GetNodeValue("PrivacyAreaTop", ref tbPrivacyTop, ref m_stXmlPrivacyTop);
            GetNodeValue("PrivacyAreaWidth", ref tbPrivacyWidth, ref m_stXmlPrivacyWidth);
            GetNodeValue("PrivacyAreaHeight", ref tbPrivacyHeight, ref m_stXmlPrivacyHeight);
        }

        private void GetPointTemperatureInfo()
        {
            GetNodeValue("SelectedPointTemperatureOnOff", ref cbPointEnable, ref m_stXmlPointEnable);
            GetNodeValue("PointTemperatureLeft", ref tbPointLeft, ref m_stXmlPointLeft);
            GetNodeValue("PointTemperatureTop", ref tbPointTop, ref m_stXmlPointTop);

            GetPoint();
        }

        private void GetAlarmInfo()
        {
            GetNodeValue("SelectedAlarmAreaOnOff", ref cbAlarmEnable, ref m_stXmlAlarmEnable);
            GetNodeValue("AlarmAreaLeft", ref tbAlarmLeft, ref m_stXmlAlarmLeft);
            GetNodeValue("AlarmAreaTop", ref tbAlarmTop, ref m_stXmlAlarmTop);
            GetNodeValue("AlarmAreaWidth", ref tbAlarmWidth, ref m_stXmlAlarmWidth);
            GetNodeValue("AlarmAreaHeight", ref tbAlarmHeight, ref m_stXmlAlarmHeight);

            GetNodeValue("AlarmCondition", ref cbAlarmCondition, ref m_stXmlAlarmCondition);
            GetNodeValue("AlarmReferenceTemperature", ref tbAlarmTemperature, ref m_stXmlAlarmTemperature);
            GetNodeValue("AlarmColorTransparencyOnOff", ref cbAlarmTransparency, ref m_stXmlAlarmTransparency);
            GetNodeValue("AlarmColor", ref cbAlarmColor, ref m_stXmlAlarmColor);

            GetAlarm();
        }

        private void btnGetPoint_Click(object sender, EventArgs e)
        {
            GetPoint();
        }

        private void btnGetAlarm_Click(object sender, EventArgs e)
        {
            GetAlarm();
        }

        private void GetPoint()
        {
            NEPTUNE_XML_FLOAT_VALUE_INFO xmlValue = new NEPTUNE_XML_FLOAT_VALUE_INFO();
            GetNodeValue("SelectedPointTemperature", ref tbPointTemperature, ref xmlValue);
        }

        private void GetAlarm()
        {
            NEPTUNE_XML_ENUM_LIST xmlValue = new NEPTUNE_XML_ENUM_LIST();
            GetNodeValue("SelectedAlarmDetectionStatus", ref cbAlarmStatus, ref xmlValue);
            cbAlarmStatus.Enabled = false;
        }

        private void cbPrivacySelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SetNodeValue("PrivacySelector", ref cbPrivacySelect, ref m_stXmlPrivacySelect))
            {
                GetImagePrivacyMaskInfo();
            }
        }

        private void cbPointSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SetNodeValue("PointTemperatureSelector", ref cbPointSelect, ref m_stXmlPointSelect))
            {
                GetPointTemperatureInfo();
            }
        }

        private void cbAlarmSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SetNodeValue("AlarmSelector", ref cbAlarmSelect, ref m_stXmlAlarmSelect))
            {
                GetAlarmInfo();
            }
        }

        private void btnSetPalette_Click(object sender, EventArgs e)
        {
            SetNodeValue("ImageColorPalette", ref cbPalette, ref m_stXmlPalette);
        }

        private void btnSetNuc_Click(object sender, EventArgs e)
        {
            SetNodeValue("NUCMode", ref cbNucMode, ref m_stXmlNucMode);
            SetNodeValue("NUCAutoPeriodicTime", ref tbNucAutoTime, ref m_stXmlNucAutoTime);
            SetNodeValue("NUCAutoTemperature", ref tbNucAutoTemperature, ref m_stXmlNucAutoTemperature);
        }

        private void btnSetDetect_Click(object sender, EventArgs e)
        {
            SetNodeValue("AlarmDetectionPixelCount", ref tbAlarmDetectPixelCnt, ref m_stXmlAlarmDetectPixelCnt);
            SetNodeValue("AlarmDetectionStartDelayTime", ref tbAlarmDetectStartDelay, ref m_stXmlAlarmDetectStartDelay);
            SetNodeValue("AlarmDetectionStopDelayTime", ref tbAlarmDetectStopDelay, ref m_stXmlAlarmDetectStopDelay);
            SetNodeValue("AlarmDetectionOutputEnable", ref cbAlarmDetectOutputEnable, ref m_stXmlAlarmDetectOutputEnable);
            SetNodeValue("AlarmDetectionOutputPolarity", ref cbAlarmDetectOutputPolarity, ref m_stXmlAlarmDetectOutputPolarity);
        }

        private void btnSetPrivacy_Click(object sender, EventArgs e)
        {
            SetNodeValue("SelectedPrivacyOnOff", ref cbPrivacyEnable, ref m_stXmlPrivacyEnable);
            SetNodeValue("PrivacyAreaLeft", ref tbPrivacyLeft, ref m_stXmlPrivacyLeft);
            SetNodeValue("PrivacyAreaTop", ref tbPrivacyTop, ref m_stXmlPrivacyTop);
            SetNodeValue("PrivacyAreaWidth", ref tbPrivacyWidth, ref m_stXmlPrivacyWidth);
            SetNodeValue("PrivacyAreaHeight", ref tbPrivacyHeight, ref m_stXmlPrivacyHeight);
        }

        private void btnSetPoint_Click(object sender, EventArgs e)
        {
            SetNodeValue("SelectedPointTemperatureOnOff", ref cbPointEnable, ref m_stXmlPointEnable);
            SetNodeValue("PointTemperatureLeft", ref tbPointLeft, ref m_stXmlPointLeft);
            SetNodeValue("PointTemperatureTop", ref tbPointTop, ref m_stXmlPointTop);
        }

        private void btnSetAlarm_Click(object sender, EventArgs e)
        {
            SetNodeValue("SelectedAlarmAreaOnOff", ref cbAlarmEnable, ref m_stXmlAlarmEnable);
            SetNodeValue("AlarmAreaLeft", ref tbAlarmLeft, ref m_stXmlAlarmLeft);
            SetNodeValue("AlarmAreaTop", ref tbAlarmTop, ref m_stXmlAlarmTop);
            SetNodeValue("AlarmAreaWidth", ref tbAlarmWidth, ref m_stXmlAlarmWidth);
            SetNodeValue("AlarmAreaHeight", ref tbAlarmHeight, ref m_stXmlAlarmHeight);
            SetNodeValue("AlarmCondition", ref cbAlarmCondition, ref m_stXmlAlarmCondition);
            SetNodeValue("AlarmReferenceTemperature", ref tbAlarmTemperature, ref m_stXmlAlarmTemperature);
            SetNodeValue("AlarmColorTransparencyOnOff", ref cbAlarmTransparency, ref m_stXmlAlarmTransparency);
            SetNodeValue("AlarmColor", ref cbAlarmColor, ref m_stXmlAlarmColor);
        }

        private void btnReqNUC_Click(object sender, EventArgs e)
        {
            ENeptuneError emErr = NeptuneC.ntcSetNodeCommand(m_refMainForm.m_pCameraHandle, "NUCManualRun");
            if (emErr != ENeptuneError.NEPTUNE_ERR_Success)
            {
                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetNodeCommand 'NUCManualRun' Failed.", emErr);
            }
        }


    }
}
