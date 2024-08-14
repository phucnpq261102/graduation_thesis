
// NeptuneCSampleDlg.cpp : 구현 파일
//

#include "stdafx.h"
#include "NeptuneCSample.h"
#include "NeptuneCSampleDlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CNeptuneCSampleDlg 대화 상자

CNeptuneCSampleDlg::CNeptuneCSampleDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(CNeptuneCSampleDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);

	m_pCameraHandle			= NULL;

	m_bFrameRateSupport		= TRUE;
	m_uiTotalFrameCount		= 0;

	m_pFeatureDlg			= NULL;
	m_pCaptureDlg			= NULL;
	m_pGrabDlg				= NULL;
	m_pResolutionDlg		= NULL;
	m_pTriggerDlg			= NULL;
	m_pStrobeDlg			= NULL;
	m_pAutoFocusDlg			= NULL;
	m_pUserSetDlg			= NULL;
	m_pSIOCtrlDlg			= NULL;
	m_pLUTDlg				= NULL;
	m_pFrameSaveDlg			= NULL;
	m_pThermalDlg			= NULL;
	m_pAltLedDlg			= NULL;
	m_pStackedROIDlg		= NULL;
}

void CNeptuneCSampleDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_PICTURE_DISPLAY, m_stcDisplayWnd);
	DDX_Control(pDX, IDC_COMBO_CAMERA_LIST, m_cbCameraList);
	DDX_Control(pDX, IDC_BUTTON_LIST_REFRESH, m_btnRefresh);
	DDX_Control(pDX, IDC_COMBO_PIXEL_FORMAT, m_cbPixelFormat);
	DDX_Control(pDX, IDC_COMBO_BAYER_CONVERT, m_cbBayerConvert);
	DDX_Control(pDX, IDC_COMBO_BAYER_LAYOUT, m_cbBayerLayout);
	DDX_Control(pDX, IDC_CHECK_FIT, m_ckFit);
	DDX_Control(pDX, IDC_CHECK_FLIP, m_ckFlip);
	DDX_Control(pDX, IDC_CHECK_MIRROR, m_ckMirror);
	DDX_Control(pDX, IDC_STATIC_RECV_FPS, m_stcReceiveFps);
	DDX_Control(pDX, IDC_STATIC_TOTAL_FRAME, m_stcReceiveFrame);
	DDX_Control(pDX, IDC_COMBO_1394_FPS, m_cb1394FPS);
	DDX_Control(pDX, IDC_EDIT_GU_FPS, m_edFPS);
	DDX_Control(pDX, IDC_BUTTON_FPS_APPLY, m_btnFpsApply);
	DDX_Control(pDX, IDC_BUTTON_START, m_btnAcqStart);
	DDX_Control(pDX, IDC_BUTTON_STOP, m_btnAcqStop);
	DDX_Control(pDX, IDC_COMBO_ACQUISITION_MODE, m_cbAcqMode);
	DDX_Control(pDX, IDC_EDIT_SHOT_COUNT, m_edMultiShotCnt);
	DDX_Control(pDX, IDC_BUTTON_SHOT, m_btnShot);
	DDX_Control(pDX, IDC_LIST_LOG, m_listLog);
	DDX_Control(pDX, IDC_CHECK_AUTO_SCROLL, m_ckAutoScroll);
	DDX_Control(pDX, IDC_BUTTON_STATUS_CLEAR, m_btnClearList);
	DDX_Control(pDX, IDC_BUTTON_CONTROL, m_btnControl);
	DDX_Control(pDX, IDC_BUTTON_FEATRUE_DLG, m_btnFeature);
	DDX_Control(pDX, IDC_BUTTON_CAPTURE_DLG, m_btnCapture);
	DDX_Control(pDX, IDC_BUTTON_GRAB_DLG, m_btnGrab);
	DDX_Control(pDX, IDC_BUTTON_RESOLUTION_DLG, m_btnResolution);
	DDX_Control(pDX, IDC_BUTTON_TRIGGER_DLG, m_btnTrigger);
	DDX_Control(pDX, IDC_BUTTON_STROBE_DLG, m_btnStrobe);
	DDX_Control(pDX, IDC_BUTTON_AUTO_FOCUS_DLG, m_btnAutoFocus);
	DDX_Control(pDX, IDC_BUTTON_USER_SET_DLG, m_btnUserSet);
	DDX_Control(pDX, IDC_BUTTON_SIO_CONTROL_DLG, m_btnSIOControl);
	DDX_Control(pDX, IDC_BUTTON_LOOK_UP_TABLE_DLG, m_btnLUT);
	DDX_Control(pDX, IDC_BUTTON_1394_FRAMESAVE_DLG, m_btnFrameSave);
	DDX_Control(pDX, IDC_BUTTON_THERMAL_DLG, m_btnThermal);
	DDX_Control(pDX, IDC_BUTTON_ALT_LED_DLG, m_btnAltLed);
	DDX_Control(pDX, IDC_BUTTON_STACKED_ROI_DLG, m_btnStackedROI);
}

