// PopupResolutionDlg.cpp : 구현 파일입니다.
//

#include "stdafx.h"
#include "NeptuneCSample.h"
#include "PopupResolutionDlg.h"
#include "afxdialogex.h"


// CPopupResolutionDlg 대화 상자입니다.

IMPLEMENT_DYNAMIC(CPopupResolutionDlg, CPopupBaseDialog)

CPopupResolutionDlg::CPopupResolutionDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis)
	: CPopupBaseDialog(CPopupResolutionDlg::IDD, pCameraHandle, ppThis)
	, m_strResolution(_T("Resolution : Width x Height"))
	, m_nlOffsetX(0)
	, m_nlOffsetY(0)
	, m_nlWidth(0)
	, m_nlHeight(0)
{

}

CPopupResolutionDlg::~CPopupResolutionDlg()
{
}

void CPopupResolutionDlg::DoDataExchange(CDataExchange* pDX)
{
	CPopupBaseDialog::DoDataExchange(pDX);
	DDX_Text(pDX, IDC_STATIC_RESOLUTION, m_strResolution);
	DDX_Text(pDX, IDC_EDIT_OFFSET_X, m_nlOffsetX);
	DDX_Text(pDX, IDC_EDIT_OFFSET_Y, m_nlOffsetY);
	DDX_Text(pDX, IDC_EDIT_WIDTH, m_nlWidth);
	DDX_Text(pDX, IDC_EDIT_HEIGHT, m_nlHeight);
}


BEGIN_MESSAGE_MAP(CPopupResolutionDlg, CPopupBaseDialog)
	ON_BN_CLICKED(IDC_BUTTON_APPLY, &CPopupResolutionDlg::OnBnClickedButtonApply)
END_MESSAGE_MAP()

void CPopupResolutionDlg::UpdateDialog()
{
	m_nlOffsetX = 0;
	m_nlOffsetY = 0;
	m_nlWidth = 0;
	m_nlHeight = 0;
	if (m_pCameraHandle)
	{
		NEPTUNE_IMAGE_SIZE stImageSize;
		ENeptuneError emErr = ntcGetMaxImageSize(m_pCameraHandle, &stImageSize);
		if (emErr == NEPTUNE_ERR_Success)
		{
			m_strResolution.Format(_T("Resolution: %d x %d"), stImageSize.nSizeX, stImageSize.nSizeY);
			emErr = ntcGetImageSize(m_pCameraHandle, &stImageSize);
			if (emErr == NEPTUNE_ERR_Success)
			{
				m_nlOffsetX = stImageSize.nStartX;
				m_nlOffsetY = stImageSize.nStartY;
				m_nlWidth = stImageSize.nSizeX;
				m_nlHeight = stImageSize.nSizeY;
			}
			else
			{
				InsertLog(TYPE_ERROR, _T("ntcGetImageSize Failed."), emErr);
			}
		}
		else
		{
			InsertLog(TYPE_ERROR, _T("ntcGetMaxImageSize Failed."), emErr);
		}
	}
	UpdateData(FALSE);
}

void CPopupResolutionDlg::OnBnClickedButtonApply()
{
	UpdateData(TRUE);
	if (m_pCameraHandle)
	{
		NEPTUNE_IMAGE_SIZE stImageSize;
		stImageSize.nStartX = m_nlOffsetX;
		stImageSize.nStartY = m_nlOffsetY;
		stImageSize.nSizeX = m_nlWidth;
		stImageSize.nSizeY = m_nlHeight;
		ENeptuneError emErr = ntcSetImageSize(m_pCameraHandle, stImageSize);
		if (emErr != NEPTUNE_ERR_Success)
		{
			InsertLog(TYPE_ERROR, _T("ntcSetImageSize Failed."), emErr);
			UpdateDialog();
		}
		
		emErr = ntcGetImageSize(m_pCameraHandle, &stImageSize);
		if (emErr == NEPTUNE_ERR_Success)
		{
			m_nlOffsetX = stImageSize.nStartX;
			m_nlOffsetY = stImageSize.nStartY;
			m_nlWidth = stImageSize.nSizeX;
			m_nlHeight = stImageSize.nSizeY;
		}
		else
		{
			InsertLog(TYPE_ERROR, _T("ntcGetImageSize Failed."), emErr);
		}
	}

	UpdateData(FALSE);
}
