// PopupUserSetDlg.cpp : 구현 파일입니다.
//

#include "stdafx.h"
#include "NeptuneCSample.h"
#include "PopupUserSetDlg.h"
#include "afxdialogex.h"


// CPopupUserSetDlg 대화 상자입니다.

IMPLEMENT_DYNAMIC(CPopupUserSetDlg, CPopupBaseDialog)

CPopupUserSetDlg::CPopupUserSetDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis)
	: CPopupBaseDialog(CPopupUserSetDlg::IDD, pCameraHandle, ppThis)
{

}

CPopupUserSetDlg::~CPopupUserSetDlg()
{
}

void CPopupUserSetDlg::DoDataExchange(CDataExchange* pDX)
{
	CPopupBaseDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_COMBO_USERSET, m_cbUserSet);
}


BEGIN_MESSAGE_MAP(CPopupUserSetDlg, CPopupBaseDialog)
	ON_BN_CLICKED(IDC_BUTTON_USERSET_LOAD, &CPopupUserSetDlg::OnBnClickedButtonUsersetLoad)
	ON_BN_CLICKED(IDC_BUTTON_USERSET_SAVE, &CPopupUserSetDlg::OnBnClickedButtonUsersetSave)
	ON_BN_CLICKED(IDC_BUTTON_USERSET_DEFAULT, &CPopupUserSetDlg::OnBnClickedButtonUsersetDefault)
END_MESSAGE_MAP()

void CPopupUserSetDlg::UpdateDialog()
{
	m_cbUserSet.ResetContent();

	if (m_pCameraHandle)
	{
		NEPTUNE_USERSET stUserSet;
		ENeptuneError emErr = ntcGetUserSet(m_pCameraHandle, &stUserSet);
		if (emErr == NEPTUNE_ERR_Success)
		{
			int nItem = CB_ERR;
			CString strItem = _T("");
			for (int i = 0; i < 16; i++)
			{
				LONG nlBit = (0x01 << i);
				if ((stUserSet.SupportUserSet & nlBit) == nlBit)
				{
					if (i == 0)
					{
						nItem = m_cbUserSet.InsertString(m_cbUserSet.GetCount(), _T("Default"));
						m_cbUserSet.SetItemData(nItem, i);
					}
					else
					{
						strItem.Format(_T("UserSet%d"), i);
						nItem = m_cbUserSet.InsertString(m_cbUserSet.GetCount(), strItem);
						m_cbUserSet.SetItemData(nItem, i);
					}
				}
			}

			m_cbUserSet.SetCurSel(stUserSet.UserSetIndex);
		}
		else
		{
			InsertLog(TYPE_ERROR, _T("ntcGetUserSet Failed."), emErr);
		}
	}
}

void CPopupUserSetDlg::OnBnClickedButtonUsersetLoad()
{
	if (m_pCameraHandle)
	{
		NEPTUNE_USERSET stUserSet;
		stUserSet.UserSetIndex = (ENeptuneUserSet)m_cbUserSet.GetItemData(m_cbUserSet.GetCurSel());
		stUserSet.Command = NEPTUNE_USERSET_CMD_LOAD;
		ENeptuneError emErr = ntcSetUserSet(m_pCameraHandle, stUserSet);
		if (emErr == NEPTUNE_ERR_Success)
		{
			UpdatePopupDialogs();
			CString strLog = _T("");
			strLog.Format(_T("Load UserSet%d"), (int)stUserSet.UserSetIndex);
			InsertLog(TYPE_INFORMATION, strLog);

			UpdateCameraInfo();
		}
		else
		{
			InsertLog(TYPE_ERROR, _T("ntcSetUserSet Failed."), emErr);
		}
	}
}
 
void CPopupUserSetDlg::OnBnClickedButtonUsersetSave()
{
	if (m_pCameraHandle)
	{
		NEPTUNE_USERSET stUserSet;
		stUserSet.UserSetIndex = (ENeptuneUserSet)m_cbUserSet.GetItemData(m_cbUserSet.GetCurSel());
		stUserSet.Command = NEPTUNE_USERSET_CMD_SAVE;
		ENeptuneError emErr = ntcSetUserSet(m_pCameraHandle, stUserSet);
		if (emErr == NEPTUNE_ERR_Success)
		{
			CString strLog = _T("");
			strLog.Format(_T("Save UserSet%d"), (int)stUserSet.UserSetIndex);
			InsertLog(TYPE_INFORMATION, strLog);
		}
		else
		{
			InsertLog(TYPE_ERROR, _T("ntcSetUserSet Failed."), emErr);
		}
	}
}

void CPopupUserSetDlg::OnBnClickedButtonUsersetDefault()
{
	if (m_pCameraHandle)
	{
		ENeptuneUserSet emUserSet = (ENeptuneUserSet)m_cbUserSet.GetItemData(m_cbUserSet.GetCurSel());
		ENeptuneError emErr = ntcSetPowerOnDefaultUserSet(m_pCameraHandle, emUserSet);
		if (emErr == NEPTUNE_ERR_Success)
		{
			CString strLog = _T("");
			strLog.Format(_T("PowerOnDefault UserSet%d"), (int)emUserSet);
			InsertLog(TYPE_INFORMATION, strLog);
		}
		else
		{
			InsertLog(TYPE_ERROR, _T("ntcSetPowerOnDefaultUserSet Failed."), emErr);
		}
	}
}



