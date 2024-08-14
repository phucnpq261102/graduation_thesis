using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using NeptuneC_Interface;

namespace NeptuneCSample_CSharp
{
    public partial class NeptuneCSampleForm : Form
    {
        public IntPtr m_pCameraHandle = IntPtr.Zero;

        private NeptuneC_Interface.NeptuneCDevCheckCallback DeviceCheckCallbackInst;
        private NeptuneC_Interface.NeptuneCUnplugCallback DeviceUnplugCallbackInst;
        private NeptuneC_Interface.NeptuneCFrameCallback FrameCallbackInst;
        private NeptuneC_Interface.NeptuneCFrameDropCallback FrameDropCallbackInst;

        public PopupFeatureForm m_formPopupFeature = null;
        public PopupCaptureForm m_formPopupCapture = null;
        public PopupResolutionForm m_formPopupResolution = null;
        public PopupTriggerForm m_formPopupTrigger = null;
        public PopupStrobeForm m_formPopupStrobe = null;
        public PopupAutoFocusForm m_formPopupAutoFocus = null;
        public PopupFrameSaveForm m_formPopupFrameSave = null;
        public PopupSIOControlForm m_formPopupSIOControl = null;
        public PopupLUTForm m_formPopupLUT = null;
        public PopupUserSetForm m_formPopupUserSet = null;
        public PopupThermalForm m_formPopupThermal = null;
        public PopupAltLedForm m_formPopupAltLed = null;
        public PopupStackedROIForm m_formPopupStackedROI = null;
        public CONTROL_PANEL m_formCONTROL_PANEL = null;

        private bool m_bFrameRateSupport = true;
        private UInt64 m_uiTotalFrameCount = 0;

        delegate void SetTotalFrameCountCallback(UInt64 uiTotalFrameCount);

        public NeptuneCSampleForm()
        {
            InitializeComponent();
        }

        private void NeptuneCSample_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            NeptuneC.ntcInit();

            InitFixedItemList();
            InitCameraList();
            UpdateControlActivate();

