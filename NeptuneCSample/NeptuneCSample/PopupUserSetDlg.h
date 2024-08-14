#pragma once
#include "afxwin.h"


// CPopupUserSetDlg 대화 상자입니다.

class CPopupUserSetDlg : public CPopupBaseDialog
{
	DECLARE_DYNAMIC(CPopupUserSetDlg)

public:
	CPopupUserSetDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis);   // 표준 생성자입니다.
	virtual ~CPopupUserSetDlg();

// 대화 상자 데이터입니다.
	enum { IDD = IDD_POPUP_USERSET };

	virtual void UpdateDialog();

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 지원입니다.

	afx_msg void OnBnClickedButtonUsersetLoad();
	afx_msg void OnBnClickedButtonUsersetSave();
	afx_msg void OnBnClickedButtonUsersetDefault();
	DECLARE_MESSAGE_MAP()

	CComboBox m_cbUserSet;
};
