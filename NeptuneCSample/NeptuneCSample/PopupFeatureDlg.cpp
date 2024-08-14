// PopupFeatureDlg.cpp : 구현 파일입니다.
//

#include "stdafx.h"
#include "NeptuneCSample.h"
#include "PopupFeatureDlg.h"
#include "afxdialogex.h"


ENeptuneFeature CPopupFeatureDlg::m_arrMapping[MAX_ARRAY_COUNT] =
{
	NEPTUNE_FEATURE_GAMMA,
	NEPTUNE_FEATURE_GAIN,
	NEPTUNE_FEATURE_RGAIN,
	NEPTUNE_FEATURE_GGAIN,
	NEPTUNE_FEATURE_BGAIN,
	NEPTUNE_FEATURE_AUTOGAIN_MIN,
	NEPTUNE_FEATURE_AUTOGAIN_MAX,
	NEPTUNE_FEATURE_SHUTTER,
	NEPTUNE_FEATURE_AUTOSHUTTER_MIN,
	NEPTUNE_FEATURE_AUTOSHUTTER_MAX,
	NEPTUNE_FEATURE_AUTOEXPOSURE,
	NEPTUNE_FEATURE_BLACKLEVEL,
	NEPTUNE_FEATURE_CONTRAST,
	NEPTUNE_FEATURE_HUE,
	NEPTUNE_FEATURE_SATURATION,
	NEPTUNE_FEATURE_SHARPNESS,
	NEPTUNE_FEATURE_TRIGNOISEFILTER,
	NEPTUNE_FEATURE_BRIGHTLEVELIRIS,
	NEPTUNE_FEATURE_SNOWNOISEREMOVE,
	NEPTUNE_FEATURE_OPTFILTER,
	NEPTUNE_FEATURE_PAN,
	NEPTUNE_FEATURE_TILT,
	NEPTUNE_FEATURE_LCD_BLUE_GAIN,
	NEPTUNE_FEATURE_LCD_RED_GAIN
};

// CPopupFeatureDlg 대화 상자입니다.

IMPLEMENT_DYNAMIC(CPopupFeatureDlg, CPopupBaseDialog)

CPopupFeatureDlg::CPopupFeatureDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis)
	: CPopupBaseDialog(CPopupFeatureDlg::IDD, pCameraHandle, ppThis)
{

}

CPopupFeatureDlg::~CPopupFeatureDlg()
{
}

