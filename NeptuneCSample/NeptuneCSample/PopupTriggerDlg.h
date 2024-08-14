#pragma once
#include "afxwin.h"


// CPopupTriggerDlg 대화 상자입니다.

class CPopupTriggerDlg : public CPopupBaseDialog
{
	DECLARE_DYNAMIC(CPopupTriggerDlg)

public:
	CPopupTriggerDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis);   // 표준 생성자입니다.
	virtual ~CPopupTriggerDlg();

// 대화 상자 데이터입니다.
	enum { IDD = IDD_POPUP_TRIGGER };

	virtual void UpdateDialog();

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 지원입니다.

	afx_msg void OnBnClickedButtonRun();
	afx_msg void OnBnClickedButtonApply();
	DECLARE_MESSAGE_MAP()

	BOOL m_bTriggerEnable;
	CComboBox m_cbTriggerMode;
	CComboBox m_cbTriggerSource;
	CComboBox m_cbTriggerPolarity;
	LONG m_nlTriggerParam;
	CString m_strParamRange;
	CButton m_btnSWTrigger;
};
