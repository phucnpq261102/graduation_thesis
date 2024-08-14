#pragma once
#include "afxwin.h"


// CPopupCaptureDlg 대화 상자입니다.

class CPopupCaptureDlg : public CPopupBaseDialog
{
	DECLARE_DYNAMIC(CPopupCaptureDlg)

public:
	CPopupCaptureDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis);   // 표준 생성자입니다.
	virtual ~CPopupCaptureDlg();

// 대화 상자 데이터입니다.
	enum { IDD = IDD_POPUP_CAPTURE };

	virtual void InitControls();

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 지원입니다.
	
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