void CPopupFeatureDlg::DoDataExchange(CDataExchange* pDX)
{
	CPopupBaseDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_CHECK_MODE0, m_ckAutoMode[0]);
	DDX_Control(pDX, IDC_CHECK_MODE1, m_ckAutoMode[1]);
	DDX_Control(pDX, IDC_CHECK_MODE2, m_ckAutoMode[2]);
	DDX_Control(pDX, IDC_CHECK_MODE3, m_ckAutoMode[3]);
	DDX_Control(pDX, IDC_CHECK_MODE4, m_ckAutoMode[4]);
	DDX_Control(pDX, IDC_CHECK_MODE5, m_ckAutoMode[5]);
	DDX_Control(pDX, IDC_CHECK_MODE6, m_ckAutoMode[6]);
	DDX_Control(pDX, IDC_CHECK_MODE7, m_ckAutoMode[7]);
	DDX_Control(pDX, IDC_CHECK_MODE8, m_ckAutoMode[8]);
	DDX_Control(pDX, IDC_CHECK_MODE9, m_ckAutoMode[9]);
	DDX_Control(pDX, IDC_CHECK_MODE10, m_ckAutoMode[10]);
	DDX_Control(pDX, IDC_CHECK_MODE11, m_ckAutoMode[11]);
	DDX_Control(pDX, IDC_CHECK_MODE12, m_ckAutoMode[12]);
	DDX_Control(pDX, IDC_CHECK_MODE13, m_ckAutoMode[13]);
	DDX_Control(pDX, IDC_CHECK_MODE14, m_ckAutoMode[14]);
	DDX_Control(pDX, IDC_CHECK_MODE15, m_ckAutoMode[15]);
	DDX_Control(pDX, IDC_CHECK_MODE16, m_ckAutoMode[16]);
	DDX_Control(pDX, IDC_CHECK_MODE17, m_ckAutoMode[17]);
	DDX_Control(pDX, IDC_CHECK_MODE18, m_ckAutoMode[18]);
	DDX_Control(pDX, IDC_CHECK_MODE19, m_ckAutoMode[19]);
	DDX_Control(pDX, IDC_CHECK_MODE20, m_ckAutoMode[20]);
	DDX_Control(pDX, IDC_CHECK_MODE21, m_ckAutoMode[21]);
	DDX_Control(pDX, IDC_CHECK_MODE22, m_ckAutoMode[22]);
	DDX_Control(pDX, IDC_CHECK_MODE23, m_ckAutoMode[23]);
	DDX_Control(pDX, IDC_SLIDER_VALUE0, m_sdValue[0]);
	DDX_Control(pDX, IDC_SLIDER_VALUE1, m_sdValue[1]);
	DDX_Control(pDX, IDC_SLIDER_VALUE2, m_sdValue[2]);
	DDX_Control(pDX, IDC_SLIDER_VALUE3, m_sdValue[3]);
	DDX_Control(pDX, IDC_SLIDER_VALUE4, m_sdValue[4]);
	DDX_Control(pDX, IDC_SLIDER_VALUE5, m_sdValue[5]);
	DDX_Control(pDX, IDC_SLIDER_VALUE6, m_sdValue[6]);
	DDX_Control(pDX, IDC_SLIDER_VALUE7, m_sdValue[7]);
	DDX_Control(pDX, IDC_SLIDER_VALUE8, m_sdValue[8]);
	DDX_Control(pDX, IDC_SLIDER_VALUE9, m_sdValue[9]);
	DDX_Control(pDX, IDC_SLIDER_VALUE10, m_sdValue[10]);
	DDX_Control(pDX, IDC_SLIDER_VALUE11, m_sdValue[11]);
	DDX_Control(pDX, IDC_SLIDER_VALUE12, m_sdValue[12]);
	DDX_Control(pDX, IDC_SLIDER_VALUE13, m_sdValue[13]);
	DDX_Control(pDX, IDC_SLIDER_VALUE14, m_sdValue[14]);
	DDX_Control(pDX, IDC_SLIDER_VALUE15, m_sdValue[15]);
	DDX_Control(pDX, IDC_SLIDER_VALUE16, m_sdValue[16]);
	DDX_Control(pDX, IDC_SLIDER_VALUE17, m_sdValue[17]);
	DDX_Control(pDX, IDC_SLIDER_VALUE18, m_sdValue[18]);
	DDX_Control(pDX, IDC_SLIDER_VALUE19, m_sdValue[19]);
	DDX_Control(pDX, IDC_SLIDER_VALUE20, m_sdValue[20]);
	DDX_Control(pDX, IDC_SLIDER_VALUE21, m_sdValue[21]);
	DDX_Control(pDX, IDC_SLIDER_VALUE22, m_sdValue[22]);
	DDX_Control(pDX, IDC_SLIDER_VALUE23, m_sdValue[23]);
	DDX_Control(pDX, IDC_EDIT_VALUE0, m_edValue[0]);
	DDX_Control(pDX, IDC_EDIT_VALUE1, m_edValue[1]);
	DDX_Control(pDX, IDC_EDIT_VALUE2, m_edValue[2]);
	DDX_Control(pDX, IDC_EDIT_VALUE3, m_edValue[3]);
	DDX_Control(pDX, IDC_EDIT_VALUE4, m_edValue[4]);
	DDX_Control(pDX, IDC_EDIT_VALUE5, m_edValue[5]);
	DDX_Control(pDX, IDC_EDIT_VALUE6, m_edValue[6]);
	DDX_Control(pDX, IDC_EDIT_VALUE7, m_edValue[7]);
	DDX_Control(pDX, IDC_EDIT_VALUE8, m_edValue[8]);
	DDX_Control(pDX, IDC_EDIT_VALUE9, m_edValue[9]);
	DDX_Control(pDX, IDC_EDIT_VALUE10, m_edValue[10]);
	DDX_Control(pDX, IDC_EDIT_VALUE11, m_edValue[11]);
	DDX_Control(pDX, IDC_EDIT_VALUE12, m_edValue[12]);
	DDX_Control(pDX, IDC_EDIT_VALUE13, m_edValue[13]);
	DDX_Control(pDX, IDC_EDIT_VALUE14, m_edValue[14]);
	DDX_Control(pDX, IDC_EDIT_VALUE15, m_edValue[15]);
	DDX_Control(pDX, IDC_EDIT_VALUE16, m_edValue[16]);
	DDX_Control(pDX, IDC_EDIT_VALUE17, m_edValue[17]);
	DDX_Control(pDX, IDC_EDIT_VALUE18, m_edValue[18]);
	DDX_Control(pDX, IDC_EDIT_VALUE19, m_edValue[19]);
	DDX_Control(pDX, IDC_EDIT_VALUE20, m_edValue[20]);
	DDX_Control(pDX, IDC_EDIT_VALUE21, m_edValue[21]);
	DDX_Control(pDX, IDC_EDIT_VALUE22, m_edValue[22]);
	DDX_Control(pDX, IDC_EDIT_VALUE23, m_edValue[23]);
	DDX_Control(pDX, IDC_STATIC_RANGE0, m_stcRange[0]);
	DDX_Control(pDX, IDC_STATIC_RANGE1, m_stcRange[1]);
	DDX_Control(pDX, IDC_STATIC_RANGE2, m_stcRange[2]);
	DDX_Control(pDX, IDC_STATIC_RANGE3, m_stcRange[3]);
	DDX_Control(pDX, IDC_STATIC_RANGE4, m_stcRange[4]);
	DDX_Control(pDX, IDC_STATIC_RANGE5, m_stcRange[5]);
	DDX_Control(pDX, IDC_STATIC_RANGE6, m_stcRange[6]);
	DDX_Control(pDX, IDC_STATIC_RANGE7, m_stcRange[7]);
	DDX_Control(pDX, IDC_STATIC_RANGE8, m_stcRange[8]);
	DDX_Control(pDX, IDC_STATIC_RANGE9, m_stcRange[9]);
	DDX_Control(pDX, IDC_STATIC_RANGE10, m_stcRange[10]);
	DDX_Control(pDX, IDC_STATIC_RANGE11, m_stcRange[11]);
	DDX_Control(pDX, IDC_STATIC_RANGE12, m_stcRange[12]);
	DDX_Control(pDX, IDC_STATIC_RANGE13, m_stcRange[13]);
	DDX_Control(pDX, IDC_STATIC_RANGE14, m_stcRange[14]);
	DDX_Control(pDX, IDC_STATIC_RANGE15, m_stcRange[15]);
	DDX_Control(pDX, IDC_STATIC_RANGE16, m_stcRange[16]);
	DDX_Control(pDX, IDC_STATIC_RANGE17, m_stcRange[17]);
	DDX_Control(pDX, IDC_STATIC_RANGE18, m_stcRange[18]);
	DDX_Control(pDX, IDC_STATIC_RANGE19, m_stcRange[19]);
	DDX_Control(pDX, IDC_STATIC_RANGE20, m_stcRange[20]);
	DDX_Control(pDX, IDC_STATIC_RANGE21, m_stcRange[21]);
	DDX_Control(pDX, IDC_STATIC_RANGE22, m_stcRange[22]);
	DDX_Control(pDX, IDC_STATIC_RANGE23, m_stcRange[23]);
	DDX_Control(pDX, IDC_COMBO_WHITE_BALANCE, m_cbWhiteBalance);
}


