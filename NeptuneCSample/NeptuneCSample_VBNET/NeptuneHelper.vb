Imports NeptuneCSample_VBNET.NeptuneC_Interface

Public Class CNeptuneContinuePlay : Implements IDisposable

    Private m_bIsAcquisition As ENeptuneBoolean
    Private m_pCameraHandle As IntPtr

    Public Sub New(ByVal pCameraHandle As IntPtr)
        MyBase.New()
        m_pCameraHandle = pCameraHandle

        m_bIsAcquisition = ENeptuneBoolean.NEPTUNE_BOOL_FALSE
        If (m_pCameraHandle <> IntPtr.Zero) Then
            Dim bIsAcquisition As ENeptuneBoolean = ENeptuneBoolean.NEPTUNE_BOOL_FALSE
            If (NeptuneC.ntcGetAcquisition(m_pCameraHandle, bIsAcquisition) = ENeptuneError.NEPTUNE_ERR_Success) Then
                If (bIsAcquisition = ENeptuneBoolean.NEPTUNE_BOOL_TRUE) Then
                    If (NeptuneC.ntcSetAcquisition(m_pCameraHandle, ENeptuneBoolean.NEPTUNE_BOOL_FALSE) = ENeptuneError.NEPTUNE_ERR_Success) Then
                        m_bIsAcquisition = bIsAcquisition
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        If (m_bIsAcquisition = ENeptuneBoolean.NEPTUNE_BOOL_TRUE) Then
            If (m_pCameraHandle <> IntPtr.Zero) Then
                NeptuneC.ntcSetAcquisition(m_pCameraHandle, m_bIsAcquisition)
            End If
        End If
    End Sub

End Class