BEGIN_MESSAGE_MAP(CNeptuneCSampleDlg, CDialogEx)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_WM_DESTROY()
	ON_WM_TIMER()
	ON_CBN_SELCHANGE(IDC_COMBO_CAMERA_LIST, &CNeptuneCSampleDlg::OnCbnSelchangeComboCameraList)
	ON_BN_CLICKED(IDC_BUTTON_LIST_REFRESH, &CNeptuneCSampleDlg::OnBnClickedButtonListRefresh)
	ON_CBN_SELCHANGE(IDC_COMBO_PIXEL_FORMAT, &CNeptuneCSampleDlg::OnCbnSelchangeComboPixelFormat)
	ON_CBN_SELCHANGE(IDC_COMBO_BAYER_CONVERT, &CNeptuneCSampleDlg::OnCbnSelchangeComboBayerConvert)
	ON_CBN_SELCHANGE(IDC_COMBO_BAYER_LAYOUT, &CNeptuneCSampleDlg::OnCbnSelchangeComboBayerLayout)
	ON_BN_CLICKED(IDC_CHECK_FIT, &CNeptuneCSampleDlg::OnBnClickedCheckFit)
	ON_BN_CLICKED(IDC_CHECK_FLIP, &CNeptuneCSampleDlg::OnBnClickedCheckFlip)
	ON_BN_CLICKED(IDC_CHECK_MIRROR, &CNeptuneCSampleDlg::OnBnClickedCheckMirror)
	ON_BN_CLICKED(IDC_BUTTON_FPS_APPLY, &CNeptuneCSampleDlg::OnBnClickedButtonFpsApply)
	ON_BN_CLICKED(IDC_BUTTON_START, &CNeptuneCSampleDlg::OnBnClickedButtonStart)
	ON_BN_CLICKED(IDC_BUTTON_STOP, &CNeptuneCSampleDlg::OnBnClickedButtonStop)
	ON_CBN_SELCHANGE(IDC_COMBO_ACQUISITION_MODE, &CNeptuneCSampleDlg::OnCbnSelchangeComboAcquisitionMode)
	ON_BN_CLICKED(IDC_BUTTON_SHOT, &CNeptuneCSampleDlg::OnBnClickedButtonShot)
	ON_BN_CLICKED(IDC_CHECK_AUTO_SCROLL, &CNeptuneCSampleDlg::OnBnClickedCheckAutoScroll)
	ON_BN_CLICKED(IDC_BUTTON_STATUS_CLEAR, &CNeptuneCSampleDlg::OnBnClickedButtonStatusClear)
	ON_BN_CLICKED(IDC_BUTTON_CONTROL, &CNeptuneCSampleDlg::OnBnClickedButtonControl)
	ON_BN_CLICKED(IDC_BUTTON_FEATRUE_DLG, &CNeptuneCSampleDlg::OnBnClickedButtonFeatrueDlg)
	ON_BN_CLICKED(IDC_BUTTON_CAPTURE_DLG, &CNeptuneCSampleDlg::OnBnClickedButtonCaptureDlg)
	ON_BN_CLICKED(IDC_BUTTON_GRAB_DLG, &CNeptuneCSampleDlg::OnBnClickedButtonGrabDlg)
	ON_BN_CLICKED(IDC_BUTTON_RESOLUTION_DLG, &CNeptuneCSampleDlg::OnBnClickedButtonResolutionDlg)
	ON_BN_CLICKED(IDC_BUTTON_TRIGGER_DLG, &CNeptuneCSampleDlg::OnBnClickedButtonTriggerDlg)
	ON_BN_CLICKED(IDC_BUTTON_STROBE_DLG, &CNeptuneCSampleDlg::OnBnClickedButtonStrobeDlg)
	ON_BN_CLICKED(IDC_BUTTON_AUTO_FOCUS_DLG, &CNeptuneCSampleDlg::OnBnClickedButtonAutoFocusDlg)
	ON_BN_CLICKED(IDC_BUTTON_USER_SET_DLG, &CNeptuneCSampleDlg::OnBnClickedButtonUserSetDlg)
	ON_BN_CLICKED(IDC_BUTTON_SIO_CONTROL_DLG, &CNeptuneCSampleDlg::OnBnClickedButtonSioControlDlg)
	ON_BN_CLICKED(IDC_BUTTON_LOOK_UP_TABLE_DLG, &CNeptuneCSampleDlg::OnBnClickedButtonLookUpTableDlg)
	ON_BN_CLICKED(IDC_BUTTON_1394_FRAMESAVE_DLG, &CNeptuneCSampleDlg::OnBnClickedButton1394FramesaveDlg)
	ON_BN_CLICKED(IDC_BUTTON_THERMAL_DLG, &CNeptuneCSampleDlg::OnBnClickedButtonThermalDlg)
	ON_BN_CLICKED(IDC_BUTTON_ALT_LED_DLG, &CNeptuneCSampleDlg::OnBnClickedButtonAltLedDlg)
	ON_MESSAGE(UM_UPDATE_POPUP_DIALOG, &CNeptuneCSampleDlg::UpdatePopupDialogs)
	ON_BN_CLICKED(IDC_BUTTON_STACKED_ROI_DLG, &CNeptuneCSampleDlg::OnBnClickedButtonStackedRoiDlg)
END_MESSAGE_MAP()


BOOL CNeptuneCSampleDlg::PreTranslateMessage(MSG* pMsg)
{
	if (pMsg->message == WM_KEYDOWN)
	{
		if (pMsg->wParam == VK_RETURN)
		{
			if (pMsg->hwnd == m_edMultiShotCnt.GetSafeHwnd())
			{
				LONG nlValue = GetMultiShotCount();
				if (m_pCameraHandle)
				{
					ENeptuneError emErr = ntcSetAcquisitionMode(m_pCameraHandle, NEPTUNE_ACQ_MULTIFRAME, (_uint32_t)nlValue);
					if (emErr != NEPTUNE_ERR_Success)
					{
						InsertLog(TYPE_ERROR, _T("ntcSetAcquisitionMode Failed"), emErr);
					}
				}
			}
			return TRUE;
		}
		else if (pMsg->wParam == VK_ESCAPE)
		{
			return TRUE;
		}
	}
	return CDialogEx::PreTranslateMessage(pMsg);
}

BOOL CNeptuneCSampleDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	SetIcon(m_hIcon, TRUE);
	SetIcon(m_hIcon, FALSE);

	ntcInit();

	InitFixedItemList();
	InitCameraList();
	UpdateControlActivate();

	ntcSetDeviceCheckCallback(DeviceCheckCallback, this);

	return TRUE;
}

void CNeptuneCSampleDlg::OnDestroy()
{
	DeleteCameraList();
	DeleteCameraHandle();
	UpdatePopupDialogs((WPARAM)TRUE, NULL);
	ntcUninit();
	CDialogEx::OnDestroy();
}

void CALLBACK CNeptuneCSampleDlg::DeviceCheckCallback(ENeptuneDeviceChangeState emState, void* pContext)
{
	CNeptuneCSampleDlg* pDlg = (CNeptuneCSampleDlg*)pContext;
	if (pDlg)
	{
		pDlg->InitCameraList();
		pDlg->InsertLog(TYPE_EVENT, (emState == NEPTUNE_DEVICE_ADDED) ? _T("Device has been added.") : _T("Device has been removed."));
	}
}

void CALLBACK CNeptuneCSampleDlg::DeviceUnplugCallback(void* pContext)
{
	CNeptuneCSampleDlg* pDlg = (CNeptuneCSampleDlg*)pContext;
	if (pDlg)
	{
		pDlg->InitCameraList();
		pDlg->InsertLog(TYPE_EVENT, _T("Selected camera was unplugged."));
	}
}

void CALLBACK CNeptuneCSampleDlg::FrameCallback(PNEPTUNE_IMAGE pImage, void* pContext)
{
	CNeptuneCSampleDlg* pDlg = (CNeptuneCSampleDlg*)pContext;
	if (pDlg)
	{
		pDlg->m_uiTotalFrameCount++;
	}
}

void CNeptuneCSampleDlg::DeleteCameraList()
{
	for (int i = 0; i < m_cbCameraList.GetCount(); i++)
	{
		PNEPTUNE_CAM_INFO pCameraInfo = (PNEPTUNE_CAM_INFO)m_cbCameraList.GetItemData(i);
		if (pCameraInfo)
		{
			delete pCameraInfo;
			pCameraInfo = NULL;
		}
	}
	m_cbCameraList.ResetContent();
}

void CNeptuneCSampleDlg::DeleteCameraHandle()
{
	if (m_pCameraHandle)
	{	
		ntcClose(m_pCameraHandle);
		m_pCameraHandle = NULL;
	}
}

