// PopupAutoFocusDlg.cpp : 구현 파일입니다.
//

#include "stdafx.h"
#include "NeptuneCSample.h"
#include "PopupAutoFocusDlg.h"
#include "afxdialogex.h"


// CPopupAutoFocusDlg 대화 상자입니다.

IMPLEMENT_DYNAMIC(CPopupAutoFocusDlg, CPopupBaseDialog)

CPopupAutoFocusDlg::CPopupAutoFocusDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis)
	: CPopupBaseDialog(CPopupAutoFocusDlg::IDD, pCameraHandle, ppThis)
{

}

CPopupAutoFocusDlg::~CPopupAutoFocusDlg()
{
}

void CPopupAutoFocusDlg::DoDataExchange(CDataExchange* pDX)
{
	CPopupBaseDialog::DoDataExchange(pDX);
}


BEGIN_MESSAGE_MAP(CPopupAutoFocusDlg, CPopupBaseDialog)
	ON_BN_CLICKED(IDC_BUTTON_ORIGIN_POINT, &CPopupAutoFocusDlg::OnBnClickedButtonOriginPoint)
	ON_BN_CLICKED(IDC_BUTTON_ONE_PUSH_AUTO, &CPopupAutoFocusDlg::OnBnClickedButtonOnePushAuto)
	ON_BN_CLICKED(IDC_BUTTON_ONE_SETUP_FORWARD, &CPopupAutoFocusDlg::OnBnClickedButtonOneSetupForward)
	ON_BN_CLICKED(IDC_BUTTON_ONE_STEP_BACKWARD, &CPopupAutoFocusDlg::OnBnClickedButtonOneStepBackward)
END_MESSAGE_MAP()


void CPopupAutoFocusDlg::OnBnClickedButtonOriginPoint()
{
	if (m_pCameraHandle)
	{
		ENeptuneError emErr = ntcSetAFControl(m_pCameraHandle, NEPTUNE_AF_ORIGIN);
		if (emErr == NEPTUNE_ERR_Success)
		{
			InsertLog(TYPE_INFORMATION, _T("Set Auto Focus: ORIGIN."));
		}
		else
		{
			InsertLog(TYPE_ERROR, _T("ntcSetAFControl Failed."), emErr);
		}
	}
}

void CPopupAutoFocusDlg::OnBnClickedButtonOnePushAuto()
{
	if (m_pCameraHandle)
	{
		ENeptuneError emErr = ntcSetAFControl(m_pCameraHandle, NEPTUNE_AF_ONEPUSH);
		if (emErr == NEPTUNE_ERR_Success)
		{
			InsertLog(TYPE_INFORMATION, _T("Set Auto Focus: ONEPUSH."));
		}
		else
		{
			InsertLog(TYPE_ERROR, _T("ntcSetAFControl Failed."), emErr);
		}
	}
}

void CPopupAutoFocusDlg::OnBnClickedButtonOneSetupForward()
{
	if (m_pCameraHandle)
	{
		ENeptuneError emErr = ntcSetAFControl(m_pCameraHandle, NEPTUNE_AF_STEP_FORWARD);
		if (emErr == NEPTUNE_ERR_Success)
		{
			InsertLog(TYPE_INFORMATION, _T("Set Auto Focus: STEP FORWARD."));
		}
		else
		{
			InsertLog(TYPE_ERROR, _T("ntcSetAFControl Failed."), emErr);
		}
	}
}

void CPopupAutoFocusDlg::OnBnClickedButtonOneStepBackward()
{
	if (m_pCameraHandle)
	{
		ENeptuneError emErr = ntcSetAFControl(m_pCameraHandle, NEPTUNE_AF_STEP_BACKWARD);
		if (emErr == NEPTUNE_ERR_Success)
		{
			InsertLog(TYPE_INFORMATION, _T("Set Auto Focus: STEP BACKWARD."));
		}
		else
		{
			InsertLog(TYPE_ERROR, _T("ntcSetAFControl Failed."), emErr);
		}
	}
}
