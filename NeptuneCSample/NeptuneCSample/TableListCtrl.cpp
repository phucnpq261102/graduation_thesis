// TableListCtrl.cpp : 구현 파일입니다.
//

#include "stdafx.h"
#include "NeptuneCSample.h"
#include "TableListCtrl.h"



CTableEdit::CTableEdit()
{
	m_nItem		= -1;
	m_nSubItem	= -1;
}
CTableEdit::~CTableEdit()
{

}

void CTableEdit::SetItem(int nItem, int nSubItem)
{
	m_nItem		= nItem;
	m_nSubItem	= nSubItem;
}

BOOL CTableEdit::PreTranslateMessage(MSG* pMsg)
{
	if (pMsg->message == WM_KEYDOWN) {
		if (pMsg->wParam == VK_RETURN) {
			CListCtrl* pParentWnd = (CListCtrl*)GetParent();
			if (pParentWnd) {
				pParentWnd->SetFocus();
			}
			return TRUE;
		} else if (pMsg->wParam == VK_ESCAPE) {
			CListCtrl* pParentWnd = (CListCtrl*)GetParent();
			if (pParentWnd) {
				CString strText = pParentWnd->GetItemText(m_nItem, m_nSubItem);
				SetWindowText(strText);
				pParentWnd->SetFocus();
			}
			return TRUE;
		}
	}

	return CEdit::PreTranslateMessage(pMsg);
}



// CTableListCtrl

IMPLEMENT_DYNAMIC(CTableListCtrl, CMFCListCtrl)

CTableListCtrl::CTableListCtrl()
{
	m_pedtSubItem	= NULL;
}

CTableListCtrl::~CTableListCtrl()
{
}


BEGIN_MESSAGE_MAP(CTableListCtrl, CMFCListCtrl)
	ON_WM_CREATE()
	ON_WM_DESTROY()
	ON_EN_KILLFOCUS(ID_TABLE_EDIT, &CTableListCtrl::OnEnKillfocusTableEdit)
	ON_NOTIFY_REFLECT(NM_DBLCLK, &CTableListCtrl::OnNMDblclk)
	ON_NOTIFY_REFLECT(NM_CLICK, &CTableListCtrl::OnNMClick)
	ON_NOTIFY_REFLECT(NM_RCLICK, &CTableListCtrl::OnNMRClick)
	ON_NOTIFY_REFLECT(NM_RDBLCLK, &CTableListCtrl::OnNMRDblclk)
	ON_WM_HSCROLL()
	ON_WM_VSCROLL()
	ON_NOTIFY(HDN_BEGINTRACKA, 0, &CTableListCtrl::OnHdnBegintrack)
	ON_NOTIFY(HDN_BEGINTRACKW, 0, &CTableListCtrl::OnHdnBegintrack)
	ON_NOTIFY(HDN_DIVIDERDBLCLICKA, 0, &CTableListCtrl::OnHdnDividerdblclick)
	ON_NOTIFY(HDN_DIVIDERDBLCLICKW, 0, &CTableListCtrl::OnHdnDividerdblclick)
	ON_WM_MOUSEHWHEEL()
	ON_WM_MOUSEWHEEL()
	ON_NOTIFY_REFLECT(LVN_COLUMNCLICK, &CTableListCtrl::OnLvnColumnclick)
END_MESSAGE_MAP()



// CTableListCtrl 메시지 처리기입니다.

COLORREF CTableListCtrl::OnGetCellBkColor(int nRow, int nColum)
{
	COLORREF clr = CMFCListCtrl::OnGetCellBkColor(nRow, nColum);

	if (nColum == 0) {
		clr = afxGlobalData.clrBtnFace;
	}

	return clr;
}

void CTableListCtrl::PreSubclassWindow()
{
	CMFCListCtrl::PreSubclassWindow();

	CreateEditCtrl();
}


int CTableListCtrl::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CMFCListCtrl::OnCreate(lpCreateStruct) == -1)
		return -1;

	CreateEditCtrl();
	
	return 0;
}

void CTableListCtrl::CreateEditCtrl()
{
	CRect rectDummy(0, 0, 0, 0);

	m_pedtSubItem = new CTableEdit;
	if (m_pedtSubItem->Create(WS_CHILD | WS_VISIBLE | WS_TABSTOP | WS_BORDER | ES_CENTER | ES_NUMBER, rectDummy, this, ID_TABLE_EDIT)) {
		m_pedtSubItem->SetFont(&afxGlobalData.fontRegular);
	}
}

void CTableListCtrl::OnDestroy()
{
	if (m_pedtSubItem) {
		delete m_pedtSubItem;
		m_pedtSubItem = NULL;
	}

	CMFCListCtrl::OnDestroy();
}