void CNeptuneCSampleDlg::InitFixedItemList()
{
	m_bmpRefresh.LoadBitmap(IDB_REFRESH);
	m_btnRefresh.SetBitmap(m_bmpRefresh);

	m_cbBayerConvert.ResetContent();
	int nItem = m_cbBayerConvert.AddString(_T("NONE"));
	m_cbBayerConvert.SetItemData(nItem, (DWORD_PTR)NEPTUNE_BAYER_METHOD_NONE);
	nItem = m_cbBayerConvert.AddString(_T("BILINEAR"));
	m_cbBayerConvert.SetItemData(nItem, (DWORD_PTR)NEPTUNE_BAYER_METHOD_BILINEAR);
	nItem = m_cbBayerConvert.AddString(_T("HQ"));
	m_cbBayerConvert.SetItemData(nItem, (DWORD_PTR)NEPTUNE_BAYER_METHOD_HQ);
	nItem = m_cbBayerConvert.AddString(_T("NEAREST"));
	m_cbBayerConvert.SetItemData(nItem, (DWORD_PTR)NEPTUNE_BAYER_METHOD_NEAREST);

	m_cbBayerLayout.ResetContent();
	nItem = m_cbBayerLayout.AddString(_T("GB/RG"));
	m_cbBayerLayout.SetItemData(nItem, (DWORD_PTR)NEPTUNE_BAYER_GB_RG);
	nItem = m_cbBayerLayout.AddString(_T("BG/GR"));
	m_cbBayerLayout.SetItemData(nItem, (DWORD_PTR)NEPTUNE_BAYER_BG_GR);
	nItem = m_cbBayerLayout.AddString(_T("RG/GB"));
	m_cbBayerLayout.SetItemData(nItem, (DWORD_PTR)NEPTUNE_BAYER_RG_GB);
	nItem = m_cbBayerLayout.AddString(_T("GR/BG"));
	m_cbBayerLayout.SetItemData(nItem, (DWORD_PTR)NEPTUNE_BAYER_GR_BG);

	m_cbAcqMode.ResetContent();
	nItem = m_cbAcqMode.AddString(_T("Continuous"));
	m_cbAcqMode.SetItemData(nItem, (DWORD_PTR)NEPTUNE_ACQ_CONTINUOUS);
	nItem = m_cbAcqMode.AddString(_T("One-Shot"));
	m_cbAcqMode.SetItemData(nItem, (DWORD_PTR)NEPTUNE_ACQ_SINGLEFRAME);
	nItem = m_cbAcqMode.AddString(_T("Multi-Shot"));
	m_cbAcqMode.SetItemData(nItem, (DWORD_PTR)NEPTUNE_ACQ_MULTIFRAME);

	m_listLog.SetExtendedStyle(LVS_EX_FULLROWSELECT | LVS_EX_GRIDLINES);
	m_listLog.InsertColumn(0, _T("Time"), LVCFMT_LEFT, 160);
	m_listLog.InsertColumn(1, _T("Type"), LVCFMT_LEFT, 80);
	m_listLog.InsertColumn(2, _T("Message"), LVCFMT_LEFT, 380);
	m_listLog.InsertColumn(3, _T("Return"), LVCFMT_LEFT, 50);
}

void CNeptuneCSampleDlg::InitCameraList()
{
	PNEPTUNE_CAM_INFO pPrevInfo = NULL;
	int nItem = m_cbCameraList.GetCurSel();
	if (nItem != CB_ERR)
	{
		PNEPTUNE_CAM_INFO pInfo = (PNEPTUNE_CAM_INFO)m_cbCameraList.GetItemData(nItem);
		if (pInfo)
		{
			pPrevInfo = new NEPTUNE_CAM_INFO;
			if (pPrevInfo)
			{
				memcpy(pPrevInfo, pInfo, sizeof(NEPTUNE_CAM_INFO));
			}
		}
	}

	DeleteCameraList();

	_uint32_t uiCount = 0;
	if (ntcGetCameraCount(&uiCount) == NEPTUNE_ERR_Success)
	{
		if (uiCount > 0)
		{
			PNEPTUNE_CAM_INFO pCameraInfo = new NEPTUNE_CAM_INFO[uiCount];
			if (pCameraInfo)
			{
				ZeroMemory(pCameraInfo, sizeof(NEPTUNE_CAM_INFO) * uiCount);
				ENeptuneError emErr = ntcGetCameraInfo(pCameraInfo, uiCount);
				if (emErr == NEPTUNE_ERR_Success)
				{
					for (_uint32_t i = 0; i < uiCount; i++)
					{
						PNEPTUNE_CAM_INFO pSetData = new NEPTUNE_CAM_INFO;
						if (pSetData)
						{
							memcpy(pSetData, &pCameraInfo[i], sizeof(NEPTUNE_CAM_INFO));

							USES_CONVERSION;
							CString strLabel = _T("");
							strLabel.Format(_T("%s: [%s] %s"), A2T(pSetData->strVendor), A2T(pSetData->strSerial), A2T(pSetData->strModel));
							int nIndex = m_cbCameraList.InsertString(m_cbCameraList.GetCount(), strLabel);
							m_cbCameraList.SetItemData(nIndex, (DWORD_PTR)pSetData);
							if (pPrevInfo)
							{
								if (strcmp(pSetData->strSerial, pPrevInfo->strSerial) == 0)
								{
									m_cbCameraList.SetCurSel(nIndex);
								}
							}
						}
					}
				}
				else
				{
					InsertLog(TYPE_ERROR, _T("ntcGetCameraInfo Failed"), emErr);
				}
				delete [] pCameraInfo;
				pCameraInfo = NULL;
			}
		}
	}
	
	if (pPrevInfo)
	{
		if (m_cbCameraList.GetCurSel() == CB_ERR)
		{
			KillTimer(TIMER_FRAME_COUNT);
			KillTimer(TIMER_FPS_CHECK);
			DeleteCameraHandle();
			UpdateControlActivate();
			PostMessage(UM_UPDATE_POPUP_DIALOG, (WPARAM)TRUE, NULL);
		}
		delete pPrevInfo;
		pPrevInfo = NULL;
	}
}

void CNeptuneCSampleDlg::InitPixelFormatList()
{
	m_cbPixelFormat.ResetContent();

	if (m_pCameraHandle)
	{
		_uint32_t uiCount = 0;
		ntcGetPixelFormatList(m_pCameraHandle, NULL, &uiCount);
		if (uiCount > 0)
		{
			ENeptunePixelFormat* pPixelFormatList = new ENeptunePixelFormat[uiCount];
			if (pPixelFormatList)
			{
				ZeroMemory(pPixelFormatList, sizeof(ENeptunePixelFormat) * uiCount);
				ENeptuneError emErr = ntcGetPixelFormatList(m_pCameraHandle, pPixelFormatList, &uiCount);
				if (emErr == NEPTUNE_ERR_Success)
				{
					ENeptunePixelFormat emPixelFormat = Unknown_PixelFormat;
					emErr = ntcGetPixelFormat(m_pCameraHandle, &emPixelFormat);
					if (emErr == NEPTUNE_ERR_Success)
					{
						_char_t szBuf[128] = {NULL, }; 
						for (_uint32_t i = 0; i < uiCount; i++)
						{
							ZeroMemory(&szBuf, sizeof(szBuf));
							if (ntcGetPixelFormatString(m_pCameraHandle, pPixelFormatList[i], szBuf, sizeof(szBuf)) == NEPTUNE_ERR_Success)
							{
								USES_CONVERSION;
								CString strItem = _T("");
								strItem.Format(_T("%s"), A2T(szBuf));
								int nIndex = m_cbPixelFormat.InsertString(i, strItem);
								m_cbPixelFormat.SetItemData(nIndex, (DWORD_PTR)pPixelFormatList[i]);
								if (emPixelFormat == pPixelFormatList[i])
								{
									m_cbPixelFormat.SetCurSel(nIndex);
								}
							}
						}
					}
					else
					{
						InsertLog(TYPE_ERROR, _T("ntcGetPixelFormat Failed"), emErr);
					}
				}
				else
				{
					InsertLog(TYPE_ERROR, _T("ntcGetPixelFormateList Failed"), emErr);
				}
				delete [] pPixelFormatList;
				pPixelFormatList = NULL;
			}
		}
	}
}

