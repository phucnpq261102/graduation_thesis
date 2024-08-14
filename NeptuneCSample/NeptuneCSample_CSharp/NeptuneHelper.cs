using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NeptuneC_Interface;

namespace NeptuneCSample_CSharp
{
    public class CNeptuneContinuePlay : IDisposable
    {
        private ENeptuneBoolean m_bIsAcquisition;
        private IntPtr m_pCameraHandle;

        public CNeptuneContinuePlay(IntPtr pCameraHandle)
        {
            m_pCameraHandle = pCameraHandle;

            m_bIsAcquisition = ENeptuneBoolean.NEPTUNE_BOOL_FALSE;
            if (m_pCameraHandle != IntPtr.Zero)
            {
                ENeptuneBoolean bIsAcquisition = ENeptuneBoolean.NEPTUNE_BOOL_FALSE;
                if (NeptuneC.ntcGetAcquisition(m_pCameraHandle, ref bIsAcquisition) == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    if (bIsAcquisition == ENeptuneBoolean.NEPTUNE_BOOL_TRUE)
                    {
                        if (NeptuneC.ntcSetAcquisition(m_pCameraHandle, ENeptuneBoolean.NEPTUNE_BOOL_FALSE) == ENeptuneError.NEPTUNE_ERR_Success)
                        {
                            m_bIsAcquisition = bIsAcquisition;
                        }
                    }
                }
            }
        }

        public void Dispose()
        {
            if (m_bIsAcquisition == ENeptuneBoolean.NEPTUNE_BOOL_TRUE)
            {
                if (m_pCameraHandle != IntPtr.Zero)
                {
                    NeptuneC.ntcSetAcquisition(m_pCameraHandle, m_bIsAcquisition);
                }
            }
        }
    }
}
