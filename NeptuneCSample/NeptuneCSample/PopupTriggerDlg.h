#pragma once
#include "afxwin.h"


// CPopupTriggerDlg ��ȭ �����Դϴ�.

class CPopupTriggerDlg : public CPopupBaseDialog
{
	DECLARE_DYNAMIC(CPopupTriggerDlg)

public:
	CPopupTriggerDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis);   // ǥ�� �������Դϴ�.
	virtual ~CPopupTriggerDlg();

// ��ȭ ���� �������Դϴ�.
	enum { IDD = IDD_POPUP_TRIGGER };

	virtual void UpdateDialog();

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV �����Դϴ�.

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