void CNeptuneCSampleDlg::InitBayerMethodList()
{
	if (m_pCameraHandle)
	{
		ENeptuneBayerMethod emMethod = NEPTUNE_BAYER_METHOD_NONE;
		if (ntcGetBayerConvert(m_pCameraHandle, &emMethod) == NEPTUNE_ERR_Success)
		{
			for(int i=0; i < m_cbBayerConvert.GetCount(); i++)
			{
				if (emMethod == (ENeptuneBayerMethod)m_cbBayerConvert.GetItemData(i))
				{
					m_cbBayerConvert.SetCurSel(i);
					break;
				}
			}
		}
	}
}

void CNeptuneCSampleDlg::InitBayerLayoutList()
{
	if (m_pCameraHandle)
	{
		ENeptuneBayerLayout emLayout = NEPTUNE_BAYER_GB_RG;
		if (ntcGetBayerLayout(m_pCameraHandle, &emLayout) == NEPTUNE_ERR_Success)
		{
			for (int i = 0; i < m_cbBayerLayout.GetCount(); i++)
			{
				if (emLayout == (ENeptuneBayerLayout)m_cbBayerLayout.GetItemData(i))
				{
					m_cbBayerLayout.SetCurSel(i);
					break;
				}
			}
		}
	}
}

void CNeptuneCSampleDlg::InitEffectState()
{
	ENeptuneDisplayOption emDisplayOpt = NEPTUNE_DISPLAY_OPTION_FIT;
	ntcGetDisplayOption(&emDisplayOpt);
	m_ckFit.SetCheck(emDisplayOpt == NEPTUNE_DISPLAY_OPTION_FIT ? BST_CHECKED : BST_UNCHECKED);
	if (m_pCameraHandle)
	{
		int nEffectFlag = 0;
		if (ntcGetEffect(m_pCameraHandle, &nEffectFlag) == NEPTUNE_ERR_Success)
		{
			m_ckFlip.SetCheck(nEffectFlag & NEPTUNE_EFFECT_FLIP ?  BST_CHECKED : BST_UNCHECKED);
			m_ckMirror.SetCheck(nEffectFlag & NEPTUNE_EFFECT_MIRROR ?  BST_CHECKED : BST_UNCHECKED);
		}
	}
}

BOOL CNeptuneCSampleDlg::IsFrameRateSupported()
{
	BOOL bRet = TRUE;
	ENeptunePixelFormat emPixelFormat = Unknown_PixelFormat;
	if (ntcGetPixelFormat(m_pCameraHandle, &emPixelFormat) == NEPTUNE_ERR_Success)
	{
		if (emPixelFormat >= Format7_Mode0_Mono8 && emPixelFormat <= Format7_Mode2_Raw12)
		{
			bRet = FALSE;
		}
	}
	m_bFrameRateSupport = bRet;
	return bRet;
}

void CNeptuneCSampleDlg::InitFrameRateList()
{
	m_cb1394FPS.ResetContent();
	m_edFPS.SetWindowText(_T(""));
	if (m_pCameraHandle)
	{
		if (IsFrameRateSupported())
		{
			ENeptuneFrameRate em1394FPS = FPS_UNKNOWN;
			double dbValue = 0.0;
			ENeptuneError emErr = ntcGetFrameRate(m_pCameraHandle, &em1394FPS, &dbValue);
			if (emErr == NEPTUNE_ERR_Success)
			{
				if (em1394FPS == FPS_VALUE || em1394FPS == FPS_UNKNOWN)
				{
					CString strValue = _T("");
					strValue.Format(_T("%.2lf"), dbValue);	
					m_edFPS.SetWindowText(strValue);
				}
				else
				{
					_uint32_t uiCount = 0;
					ntcGetFrameRateList(m_pCameraHandle, NULL, &uiCount);
					if (uiCount > 0)
					{
						ENeptuneFrameRate* pFrameRateList = new ENeptuneFrameRate[uiCount];
						if (pFrameRateList)
						{
							ZeroMemory(pFrameRateList, sizeof(ENeptuneFrameRate) * uiCount);
							emErr = ntcGetFrameRateList(m_pCameraHandle, pFrameRateList, &uiCount);
							if (emErr == NEPTUNE_ERR_Success)
							{
								_char_t szBuf[128] = {NULL, }; 
								for(_uint32_t i = 0; i < uiCount; i++)
								{
									ZeroMemory(&szBuf, sizeof(szBuf));
									if (ntcGetFrameRateString(m_pCameraHandle, pFrameRateList[i], szBuf, sizeof(szBuf)) == NEPTUNE_ERR_Success)
									{
										USES_CONVERSION;
										CString strItem = _T("");
										strItem.Format(_T("%s"), A2T(szBuf));
										int nIndex = m_cb1394FPS.InsertString(i, strItem);
										m_cb1394FPS.SetItemData(nIndex, (DWORD_PTR)pFrameRateList[i]);
										if (em1394FPS == pFrameRateList[i])
										{
											m_cb1394FPS.SetCurSel(i);
										}
									}
								}
							}
							else
							{
								InsertLog(TYPE_ERROR, _T("ntcGetFrameRateList Failed"), emErr);
							}
							delete [] pFrameRateList;
							pFrameRateList = NULL;
						}
					}
				}
			}
			else
			{
				InsertLog(TYPE_ERROR, _T("ntcGetFrameRate Failed"), emErr);
			}
		}
	}
}

void CNeptuneCSampleDlg::InitAcquisitionMode()
{
	if (m_pCameraHandle)
	{
		ENeptuneAcquisitionMode emAcqMode = NEPTUNE_ACQ_CONTINUOUS;
		_uint32_t uiFrames = 0;
		ENeptuneError emErr = ntcGetAcquisitionMode(m_pCameraHandle, &emAcqMode, &uiFrames);
		if (emErr == NEPTUNE_ERR_Success)
		{
			CString strText = _T("");
			strText.Format(_T("%d"), uiFrames);
			m_edMultiShotCnt.SetWindowText(strText);
			for (int i = 0; i < m_cbAcqMode.GetCount(); i++)
			{
				if (emAcqMode == (ENeptuneAcquisitionMode)m_cbAcqMode.GetItemData(i))
				{
					m_cbAcqMode.SetCurSel(i);
					break;
				}
			}
		}
		else
		{
			InsertLog(TYPE_ERROR, _T("ntcGetAcquisitionMode Failed"), emErr);
		}
	}
}

