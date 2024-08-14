#pragma once


// CPopupAutoFocusDlg 대화 상자입니다.

class CPopupAutoFocusDlg : public CPopupBaseDialog
{
	DECLARE_DYNAMIC(CPopupAutoFocusDlg)

public:
	CPopupAutoFocusDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis);   // 표준 생성자입니다.
	virtual ~CPopupAutoFocusDlg();

// 대화 상자 데이터입니다.
	enum { IDD = IDD_POPUP_AUTOFOCUS };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 지원입니다.

	afx_msg void OnBnClickedButtonOriginPoint();
	afx_msg void OnBnClickedButtonOnePushAuto();
	afx_msg void OnBnClickedButtonOneSetupForward();
	afx_msg void OnBnClickedButtonOneStepBackward();
	DECLARE_MESSAGE_MAP()
};
