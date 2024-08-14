// PopupCaptureDlg.cpp : 구현 파일입니다.
//

#include "stdafx.h"
#include "NeptuneCSample.h"
#include "PopupCaptureDlg.h"
#include "afxdialogex.h"


// CPopupCaptureDlg 대화 상자입니다.

IMPLEMENT_DYNAMIC(CPopupCaptureDlg, CPopupBaseDialog)

CPopupCaptureDlg::CPopupCaptureDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis)
	: CPopupBaseDialog(CPopupCaptureDlg::IDD, pCameraHandle, ppThis)
{
	m_bRecording = FALSE;
}

CPopupCaptureDlg::~CPopupCaptureDlg()
{
}

void CPopupCaptureDlg::DoDataExchange(CDataExchange* pDX)
{
	CPopupBaseDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_EDIT_SAVE_PATH, m_edSavePath);
	DDX_Control(pDX, IDC_COMBO_SAVE_FORMAT, m_cbImageForamt);
	DDX_Control(pDX, IDC_BUTTON_CAPTURE, m_btnSaveImage);
	DDX_Control(pDX, IDC_BUTTON_REC_STRAT, m_btnStartRecord);
	DDX_Control(pDX, IDC_BUTTON_REC_STOP, m_btnStopRecord);
}


BEGIN_MESSAGE_MAP(CPopupCaptureDlg, CPopupBaseDialog)
	ON_CBN_SELCHANGE(IDC_COMBO_SAVE_FORMAT, &CPopupCaptureDlg::OnCbnSelchangeComboSaveFormat)
	ON_BN_CLICKED(IDC_BUTTON_CAPTURE, &CPopupCaptureDlg::OnBnClickedButtonCapture)
	ON_BN_CLICKED(IDC_BUTTON_REC_STRAT, &CPopupCaptureDlg::OnBnClickedButtonRecStrat)
	ON_BN_CLICKED(IDC_BUTTON_REC_STOP, &CPopupCaptureDlg::OnBnClickedButtonRecStop)
END_MESSAGE_MAP()


void CPopupCaptureDlg::InitControls()
{
	TCHAR szFilePath[MAX_PATH] = {NULL, };
	GetModuleFileName(NULL, szFilePath, _countof(szFilePath));
	PathRemoveFileSpec(szFilePath);
	m_edSavePath.SetWindowText(szFilePath);
	m_edSavePath.EnableFolderBrowseButton();

	m_cbImageForamt.ResetContent();
	m_cbImageForamt.AddString(_T("RGB"));
	m_cbImageForamt.AddString(_T("BMP"));
	m_cbImageForamt.AddString(_T("JPG"));
	m_cbImageForamt.AddString(_T("TIF"));
	m_cbImageForamt.AddString(_T("AVI"));
	m_cbImageForamt.SetCurSel(0);
	OnCbnSelchangeComboSaveFormat();
}

void CPopupCaptureDlg::OnCbnSelchangeComboSaveFormat()
{
	int nItem = m_cbImageForamt.GetCurSel();
	if (nItem != CB_ERR)
	{
		CString strText = _T("");
		m_cbImageForamt.GetLBText(nItem, strText);
		m_btnSaveImage.EnableWindow(strText.CompareNoCase(_T("AVI")) != 0);
		m_btnStartRecord.EnableWindow(strText.CompareNoCase(_T("AVI")) == 0);
		m_btnStopRecord.EnableWindow(FALSE);
		if (strText.CompareNoCase(_T("AVI")) != 0 && m_bRecording)
		{
			OnBnClickedButtonRecStop();
		}
	}
}

