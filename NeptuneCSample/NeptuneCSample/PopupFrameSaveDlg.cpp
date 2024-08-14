// PopupFrameSaveDlg.cpp : 구현 파일입니다.
//

#include "stdafx.h"
#include "NeptuneCSample.h"
#include "PopupFrameSaveDlg.h"
#include "afxdialogex.h"


// CPopupFrameSaveDlg 대화 상자입니다.

IMPLEMENT_DYNAMIC(CPopupFrameSaveDlg, CPopupBaseDialog)

CPopupFrameSaveDlg::CPopupFrameSaveDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis)
	: CPopupBaseDialog(CPopupFrameSaveDlg::IDD, pCameraHandle, ppThis)
{

}

CPopupFrameSaveDlg::~CPopupFrameSaveDlg()
{
}

void CPopupFrameSaveDlg::DoDataExchange(CDataExchange* pDX)
{
	CPopupBaseDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_CHECK_ENABLE, m_ckEnable);
	DDX_Control(pDX, IDC_EDIT_REMAINED_IMAGE, m_edRemainCount);
	DDX_Control(pDX, IDC_EDIT_RECEIVE_IMAGE, m_edReceiveCount);
}


BEGIN_MESSAGE_MAP(CPopupFrameSaveDlg, CPopupBaseDialog)
	ON_BN_CLICKED(IDC_CHECK_ENABLE, &CPopupFrameSaveDlg::OnBnClickedCheckEnable)
	ON_BN_CLICKED(IDC_BUTTON_REFRESH, &CPopupFrameSaveDlg::OnBnClickedButtonRefresh)
	ON_BN_CLICKED(IDC_BUTTON_PLAY, &CPopupFrameSaveDlg::OnBnClickedButtonPlay)
END_MESSAGE_MAP()

void CPopupFrameSaveDlg::UpdateDialog()
{
	if (m_pCameraHandle)
	{
		ENeptuneBoolean emOnOff = NEPTUNE_BOOL_FALSE;
		_uint32_t uiFrameRemained = 0;
		ENeptuneError emErr = ntcGetFrameSave(m_pCameraHandle, &emOnOff, &uiFrameRemained);
		if (emErr == NEPTUNE_ERR_Success)
		{
			m_ckEnable.SetCheck((emOnOff == NEPTUNE_BOOL_TRUE) ? BST_CHECKED : BST_UNCHECKED);
			CString strValue = _T("");
			strValue.Format(_T("%d"), uiFrameRemained);
			m_edRemainCount.SetWindowText(strValue);
		}
		else
		{
			InsertLog(TYPE_ERROR, _T("ntcGetFrameSave Failed."), emErr);
		}
	}
}

void CPopupFrameSaveDlg::OnBnClickedCheckEnable()
{
	if (m_pCameraHandle)
	{
		ENeptuneBoolean emOnOff = (m_ckEnable.GetCheck() == BST_CHECKED) ? NEPTUNE_BOOL_TRUE : NEPTUNE_BOOL_FALSE;
		ENeptuneError emErr = ntcSetFrameSave(m_pCameraHandle, emOnOff, NEPTUNE_BOOL_FALSE, 0);
		if (emErr != NEPTUNE_ERR_Success)
		{
			InsertLog(TYPE_ERROR, _T("ntcSetFrameSave Failed."), emErr);
		}
	}
}

void CPopupFrameSaveDlg::OnBnClickedButtonRefresh()
{
	UpdateDialog();
}

void CPopupFrameSaveDlg::OnBnClickedButtonPlay()
{
	if (m_pCameraHandle)
	{
		ENeptuneBoolean emOnOff = (m_ckEnable.GetCheck() == BST_CHECKED) ? NEPTUNE_BOOL_TRUE : NEPTUNE_BOOL_FALSE;
		CString strValue = _T("");
		m_edReceiveCount.GetWindowText(strValue);
		_uint32_t uiFrameRemained = _ttoi(strValue);
		ENeptuneError emErr = ntcSetFrameSave(m_pCameraHandle, emOnOff, NEPTUNE_BOOL_TRUE, uiFrameRemained);
		if (emErr != NEPTUNE_ERR_Success)
		{
			InsertLog(TYPE_ERROR, _T("ntcSetFrameSave Failed."), emErr);
		}
	}
}
