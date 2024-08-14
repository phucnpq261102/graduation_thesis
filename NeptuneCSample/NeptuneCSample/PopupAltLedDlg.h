#pragma once
#include "TableListCtrl.h"


// CPopupAltLedDlg 대화 상자입니다.

class CPopupAltLedDlg : public CPopupBaseDialog
{
	DECLARE_DYNAMIC(CPopupAltLedDlg)

public:
	CPopupAltLedDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis);
	virtual ~CPopupAltLedDlg();

// 대화 상자 데이터입니다.
	enum { IDD = IDD_POPUP_ALTLED };

	virtual void UpdateDialog();

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 지원입니다.

	DECLARE_MESSAGE_MAP()
protected:
	CButton m_btnIndex;
	CButton m_btnDirect;
	CButton m_btnAutoRun;
	CEdit m_edStartIndex;
	CTableListCtrl m_wndTable;

	int m_nTableItemCnt;
	int m_nTableSubItemCnt;
	RANGE_LONG m_rangeValue;
public:
	virtual BOOL OnInitDialog();
	afx_msg void OnBnClickedButtonSet();
	afx_msg void OnBnClickedButtonUpdate();
	afx_msg void OnBnClickedButtonZeroFill();
	afx_msg void OnBnClickedButtonSampleFill();
	afx_msg void OnLvnItemchangedListTable(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnBnClickedRadioIndex();
	afx_msg void OnBnClickedRadioDirect();
};