void CPopupCaptureDlg::OnBnClickedButtonCapture()
{
	if (m_pCameraHandle)
	{
		SYSTEMTIME sysTime = {NULL, };
		GetLocalTime(&sysTime);

		CString strPathName = _T("");
		m_edSavePath.GetWindowText(strPathName);
		if (strPathName.Find(_T("\\"), strPathName.GetLength() - 2) == -1)
		{
			strPathName.Append(_T("\\"));
		}
		strPathName.AppendFormat(_T("Capture_%02d%02d%02d_%03d."), sysTime.wHour, sysTime.wMinute, sysTime.wSecond, sysTime.wMilliseconds);

		CString strExt = _T("");
		m_cbImageForamt.GetLBText(m_cbImageForamt.GetCurSel(), strExt);
		strPathName += strExt;

		USES_CONVERSION;
		CStringA strPathNameA = T2A(strPathName);

		ENeptuneError emErr = NEPTUNE_ERR_Fail;
		if (strExt.CompareNoCase(_T("RGB")) == 0)
		{
			NEPTUNE_IMAGE_SIZE stImageSize;
			emErr = ntcGetImageSize(m_pCameraHandle, &stImageSize);
			if (emErr == NEPTUNE_ERR_Success)
			{
				_uint32_t uiBufSize = stImageSize.nSizeX * stImageSize.nSizeY * 3;
				PBYTE pRGBBuffer = new BYTE[uiBufSize];
				ZeroMemory(pRGBBuffer, uiBufSize);
				emErr = ntcGetRGBData(m_pCameraHandle, pRGBBuffer, uiBufSize);
				if (emErr == NEPTUNE_ERR_Success)
				{
					FILE* fp = NULL;
					if (fopen_s(&fp, strPathNameA, "wb") == 0)
					{
						fwrite(pRGBBuffer, uiBufSize, 1, fp);
						fclose(fp);
					}
				}
				delete [] pRGBBuffer;
			}
		}
		else
		{
			emErr = ntcSaveImage(m_pCameraHandle, strPathNameA.GetBuffer(0), 100);
		}
		
		if (emErr == NEPTUNE_ERR_Success)
		{
			InsertLog(TYPE_INFORMATION, _T("Save Image") + strPathName);
		}
		else
		{
			InsertLog(TYPE_ERROR, _T("ntcSaveImage Failed."), emErr);
		}
	}
}

void CPopupCaptureDlg::OnBnClickedButtonRecStrat()
{
	if (m_pCameraHandle)
	{
		SYSTEMTIME sysTime = {NULL, };
		GetLocalTime(&sysTime);

		CString strPathName = _T("");
		m_edSavePath.GetWindowText(strPathName);
		if (strPathName.Find(_T("\\"), strPathName.GetLength() - 2) == -1)
		{
			strPathName.Append(_T("\\"));
		}
		strPathName.AppendFormat(_T("Capture_%02d%02d%02d_%03d.AVI"), sysTime.wHour, sysTime.wMinute, sysTime.wSecond, sysTime.wMilliseconds);

		USES_CONVERSION;
		ENeptuneError emErr = ntcStartStreamCapture(m_pCameraHandle, T2A(strPathName), NEPTUNE_BOOL_TRUE, 4000);
		if (emErr == NEPTUNE_ERR_Success)
		{
			m_bRecording = TRUE;
			m_btnStartRecord.EnableWindow(!m_bRecording);
			m_btnStopRecord.EnableWindow(m_bRecording);
			InsertLog(TYPE_INFORMATION, _T("Start Recording: ") + strPathName);
		}
		else
		{
			InsertLog(TYPE_ERROR, _T("ntcStartStreamCapture Failed."), emErr);
		}
	}
}

void CPopupCaptureDlg::OnBnClickedButtonRecStop()
{
	if (m_pCameraHandle)
	{
		ENeptuneError emErr = ntcStopStreamCapture(m_pCameraHandle);
		if (emErr == NEPTUNE_ERR_Success)
		{
			m_bRecording = FALSE;
			m_btnStartRecord.EnableWindow(!m_bRecording);
			m_btnStopRecord.EnableWindow(m_bRecording);
			InsertLog(TYPE_INFORMATION, _T("Stop Recording."));
		}
		else
		{
			InsertLog(TYPE_ERROR, _T("ntcStopStreamCapture Failed."), emErr);
		}
	}
}
