// PopupStackedROIDlg.cpp : 구현 파일입니다.
//

#include "stdafx.h"
#include "NeptuneCSample.h"
#include "PopupStackedROIDlg.h"
#include "afxdialogex.h"


// CPopupStackedROIDlg 대화 상자입니다.

IMPLEMENT_DYNAMIC(CPopupStackedROIDlg, CPopupBaseDialog)

CPopupStackedROIDlg::CPopupStackedROIDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis)
	: CPopupBaseDialog(CPopupStackedROIDlg::IDD, pCameraHandle, ppThis)
{

}

CPopupStackedROIDlg::~CPopupStackedROIDlg()
{
}

void CPopupStackedROIDlg::DoDataExchange(CDataExchange* pDX)
{
	CPopupBaseDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_CHECK_CONTROL, m_btnControl);
	DDX_Control(pDX, IDC_COMBO_SELECTOR, m_cbIndex);
	DDX_Control(pDX, IDC_CHECK_ENABLE, m_btnEnable);
	DDX_Control(pDX, IDC_EDIT_OFFSET_X, m_edOffsetX);
	DDX_Control(pDX, IDC_EDIT_OFFSET_Y, m_edOffsetY);
	DDX_Control(pDX, IDC_EDIT_WIDTH, m_edWidth);
	DDX_Control(pDX, IDC_EDIT_HEIGHT, m_edHeight);
	DDX_Control(pDX, IDC_EDIT_ALL_OFFSET_X, m_edAllOffsetX);
	DDX_Control(pDX, IDC_EDIT_ALL_WIDTH, m_edAllWidth);
}


BEGIN_MESSAGE_MAP(CPopupStackedROIDlg, CPopupBaseDialog)
	ON_BN_CLICKED(IDC_CHECK_CONTROL, &CPopupStackedROIDlg::OnBnClickedCheckControl)
	ON_CBN_SELCHANGE(IDC_COMBO_SELECTOR, &CPopupStackedROIDlg::OnCbnSelchangeComboSelector)
	ON_BN_CLICKED(IDC_BUTTON_SET_ALL_OFFSET_X, &CPopupStackedROIDlg::OnBnClickedButtonSetAllOffsetX)
	ON_BN_CLICKED(IDC_BUTTON_SET_ALL_WIDTH, &CPopupStackedROIDlg::OnBnClickedButtonSetAllWidth)
	ON_BN_CLICKED(IDC_BUTTON_APPLY, &CPopupStackedROIDlg::OnBnClickedButtonApply)
END_MESSAGE_MAP()


// CPopupStackedROIDlg 메시지 처리기입니다.
void CPopupStackedROIDlg::InitControls()
{
	CString strText;
	for (int i=0; i<8; i++)
	{
		strText.Format(_T("%d"), i);
		m_cbIndex.InsertString(i, strText);
	}
}

void CPopupStackedROIDlg::UpdateDialog()
{
	GetStackedROIControl();
	GetSelectedStackedROI();
	GetStackedROIOffsetX();
	GetStackedROIWidth();
	GetSelectedStackedROIInfo();
}

void CPopupStackedROIDlg::OnBnClickedCheckControl()
{
	CNeptuneContinuePlay continuePlay(m_pCameraHandle);

	int iCheck = m_btnControl.GetCheck();
	ENeptuneBoolean bControl = iCheck == BST_CHECKED ? NEPTUNE_BOOL_TRUE : NEPTUNE_BOOL_FALSE;
	ENeptuneError err = ntcSetStackedRoiControl(m_pCameraHandle, bControl);
	if (err != NEPTUNE_ERR_Success)
	{
		InsertLog(TYPE_ERROR, _T("ntcSetStackedRoiControl Failed"), err);
		GetStackedROIControl();
	}
}


void CPopupStackedROIDlg::OnCbnSelchangeComboSelector()
{
	int iSel = m_cbIndex.GetCurSel();
	if (iSel != CB_ERR)
	{
		ENeptuneError err = ntcSetStackedRoiSelector(m_pCameraHandle, iSel);
		if (err == NEPTUNE_ERR_Success)
		{
			GetSelectedStackedROIInfo();
		}
		else
		{
			InsertLog(TYPE_ERROR, _T("ntcSetStackedRoiSelector Failed"), err);
			GetSelectedStackedROI();			
		}
	}
}


void CPopupStackedROIDlg::GetStackedROIControl()
{
	ENeptuneBoolean bControl = NEPTUNE_BOOL_FALSE;
	ENeptuneError err = ntcGetStackedRoiControl(m_pCameraHandle, &bControl);
	if (err != NEPTUNE_ERR_Success)
	{
		InsertLog(TYPE_ERROR, _T("ntcGetStackedRoiControl Failed"), err);
	}
	m_btnControl.SetCheck(bControl == NEPTUNE_BOOL_TRUE ? BST_CHECKED : BST_UNCHECKED);
}