void CNeptuneCSampleDlg::UpdateControlActivate()
{
	BOOL bSelCam		= FALSE;
	BOOL b1394Type		= FALSE;
	BOOL bUsb3Type		= FALSE;
	BOOL bThermalType	= FALSE;
	BOOL bPlay			= FALSE;
	BOOL bContinuous	= FALSE;
	BOOL bMultishot		= FALSE;
	BOOL bSupportedSRoi = FALSE;
	if (m_pCameraHandle)
	{
		bSelCam = TRUE;
		ENeptuneDevType emDevType = NEPTUNE_DEV_TYPE_UNKNOWN;
		if (ntcGetCameraType(m_pCameraHandle, &emDevType) == NEPTUNE_ERR_Success)
		{
			b1394Type = (emDevType == NEPTUNE_DEV_TYPE_1394);
			bUsb3Type = (emDevType == NEPTUNE_DEV_TYPE_USB3);
		}
		ENeptuneBoolean emStatus = NEPTUNE_BOOL_FALSE;
		if (ntcGetAcquisition(m_pCameraHandle, &emStatus) == NEPTUNE_ERR_Success)
		{
			bPlay = (emStatus == NEPTUNE_BOOL_TRUE);
		}

		NEPTUNE_XML_NODE_INFO stNodeInfo;
		if (ntcGetNodeInfo(m_pCameraHandle, "Temperatures", &stNodeInfo) == NEPTUNE_ERR_Success)
		{
			bThermalType = TRUE;
		}

		ENeptuneAcquisitionMode emAcqMode = NEPTUNE_ACQ_CONTINUOUS;
		_uint32_t uiFrames = 0;
		if (ntcGetAcquisitionMode(m_pCameraHandle, &emAcqMode, &uiFrames) == NEPTUNE_ERR_Success)
		{
			bContinuous = (emAcqMode == NEPTUNE_ACQ_CONTINUOUS);
			bMultishot = (emAcqMode == NEPTUNE_ACQ_MULTIFRAME);
		}

		if (ntcGetNodeInfo(m_pCameraHandle, "StackedROIEnable", &stNodeInfo) == NEPTUNE_ERR_Success)
		{
			bSupportedSRoi = TRUE;
		}
	}

	m_cbPixelFormat.EnableWindow(bSelCam);
	m_cbBayerConvert.EnableWindow(bSelCam);
	m_cbBayerLayout.EnableWindow(bSelCam);
	m_ckFit.EnableWindow(TRUE);
	m_ckFlip.EnableWindow(bSelCam);
	m_ckMirror.EnableWindow(bSelCam);
	m_cb1394FPS.EnableWindow(bSelCam && !bPlay && b1394Type && m_bFrameRateSupport);
	m_edFPS.EnableWindow(bSelCam && !bPlay && !b1394Type);
	m_btnFpsApply.EnableWindow(m_cb1394FPS.IsWindowEnabled() || m_edFPS.IsWindowEnabled());
	m_btnAcqStart.EnableWindow(bSelCam && !bPlay);
	m_btnAcqStop.EnableWindow(bSelCam && bPlay);
	m_cbAcqMode.EnableWindow(bSelCam);
	m_edMultiShotCnt.EnableWindow(bSelCam && bMultishot);
	m_btnShot.EnableWindow(bSelCam && bPlay && !bContinuous);
	m_btnControl.EnableWindow(bSelCam);
	m_btnFeature.EnableWindow(bSelCam);
	m_btnCapture.EnableWindow(bSelCam);
	m_btnGrab.EnableWindow(bSelCam);
	m_btnResolution.EnableWindow(bSelCam);
	m_btnTrigger.EnableWindow(bSelCam);
	m_btnStrobe.EnableWindow(bSelCam);
	m_btnAutoFocus.EnableWindow(bSelCam);
	m_btnUserSet.EnableWindow(bSelCam);
	m_btnSIOControl.EnableWindow(bSelCam);
	m_btnLUT.EnableWindow(bSelCam);
	m_btnFrameSave.EnableWindow(bSelCam && b1394Type);
	m_btnThermal.EnableWindow(bSelCam && bThermalType);
	m_btnAltLed.EnableWindow(bSelCam && bUsb3Type);
	m_btnStackedROI.EnableWindow(bSelCam && bSupportedSRoi);
}

LRESULT CNeptuneCSampleDlg::UpdatePopupDialogs(WPARAM wParam, LPARAM lParam)
{
	BOOL bDelete = (BOOL)wParam;
	if (bDelete) {
		if (m_pFeatureDlg) {
			m_pFeatureDlg->DestroyWindow();
		}
		if (m_pCaptureDlg) {
			m_pCaptureDlg->DestroyWindow();
		}
		if (m_pGrabDlg) {
			m_pGrabDlg->DestroyWindow();
		}
		if (m_pResolutionDlg) {
			m_pResolutionDlg->DestroyWindow();
		}
		if (m_pTriggerDlg) {
			m_pTriggerDlg->DestroyWindow();
		}
		if (m_pStrobeDlg) {
			m_pStrobeDlg->DestroyWindow();
		}
		if (m_pAutoFocusDlg) {
			m_pAutoFocusDlg->DestroyWindow();
		}
		if (m_pUserSetDlg) {
			m_pUserSetDlg->DestroyWindow();
		}
		if (m_pSIOCtrlDlg) {
			m_pSIOCtrlDlg->DestroyWindow();
		}
		if (m_pLUTDlg) {
			m_pLUTDlg->DestroyWindow();
		}
		if (m_pFrameSaveDlg) {
			m_pFrameSaveDlg->DestroyWindow();
		}
		if (m_pThermalDlg) {
			m_pThermalDlg->DestroyWindow();
		}
		if (m_pAltLedDlg) {
			m_pAltLedDlg->DestroyWindow();
		}
		if (m_pStackedROIDlg) {
			m_pStackedROIDlg->DestroyWindow();
		}
	} else {
		if (m_pFeatureDlg) {
			m_pFeatureDlg->UpdateDialog();
		}
		if (m_pCaptureDlg) {
			m_pCaptureDlg->UpdateDialog();
		}
		if (m_pGrabDlg) {
			m_pGrabDlg->UpdateDialog();
		}
		if (m_pResolutionDlg) {
			m_pResolutionDlg->UpdateDialog();
		}
		if (m_pTriggerDlg) {
			m_pTriggerDlg->UpdateDialog();
		}
		if (m_pStrobeDlg) {
			m_pStrobeDlg->UpdateDialog();
		}
		if (m_pAutoFocusDlg) {
			m_pAutoFocusDlg->UpdateDialog();
		}
		if (m_pUserSetDlg) {
			m_pUserSetDlg->UpdateDialog();
		}
		if (m_pSIOCtrlDlg) {
			m_pSIOCtrlDlg->UpdateDialog();
		}
		if (m_pLUTDlg) {
			m_pLUTDlg->UpdateDialog();
		}
		if (m_pFrameSaveDlg) {
			m_pFrameSaveDlg->UpdateDialog();
		}
		if (m_pThermalDlg) {
			m_pThermalDlg->UpdateDialog();
		}
		if (m_pAltLedDlg) {
			m_pAltLedDlg->UpdateDialog();
		}
		if (m_pStackedROIDlg) {
			m_pStackedROIDlg->UpdateDialog();
		}
	}
	return 0;
}

