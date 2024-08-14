#pragma once
#include "afxwin.h"


// CPopupCaptureDlg ��ȭ �����Դϴ�.

class CPopupCaptureDlg : public CPopupBaseDialog
{
	DECLARE_DYNAMIC(CPopupCaptureDlg)

public:
	CPopupCaptureDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis);   // ǥ�� �������Դϴ�.
	virtual ~CPopupCaptureDlg();

// ��ȭ ���� �������Դϴ�.
	enum { IDD = IDD_POPUP_CAPTURE };

	virtual void InitControls();

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV �����Դϴ�.
	
	afx_msg void OnCbnSelchangeComboSaveFormat();
	afx_msg void OnBnClickedButtonCapture();
	afx_msg void OnBnClickedButtonRecStrat();
	afx_msg void OnBnClickedButtonRecStop();
	DECLARE_MESSAGE_MAP()

	CMFCEditBrowseCtrl m_edSavePath;
	CComboBox m_cbImageForamt;
	CButton m_btnSaveImage;
	CButton m_btnStartRecord;
	CButton m_btnStopRecord;

	BOOL m_bRecording;
};
