#pragma once
#include "afxwin.h"


// CPopupFrameSaveDlg 대화 상자입니다.

class CPopupFrameSaveDlg : public CPopupBaseDialog
{
	DECLARE_DYNAMIC(CPopupFrameSaveDlg)

public:
	CPopupFrameSaveDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis);   // 표준 생성자입니다.
	virtual ~CPopupFrameSaveDlg();

// 대화 상자 데이터입니다.
	enum { IDD = IDD_POPUP_FRAMESAVE };

	virtual void UpdateDialog();

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 지원입니다.

	afx_msg void OnBnClickedCheckEnable();
	afx_msg void OnBnClickedButtonRefresh();
	afx_msg void OnBnClickedButtonPlay();
	DECLARE_MESSAGE_MAP()

	CButton m_ckEnable;
	CEdit m_edRemainCount;
	CEdit m_edReceiveCount;
};
