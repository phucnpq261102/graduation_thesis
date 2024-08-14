#pragma once
#include "afxwin.h"


// CPopupThermalDlg 대화 상자입니다.

class CPopupThermalDlg : public CPopupBaseDialog
{
	DECLARE_DYNAMIC(CPopupThermalDlg)

public:
	CPopupThermalDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis);   // 표준 생성자입니다.
	virtual ~CPopupThermalDlg();

// 대화 상자 데이터입니다.
	enum { IDD = IDD_POPUP_THERMAL };

	virtual void UpdateDialog();

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 지원입니다.

	DECLARE_MESSAGE_MAP()
public:
	CComboBox m_cbPalette;

	CComboBox m_cbNucMode;
	CEdit m_edtNucAutoTime;
	CEdit m_edtNucAutoTemperature;

	CEdit m_edtAlarmDetectPixelCnt;
	CEdit m_edtAlarmDetectStartDelay;
	CEdit m_edtAlarmDetectStopDelay;
	CComboBox m_cbAlarmDetectOutputEnable;
	CComboBox m_cbAlarmDetectOutputPolarity;
	CButton m_btnReqNUC;

	CComboBox m_cbPrivacySelect;
	CComboBox m_cbPrivacyEnable;
	CEdit m_edtPrivacyLeft;
	CEdit m_edtPrivacyTop;
	CEdit m_edtPrivacyWidth;
	CEdit m_edtPrivacyHeight;

	CComboBox m_cbPointSelect;
	CComboBox m_cbPointEnable;
	CEdit m_edtPointLeft;
	CEdit m_edtPointTop;

	CComboBox m_cbAlarmSelect;
	CComboBox m_cbAlarmEnable;
	CEdit m_edtAlarmLeft;
	CEdit m_edtAlarmTop;
	CEdit m_edtAlarmWidth;
	CEdit m_edtAlarmHeight;
	CComboBox m_cbAlarmCondition;
	CEdit m_edtAlarmTemperature;
	CComboBox m_cbAlarmTransparency;
	CComboBox m_cbAlarmColor;

	NEPTUNE_XML_ENUM_LIST m_stXmlPalette;

	NEPTUNE_XML_ENUM_LIST m_stXmlNucMode;
	NEPTUNE_XML_INT_VALUE_INFO m_stXmlNucAutoTime;
	NEPTUNE_XML_INT_VALUE_INFO m_stXmlNucAutoTemperature;

	NEPTUNE_XML_INT_VALUE_INFO m_stXmlAlarmDetectPixelCnt;
	NEPTUNE_XML_FLOAT_VALUE_INFO m_stXmlAlarmDetectStartDelay;
	NEPTUNE_XML_FLOAT_VALUE_INFO m_stXmlAlarmDetectStopDelay;
	NEPTUNE_XML_ENUM_LIST m_stXmlAlarmDetectOutputEnable;
	NEPTUNE_XML_ENUM_LIST m_stXmlAlarmDetectOutputPolarity;

	NEPTUNE_XML_ENUM_LIST m_stXmlPrivacySelect;
	NEPTUNE_XML_ENUM_LIST m_stXmlPrivacyEnable;
	NEPTUNE_XML_INT_VALUE_INFO m_stXmlPrivacyLeft;
	NEPTUNE_XML_INT_VALUE_INFO m_stXmlPrivacyTop;
	NEPTUNE_XML_INT_VALUE_INFO m_stXmlPrivacyWidth;
	NEPTUNE_XML_INT_VALUE_INFO m_stXmlPrivacyHeight;

	NEPTUNE_XML_ENUM_LIST m_stXmlPointSelect;
	NEPTUNE_XML_ENUM_LIST m_stXmlPointEnable;
	NEPTUNE_XML_INT_VALUE_INFO m_stXmlPointLeft;
	NEPTUNE_XML_INT_VALUE_INFO m_stXmlPointTop;

	NEPTUNE_XML_ENUM_LIST m_stXmlAlarmSelect;
	NEPTUNE_XML_ENUM_LIST m_stXmlAlarmEnable;
	NEPTUNE_XML_INT_VALUE_INFO m_stXmlAlarmLeft;
	NEPTUNE_XML_INT_VALUE_INFO m_stXmlAlarmTop;
	NEPTUNE_XML_INT_VALUE_INFO m_stXmlAlarmWidth;
	NEPTUNE_XML_INT_VALUE_INFO m_stXmlAlarmHeight;
	NEPTUNE_XML_ENUM_LIST m_stXmlAlarmCondition;
	NEPTUNE_XML_FLOAT_VALUE_INFO m_stXmlAlarmTemperature;
	NEPTUNE_XML_ENUM_LIST m_stXmlAlarmTransparency;
	NEPTUNE_XML_ENUM_LIST m_stXmlAlarmColor;

	void GetYuvPaletteInfo();
	void GetNucInfo();
	void GetAlarmDetectInfo();
	void GetImagePrivacyMaskSelect();
	void GetPointTemperatureSelect();
	void GetAlarmSelect();
	void GetImagePrivacyMaskInfo();
	void GetPointTemperatureInfo();
	void GetAlarmInfo();

	BOOL GetNodeValue(LPCSTR lpszNodeName, CComboBox* pcb, NEPTUNE_XML_ENUM_LIST* pXmlValue);
	BOOL GetNodeValue(LPCSTR lpszNodeName, CEdit* pedt, NEPTUNE_XML_INT_VALUE_INFO* pXmlValue);
	BOOL GetNodeValue(LPCSTR lpszNodeName, CEdit* pedt, NEPTUNE_XML_FLOAT_VALUE_INFO* pXmlValue);

	BOOL SetNodeValue(LPCSTR lpszNodeName, CComboBox* pcb, NEPTUNE_XML_ENUM_LIST* pXmlValue);
	BOOL SetNodeValue(LPCSTR lpszNodeName, CEdit* pedt, NEPTUNE_XML_INT_VALUE_INFO* pXmlValue);
	BOOL SetNodeValue(LPCSTR lpszNodeName, CEdit* pedt, NEPTUNE_XML_FLOAT_VALUE_INFO* pXmlValue);

	afx_msg void OnCbnSelchangeComboPrivacySelect();
	afx_msg void OnCbnSelchangeComboPointSelect();
	afx_msg void OnCbnSelchangeComboAlarmSelect();
	afx_msg void OnBnClickedButtonSetPalette();
	afx_msg void OnBnClickedButtonSetNuc();
	afx_msg void OnBnClickedButtonSetAlarmDetect();
	afx_msg void OnBnClickedButtonSetPrivacy();
	afx_msg void OnBnClickedButtonSetPoint();
	afx_msg void OnBnClickedButtonSetAlarm();
	afx_msg void OnBnClickedButtonRequestNuc();

	inline __int64 round(double x)
	{
		return (__int64)(x > 0.0 ? x + 0.5 : x - 0.5);
	}
	CEdit m_edtPointTemperature;
	afx_msg void OnBnClickedButtonGetPoint();
	CComboBox m_cbAlarmStatus;
	afx_msg void OnBnClickedButtonGetAlarm();
};
