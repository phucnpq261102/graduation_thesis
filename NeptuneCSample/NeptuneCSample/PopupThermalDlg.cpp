// PopupThermalDlg.cpp : 구현 파일입니다.
//

#include "stdafx.h"
#include "NeptuneCSample.h"
#include "PopupThermalDlg.h"
#include "afxdialogex.h"


// CPopupThermalDlg 대화 상자입니다.

IMPLEMENT_DYNAMIC(CPopupThermalDlg, CPopupBaseDialog)

CPopupThermalDlg::CPopupThermalDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis)
	: CPopupBaseDialog(CPopupThermalDlg::IDD, pCameraHandle, ppThis)
{

}

CPopupThermalDlg::~CPopupThermalDlg()
{
}

void CPopupThermalDlg::DoDataExchange(CDataExchange* pDX)
{
	CPopupBaseDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_COMBO_PALETTE, m_cbPalette);
	DDX_Control(pDX, IDC_COMBO_NUC_MODE, m_cbNucMode);
	DDX_Control(pDX, IDC_EDIT_NUC_AUTO_TIME, m_edtNucAutoTime);
	DDX_Control(pDX, IDC_EDIT_NUC_AUTO_TEMPERATURE, m_edtNucAutoTemperature);
	DDX_Control(pDX, IDC_EDIT_ALARM_DETECT_PIXEL_CNT, m_edtAlarmDetectPixelCnt);
	DDX_Control(pDX, IDC_EDIT_ALARM_DETECT_PIXEL_START_DELAY, m_edtAlarmDetectStartDelay);
	DDX_Control(pDX, IDC_EDIT_ALARM_DETECT_PIXEL_STOP_DELAY, m_edtAlarmDetectStopDelay);
	DDX_Control(pDX, IDC_COMBO_ALARM_DETECT_OUTPUT_ENABLE, m_cbAlarmDetectOutputEnable);
	DDX_Control(pDX, IDC_COMBO_ALARM_DETECT_OUTPUT_POLARITY, m_cbAlarmDetectOutputPolarity);
	DDX_Control(pDX, IDC_BUTTON_REQUEST_NUC, m_btnReqNUC);
	DDX_Control(pDX, IDC_COMBO_PRIVACY_SELECT, m_cbPrivacySelect);
	DDX_Control(pDX, IDC_COMBO_PRIVACY_ENABLE, m_cbPrivacyEnable);
	DDX_Control(pDX, IDC_EDIT_PRIVACY_LEFT, m_edtPrivacyLeft);
	DDX_Control(pDX, IDC_EDIT_PRIVACY_TOP, m_edtPrivacyTop);
	DDX_Control(pDX, IDC_EDIT_PRIVACY_WIDTH, m_edtPrivacyWidth);
	DDX_Control(pDX, IDC_EDIT_PRIVACY_HEIGHT, m_edtPrivacyHeight);
	DDX_Control(pDX, IDC_COMBO_POINT_SELECT, m_cbPointSelect);
	DDX_Control(pDX, IDC_COMBO_POINT_ENABLE, m_cbPointEnable);
	DDX_Control(pDX, IDC_EDIT_POINT_LEFT, m_edtPointLeft);
	DDX_Control(pDX, IDC_EDIT_POINT_TOP, m_edtPointTop);
	DDX_Control(pDX, IDC_COMBO_ALARM_SELECT, m_cbAlarmSelect);
	DDX_Control(pDX, IDC_COMBO_ALARM_ENABLE, m_cbAlarmEnable);
	DDX_Control(pDX, IDC_EDIT_ALARM_LEFT, m_edtAlarmLeft);
	DDX_Control(pDX, IDC_EDIT_ALARM_TOP, m_edtAlarmTop);
	DDX_Control(pDX, IDC_EDIT_ALARM_WIDTH, m_edtAlarmWidth);
	DDX_Control(pDX, IDC_EDIT_ALARM_HEIGHT, m_edtAlarmHeight);
	DDX_Control(pDX, IDC_COMBO_ALARM_CONDITION, m_cbAlarmCondition);
	DDX_Control(pDX, IDC_EDIT_ALARM_TEMPERATURE, m_edtAlarmTemperature);
	DDX_Control(pDX, IDC_COMBO_ALARM_TRANSPARENCY, m_cbAlarmTransparency);
	DDX_Control(pDX, IDC_COMBO_ALARM_COLOR, m_cbAlarmColor);
	DDX_Control(pDX, IDC_EDIT_POINT_TEMPERATURE, m_edtPointTemperature);
	DDX_Control(pDX, IDC_COMBO_ALARM_STATUS, m_cbAlarmStatus);
}