BEGIN_MESSAGE_MAP(CPopupFeatureDlg, CPopupBaseDialog)
	ON_BN_CLICKED(IDC_CHECK_MODE0, &CPopupFeatureDlg::OnBnClickedCheckMode0)
	ON_BN_CLICKED(IDC_CHECK_MODE1, &CPopupFeatureDlg::OnBnClickedCheckMode1)
	ON_BN_CLICKED(IDC_CHECK_MODE2, &CPopupFeatureDlg::OnBnClickedCheckMode2)
	ON_BN_CLICKED(IDC_CHECK_MODE3, &CPopupFeatureDlg::OnBnClickedCheckMode3)
	ON_BN_CLICKED(IDC_CHECK_MODE4, &CPopupFeatureDlg::OnBnClickedCheckMode4)
	ON_BN_CLICKED(IDC_CHECK_MODE5, &CPopupFeatureDlg::OnBnClickedCheckMode5)
	ON_BN_CLICKED(IDC_CHECK_MODE6, &CPopupFeatureDlg::OnBnClickedCheckMode6)
	ON_BN_CLICKED(IDC_CHECK_MODE7, &CPopupFeatureDlg::OnBnClickedCheckMode7)
	ON_BN_CLICKED(IDC_CHECK_MODE8, &CPopupFeatureDlg::OnBnClickedCheckMode8)
	ON_BN_CLICKED(IDC_CHECK_MODE9, &CPopupFeatureDlg::OnBnClickedCheckMode9)
	ON_BN_CLICKED(IDC_CHECK_MODE10, &CPopupFeatureDlg::OnBnClickedCheckMode10)
	ON_BN_CLICKED(IDC_CHECK_MODE11, &CPopupFeatureDlg::OnBnClickedCheckMode11)
	ON_BN_CLICKED(IDC_CHECK_MODE12, &CPopupFeatureDlg::OnBnClickedCheckMode12)
	ON_BN_CLICKED(IDC_CHECK_MODE13, &CPopupFeatureDlg::OnBnClickedCheckMode13)
	ON_BN_CLICKED(IDC_CHECK_MODE14, &CPopupFeatureDlg::OnBnClickedCheckMode14)
	ON_BN_CLICKED(IDC_CHECK_MODE15, &CPopupFeatureDlg::OnBnClickedCheckMode15)
	ON_BN_CLICKED(IDC_CHECK_MODE16, &CPopupFeatureDlg::OnBnClickedCheckMode16)
	ON_BN_CLICKED(IDC_CHECK_MODE17, &CPopupFeatureDlg::OnBnClickedCheckMode17)
	ON_BN_CLICKED(IDC_CHECK_MODE18, &CPopupFeatureDlg::OnBnClickedCheckMode18)
	ON_BN_CLICKED(IDC_CHECK_MODE19, &CPopupFeatureDlg::OnBnClickedCheckMode19)
	ON_BN_CLICKED(IDC_CHECK_MODE20, &CPopupFeatureDlg::OnBnClickedCheckMode20)
	ON_BN_CLICKED(IDC_CHECK_MODE21, &CPopupFeatureDlg::OnBnClickedCheckMode21)
	ON_BN_CLICKED(IDC_CHECK_MODE22, &CPopupFeatureDlg::OnBnClickedCheckMode22)
	ON_BN_CLICKED(IDC_CHECK_MODE23, &CPopupFeatureDlg::OnBnClickedCheckMode23)
	ON_NOTIFY(NM_RELEASEDCAPTURE, IDC_SLIDER_VALUE0, &CPopupFeatureDlg::OnNMReleasedcaptureSliderValue0)
	ON_NOTIFY(NM_RELEASEDCAPTURE, IDC_SLIDER_VALUE1, &CPopupFeatureDlg::OnNMReleasedcaptureSliderValue1)
	ON_NOTIFY(NM_RELEASEDCAPTURE, IDC_SLIDER_VALUE2, &CPopupFeatureDlg::OnNMReleasedcaptureSliderValue2)
	ON_NOTIFY(NM_RELEASEDCAPTURE, IDC_SLIDER_VALUE3, &CPopupFeatureDlg::OnNMReleasedcaptureSliderValue3)
	ON_NOTIFY(NM_RELEASEDCAPTURE, IDC_SLIDER_VALUE4, &CPopupFeatureDlg::OnNMReleasedcaptureSliderValue4)
	ON_NOTIFY(NM_RELEASEDCAPTURE, IDC_SLIDER_VALUE5, &CPopupFeatureDlg::OnNMReleasedcaptureSliderValue5)
	ON_NOTIFY(NM_RELEASEDCAPTURE, IDC_SLIDER_VALUE6, &CPopupFeatureDlg::OnNMReleasedcaptureSliderValue6)
	ON_NOTIFY(NM_RELEASEDCAPTURE, IDC_SLIDER_VALUE7, &CPopupFeatureDlg::OnNMReleasedcaptureSliderValue7)
	ON_NOTIFY(NM_RELEASEDCAPTURE, IDC_SLIDER_VALUE8, &CPopupFeatureDlg::OnNMReleasedcaptureSliderValue8)
	ON_NOTIFY(NM_RELEASEDCAPTURE, IDC_SLIDER_VALUE9, &CPopupFeatureDlg::OnNMReleasedcaptureSliderValue9)
	ON_NOTIFY(NM_RELEASEDCAPTURE, IDC_SLIDER_VALUE10, &CPopupFeatureDlg::OnNMReleasedcaptureSliderValue10)
	ON_NOTIFY(NM_RELEASEDCAPTURE, IDC_SLIDER_VALUE11, &CPopupFeatureDlg::OnNMReleasedcaptureSliderValue11)
	ON_NOTIFY(NM_RELEASEDCAPTURE, IDC_SLIDER_VALUE12, &CPopupFeatureDlg::OnNMReleasedcaptureSliderValue12)
	ON_NOTIFY(NM_RELEASEDCAPTURE, IDC_SLIDER_VALUE13, &CPopupFeatureDlg::OnNMReleasedcaptureSliderValue13)
	ON_NOTIFY(NM_RELEASEDCAPTURE, IDC_SLIDER_VALUE14, &CPopupFeatureDlg::OnNMReleasedcaptureSliderValue14)
	ON_NOTIFY(NM_RELEASEDCAPTURE, IDC_SLIDER_VALUE15, &CPopupFeatureDlg::OnNMReleasedcaptureSliderValue15)
	ON_NOTIFY(NM_RELEASEDCAPTURE, IDC_SLIDER_VALUE16, &CPopupFeatureDlg::OnNMReleasedcaptureSliderValue16)
	ON_NOTIFY(NM_RELEASEDCAPTURE, IDC_SLIDER_VALUE17, &CPopupFeatureDlg::OnNMReleasedcaptureSliderValue17)
	ON_NOTIFY(NM_RELEASEDCAPTURE, IDC_SLIDER_VALUE18, &CPopupFeatureDlg::OnNMReleasedcaptureSliderValue18)
	ON_NOTIFY(NM_RELEASEDCAPTURE, IDC_SLIDER_VALUE19, &CPopupFeatureDlg::OnNMReleasedcaptureSliderValue19)
	ON_NOTIFY(NM_RELEASEDCAPTURE, IDC_SLIDER_VALUE20, &CPopupFeatureDlg::OnNMReleasedcaptureSliderValue20)
	ON_NOTIFY(NM_RELEASEDCAPTURE, IDC_SLIDER_VALUE21, &CPopupFeatureDlg::OnNMReleasedcaptureSliderValue21)
	ON_NOTIFY(NM_RELEASEDCAPTURE, IDC_SLIDER_VALUE22, &CPopupFeatureDlg::OnNMReleasedcaptureSliderValue22)
	ON_NOTIFY(NM_RELEASEDCAPTURE, IDC_SLIDER_VALUE23, &CPopupFeatureDlg::OnNMReleasedcaptureSliderValue23)
	ON_CBN_SELCHANGE(IDC_COMBO_WHITE_BALANCE, &CPopupFeatureDlg::OnCbnSelchangeComboWhiteBalance)
	ON_BN_CLICKED(IDC_BUTTON_DEFUALT, &CPopupFeatureDlg::OnBnClickedButtonDefualt)