void CPopupStackedROIDlg::GetStackedROIOffsetX()
{
	ENeptuneError err = NEPTUNE_ERR_Success;

	_uint32_t uiOffsetX = 0;

	int iSel = m_cbIndex.GetCurSel();
	int iCnt = m_cbIndex.GetCount();

	for (int i = 0; i < iCnt; i++)
	{
		err = ntcSetStackedRoiSelector(m_pCameraHandle, i);
		if (err == NEPTUNE_ERR_Success)
		{
			ENeptuneBoolean bEnable = NEPTUNE_BOOL_FALSE;
			err = ntcGetStackedRoiSelectedEnable(m_pCameraHandle, &bEnable);
			if (err == NEPTUNE_ERR_Success)
			{
				if (bEnable == NEPTUNE_BOOL_TRUE)
				{
					err = ntcGetStackedRoiOffsetX(m_pCameraHandle, &uiOffsetX);
					if (err == NEPTUNE_ERR_Success)
					{
						break;
					}
				}
			}
		}
	}
	ntcSetStackedRoiSelector(m_pCameraHandle, iSel);

	CString strText;
	strText.Format(_T("%d"), uiOffsetX);
	m_edAllOffsetX.SetWindowText(strText);
}

void CPopupStackedROIDlg::GetStackedROIWidth()
{
	ENeptuneError err = NEPTUNE_ERR_Success;

	_uint32_t uiWidth = 0;

	int iSel = m_cbIndex.GetCurSel();
	int iCnt = m_cbIndex.GetCount();

	for (int i = 0; i < iCnt; i++)
	{
		err = ntcSetStackedRoiSelector(m_pCameraHandle, i);
		if (err == NEPTUNE_ERR_Success)
		{
			ENeptuneBoolean bEnable = NEPTUNE_BOOL_FALSE;
			err = ntcGetStackedRoiSelectedEnable(m_pCameraHandle, &bEnable);
			if (err == NEPTUNE_ERR_Success)
			{
				if (bEnable == NEPTUNE_BOOL_TRUE)
				{
					
					err = ntcGetStackedRoiWidth(m_pCameraHandle, &uiWidth);
					if (err == NEPTUNE_ERR_Success)
					{
						break;
					}
				}
			}
		}
	}
	ntcSetStackedRoiSelector(m_pCameraHandle, iSel);

	CString strText;
	strText.Format(_T("%d"), uiWidth);
	m_edAllWidth.SetWindowText(strText);
}

void CPopupStackedROIDlg::GetSelectedStackedROI()
{
	_uint32_t uiIdx = 0;
	ENeptuneError err = ntcGetStackedRoiSelector(m_pCameraHandle, &uiIdx);
	if (err != NEPTUNE_ERR_Success)
	{
		InsertLog(TYPE_ERROR, _T("ntcGetStackedRoiSelector Failed"), err);
	}
	m_cbIndex.SetCurSel(uiIdx);
}

void CPopupStackedROIDlg::GetSelectedStackedROIInfo()
{
	ENeptuneBoolean bEnable = NEPTUNE_BOOL_FALSE;
	_uint32_t uiOffsetX = 0;
	_uint32_t uiOffsetY = 0;
	_uint32_t uiWidth = 0;
	_uint32_t uiHeight = 0;
	ENeptuneError err = NEPTUNE_ERR_Success;
	
	err = ntcGetStackedRoiSelectedEnable(m_pCameraHandle, &bEnable);
	if (err != NEPTUNE_ERR_Success)
	{
		InsertLog(TYPE_ERROR, _T("ntcGetStackedRoiSelectedEnable Failed"), err);
	}

	err = ntcGetStackedRoiOffsetX(m_pCameraHandle, &uiOffsetX);
	if (err != NEPTUNE_ERR_Success)
	{
		InsertLog(TYPE_ERROR, _T("ntcGetStackedRoiOffsetX Failed"), err);
	}

	err = ntcGetStackedRoiOffsetY(m_pCameraHandle, &uiOffsetY);
	if (err != NEPTUNE_ERR_Success)
	{
		InsertLog(TYPE_ERROR, _T("ntcGetStackedRoiOffsetY Failed"), err);
	}

	err = ntcGetStackedRoiWidth(m_pCameraHandle, &uiWidth);
	if (err != NEPTUNE_ERR_Success)
	{
		InsertLog(TYPE_ERROR, _T("ntcGetStackedRoiWidth Failed"), err);
	}

	err = ntcGetStackedRoiHeight(m_pCameraHandle, &uiHeight);
	if (err != NEPTUNE_ERR_Success)
	{
		InsertLog(TYPE_ERROR, _T("ntcGetStackedRoiHeight Failed"), err);
	}
	
	m_btnEnable.SetCheck(bEnable == NEPTUNE_BOOL_TRUE ? BST_CHECKED : BST_UNCHECKED);
	CString strText;
	strText.Format(_T("%d"), uiOffsetX);
	m_edOffsetX.SetWindowText(strText);
	strText.Format(_T("%d"), uiOffsetY);
	m_edOffsetY.SetWindowText(strText);
	strText.Format(_T("%d"), uiWidth);
	m_edWidth.SetWindowText(strText);
	strText.Format(_T("%d"), uiHeight);
	m_edHeight.SetWindowText(strText);

	if (bEnable == NEPTUNE_BOOL_TRUE)
	{
		GetStackedROIOffsetX();
		GetStackedROIWidth();
	}
}


