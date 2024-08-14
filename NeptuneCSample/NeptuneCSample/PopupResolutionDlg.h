#pragma once
#include "afxwin.h"


// CPopupResolutionDlg ��ȭ �����Դϴ�.

class CPopupResolutionDlg : public CPopupBaseDialog
{
	DECLARE_DYNAMIC(CPopupResolutionDlg)

public:
	CPopupResolutionDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis);   // ǥ�� �������Դϴ�.
	virtual ~CPopupResolutionDlg();

// ��ȭ ���� �������Դϴ�.
	enum { IDD = IDD_POPUP_RESOLUTION };

	virtual void UpdateDialog();

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV �����Դϴ�.

	afx_msg void OnBnClickedButtonApply();
	DECLARE_MESSAGE_MAP()

	CString m_strResolution;
	LONG m_nlOffsetX;
	LONG m_nlOffsetY;
	LONG m_nlWidth;
	LONG m_nlHeight;
};