END_MESSAGE_MAP()


BOOL CPopupFeatureDlg::PreTranslateMessage(MSG* pMsg)
{
	if (pMsg->message == WM_KEYDOWN)
	{
		if (pMsg->wParam == VK_RETURN || pMsg->wParam == VK_ESCAPE)
		{
			for (int i = 0; i < MAX_ARRAY_COUNT; i++)
			{
				if (pMsg->hwnd == m_edValue[i].GetSafeHwnd())
				{
					OnEditBoxKeyDown(i, pMsg->wParam == VK_RETURN);
				}
			}
			return TRUE;
		}
	}

	return CPopupBaseDialog::PreTranslateMessage(pMsg);
}

void CPopupFeatureDlg::UpdateDialog()
{
	for (int i = 0; i < MAX_ARRAY_COUNT; i++)
	{
		ZeroMemory(&m_arrFeatureInfo, sizeof(m_arrFeatureInfo));
		m_ckAutoMode[i].ShowWindow(SW_SHOW);
		m_ckAutoMode[i].SetCheck(BST_UNCHECKED);
		m_sdValue[i].EnableWindow(TRUE);
		m_sdValue[i].SetRange(INT_MIN, INT_MAX);
		m_sdValue[i].SetPos(0);
		m_edValue[i].EnableWindow(TRUE);
		m_edValue[i].SetWindowText(_T("0"));
		m_stcRange[i].EnableWindow(TRUE);
		m_stcRange[i].SetWindowText(_T("(Min ~ Max)"));
	}
	m_cbWhiteBalance.ResetContent();

	if (m_pCameraHandle)
	{
		for (int i = 0; i < MAX_ARRAY_COUNT; i++)
		{
			if (m_arrMapping[i] == NEPTUNE_FEATURE_GAMMA)
			{
				NEPTUNE_XML_NODE_INFO stNodeInfo;
				ntcGetNodeInfo(m_pCameraHandle, "Gamma", &stNodeInfo);
				if (stNodeInfo.Type == NEPTUNE_NODE_TYPE_INT) {
					NEPTUNE_XML_INT_VALUE_INFO stIntValue;
					if (ntcGetNodeInt(m_pCameraHandle, "Gamma", &stIntValue) == NEPTUNE_ERR_Success) {
						CString strValue = _T("");
						strValue.Format(_T("%d"), stIntValue.nValue);
						CString strRange = _T("");
						strRange.Format(_T("(%d ~ %d)"), stIntValue.nMin, stIntValue.nMax);
						m_sdValue[i].SetRange(stIntValue.nMin, stIntValue.nMax, TRUE);
						m_sdValue[i].SetPos(stIntValue.nValue);
						m_sdValue[i].EnableWindow((stIntValue.AccessMode == NEPTUNE_NODE_ACCESSMODE_RW) || (stIntValue.AccessMode == NEPTUNE_NODE_ACCESSMODE_WO));
						m_edValue[i].SetWindowText(strValue);
						m_edValue[i].EnableWindow((stIntValue.AccessMode == NEPTUNE_NODE_ACCESSMODE_RW) || (stIntValue.AccessMode == NEPTUNE_NODE_ACCESSMODE_WO));
						m_stcRange[i].SetWindowText(strRange);
					} else {
						m_sdValue[i].EnableWindow(FALSE);
						m_edValue[i].EnableWindow(FALSE);
						m_stcRange[i].EnableWindow(FALSE);
					}
				} else {
					NEPTUNE_XML_FLOAT_VALUE_INFO stFloatValue;
					if (ntcGetNodeFloat(m_pCameraHandle, "Gamma", &stFloatValue) == NEPTUNE_ERR_Success) {
						CString strValue = _T("");
						strValue.Format(_T("%0.3f"), stFloatValue.dValue);
						CString strRange = _T("");
						strRange.Format(_T("(%0.1f ~ %0.1f)"), stFloatValue.dMin, stFloatValue.dMax);
						m_sdValue[i].SetRange(stFloatValue.dMin * 1000, stFloatValue.dMax * 1000, TRUE);
						m_sdValue[i].SetPos(stFloatValue.dValue * 1000);
						m_sdValue[i].EnableWindow((stFloatValue.AccessMode == NEPTUNE_NODE_ACCESSMODE_RW) || (stFloatValue.AccessMode == NEPTUNE_NODE_ACCESSMODE_WO));
						m_edValue[i].SetWindowText(strValue);
						m_edValue[i].EnableWindow((stFloatValue.AccessMode == NEPTUNE_NODE_ACCESSMODE_RW) || (stFloatValue.AccessMode == NEPTUNE_NODE_ACCESSMODE_WO));
						m_stcRange[i].SetWindowText(strRange);
					} else {
						m_sdValue[i].EnableWindow(FALSE);
						m_edValue[i].EnableWindow(FALSE);
						m_stcRange[i].EnableWindow(FALSE);
					}
				}
				m_ckAutoMode[i].ShowWindow(SW_HIDE);
			}
			else
			{
				if (ntcGetFeature(m_pCameraHandle, m_arrMapping[i], &m_arrFeatureInfo[i]) == NEPTUNE_ERR_Success)
				{
					if (m_arrFeatureInfo[i].SupportAutoModes != 0 &&
						m_arrMapping[i] != NEPTUNE_FEATURE_RGAIN &&
						m_arrMapping[i] != NEPTUNE_FEATURE_GGAIN &&
						m_arrMapping[i] != NEPTUNE_FEATURE_BGAIN)
					{
						m_ckAutoMode[i].SetCheck((m_arrFeatureInfo[i].AutoMode == NEPTUNE_AUTO_CONTINUOUS) ? BST_CHECKED : BST_UNCHECKED);
					}
					else
					{
						if (m_arrMapping[i] == NEPTUNE_FEATURE_SNOWNOISEREMOVE)
						{
							m_ckAutoMode[i].SetWindowText(_T("On"));
							m_ckAutoMode[i].SetCheck((m_arrFeatureInfo[i].bOnOff == NEPTUNE_BOOL_TRUE) ? BST_CHECKED : BST_UNCHECKED);
						}
						else
						{
							m_ckAutoMode[i].ShowWindow(SW_HIDE);
						}
					}

					if (m_arrFeatureInfo[i].Value != -1)
					{
						CString strValue = _T("");
						strValue.Format(_T("%d"), m_arrFeatureInfo[i].Value);
						CString strRange = _T("");
						strRange.Format(_T("(%d ~ %d)"), m_arrFeatureInfo[i].Min, m_arrFeatureInfo[i].Max);
						m_sdValue[i].SetRange(m_arrFeatureInfo[i].Min, m_arrFeatureInfo[i].Max, TRUE);
						m_sdValue[i].SetPos(m_arrFeatureInfo[i].Value);
						m_sdValue[i].EnableWindow((m_arrFeatureInfo[i].ValueAccessMode == NEPTUNE_NODE_ACCESSMODE_RW) || (m_arrFeatureInfo[i].ValueAccessMode == NEPTUNE_NODE_ACCESSMODE_WO));
						m_edValue[i].SetWindowText(strValue);
						m_edValue[i].EnableWindow((m_arrFeatureInfo[i].ValueAccessMode == NEPTUNE_NODE_ACCESSMODE_RW) || (m_arrFeatureInfo[i].ValueAccessMode == NEPTUNE_NODE_ACCESSMODE_WO));
						m_stcRange[i].SetWindowText(strRange);

						if (m_arrMapping[i] == NEPTUNE_FEATURE_SNOWNOISEREMOVE)
						{
							m_sdValue[i].EnableWindow(m_sdValue[i].IsWindowEnabled() && (m_ckAutoMode[i].GetCheck() == BST_CHECKED));
							m_edValue[i].EnableWindow(m_edValue[i].IsWindowEnabled() && (m_ckAutoMode[i].GetCheck() == BST_CHECKED));
						}
					}
					else
					{
						m_sdValue[i].EnableWindow(FALSE);
						m_edValue[i].EnableWindow(FALSE);
						m_stcRange[i].EnableWindow(FALSE);
					}
				}
				else
				{
					m_ckAutoMode[i].ShowWindow(SW_HIDE);
					m_sdValue[i].EnableWindow(FALSE);
					m_edValue[i].EnableWindow(FALSE);
					m_stcRange[i].EnableWindow(FALSE);
				}
			}
		}

		NEPTUNE_FEATURE stFeatureInfo;
		if (ntcGetFeature(m_pCameraHandle, NEPTUNE_FEATURE_WHITEBALANCE, &stFeatureInfo) == NEPTUNE_ERR_Success)
		{
			int nItem = CB_ERR;
			if ((stFeatureInfo.SupportAutoModes & 0x1) == 0x1)
			{
				nItem = m_cbWhiteBalance.InsertString(m_cbWhiteBalance.GetCount(), _T("Off"));
				m_cbWhiteBalance.SetItemData(nItem, NEPTUNE_AUTO_OFF);
			}
			if ((stFeatureInfo.SupportAutoModes & 0x2) == 0x2)
			{
				nItem = m_cbWhiteBalance.InsertString(m_cbWhiteBalance.GetCount(), _T("Once"));
				m_cbWhiteBalance.SetItemData(nItem, NEPTUNE_AUTO_ONCE);
			}
			if ((stFeatureInfo.SupportAutoModes & 0x4) == 0x4)
			{
				nItem = m_cbWhiteBalance.InsertString(m_cbWhiteBalance.GetCount(), _T("Continuous"));
				m_cbWhiteBalance.SetItemData(nItem, NEPTUNE_AUTO_CONTINUOUS);
			}
			for (int i = 0; i < m_cbWhiteBalance.GetCount(); i++)
			{
				if (stFeatureInfo.AutoMode == (ENeptuneAutoMode)m_cbWhiteBalance.GetItemData(i))
				{
					m_cbWhiteBalance.SetCurSel(i);
					break;
				}
			}
		}

		OnCheckBoxClicked(1); // gain
		OnCheckBoxClicked(7); // shutter

		for (int i = 0; i < MAX_ARRAY_COUNT; i++)
		{
			if (m_arrMapping[i] == NEPTUNE_FEATURE_RGAIN ||
				m_arrMapping[i] == NEPTUNE_FEATURE_GGAIN ||
				m_arrMapping[i] == NEPTUNE_FEATURE_BGAIN)
			{
				NEPTUNE_FEATURE stInfoEx;
				ntcGetFeature(m_pCameraHandle, m_arrMapping[i], &stInfoEx);
				BOOL bIsAccess = (stInfoEx.ValueAccessMode == NEPTUNE_NODE_ACCESSMODE_RW || stInfoEx.ValueAccessMode == NEPTUNE_NODE_ACCESSMODE_WO);
				m_sdValue[i].EnableWindow(bIsAccess);
				m_edValue[i].EnableWindow(bIsAccess);
			}
		}
	}
}

