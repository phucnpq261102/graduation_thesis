#include "StdAfx.h"
#include "NeptuneHelper.h"


CNeptuneContinuePlay::CNeptuneContinuePlay(NeptuneCamHandle pCameraHandle)
	: m_pCameraHandle(pCameraHandle)
{
	m_bIsAcquisition = NEPTUNE_BOOL_FALSE;
	if (m_pCameraHandle)
	{
		ENeptuneBoolean bIsAcquisition = NEPTUNE_BOOL_FALSE;
		if (ntcGetAcquisition(m_pCameraHandle, &bIsAcquisition) == NEPTUNE_ERR_Success)
		{
			if (bIsAcquisition == NEPTUNE_BOOL_TRUE)
			{
				if (ntcSetAcquisition(m_pCameraHandle, NEPTUNE_BOOL_FALSE) == NEPTUNE_ERR_Success)
				{
					m_bIsAcquisition = bIsAcquisition;
				}
			}
		}
	}
}

CNeptuneContinuePlay::~CNeptuneContinuePlay(void)
{
	if (m_bIsAcquisition == NEPTUNE_BOOL_TRUE)
	{
		if (m_pCameraHandle)
		{
			ntcSetAcquisition(m_pCameraHandle, m_bIsAcquisition);
		}
	}
}