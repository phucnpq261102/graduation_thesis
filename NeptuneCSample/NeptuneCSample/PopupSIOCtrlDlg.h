#pragma once
#include "afxwin.h"


// CPopupSIOCtrlDlg 대화 상자입니다.

class CPopupSIOCtrlDlg : public CPopupBaseDialog
{
	DECLARE_DYNAMIC(CPopupSIOCtrlDlg)

public:
	CPopupSIOCtrlDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis);   // 표준 생성자입니다.
	virtual ~CPopupSIOCtrlDlg();

// 대화 상자 데이터입니다.
	enum { IDD = IDD_POPUP_SIOCONTROL };

	virtual void InitControls();

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 지원입니다.

	afx_msg void OnBnClickedButtonApply();
	afx_msg void OnBnClickedButtonSendData();
	afx_msg void OnBnClickedButtonReceiveData();
	DECLARE_MESSAGE_MAP()

	CButton m_ckEnable;
	CComboBox m_cbBaudRate;
	CComboBox m_cbParityBits;
	CComboBox m_cbDataBits;
	CComboBox m_cbStopBits;
	CEdit m_edData;
};
