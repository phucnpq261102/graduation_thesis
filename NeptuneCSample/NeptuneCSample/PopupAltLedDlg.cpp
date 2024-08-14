// PopupAltLedDlg.cpp : 구현 파일입니다.
//

#include "stdafx.h"
#include "NeptuneCSample.h"
#include "PopupAltLedDlg.h"
#include "afxdialogex.h"


// CPopupAltLedDlg 대화 상자입니다.

IMPLEMENT_DYNAMIC(CPopupAltLedDlg, CPopupBaseDialog)

CPopupAltLedDlg::CPopupAltLedDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis)
	: CPopupBaseDialog(CPopupAltLedDlg::IDD, pCameraHandle, ppThis)
{
	m_nTableItemCnt		= 255;
	m_nTableSubItemCnt	= 64;

	m_rangeValue.nlMin	= 0;
	m_rangeValue.nlMax	= 255;
}

CPopupAltLedDlg::~CPopupAltLedDlg()
{
}

void CPopupAltLedDlg::DoDataExchange(CDataExchange* pDX)
{
	CPopupBaseDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_RADIO_INDEX, m_btnIndex);
	DDX_Control(pDX, IDC_RADIO_DIRECT, m_btnDirect);
	DDX_Control(pDX, IDC_CHECK_AUTO_RUN, m_btnAutoRun);
	DDX_Control(pDX, IDC_EDIT_START_INDEX, m_edStartIndex);
	DDX_Control(pDX, IDC_LIST_TABLE, m_wndTable);
}


BEGIN_MESSAGE_MAP(CPopupAltLedDlg, CPopupBaseDialog)
	ON_BN_CLICKED(IDC_BUTTON_SET, &CPopupAltLedDlg::OnBnClickedButtonSet)
	ON_BN_CLICKED(IDC_BUTTON_UPDATE, &CPopupAltLedDlg::OnBnClickedButtonUpdate)
	ON_BN_CLICKED(IDC_BUTTON_ZERO_FILL, &CPopupAltLedDlg::OnBnClickedButtonZeroFill)
	ON_BN_CLICKED(IDC_BUTTON_SAMPLE_FILL, &CPopupAltLedDlg::OnBnClickedButtonSampleFill)
	ON_NOTIFY(LVN_ITEMCHANGED, IDC_LIST_TABLE, &CPopupAltLedDlg::OnLvnItemchangedListTable)
	ON_BN_CLICKED(IDC_RADIO_INDEX, &CPopupAltLedDlg::OnBnClickedRadioIndex)
	ON_BN_CLICKED(IDC_RADIO_DIRECT, &CPopupAltLedDlg::OnBnClickedRadioDirect)
END_MESSAGE_MAP()


// CPopupAltLedDlg 메시지 처리기입니다.

BOOL CPopupAltLedDlg::OnInitDialog()
{
	CPopupBaseDialog::OnInitDialog();

	// TODO:  여기에 추가 초기화 작업을 추가합니다.
	m_edStartIndex.SetWindowText(_T("0"));

	int cxSB = GetSystemMetrics(SM_CXVSCROLL);

	CRect rect;
	m_wndTable.GetWindowRect(rect);
	int nWidth = (rect.Width()-cxSB) / 9;

	m_wndTable.SetExtendedStyle(LVS_EX_FULLROWSELECT | LVS_EX_GRIDLINES);

	m_wndTable.InsertColumn(0, _T("Index"),	LVCFMT_CENTER, nWidth-1);
	CString strColumn = _T("");
	for (int nSubItem=1; nSubItem<=m_nTableSubItemCnt; nSubItem++)
	{
		strColumn.Format(_T("Ch%d"), nSubItem);
		int nColumn = m_wndTable.InsertColumn(nSubItem, strColumn, LVCFMT_CENTER, nWidth);
		if (nColumn != -1) {
			HDITEM hdi	= {NULL, };
			hdi.mask	= HDI_LPARAM;
			hdi.lParam	= (LPARAM)&m_rangeValue;
			m_wndTable.GetHeaderCtrl().SetItem(nColumn, &hdi);
		}
	}

	CString strValue = _T("");
	LVITEM LI		= {NULL, };
	LI.mask			= LVIF_TEXT|LVIF_PARAM;
	LI.iSubItem		= 0;
	for (int i=0; i<m_nTableItemCnt; i++)
	{
		LI.iItem		= i;
		LI.lParam		= i;
		strValue.Format(_T("%d"), i);
		LI.pszText		= strValue.GetBuffer(0);
		int nItem = m_wndTable.InsertItem(&LI);
	}
	OnBnClickedButtonZeroFill();
	m_wndTable.SetItemState(0, LVIS_SELECTED|LVIS_FOCUSED, LVIS_SELECTED|LVIS_FOCUSED);

	return TRUE;  // return TRUE unless you set the focus to a control
	// 예외: OCX 속성 페이지는 FALSE를 반환해야 합니다.
}

