#pragma once


// CLutWnd

class CLutWnd : public CWnd
{
	DECLARE_DYNAMIC(CLutWnd)

public:
	typedef struct _tagLutInfo
	{
		CEdit* pedtX;
		CEdit* pedtY;
		CPoint point;
	} LUT_INFO, *PLUT_INFO;

	CLutWnd(const CSize& sizeMaxLut, CEdit* pedtX1, CEdit* pedtY1, CEdit* pedtX2, CEdit* pedtY2, CEdit* pedtX3, CEdit* pedtY3, CEdit* pedtX4, CEdit* pedtY4);
	virtual ~CLutWnd();

	void UpdateLUT();

protected:
	const CSize& m_sizeMaxLut;
	LONG m_nlClientHeight;
	double m_fRatioX;
	double m_fRatioY;

	int m_nHitTest;

	LUT_INFO m_LutInfo[4];
	CMap<INT, INT, CRect, const CRect&> m_mapPointRects;

protected:
	DECLARE_MESSAGE_MAP()

	void OnDraw(CDC* pDCSrc);
	void OnFillBackground(CDC* pDC, CRect rectClient);
	void OnDrawLutLine(CDC* pDC, CDrawingManager* pDM, CRect rectClient);
	void OnDrawLutMarker(CDrawingManager* pDM, CRect rectClient);

	int MarkerHitTest(const CPoint& pt);
public:
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg BOOL OnEraseBkgnd(CDC* pDC);
	afx_msg void OnPaint();
	afx_msg void OnLButtonDown(UINT nFlags, CPoint point);
	afx_msg void OnLButtonUp(UINT nFlags, CPoint point);
	afx_msg void OnMouseMove(UINT nFlags, CPoint point);
	afx_msg BOOL OnSetCursor(CWnd* pWnd, UINT nHitTest, UINT message);
};


