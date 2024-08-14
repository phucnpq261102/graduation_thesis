// PopupBaseDialog.cpp : 구현 파일입니다.
//

#include "stdafx.h"
#include "NeptuneCSample.h"
#include "PopupBaseDialog.h"
#include "afxdialogex.h"

#include "NeptuneCSampleDlg.h"

IMPLEMENT_DYNAMIC(CPopupBaseDialog, CDialogEx)

CPopupBaseDialog::CPopupBaseDialog(UINT ulIDTemplate, NeptuneCamHandle& pCameraHandle, CWnd** ppThis)
	: CDialogEx(ulIDTemplate, NULL)
	, m_pCameraHandle(pCameraHandle)
	, m_ppThis(ppThis)
{

}

CPopupBaseDialog::~CPopupBaseDialog()
{
}

void CPopupBaseDialog::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}


BEGIN_MESSAGE_MAP(CPopupBaseDialog, CDialogEx)
	ON_WM_NCDESTROY()
	ON_WM_CLOSE()
END_MESSAGE_MAP()

BOOL CPopupBaseDialog::PreTranslateMessage(MSG* pMsg)
{
	if (pMsg->message == WM_KEYDOWN)
	{
		if (pMsg->wParam == VK_RETURN || pMsg->wParam == VK_ESCAPE)
		{
			return TRUE;
		}
	}
	return CDialogEx::PreTranslateMessage(pMsg);
}

BOOL CPopupBaseDialog::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	InitControls();
	UpdateDialog();

	return TRUE;
}

void CPopupBaseDialog::OnNcDestroy()
{
	CDialogEx::OnNcDestroy();
	if (*m_ppThis)
	{
		*m_ppThis = NULL;
	}
	delete this;
}

void CPopupBaseDialog::OnClose()
{
	DestroyWindow();
}

void CPopupBaseDialog::OnOK()
{
	DestroyWindow();
}

void CPopupBaseDialog::OnCancel()
{
	DestroyWindow();
}

void CPopupBaseDialog::InsertLog(EM_LOG_LEVEL emLevel, CString strMessage, ENeptuneError emErr /*= NEPTUNE_ERR_Success*/)
{
	CNeptuneCSampleDlg* pMainDlg = (CNeptuneCSampleDlg*)AfxGetMainWnd();
	if (pMainDlg)
	{
		pMainDlg->InsertLog(emLevel, strMessage, emErr);
	}
}

void CPopupBaseDialog::UpdateCameraInfo()
{
	CNeptuneCSampleDlg* pMainDlg = (CNeptuneCSampleDlg*)AfxGetMainWnd();
	if (pMainDlg)
	{
		pMainDlg->UpdateCameraInfo();
	}
}

void CPopupBaseDialog::UpdatePopupDialogs()
{
	CNeptuneCSampleDlg* pMainDlg = (CNeptuneCSampleDlg*)AfxGetMainWnd();
	if (pMainDlg)
	{
		pMainDlg->UpdatePopupDialogs((WPARAM)FALSE, NULL);
	}
}



