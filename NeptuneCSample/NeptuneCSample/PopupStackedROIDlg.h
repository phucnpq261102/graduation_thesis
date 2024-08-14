#pragma once
#include "afxwin.h"


// CPopupStackedROIDlg 대화 상자입니다.

class CPopupStackedROIDlg : public CPopupBaseDialog
{
	DECLARE_DYNAMIC(CPopupStackedROIDlg)

public:
	CPopupStackedROIDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis);   // 표준 생성자입니다.
	virtual ~CPopupStackedROIDlg();

// 대화 상자 데이터입니다.
	enum { IDD = IDD_POPUP_STACKED_ROI };

	virtual void InitControls();
	virtual void UpdateDialog();

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 지원입니다.

	DECLARE_MESSAGE_MAP()

	CButton m_btnControl;
	CComboBox m_cbIndex;
	CButton m_btnEnable;
	CEdit m_edOffsetX;
	CEdit m_edOffsetY;
	CEdit m_edWidth;
	CEdit m_edHeight;
	afx_msg void OnBnClickedCheckControl();
	afx_msg void OnCbnSelchangeComboSelector();

	void GetStackedROIControl();
	void GetStackedROIOffsetX();
	void GetStackedROIWidth();
	void GetSelectedStackedROI();
	void GetSelectedStackedROIInfo();
	
public:
	CEdit m_edAllOffsetX;
	CEdit m_edAllWidth;
	afx_msg void OnBnClickedButtonSetAllOffsetX();
	afx_msg void OnBnClickedButtonSetAllWidth();
	afx_msg void OnBnClickedButtonApply();
};