#pragma region CheckBoxClick
void CPopupFeatureDlg::OnCheckBoxClicked(int nIndex)
{
	if (m_pCameraHandle)
	{
		NEPTUNE_FEATURE stInfo;
		memcpy(&stInfo, &m_arrFeatureInfo[nIndex], sizeof(NEPTUNE_FEATURE));
		if (m_arrMapping[nIndex] == NEPTUNE_FEATURE_SNOWNOISEREMOVE)
		{
			stInfo.bOnOff = ((m_ckAutoMode[nIndex].GetCheck() == BST_CHECKED) ? NEPTUNE_BOOL_TRUE : NEPTUNE_BOOL_FALSE);
			ENeptuneError emErr = ntcSetFeature(m_pCameraHandle, m_arrMapping[nIndex], stInfo);
			if (emErr == NEPTUNE_ERR_Success)
			{
				m_sdValue[nIndex].EnableWindow(stInfo.bOnOff == NEPTUNE_BOOL_TRUE);
				m_edValue[nIndex].EnableWindow(stInfo.bOnOff == NEPTUNE_BOOL_TRUE);
				memcpy(&m_arrFeatureInfo[nIndex], &stInfo, sizeof(NEPTUNE_FEATURE));
			}
			else
			{
				m_ckAutoMode[nIndex].SetCheck((m_arrFeatureInfo[nIndex].AutoMode == NEPTUNE_AUTO_CONTINUOUS) ? BST_CHECKED : BST_UNCHECKED);
				InsertLog(TYPE_ERROR, _T("ntcSetFeature Failed."), emErr);
			}
		}
		else
		{
			if (m_ckAutoMode[nIndex].GetCheck() == BST_CHECKED)
			{
				stInfo.AutoMode = NEPTUNE_AUTO_CONTINUOUS;
			}
			else
			{
				ntcGetFeature(m_pCameraHandle, m_arrMapping[nIndex], &stInfo);
				stInfo.AutoMode = NEPTUNE_AUTO_OFF;

				CString strValue = _T("");
				strValue.Format(_T("%d"), stInfo.Value);
				m_sdValue[nIndex].SetPos(stInfo.Value);
				m_edValue[nIndex].SetWindowText(strValue);
			}
			
			ENeptuneError emErr = ntcSetFeature(m_pCameraHandle, m_arrMapping[nIndex], stInfo);
			if (emErr == NEPTUNE_ERR_Success)
			{
				memcpy(&m_arrFeatureInfo[nIndex], &stInfo, sizeof(NEPTUNE_FEATURE));
				BOOL bEnable = (stInfo.AutoMode == NEPTUNE_AUTO_OFF);
				m_sdValue[nIndex].EnableWindow(bEnable);
				m_edValue[nIndex].EnableWindow(bEnable);
			}
			else
			{
				m_ckAutoMode[nIndex].SetCheck((m_arrFeatureInfo[nIndex].AutoMode == NEPTUNE_AUTO_CONTINUOUS) ? BST_CHECKED : BST_UNCHECKED);
				InsertLog(TYPE_ERROR, _T("ntcSetFeature Failed."), emErr);
			}
		}
	}
}