void CTableListCtrl::OnEnKillfocusTableEdit()
{
	CString strText = _T("");
	m_pedtSubItem->GetWindowText(strText);

	PRANGE_LONG pRange = NULL;
	HDITEM hdi	= {NULL, };
	hdi.mask	= HDI_LPARAM;
	if (GetHeaderCtrl().GetItem(m_pedtSubItem->GetSubItem(), &hdi)) {
		pRange = (PRANGE_LONG)hdi.lParam;
	}

	if (pRange) {
		LONG nlValue = _ttol(strText);
		if (nlValue < pRange->nlMin) {
			strText.Format(_T("%d"), pRange->nlMin);
		} else if (nlValue > pRange->nlMax) {
			strText.Format(_T("%d"), pRange->nlMax);
		}
	}
	SetItemText(m_pedtSubItem->GetItem(), m_pedtSubItem->GetSubItem(), strText);
	m_pedtSubItem->ShowWindow(SW_HIDE);
	m_pedtSubItem->SetItem(-1, -1);
}

void CTableListCtrl::OnNMDblclk(NMHDR *pNMHDR, LRESULT *pResult)
{
	LPNMITEMACTIVATE pNMItemActivate = reinterpret_cast<LPNMITEMACTIVATE>(pNMHDR);

	if (GetFocus() != this) {
		SetFocus();
	}
	
	if (pNMItemActivate->iItem != -1) {
		if (pNMItemActivate->iSubItem != -1 && pNMItemActivate->iSubItem != 0) {
			CRect rectSub;
			GetSubItemRect(pNMItemActivate->iItem, pNMItemActivate->iSubItem, LVIR_BOUNDS, rectSub);
			if (m_pedtSubItem && m_pedtSubItem->GetSafeHwnd()) {
				m_pedtSubItem->SetItem(pNMItemActivate->iItem, pNMItemActivate->iSubItem);

				CString strText = GetItemText(pNMItemActivate->iItem, pNMItemActivate->iSubItem);
				m_pedtSubItem->SetWindowText(strText);
				m_pedtSubItem->SetSel(0, -1);
				m_pedtSubItem->MoveWindow(rectSub);
				m_pedtSubItem->ShowWindow(SW_SHOW);
				m_pedtSubItem->SetFocus();
			}
		}
	}

	*pResult = 0;
}

void CTableListCtrl::OnNMClick(NMHDR *pNMHDR, LRESULT *pResult)
{
	LPNMITEMACTIVATE pNMItemActivate = reinterpret_cast<LPNMITEMACTIVATE>(pNMHDR);
	if (GetFocus() != this) {
		SetFocus();
	}
	*pResult = 0;
}

void CTableListCtrl::OnNMRClick(NMHDR *pNMHDR, LRESULT *pResult)
{
	LPNMITEMACTIVATE pNMItemActivate = reinterpret_cast<LPNMITEMACTIVATE>(pNMHDR);
	if (GetFocus() != this) {
		SetFocus();
	}
	*pResult = 0;
}

void CTableListCtrl::OnNMRDblclk(NMHDR *pNMHDR, LRESULT *pResult)
{
	LPNMITEMACTIVATE pNMItemActivate = reinterpret_cast<LPNMITEMACTIVATE>(pNMHDR);
	if (GetFocus() != this) {
		SetFocus();
	}
	*pResult = 0;
}


void CTableListCtrl::OnHScroll(UINT nSBCode, UINT nPos, CScrollBar* pScrollBar)
{
	CMFCListCtrl::OnHScroll(nSBCode, nPos, pScrollBar);
	if (GetFocus() != this) {
		SetFocus();
	}
}


void CTableListCtrl::OnVScroll(UINT nSBCode, UINT nPos, CScrollBar* pScrollBar)
{
	CMFCListCtrl::OnVScroll(nSBCode, nPos, pScrollBar);
	if (GetFocus() != this) {
		SetFocus();
	}
}

void CTableListCtrl::OnHdnBegintrack(NMHDR *pNMHDR, LRESULT *pResult)
{
	LPNMHEADER phdr = reinterpret_cast<LPNMHEADER>(pNMHDR);
	if (GetFocus() != this) {
		SetFocus();
	}
	*pResult = 0;
}

void CTableListCtrl::OnHdnDividerdblclick(NMHDR *pNMHDR, LRESULT *pResult)
{
	LPNMHEADER phdr = reinterpret_cast<LPNMHEADER>(pNMHDR);
	if (GetFocus() != this) {
		SetFocus();
	}
	*pResult = 0;
}

void CTableListCtrl::OnMouseHWheel(UINT nFlags, short zDelta, CPoint pt)
{
	CMFCListCtrl::OnMouseHWheel(nFlags, zDelta, pt);
	if (GetFocus() != this) {
		SetFocus();
	}
}


BOOL CTableListCtrl::OnMouseWheel(UINT nFlags, short zDelta, CPoint pt)
{
	BOOL bRet = CMFCListCtrl::OnMouseWheel(nFlags, zDelta, pt);
	if (GetFocus() != this) {
		SetFocus();
	}
	return bRet;
}


void CTableListCtrl::OnLvnColumnclick(NMHDR *pNMHDR, LRESULT *pResult)
{
	LPNMLISTVIEW pNMLV = reinterpret_cast<LPNMLISTVIEW>(pNMHDR);
	
	*pResult = 0;
}