BEGIN_MESSAGE_MAP(CPopupThermalDlg, CPopupBaseDialog)
	ON_CBN_SELCHANGE(IDC_COMBO_PRIVACY_SELECT, &CPopupThermalDlg::OnCbnSelchangeComboPrivacySelect)
	ON_CBN_SELCHANGE(IDC_COMBO_POINT_SELECT, &CPopupThermalDlg::OnCbnSelchangeComboPointSelect)
	ON_CBN_SELCHANGE(IDC_COMBO_ALARM_SELECT, &CPopupThermalDlg::OnCbnSelchangeComboAlarmSelect)
	ON_BN_CLICKED(IDC_BUTTON_SET_PALETTE, &CPopupThermalDlg::OnBnClickedButtonSetPalette)
	ON_BN_CLICKED(IDC_BUTTON_SET_NUC, &CPopupThermalDlg::OnBnClickedButtonSetNuc)
	ON_BN_CLICKED(IDC_BUTTON_SET_ALARM_DETECT, &CPopupThermalDlg::OnBnClickedButtonSetAlarmDetect)
	ON_BN_CLICKED(IDC_BUTTON_SET_PRIVACY, &CPopupThermalDlg::OnBnClickedButtonSetPrivacy)
	ON_BN_CLICKED(IDC_BUTTON_SET_POINT, &CPopupThermalDlg::OnBnClickedButtonSetPoint)
	ON_BN_CLICKED(IDC_BUTTON_SET_ALARM, &CPopupThermalDlg::OnBnClickedButtonSetAlarm)
	ON_BN_CLICKED(IDC_BUTTON_REQUEST_NUC, &CPopupThermalDlg::OnBnClickedButtonRequestNuc)
	ON_BN_CLICKED(IDC_BUTTON_GET_POINT, &CPopupThermalDlg::OnBnClickedButtonGetPoint)
	ON_BN_CLICKED(IDC_BUTTON_GET_ALARM, &CPopupThermalDlg::OnBnClickedButtonGetAlarm)
END_MESSAGE_MAP()


// CPopupThermalDlg 메시지 처리기입니다.

