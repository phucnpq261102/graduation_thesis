// LutWnd.cpp : 구현 파일입니다.
//

#include "stdafx.h"
#include "NeptuneCSample.h"
#include "LutWnd.h"
#include "PopupLutDlg.h"


// CLutWnd
const int nMarkerSize = 5;

IMPLEMENT_DYNAMIC(CLutWnd, CWnd)

CLutWnd::CLutWnd(const CSize& sizeMaxLut, CEdit* pedtX1, CEdit* pedtY1, CEdit* pedtX2, CEdit* pedtY2, CEdit* pedtX3, CEdit* pedtY3, CEdit* pedtX4, CEdit* pedtY4)
	: m_sizeMaxLut(sizeMaxLut)
{
	m_LutInfo[0].pedtX = pedtX1;
	m_LutInfo[0].pedtY = pedtY1;
	m_LutInfo[1].pedtX = pedtX2;
	m_LutInfo[1].pedtY = pedtY2;
	m_LutInfo[2].pedtX = pedtX3;
	m_LutInfo[2].pedtY = pedtY3;
	m_LutInfo[3].pedtX = pedtX4;
	m_LutInfo[3].pedtY = pedtY4;

	m_nlClientHeight = 0;
	m_fRatioX = 1.f;
	m_fRatioY = 1.f;

	m_nHitTest	= -1;
}

CLutWnd::~CLutWnd()
{
}


BEGIN_MESSAGE_MAP(CLutWnd, CWnd)
	ON_WM_CREATE()
	ON_WM_ERASEBKGND()
	ON_WM_PAINT()
	ON_WM_LBUTTONDOWN()
	ON_WM_LBUTTONUP()
	ON_WM_MOUSEMOVE()
	ON_WM_SETCURSOR()
END_MESSAGE_MAP()



// CLutWnd 메시지 처리기입니다.


void CLutWnd::UpdateLUT()
{
	CString strValueX = _T("");
	CString strValueY = _T("");
	for (size_t i=0; i<_countof(m_LutInfo); i++)
	{
		m_LutInfo[i].pedtX->GetWindowText(strValueX);
		m_LutInfo[i].pedtY->GetWindowText(strValueY);
		m_LutInfo[i].point.x = (LONG)(m_fRatioX * _ttol(strValueX));
		m_LutInfo[i].point.y = (LONG)(m_nlClientHeight - (m_fRatioY * _ttol(strValueY)));

		CRect rectMarker(m_LutInfo[i].point, m_LutInfo[i].point);
		rectMarker.InflateRect(nMarkerSize, nMarkerSize);
		m_mapPointRects[i] = rectMarker;
	}
	RedrawWindow(NULL, NULL, RDW_INVALIDATE | RDW_FRAME | RDW_UPDATENOW | RDW_ALLCHILDREN);
}

int CLutWnd::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CWnd::OnCreate(lpCreateStruct) == -1)
		return -1;

	CRect rectClient;
	GetClientRect(rectClient);

	m_nlClientHeight = rectClient.Height();
	m_fRatioX = rectClient.Width() / (double)m_sizeMaxLut.cx;
	m_fRatioY = rectClient.Height() / (double)m_sizeMaxLut.cy;

	return 0;
}


BOOL CLutWnd::OnEraseBkgnd(CDC* pDC)
{
	return TRUE;
}


void CLutWnd::OnPaint()
{
	CPaintDC dc(this);
	OnDraw(&dc);
}

void CLutWnd::OnDraw(CDC* pDCSrc)
{
	CMemDC memDC(*pDCSrc, this);
	CDC* pDC = &memDC.GetDC();

	CRect rectClient;
	GetClientRect(rectClient);

	OnFillBackground(pDC, rectClient);

	CDrawingManager dm(*pDC);
	OnDrawLutLine(pDC, &dm, rectClient);
	OnDrawLutMarker(&dm, rectClient);
}

void CLutWnd::OnFillBackground(CDC* pDC, CRect rectClient)
{
	pDC->FillRect(rectClient, &afxGlobalData.brWindow);

	CPen penDot;
	penDot.CreatePen(PS_DOT, 0, RGB(128, 128, 128));
	CPen* pOldPen = pDC->SelectObject(&penDot);

	for (int x=rectClient.left; x<rectClient.right; x+=40)
	{
		if (x != 0)
		{
			pDC->MoveTo(x, rectClient.top);
			pDC->LineTo(x, rectClient.bottom);
		}
	}
	for (int y=rectClient.bottom; y>=rectClient.top; y-=40)
	{
		if (y != 0)
		{
			pDC->MoveTo(rectClient.left, y);
			pDC->LineTo(rectClient.right, y);
		}
	}

	pDC->SelectObject(pOldPen);
}

