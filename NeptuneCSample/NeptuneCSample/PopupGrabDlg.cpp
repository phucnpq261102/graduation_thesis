// PopupGrabDlg.cpp : 구현 파일입니다.
//

#include "stdafx.h"
#include "NeptuneCSample.h"
#include "PopupGrabDlg.h"
#include "afxdialogex.h"


// CPopupGrabDlg 대화 상자입니다.

IMPLEMENT_DYNAMIC(CPopupGrabDlg, CPopupBaseDialog)

CPopupGrabDlg::CPopupGrabDlg(NeptuneCamHandle& pCameraHandle, CWnd** ppThis)
	: CPopupBaseDialog(CPopupGrabDlg::IDD, pCameraHandle, ppThis)
{

}

CPopupGrabDlg::~CPopupGrabDlg()
{
}

void CPopupGrabDlg::DoDataExchange(CDataExchange* pDX)
{
	CPopupBaseDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_EDIT_SAVE_PATH, m_edSavePath);
}


BEGIN_MESSAGE_MAP(CPopupGrabDlg, CPopupBaseDialog)
	ON_BN_CLICKED(IDC_BUTTON_GRAB, &CPopupGrabDlg::OnBnClickedButtonGrab)
END_MESSAGE_MAP()

void CPopupGrabDlg::InitControls()
{
	TCHAR szFilePath[MAX_PATH] = {NULL, };
	GetModuleFileName(NULL, szFilePath, _countof(szFilePath));
	PathRemoveFileSpec(szFilePath);
	m_edSavePath.SetWindowText(szFilePath);
	m_edSavePath.EnableFolderBrowseButton();
}

void CPopupGrabDlg::OnBnClickedButtonGrab()
{
	if (m_pCameraHandle)
	{
		_uint32_t uiSize = 0;
		ENeptuneError emErr = ntcGetBufferSize(m_pCameraHandle, &uiSize);
		if (emErr == NEPTUNE_ERR_Success)
		{
			NEPTUNE_IMAGE stImageInfo;
			stImageInfo.pData = new _uchar_t[uiSize];
			emErr = ntcGrab(m_pCameraHandle, &stImageInfo, NEPTUNE_GRAB_RAW, 1000);
			if (emErr == NEPTUNE_ERR_Success)
			{
				SYSTEMTIME sysTime = {NULL, };
				GetLocalTime(&sysTime);

				CString strPathName = _T("");
				m_edSavePath.GetWindowText(strPathName);
				if (strPathName.Find(_T("\\"), strPathName.GetLength() - 2) == -1)
				{
					strPathName.Append(_T("\\"));
				}
				strPathName.AppendFormat(_T("Grab_%02d%02d%02d_%03d.raw"), sysTime.wHour, sysTime.wMinute, sysTime.wSecond, sysTime.wMilliseconds);

				FILE* fp = NULL;
				if (_tfopen_s(&fp, strPathName, _T("wb")) == 0)
				{
					fwrite(stImageInfo.pData, uiSize, 1, fp);
					fclose(fp);
				}
				InsertLog(TYPE_INFORMATION, _T("Grab Image: ") + strPathName);
			}
			else
			{
				InsertLog(TYPE_ERROR, _T("ntcGrab Failed."), emErr);
			}
			
			delete [] stImageInfo.pData;
		}
		else
		{
			InsertLog(TYPE_ERROR, _T("ntcGetBufferSize Failed."), emErr);
		}
	}
}

