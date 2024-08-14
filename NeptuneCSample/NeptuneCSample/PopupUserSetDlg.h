#pragma once
#include "afxwin.h"


// CPopupUserSetDlg ��ȭ �����Դϴ�.

class CPopupUserSetDlg : public CPopupBaseDialog
{
	DECLARE_DYNAMIC(CPopupUserSetDlg)

public:
	CPopupUserSetDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis);   // ǥ�� �������Դϴ�.
	virtual ~CPopupUserSetDlg();

// ��ȭ ���� �������Դϴ�.
	enum { IDD = IDD_POPUP_USERSET };

	virtual void UpdateDialog();

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV �����Դϴ�.

	afx_msg void OnBnClickedButtonUsersetLoad();
	afx_msg void OnBnClickedButtonUsersetSave();
	afx_msg void OnBnClickedButtonUsersetDefault();
	DECLARE_MESSAGE_MAP()

	CComboBox m_cbUserSet;
};