void CLutWnd::OnDrawLutLine(CDC* pDC, CDrawingManager* pDM, CRect rectClient)
{
	COLORREF clrLine = IsWindowEnabled() ? RGB(0, 0, 255) : RGB(128, 128, 128);

	size_t nCnt = _countof(m_LutInfo);
	for (size_t i=0; i<nCnt; i++)
	{
		if (i == nCnt-1)
		{
			pDM->DrawLineA(m_LutInfo[i].point.x, m_LutInfo[i].point.y, rectClient.right, rectClient.top, clrLine);
		}
		else
		{
			if (i == 0)
			{
				pDM->DrawLineA(rectClient.left, rectClient.bottom, m_LutInfo[i].point.x, m_LutInfo[i].point.y, clrLine);
			}
			pDM->DrawLineA(m_LutInfo[i].point.x, m_LutInfo[i].point.y, m_LutInfo[i+1].point.x, m_LutInfo[i+1].point.y, clrLine);
		}
	}
}

void CLutWnd::OnDrawLutMarker(CDrawingManager* pDM, CRect rectClient)
{
	COLORREF clrFill = IsWindowEnabled() ? RGB(173, 216, 230) : RGB(128, 128, 128);
	COLORREF clrLine = IsWindowEnabled() ? RGB(70, 130, 180) : RGB(128, 128, 128);

	for (POSITION pos = m_mapPointRects.GetStartPosition (); pos != NULL;)
	{
		INT nHitTest = 0;
		CRect rect;
		m_mapPointRects.GetNextAssoc(pos, nHitTest, rect);
		pDM->DrawEllipse(rect, clrFill, clrLine);
	}
}



void CLutWnd::OnLButtonDown(UINT nFlags, CPoint point)
{
	CWnd::OnLButtonDown(nFlags, point);

	m_nHitTest = MarkerHitTest(point);
	if (m_nHitTest != -1)
	{
		SetCapture();
	}
}


void CLutWnd::OnLButtonUp(UINT nFlags, CPoint point)
{
	CWnd::OnLButtonUp(nFlags, point);

	if (m_nHitTest != -1)
	{
		ReleaseCapture();
		m_nHitTest = -1;
	}
}


void CLutWnd::OnMouseMove(UINT nFlags, CPoint point)
{
	if (m_nHitTest != -1)
	{
		CRect rectClient;
		GetClientRect(rectClient);

		CPoint ptCur = point;

		if (ptCur.x < rectClient.left)
		{
			ptCur.x = rectClient.left;
		}
		else if (ptCur.x > rectClient.right)
		{
			ptCur.x = rectClient.right;
		}

		if (ptCur.y < rectClient.top)
		{
			ptCur.y = rectClient.top;
		}
		else if (ptCur.y > rectClient.bottom)
		{
			ptCur.y = rectClient.bottom;
		}

		m_LutInfo[m_nHitTest].point = ptCur;

		CRect rectMarker(m_LutInfo[m_nHitTest].point, m_LutInfo[m_nHitTest].point);
		rectMarker.InflateRect(nMarkerSize, nMarkerSize);
		m_mapPointRects[m_nHitTest] = rectMarker;

		CPoint ptConv;
		ptConv.x = (LONG)(m_LutInfo[m_nHitTest].point.x / m_fRatioX);
		ptConv.y = (LONG)((m_nlClientHeight - m_LutInfo[m_nHitTest].point.y) / m_fRatioY);

		CString strValueX = _T("");
		CString strValueY = _T("");
		strValueX.Format(_T("%d"), ptConv.x);
		strValueY.Format(_T("%d"), ptConv.y);
		m_LutInfo[m_nHitTest].pedtX->SetWindowText(strValueX);
		m_LutInfo[m_nHitTest].pedtY->SetWindowText(strValueY);

		RedrawWindow(NULL, NULL, RDW_INVALIDATE | RDW_FRAME | RDW_UPDATENOW | RDW_ALLCHILDREN);
	}

	CWnd::OnMouseMove(nFlags, point);
}

int CLutWnd::MarkerHitTest(const CPoint& pt)
{
	int nHitTestRet = -1;
	for (POSITION pos = m_mapPointRects.GetStartPosition (); pos != NULL;)
	{
		CRect rect;
		INT nHitTest = 0;
		m_mapPointRects.GetNextAssoc(pos, nHitTest, rect);
		if (rect.PtInRect(pt)) {
			nHitTestRet = nHitTest;
			break;
		}
	}
	return nHitTestRet;
}


BOOL CLutWnd::OnSetCursor(CWnd* pWnd, UINT nHitTest, UINT message)
{
	CPoint ptCursor;
	GetCursorPos(&ptCursor);
	ScreenToClient(&ptCursor);
	int nMarkerHitTest = MarkerHitTest(ptCursor);
	if (nMarkerHitTest != -1) {
		SetCursor(AfxGetApp()->LoadStandardCursor(IDC_SIZEALL));
		return TRUE;
	}

	return CWnd::OnSetCursor(pWnd, nHitTest, message);
}
