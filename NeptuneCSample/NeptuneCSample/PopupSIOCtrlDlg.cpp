// PopupSIOCtrlDlg.cpp : 구현 파일입니다.
//

#include "stdafx.h"
#include "NeptuneCSample.h"
#include "PopupSIOCtrlDlg.h"
#include "afxdialogex.h"


// CPopupSIOCtrlDlg 대화 상자입니다.

IMPLEMENT_DYNAMIC(CPopupSIOCtrlDlg, CPopupBaseDialog)

CPopupSIOCtrlDlg::CPopupSIOCtrlDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis)
	: CPopupBaseDialog(CPopupSIOCtrlDlg::IDD, pCameraHandle, ppThis)
{

}

CPopupSIOCtrlDlg::~CPopupSIOCtrlDlg()
{
}

void CPopupSIOCtrlDlg::DoDataExchange(CDataExchange* pDX)
{
	CPopupBaseDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_CHECK_ENABLE, m_ckEnable);
	DDX_Control(pDX, IDC_COMBO_BAUD_RATE, m_cbBaudRate);
	DDX_Control(pDX, IDC_COMBO_PARITY_BITS, m_cbParityBits);
	DDX_Control(pDX, IDC_COMBO_DATA_BITS, m_cbDataBits);
	DDX_Control(pDX, IDC_COMBO_STOP_BITS, m_cbStopBits);
	DDX_Control(pDX, IDC_EDIT_DATA, m_edData);
}


BEGIN_MESSAGE_MAP(CPopupSIOCtrlDlg, CPopupBaseDialog)
	ON_BN_CLICKED(IDC_BUTTON_APPLY, &CPopupSIOCtrlDlg::OnBnClickedButtonApply)
	ON_BN_CLICKED(IDC_BUTTON_SEND_DATA, &CPopupSIOCtrlDlg::OnBnClickedButtonSendData)
	ON_BN_CLICKED(IDC_BUTTON_RECEIVE_DATA, &CPopupSIOCtrlDlg::OnBnClickedButtonReceiveData)
END_MESSAGE_MAP()

void CPopupSIOCtrlDlg::InitControls()
{
	m_cbBaudRate.ResetContent();
	int nItem = m_cbBaudRate.InsertString(m_cbBaudRate.GetCount(), _T("300"));
	m_cbBaudRate.SetItemData(nItem, 300);
	nItem = m_cbBaudRate.InsertString(m_cbBaudRate.GetCount(), _T("600"));
	m_cbBaudRate.SetItemData(nItem, 600);
	nItem = m_cbBaudRate.InsertString(m_cbBaudRate.GetCount(), _T("1200"));
	m_cbBaudRate.SetItemData(nItem, 1200);
	nItem = m_cbBaudRate.InsertString(m_cbBaudRate.GetCount(), _T("2400"));
	m_cbBaudRate.SetItemData(nItem, 2400);
	nItem = m_cbBaudRate.InsertString(m_cbBaudRate.GetCount(), _T("4800"));
	m_cbBaudRate.SetItemData(nItem, 4800);
	nItem = m_cbBaudRate.InsertString(m_cbBaudRate.GetCount(), _T("9600"));
	m_cbBaudRate.SetItemData(nItem, 9600);
	nItem = m_cbBaudRate.InsertString(m_cbBaudRate.GetCount(), _T("19200"));
	m_cbBaudRate.SetItemData(nItem, 19200);
	nItem = m_cbBaudRate.InsertString(m_cbBaudRate.GetCount(), _T("38400"));
	m_cbBaudRate.SetItemData(nItem, 38400);
	nItem = m_cbBaudRate.InsertString(m_cbBaudRate.GetCount(), _T("57600"));
	m_cbBaudRate.SetItemData(nItem, 57600);
	nItem = m_cbBaudRate.InsertString(m_cbBaudRate.GetCount(), _T("115200"));
	m_cbBaudRate.SetItemData(nItem, 115200);
	nItem = m_cbBaudRate.InsertString(m_cbBaudRate.GetCount(), _T("230400"));
	m_cbBaudRate.SetItemData(nItem, 230400);
	m_cbBaudRate.SetCurSel(8);

	m_cbParityBits.ResetContent();
	nItem = m_cbParityBits.InsertString(m_cbParityBits.GetCount(), _T("None"));
	m_cbParityBits.SetItemData(nItem, NEPTUNE_SIO_PARITY_NONE);
	nItem = m_cbParityBits.InsertString(m_cbParityBits.GetCount(), _T("Odd"));
	m_cbParityBits.SetItemData(nItem, NEPTUNE_SIO_PARITY_ODD);
	nItem = m_cbParityBits.InsertString(m_cbParityBits.GetCount(), _T("Even"));
	m_cbParityBits.SetItemData(nItem, NEPTUNE_SIO_PARITY_EVEN);
	m_cbParityBits.SetCurSel(0);

	m_cbDataBits.ResetContent();
	nItem = m_cbDataBits.InsertString(m_cbDataBits.GetCount(), _T("7"));
	m_cbDataBits.SetItemData(nItem, 7);
	nItem = m_cbDataBits.InsertString(m_cbDataBits.GetCount(), _T("8"));
	m_cbDataBits.SetItemData(nItem, 8);
	m_cbDataBits.SetCurSel(1);

	m_cbStopBits.ResetContent();
	nItem = m_cbStopBits.InsertString(m_cbStopBits.GetCount(), _T("1"));
	m_cbStopBits.SetItemData(nItem, 1);
	nItem = m_cbStopBits.InsertString(m_cbStopBits.GetCount(), _T("2"));
	m_cbStopBits.SetItemData(nItem, 2);
	m_cbStopBits.SetCurSel(0);
}