void CNeptuneCSampleDlg::OnTimer(UINT_PTR nIDEvent)
{
	if (nIDEvent == TIMER_FPS_CHECK)
	{
		if (m_pCameraHandle)
		{
			_float32_t fCurFrameRate = 0;
			if (ntcGetReceiveFrameRate(m_pCameraHandle, &fCurFrameRate) == NEPTUNE_ERR_Success)
			{
				CString strValue = _T("");
				strValue.Format(_T("%.2f"), fCurFrameRate);
				m_stcReceiveFps.SetWindowText(strValue);
			}
		}
	}
	else if (nIDEvent == TIMER_FRAME_COUNT)
	{
		CString strValue = _T("");
		strValue.Format(_T("%u"), m_uiTotalFrameCount);
		m_stcReceiveFrame.SetWindowText(strValue);
	}
	CDialogEx::OnTimer(nIDEvent);
}

void CNeptuneCSampleDlg::OnCbnSelchangeComboCameraList()
{
	DeleteCameraHandle();

	int nItem = m_cbCameraList.GetCurSel();
	if (nItem != CB_ERR)
	{
		PNEPTUNE_CAM_INFO pCameraInfo = (PNEPTUNE_CAM_INFO)m_cbCameraList.GetItemData(nItem);
		if (pCameraInfo)
		{
			ENeptuneError emErr = ntcOpen(pCameraInfo->strCamID, &m_pCameraHandle);
			if (emErr == NEPTUNE_ERR_Success)
			{
				ntcSetDisplay(m_pCameraHandle, m_stcDisplayWnd.GetSafeHwnd());
				ntcSetUnplugCallback(m_pCameraHandle, DeviceUnplugCallback, this);
				ntcSetFrameCallback(m_pCameraHandle, FrameCallback, this);
			}
			else
			{
				m_cbCameraList.SetCurSel(CB_ERR);
				InsertLog(TYPE_ERROR, _T("ntcOpen Failed"), emErr);
			}

			UpdateCameraInfo();
		}
	}
}

void CNeptuneCSampleDlg::OnBnClickedButtonListRefresh()
{
	InitCameraList();
}

void CNeptuneCSampleDlg::OnCbnSelchangeComboPixelFormat()
{
	int nItem = m_cbPixelFormat.GetCurSel();
	if (nItem != CB_ERR && m_pCameraHandle)
	{
		ENeptuneError emErr = ntcSetPixelFormat(m_pCameraHandle, (ENeptunePixelFormat)m_cbPixelFormat.GetItemData(nItem));
		if (emErr == NEPTUNE_ERR_Success)
		{
			ENeptuneDevType emDevType = NEPTUNE_DEV_TYPE_UNKNOWN;
			if (ntcGetCameraType(m_pCameraHandle, &emDevType) == NEPTUNE_ERR_Success)
			{
				if (emDevType == NEPTUNE_DEV_TYPE_1394)
				{
					InitFrameRateList();
					UpdateControlActivate();
				}
			}
		}
		else
		{
			InsertLog(TYPE_ERROR, _T("ntcSetPixelFormat Failed"), emErr);
		}
	}
}

void CNeptuneCSampleDlg::OnCbnSelchangeComboBayerConvert()
{
	int nItem = m_cbBayerConvert.GetCurSel();
	if (nItem != CB_ERR && m_pCameraHandle)
	{
		ENeptuneError emErr = ntcSetBayerConvert(m_pCameraHandle, (ENeptuneBayerMethod)m_cbBayerConvert.GetItemData(nItem));
		if (emErr != NEPTUNE_ERR_Success)
		{
			InsertLog(TYPE_ERROR, _T("ntcSetBayerConvert Failed."), emErr);
		}
	}
}

void CNeptuneCSampleDlg::OnCbnSelchangeComboBayerLayout()
{
	int nItem = m_cbBayerLayout.GetCurSel();
	if (nItem != CB_ERR && m_pCameraHandle)
	{
		ENeptuneError emErr = ntcSetBayerLayout(m_pCameraHandle, (ENeptuneBayerLayout)m_cbBayerLayout.GetItemData(nItem));
		if (emErr != NEPTUNE_ERR_Success)
		{
			InsertLog(TYPE_ERROR, _T("ntcSetBayerLayout Failed."), emErr);
		}
	}
}

void CNeptuneCSampleDlg::OnBnClickedCheckFit()
{
	ENeptuneError emErr = ntcSetDisplayOption((m_ckFit.GetCheck() == BST_CHECKED) ? NEPTUNE_DISPLAY_OPTION_FIT : NEPTUNE_DISPLAY_OPTION_ORIGINAL_CENTER);
	if (emErr != NEPTUNE_ERR_Success)
	{
		InsertLog(TYPE_ERROR, _T("ntcSetDisplayOption Failed."), emErr);
	}
}

void CNeptuneCSampleDlg::OnBnClickedCheckFlip()
{
	if (m_pCameraHandle)
	{
		int nEffectFlags = 0;
		if (ntcGetEffect(m_pCameraHandle, &nEffectFlags) == NEPTUNE_ERR_Success)
		{
			if (m_ckFlip.GetCheck() == BST_CHECKED)
			{
				nEffectFlags |= NEPTUNE_EFFECT_FLIP;
			}
			else
			{
				nEffectFlags &= ~NEPTUNE_EFFECT_FLIP;
			}

			ENeptuneError emErr = ntcSetEffect(m_pCameraHandle, nEffectFlags);
			if (emErr != NEPTUNE_ERR_Success)
			{
				InsertLog(TYPE_ERROR, _T("ntcSetEffect Failed."), emErr);
			}
		}
	}
}

void CNeptuneCSampleDlg::OnBnClickedCheckMirror()
{
	if (m_pCameraHandle)
	{
		int nEffectFlags = 0;
		if (ntcGetEffect(m_pCameraHandle, &nEffectFlags) == NEPTUNE_ERR_Success)
		{
			if (m_ckMirror.GetCheck() == BST_CHECKED)
			{
				nEffectFlags |= NEPTUNE_EFFECT_MIRROR;
			}
			else
			{
				nEffectFlags &= ~NEPTUNE_EFFECT_MIRROR;
			}

			ENeptuneError emErr = ntcSetEffect(m_pCameraHandle, nEffectFlags);
			if (emErr != NEPTUNE_ERR_Success)
			{
				InsertLog(TYPE_ERROR, _T("ntcSetEffect Failed."), emErr);
			}
		}
	}
}

void CNeptuneCSampleDlg::OnBnClickedButtonFpsApply()
{
	if (m_pCameraHandle)
	{
		ENeptuneDevType emDevType = NEPTUNE_DEV_TYPE_UNKNOWN;
		if (ntcGetCameraType(m_pCameraHandle, &emDevType) == NEPTUNE_ERR_Success)
		{
			ENeptuneFrameRate em1394FPS = FPS_UNKNOWN;
			DOUBLE dbValue = 0.0;
			if (emDevType == NEPTUNE_DEV_TYPE_1394)
			{
				int nItem = m_cb1394FPS.GetCurSel();
				if (nItem != CB_ERR)
				{
					em1394FPS = (ENeptuneFrameRate)m_cb1394FPS.GetItemData(nItem);
				}
			}
			else
			{
				CString strValue = _T("");
				m_edFPS.GetWindowText(strValue);
				dbValue = _ttof(strValue);
			}

			ENeptuneError emErr = ntcSetFrameRate(m_pCameraHandle, em1394FPS, dbValue);
			if (emErr != NEPTUNE_ERR_Success)
			{
				InsertLog(TYPE_ERROR, _T("ntcGetCameraType Failed."), emErr);
			}
		}
	}
}

