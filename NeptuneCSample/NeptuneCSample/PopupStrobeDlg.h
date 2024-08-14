#pragma once
#include "afxwin.h"


// CPopupStrobeDlg ��ȭ �����Դϴ�.

class CPopupStrobeDlg : public CPopupBaseDialog
{
	DECLARE_DYNAMIC(CPopupStrobeDlg)

public:
	CPopupStrobeDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis);   // ǥ�� �������Դϴ�.
	virtual ~CPopupStrobeDlg();

// ��ȭ ���� �������Դϴ�.
	enum { IDD = IDD_POPUP_STROBE };

	virtual void UpdateDialog();

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV �����Դϴ�.

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
