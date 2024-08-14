#pragma once
#include "afxwin.h"
#include "afxcmn.h"

#define MAX_ARRAY_COUNT		24

// CPopupFeatureDlg 대화 상자입니다.

class CPopupFeatureDlg : public CPopupBaseDialog
{
	DECLARE_DYNAMIC(CPopupFeatureDlg)

public:
	CPopupFeatureDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis);   // 표준 생성자입니다.
	virtual ~CPopupFeatureDlg();

// 대화 상자 데이터입니다.
	enum { IDD = IDD_POPUP_FEATURE };

	virtual void UpdateDialog();

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 지원입니다.
	virtual BOOL PreTranslateMessage(MSG* pMsg);

	afx_msg void OnBnClickedCheckMode0();
	afx_msg void OnBnClickedCheckMode1();
	afx_msg void OnBnClickedCheckMode2();
	afx_msg void OnBnClickedCheckMode3();
	afx_msg void OnBnClickedCheckMode4();
	afx_msg void OnBnClickedCheckMode5();
	afx_msg void OnBnClickedCheckMode6();
	afx_msg void OnBnClickedCheckMode7();
	afx_msg void OnBnClickedCheckMode8();
	afx_msg void OnBnClickedCheckMode9();
	afx_msg void OnBnClickedCheckMode10();
	afx_msg void OnBnClickedCheckMode11();
	afx_msg void OnBnClickedCheckMode12();
	afx_msg void OnBnClickedCheckMode13();
	afx_msg void OnBnClickedCheckMode14();
	afx_msg void OnBnClickedCheckMode15();
	afx_msg void OnBnClickedCheckMode16();
	afx_msg void OnBnClickedCheckMode17();
	afx_msg void OnBnClickedCheckMode18();
	afx_msg void OnBnClickedCheckMode19();
	afx_msg void OnBnClickedCheckMode20();
	afx_msg void OnBnClickedCheckMode21();
	afx_msg void OnBnClickedCheckMode22();
	afx_msg void OnBnClickedCheckMode23();
	afx_msg void OnNMReleasedcaptureSliderValue0(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnNMReleasedcaptureSliderValue1(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnNMReleasedcaptureSliderValue2(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnNMReleasedcaptureSliderValue3(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnNMReleasedcaptureSliderValue4(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnNMReleasedcaptureSliderValue5(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnNMReleasedcaptureSliderValue6(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnNMReleasedcaptureSliderValue7(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnNMReleasedcaptureSliderValue8(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnNMReleasedcaptureSliderValue9(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnNMReleasedcaptureSliderValue10(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnNMReleasedcaptureSliderValue11(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnNMReleasedcaptureSliderValue12(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnNMReleasedcaptureSliderValue13(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnNMReleasedcaptureSliderValue14(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnNMReleasedcaptureSliderValue15(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnNMReleasedcaptureSliderValue16(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnNMReleasedcaptureSliderValue17(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnNMReleasedcaptureSliderValue18(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnNMReleasedcaptureSliderValue19(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnNMReleasedcaptureSliderValue20(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnNMReleasedcaptureSliderValue21(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnNMReleasedcaptureSliderValue22(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnNMReleasedcaptureSliderValue23(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnCbnSelchangeComboWhiteBalance();
	afx_msg void OnBnClickedButtonDefualt();
	DECLARE_MESSAGE_MAP()

	void OnCheckBoxClicked(int nIndex);
	void OnSliderBarClicked(int nIndex);
	void OnEditBoxKeyDown(int nIndex, BOOL bEnter);

	static ENeptuneFeature m_arrMapping[MAX_ARRAY_COUNT];
	NEPTUNE_FEATURE m_arrFeatureInfo[MAX_ARRAY_COUNT];
	CButton m_ckAutoMode[MAX_ARRAY_COUNT];
	CSliderCtrl m_sdValue[MAX_ARRAY_COUNT];
	CEdit m_edValue[MAX_ARRAY_COUNT];
	CStatic m_stcRange[MAX_ARRAY_COUNT];
	CComboBox m_cbWhiteBalance;
};