void CPopupAltLedDlg::UpdateDialog()
{
	BOOL bEnable = FALSE;
	if (m_pCameraHandle)
	{
		ENeptuneDevType emDevType = NEPTUNE_DEV_TYPE_UNKNOWN;
		if (ntcGetCameraType(m_pCameraHandle, &emDevType) == NEPTUNE_ERR_Success)
		{
			if (emDevType == NEPTUNE_DEV_TYPE_USB3)
			{				
				ENeptuneError emErr = ntcInitCam4AltLed(m_pCameraHandle);
				if (emErr == NEPTUNE_ERR_Success)
				{
					bEnable = TRUE;
				}
				else
				{
					InsertLog(TYPE_ERROR, _T("ntcInitCam4AltLed Failed."), emErr);
				}
			}
		}
	}

	EnableWindow(bEnable);

	if (bEnable) {
		OnBnClickedButtonZeroFill();
		m_wndTable.SetItemState(0, LVIS_SELECTED|LVIS_FOCUSED, LVIS_SELECTED|LVIS_FOCUSED);

		m_btnIndex.SetCheck(BST_CHECKED);
		OnBnClickedRadioIndex();

		m_btnAutoRun.SetCheck(BST_CHECKED);
	}
}


void CPopupAltLedDlg::OnBnClickedButtonSet()
{
	if (m_pCameraHandle)
	{
		if (m_btnIndex.GetCheck() == BST_CHECKED)
		{
			ENeptuneBoolean bAutoRun = (m_btnAutoRun.GetCheck() == BST_CHECKED) ? NEPTUNE_BOOL_TRUE:NEPTUNE_BOOL_FALSE;

			CString strValue = _T("");
			m_edStartIndex.GetWindowText(strValue);
			_int32_t iStart = _ttol(strValue);
			if (iStart < 0) {
				iStart = 0;
			}
			else if (iStart > 254)
			{
				iStart = 254;
			}
			strValue.Format(_T("%d"), iStart);
			m_edStartIndex.SetWindowText(strValue);

			ENeptuneError emErr = ntcSetCam4AltLedIndex(m_pCameraHandle, bAutoRun, iStart, 254);
			if (emErr == NEPTUNE_ERR_Success)
			{
				InsertLog(TYPE_INFORMATION, _T("Set Alt LED Index."));
			}
			else
			{
				InsertLog(TYPE_ERROR, _T("ntcSetCam4AltLedIndex Failed."), emErr);
			}
		}
		else
		{
			POSITION pos = m_wndTable.GetFirstSelectedItemPosition();
			if (pos)
			{
				int iItem = m_wndTable.GetNextSelectedItem(pos);
				ENeptuneError emErr = ntcSetCam4AltLedDirect(m_pCameraHandle, iItem);
				if (emErr == NEPTUNE_ERR_Success)
				{
					CString strText = _T("");
					strText.Format(_T("Set Alt LED Direct %d."), iItem);
					InsertLog(TYPE_INFORMATION, strText);
				}
				else
				{
					InsertLog(TYPE_ERROR, _T("ntcSetCam4AltLedDirect Failed."), emErr);
				}
			}
		}
	}
}