            DeviceCheckCallbackInst = new NeptuneC_Interface.NeptuneCDevCheckCallback(DeviceCheckCallbackFunc);
            DeviceUnplugCallbackInst = new NeptuneC_Interface.NeptuneCUnplugCallback(DeviceUnplugCallbackFunc);
            FrameCallbackInst = new NeptuneC_Interface.NeptuneCFrameCallback(FrameCallbackFunc);
            NeptuneC.ntcSetDeviceCheckCallback(DeviceCheckCallbackInst, this.Handle);
            
        }
        //private Bitmap bitmap;
        //private void Get_Image_Function_Callback()
        //{
        //    //-------------------------
        //    ENeptuneError emErr = ENeptuneError.NEPTUNE_ERR_Fail;
        //    NEPTUNE_IMAGE_SIZE stImageSize = new NEPTUNE_IMAGE_SIZE();
        //    emErr = NeptuneC.ntcGetImageSize(m_pCameraHandle, ref stImageSize);
        //    if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
        //    {
        //        UInt32 uiBufSize = (UInt32)(stImageSize.nSizeX * stImageSize.nSizeY * 3);
        //        Byte[] arrBuffer = new Byte[uiBufSize];
        //        emErr = NeptuneC.ntcGetRGBData(m_pCameraHandle, arrBuffer, uiBufSize);
        //        if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
        //        {
        //            // Tạo một ảnh bitmap từ dữ liệu RGB
        //            bitmap = new Bitmap(stImageSize.nSizeX, stImageSize.nSizeY, PixelFormat.Format24bppRgb);
        //            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, stImageSize.nSizeX, stImageSize.nSizeY), ImageLockMode.WriteOnly, bitmap.PixelFormat);
        //            IntPtr ptr = bmpData.Scan0;
        //            System.Runtime.InteropServices.Marshal.Copy(arrBuffer, 0, ptr, arrBuffer.Length);
        //            bitmap.UnlockBits(bmpData);
        //            // In ra kích thước của ảnh bitmap
        //            Console.WriteLine("Width: " + bitmap.Width);
        //            Console.WriteLine("Height: " + bitmap.Height);
        //            // Hiển thị ảnh bitmap lên pictureBox1
        //            pictureBox1.Image = bitmap;
        //        }
        //    }
        //}
        private void NeptuneCSample_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseCameraHandle();
            NeptuneC.ntcUninit();
        }

        private void DeviceCheckCallbackFunc(ENeptuneDeviceChangeState emState, IntPtr pContext)
        {
            // 크로스 스레드 작업 오류에 대한 임시방편
            CheckForIllegalCrossThreadCalls = false;

            InitCameraList();
            String strMsg = (emState == ENeptuneDeviceChangeState.NEPTUNE_DEVICE_ADDED ? "Device has been added." : "Device has been removed.");
            InsertLog(EM_LOG_LEVEL.TYPE_EVENT, strMsg);
        }

        private void DeviceUnplugCallbackFunc(IntPtr pContext)
        {
            // 크로스 스레드 작업 오류에 대한 임시방편
            CheckForIllegalCrossThreadCalls = false;

            InitCameraList();
            InsertLog(EM_LOG_LEVEL.TYPE_EVENT, "Selected camera was unplugged.");
        }

        private void FrameCallbackFunc(ref NEPTUNE_IMAGE stImage, IntPtr pContext)
        {
            m_uiTotalFrameCount++;
            //Get_Image_Function_Callback();
            //Console.WriteLine("OKKKKK");
        }

        private void CloseCameraHandle()
        {
            if (m_pCameraHandle != IntPtr.Zero)
            {
                m_btnStop.PerformClick();
                NeptuneC.ntcClose(m_pCameraHandle);
                m_pCameraHandle = IntPtr.Zero;
            }
        }

        public void UpdatePopupForms(bool bDelete)
        {
            if (bDelete)
            {
                if (m_formPopupFeature != null)
                {
                    m_formPopupFeature.Close();
                }
                if (m_formPopupCapture != null)
                {
                    m_formPopupCapture.Close();
                }
                if (m_formPopupResolution != null)
                {
                    m_formPopupResolution.Close();
                }
                if (m_formPopupTrigger != null)
                {
                    m_formPopupTrigger.Close();
                }
                if (m_formPopupStrobe != null)
                {
                    m_formPopupStrobe.Close();
                }
                if (m_formPopupAutoFocus != null)
                {
                    m_formPopupAutoFocus.Close();
                }
                if (m_formPopupFrameSave != null)
                {
                    m_formPopupFrameSave.Close();
                }
                if (m_formPopupSIOControl != null)
                {
                    m_formPopupSIOControl.Close();
                }
                if (m_formPopupLUT != null)
                {
                    m_formPopupLUT.Close();
                }
                if (m_formPopupUserSet != null)
                {
                    m_formPopupUserSet.Close();
                }
                if (m_formPopupThermal != null)
                {
                    m_formPopupThermal.Close();
                }
                if (m_formPopupAltLed != null)
                {
                    m_formPopupAltLed.Close();
                }
                if (m_formPopupStackedROI != null)
                {
                    m_formPopupStackedROI.Close();
                }
            }
            else
            {
                if (m_formPopupFeature != null)
                {
                    m_formPopupFeature.UpdateForm();
                }
                if (m_formPopupCapture != null)
                {
                    m_formPopupCapture.UpdateForm();
                }
                if (m_formPopupResolution != null)
                {
                    m_formPopupResolution.UpdateForm();
                }
                if (m_formPopupTrigger != null)
                {
                    m_formPopupTrigger.UpdateForm();
                }
                if (m_formPopupStrobe != null)
                {
                    m_formPopupStrobe.UpdateForm();
                }
                if (m_formPopupAutoFocus != null)
                {
                    m_formPopupAutoFocus.UpdateForm();
                }
                if (m_formPopupFrameSave != null)
                {
                    m_formPopupFrameSave.UpdateForm();
                }
                if (m_formPopupSIOControl != null)
                {
                    m_formPopupSIOControl.UpdateForm();
                }
                if (m_formPopupLUT != null)
                {
                    m_formPopupLUT.UpdateForm();
                }
                if (m_formPopupUserSet != null)
                {
                    m_formPopupUserSet.UpdateForm();
                }
                if (m_formPopupThermal != null)
                {
                    m_formPopupThermal.UpdateForm();
                }
                if (m_formPopupAltLed != null)
                {
                    m_formPopupAltLed.UpdateForm();
                }
                if (m_formPopupStackedROI != null)
                {
                    m_formPopupStackedROI.UpdateForm();
                }
            }
        }

        private bool IsThermalType()
        {
            bool bRet = false;

            NEPTUNE_XML_NODE_INFO stNodeInfo = new NEPTUNE_XML_NODE_INFO();
            if (NeptuneC.ntcGetNodeInfo(m_pCameraHandle, "Temperatures", ref stNodeInfo) == ENeptuneError.NEPTUNE_ERR_Success)
            {
                bRet = true;
            }

            return bRet;
        }

        private bool IsSupportStackedROI()
        {
            bool bRet = false;

            NEPTUNE_XML_NODE_INFO stNodeInfo = new NEPTUNE_XML_NODE_INFO();
            if (NeptuneC.ntcGetNodeInfo(m_pCameraHandle, "StackedROIEnable", ref stNodeInfo) == ENeptuneError.NEPTUNE_ERR_Success)
            {
                bRet = true;
            }

            return bRet;
        }

        private void UpdateControlActivate()
        {
            bool bSelCam = false;
            bool b1394Type = false;
            bool bUsb3Type = false;
            bool bPlay = false;
            bool bContinuous = false;
            bool bMultishot = false;
            bool bIsThermal = false;
            bool bSupportedSRoi = false;
            if (m_pCameraHandle != IntPtr.Zero)
            {
                bSelCam = true;
                ENeptuneDevType emDevType = ENeptuneDevType.NEPTUNE_DEV_TYPE_UNKNOWN;
                if (NeptuneC.ntcGetCameraType(m_pCameraHandle, ref emDevType) == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    b1394Type = (emDevType == ENeptuneDevType.NEPTUNE_DEV_TYPE_1394) ? true : false;
                    bUsb3Type = (emDevType == ENeptuneDevType.NEPTUNE_DEV_TYPE_USB3) ? true : false;
                }
                ENeptuneBoolean emStatus = ENeptuneBoolean.NEPTUNE_BOOL_FALSE;
                if (NeptuneC.ntcGetAcquisition(m_pCameraHandle, ref emStatus) == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    bPlay = (emStatus == ENeptuneBoolean.NEPTUNE_BOOL_TRUE) ? true : false;
                }
                ENeptuneAcquisitionMode emAcqMode = ENeptuneAcquisitionMode.NEPTUNE_ACQ_CONTINUOUS;
                UInt32 uiFrames = 0;
                if (NeptuneC.ntcGetAcquisitionMode(m_pCameraHandle, ref emAcqMode, ref uiFrames) == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    bContinuous = (emAcqMode == ENeptuneAcquisitionMode.NEPTUNE_ACQ_CONTINUOUS ? true : false);
                    bMultishot = (emAcqMode == ENeptuneAcquisitionMode.NEPTUNE_ACQ_MULTIFRAME ? true : false);
                }
                bIsThermal = IsThermalType();

                bSupportedSRoi = IsSupportStackedROI();
            }

            m_cbPixelFormat.Enabled = bSelCam;
            m_cbBayerConvert.Enabled = bSelCam;
            m_cbBayerLayout.Enabled = bSelCam;
            m_ckFit.Enabled = true;
            m_ckFlip.Enabled = bSelCam;
            m_ckMirror.Enabled = bSelCam;
            m_cb1394FPS.Enabled = (bSelCam && !bPlay && b1394Type && m_bFrameRateSupport);
            m_edFPS.Enabled = (bSelCam && !bPlay && !b1394Type);
            m_btnFpsApply.Enabled = (m_cb1394FPS.Enabled || m_edFPS.Enabled);
            m_btnPlay.Enabled = (bSelCam && !bPlay);
            m_btnStop.Enabled = (bSelCam && bPlay);
            m_cbAcquisitionMode.Enabled = bSelCam;
            m_edMultiShotCnt.Enabled = (bSelCam && bMultishot);
            m_btnShot.Enabled = (bSelCam && bPlay && !bContinuous);
            m_btnControl.Enabled = bSelCam;
            m_btnFeature.Enabled = bSelCam;
            m_btnCapture.Enabled = bSelCam;
            m_btnResolution.Enabled = bSelCam;
            m_btnTrigger.Enabled = bSelCam;
            m_btnStrobe.Enabled = bSelCam;
            m_btnAutoFocus.Enabled = bSelCam;
            m_btnUserSet.Enabled = bSelCam;
            m_btnSIOControl.Enabled = bSelCam;
            m_btnLUT.Enabled = bSelCam;
            m_btnFrameSave.Enabled = (bSelCam && b1394Type);
            m_btnThermalControl.Enabled = (bSelCam && bIsThermal);
            m_btnATLLedControl.Enabled = (bSelCam && bUsb3Type);
            m_btnStackedROI.Enabled = (bSelCam && bSupportedSRoi);
        }

        private void InitFixedItemList()
        {
            m_listLog.Columns.Clear();
            m_listLog.Columns.Add("Time", 150);
            m_listLog.Columns.Add("Type", 80);
            m_listLog.Columns.Add("Message", 260);
            m_listLog.Columns.Add("Return", 190);
            m_listLog.FullRowSelect = true;

            m_cbBayerConvert.Items.Clear();
            m_cbBayerConvert.Items.Add(new ItemData("None",     (Int32)ENeptuneBayerMethod.NEPTUNE_BAYER_METHOD_NONE));
            m_cbBayerConvert.Items.Add(new ItemData("Bilinear", (Int32)ENeptuneBayerMethod.NEPTUNE_BAYER_METHOD_BILINEAR));
            m_cbBayerConvert.Items.Add(new ItemData("HQ",       (Int32)ENeptuneBayerMethod.NEPTUNE_BAYER_METHOD_HQ));
            m_cbBayerConvert.Items.Add(new ItemData("Nearest",  (Int32)ENeptuneBayerMethod.NEPTUNE_BAYER_METHOD_NEAREST));

            m_cbBayerLayout.Items.Clear();
            m_cbBayerLayout.Items.Add(new ItemData("GB/RG", (Int32)ENeptuneBayerLayout.NEPTUNE_BAYER_GB_RG));
            m_cbBayerLayout.Items.Add(new ItemData("BG/GR", (Int32)ENeptuneBayerLayout.NEPTUNE_BAYER_BG_GR));
            m_cbBayerLayout.Items.Add(new ItemData("RG/GB", (Int32)ENeptuneBayerLayout.NEPTUNE_BAYER_RG_GB));
            m_cbBayerLayout.Items.Add(new ItemData("RG/BG", (Int32)ENeptuneBayerLayout.NEPTUNE_BAYER_GR_BG));

            m_cbAcquisitionMode.Items.Clear();
            m_cbAcquisitionMode.Items.Add(new ItemData("Continuous",    (Int32)ENeptuneAcquisitionMode.NEPTUNE_ACQ_CONTINUOUS));
            m_cbAcquisitionMode.Items.Add(new ItemData("One-Shot",      (Int32)ENeptuneAcquisitionMode.NEPTUNE_ACQ_SINGLEFRAME));
            m_cbAcquisitionMode.Items.Add(new ItemData("Multi-Shot",    (Int32)ENeptuneAcquisitionMode.NEPTUNE_ACQ_MULTIFRAME));

            m_edMultiShotCnt.Minimum = 1;
            m_edMultiShotCnt.Maximum = 65535;
        }
        
        private void InitCameraList()
        {
            ItemData CurSelItem = (ItemData)m_cbCameraList.SelectedItem;
           
            m_cbCameraList.Items.Clear();

            UInt32 uiCount = 0;
            if (NeptuneC.ntcGetCameraCount(ref uiCount) == ENeptuneError.NEPTUNE_ERR_Success)
            {
                if (uiCount > 0)
                {
                    NEPTUNE_CAM_INFO[] pCameraInfo = new NEPTUNE_CAM_INFO[uiCount];
                    ENeptuneError emErr = NeptuneC.ntcGetCameraInfo(pCameraInfo, uiCount);
                    if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                    {
                        for (UInt32 i = 0; i < uiCount; i++)
                        {
                            Int32 nItem = m_cbCameraList.Items.Add(new ItemData(pCameraInfo[i]));
                            if (CurSelItem != null)
                            {
                                if (((ItemData)m_cbCameraList.Items[nItem]).m_stCameraInfo.strSerial.Equals(CurSelItem.m_stCameraInfo.strSerial) == true)
                                {
                                    m_cbCameraList.SelectedIndex = nItem;
                                }
                            }
                        }
                    }
                    else
                    {
                        InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetCameraInfo Failed.", emErr);
                    }
                }
            }

            if (CurSelItem != null && m_cbCameraList.SelectedIndex == -1)
            {
                m_TimerReceiveFrame.Stop();
                m_TimerReceiveFPS.Stop();
                CloseCameraHandle();
                UpdateControlActivate();
                UpdatePopupForms(true);
            }
        }

        private void InitPixelFormatList()
        {
            m_cbPixelFormat.Items.Clear();

            if (m_pCameraHandle != IntPtr.Zero)
            {
                UInt32 puiSize = 0;
                NeptuneC.ntcGetPixelFormatList(m_pCameraHandle, null, ref puiSize);
                if (puiSize > 0)
                {
                    ENeptunePixelFormat[] emPixelList = new ENeptunePixelFormat[puiSize];
                    ENeptuneError emErr = NeptuneC.ntcGetPixelFormatList(m_pCameraHandle, emPixelList, ref puiSize);
                    if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                    {
                        ENeptunePixelFormat emCurPixelFormat = ENeptunePixelFormat.Unknown_PixelFormat;
                        emErr = NeptuneC.ntcGetPixelFormat(m_pCameraHandle, ref emCurPixelFormat);
                        if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                        {
                            char[] pOutString = new char[64];
                            for (Int32 i = 0; i < emPixelList.Length; i++)
                            {
                                Array.Clear(pOutString, 0, pOutString.Length);
                                if (NeptuneC.ntcGetPixelFormatString(m_pCameraHandle, emPixelList[i], pOutString, (UInt32)pOutString.Length) == ENeptuneError.NEPTUNE_ERR_Success)
                                {
                                    String strLabel = new String(pOutString);
                                    Int32 nItem = m_cbPixelFormat.Items.Add(new ItemData(strLabel, (Int32)emPixelList[i]));
                                    if (emCurPixelFormat == emPixelList[i])
                                    {
                                        m_cbPixelFormat.SelectedIndex = nItem;
                                    }
                                }
                            }
                        }
                        else
                        {
                            InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetPixelFormatList Failed.", emErr);
                        }
                    }
                    else
                    {
                        InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetPixelFormatList Failed.", emErr);
                    }
                }
            }
        }

        private void InitBayerMethodList()
        {
            if (m_pCameraHandle != IntPtr.Zero)
            {
                ENeptuneBayerMethod emMethod = ENeptuneBayerMethod.NEPTUNE_BAYER_METHOD_NONE;
                if (NeptuneC.ntcGetBayerConvert(m_pCameraHandle, ref emMethod) == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    for (Int32 i = 0; i < m_cbBayerConvert.Items.Count; i++)
                    {
                        if (emMethod == (ENeptuneBayerMethod)((ItemData)m_cbBayerConvert.Items[i]).m_nValue)
                        {
                            m_cbBayerConvert.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }

        private void InitBayerLayoutList()
        {
            if (m_pCameraHandle != IntPtr.Zero)
            {
                ENeptuneBayerLayout emLayout = ENeptuneBayerLayout.NEPTUNE_BAYER_GB_RG;
                if (NeptuneC.ntcGetBayerLayout(m_pCameraHandle, ref emLayout) == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    for (Int32 i = 0; i < m_cbBayerLayout.Items.Count; i++)
                    {
                        if (emLayout == (ENeptuneBayerLayout)((ItemData)m_cbBayerLayout.Items[i]).m_nValue)
                        {
                            m_cbBayerLayout.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }

        private void InitEffectState()
        {
            ENeptuneDisplayOption emDisplayOpt = ENeptuneDisplayOption.NEPTUNE_DISPLAY_OPTION_FIT;
            NeptuneC.ntcGetDisplayOption(ref emDisplayOpt);
            m_ckFit.Checked = (emDisplayOpt == ENeptuneDisplayOption.NEPTUNE_DISPLAY_OPTION_FIT);

            if (m_pCameraHandle != IntPtr.Zero)
            {
                Int32 nEffectFlag = 0;
                if (NeptuneC.ntcGetEffect(m_pCameraHandle, ref nEffectFlag) == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_ckFlip.Checked = ((nEffectFlag & (Int32)ENeptuneEffect.NEPTUNE_EFFECT_FLIP) == (Int32)ENeptuneEffect.NEPTUNE_EFFECT_FLIP) ? true : false;
                    m_ckMirror.Checked = ((nEffectFlag & (Int32)ENeptuneEffect.NEPTUNE_EFFECT_MIRROR) == (Int32)ENeptuneEffect.NEPTUNE_EFFECT_MIRROR) ? true : false;
                }
            }
        }

        private bool IsFrameRateSupported()
        {
            bool bRet = true;
            ENeptunePixelFormat emPixelFormat = ENeptunePixelFormat.Unknown_PixelFormat;
            if (NeptuneC.ntcGetPixelFormat(m_pCameraHandle, ref emPixelFormat) == ENeptuneError.NEPTUNE_ERR_Success)
            {
                if (emPixelFormat >= ENeptunePixelFormat.Format7_Mode0_Mono8 && emPixelFormat <= ENeptunePixelFormat.Format7_Mode2_Raw12)
                {
                    bRet = false;
                }
            }
            m_bFrameRateSupport = bRet;
            return bRet;
        }

        private void InitFrameRateList()
        {
            m_cb1394FPS.Items.Clear();
            m_edFPS.Text = "";
            if (m_pCameraHandle != IntPtr.Zero)
            {
                if (IsFrameRateSupported())
                {
                    ENeptuneFrameRate em1394FPS = ENeptuneFrameRate.FPS_UNKNOWN;
                    Double dbValue = 0.0;
                    ENeptuneError emErr = NeptuneC.ntcGetFrameRate(m_pCameraHandle, ref em1394FPS, ref dbValue);
                    if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                    {
                        if (em1394FPS == ENeptuneFrameRate.FPS_VALUE || em1394FPS == ENeptuneFrameRate.FPS_UNKNOWN)
                        {
                            m_edFPS.Text = dbValue.ToString();
                        }
                        else
                        {
                            UInt32 uiSize = 0;
                            NeptuneC.ntcGetFrameRateList(m_pCameraHandle, null, ref uiSize);
                            if (uiSize > 0)
                            {
                                ENeptuneFrameRate[] p1394FpsList = new ENeptuneFrameRate[uiSize];
                                emErr = NeptuneC.ntcGetFrameRateList(m_pCameraHandle, p1394FpsList, ref uiSize);
                                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                                {
                                    char[] pOutString = new char[64];
                                    for (Int32 i = 0; i < p1394FpsList.Length; i++)
                                    {
                                        Array.Clear(pOutString, 0, pOutString.Length);
                                        if (NeptuneC.ntcGetFrameRateString(m_pCameraHandle, p1394FpsList[i], pOutString, (UInt32)pOutString.Length) == ENeptuneError.NEPTUNE_ERR_Success)
                                        {
                                            String strLabel = new String(pOutString);
                                            Int32 nItem = m_cb1394FPS.Items.Add(new ItemData(strLabel, (Int32)p1394FpsList[i]));
                                            if (em1394FPS == p1394FpsList[i])
                                            {
                                                m_cb1394FPS.SelectedIndex = nItem;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetFrameRateList Failed.", emErr);
                                }
                            }
                        }
                    }
                    else
                    {
                        InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetFrameRate Failed.", emErr);
                    }
                }
            }
        }

        private void InitAcquisitionMode()
        {
            if (m_pCameraHandle != IntPtr.Zero)
            {
                ENeptuneAcquisitionMode emAcqMode = ENeptuneAcquisitionMode.NEPTUNE_ACQ_CONTINUOUS;
                UInt32 uiFrames = 0;
                ENeptuneError emErr = NeptuneC.ntcGetAcquisitionMode(m_pCameraHandle, ref emAcqMode, ref uiFrames);
                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_edMultiShotCnt.Value = uiFrames;
                    for (Int32 i = 0; i < m_cbAcquisitionMode.Items.Count; i++)
                    {
                        if (emAcqMode == (ENeptuneAcquisitionMode)((ItemData)m_cbAcquisitionMode.Items[i]).m_nValue)
                        {
                            m_cbAcquisitionMode.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else
                {
                    InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetAcquisitionMode Failed.", emErr);
                }
            }
        }

        private void m_btnRefresh_Click(object sender, EventArgs e)
        {
            InitCameraList();
        }

        private void m_cbCameraList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Camera List Refresh Event 발생 시 기존에 있던 카메라 목록을 모두 지운 후 
            // 기존에 선택되어 있던 카메라가 있다면 카메라 목록 삽입 시 강제로 선택해주는데,
            // 이 때 사용자가 GUI 상에서 선택(Focus 존재)하는 경우가 아님에도 해당 이벤트가 발생
            if (((ComboBox)sender).Focused)
            {
                CloseCameraHandle();

                if (m_cbCameraList.SelectedIndex != -1)
                {
                    ENeptuneError emErr = NeptuneC.ntcOpen(((ItemData)m_cbCameraList.SelectedItem).m_stCameraInfo.strCamID, ref m_pCameraHandle, ENeptuneDevAccess.NEPTUNE_DEV_ACCESS_EXCLUSIVE);
                    if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                    {
                        NeptuneC.ntcSetDisplay(m_pCameraHandle, m_stcDisplayWnd.Handle);
                        NeptuneC.ntcSetUnplugCallback(m_pCameraHandle, DeviceUnplugCallbackInst, this.Handle);
                        NeptuneC.ntcSetFrameCallback(m_pCameraHandle, FrameCallbackInst, this.Handle);
                    }
                    else
                    {
                        m_cbCameraList.SelectedIndex = -1;
                        InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcOpen Failed.", emErr);
                    }

                    UpdateCameraInfo();
                }
            }
        }

        private void m_cbPixelFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Focused)
            {
                if (m_cbPixelFormat.SelectedIndex != -1 && m_pCameraHandle != IntPtr.Zero)
                {
                    ENeptuneError emErr = NeptuneC.ntcSetPixelFormat(m_pCameraHandle, (ENeptunePixelFormat)((ItemData)m_cbPixelFormat.SelectedItem).m_nValue);
                    if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                    {
                        ENeptuneDevType emDevType = ENeptuneDevType.NEPTUNE_DEV_TYPE_UNKNOWN;
                        if (NeptuneC.ntcGetCameraType(m_pCameraHandle, ref emDevType) == ENeptuneError.NEPTUNE_ERR_Success)
                        {
                            if (emDevType == ENeptuneDevType.NEPTUNE_DEV_TYPE_1394)
                            {
                                InitFrameRateList();
                                UpdateControlActivate();
                            }
                        }
                    }
                    else
                    {
                        InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetPixelFormat Failed.", emErr);
                    }
                }
            }
        }

        private void m_cbBayerConvert_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Focused)
            {
                if (m_cbBayerConvert.SelectedIndex != -1 && m_pCameraHandle != IntPtr.Zero)
                {
                    ENeptuneError emErr = NeptuneC.ntcSetBayerConvert(m_pCameraHandle, (ENeptuneBayerMethod)((ItemData)m_cbBayerConvert.SelectedItem).m_nValue);
                    if (emErr != ENeptuneError.NEPTUNE_ERR_Success)
                    {
                        InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetBayerConvert Failed.", emErr);
                    }
                }
            }
        }

        private void m_cbBayerLayout_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Focused)
            {
                if (m_cbBayerLayout.SelectedIndex != -1 && m_pCameraHandle != IntPtr.Zero)
                {
                    ENeptuneError emErr = NeptuneC.ntcSetBayerLayout(m_pCameraHandle, (ENeptuneBayerLayout)((ItemData)m_cbBayerLayout.SelectedItem).m_nValue);
                    if (emErr != ENeptuneError.NEPTUNE_ERR_Success)
                    {
                        InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetBayerLayout Failed.", emErr);
                    }
                }
            }
        }

        private void m_ckFit_CheckedChanged(object sender, EventArgs e)
        {
            ENeptuneError emErr = NeptuneC.ntcSetDisplayOption(m_ckFit.Checked ? ENeptuneDisplayOption.NEPTUNE_DISPLAY_OPTION_FIT : ENeptuneDisplayOption.NEPTUNE_DISPLAY_OPTION_ORIGINAL_CENTER);
            if (emErr != ENeptuneError.NEPTUNE_ERR_Success)
            {
                InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetDisplayOption Failed.", emErr);
            }
        }

        private void m_ckFlip_CheckedChanged(object sender, EventArgs e)
        {
            if (m_pCameraHandle != IntPtr.Zero)
            {
                Int32 nEffectFlags = 0;
                if (NeptuneC.ntcGetEffect(m_pCameraHandle, ref nEffectFlags) == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    if (m_ckFlip.Checked)
                    {
                        nEffectFlags |= (Int32)ENeptuneEffect.NEPTUNE_EFFECT_FLIP;
                    }
                    else
                    {
                        nEffectFlags &= ~(Int32)ENeptuneEffect.NEPTUNE_EFFECT_FLIP;
                    }
                    
                    ENeptuneError emErr = NeptuneC.ntcSetEffect(m_pCameraHandle, nEffectFlags);
                    if (emErr != ENeptuneError.NEPTUNE_ERR_Success)
                    {
                        InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetEffect Failed.", emErr);
                    }
                }
            }
        }

        private void m_ckMirror_CheckedChanged(object sender, EventArgs e)
        {
            if (m_pCameraHandle != IntPtr.Zero)
            {
                Int32 nEffectFlags = 0;
                if (NeptuneC.ntcGetEffect(m_pCameraHandle, ref nEffectFlags) == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    if (m_ckMirror.Checked)
                    {
                        nEffectFlags |= (Int32)ENeptuneEffect.NEPTUNE_EFFECT_MIRROR;
                    }
                    else
                    {
                        nEffectFlags &= ~(Int32)ENeptuneEffect.NEPTUNE_EFFECT_MIRROR;
                    }

                    ENeptuneError emErr = NeptuneC.ntcSetEffect(m_pCameraHandle, nEffectFlags);
                    if (emErr != ENeptuneError.NEPTUNE_ERR_Success)
                    {
                        InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetEffect Failed.", emErr);
                    }
                }
            }
        }

        private void m_TimerReceiveFrame_Tick(object sender, EventArgs e)
        {
            this.m_stcReceiveFrame.Text = m_uiTotalFrameCount.ToString();
        }

        private void m_TimerReceiveFPS_Tick(object sender, EventArgs e)
        {
            if (m_pCameraHandle != IntPtr.Zero)
            {
                float fFps = 0;
                if (NeptuneC.ntcGetReceiveFrameRate(m_pCameraHandle, ref fFps) == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_stcReceiveFps.Text = fFps.ToString();
                }
            }
        }

        private void m_btnFpsApply_Click(object sender, EventArgs e)
        {
            if (m_pCameraHandle != IntPtr.Zero)
            {
                ENeptuneDevType emDevType = ENeptuneDevType.NEPTUNE_DEV_TYPE_UNKNOWN;
                if (NeptuneC.ntcGetCameraType(m_pCameraHandle, ref emDevType) == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    ENeptuneFrameRate em1394FPS = ENeptuneFrameRate.FPS_UNKNOWN;
                    Double dbValue = 0.0;
                    if (emDevType == ENeptuneDevType.NEPTUNE_DEV_TYPE_1394)
                    {
                        if (m_cb1394FPS.SelectedIndex != -1)
                        {
                            em1394FPS = (ENeptuneFrameRate)((ItemData)m_cb1394FPS.SelectedItem).m_nValue;
                        }
                    }
                    else
                    {
                        dbValue = Convert.ToDouble(m_edFPS.Text);
                    }

                    ENeptuneError emErr = NeptuneC.ntcSetFrameRate(m_pCameraHandle, em1394FPS, dbValue);
                    if (emErr != ENeptuneError.NEPTUNE_ERR_Success)
                    {
                        InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetCameraType Failed.", emErr);
                    }
                }
            }
        }

        private void m_btnPlay_Click(object sender, EventArgs e)
        {
            if (m_pCameraHandle != IntPtr.Zero)
            {
                ENeptuneError emErr = NeptuneC.ntcSetAcquisition(m_pCameraHandle, ENeptuneBoolean.NEPTUNE_BOOL_TRUE);
                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_TimerReceiveFrame.Start();
                    m_TimerReceiveFPS.Start();
                    UpdateControlActivate();
                }
                else
                {
                    InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetAcquisition Failed.", emErr);
                }
            }
        }

        private void m_btnStop_Click(object sender, EventArgs e)
        {
            if (m_pCameraHandle != IntPtr.Zero)
            {
                m_uiTotalFrameCount = 0;
                ENeptuneError emErr = NeptuneC.ntcSetAcquisition(m_pCameraHandle, ENeptuneBoolean.NEPTUNE_BOOL_FALSE);
                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_TimerReceiveFrame.Stop();
                    m_TimerReceiveFPS.Stop();
                    UpdateControlActivate();   
                }
                else
                {
                    InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetAcquisition Failed.", emErr);
                }
            }
        }

        private void m_cbAcquisitionMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Focused)
            {
                if (m_cbAcquisitionMode.SelectedIndex != -1 && m_pCameraHandle != IntPtr.Zero)
                {
                    ENeptuneError emErr = NeptuneC.ntcSetAcquisitionMode(m_pCameraHandle, (ENeptuneAcquisitionMode)((ItemData)m_cbAcquisitionMode.SelectedItem).m_nValue, (UInt32)m_edMultiShotCnt.Value);
                    if (emErr != ENeptuneError.NEPTUNE_ERR_Success)
                    {
                        InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetAcquisitionMode Failed.", emErr);
                    }
                    UpdateControlActivate();
                }
            }
        }

        private void m_btnShot_Click(object sender, EventArgs e)
        {
            if (m_cbAcquisitionMode.SelectedIndex != -1 && m_pCameraHandle != IntPtr.Zero)
            {
                ENeptuneAcquisitionMode emCurSel = (ENeptuneAcquisitionMode)((ItemData)m_cbAcquisitionMode.SelectedItem).m_nValue;
                if (emCurSel == ENeptuneAcquisitionMode.NEPTUNE_ACQ_SINGLEFRAME)
                {
                    ENeptuneError emErr = NeptuneC.ntcOneShot(m_pCameraHandle);
                    if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                    {
                        InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, "One-Shot.");
                    }
                    else
                    {
                        InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcOneShot Failed.", emErr);
                    }
                }
                else if (emCurSel == ENeptuneAcquisitionMode.NEPTUNE_ACQ_MULTIFRAME)
                {
                    ENeptuneAcquisitionMode emAcqMode = ENeptuneAcquisitionMode.NEPTUNE_ACQ_MULTIFRAME;
                    UInt32 uiFrames = 0;
                    if (NeptuneC.ntcGetAcquisitionMode(m_pCameraHandle, ref emAcqMode, ref uiFrames) == ENeptuneError.NEPTUNE_ERR_Success)
                    {
                        if (emAcqMode != emCurSel || uiFrames != (UInt32)m_edMultiShotCnt.Value)
                        {
                            NeptuneC.ntcSetAcquisitionMode(m_pCameraHandle, emCurSel, (UInt32)m_edMultiShotCnt.Value);
                        }
                    }

                    ENeptuneError emErr = NeptuneC.ntcMultiShot(m_pCameraHandle);
                    if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                    {
                        InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, "Multi-Shot.");
                    }
                    else
                    {
                        InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcMultiShot Failed.", emErr);
                    }
                }
            }
        }

        public void InsertLog(EM_LOG_LEVEL emLogLevel, String strMessage, ENeptuneError emReturn = ENeptuneError.NEPTUNE_ERR_Success)
        {
            DateTime dt = DateTime.Now;
            String strItem = "";
            switch(emLogLevel)
            {
                case EM_LOG_LEVEL.TYPE_ERROR: strItem = "Error"; break;
                case EM_LOG_LEVEL.TYPE_EVENT: strItem = "Event"; break;
                case EM_LOG_LEVEL.TYPE_INFORMATION: strItem = "Information"; break;
            }
            ListViewItem lvItem = new ListViewItem(dt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            lvItem.SubItems.Add(strItem);
            lvItem.SubItems.Add(strMessage);
            lvItem.SubItems.Add(emReturn.ToString());
            m_listLog.Items.Add(lvItem);
            if (m_ckAutoScroll.Checked == true)
            {
                m_listLog.EnsureVisible(m_listLog.Items.Count - 1);
            }
        }

        public void UpdateCameraInfo()
        {
            InitPixelFormatList();
            InitBayerMethodList();
            InitBayerLayoutList();
            InitEffectState();
            InitFrameRateList();
            InitAcquisitionMode();
            UpdateControlActivate();
            UpdatePopupForms((m_cbCameraList.SelectedIndex == -1) ? true : false);
        }

        private void m_ckAutoScroll_CheckedChanged(object sender, EventArgs e)
        {
            if (m_ckAutoScroll.Checked == true)
            {
                Int32 nIndex = m_listLog.Items.Count - 1;
                if (nIndex > 0)
                {
                    m_listLog.EnsureVisible(nIndex);
                }
            }
        }

        private void m_btnClearList_Click(object sender, EventArgs e)
        {
            m_listLog.Items.Clear();
        }

        private void m_btnControl_Click(object sender, EventArgs e)
        {
            if (m_pCameraHandle != IntPtr.Zero)
            {
                ENeptuneError emErr = NeptuneC.ntcShowControlDialog(m_pCameraHandle);
                if (emErr != ENeptuneError.NEPTUNE_ERR_Success)
                {
                    InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcShowControlDialog Failed.", emErr);
                }
            }
        }

        private void m_btnFeature_Click(object sender, EventArgs e)
        {
            if (m_formPopupFeature == null)
            {
                m_formPopupFeature = new PopupFeatureForm(this);
                m_formPopupFeature.Owner = null;
                m_formPopupFeature.Show();
            }
            else
            {
                m_formPopupFeature.Show();
                m_formPopupFeature.Focus();
                m_formPopupFeature.UpdateForm();
            }
        }

        private void m_btnCapture_Click(object sender, EventArgs e)
        {
            if (m_formPopupCapture == null)
            {
                m_formPopupCapture = new PopupCaptureForm(this);
                m_formPopupCapture.Owner = null;
                m_formPopupCapture.Show();
            }
            else
            {
                m_formPopupCapture.Show();
                m_formPopupCapture.Focus();
                m_formPopupCapture.UpdateForm();
            }
        }


        private void m_btnResolution_Click(object sender, EventArgs e)
        {
            if (m_formPopupResolution == null)
            {
                m_formPopupResolution = new PopupResolutionForm(this);
                m_formPopupResolution.Owner = null;
                m_formPopupResolution.Show();
            }
            else
            {
                m_formPopupResolution.Show();
                m_formPopupResolution.Focus();
                m_formPopupResolution.UpdateForm();
            }
        }

        private void m_btnTrigger_Click(object sender, EventArgs e)
        {
            if (m_formPopupTrigger == null)
            {
                m_formPopupTrigger = new PopupTriggerForm(this);
                m_formPopupTrigger.Owner = null;
                m_formPopupTrigger.Show();
            }
            else
            {
                m_formPopupTrigger.Show();
                m_formPopupTrigger.Focus();
                m_formPopupTrigger.UpdateForm();
            }
        }

        private void m_btnStrobe_Click(object sender, EventArgs e)
        {
            if (m_formPopupStrobe == null)
            {
                m_formPopupStrobe = new PopupStrobeForm(this);
                m_formPopupStrobe.Owner = null;
                m_formPopupStrobe.Show();
            }
            else
            {
                m_formPopupStrobe.Show();
                m_formPopupStrobe.Focus();
                m_formPopupStrobe.UpdateForm();
            }
        }

        private void m_btnAutoFocus_Click(object sender, EventArgs e)
        {
            if (m_formPopupAutoFocus == null)
            {
                m_formPopupAutoFocus = new PopupAutoFocusForm(this);
                m_formPopupAutoFocus.Owner = null;
                m_formPopupAutoFocus.Show();
            }
            else
            {
                m_formPopupAutoFocus.Show();
                m_formPopupAutoFocus.Focus();
                m_formPopupAutoFocus.UpdateForm();
            }
        }

        private void m_btnFrameSave_Click(object sender, EventArgs e)
        {
            if (m_formPopupFrameSave == null)
            {
                m_formPopupFrameSave = new PopupFrameSaveForm(this);
                m_formPopupFrameSave.Owner = null;
                m_formPopupFrameSave.Show();
            }
            else
            {
                m_formPopupFrameSave.Show();
                m_formPopupFrameSave.Focus();
                m_formPopupFrameSave.UpdateForm();
            }
        }

        private void m_btnSIOControl_Click(object sender, EventArgs e)
        {
            if (m_formPopupSIOControl == null)
            {
                m_formPopupSIOControl = new PopupSIOControlForm(this);
                m_formPopupSIOControl.Owner = null;
                m_formPopupSIOControl.Show();
            }
            else
            {
                m_formPopupSIOControl.Show();
                m_formPopupSIOControl.Focus();
                m_formPopupSIOControl.UpdateForm();
            }
        }

        private void m_btnLUT_Click(object sender, EventArgs e)
        {
            if (m_formPopupLUT == null)
            {
                m_formPopupLUT = new PopupLUTForm(this);
                m_formPopupLUT.Owner = null;
                m_formPopupLUT.Show();
            }
            else
            {
                m_formPopupLUT.Show();
                m_formPopupLUT.Focus();
                m_formPopupLUT.UpdateForm();
            }
        }

        private void m_btnUserSet_Click(object sender, EventArgs e)
        {
            if (m_formPopupUserSet == null)
            {
                m_formPopupUserSet = new PopupUserSetForm(this);
                m_formPopupUserSet.Owner = null;
                m_formPopupUserSet.Show();
            }
            else
            {
                m_formPopupUserSet.Show();
                m_formPopupUserSet.Focus();
                m_formPopupUserSet.UpdateForm();
            }
        }

        private void m_btnThermalControl_Click(object sender, EventArgs e)
        {
            if (m_formPopupThermal == null)
            {
                m_formPopupThermal = new PopupThermalForm(this);
                m_formPopupThermal.Owner = null;
                m_formPopupThermal.Show();
            }
            else
            {
                m_formPopupThermal.Show();
                m_formPopupThermal.Focus();
                m_formPopupThermal.UpdateForm();
            }
        }

        private void m_btnATLLedControl_Click(object sender, EventArgs e)
        {
            if (m_formPopupThermal == null)
            {
                m_formPopupAltLed = new PopupAltLedForm(this);
                m_formPopupAltLed.Owner = null;
                m_formPopupAltLed.Show();
            }
            else
            {
                m_formPopupAltLed.Show();
                m_formPopupAltLed.Focus();
                m_formPopupAltLed.UpdateForm();
            }
        }

        private void m_btnStackedROI_Click(object sender, EventArgs e)
        {
            if (m_formPopupStackedROI == null)
            {
                m_formPopupStackedROI = new PopupStackedROIForm(this);
                m_formPopupStackedROI.Owner = null;
                m_formPopupStackedROI.Show();
            }
            else
            {
                m_formPopupStackedROI.Show();
                m_formPopupStackedROI.Focus();
                m_formPopupStackedROI.UpdateForm();
            }
        }

        private void CONTROL_PANEL_Click(object sender, EventArgs e)
        {
            if (m_formCONTROL_PANEL == null)
            {
                m_formCONTROL_PANEL = new CONTROL_PANEL(this);
                m_formCONTROL_PANEL.Owner = null;
                m_formCONTROL_PANEL.Show();
            }
            else
            {
                m_formCONTROL_PANEL.Show();
                m_formCONTROL_PANEL.Focus();
            }
        }
    }

    public class ItemData
    {
        public String m_strLabel = "";
        public Int32 m_nValue = 0;
        public NEPTUNE_CAM_INFO m_stCameraInfo;

        public ItemData(String strLabel, Int32 nValue)
        {
            m_strLabel = strLabel;
            m_nValue = nValue;
        }

        public ItemData(NEPTUNE_CAM_INFO stCameraInfo)
        {
            m_stCameraInfo = stCameraInfo;
            m_strLabel = m_stCameraInfo.strVendor + ": [" + m_stCameraInfo.strSerial + "] " + m_stCameraInfo.strModel;
        }

        public override String ToString()
        {
            return m_strLabel;
        }
    };

    public enum EM_LOG_LEVEL
    {
        TYPE_ERROR,
        TYPE_EVENT,
        TYPE_INFORMATION
    };
}
