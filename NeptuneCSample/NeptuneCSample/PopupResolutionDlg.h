#pragma once
#include "afxwin.h"


// CPopupResolutionDlg 대화 상자입니다.

class CPopupResolutionDlg : public CPopupBaseDialog
{
	DECLARE_DYNAMIC(CPopupResolutionDlg)

public:
	CPopupResolutionDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis);   // 표준 생성자입니다.
	virtual ~CPopupResolutionDlg();

// 대화 상자 데이터입니다.
	enum { IDD = IDD_POPUP_RESOLUTION };

	virtual void UpdateDialog();

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 지원입니다.

	afx_msg void OnBnClickedButtonApply();
	DECLARE_MESSAGE_MAP()

	CString m_strResolution;
	LONG m_nlOffsetX;
	LONG m_nlOffsetY;
	LONG m_nlWidth;
	LONG m_nlHeight;
};
