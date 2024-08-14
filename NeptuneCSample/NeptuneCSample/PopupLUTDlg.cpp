// PopupLUTDlg.cpp : 구현 파일입니다.
//

#include "stdafx.h"
#include "NeptuneCSample.h"
#include "PopupLUTDlg.h"
#include "afxdialogex.h"


// CPopupLUTDlg 대화 상자입니다.

IMPLEMENT_DYNAMIC(CPopupLUTDlg, CPopupBaseDialog)

CPopupLUTDlg::CPopupLUTDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis)
	: CPopupBaseDialog(CPopupLUTDlg::IDD, pCameraHandle, ppThis)
	, m_sizeMaxLut(4095, 4095)
	, m_wndLut(m_sizeMaxLut, &m_edPointX[0], &m_edPointY[0], &m_edPointX[1], &m_edPointY[1], &m_edPointX[2], &m_edPointY[2], &m_edPointX[3], &m_edPointY[3])
	, m_b4StepLUTEnable(FALSE)
	, m_bUserLUTEnable(FALSE)
{
	ZeroMemory(&m_nlPointX, sizeof(m_nlPointX));
	ZeroMemory(&m_nlPointY, sizeof(m_nlPointY));
}

CPopupLUTDlg::~CPopupLUTDlg()
{
}

void CPopupLUTDlg::DoDataExchange(CDataExchange* pDX)
{
	CPopupBaseDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_STATIC_GRAPH, m_wndGraph);
	DDX_Check(pDX, IDC_CHECK_4STEP_ENABLE, m_b4StepLUTEnable);
	DDX_Text(pDX, IDC_EDIT_POINT1_X, m_nlPointX[0]);
	DDX_Text(pDX, IDC_EDIT_POINT2_X, m_nlPointX[1]);
	DDX_Text(pDX, IDC_EDIT_POINT3_X, m_nlPointX[2]);
	DDX_Text(pDX, IDC_EDIT_POINT4_X, m_nlPointX[3]);
	DDX_Text(pDX, IDC_EDIT_POINT1_Y, m_nlPointY[0]);
	DDX_Text(pDX, IDC_EDIT_POINT2_Y, m_nlPointY[1]);
	DDX_Text(pDX, IDC_EDIT_POINT3_Y, m_nlPointY[2]);
	DDX_Text(pDX, IDC_EDIT_POINT4_Y, m_nlPointY[3]);
	DDX_Control(pDX, IDC_EDIT_POINT1_X, m_edPointX[0]);
	DDX_Control(pDX, IDC_EDIT_POINT2_X, m_edPointX[1]);
	DDX_Control(pDX, IDC_EDIT_POINT3_X, m_edPointX[2]);
	DDX_Control(pDX, IDC_EDIT_POINT4_X, m_edPointX[3]);
	DDX_Control(pDX, IDC_EDIT_POINT1_Y, m_edPointY[0]);
	DDX_Control(pDX, IDC_EDIT_POINT2_Y, m_edPointY[1]);
	DDX_Control(pDX, IDC_EDIT_POINT3_Y, m_edPointY[2]);
	DDX_Control(pDX, IDC_EDIT_POINT4_Y, m_edPointY[3]);
	DDX_Check(pDX, IDC_CHECK_USER_ENABLE, m_bUserLUTEnable);
	DDX_Control(pDX, IDC_COMBO_LUT_INDEX, m_cbUserLUTIndex);
}


BEGIN_MESSAGE_MAP(CPopupLUTDlg, CPopupBaseDialog)
	ON_BN_CLICKED(IDC_BUTTON_SET_TO_LINEAR, &CPopupLUTDlg::OnBnClickedButtonSetToLinear)
	ON_BN_CLICKED(IDC_BUTTON_4STEP_APPLY, &CPopupLUTDlg::OnBnClickedButton4stepApply)
	ON_BN_CLICKED(IDC_BUTTON_SAVEDATA_IN_INDEX, &CPopupLUTDlg::OnBnClickedButtonSavedataInIndex)
	ON_BN_CLICKED(IDC_BUTTON_USER_APPLY, &CPopupLUTDlg::OnBnClickedButtonUserApply)
