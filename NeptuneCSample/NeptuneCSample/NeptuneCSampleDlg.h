
// NeptuneCSampleDlg.h : 헤더 파일
//

#pragma once
#include "PopupFeatureDlg.h"
#include "PopupCaptureDlg.h"
#include "PopupGrabDlg.h"
#include "PopupResolutionDlg.h"
#include "PopupTriggerDlg.h"
#include "PopupStrobeDlg.h"
#include "PopupAutoFocusDlg.h"
#include "PopupUserSetDlg.h"
#include "PopupSIOCtrlDlg.h"
#include "PopupLUTDlg.h"
#include "PopupFrameSaveDlg.h"
#include "PopupThermalDlg.h"
#include "PopupAltLedDlg.h"
#include "PopupStackedROIDlg.h"

#define TIMER_FPS_CHECK				100
#define TIMER_FRAME_COUNT			101

#define UM_UPDATE_POPUP_DIALOG		WM_USER+1

class CNeptuneCSampleDlg : public CDialogEx
{
public:
	CNeptuneCSampleDlg(CWnd* pParent = NULL);

	enum { IDD = IDD_NEPTUNECSAMPLE_DIALOG };

	void InsertLog(EM_LOG_LEVEL emLevel, CString strMessage, ENeptuneError emErr = NEPTUNE_ERR_Success);
	void UpdateCameraInfo();

	afx_msg LRESULT UpdatePopupDialogs(WPARAM wParam, LPARAM lParam);

protected:
	HICON m_hIcon;

	virtual BOOL PreTranslateMessage(MSG* pMsg);
	virtual void DoDataExchange(CDataExchange* pDX);
	virtual BOOL OnInitDialog();

	afx_msg void OnDestroy();
	afx_msg void OnTimer(UINT_PTR nIDEvent);
	afx_msg void OnCbnSelchangeComboCameraList();
	afx_msg void OnBnClickedButtonListRefresh();
	afx_msg void OnCbnSelchangeComboPixelFormat();
	afx_msg void OnCbnSelchangeComboBayerConvert();
	afx_msg void OnCbnSelchangeComboBayerLayout();
	afx_msg void OnBnClickedCheckFit();
	afx_msg void OnBnClickedCheckFlip();
	afx_msg void OnBnClickedCheckMirror();
	afx_msg void OnBnClickedButtonFpsApply();
	afx_msg void OnBnClickedButtonStart();
	afx_msg void OnBnClickedButtonStop();
	afx_msg void OnCbnSelchangeComboAcquisitionMode();
	afx_msg void OnBnClickedButtonShot();
	afx_msg void OnBnClickedCheckAutoScroll();
	afx_msg void OnBnClickedButtonStatusClear();
	afx_msg void OnBnClickedButtonControl();
	afx_msg void OnBnClickedButtonFeatrueDlg();
	afx_msg void OnBnClickedButtonCaptureDlg();
	afx_msg void OnBnClickedButtonGrabDlg();
	afx_msg void OnBnClickedButtonResolutionDlg();
	afx_msg void OnBnClickedButtonTriggerDlg();
	afx_msg void OnBnClickedButtonStrobeDlg();
	afx_msg void OnBnClickedButtonAutoFocusDlg();
	afx_msg void OnBnClickedButtonUserSetDlg();
	afx_msg void OnBnClickedButtonSioControlDlg();
	afx_msg void OnBnClickedButtonLookUpTableDlg();
	afx_msg void OnBnClickedButton1394FramesaveDlg();
	afx_msg void OnBnClickedButtonThermalDlg();
	afx_msg void OnBnClickedButtonAltLedDlg();
	DECLARE_MESSAGE_MAP()

	static void CALLBACK DeviceCheckCallback(ENeptuneDeviceChangeState emState, void* pContext);
	static void CALLBACK DeviceUnplugCallback(void* pContext);
	static void CALLBACK FrameCallback(PNEPTUNE_IMAGE pImage, void* pContext);

	BOOL IsFrameRateSupported();
	LONG GetMultiShotCount();

	void DeleteCameraList();
	void DeleteCameraHandle();
	
	void InitFixedItemList();
	void InitCameraList();
	void InitPixelFormatList();
	void InitBayerMethodList();
	void InitBayerLayoutList();
	void InitEffectState();
	void InitFrameRateList();
	void InitAcquisitionMode();

	void UpdateControlActivate();

	NeptuneCamHandle		m_pCameraHandle;

	CStatic					m_stcDisplayWnd;
	CComboBox				m_cbCameraList;
	CButton					m_btnRefresh;
	CComboBox				m_cbPixelFormat;
	CComboBox				m_cbBayerConvert;
	CComboBox				m_cbBayerLayout;
	CButton					m_ckFit;
	CButton					m_ckFlip;
	CButton					m_ckMirror;

	CStatic					m_stcReceiveFps;
	CStatic					m_stcReceiveFrame;
	CComboBox				m_cb1394FPS;
	CEdit					m_edFPS;
	CButton					m_btnFpsApply;

	CButton					m_btnAcqStart;
	CButton					m_btnAcqStop;
	CComboBox				m_cbAcqMode;
	CEdit					m_edMultiShotCnt;
	CButton					m_btnShot;
	
	CListCtrl				m_listLog;
	CButton					m_ckAutoScroll;
	CButton					m_btnClearList;

	CButton					m_btnControl;
	CButton					m_btnFeature;
	CButton					m_btnCapture;
	CButton					m_btnGrab;
	CButton					m_btnResolution;
	CButton					m_btnTrigger;
	CButton					m_btnStrobe;
	CButton					m_btnAutoFocus;
	CButton					m_btnUserSet;
	CButton					m_btnSIOControl;
	CButton					m_btnLUT;
	CButton					m_btnFrameSave;
	CButton					m_btnThermal;
	CButton					m_btnAltLed;
	CButton					m_btnStackedROI;

	BOOL					m_bFrameRateSupport;
	unsigned __int64		m_uiTotalFrameCount;

	CBitmap					m_bmpRefresh;

	CPopupFeatureDlg*		m_pFeatureDlg;
	CPopupCaptureDlg*		m_pCaptureDlg;
	CPopupGrabDlg*			m_pGrabDlg;
	CPopupResolutionDlg*	m_pResolutionDlg;
	CPopupTriggerDlg*		m_pTriggerDlg;
	CPopupStrobeDlg*		m_pStrobeDlg;
	CPopupAutoFocusDlg*		m_pAutoFocusDlg;
	CPopupUserSetDlg*		m_pUserSetDlg;
	CPopupSIOCtrlDlg*		m_pSIOCtrlDlg;
	CPopupLUTDlg*			m_pLUTDlg;
	CPopupFrameSaveDlg*		m_pFrameSaveDlg;
	CPopupThermalDlg*		m_pThermalDlg;
	CPopupAltLedDlg*		m_pAltLedDlg;
	CPopupStackedROIDlg*	m_pStackedROIDlg;
public:
	afx_msg void OnBnClickedButtonStackedRoiDlg();
};
