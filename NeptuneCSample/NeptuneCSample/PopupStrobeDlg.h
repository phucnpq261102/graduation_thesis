#pragma once
#include "afxwin.h"


// CPopupStrobeDlg 대화 상자입니다.

class CPopupStrobeDlg : public CPopupBaseDialog
{
	DECLARE_DYNAMIC(CPopupStrobeDlg)

public:
	CPopupStrobeDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis);   // 표준 생성자입니다.
	virtual ~CPopupStrobeDlg();

// 대화 상자 데이터입니다.
	enum { IDD = IDD_POPUP_STROBE };

	virtual void UpdateDialog();

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 지원입니다.

	afx_msg void OnBnClickedButtonApply();
	DECLARE_MESSAGE_MAP()

	BOOL m_bStrobeEnable;
	CComboBox m_cbStrobeMode;
	CComboBox m_cbStrobePolarity;
	LONG m_nlStrobeDelay;
	LONG m_nlStrobeDelayMin;
	LONG m_nlStrobeDelayMax;
	LONG m_nlStrobeDuration;
	LONG m_nlStrobeDurationMin;
	LONG m_nlStrobeDurationMax;
	CString m_strDelayRange;
	CString m_strDurationRange;
	CEdit m_edStrobeDelay;
	CEdit m_edStrobeDuration;
};
