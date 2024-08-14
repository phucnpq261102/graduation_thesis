// PopupTriggerDlg.cpp : 구현 파일입니다.
//

#include "stdafx.h"
#include "NeptuneCSample.h"
#include "PopupTriggerDlg.h"
#include "afxdialogex.h"


// CPopupTriggerDlg 대화 상자입니다.

IMPLEMENT_DYNAMIC(CPopupTriggerDlg, CPopupBaseDialog)

CPopupTriggerDlg::CPopupTriggerDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis)
	: CPopupBaseDialog(CPopupTriggerDlg::IDD, pCameraHandle, ppThis)
	, m_bTriggerEnable(FALSE)
	, m_nlTriggerParam(0)
	, m_strParamRange(_T(""))
{

}

CPopupTriggerDlg::~CPopupTriggerDlg()
{
}

void CPopupTriggerDlg::DoDataExchange(CDataExchange* pDX)
{
	CPopupBaseDialog::DoDataExchange(pDX);
	DDX_Check(pDX, IDC_CHECK_ENABLE, m_bTriggerEnable);
	DDX_Control(pDX, IDC_COMBO_MODE, m_cbTriggerMode);
	DDX_Control(pDX, IDC_COMBO_SOURCE, m_cbTriggerSource);
	DDX_Control(pDX, IDC_COMBO_POLARITY, m_cbTriggerPolarity);
	DDX_Text(pDX, IDC_EDIT_PARAMERTER, m_nlTriggerParam);
	DDX_Text(pDX, IDC_STATIC_PARAMERTER_RANGE, m_strParamRange);
	DDX_Control(pDX, IDC_BUTTON_RUN, m_btnSWTrigger);
}


BEGIN_MESSAGE_MAP(CPopupTriggerDlg, CPopupBaseDialog)
	ON_BN_CLICKED(IDC_BUTTON_RUN, &CPopupTriggerDlg::OnBnClickedButtonRun)
	ON_BN_CLICKED(IDC_BUTTON_APPLY, &CPopupTriggerDlg::OnBnClickedButtonApply)
END_MESSAGE_MAP()