void CPopupAltLedDlg::OnBnClickedButtonUpdate()
{
	CWaitCursor wait;

	if (m_pCameraHandle)
	{
		_int32_t* pTable = new _int32_t[m_nTableItemCnt*m_nTableSubItemCnt];
		_int32_t iSize = m_nTableItemCnt*m_nTableSubItemCnt*sizeof(_int32_t);
		ZeroMemory(pTable, iSize);

		int iIndex = 0;
		for (int i=0; i<m_nTableItemCnt; i++)
		{
			for (int nSubItem=1; nSubItem<=m_nTableSubItemCnt; nSubItem++)
			{
				CString strValue = m_wndTable.GetItemText(i, nSubItem);
				iIndex = i*m_nTableSubItemCnt + nSubItem-1;
				pTable[iIndex] = _ttol(strValue);
			}
		}

		ENeptuneError emErr = ntcUpdateCam4AltLedTable(m_pCameraHandle, pTable, iSize);
		if (emErr == NEPTUNE_ERR_Success)
		{
			InsertLog(TYPE_INFORMATION, _T("Set Update ALT LED Table."));
		}
		else
		{
			InsertLog(TYPE_ERROR, _T("ntcUpdateCam4AltLedTable Failed."), emErr);
		}

		delete [] pTable;
	}
}

void CPopupAltLedDlg::OnBnClickedButtonZeroFill()
{
	for (int i=0; i<m_nTableItemCnt; i++)
	{
		for (int nSubItem=1; nSubItem<=m_nTableSubItemCnt; nSubItem++)
		{
			m_wndTable.SetItemText(i, nSubItem, _T("0"));
		}
	}
}


void CPopupAltLedDlg::OnBnClickedButtonSampleFill()
{
	OnBnClickedButtonZeroFill();

	BOOL bForward = TRUE;

	CString strValue = _T("");
	int iOffsetX = -1;
	for (int i=0; i<m_nTableItemCnt; i++)
	{
		if (bForward)
		{
			iOffsetX++;
		}
		else
		{
			iOffsetX--;
		}
		strValue.Format(_T("%d"), i+1);

		for (int x=iOffsetX+1; x<=m_nTableSubItemCnt; x+=8)
		{
			m_wndTable.SetItemText(i, x, strValue);
		}

		if (i != 0)
		{
			if (iOffsetX == 0 || iOffsetX == 7)
			{
				bForward = !bForward;
			}
		}
	}
}


void CPopupAltLedDlg::OnLvnItemchangedListTable(NMHDR *pNMHDR, LRESULT *pResult)
{
	LPNMLISTVIEW pNMLV = reinterpret_cast<LPNMLISTVIEW>(pNMHDR);
	
	if ((pNMLV->uChanged & LVIF_STATE) && (pNMLV->uNewState & LVIS_SELECTED)) {
		CString strDirectIdx = m_wndTable.GetItemText(pNMLV->iItem, 0);
		CString strDirect = _T("");
		strDirect.Format(_T("Direct %s"), strDirectIdx);
		m_btnDirect.SetWindowText(strDirect);
	}

	*pResult = 0;
}


void CPopupAltLedDlg::OnBnClickedRadioIndex()
{
	m_btnAutoRun.EnableWindow(TRUE);
	m_edStartIndex.EnableWindow(TRUE);
}


void CPopupAltLedDlg::OnBnClickedRadioDirect()
{
	m_btnAutoRun.EnableWindow(FALSE);
	m_edStartIndex.EnableWindow(FALSE);
}
