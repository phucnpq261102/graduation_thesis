#pragma once


// CPopupAutoFocusDlg ��ȭ �����Դϴ�.

class CPopupAutoFocusDlg : public CPopupBaseDialog
{
	DECLARE_DYNAMIC(CPopupAutoFocusDlg)

public:
	CPopupAutoFocusDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis);   // ǥ�� �������Դϴ�.
	virtual ~CPopupAutoFocusDlg();

// ��ȭ ���� �������Դϴ�.
	enum { IDD = IDD_POPUP_AUTOFOCUS };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV �����Դϴ�.

	afx_msg void OnBnClickedButtonOriginPoint();
	afx_msg void OnBnClickedButtonOnePushAuto();
	afx_msg void OnBnClickedButtonOneSetupForward();
	afx_msg void OnBnClickedButtonOneStepBackward();
	DECLARE_MESSAGE_MAP()
};
