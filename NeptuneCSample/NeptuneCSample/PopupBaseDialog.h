#pragma once

class CPopupBaseDialog : public CDialogEx
{
	DECLARE_DYNAMIC(CPopupBaseDialog)

public:
	CPopupBaseDialog(UINT ulIDTemplate, NeptuneCamHandle& pCameraHandle, CWnd** ppThis);
	virtual ~CPopupBaseDialog();

	virtual void InitControls() {}
	virtual void UpdateDialog() {}

protected:
	virtual void DoDataExchange(CDataExchange* pDX);
	virtual BOOL PreTranslateMessage(MSG* pMsg);
	virtual BOOL OnInitDialog();
	virtual void OnOK();
	virtual void OnCancel();

	afx_msg void OnNcDestroy();
	afx_msg void OnClose();
	DECLARE_MESSAGE_MAP()

	void InsertLog(EM_LOG_LEVEL emLevel, CString strMessage, ENeptuneError emErr = NEPTUNE_ERR_Success);
	void UpdateCameraInfo();
	void UpdatePopupDialogs();

	NeptuneCamHandle& m_pCameraHandle;
	CWnd** m_ppThis;
};