void CPopupFeatureDlg::OnBnClickedCheckMode0() { OnCheckBoxClicked(0); }
void CPopupFeatureDlg::OnBnClickedCheckMode1() { OnCheckBoxClicked(1); }
void CPopupFeatureDlg::OnBnClickedCheckMode2() { OnCheckBoxClicked(2); }
void CPopupFeatureDlg::OnBnClickedCheckMode3() { OnCheckBoxClicked(3); }
void CPopupFeatureDlg::OnBnClickedCheckMode4() { OnCheckBoxClicked(4); }
void CPopupFeatureDlg::OnBnClickedCheckMode5() { OnCheckBoxClicked(5); }
void CPopupFeatureDlg::OnBnClickedCheckMode6() { OnCheckBoxClicked(6); }
void CPopupFeatureDlg::OnBnClickedCheckMode7() { OnCheckBoxClicked(7); }
void CPopupFeatureDlg::OnBnClickedCheckMode8() { OnCheckBoxClicked(8); }
void CPopupFeatureDlg::OnBnClickedCheckMode9() { OnCheckBoxClicked(9); }
void CPopupFeatureDlg::OnBnClickedCheckMode10() { OnCheckBoxClicked(10); }
void CPopupFeatureDlg::OnBnClickedCheckMode11() { OnCheckBoxClicked(11); }
void CPopupFeatureDlg::OnBnClickedCheckMode12() { OnCheckBoxClicked(12); }
void CPopupFeatureDlg::OnBnClickedCheckMode13() { OnCheckBoxClicked(13); }
void CPopupFeatureDlg::OnBnClickedCheckMode14() { OnCheckBoxClicked(14); }
void CPopupFeatureDlg::OnBnClickedCheckMode15() { OnCheckBoxClicked(15); }
void CPopupFeatureDlg::OnBnClickedCheckMode16() { OnCheckBoxClicked(16); }
void CPopupFeatureDlg::OnBnClickedCheckMode17() { OnCheckBoxClicked(17); }
void CPopupFeatureDlg::OnBnClickedCheckMode18() { OnCheckBoxClicked(18); }
void CPopupFeatureDlg::OnBnClickedCheckMode19() { OnCheckBoxClicked(19); }
void CPopupFeatureDlg::OnBnClickedCheckMode20() { OnCheckBoxClicked(20); }
void CPopupFeatureDlg::OnBnClickedCheckMode21() { OnCheckBoxClicked(21); }
void CPopupFeatureDlg::OnBnClickedCheckMode22() { OnCheckBoxClicked(22); }
void CPopupFeatureDlg::OnBnClickedCheckMode23() { OnCheckBoxClicked(23); }
#pragma endregion