void CPopupStackedROIDlg::OnBnClickedButtonSetAllOffsetX()
{
	CNeptuneContinuePlay continuePlay(m_pCameraHandle);

	CString strText;
	m_edAllOffsetX.GetWindowText(strText);
	int iOffsetX = _ttoi(strText);
	ENeptuneError err = ntcSetStackedRoiOffsetXAll(m_pCameraHandle, iOffsetX);
	if (err == NEPTUNE_ERR_Success)
	{
		GetSelectedStackedROIInfo();
	}
	else
	{
		InsertLog(TYPE_ERROR, _T("ntcSetStackedRoiOffsetXAll Failed"), err);
	}

	GetStackedROIOffsetX();
}


void CPopupStackedROIDlg::OnBnClickedButtonSetAllWidth()
{
	CNeptuneContinuePlay continuePlay(m_pCameraHandle);

	CString strText;
	m_edAllWidth.GetWindowText(strText);
	int iWidth = _ttoi(strText);
	ENeptuneError err = ntcSetStackedRoiWidthAll(m_pCameraHandle, iWidth);
	if (err == NEPTUNE_ERR_Success)
	{
		GetSelectedStackedROIInfo();
	}
	else
	{
		InsertLog(TYPE_ERROR, _T("ntcSetStackedRoiWidthAll Failed"), err);
	}

	GetStackedROIWidth();
}


void CPopupStackedROIDlg::OnBnClickedButtonApply()
{
	CNeptuneContinuePlay continuePlay(m_pCameraHandle);

	CString strText;

	m_edOffsetX.GetWindowText(strText);
	_uint32_t uiOffsetX = _ttoi(strText);
	m_edOffsetY.GetWindowText(strText);
	_uint32_t uiOffsetY = _ttoi(strText);	
	m_edWidth.GetWindowText(strText);
	_uint32_t uiWidth = _ttoi(strText);
	m_edHeight.GetWindowText(strText);
	_uint32_t uiHeight = _ttoi(strText);

	int iCheck = m_btnEnable.GetCheck();
	ENeptuneBoolean bEnable = iCheck == BST_CHECKED ? NEPTUNE_BOOL_TRUE : NEPTUNE_BOOL_FALSE;

	ENeptuneError err = NEPTUNE_ERR_Success;

	err = ntcSetStackedRoiOffsetX(m_pCameraHandle, uiOffsetX);
	if (err != NEPTUNE_ERR_Success)
	{
		InsertLog(TYPE_ERROR, _T("ntcSetStackedRoiOffsetX Failed"), err);
	}

	err = ntcSetStackedRoiOffsetY(m_pCameraHandle, uiOffsetY);
	if (err != NEPTUNE_ERR_Success)
	{
		InsertLog(TYPE_ERROR, _T("ntcSetStackedRoiOffsetY Failed"), err);
	}

	err = ntcSetStackedRoiWidth(m_pCameraHandle, uiWidth);
	if (err != NEPTUNE_ERR_Success)
	{
		InsertLog(TYPE_ERROR, _T("ntcSetStackedRoiWidth Failed"), err);
	}

	err = ntcSetStackedRoiHeight(m_pCameraHandle, uiHeight);
	if (err != NEPTUNE_ERR_Success)
	{
		InsertLog(TYPE_ERROR, _T("ntcSetStackedRoiHeight Failed"), err);
	}

	err = ntcSetStackedRoiSelectedEnable(m_pCameraHandle, bEnable);
	if (err != NEPTUNE_ERR_Success)
	{
		InsertLog(TYPE_ERROR, _T("ntcSetStackedRoiSelectedEnable Failed"), err);
	}

	GetSelectedStackedROIInfo();
	GetStackedROIOffsetX();
	GetStackedROIWidth();
}