END_MESSAGE_MAP()

BOOL CPopupLUTDlg::PreTranslateMessage(MSG* pMsg)
{
	if (pMsg->message == WM_KEYDOWN)
	{
		if (pMsg->wParam == VK_RETURN)
		{
			m_wndLut.UpdateLUT();
			return TRUE;
		}
	}
	return CPopupBaseDialog::PreTranslateMessage(pMsg);
}

void CPopupLUTDlg::InitControls()
{
	CRect rect;
	m_wndGraph.GetWindowRect(rect);
	ScreenToClient(rect);
	m_wndLut.Create(NULL, NULL, WS_VISIBLE|WS_CHILD|WS_BORDER, rect, this, 100);
}

void CPopupLUTDlg::UpdateDialog()
{
	m_b4StepLUTEnable = FALSE;
	ZeroMemory(&m_nlPointX, sizeof(m_nlPointX));
	ZeroMemory(&m_nlPointY, sizeof(m_nlPointY));
	m_bUserLUTEnable = FALSE;
	m_cbUserLUTIndex.ResetContent();

	if (m_pCameraHandle)
	{
		NEPTUNE_KNEE_LUT stKneeLUT;
		ENeptuneError emErr = ntcGetKneeLUT(m_pCameraHandle, &stKneeLUT);
		if (emErr == NEPTUNE_ERR_Success)
		{
			m_b4StepLUTEnable = (stKneeLUT.bEnable == NEPTUNE_BOOL_TRUE);
			for (int i = 0; i < MAX_POINT_COUNT; i++)
			{
				m_nlPointX[i] = stKneeLUT.Points[i].x;
				m_nlPointY[i] = stKneeLUT.Points[i].y;
			}
		}
		else
		{
			InsertLog(TYPE_ERROR, _T("ntcGetKneeLUT Failed."), emErr);
		}

		NEPTUNE_USER_LUT stUserLUT;
		emErr = ntcGetUserLUT(m_pCameraHandle, &stUserLUT);
		if (emErr == NEPTUNE_ERR_Success)
		{
			int nItem = CB_ERR;
			CString strItem = _T("");
			m_bUserLUTEnable = (stUserLUT.bEnable == NEPTUNE_BOOL_TRUE);
			for (int i = 0; i < 16; i++)
			{
				if (((stUserLUT.SupportLUT >> i) & 0x01) == 0x01)
				{
					strItem.Format(_T("LUT%d"), i);
					nItem = m_cbUserLUTIndex.InsertString(m_cbUserLUTIndex.GetCount(), strItem);
					m_cbUserLUTIndex.SetItemData(nItem, i);
				}
			}
			for (int i = 0; i < m_cbUserLUTIndex.GetCount(); i++)
			{
				if (stUserLUT.LUTIndex == (_uint16_t)m_cbUserLUTIndex.GetItemData(i))
				{
					m_cbUserLUTIndex.SetCurSel(i);
					break;
				}
			}
		}
		else
		{
			InsertLog(TYPE_ERROR, _T("ntcGetUserLUT Failed."), emErr);
		}
	}
	UpdateData(FALSE);
	m_wndLut.UpdateLUT();
}

void CPopupLUTDlg::OnBnClickedButtonSetToLinear()
{
	int nPointX = 1000;
	int nPointY = 1000;
	for (int i = 0; i < MAX_POINT_COUNT; i++)
	{
		m_nlPointX[i] = nPointX;
		m_nlPointY[i] = nPointY;
		nPointX += 500;
		nPointY += 500;
	}
	UpdateData(FALSE);
	m_wndLut.UpdateLUT();
}

