#pragma once
#include "LutWnd.h"
#include "afxwin.h"


#define MAX_POINT_COUNT		4

// CPopupLUTDlg ��ȭ �����Դϴ�.

class CPopupLUTDlg : public CPopupBaseDialog
{
	DECLARE_DYNAMIC(CPopupLUTDlg)

public:
	CPopupLUTDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis);   // ǥ�� �������Դϴ�.
	virtual ~CPopupLUTDlg();

// ��ȭ ���� �������Դϴ�.
	enum { IDD = IDD_POPUP_LUT };

	virtual void InitControls();
	virtual void UpdateDialog();

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV �����Դϴ�.
	virtual BOOL PreTranslateMessage(MSG* pMsg);

	afx_msg void OnBnClickedButtonSetToLinear();
	afx_msg void OnBnClickedButton4stepApply();
	afx_msg void OnBnClickedButtonSavedataInIndex();
	afx_msg void OnBnClickedButtonUserApply();
	DECLARE_MESSAGE_MAP()

	const CSize m_sizeMaxLut;
	CLutWnd m_wndLut;

	CStatic m_wndGraph;
	BOOL m_b4StepLUTEnable;
	LONG m_nlPointX[MAX_POINT_COUNT];
	LONG m_nlPointY[MAX_POINT_COUNT];
	CEdit m_edPointX[MAX_POINT_COUNT];
	CEdit m_edPointY[MAX_POINT_COUNT];
	BOOL m_bUserLUTEnable;
	CComboBox m_cbUserLUTIndex;
};
