
// NeptuneCSample.h : PROJECT_NAME ���� ���α׷��� ���� �� ��� �����Դϴ�.
//

#pragma once

#ifndef __AFXWIN_H__
	#error "PCH�� ���� �� ������ �����ϱ� ���� 'stdafx.h'�� �����մϴ�."
#endif

#include "resource.h"		// �� ��ȣ�Դϴ�.


// CNeptuneCSampleApp:
// �� Ŭ������ ������ ���ؼ��� NeptuneCSample.cpp�� �����Ͻʽÿ�.
//

class CNeptuneCSampleApp : public CWinApp
{
public:
	CNeptuneCSampleApp();

// �������Դϴ�.
public:
	virtual BOOL InitInstance();

// �����Դϴ�.

	DECLARE_MESSAGE_MAP()
};

extern CNeptuneCSampleApp theApp;