void CNeptuneCSampleDlg::OnBnClickedButtonStart()
{
	if (m_pCameraHandle)
	{
		ENeptuneError emErr = ntcSetAcquisition(m_pCameraHandle, NEPTUNE_BOOL_TRUE);
		if (emErr == NEPTUNE_ERR_Success)
		{
			SetTimer(TIMER_FRAME_COUNT, 100, NULL);
			SetTimer(TIMER_FPS_CHECK, 1000, NULL);
			UpdateControlActivate();
		}
		else
		{
			InsertLog(TYPE_ERROR, _T("ntcSetAcquisition Failed."), emErr);
		}
	}
}

void CNeptuneCSampleDlg::OnBnClickedButtonStop()
{
	if (m_pCameraHandle)
	{
		m_uiTotalFrameCount = 0;
		ENeptuneError emErr = ntcSetAcquisition(m_pCameraHandle, NEPTUNE_BOOL_FALSE);
		if (emErr == NEPTUNE_ERR_Success)
		{
			KillTimer(TIMER_FRAME_COUNT);
			KillTimer(TIMER_FPS_CHECK);
			UpdateControlActivate();   
		}
		else
		{
			InsertLog(TYPE_ERROR, _T("ntcSetAcquisition Failed."), emErr);
		}
	}
}

void CNeptuneCSampleDlg::OnCbnSelchangeComboAcquisitionMode()
{
	int nItem = m_cbAcqMode.GetCurSel();
	if (nItem != CB_ERR && m_pCameraHandle)
	{
		ENeptuneError emErr = ntcSetAcquisitionMode(m_pCameraHandle, (ENeptuneAcquisitionMode)m_cbAcqMode.GetItemData(nItem), (_uint32_t)GetMultiShotCount());
		if (emErr != NEPTUNE_ERR_Success)
		{
			InsertLog(TYPE_ERROR, _T("ntcSetAcquisitionMode Failed."), emErr);
		}
		UpdateControlActivate();
	}
}

LONG CNeptuneCSampleDlg::GetMultiShotCount()
{
	CString strText = _T("");
	m_edMultiShotCnt.GetWindowText(strText);
	LONG nlValue = _ttoi(strText);
	if (nlValue < 1)
	{
		nlValue = 1;
	}
	if (nlValue > 65535)
	{
		nlValue = 65535;
	}
	strText.Format(_T("%d"), nlValue);
	m_edMultiShotCnt.GetWindowText(strText);
	return nlValue;
}

void CNeptuneCSampleDlg::OnBnClickedButtonShot()
{
	int nItem = m_cbAcqMode.GetCurSel();
	if (nItem != CB_ERR && m_pCameraHandle)
	{
		ENeptuneAcquisitionMode emCurSel = (ENeptuneAcquisitionMode)m_cbAcqMode.GetItemData(nItem);
		if (emCurSel == NEPTUNE_ACQ_SINGLEFRAME)
		{
			ENeptuneError emErr = ntcOneShot(m_pCameraHandle);
			if (emErr == NEPTUNE_ERR_Success)
			{
				InsertLog(TYPE_INFORMATION, _T("One-Shot."));
			}
			else
			{
				InsertLog(TYPE_ERROR, _T("ntcOneShot Failed."), emErr);
			}
		}
		else if (emCurSel == NEPTUNE_ACQ_MULTIFRAME)
		{
			ENeptuneAcquisitionMode emAcqMode = NEPTUNE_ACQ_CONTINUOUS;
			_uint32_t uiFrames = 0;
			if (ntcGetAcquisitionMode(m_pCameraHandle, &emAcqMode, &uiFrames) == NEPTUNE_ERR_Success)
			{
				if (emAcqMode != emCurSel || uiFrames != (_uint32_t)GetMultiShotCount())
				{
					ntcSetAcquisitionMode(m_pCameraHandle, emCurSel, (_uint32_t)GetMultiShotCount());
				}
			}

			ENeptuneError emErr = ntcMultiShot(m_pCameraHandle);
			if (emErr == NEPTUNE_ERR_Success)
			{
				InsertLog(TYPE_INFORMATION, _T("Multi-Shot."));
			}
			else
			{
				InsertLog(TYPE_ERROR, _T("ntcMultiShot Failed."), emErr);
			}
		}
	}
}

void CNeptuneCSampleDlg::InsertLog(EM_LOG_LEVEL emLevel, CString strMessage, ENeptuneError emErr /*= NEPTUNE_ERR_Success*/)
{
	int nItem = m_listLog.GetItemCount();
	SYSTEMTIME sysTime = {NULL, };
	GetLocalTime(&sysTime);
	CString strItem = _T("");
	strItem.Format(_T("%04d-%02d-%02d %02d:%02d:%02d.%03d"), sysTime.wYear, sysTime.wMonth, sysTime.wDay, sysTime.wHour, sysTime.wMinute, sysTime.wSecond, sysTime.wMilliseconds);
	m_listLog.InsertItem(LVIF_TEXT, nItem, strItem, 0, 0, 0, NULL);
	switch (emLevel)
	{
	case TYPE_ERROR:		strItem = _T("Error");			break;
	case TYPE_EVENT:		strItem = _T("Event");			break;
	case TYPE_INFORMATION:	strItem = _T("Information");	break;
	}
	m_listLog.SetItem(nItem, 1, LVIF_TEXT, strItem, 0, 0, 0, NULL, 0);
	m_listLog.SetItem(nItem, 2, LVIF_TEXT, strMessage, 0, 0, 0, NULL, 0);
	strItem.Format(_T("%d"), (int)emErr);
	m_listLog.SetItem(nItem, 3, LVIF_TEXT, strItem, 0, 0, 0, NULL, 0);
	if (m_ckAutoScroll.GetCheck() == BST_CHECKED)
	{
		m_listLog.EnsureVisible(nItem, TRUE);
	}
}

void CNeptuneCSampleDlg::UpdateCameraInfo()
{
	InitPixelFormatList();
	InitBayerMethodList();
	InitBayerLayoutList();
	InitEffectState();
	InitFrameRateList();
	InitAcquisitionMode();
	UpdateControlActivate();
	UpdatePopupDialogs((WPARAM)(m_cbCameraList.GetCurSel() == CB_ERR), NULL);
}

void CNeptuneCSampleDlg::OnBnClickedCheckAutoScroll()
{
	if (m_ckAutoScroll.GetCheck() == BST_CHECKED)
	{
		int nIndex = m_listLog.GetItemCount() - 1;
		if (nIndex > 0)
		{
			m_listLog.EnsureVisible(nIndex, TRUE);
		}
	}
}

void CNeptuneCSampleDlg::OnBnClickedButtonStatusClear()
{
	m_listLog.DeleteAllItems();
}

void CNeptuneCSampleDlg::OnBnClickedButtonControl()
{
	if (m_pCameraHandle)
	{
		ntcShowControlDialog(m_pCameraHandle);
	}
}