void CPopupSIOCtrlDlg::OnBnClickedButtonApply()
{
	if (m_pCameraHandle)
	{
		NEPTUNE_SIO_PROPERTY stProperty;
		stProperty.bEnable = (m_ckEnable.GetCheck() == BST_CHECKED) ? NEPTUNE_BOOL_TRUE : NEPTUNE_BOOL_FALSE;
		stProperty.Baudrate = (_uint32_t)m_cbBaudRate.GetItemData(m_cbBaudRate.GetCurSel());
		stProperty.Parity = (ENeptuneSIOParity)m_cbParityBits.GetItemData(m_cbParityBits.GetCurSel());
		stProperty.DataBit = (_uint32_t)m_cbDataBits.GetItemData(m_cbDataBits.GetCurSel());
		stProperty.StopBit = (_uint32_t)m_cbStopBits.GetItemData(m_cbStopBits.GetCurSel());
		ENeptuneError emErr = ntcSetSIO(m_pCameraHandle, stProperty);
		if (emErr != NEPTUNE_ERR_Success)
		{
			InsertLog(TYPE_ERROR, _T("ntcSetSIO Failed."), emErr);
		}
		else
		{
			InsertLog(TYPE_ERROR, _T("ntcSetSIO Connected."), emErr);
		}
	}
}

void CPopupSIOCtrlDlg::OnBnClickedButtonSendData()
{
	if (m_pCameraHandle)
	{
		CString strData = _T("");
		m_edData.GetWindowText(strData);

		NEPTUNE_SIO stSIO;
		USES_CONVERSION;
		strcpy_s(stSIO.strText, _countof(stSIO.strText), T2A(strData));
		ENeptuneError emErr = ntcWriteSIO(m_pCameraHandle, stSIO);
		if (emErr != NEPTUNE_ERR_Success)
		{
			InsertLog(TYPE_ERROR, _T("ntcWriteSIO Failed."), emErr);
		}
	}
}

void CPopupSIOCtrlDlg::OnBnClickedButtonReceiveData()
{
	if (m_pCameraHandle)
	{
		NEPTUNE_SIO stSIO;
		ENeptuneError emErr = ntcReadSIO(m_pCameraHandle, &stSIO);
		if (emErr == NEPTUNE_ERR_Success)
		{
			TCHAR szData[_countof(stSIO.strText)] = {NULL, };
			USES_CONVERSION;
			_tcscpy_s(szData, A2T(stSIO.strText));
			m_edData.SetWindowText(szData);
		}
		else
		{
			InsertLog(TYPE_ERROR, _T("ntcReadSIO Failed."), emErr);
		}
	}
}