void CPopupTriggerDlg::UpdateDialog()
{
	m_bTriggerEnable = FALSE;
	m_cbTriggerMode.ResetContent();
	m_cbTriggerSource.ResetContent();
	m_cbTriggerPolarity.ResetContent();
	m_nlTriggerParam = 0;
	m_strParamRange = _T("(Min ~ Max)");
	m_btnSWTrigger.EnableWindow(FALSE);
	
	if (m_pCameraHandle)
	{
		NEPTUNE_TRIGGER_INFO stTriggerInfo;
		ENeptuneError emErr = ntcGetTriggerInfo(m_pCameraHandle, &stTriggerInfo);
		if (emErr == NEPTUNE_ERR_Success)
		{
			if (stTriggerInfo.bSupport == NEPTUNE_BOOL_TRUE)
			{
				CString strItem = _T("");
				int nItem = CB_ERR;
				int nFlag = (int)stTriggerInfo.nModeFlag;
				for (int i = 0; i < 31; i++)
				{
					if ((nFlag & 0x01) == 0x01)
					{
						strItem.Format(_T("Mode%d"), i);
						nItem = m_cbTriggerMode.InsertString(m_cbTriggerMode.GetCount(), strItem);
						m_cbTriggerMode.SetItemData(nItem, i);
					}
					nFlag = (nFlag >> 1);
				}

				if (((stTriggerInfo.nSourceFlag >> NEPTUNE_TRIGGER_SOURCE_LINE1) & 0x01) == 0x01)
				{
					nItem = m_cbTriggerSource.InsertString(m_cbTriggerSource.GetCount(), _T("Line1"));
					m_cbTriggerSource.SetItemData(nItem, NEPTUNE_TRIGGER_SOURCE_LINE1);
				}
				if (((stTriggerInfo.nSourceFlag >> NEPTUNE_TRIGGER_SOURCE_SW) & 0x01) == 0x01)
				{
					nItem = m_cbTriggerSource.InsertString(m_cbTriggerSource.GetCount(), _T("Software"));
					m_cbTriggerSource.SetItemData(nItem, NEPTUNE_TRIGGER_SOURCE_SW);
				}

				if (((stTriggerInfo.nPolarityFlag >> NEPTUNE_POLARITY_RISINGEDGE) & 0x01) == 0x01)
				{
					nItem = m_cbTriggerPolarity.InsertString(m_cbTriggerPolarity.GetCount(), _T("Rising Edge"));
					m_cbTriggerPolarity.SetItemData(nItem, NEPTUNE_POLARITY_RISINGEDGE);
				}
				if (((stTriggerInfo.nPolarityFlag >> NEPTUNE_POLARITY_FALLINGEDGE) & 0x01) == 0x01)
				{
					nItem = m_cbTriggerPolarity.InsertString(m_cbTriggerPolarity.GetCount(), _T("Falling Edge"));
					m_cbTriggerPolarity.SetItemData(nItem, NEPTUNE_POLARITY_FALLINGEDGE);
				}
				if (((stTriggerInfo.nPolarityFlag >> NEPTUNE_POLARITY_ANYEDGE) & 0x01) == 0x01)
				{
					nItem = m_cbTriggerPolarity.InsertString(m_cbTriggerPolarity.GetCount(), _T("Any Edge"));
					m_cbTriggerPolarity.SetItemData(nItem, NEPTUNE_POLARITY_ANYEDGE);
				}
				if (((stTriggerInfo.nPolarityFlag >> NEPTUNE_POLARITY_LEVELHIGH) & 0x01) == 0x01)
				{
					nItem = m_cbTriggerPolarity.InsertString(m_cbTriggerPolarity.GetCount(), _T("High Level"));
					m_cbTriggerPolarity.SetItemData(nItem, NEPTUNE_POLARITY_LEVELHIGH);
				}
				if (((stTriggerInfo.nPolarityFlag >> NEPTUNE_POLARITY_LEVELLOW) & 0x01) == 0x01)
				{
					nItem = m_cbTriggerPolarity.InsertString(m_cbTriggerPolarity.GetCount(), _T("Low Level"));
					m_cbTriggerPolarity.SetItemData(nItem, NEPTUNE_POLARITY_LEVELLOW);
				}

				m_strParamRange.Format(_T("(%d ~ %d)"), stTriggerInfo.nParamMin, stTriggerInfo.nParamMax);

				NEPTUNE_TRIGGER stTrigger;
				emErr = ntcGetTrigger(m_pCameraHandle, &stTrigger);
				if (emErr == NEPTUNE_ERR_Success)
				{
					m_bTriggerEnable = (stTrigger.OnOff == NEPTUNE_BOOL_TRUE);

					for (int i = 0; i < m_cbTriggerMode.GetCount(); i++)
					{
						if (stTrigger.Mode == (ENeptuneTriggerMode)m_cbTriggerMode.GetItemData(i))
						{
							m_cbTriggerMode.SetCurSel(i);
							break;
						}
					}

					for (int i = 0; i < m_cbTriggerSource.GetCount(); i++)
					{
						if (stTrigger.Source == (ENeptuneTriggerSource)m_cbTriggerSource.GetItemData(i))
						{
							m_cbTriggerSource.SetCurSel(i);
							break;
						}
					}

					for (int i = 0; i < m_cbTriggerPolarity.GetCount(); i++)
					{
						if (stTrigger.Polarity == (ENeptunePolarity)m_cbTriggerPolarity.GetItemData(i))
						{
							m_cbTriggerPolarity.SetCurSel(i);
							break;
						}
					}

					m_nlTriggerParam = stTrigger.nParam;

					m_btnSWTrigger.EnableWindow((stTrigger.Source == NEPTUNE_TRIGGER_SOURCE_SW) && (stTrigger.OnOff == NEPTUNE_BOOL_TRUE));
				}
				else
				{
					InsertLog(TYPE_ERROR, _T("ntcGetTrigger Failed."), emErr);
				}
			}
		}
		else
		{
			InsertLog(TYPE_ERROR, _T("ntcGetTriggerInfo Failed."), emErr);
		}
	}

	UpdateData(FALSE);
}

void CPopupTriggerDlg::OnBnClickedButtonRun()
{
	if (m_pCameraHandle)
	{
		ntcRunSWTrigger(m_pCameraHandle);
	}
}

void CPopupTriggerDlg::OnBnClickedButtonApply()
{
	UpdateData(TRUE);
	if (m_pCameraHandle)
	{
		NEPTUNE_TRIGGER stTrigger;
		stTrigger.OnOff = (m_bTriggerEnable ? NEPTUNE_BOOL_TRUE : NEPTUNE_BOOL_FALSE);
		stTrigger.Mode = (ENeptuneTriggerMode)m_cbTriggerMode.GetItemData(m_cbTriggerMode.GetCurSel());
		stTrigger.Source = (ENeptuneTriggerSource)m_cbTriggerSource.GetItemData(m_cbTriggerSource.GetCurSel());
		stTrigger.Polarity = (ENeptunePolarity)m_cbTriggerPolarity.GetItemData(m_cbTriggerPolarity.GetCurSel());
		stTrigger.nParam = (_uint16_t)m_nlTriggerParam;
		ENeptuneError emErr = ntcSetTrigger(m_pCameraHandle, stTrigger);
		if (emErr == NEPTUNE_ERR_Success)
		{
			m_btnSWTrigger.EnableWindow((stTrigger.Source == NEPTUNE_TRIGGER_SOURCE_SW) && (stTrigger.OnOff == NEPTUNE_BOOL_TRUE));
		}
		else
		{
			UpdateDialog();
			InsertLog(TYPE_ERROR, _T("ntcSetTrigger Failed."), emErr);
		}
	}
}