void CNeptuneCSampleDlg::OnBnClickedButtonFeatrueDlg()
{
	if (m_pFeatureDlg) {
		m_pFeatureDlg->SetFocus();
	} else {
		m_pFeatureDlg = new CPopupFeatureDlg(m_pCameraHandle, (CWnd**)&m_pFeatureDlg);
		m_pFeatureDlg->Create(CPopupFeatureDlg::IDD, CWnd::GetDesktopWindow());
		m_pFeatureDlg->ShowWindow(SW_SHOW);
	}
}

void CNeptuneCSampleDlg::OnBnClickedButtonCaptureDlg()
{
	if (m_pCaptureDlg) {
		m_pCaptureDlg->SetFocus();
	} else {
		m_pCaptureDlg = new CPopupCaptureDlg(m_pCameraHandle, (CWnd**)&m_pCaptureDlg);
		m_pCaptureDlg->Create(CPopupCaptureDlg::IDD, CWnd::GetDesktopWindow());
		m_pCaptureDlg->ShowWindow(SW_SHOW);
	}
}

void CNeptuneCSampleDlg::OnBnClickedButtonGrabDlg()
{
	if (m_pGrabDlg) {
		m_pGrabDlg->SetFocus();
	} else {
		m_pGrabDlg = new CPopupGrabDlg(m_pCameraHandle, (CWnd**)&m_pGrabDlg);
		m_pGrabDlg->Create(CPopupGrabDlg::IDD, CWnd::GetDesktopWindow());
		m_pGrabDlg->ShowWindow(SW_SHOW);
	}
}

void CNeptuneCSampleDlg::OnBnClickedButtonResolutionDlg()
{
	if (m_pResolutionDlg) {
		m_pResolutionDlg->SetFocus();
	} else {
		m_pResolutionDlg = new CPopupResolutionDlg(m_pCameraHandle, (CWnd**)&m_pResolutionDlg);
		m_pResolutionDlg->Create(CPopupResolutionDlg::IDD, CWnd::GetDesktopWindow());
		m_pResolutionDlg->ShowWindow(SW_SHOW);
	}
}

void CNeptuneCSampleDlg::OnBnClickedButtonTriggerDlg()
{
	if (m_pTriggerDlg) {
		m_pTriggerDlg->SetFocus();
	} else {
		m_pTriggerDlg = new CPopupTriggerDlg(m_pCameraHandle, (CWnd**)&m_pTriggerDlg);
		m_pTriggerDlg->Create(CPopupTriggerDlg::IDD, CWnd::GetDesktopWindow());
		m_pTriggerDlg->ShowWindow(SW_SHOW);
	}
}

void CNeptuneCSampleDlg::OnBnClickedButtonStrobeDlg()
{
	if (m_pStrobeDlg) {
		m_pStrobeDlg->SetFocus();
	} else {
		m_pStrobeDlg = new CPopupStrobeDlg(m_pCameraHandle, (CWnd**)&m_pStrobeDlg);
		m_pStrobeDlg->Create(CPopupStrobeDlg::IDD, CWnd::GetDesktopWindow());
		m_pStrobeDlg->ShowWindow(SW_SHOW);
	}
}

void CNeptuneCSampleDlg::OnBnClickedButtonAutoFocusDlg()
{
	if (m_pAutoFocusDlg) {
		m_pAutoFocusDlg->SetFocus();
	} else {
		m_pAutoFocusDlg = new CPopupAutoFocusDlg(m_pCameraHandle, (CWnd**)&m_pAutoFocusDlg);
		m_pAutoFocusDlg->Create(CPopupAutoFocusDlg::IDD, CWnd::GetDesktopWindow());
		m_pAutoFocusDlg->ShowWindow(SW_SHOW);
	}
}

void CNeptuneCSampleDlg::OnBnClickedButtonUserSetDlg()
{
	if (m_pUserSetDlg) {
		m_pUserSetDlg->SetFocus();
	} else {
		m_pUserSetDlg = new CPopupUserSetDlg(m_pCameraHandle, (CWnd**)&m_pUserSetDlg);
		m_pUserSetDlg->Create(CPopupUserSetDlg::IDD, CWnd::GetDesktopWindow());
		m_pUserSetDlg->ShowWindow(SW_SHOW);
	}
}

void CNeptuneCSampleDlg::OnBnClickedButtonSioControlDlg()
{
	if (m_pSIOCtrlDlg) {
		m_pSIOCtrlDlg->SetFocus();
	} else {
		m_pSIOCtrlDlg = new CPopupSIOCtrlDlg(m_pCameraHandle, (CWnd**)&m_pSIOCtrlDlg);
		m_pSIOCtrlDlg->Create(CPopupSIOCtrlDlg::IDD, CWnd::GetDesktopWindow());
		m_pSIOCtrlDlg->ShowWindow(SW_SHOW);
	}
}

void CNeptuneCSampleDlg::OnBnClickedButtonLookUpTableDlg()
{
	if (m_pLUTDlg) {
		m_pLUTDlg->SetFocus();
	} else {
		m_pLUTDlg = new CPopupLUTDlg(m_pCameraHandle, (CWnd**)&m_pLUTDlg);
		m_pLUTDlg->Create(CPopupLUTDlg::IDD, CWnd::GetDesktopWindow());
		m_pLUTDlg->ShowWindow(SW_SHOW);
	}
}

void CNeptuneCSampleDlg::OnBnClickedButton1394FramesaveDlg()
{
	if (m_pFrameSaveDlg) {
		m_pFrameSaveDlg->SetFocus();
	} else {
		m_pFrameSaveDlg = new CPopupFrameSaveDlg(m_pCameraHandle, (CWnd**)&m_pFrameSaveDlg);
		m_pFrameSaveDlg->Create(CPopupFrameSaveDlg::IDD, CWnd::GetDesktopWindow());
		m_pFrameSaveDlg->ShowWindow(SW_SHOW);
	}
}

void CNeptuneCSampleDlg::OnBnClickedButtonThermalDlg()
{
	if (m_pThermalDlg) {
		m_pThermalDlg->SetFocus();
	} else {
		m_pThermalDlg = new CPopupThermalDlg(m_pCameraHandle, (CWnd**)&m_pThermalDlg);
		m_pThermalDlg->Create(CPopupThermalDlg::IDD, CWnd::GetDesktopWindow());
		m_pThermalDlg->ShowWindow(SW_SHOW);
	}
}


void CNeptuneCSampleDlg::OnBnClickedButtonAltLedDlg()
{
	if (m_pAltLedDlg) {
		m_pAltLedDlg->SetFocus();
	} else {
		m_pAltLedDlg = new CPopupAltLedDlg(m_pCameraHandle, (CWnd**)&m_pAltLedDlg);
		m_pAltLedDlg->Create(CPopupAltLedDlg::IDD, CWnd::GetDesktopWindow());
		m_pAltLedDlg->ShowWindow(SW_SHOW);
	}
}

void CNeptuneCSampleDlg::OnBnClickedButtonStackedRoiDlg()
{
	if (m_pStackedROIDlg) {
		m_pStackedROIDlg->SetFocus();
	} else {
		m_pStackedROIDlg = new CPopupStackedROIDlg(m_pCameraHandle, (CWnd**)&m_pStackedROIDlg);
		m_pStackedROIDlg->Create(CPopupStackedROIDlg::IDD, CWnd::GetDesktopWindow());
		m_pStackedROIDlg->ShowWindow(SW_SHOW);
	}
}
