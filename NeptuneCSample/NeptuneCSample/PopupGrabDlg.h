#pragma once
#include "afxwin.h"


// CPopupGrabDlg 대화 상자입니다.

class CPopupGrabDlg : public CPopupBaseDialog
{
	DECLARE_DYNAMIC(CPopupGrabDlg)

public:
	CPopupGrabDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis);   // 표준 생성자입니다.
	virtual ~CPopupGrabDlg();

// 대화 상자 데이터입니다.
	enum { IDD = IDD_POPUP_GRAB };

	virtual void InitControls();

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 지원입니다.

	afx_msg void OnBnClickedButtonGrab();
	DECLARE_MESSAGE_MAP()

	CMFCEditBrowseCtrl m_edSavePath;
};