void CPopupLUTDlg::OnBnClickedButton4stepApply()
{
	UpdateData(TRUE);
	if (m_pCameraHandle)
	{
		NEPTUNE_KNEE_LUT stKneeLUT;
		stKneeLUT.bEnable = (m_b4StepLUTEnable ? NEPTUNE_BOOL_TRUE : NEPTUNE_BOOL_FALSE);
		for (int i = 0; i < MAX_POINT_COUNT; i++)
		{
			if (m_nlPointX[i] > m_sizeMaxLut.cx)
			{
				m_nlPointX[i] = m_sizeMaxLut.cx;
			}
			if (m_nlPointX[i] < 0)
			{
				m_nlPointX[i] = 0;
			}
			if (m_nlPointY[i] > m_sizeMaxLut.cy)
			{
				m_nlPointY[i] = m_sizeMaxLut.cy;
			}
			if (m_nlPointY[i] < 0)
			{
				m_nlPointY[i] = 0;
			}
			stKneeLUT.Points[i].x = m_nlPointX[i];
			stKneeLUT.Points[i].y = m_nlPointY[i];
		}
		ENeptuneError emErr = ntcSetKneeLUT(m_pCameraHandle, stKneeLUT);
		if (emErr != NEPTUNE_ERR_Success)
		{
			UpdateDialog();
			InsertLog(TYPE_ERROR, _T("ntcSetKneeLUT Failed."), emErr);
		}
	}
	UpdateData(FALSE);
	m_wndLut.UpdateLUT();
}

void CPopupLUTDlg::OnBnClickedButtonSavedataInIndex()
{
	TCHAR szLutTablePath[MAX_PATH] = {NULL, };
	GetModuleFileName(NULL, szLutTablePath, _countof(szLutTablePath));
	PathRemoveFileSpec(szLutTablePath);
	PathAppend(szLutTablePath, _T("Bin"));
	PathAppend(szLutTablePath, _T("Table"));
	PathAppend(szLutTablePath, _T("LUT"));

	CFileDialog dlg(TRUE, NULL, NULL, OFN_READONLY|OFN_HIDEREADONLY|OFN_PATHMUSTEXIST|OFN_FILEMUSTEXIST, _T("Data Files (*.dat)|*.dat|All Files (*.*)|*.*||"), this);
	dlg.m_ofn.lpstrInitialDir = szLutTablePath;
	if (dlg.DoModal() == IDOK)
	{
		CString strFilePath = dlg.GetPathName();
		FILE* fp = NULL;
		if (_tfopen_s(&fp, strFilePath, _T("r")) == 0)
		{
			PSHORT pnsBuf = new SHORT[4096];
			ZeroMemory(pnsBuf, 4096*sizeof(SHORT));
			int nValue = 0;
			for (int i = 0; i < 4096; i++)
			{
				if (!feof(fp))
				{
					nValue = 0;
					_ftscanf_s(fp, _T("%d"), &nValue);
					pnsBuf[i] = (SHORT)nValue;
				}
				else
				{
					break;
				}
			}
			fclose(fp);
			
			NEPTUNE_USER_LUT stUserLUT;
			stUserLUT.LUTIndex = (_uint16_t)m_cbUserLUTIndex.GetItemData(m_cbUserLUTIndex.GetCurSel());
			memcpy(stUserLUT.Data, pnsBuf, sizeof(stUserLUT.Data));
			ENeptuneError emErr = ntcSetUserLUT(m_pCameraHandle, stUserLUT);
			if (emErr == NEPTUNE_ERR_Success)
			{
				CString strLog = _T("");
				strLog.Format(_T("Write Data: LUT%d"), stUserLUT.LUTIndex);
				InsertLog(TYPE_INFORMATION, strLog);
			}
			else
			{
				InsertLog(TYPE_ERROR, _T("ntcSetUserLUT Failed."), emErr);
			}

			delete [] pnsBuf;
		}
	}
}

void CPopupLUTDlg::OnBnClickedButtonUserApply()
{
	UpdateData(TRUE);
	if (m_pCameraHandle)
	{
		NEPTUNE_USER_LUT stUserLUT;
		stUserLUT.bEnable = (m_bUserLUTEnable ? NEPTUNE_BOOL_TRUE : NEPTUNE_BOOL_FALSE);
		stUserLUT.LUTIndex = (_uint16_t)m_cbUserLUTIndex.GetItemData(m_cbUserLUTIndex.GetCurSel());
		ENeptuneError emErr = ntcSetUserLUT(m_pCameraHandle, stUserLUT);
		if (emErr != NEPTUNE_ERR_Success)
		{
			InsertLog(TYPE_ERROR, _T("ntcSetUserLUT Failed."), emErr);
		}
	}
}



