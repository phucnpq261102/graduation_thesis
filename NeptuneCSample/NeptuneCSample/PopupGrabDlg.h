#pragma once
#include "afxwin.h"


// CPopupGrabDlg ��ȭ �����Դϴ�.

class CPopupGrabDlg : public CPopupBaseDialog
{
	DECLARE_DYNAMIC(CPopupGrabDlg)

public:
	CPopupGrabDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis);   // ǥ�� �������Դϴ�.
	virtual ~CPopupGrabDlg();

// ��ȭ ���� �������Դϴ�.
	enum { IDD = IDD_POPUP_GRAB };

	virtual void InitControls();

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV �����Դϴ�.

	afx_msg void OnBnClickedButtonGrab();
	DECLARE_MESSAGE_MAP()

	CMFCEditBrowseCtrl m_edSavePath;
};
