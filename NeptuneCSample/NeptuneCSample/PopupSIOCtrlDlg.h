#pragma once
#include "afxwin.h"


// CPopupSIOCtrlDlg ��ȭ �����Դϴ�.

class CPopupSIOCtrlDlg : public CPopupBaseDialog
{
	DECLARE_DYNAMIC(CPopupSIOCtrlDlg)

public:
	CPopupSIOCtrlDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis);   // ǥ�� �������Դϴ�.
	virtual ~CPopupSIOCtrlDlg();

// ��ȭ ���� �������Դϴ�.
	enum { IDD = IDD_POPUP_SIOCONTROL };

	virtual void InitControls();

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV �����Դϴ�.

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
