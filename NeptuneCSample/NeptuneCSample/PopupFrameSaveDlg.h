#pragma once
#include "afxwin.h"


// CPopupFrameSaveDlg ��ȭ �����Դϴ�.

class CPopupFrameSaveDlg : public CPopupBaseDialog
{
	DECLARE_DYNAMIC(CPopupFrameSaveDlg)

public:
	CPopupFrameSaveDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis);   // ǥ�� �������Դϴ�.
	virtual ~CPopupFrameSaveDlg();

// ��ȭ ���� �������Դϴ�.
	enum { IDD = IDD_POPUP_FRAMESAVE };

	virtual void UpdateDialog();

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV �����Դϴ�.

	afx_msg void OnBnClickedCheckEnable();
	afx_msg void OnBnClickedButtonRefresh();
	afx_msg void OnBnClickedButtonPlay();
	DECLARE_MESSAGE_MAP()

	CButton m_ckEnable;
	CEdit m_edRemainCount;
	CEdit m_edReceiveCount;
};