void CPopupThermalDlg::UpdateDialog()
{
	BOOL bEnable = FALSE;
	if (m_pCameraHandle)
	{
		NEPTUNE_XML_NODE_INFO stNodeInfo;
		if (ntcGetNodeInfo(m_pCameraHandle, "Temperatures", &stNodeInfo) == NEPTUNE_ERR_Success)
		{
			bEnable = TRUE;
		}
	}

	EnableWindow(bEnable);
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

void CPopupThermalDlg::GetYuvPaletteInfo()
{
	GetNodeValue("ImageColorPalette", &m_cbPalette, &m_stXmlPalette);
}

void CPopupThermalDlg::GetNucInfo()
{
	GetNodeValue("NUCMode", &m_cbNucMode, &m_stXmlNucMode);
	GetNodeValue("NUCAutoPeriodicTime", &m_edtNucAutoTime, &m_stXmlNucAutoTime);
	GetNodeValue("NUCAutoTemperature", &m_edtNucAutoTemperature, &m_stXmlNucAutoTemperature);
}

void CPopupThermalDlg::GetAlarmDetectInfo()
{
	GetNodeValue("AlarmDetectionPixelCount", &m_edtAlarmDetectPixelCnt, &m_stXmlAlarmDetectPixelCnt);
	GetNodeValue("AlarmDetectionStartDelayTime", &m_edtAlarmDetectStartDelay, &m_stXmlAlarmDetectStartDelay);
	GetNodeValue("AlarmDetectionStopDelayTime", &m_edtAlarmDetectStopDelay, &m_stXmlAlarmDetectStopDelay);
	GetNodeValue("AlarmDetectionOutputEnable", &m_cbAlarmDetectOutputEnable, &m_stXmlAlarmDetectOutputEnable);
	GetNodeValue("AlarmDetectionOutputPolarity", &m_cbAlarmDetectOutputPolarity, &m_stXmlAlarmDetectOutputPolarity);
}

void CPopupThermalDlg::GetImagePrivacyMaskSelect()
{
	if (GetNodeValue("PrivacySelector", &m_cbPrivacySelect, &m_stXmlPrivacySelect))
	{
		GetImagePrivacyMaskInfo();
	}
}

void CPopupThermalDlg::GetPointTemperatureSelect()
{
	if (GetNodeValue("PointTemperatureSelector", &m_cbPointSelect, &m_stXmlPointSelect))
	{
		GetPointTemperatureInfo();
	}
}

void CPopupThermalDlg::GetAlarmSelect()
{
	if (GetNodeValue("AlarmSelector", &m_cbAlarmSelect, &m_stXmlAlarmSelect))
	{
		GetAlarmInfo();
	}
}

void CPopupThermalDlg::GetImagePrivacyMaskInfo()
{
	GetNodeValue("SelectedPrivacyOnOff", &m_cbPrivacyEnable, &m_stXmlPrivacyEnable);
	GetNodeValue("PrivacyAreaLeft", &m_edtPrivacyLeft, &m_stXmlPrivacyLeft);
	GetNodeValue("PrivacyAreaTop", &m_edtPrivacyTop, &m_stXmlPrivacyTop);
	GetNodeValue("PrivacyAreaWidth", &m_edtPrivacyWidth, &m_stXmlPrivacyWidth);
	GetNodeValue("PrivacyAreaHeight", &m_edtPrivacyHeight, &m_stXmlPrivacyHeight);
}

void CPopupThermalDlg::GetPointTemperatureInfo()
{
	GetNodeValue("SelectedPointTemperatureOnOff", &m_cbPointEnable, &m_stXmlPointEnable);
	GetNodeValue("PointTemperatureLeft", &m_edtPointLeft, &m_stXmlPointLeft);
	GetNodeValue("PointTemperatureTop", &m_edtPointTop, &m_stXmlPointTop);

	OnBnClickedButtonGetPoint();
}

void CPopupThermalDlg::GetAlarmInfo()
{
	GetNodeValue("SelectedAlarmAreaOnOff", &m_cbAlarmEnable, &m_stXmlAlarmEnable);
	GetNodeValue("AlarmAreaLeft", &m_edtAlarmLeft, &m_stXmlAlarmLeft);
	GetNodeValue("AlarmAreaTop", &m_edtAlarmTop, &m_stXmlAlarmTop);
	GetNodeValue("AlarmAreaWidth", &m_edtAlarmWidth, &m_stXmlAlarmWidth);
	GetNodeValue("AlarmAreaHeight", &m_edtAlarmHeight, &m_stXmlAlarmHeight);

	GetNodeValue("AlarmCondition", &m_cbAlarmCondition, &m_stXmlAlarmCondition);
	GetNodeValue("AlarmReferenceTemperature", &m_edtAlarmTemperature, &m_stXmlAlarmTemperature);
	GetNodeValue("AlarmColorTransparencyOnOff", &m_cbAlarmTransparency, &m_stXmlAlarmTransparency);
	GetNodeValue("AlarmColor", &m_cbAlarmColor, &m_stXmlAlarmColor);

	OnBnClickedButtonGetAlarm();
}


void CPopupThermalDlg::OnCbnSelchangeComboPrivacySelect()
{
	if (SetNodeValue("PrivacySelector", &m_cbPrivacySelect, &m_stXmlPrivacySelect))
	{
		GetImagePrivacyMaskInfo();
	}
}


void CPopupThermalDlg::OnCbnSelchangeComboPointSelect()
{
	if (SetNodeValue("PointTemperatureSelector", &m_cbPointSelect, &m_stXmlPointSelect))
	{
		GetPointTemperatureInfo();
	}
}


void CPopupThermalDlg::OnCbnSelchangeComboAlarmSelect()
{
	if (SetNodeValue("AlarmSelector", &m_cbAlarmSelect, &m_stXmlAlarmSelect))
	{
		GetAlarmInfo();
	}
}


void CPopupThermalDlg::OnBnClickedButtonSetPalette()
{
	SetNodeValue("ImageColorPalette", &m_cbPalette, &m_stXmlPalette);
}


void CPopupThermalDlg::OnBnClickedButtonSetNuc()
{
	SetNodeValue("NUCMode", &m_cbNucMode, &m_stXmlNucMode);
	SetNodeValue("NUCAutoPeriodicTime", &m_edtNucAutoTime, &m_stXmlNucAutoTime);
	SetNodeValue("NUCAutoTemperature", &m_edtNucAutoTemperature, &m_stXmlNucAutoTemperature);
}


void CPopupThermalDlg::OnBnClickedButtonSetAlarmDetect()
{
	SetNodeValue("AlarmDetectionPixelCount", &m_edtAlarmDetectPixelCnt, &m_stXmlAlarmDetectPixelCnt);
	SetNodeValue("AlarmDetectionStartDelayTime", &m_edtAlarmDetectStartDelay, &m_stXmlAlarmDetectStartDelay);
	SetNodeValue("AlarmDetectionStopDelayTime", &m_edtAlarmDetectStopDelay, &m_stXmlAlarmDetectStopDelay);
	SetNodeValue("AlarmDetectionOutputEnable", &m_cbAlarmDetectOutputEnable, &m_stXmlAlarmDetectOutputEnable);
	SetNodeValue("AlarmDetectionOutputPolarity", &m_cbAlarmDetectOutputPolarity, &m_stXmlAlarmDetectOutputPolarity);
}


void CPopupThermalDlg::OnBnClickedButtonSetPrivacy()
{
	SetNodeValue("SelectedPrivacyOnOff", &m_cbPrivacyEnable, &m_stXmlPrivacyEnable);
	SetNodeValue("PrivacyAreaLeft", &m_edtPrivacyLeft, &m_stXmlPrivacyLeft);
	SetNodeValue("PrivacyAreaTop", &m_edtPrivacyTop, &m_stXmlPrivacyTop);
	SetNodeValue("PrivacyAreaWidth", &m_edtPrivacyWidth, &m_stXmlPrivacyWidth);
	SetNodeValue("PrivacyAreaHeight", &m_edtPrivacyHeight, &m_stXmlPrivacyHeight);
}


void CPopupThermalDlg::OnBnClickedButtonSetPoint()
{
	SetNodeValue("SelectedPointTemperatureOnOff", &m_cbPointEnable, &m_stXmlPointEnable);
	SetNodeValue("PointTemperatureLeft", &m_edtPointLeft, &m_stXmlPointLeft);
	SetNodeValue("PointTemperatureTop", &m_edtPointTop, &m_stXmlPointTop);
}


void CPopupThermalDlg::OnBnClickedButtonSetAlarm()
{
	SetNodeValue("SelectedAlarmAreaOnOff", &m_cbAlarmEnable, &m_stXmlAlarmEnable);
	SetNodeValue("AlarmAreaLeft", &m_edtAlarmLeft, &m_stXmlAlarmLeft);
	SetNodeValue("AlarmAreaTop", &m_edtAlarmTop, &m_stXmlAlarmTop);
	SetNodeValue("AlarmAreaWidth", &m_edtAlarmWidth, &m_stXmlAlarmWidth);
	SetNodeValue("AlarmAreaHeight", &m_edtAlarmHeight, &m_stXmlAlarmHeight);
	SetNodeValue("AlarmCondition", &m_cbAlarmCondition, &m_stXmlAlarmCondition);
	SetNodeValue("AlarmReferenceTemperature", &m_edtAlarmTemperature, &m_stXmlAlarmTemperature);
	SetNodeValue("AlarmColorTransparencyOnOff", &m_cbAlarmTransparency, &m_stXmlAlarmTransparency);
	SetNodeValue("AlarmColor", &m_cbAlarmColor, &m_stXmlAlarmColor);
}


void CPopupThermalDlg::OnBnClickedButtonRequestNuc()
{
	ENeptuneError emErr = ntcSetNodeCommand(m_pCameraHandle, "NUCManualRun");
	if (emErr != NEPTUNE_ERR_Success)
	{
		InsertLog(TYPE_ERROR, _T("ntcSetNodeCommand 'NUCManualRun' Failed."), emErr);
	}
}


BOOL CPopupThermalDlg::GetNodeValue(LPCSTR lpszNodeName, CComboBox* pcb, NEPTUNE_XML_ENUM_LIST* pXmlValue)
{
	BOOL bRet = FALSE;

	USES_CONVERSION;

	for (int i = pcb->GetCount() - 1; i >= 0; i--)
	{
		pcb->DeleteString(i);
	}
	ENeptuneError emErr = ntcGetNodeEnum(m_pCameraHandle, lpszNodeName, pXmlValue);
	if (emErr == NEPTUNE_ERR_Success)
	{
		for (_uint32_t i=0; i<pXmlValue->nCount; i++)
		{
			CString strValue = A2T(pXmlValue->pstrList[i]);
			pcb->InsertString(i, strValue);
		}
		pcb->SetCurSel(pXmlValue->nIndex);
		bRet = TRUE;
	}
	else
	{
		CString strNodeName = A2T(lpszNodeName);

		CString strLog = _T("");
		strLog.Format(_T("ntcGetNodeEnum '%s' Failed."), strNodeName);
		InsertLog(TYPE_ERROR, strLog, emErr);
	}
	pcb->EnableWindow(bRet);

	return bRet;
}

BOOL CPopupThermalDlg::GetNodeValue(LPCSTR lpszNodeName, CEdit* pedt, NEPTUNE_XML_INT_VALUE_INFO* pXmlValue)
{
	BOOL bRet = FALSE;
	ENeptuneError emErr = ntcGetNodeInt(m_pCameraHandle, lpszNodeName, pXmlValue);
	if (emErr == NEPTUNE_ERR_Success)
	{
		CString strValue = _T("");
		strValue.Format(_T("%I64d"), pXmlValue->nValue);
		pedt->SetWindowText(strValue);
		bRet = TRUE;
	}
	else
	{
		USES_CONVERSION;
		CString strNodeName = A2T(lpszNodeName);

		CString strLog = _T("");
		strLog.Format(_T("ntcGetNodeInt '%s' Failed."), strNodeName);
		InsertLog(TYPE_ERROR, strLog, emErr);
	}
	pedt->EnableWindow(bRet);

	return bRet;
}

BOOL CPopupThermalDlg::GetNodeValue(LPCSTR lpszNodeName, CEdit* pedt, NEPTUNE_XML_FLOAT_VALUE_INFO* pXmlValue)
{
	BOOL bRet = FALSE;
	ENeptuneError emErr = ntcGetNodeFloat(m_pCameraHandle, lpszNodeName, pXmlValue);
	if (emErr == NEPTUNE_ERR_Success)
	{
		CString strValue = _T("");
		strValue.Format(_T("%.3lf"), pXmlValue->dValue);
		pedt->SetWindowText(strValue);
		bRet = TRUE;
	}
	else
	{
		USES_CONVERSION;
		CString strNodeName = A2T(lpszNodeName);

		CString strLog = _T("");
		strLog.Format(_T("ntcGetNodeFloat '%s' Failed."), strNodeName);
		InsertLog(TYPE_ERROR, strLog, emErr);
	}
	pedt->EnableWindow(bRet);

	return bRet;
}

BOOL CPopupThermalDlg::SetNodeValue(LPCSTR lpszNodeName, CComboBox* pcb, NEPTUNE_XML_ENUM_LIST* pXmlValue)
{
	BOOL bRet = FALSE;

	int iSel = pcb->GetCurSel();
	if (iSel != CB_ERR)
	{
		USES_CONVERSION;

		CString strSelect = _T("");
		pcb->GetLBText(iSel, strSelect);
		CStringA strValue = T2A(strSelect);

		ENeptuneError emErr = ntcSetNodeEnum(m_pCameraHandle, lpszNodeName, strValue.GetBuffer(0));
		if (emErr == NEPTUNE_ERR_Success)
		{
			pXmlValue->nIndex = iSel;
			bRet = TRUE;
		}
		else
		{
			CString strNodeName = A2T(lpszNodeName);

			CString strLog = _T("");
			strLog.Format(_T("ntcSetNodeEnum '%s' Failed."), strNodeName);
			InsertLog(TYPE_ERROR, strLog, emErr);

			pcb->SetCurSel(pXmlValue->nIndex);
		}
	}

	return bRet;
}

BOOL CPopupThermalDlg::SetNodeValue(LPCSTR lpszNodeName, CEdit* pedt, NEPTUNE_XML_INT_VALUE_INFO* pXmlValue)
{
	BOOL bRet = FALSE;

	CString strText = _T("");
	pedt->GetWindowText(strText);
	strText.TrimLeft();
	strText.TrimRight();
	__int64 iVal	= _ttoi64(strText);
	__int64 iNewVal = iVal;
	if (iNewVal < pXmlValue->nMin)
	{
		iNewVal = pXmlValue->nMin;
	}
	else if (iNewVal > pXmlValue->nMax)
	{
		iNewVal = pXmlValue->nMax;
	}

	__int64 iShare = iNewVal / pXmlValue->nInc;
	iNewVal = iShare * pXmlValue->nInc;

	if (iNewVal != iVal)
	{
		strText.Format(_T("%I64d"), iNewVal);
		pedt->SetWindowText(strText);
	}

	ENeptuneError emErr = ntcSetNodeInt(m_pCameraHandle, lpszNodeName, iNewVal);
	if (emErr == NEPTUNE_ERR_Success)
	{
		pXmlValue->nValue = iNewVal;
		bRet = TRUE;
	}
	else
	{
		USES_CONVERSION;
		CString strNodeName = A2T(lpszNodeName);

		CString strLog = _T("");
		strLog.Format(_T("ntcSetNodeInt '%s' Failed."), strNodeName);
		InsertLog(TYPE_ERROR, strLog, emErr);

		strText.Format(_T("%I64d"), pXmlValue->nValue);
		pedt->SetWindowText(strText);
	}

	return bRet;
}

BOOL CPopupThermalDlg::SetNodeValue(LPCSTR lpszNodeName, CEdit* pedt, NEPTUNE_XML_FLOAT_VALUE_INFO* pXmlValue)
{
	BOOL bRet = FALSE;

	CString strText = _T("");
	pedt->GetWindowText(strText);
	strText.TrimLeft();
	strText.TrimRight();
	if (strText.GetLength() > 0)
	{
		double dblVal = 0.0;
		_stscanf_s(strText, _T("%lf"), &dblVal);

		double dblNewVal = dblVal;

		if (dblNewVal < pXmlValue->dMin)
		{
			dblNewVal = pXmlValue->dMin;
		}
		else if (dblNewVal > pXmlValue->dMax)
		{
			dblNewVal = pXmlValue->dMax;
		}

		double dblShare = dblNewVal / pXmlValue->dInc;
		__int64 iShare = round(dblShare);
		dblNewVal = iShare*pXmlValue->dInc;

		if (dblNewVal != dblVal)
		{
			strText.Format(_T("%.3lf"), dblNewVal);
			pedt->SetWindowText(strText);
		}

		ENeptuneError emErr = ntcSetNodeFloat(m_pCameraHandle, lpszNodeName, dblNewVal);
		if (emErr == NEPTUNE_ERR_Success)
		{
			pXmlValue->dValue = dblNewVal;
			bRet = TRUE;
		}
		else
		{
			USES_CONVERSION;
			CString strNodeName = A2T(lpszNodeName);

			CString strLog = _T("");
			strLog.Format(_T("ntcSetNodeFloat '%s' Failed."), strNodeName);
			InsertLog(TYPE_ERROR, strLog, emErr);

			strText.Format(_T("%.3lf"), pXmlValue->dValue);
			pedt->SetWindowText(strText);
		}
	}

	return bRet;
}


void CPopupThermalDlg::OnBnClickedButtonGetPoint()
{
	NEPTUNE_XML_FLOAT_VALUE_INFO stXmlPointTemperature;
	GetNodeValue("SelectedPointTemperature", &m_edtPointTemperature, &stXmlPointTemperature);
}


void CPopupThermalDlg::OnBnClickedButtonGetAlarm()
{
	NEPTUNE_XML_ENUM_LIST stXmlAlarmStatus;
	GetNodeValue("SelectedAlarmDetectionStatus", &m_cbAlarmStatus, &stXmlAlarmStatus);
	m_cbAlarmStatus.EnableWindow(FALSE);
}