#pragma region SliderBarClick
void CPopupFeatureDlg::OnSliderBarClicked(int nIndex)
{
	if (m_pCameraHandle)
	{
		if (m_arrMapping[nIndex] == NEPTUNE_FEATURE_GAMMA) {
			NEPTUNE_XML_NODE_INFO stNodeInfo;
			ntcGetNodeInfo(m_pCameraHandle, "Gamma", &stNodeInfo);
			if (stNodeInfo.Type == NEPTUNE_NODE_TYPE_INT) {
				ntcSetNodeInt(m_pCameraHandle, "Gamma", m_sdValue[nIndex].GetPos());
				CString strText = _T("");
				strText.Format(_T("%d"), m_sdValue[nIndex].GetPos());
				m_edValue[nIndex].SetWindowText(strText);
			} else {
				NEPTUNE_XML_FLOAT_VALUE_INFO stValueInfo;
				ntcGetNodeFloat(m_pCameraHandle, "Gamma", &stValueInfo);
				FLOAT fVal = (FLOAT)m_sdValue[nIndex].GetPos() / 1000.0;
				LONG nlVal = (LONG)(fVal * 1000);
				LONG nlInc = (LONG)(stValueInfo.dInc * 1000);
				LONG nlRemain = nlVal % nlInc;
				if (nlRemain != 0) {
					LONG nlHalfInc = (LONG)(nlInc / 2);
					if (nlRemain > nlHalfInc) {
						fVal = (FLOAT)(nlVal + (nlInc - nlRemain)) / 1000.0;
					} else {
						fVal = (FLOAT)(nlVal - nlRemain) / 1000.0;
					}
				}
				ntcSetNodeFloat(m_pCameraHandle, "Gamma", fVal);
				CString strText = _T("");
				strText.Format(_T("%0.3f"), fVal);
				m_edValue[nIndex].SetWindowText(strText);
				m_sdValue[nIndex].SetPos(fVal * 1000);
			}
		} else {
			NEPTUNE_FEATURE stInfo;
			memcpy(&stInfo, &m_arrFeatureInfo[nIndex], sizeof(NEPTUNE_FEATURE));
			stInfo.Value = m_sdValue[nIndex].GetPos();
			ENeptuneError emErr = ntcSetFeature(m_pCameraHandle, m_arrMapping[nIndex], stInfo);
			if (emErr == NEPTUNE_ERR_Success)
			{
				memcpy(&m_arrFeatureInfo[nIndex], &stInfo, sizeof(NEPTUNE_FEATURE));
				CString strText = _T("");
				strText.Format(_T("%d"), m_arrFeatureInfo[nIndex].Value);
				m_edValue[nIndex].SetWindowText(strText);
			}
			else
			{
				m_sdValue[nIndex].SetPos(m_arrFeatureInfo[nIndex].Value);
				InsertLog(TYPE_ERROR, _T("ntcSetFeature Failed."), emErr);
			}
		}
	}
}

void CPopupFeatureDlg::OnNMReleasedcaptureSliderValue0(NMHDR *pNMHDR, LRESULT *pResult) { OnSliderBarClicked(0); *pResult = 0; }
void CPopupFeatureDlg::OnNMReleasedcaptureSliderValue1(NMHDR *pNMHDR, LRESULT *pResult) { OnSliderBarClicked(1); *pResult = 0; }
void CPopupFeatureDlg::OnNMReleasedcaptureSliderValue2(NMHDR *pNMHDR, LRESULT *pResult) { OnSliderBarClicked(2); *pResult = 0; }
void CPopupFeatureDlg::OnNMReleasedcaptureSliderValue3(NMHDR *pNMHDR, LRESULT *pResult) { OnSliderBarClicked(3); *pResult = 0; }
void CPopupFeatureDlg::OnNMReleasedcaptureSliderValue4(NMHDR *pNMHDR, LRESULT *pResult) { OnSliderBarClicked(4); *pResult = 0; }
void CPopupFeatureDlg::OnNMReleasedcaptureSliderValue5(NMHDR *pNMHDR, LRESULT *pResult) { OnSliderBarClicked(5); *pResult = 0; }
void CPopupFeatureDlg::OnNMReleasedcaptureSliderValue6(NMHDR *pNMHDR, LRESULT *pResult) { OnSliderBarClicked(6); *pResult = 0; }
void CPopupFeatureDlg::OnNMReleasedcaptureSliderValue7(NMHDR *pNMHDR, LRESULT *pResult) { OnSliderBarClicked(7); *pResult = 0; }
void CPopupFeatureDlg::OnNMReleasedcaptureSliderValue8(NMHDR *pNMHDR, LRESULT *pResult) { OnSliderBarClicked(8); *pResult = 0; }
void CPopupFeatureDlg::OnNMReleasedcaptureSliderValue9(NMHDR *pNMHDR, LRESULT *pResult) { OnSliderBarClicked(9); *pResult = 0; }
void CPopupFeatureDlg::OnNMReleasedcaptureSliderValue10(NMHDR *pNMHDR, LRESULT *pResult) { OnSliderBarClicked(10); *pResult = 0; }
void CPopupFeatureDlg::OnNMReleasedcaptureSliderValue11(NMHDR *pNMHDR, LRESULT *pResult) { OnSliderBarClicked(11); *pResult = 0; }
void CPopupFeatureDlg::OnNMReleasedcaptureSliderValue12(NMHDR *pNMHDR, LRESULT *pResult) { OnSliderBarClicked(12); *pResult = 0; }
void CPopupFeatureDlg::OnNMReleasedcaptureSliderValue13(NMHDR *pNMHDR, LRESULT *pResult) { OnSliderBarClicked(13); *pResult = 0; }
void CPopupFeatureDlg::OnNMReleasedcaptureSliderValue14(NMHDR *pNMHDR, LRESULT *pResult) { OnSliderBarClicked(14); *pResult = 0; }
void CPopupFeatureDlg::OnNMReleasedcaptureSliderValue15(NMHDR *pNMHDR, LRESULT *pResult) { OnSliderBarClicked(15); *pResult = 0; }
void CPopupFeatureDlg::OnNMReleasedcaptureSliderValue16(NMHDR *pNMHDR, LRESULT *pResult) { OnSliderBarClicked(16); *pResult = 0; }
void CPopupFeatureDlg::OnNMReleasedcaptureSliderValue17(NMHDR *pNMHDR, LRESULT *pResult) { OnSliderBarClicked(17); *pResult = 0; }
void CPopupFeatureDlg::OnNMReleasedcaptureSliderValue18(NMHDR *pNMHDR, LRESULT *pResult) { OnSliderBarClicked(18); *pResult = 0; }
void CPopupFeatureDlg::OnNMReleasedcaptureSliderValue19(NMHDR *pNMHDR, LRESULT *pResult) { OnSliderBarClicked(19); *pResult = 0; }
void CPopupFeatureDlg::OnNMReleasedcaptureSliderValue20(NMHDR *pNMHDR, LRESULT *pResult) { OnSliderBarClicked(20); *pResult = 0; }
void CPopupFeatureDlg::OnNMReleasedcaptureSliderValue21(NMHDR *pNMHDR, LRESULT *pResult) { OnSliderBarClicked(21); *pResult = 0; }
void CPopupFeatureDlg::OnNMReleasedcaptureSliderValue22(NMHDR *pNMHDR, LRESULT *pResult) { OnSliderBarClicked(22); *pResult = 0; }
void CPopupFeatureDlg::OnNMReleasedcaptureSliderValue23(NMHDR *pNMHDR, LRESULT *pResult) { OnSliderBarClicked(23); *pResult = 0; }
#pragma endregion

