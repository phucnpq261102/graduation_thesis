#pragma once

typedef struct tagRangeLong {
	LONG		nlMin;
	LONG		nlMax;

	tagRangeLong() {
		nlMin = 0;
		nlMax = 0;
	}
} RANGE_LONG, *PRANGE_LONG, *LPRANGE_LONG;

class CTableEdit : public CEdit
{
public:
	CTableEdit();
	virtual ~CTableEdit();
	virtual BOOL PreTranslateMessage(MSG* pMsg);

	void SetItem(int nItem, int nSubItem);
	int GetItem() {return m_nItem;}
	int GetSubItem() {return m_nSubItem;}

protected:
	int m_nItem;
	int m_nSubItem;
};


// CTableListCtrl

class CTableListCtrl : public CMFCListCtrl
{
	DECLARE_DYNAMIC(CTableListCtrl)

public:
	CTableListCtrl();
	virtual ~CTableListCtrl();

	virtual COLORREF OnGetCellBkColor(int nRow, int nColum);

protected:
	void CreateEditCtrl();

protected:
	CTableEdit* m_pedtSubItem;

protected:
	DECLARE_MESSAGE_MAP()
public:
	virtual void PreSubclassWindow();
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnDestroy();
	afx_msg void OnEnKillfocusTableEdit();
	afx_msg void OnNMDblclk(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnNMClick(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnNMRClick(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnNMRDblclk(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnHScroll(UINT nSBCode, UINT nPos, CScrollBar* pScrollBar);
	afx_msg void OnVScroll(UINT nSBCode, UINT nPos, CScrollBar* pScrollBar);
	afx_msg void OnHdnBegintrack(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnHdnDividerdblclick(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnMouseHWheel(UINT nFlags, short zDelta, CPoint pt);
	afx_msg BOOL OnMouseWheel(UINT nFlags, short zDelta, CPoint pt);
	afx_msg void OnLvnColumnclick(NMHDR *pNMHDR, LRESULT *pResult);
};


