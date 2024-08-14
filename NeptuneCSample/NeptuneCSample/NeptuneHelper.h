#pragma once

class CNeptuneContinuePlay
{
public:
	CNeptuneContinuePlay(NeptuneCamHandle pCameraHandle);
	virtual ~CNeptuneContinuePlay(void);

protected:
	NeptuneCamHandle m_pCameraHandle;
	ENeptuneBoolean m_bIsAcquisition;
};