void CPopupFeatureDlg::OnEditBoxKeyDown(int nIndex, BOOL bEnter)
{
	if (m_pCameraHandle)
	{
		if (m_arrMapping[nIndex] == NEPTUNE_FEATURE_GAMMA) {
			CString strValue = _T("");
			m_edValue[nIndex].GetWindowText(strValue);

			NEPTUNE_XML_NODE_INFO stNodeInfo;
			ntcGetNodeInfo(m_pCameraHandle, "Gamma", &stNodeInfo);
			if (stNodeInfo.Type == NEPTUNE_NODE_TYPE_INT) {
				NEPTUNE_XML_INT_VALUE_INFO stValueInfo;
				ntcGetNodeInt(m_pCameraHandle, "Gamma", &stValueInfo);
				int nValue = _ttoi(strValue);
				if (nValue < stValueInfo.nMin) {
					nValue = stValueInfo.nMin;
				}
				if (nValue > stValueInfo.nMax) {
					nValue = stValueInfo.nMax;
				}
				ntcSetNodeInt(m_pCameraHandle, "Gamma", nValue);
				m_sdValue[nIndex].SetPos(nValue);
			} else {
				NEPTUNE_XML_FLOAT_VALUE_INFO stValueInfo;
				ntcGetNodeFloat(m_pCameraHandle, "Gamma", &stValueInfo);
				FLOAT fValue = _ttof(strValue);
				if (fValue < stValueInfo.dMin) {
					fValue = stValueInfo.dMin;
				}
				if (fValue > stValueInfo.dMax) {
					fValue = stValueInfo.dMax;
				}
				LONG nlVal = (LONG)(fValue * 1000);
				LONG nlInc = (LONG)(stValueInfo.dInc * 1000);
				LONG nlRemain = nlVal % nlInc;
				if (nlRemain != 0) {
					LONG nlHalfInc = (LONG)(nlInc / 2);
					if (nlRemain > nlHalfInc) {
						fValue = (FLOAT)(nlVal + (nlInc - nlRemain)) / 1000.0;
					} else {
						fValue = (FLOAT)(nlVal - nlRemain) / 1000.0;
					}
				}
				ntcSetNodeFloat(m_pCameraHandle, "Gamma", fValue);
				m_sdValue[nIndex].SetPos(fValue * 1000);
				CString strText = _T("");
				strText.Format(_T("%0.3f"), fValue);
				m_edValue[nIndex].SetWindowText(strText);
			}
		} else {
			NEPTUNE_FEATURE stInfo;
			memcpy(&stInfo, &m_arrFeatureInfo[nIndex], sizeof(NEPTUNE_FEATURE));

			CString strValue = _T("");
			m_edValue[nIndex].GetWindowText(strValue);
			stInfo.Value = _ttoi(strValue);
			if (stInfo.Value < stInfo.Min)
			{
				stInfo.Value = stInfo.Min;
			}
			if (stInfo.Value > stInfo.Max)
			{
				stInfo.Value = stInfo.Max;
			}
			ENeptuneError emErr = ntcSetFeature(m_pCameraHandle, m_arrMapping[nIndex], stInfo);
			if (emErr == NEPTUNE_ERR_Success)
			{
				memcpy(&m_arrFeatureInfo[nIndex], &stInfo, sizeof(NEPTUNE_FEATURE));
				strValue.Format(_T("%d"), m_arrFeatureInfo[nIndex].Value);
				m_edValue[nIndex].SetWindowText(strValue);
				m_sdValue[nIndex].SetPos(m_arrFeatureInfo[nIndex].Value);
			}
			else
			{
				strValue.Format(_T("%d"), m_arrFeatureInfo[nIndex].Value);
				m_edValue[nIndex].SetWindowText(strValue);
				InsertLog(TYPE_ERROR, _T("ntcSetFeature Failed."), emErr);
			}
		}
	}
}

void CPopupFeatureDlg::OnCbnSelchangeComboWhiteBalance()
{
	if (m_pCameraHandle)
	{
		NEPTUNE_FEATURE stInfo;
		stInfo.AutoMode = (ENeptuneAutoMode)m_cbWhiteBalance.GetItemData(m_cbWhiteBalance.GetCurSel());
		ENeptuneError emErr = ntcSetFeature(m_pCameraHandle, NEPTUNE_FEATURE_WHITEBALANCE, stInfo);
		if (emErr == NEPTUNE_ERR_Success)
		{
			if (stInfo.AutoMode == NEPTUNE_AUTO_ONCE)
			{
				for (int i = 0; i < m_cbWhiteBalance.GetCount(); i++)
				{
					if ((ENeptuneAutoMode)m_cbWhiteBalance.GetItemData(i) == NEPTUNE_AUTO_OFF)
					{
						m_cbWhiteBalance.SetCurSel(i);
						break;
					}
				}
			}

			for (int i = 0; i < MAX_ARRAY_COUNT; i++)
			{
				if (m_arrMapping[i] == NEPTUNE_FEATURE_RGAIN ||
					m_arrMapping[i] == NEPTUNE_FEATURE_GGAIN ||
					m_arrMapping[i] == NEPTUNE_FEATURE_BGAIN)
				{
					NEPTUNE_FEATURE stInfoEx;
					ntcGetFeature(m_pCameraHandle, m_arrMapping[i], &stInfoEx);
					BOOL bIsAccess = (stInfoEx.ValueAccessMode == NEPTUNE_NODE_ACCESSMODE_RW || stInfoEx.ValueAccessMode == NEPTUNE_NODE_ACCESSMODE_WO);
					m_sdValue[i].EnableWindow(bIsAccess);
					m_edValue[i].EnableWindow(bIsAccess);
				}
			}
		}
		else
		{
			InsertLog(TYPE_ERROR, _T("ntcSetFeature Failed."), emErr);
		}
	}
}

void CPopupFeatureDlg::OnBnClickedButtonDefualt()
{
	if (m_pCameraHandle)
	{
		NEPTUNE_USERSET stUserSet;
		stUserSet.Command = NEPTUNE_USERSET_CMD_LOAD;
		stUserSet.UserSetIndex = NEPTUNE_USERSET_DEFAULT;
		ENeptuneError emErr = ntcSetUserSet(m_pCameraHandle, stUserSet);
		if (emErr == NEPTUNE_ERR_Success)
		{
			UpdateDialog();
		}
		else
		{
			InsertLog(TYPE_ERROR, _T("ntcSetUserSet Failed."), emErr);
		}
	}
}
