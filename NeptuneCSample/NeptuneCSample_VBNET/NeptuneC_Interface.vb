Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Runtime.InteropServices

Namespace NeptuneC_Interface

    '''///////////////////////////////////////////////////////////////////////
    Public Enum ENeptuneError
        NEPTUNE_ERR_Fail = -1
        NEPTUNE_ERR_Success = 0
        NEPTUNE_ERR_AlreadyInitialized = -100
        NEPTUNE_ERR_APINotInitialized = -101
        NEPTUNE_ERR_NotInitialized = -102
        NEPTUNE_ERR_GC = -103
        NEPTUNE_ERR_TimeOut = -104
        NEPTUNE_ERR_NotSupportedFunc = -105
        NEPTUNE_ERR_OpenXML = -106
        NEPTUNE_ERR_InvalidValue = -107
        NEPTUNE_ERR_EventChannel = -108
        NEPTUNE_ERR_NotReady = -109
        NEPTUNE_ERR_PacketResend = -110
        NEPTUNE_ERR_InvalidFeatureRange = -111
        NEPTUNE_ERR_TLInterface = -112
        NEPTUNE_ERR_TLDevOpen = -113
        NEPTUNE_ERR_TLDevPort = -114
        NEPTUNE_ERR_TLDevURL = -115
        NEPTUNE_ERR_GrabTimeout = -116
        NEPTUNE_ERR_DeviceNotExist = -117
        NEPTUNE_ERR_TLInitFail = -200
        NEPTUNE_ERR_NoInterface = -201
        NEPTUNE_ERR_DeviceCheck = -202
        NEPTUNE_ERR_InvalidParameter = -203
        NEPTUNE_ERR_NotSupport = -204
        NEPTUNE_ERR_AccessDenied = -205
        NEPTUNE_ERR_InvalidAddress = -206
        NEPTUNE_ERR_InvalidArraySize = -207
        NEPTUNE_ERR_Interface = -208
        NEPTUNE_ERR_DeviceInfo = -209
        NEPTUNE_ERR_MemoryAlloc = -210
        NEPTUNE_ERR_DeviceOpen = -211
        NEPTUNE_ERR_DevicePort = -212
        NEPTUNE_ERR_DeviceURL = -213
        NEPTUNE_ERR_DeviceWrite = -214
        NEPTUNE_ERR_DeviceXML = -215
        NEPTUNE_ERR_DeviceHeartbeat = -216
        NEPTUNE_ERR_DeviceClose = -217
        NEPTUNE_ERR_DeviceStream = -218
        NEPTUNE_ERR_DeviceNotStreaming = -219
        NEPTUNE_ERR_DeviceStreaming = -220
        NEPTUNE_ERR_InvalidXMLNode = -300
        NEPTUNE_ERR_StreamCount = -303
        NEPTUNE_ERR_AccessTimeOut = -304
        NEPTUNE_ERR_OutOfRange = -305
        NEPTUNE_ERR_InvalidChannel = -306
        NEPTUNE_ERR_InvalidBuffer = -307
        NEPTUNE_ERR_FileAccessError = -400
        NEPTUNE_ERR_GrabFrameDropped = -450
    End Enum

    Public Enum ENeptuneBoolean
        NEPTUNE_BOOL_FALSE = 0
        NEPTUNE_BOOL_TRUE = 1
    End Enum

    Public Enum ENeptuneEffect
        NEPTUNE_EFFECT_NONE = 0
        NEPTUNE_EFFECT_FLIP = 1
        NEPTUNE_EFFECT_MIRROR = 2
        NEPTUNE_EFFECT_NEGATIVE = 4
    End Enum

    Public Enum ENeptuneAutoMode
        NEPTUNE_AUTO_OFF = 0
        NEPTUNE_AUTO_ONCE = 1
        NEPTUNE_AUTO_CONTINUOUS = 2
    End Enum

    Public Enum ENeptunePixelFormat
        Unknown_PixelFormat = -1
        Format0_320x240_YUV422 = 0
        Format0_640x480_YUV411 = 1
        Format0_640x480_YUV422 = 2
        Format0_640x480_Mono8 = 3
        Format0_640x480_Mono16 = 4
        Format1_800x600_YUV422 = 5
        Format1_800x600_Mono8 = 6
        Format1_1024x768_YUV422 = 7
        Format1_1024x768_Mono8 = 8
        Format1_800x600_Mono16 = 9
        Format1_1024x768_Mono16 = 10
        Format2_1280x960_YUV422 = 11
        Format2_1280x960_Mono8 = 12
        Format2_1600x1200_YUV422 = 13
        Format2_1600x1200_Mono8 = 14
        Format2_1280x960_Mono16 = 15
        Format2_1600x1200_Mono16 = 16
        Format7_Mode0_Mono8 = 17
        Format7_Mode0_YUV411 = 18
        Format7_Mode0_YUV422 = 19
        Format7_Mode0_Mono16 = 20
        Format7_Mode0_Raw8 = 21
        Format7_Mode0_Raw16 = 22
        Format7_Mode0_Mono12 = 23
        Format7_Mode0_Raw12 = 24
        Format7_Mode1_Mono8 = 25
        Format7_Mode1_YUV411 = 26
        Format7_Mode1_YUV422 = 27
        Format7_Mode1_Mono16 = 28
        Format7_Mode1_Raw8 = 29
        Format7_Mode1_Raw16 = 30
        Format7_Mode1_Mono12 = 31
        Format7_Mode1_Raw12 = 32
        Format7_Mode2_Mono8 = 33
        Format7_Mode2_YUV411 = 34
        Format7_Mode2_YUV422 = 35
        Format7_Mode2_Mono16 = 36
        Format7_Mode2_Raw8 = 37
        Format7_Mode2_Raw16 = 38
        Format7_Mode2_Mono12 = 39
        Format7_Mode2_Raw12 = 40
        Mono8 = 101
        Mono10 = 102
        Mono12 = 103
        Mono16 = 104
        BayerGR8 = 105
        BayerGR10 = 106
        BayerGR12 = 107
        YUV411Packed = 108
        YUV422Packed = 109
        YUV422_8 = 110
        BayerRG8 = 111
        BayerRG12 = 112
        BayerGB8 = 113
        BayerGB12 = 114
        BayerBG8 = 115
        BayerBG12 = 116
        Profile32 = 117
    End Enum

    Public Enum ENeptunePixelType
        NEPTUNE_PIXEL_MONO = 1
        NEPTUNE_PIXEL_BAYER = 2
        NEPTUNE_PIXEL_RGB = 3
        NEPTUNE_PIXEL_YUV = 4
        NEPTUNE_PIXEL_RGBPLANAR = 5
        NEPTUNE_PIXEL_YUV_8 = 6
        NEPTUNE_PIXEL_PROFILE32 = 7
    End Enum

    Public Enum ENeptuneFrameRate
        FPS_UNKNOWN = -1
        FPS_1_875 = 0
        FPS_3_75 = 1
        FPS_7_5 = 2
        FPS_15 = 3
        FPS_30 = 4
        FPS_60 = 5
        FPS_120 = 6
        FPS_240 = 7
        FPS_VALUE = 20
    End Enum

    Public Enum ENeptuneBayerLayout
        NEPTUNE_BAYER_GB_RG = 0
        NEPTUNE_BAYER_BG_GR = 1
        NEPTUNE_BAYER_RG_GB = 2
        NEPTUNE_BAYER_GR_BG = 3
    End Enum

    Public Enum ENeptuneBayerMethod
        NEPTUNE_BAYER_METHOD_NONE = 0
        NEPTUNE_BAYER_METHOD_BILINEAR = 1
        NEPTUNE_BAYER_METHOD_HQ = 2
        NEPTUNE_BAYER_METHOD_NEAREST = 3
    End Enum

    Public Enum ENeptuneAcquisitionMode
        NEPTUNE_ACQ_CONTINUOUS = 0
        NEPTUNE_ACQ_MULTIFRAME = 1
        NEPTUNE_ACQ_SINGLEFRAME = 2
    End Enum

    Public Enum ENeptuneImageFormat
        NEPTUNE_IMAGE_FORMAT_UNKNOWN = -1
        NEPTUNE_IMAGE_FORMAT_BMP = 0
        NEPTUNE_IMAGE_FORMAT_JPG = 1
        NEPTUNE_IMAGE_FORMAT_TIF = 2
    End Enum

    Public Enum ENeptuneGrabFormat
        NEPTUNE_GRAB_RAW = 0
        NEPTUNE_GRAB_RGB = 1
        NEPTUNE_GRAB_RGB32 = 2
    End Enum

    Public Enum ENeptuneDeviceChangeState
        NEPTUNE_DEVICE_ADDED = 0
        NEPTUNE_DEVICE_REMOVED = 1
    End Enum

    Public Enum ENeptuneRotationAngle
        NEPTUNE_ROTATE_0 = 0
        NEPTUNE_ROTATE_90 = 1
        NEPTUNE_ROTATE_180 = 2
        NEPTUNE_ROTATE_270 = 3
    End Enum

    Public Enum ENeptuneCameraListOpt
        NEPTUNE_CAMERALISTOPT_ONLYIMI = 0
        NEPTUNE_CAMERALISTOPT_ALL = 1
    End Enum

    Public Enum ENeptuneDisplayOption

        NEPTUNE_DISPLAY_OPTION_FIT = 0

        NEPTUNE_DISPLAY_OPTION_ORIGINAL_CENTER = 1
    End Enum

    Public Enum ENeptune1394Foramt
        FORMAT_0 = 0
        FORMAT_1 = 1
        FORMAT_2 = 2
        FORMAT_7 = 7
    End Enum

    Public Enum ENeptuneDevType
        NEPTUNE_DEV_TYPE_UNKNOWN = -1
        NEPTUNE_DEV_TYPE_1394 = 0
        NEPTUNE_DEV_TYPE_USB3 = 1
        NEPTUNE_DEV_TYPE_GIGE = 2
    End Enum

    Public Enum ENeptuneDevAccess
        NEPTUNE_DEV_ACCESS_UNKNOWN = -1
        NEPTUNE_DEV_ACCESS_EXCLUSIVE = 0
        NEPTUNE_DEV_ACCESS_CONTROL = 1
        NEPTUNE_DEV_ACCESS_MONITOR = 2
    End Enum

    Public Enum ENeptuneFeature
        NEPTUNE_FEATURE_GAMMA = 0
        NEPTUNE_FEATURE_GAIN = 1
        NEPTUNE_FEATURE_RGAIN = 2
        NEPTUNE_FEATURE_GGAIN = 3
        NEPTUNE_FEATURE_BGAIN = 4
        NEPTUNE_FEATURE_BLACKLEVEL = 5
        NEPTUNE_FEATURE_SHARPNESS = 6
        NEPTUNE_FEATURE_SATURATION = 7
        NEPTUNE_FEATURE_AUTOEXPOSURE = 8
        NEPTUNE_FEATURE_SHUTTER = 9
        NEPTUNE_FEATURE_HUE = 10
        NEPTUNE_FEATURE_PAN = 11
        NEPTUNE_FEATURE_TILT = 12
        NEPTUNE_FEATURE_OPTFILTER = 13
        NEPTUNE_FEATURE_AUTOSHUTTER_MIN = 14
        NEPTUNE_FEATURE_AUTOSHUTTER_MAX = 15
        NEPTUNE_FEATURE_AUTOGAIN_MIN = 16
        NEPTUNE_FEATURE_AUTOGAIN_MAX = 17
        NEPTUNE_FEATURE_TRIGNOISEFILTER = 18
        NEPTUNE_FEATURE_BRIGHTLEVELIRIS = 19
        NEPTUNE_FEATURE_SNOWNOISEREMOVE = 20
        NEPTUNE_FEATURE_WATCHDOG = 21
        NEPTUNE_FEATURE_WHITEBALANCE = 22
        NEPTUNE_FEATURE_CONTRAST = 23
        NEPTUNE_FEATURE_LCD_BLUE_GAIN = 24
        NEPTUNE_FEATURE_LCD_RED_GAIN = 25
    End Enum

    Public Enum ENeptuneUserSet
        NEPTUNE_USERSET_DEFAULT = 0
        NEPTUNE_USERSET_1 = 1
        NEPTUNE_USERSET_2 = 2
        NEPTUNE_USERSET_3 = 3
        NEPTUNE_USERSET_4 = 4
        NEPTUNE_USERSET_5 = 5
        NEPTUNE_USERSET_6 = 6
        NEPTUNE_USERSET_7 = 7
        NEPTUNE_USERSET_8 = 8
        NEPTUNE_USERSET_9 = 9
        NEPTUNE_USERSET_10 = 10
        NEPTUNE_USERSET_11 = 11
        NEPTUNE_USERSET_12 = 12
        NEPTUNE_USERSET_13 = 13
        NEPTUNE_USERSET_14 = 14
        NEPTUNE_USERSET_15 = 15
    End Enum

    Public Enum ENeptuneUserSetCommand
        NEPTUNE_USERSET_CMD_LOAD = 0
        NEPTUNE_USERSET_CMD_SAVE = 1
    End Enum

    Public Enum ENeptuneAutoIrisMode
        NEPTUNE_AUTOIRIS_MODE_MANUAL = 0
        NEPTUNE_AUTOIRIS_MODE_AUTO = 1
    End Enum

    Public Enum ENeptuneSIOParity
        NEPTUNE_SIO_PARITY_NONE = 0
        NEPTUNE_SIO_PARITY_ODD = 1
        NEPTUNE_SIO_PARITY_EVEN = 2
    End Enum

    Public Enum ENeptuneAutoAreaSelect
        NEPTUNE_AUTOAREA_SELECT_AE = 0
        NEPTUNE_AUTOAREA_SELECT_AWB = 1
        NEPTUNE_AUTOAREA_SELECT_AF = 2
    End Enum

    Public Enum ENeptuneAutoAreaSize
        NEPTUNE_AUTOAREA_SIZE_SELECTED = 0
        NEPTUNE_AUTOAREA_SIZE_FULL = 1
    End Enum

    Public Enum ENeptuneAFMode
        NEPTUNE_AF_ORIGIN = 0
        NEPTUNE_AF_ONEPUSH = 1
        NEPTUNE_AF_STEP_FORWARD = 2
        NEPTUNE_AF_STEP_BACKWARD = 3
    End Enum

    Public Enum ENeptuneTriggerSource
        NEPTUNE_TRIGGER_SOURCE_LINE1 = 0
        NEPTUNE_TRIGGER_SOURCE_SW = 7
    End Enum

    Public Enum ENeptuneTriggerMode
        NEPTUNE_TRIGGER_MODE_0 = 0
        NEPTUNE_TRIGGER_MODE_1
        NEPTUNE_TRIGGER_MODE_2
        NEPTUNE_TRIGGER_MODE_3
        NEPTUNE_TRIGGER_MODE_4
        NEPTUNE_TRIGGER_MODE_5
        NEPTUNE_TRIGGER_MODE_6
        NEPTUNE_TRIGGER_MODE_7
        NEPTUNE_TRIGGER_MODE_8
        NEPTUNE_TRIGGER_MODE_9
        NEPTUNE_TRIGGER_MODE_10
        NEPTUNE_TRIGGER_MODE_11
        NEPTUNE_TRIGGER_MODE_12
        NEPTUNE_TRIGGER_MODE_13
        NEPTUNE_TRIGGER_MODE_14
        NEPTUNE_TRIGGER_MODE_15
    End Enum

    Public Enum ENeptuneStrobe
        NEPTUNE_STROBE0 = 0
        NEPTUNE_STROBE1 = 1
        NEPTUNE_STROBE2 = 2
        NEPTUNE_STROBE3 = 3
        NEPTUNE_STROBE4 = 4
    End Enum

    Public Enum ENeptunePolarity
        NEPTUNE_POLARITY_RISINGEDGE = 0
        NEPTUNE_POLARITY_FALLINGEDGE = 1
        NEPTUNE_POLARITY_ANYEDGE = 2
        NEPTUNE_POLARITY_LEVELHIGH = 3
        NEPTUNE_POLARITY_LEVELLOW = 4
    End Enum

    Public Enum ENeptuneNodeType
        NEPTUNE_NODE_TYPE_UKNOWN = -1
        NEPTUNE_NODE_TYPE_CATEGORY = 0
        NEPTUNE_NODE_TYPE_COMMAND = 1
        NEPTUNE_NODE_TYPE_RAW = 2
        NEPTUNE_NODE_TYPE_STRING = 3
        NEPTUNE_NODE_TYPE_ENUM = 4
        NEPTUNE_NODE_TYPE_INT = 5
        NEPTUNE_NODE_TYPE_FLOAT = 6
        NEPTUNE_NODE_TYPE_BOOLEAN = 7
    End Enum

    Public Enum ENeptuneNodeAccessMode
        NEPTUNE_NODE_ACCESSMODE_NI = 0
        NEPTUNE_NODE_ACCESSMODE_NA = 1
        NEPTUNE_NODE_ACCESSMODE_WO = 2
        NEPTUNE_NODE_ACCESSMODE_RO = 3
        NEPTUNE_NODE_ACCESSMODE_RW = 4
        NEPTUNE_NODE_ACCESSMODE_UNDEFINED = 5
    End Enum

    Public Enum ENeptuneNodeVisibility
        NEPTUNE_NODE_VISIBLE_UNKNOWN = -1
        NEPTUNE_NODE_VISIBLE_BEGINNER = 0
        NEPTUNE_NODE_VISIBLE_EXPERT = 1
        NEPTUNE_NODE_VISIBLE_GURU = 2
    End Enum

    Public Enum ENeptuneGPIO
        NEPTUNE_GPIO_LINE0 = 0
        NEPTUNE_GPIO_LINE1
    End Enum

    Public Enum ENeptuneGPIOSource
        NEPTUNE_GPIO_SOURCE_STROBE = 0
        NEPTUNE_GPIO_SOURCE_USER
    End Enum

    Public Enum ENeptuneGPIOValue
        NEPTUNE_GPIO_VALUE_LOW = 0
        NEPTUNE_GPIO_VALUE_HIGH
    End Enum

    '''///////////////////////////////////////////////////////////////////////
    <StructLayout(LayoutKind.Sequential, Pack:=1, CharSet:=CharSet.Ansi)> _
    Public Structure NEPTUNE_CAM_INFO

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=512)> _
        Public strVendor As String

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=512)> _
        Public strModel As String

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=512)> _
        Public strSerial As String

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=512)> _
        Public strUserID As String

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=512)> _
        Public strIP As String

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)> _
        Public strMAC As String

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=512)> _
        Public strSubnet As String

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=512)> _
        Public strGateway As String

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=512)> _
        Public strCamID As String
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure NEPTUNE_IMAGE_SIZE

        Public nStartX As Int32

        Public nStartY As Int32

        Public nSizeX As Int32

        Public nSizeY As Int32
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure NEPTUNE_IMAGE

        Public uiWidth As UInt32

        Public uiHeight As UInt32

        Public uiBitDepth As UInt32

        Public pData As IntPtr

        Public uiSize As UInt32

        Public uiIndex As UInt32

        Public uiTimestamp As UInt64

        Public bFrameValid As Byte
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure NEPTUNE_FEATURE

        Public bSupport As ENeptuneBoolean

        Public bOnOff As ENeptuneBoolean

        Public SupportAutoModes As Byte

        Public AutoMode As ENeptuneAutoMode

        Public Min As Int32

        Public Max As Int32

        Public Inc As Int32

        Public Value As Int32

        Public ValueAccessMode As ENeptuneNodeAccessMode
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure NEPTUNE_PACKAGE_FEATURE

        Public Gain As UInt32

        Public Sharpness As UInt32

        Public Shutter As UInt32

        Public BlackLevel As UInt32

        Public Contrast As UInt32

        Public Gamma As UInt32
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure NEPTUNE_USERSET

        Public SupportUserSet As UInt16

        Public UserSetIndex As ENeptuneUserSet

        Public Command As ENeptuneUserSetCommand
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure NEPTUNE_POINT

        Public x As UInt32

        Public y As UInt32
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure NEPTUNE_KNEE_LUT

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> _
        Public Points() As NEPTUNE_POINT

        Public bEnable As ENeptuneBoolean
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure NEPTUNE_USER_LUT

        Public SupportLUT As UInt16

        Public LUTIndex As UInt16

        Public bEnable As ENeptuneBoolean

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=4096)> _
        Public Data() As UInt16
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure NEPTUNE_SIO_PROPERTY

        Public bEnable As ENeptuneBoolean

        Public Baudrate As UInt32

        Public Parity As ENeptuneSIOParity

        Public DataBit As UInt32

        Public StopBit As UInt32
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1, CharSet:=CharSet.Ansi)> _
    Public Structure NEPTUNE_SIO

        Public TextCount As UInt32

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=256)> _
        Public strText As String

        Public TimeOut As UInt32
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure NEPTUNE_AUTOAREA

        Public OnOff As ENeptuneBoolean

        Public SizeControl As ENeptuneAutoAreaSize

        Public AreaSize As NEPTUNE_IMAGE_SIZE
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure NEPTUNE_TRIGGER_INFO

        Public bSupport As ENeptuneBoolean

        Public nModeFlag As UInt16

        Public nSourceFlag As UInt16

        Public nPolarityFlag As UInt16

        Public nParamMin As UInt16

        Public nParamMax As UInt16
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure NEPTUNE_TRIGGER

        Public Source As ENeptuneTriggerSource

        Public Mode As ENeptuneTriggerMode

        Public Polarity As ENeptunePolarity

        Public OnOff As ENeptuneBoolean

        Public nParam As UInt16
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure NEPTUNE_TRIGGER_PARAM

        Public nFrameOrder As UInt32

        Public nIncrement As UInt32

        Public nGainValue As UInt32

        Public nShutterValue As UInt32
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure NEPTUNE_TRIGGER_TABLE

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=255)> _
        Public Param() As NEPTUNE_TRIGGER_PARAM

        Public Index As UInt32
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure NEPTUNE_STROBE_INFO

        Public bSupport As ENeptuneBoolean

        Public nStrobeFlag As UInt16

        Public nPolarityFlag As UInt16

        Public nDurationMin As UInt16

        Public nDurationMax As UInt16

        Public nDelayMin As UInt16

        Public nDelayMax As UInt16
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure NEPTUNE_STROBE

        Public OnOff As ENeptuneBoolean

        Public Strobe As ENeptuneStrobe

        Public nDuration As UInt16

        Public nDelay As UInt16

        Public Polarity As ENeptunePolarity
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1, CharSet:=CharSet.Ansi)> _
    Public Structure NEPTUNE_XML_NODE_STRING
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=256)> _
        Public nodeString As String

        Public Overrides Function ToString() As String
            Return nodeString
        End Function
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1, CharSet:=CharSet.Ansi)> _
    Public Structure NEPTUNE_XML_NODE_LIST

        Public nCount As UInt32

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=128)> _
        Public pstrList() As NEPTUNE_XML_NODE_STRING

        Public Shared Function Create() As NEPTUNE_XML_NODE_LIST
            Dim ret As NEPTUNE_XML_NODE_LIST = New NEPTUNE_XML_NODE_LIST()
            ret.pstrList = New NEPTUNE_XML_NODE_STRING(128) {}
            Return ret
        End Function
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1, CharSet:=CharSet.Ansi)> _
    Public Structure NEPTUNE_XML_ENUM_LIST

        Public nCount As UInt32

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=64)> _
        Public pstrList() As NEPTUNE_XML_NODE_STRING

        Public nIndex As UInt32

        Public Shared Function Create() As NEPTUNE_XML_ENUM_LIST
            Dim ret As NEPTUNE_XML_ENUM_LIST = New NEPTUNE_XML_ENUM_LIST()
            ret.pstrList = New NEPTUNE_XML_NODE_STRING(64) {}
            Return ret
        End Function
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1, CharSet:=CharSet.Ansi)> _
    Public Structure NEPTUNE_XML_NODE_INFO

        Public Type As ENeptuneNodeType

        Public AccessMode As ENeptuneNodeAccessMode

        Public Visibility As ENeptuneNodeVisibility

        Public bHasChild As Boolean

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=512)> _
        Public strDisplayName As String

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=512)> _
        Public strTooltip As String

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=512)> _
        Public strDescription As String
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure NEPTUNE_XML_INT_VALUE_INFO

        Public nValue As Int64

        Public nMin As Int64

        Public nMax As Int64

        Public nInc As Int64

        Public AccessMode As ENeptuneNodeAccessMode
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure NEPTUNE_XML_FLOAT_VALUE_INFO

        Public dValue As Double

        Public dMin As Double

        Public dMax As Double

        Public dInc As Double

        Public AccessMode As ENeptuneNodeAccessMode
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure NEPTUNE_GPIO

        Public Gpio As ENeptuneGPIO

        Public Source As ENeptuneGPIOSource

        Public Value As ENeptuneGPIOValue
    End Structure


    ' device check callback
    Public Delegate Sub NeptuneCDevCheckCallback(ByVal emState As ENeptuneDeviceChangeState, ByVal pContext As IntPtr)

    ' camera unplug callback
    Public Delegate Sub NeptuneCUnplugCallback(ByVal pContext As IntPtr)

    ' image received callback
    Public Delegate Sub NeptuneCFrameCallback(ByRef stImage As NEPTUNE_IMAGE, ByVal pContext As IntPtr)

    ' frame drop callback
    Public Delegate Sub NeptuneCFrameDropCallback(ByVal pContext As IntPtr)

    ' receive frame timeout callback
    Public Delegate Sub NeptuneCRecvTimeoutCallback(ByVal pContext As IntPtr)

    '''///////////////////////////////////////////////////////////////////////
    Class NeptuneC

        Const strFileName As String = ".\NeptuneC_MD_VC141.dll"

        <DllImport(strFileName)> _
        Public Shared Function ntcInit() As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcUninit() As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetCameraCount(ByRef puiCount As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetCameraInfo(<Out()> pCameraInfo() As NEPTUNE_CAM_INFO, ByVal uiCount As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcOpen(ByVal pszCameraID As String, ByRef phCameraHandle As IntPtr, ByVal emAccessFlag As ENeptuneDevAccess) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcClose(ByVal hCameraHandle As IntPtr) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetCameraType(ByVal hCameraHandle As IntPtr, ByRef pemDevType As ENeptuneDevType) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetPixelFormatList(ByVal hCameraHandle As IntPtr, <Out()> pemPixelFmtList() As ENeptunePixelFormat, ByRef puiCount As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetPixelFormatString(ByVal hCameraHandle As IntPtr, ByVal emPixelFmt As ENeptunePixelFormat, <Out()> pszBuffer() As Char, ByVal uiBufSize As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetPixelFormat(ByVal hCameraHandle As IntPtr, ByRef pemPixelFmt As ENeptunePixelFormat) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetPixelFormat(ByVal hCameraHandle As IntPtr, ByVal emPixelFmt As ENeptunePixelFormat) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetFrameRateList(ByVal hCameraHandle As IntPtr, <Out()> pemFPSList() As ENeptuneFrameRate, ByRef puiCount As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetFrameRateString(ByVal hCameraHandle As IntPtr, ByVal emFPS As ENeptuneFrameRate, <Out()> pszBuffer() As Char, ByVal uiBufSize As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetFrameRate(ByVal hCameraHandle As IntPtr, ByRef pemFPS As ENeptuneFrameRate, ByRef pdbFPS As Double) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetFrameRate(ByVal hCameraHandle As IntPtr, ByVal emFPS As ENeptuneFrameRate, ByVal dbFPS As Double) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetReceiveFrameRate(ByVal hCameraHandle As IntPtr, ByRef pfRecvFPS As Single) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetMaxImageSize(ByVal hCameraHandle As IntPtr, ByRef pImageSize As NEPTUNE_IMAGE_SIZE) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetImageSize(ByVal hCameraHandle As IntPtr, ByRef pImageSize As NEPTUNE_IMAGE_SIZE) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetImageSize(ByVal hCameraHandle As IntPtr, ByVal stImageSize As NEPTUNE_IMAGE_SIZE) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetAcquisition(ByVal hCameraHandle As IntPtr, ByRef pemState As ENeptuneBoolean) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetAcquisition(ByVal hCameraHandle As IntPtr, ByVal emState As ENeptuneBoolean) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetAcquisitionMode(ByVal hCameraHandle As IntPtr, ByRef pemAcqMode As ENeptuneAcquisitionMode, ByRef puiFrames As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetAcquisitionMode(ByVal hCameraHandle As IntPtr, ByVal emAcqMode As ENeptuneAcquisitionMode, ByVal uiFrames As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcOneShot(ByVal hCameraHandle As IntPtr) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcMultiShot(ByVal hCameraHandle As IntPtr) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetBayerConvert(ByVal hCameraHandle As IntPtr, ByRef pemMethod As ENeptuneBayerMethod) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetBayerConvert(ByVal hCameraHandle As IntPtr, ByVal emMethod As ENeptuneBayerMethod) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetBayerLayout(ByVal hCameraHandle As IntPtr, ByRef pemLayout As ENeptuneBayerLayout) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetBayerLayout(ByVal hCameraHandle As IntPtr, ByVal emLayout As ENeptuneBayerLayout) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetRotation(ByVal hCameraHandle As IntPtr, ByRef pemAngle As ENeptuneRotationAngle) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetRotation(ByVal hCameraHandle As IntPtr, ByVal emAngle As ENeptuneRotationAngle) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetEffect(ByVal hCameraHandle As IntPtr, ByRef pnEffectFlag As Int32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetEffect(ByVal hCameraHandle As IntPtr, ByVal nEffectFlag As Int32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetCameraListOpt(ByRef pemCameraListOpt As ENeptuneCameraListOpt) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetCameraListOpt(ByVal emCameraListOpt As ENeptuneCameraListOpt) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetDisplayOption(ByRef pemDisplayOpt As ENeptuneDisplayOption) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetDisplayOption(ByVal emDisplayOpt As ENeptuneDisplayOption) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetDisplay(ByVal hCameraHandle As IntPtr, ByVal hWnd As IntPtr) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcShowControlDialog(ByVal hCameraHandle As IntPtr) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGrab(ByVal hCameraHandle As IntPtr, ByRef pImageInfo As NEPTUNE_IMAGE, ByVal emGrabFmt As ENeptuneGrabFormat, ByVal uiTimeOut As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetRGBData(ByVal hCameraHandle As IntPtr, <Out()> pBuffer() As Byte, ByVal uiBufSize As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetRGB32Data(ByVal hCameraHandle As IntPtr, <Out()> pBuffer() As Byte, ByVal uiBufSize As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSaveImage(ByVal hCameraHandle As IntPtr, ByVal pszFilePathName As String, ByVal uiQuality As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcStartStreamCapture(ByVal hCameraHandle As IntPtr, ByVal pszFilePathName As String, ByVal emCompress As ENeptuneBoolean, ByVal uiBitrate As UInt32, ByVal fPlaySpeed As Double) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcStopStreamCapture(ByVal hCameraHandle As IntPtr) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetFeature(ByVal hCameraHandle As IntPtr, ByVal emFeatureType As ENeptuneFeature, ByRef pFeatureInfo As NEPTUNE_FEATURE) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetFeature(ByVal hCameraHandle As IntPtr, ByVal emFeatureType As ENeptuneFeature, ByVal stFeatureInfo As NEPTUNE_FEATURE) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetPackageFeature(ByVal hCameraHandle As IntPtr, ByRef pPackageFeature As NEPTUNE_PACKAGE_FEATURE) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetPackageFeature(ByVal hCameraHandle As IntPtr, ByVal stPackageFeature As NEPTUNE_PACKAGE_FEATURE) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetExposureTime(ByVal hCameraHandle As IntPtr, ByRef puiMicroSec As UInt32, ByRef puiMin As UInt32, ByRef puiMax As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetExposureTime(ByVal hCameraHandle As IntPtr, ByVal uiMicroSec As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetShutterString(ByVal hCameraHandle As IntPtr, ByVal pszExposureTime As String) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetTriggerMode14Exposure(ByVal hCameraHandle As IntPtr, ByVal uiExposure As UInt32, ByVal uiInterval As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetTriggerInfo(ByVal hCameraHandle As IntPtr, ByRef pTriggerInfo As NEPTUNE_TRIGGER_INFO) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetTrigger(ByVal hCameraHandle As IntPtr, ByRef pTrigger As NEPTUNE_TRIGGER) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetTrigger(ByVal hCameraHandle As IntPtr, ByVal stTrigger As NEPTUNE_TRIGGER) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetTriggerDelay(ByVal hCameraHandle As IntPtr, ByRef puiValue As UInt32, ByRef puiMin As UInt32, ByRef puiMax As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetTriggerDelay(ByVal hCameraHandle As IntPtr, ByVal uiValue As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcRunSWTrigger(ByVal hCameraHandle As IntPtr) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcRunSWTriggerEx(ByVal hCameraHandle As IntPtr, ByVal uiTimeout As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcReadTriggerTable(ByVal hCameraHandle As IntPtr, ByRef pTriggerTable As NEPTUNE_TRIGGER_TABLE) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSaveTriggerTable(ByVal hCameraHandle As IntPtr, ByVal stTriggerTable As NEPTUNE_TRIGGER_TABLE) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcLoadTriggerTable(ByVal hCameraHandle As IntPtr, ByVal uiIndex As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetStrobeInfo(ByVal hCameraHandle As IntPtr, ByRef pStrobeInfo As NEPTUNE_STROBE_INFO) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetStrobe(ByVal hCameraHandle As IntPtr, ByRef pStrobe As NEPTUNE_STROBE) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetStrobe(ByVal hCameraHandle As IntPtr, ByVal stStrobe As NEPTUNE_STROBE) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetAutoAreaControl(ByVal hCameraHandle As IntPtr, ByVal emSelect As ENeptuneAutoAreaSelect, ByRef pAutoArea As NEPTUNE_AUTOAREA) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetAutoAreaControl(ByVal hCameraHandle As IntPtr, ByVal emSelect As ENeptuneAutoAreaSelect, ByVal stAutoArea As NEPTUNE_AUTOAREA) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetAFControl(ByVal hCameraHandle As IntPtr, ByVal emControlMode As ENeptuneAFMode) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetAutoIrisMode(ByVal hCameraHandle As IntPtr, ByVal emAutoIrisMode As ENeptuneAutoIrisMode) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetAutoIrisAverageFrame(ByVal hCameraHandle As IntPtr, ByRef puiValue As UInt32, ByRef puiMin As UInt32, ByRef puiMax As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetAutoIrisAverageFrame(ByVal hCameraHandle As IntPtr, ByVal uiValue As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetAutoIrisTargetValue(ByVal hCameraHandle As IntPtr, ByRef puiValue As UInt32, ByRef puiMin As UInt32, ByRef puiMax As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetAutoIrisTargetValue(ByVal hCameraHandle As IntPtr, ByVal uiValue As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetBitsPerPixel(ByVal hCameraHandle As IntPtr, ByRef puiValue As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetBytePerPacket(ByVal hCameraHandle As IntPtr, ByRef puiValue As UInt32, ByRef puiMin As UInt32, ByRef puiMax As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetBytePerPacket(ByVal hCameraHandle As IntPtr, ByVal uiValue As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetPacketSize(ByVal hCameraHandle As IntPtr, ByRef puiValue As UInt32, ByRef puiMin As UInt32, ByRef puiMax As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetPacketSize(ByVal hCameraHandle As IntPtr, ByVal uiValue As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetPacketResend(ByVal hCameraHandle As IntPtr, ByVal emEnable As ENeptuneBoolean) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetBufferCount(ByVal hCameraHandle As IntPtr, ByRef puiCount As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetBufferCount(ByVal hCameraHandle As IntPtr, ByVal uiCount As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetUSBTriggerBufferCount(ByVal hCameraHandle As IntPtr, ByVal uiCount As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetBufferSize(ByVal hCameraHandle As IntPtr, ByRef puiSize As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetRecvDroppedFrame(ByVal hCameraHandle As IntPtr, ByVal emEnable As ENeptuneBoolean) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetHeartbeatTime(ByVal hCameraHandle As IntPtr, ByVal ulMilliSecTime As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetMulticastAddress(ByVal hCameraHandle As IntPtr, ByVal pszAddress As String) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetUserSet(ByVal hCameraHandle As IntPtr, ByRef pUserSet As NEPTUNE_USERSET) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetUserSet(ByVal hCameraHandle As IntPtr, ByVal stUserSet As NEPTUNE_USERSET) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetDefaultUserSet(ByVal hCameraHandle As IntPtr, ByVal emUserSet As ENeptuneUserSet) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetPowerOnDefaultUserSet(ByVal hCameraHandle As IntPtr, ByVal emUserSet As ENeptuneUserSet) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSaveCameraParameter(ByVal hCameraHandle As IntPtr, ByVal pszFilePathName As String) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcLoadCameraParameter(ByVal hCameraHandle As IntPtr, ByVal pszFilePathName As String) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetKneeLUT(ByVal hCameraHandle As IntPtr, ByRef pKneeLUT As NEPTUNE_KNEE_LUT) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetKneeLUT(ByVal hCameraHandle As IntPtr, ByVal stKneeLUT As NEPTUNE_KNEE_LUT) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetUserLUT(ByVal hCameraHandle As IntPtr, ByRef pUserLUT As NEPTUNE_USER_LUT) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetUserLUT(ByVal hCameraHandle As IntPtr, ByVal stUserLUT As NEPTUNE_USER_LUT) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetFrameSave(ByVal hCameraHandle As IntPtr, ByRef pemOnOff As ENeptuneBoolean, ByRef puiFrameRemained As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetFrameSave(ByVal hCameraHandle As IntPtr, ByVal emOnOff As ENeptuneBoolean, ByVal emTransfer As ENeptuneBoolean, ByVal uiFrames As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetGPIO(ByVal hCameraHandle As IntPtr, ByVal stGpio As NEPTUNE_GPIO) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcReadSIO(ByVal hCameraHandle As IntPtr, ByRef pData As NEPTUNE_SIO) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcWriteSIO(ByVal hCameraHandle As IntPtr, ByVal stData As NEPTUNE_SIO) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetSIO(ByVal hCameraHandle As IntPtr, ByVal stProperty As NEPTUNE_SIO_PROPERTY) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcReadRegister(ByVal hCameraHandle As IntPtr, ByVal ulAddress As UInt32, ByRef pulValue As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcWriteRegister(ByVal hCameraHandle As IntPtr, ByVal ulAddress As UInt32, ByVal ulValue As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcReadBlock(ByVal hCameraHandle As IntPtr, ByVal ulAddress As UInt32, ByRef pBuffer As Byte, ByRef pulBufSize As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcWriteBlock(ByVal hCameraHandle As IntPtr, ByVal ulAddress As UInt32, ByRef pBuffer As Byte, ByVal ulBufSize As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcWriteBroadcast(ByVal hCameraHandle As IntPtr, ByVal ulAddress As UInt32, ByVal ulValue As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetNodeVisibility(ByVal hCameraHandle As IntPtr, ByRef pemVisibility As ENeptuneNodeVisibility) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetNodeVisibility(ByVal hCameraHandle As IntPtr, ByVal emVisibility As ENeptuneNodeVisibility) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetNodeList(ByVal hCameraHandle As IntPtr, ByVal pszParentNodeName As String, ByRef pNodeInfoList As NEPTUNE_XML_NODE_LIST) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetNodeListChar(ByVal hCameraHandle As IntPtr, ByVal pszParentNodeName As String, <Out()> pBuffer() As Char, ByVal uiStrLength As UInt32, ByRef puiCount As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetNodeInfo(ByVal hCameraHandle As IntPtr, ByVal pszNodeName As String, ByRef pNodeInfo As NEPTUNE_XML_NODE_INFO) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetNodeInt(ByVal hCameraHandle As IntPtr, ByVal pszNodeName As String, ByRef pValueInfo As NEPTUNE_XML_INT_VALUE_INFO) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetNodeInt(ByVal hCameraHandle As IntPtr, ByVal pszNodeName As String, ByVal nValue As Int64) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetNodeFloat(ByVal hCameraHandle As IntPtr, ByVal pszNodeName As String, ByRef pValueInfo As NEPTUNE_XML_FLOAT_VALUE_INFO) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetNodeFloat(ByVal hCameraHandle As IntPtr, ByVal pszNodeName As String, ByVal dbValue As Double) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetNodeEnum(ByVal hCameraHandle As IntPtr, ByVal pszNodeName As String, ByRef pEnumList As NEPTUNE_XML_ENUM_LIST) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetNodeEnumChar(ByVal hCameraHandle As IntPtr, ByVal pszNodeName As String, <Out()> pBuffer() As Char, ByVal uiStrLength As UInt32, ByRef puiCount As UInt32, ByRef puiIndex As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetNodeEnum(ByVal hCameraHandle As IntPtr, ByVal pszNodeName As String, ByVal pszValue As String) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetNodeString(ByVal hCameraHandle As IntPtr, ByVal pszNodeName As String, <Out()> pBuffer() As Char, ByRef puiBufSize As UInt32, ByRef pemAccessMode As ENeptuneNodeAccessMode) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetNodeString(ByVal hCameraHandle As IntPtr, ByVal pszNodeName As String, ByVal pszValue As String) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetNodeBoolean(ByVal hCameraHandle As IntPtr, ByVal pszNodeName As String, ByRef pemState As ENeptuneBoolean) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetNodeBoolean(ByVal hCameraHandle As IntPtr, ByVal pszNodeName As String, ByVal emState As ENeptuneBoolean) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetNodeCommand(ByVal hCameraHandle As IntPtr, ByVal pszNodeName As String) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetDeviceCheckCallback(ByVal fpCallback As NeptuneCDevCheckCallback, ByVal pContext As IntPtr) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetUnplugCallback(ByVal hCameraHandle As IntPtr, ByVal fpCallback As NeptuneCUnplugCallback, ByVal pContext As IntPtr) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetFrameCallback(ByVal hCameraHandle As IntPtr, ByVal fpCallback As NeptuneCFrameCallback, ByVal pContext As IntPtr) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetFrameDropCallback(ByVal hCameraHandle As IntPtr, ByVal fpCallback As NeptuneCFrameDropCallback, ByVal pContext As IntPtr) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetRecvTimeoutCallback(ByVal hCameraHandle As IntPtr, ByVal fpCallback As NeptuneCRecvTimeoutCallback, ByVal pContext As IntPtr) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcInitCam4AltLed(ByVal hCameraHandle As IntPtr) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcUpdateCam4AltLedTable(ByVal hCameraHandle As IntPtr, ByVal piData() As Int32, ByVal iSize As Int32) As ENeptuneError      ' iSize = 255*64*sizeof(_int32_t)
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetCam4AltLedIndex(ByVal hCameraHandle As IntPtr, ByVal bAutoRun As ENeptuneBoolean, ByVal iStart As Int32, ByVal iEnd As Int32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetCam4AltLedDirect(ByVal hCameraHandle As IntPtr, ByVal iIndex As Int32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetStackedRoiControl(ByVal hCameraHandle As IntPtr, ByRef pemState As ENeptuneBoolean) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetStackedRoiControl(ByVal hCameraHandle As IntPtr, ByVal emState As ENeptuneBoolean) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetStackedRoiSelector(ByVal hCameraHandle As IntPtr, ByRef puiStackedRoiIdx As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetStackedRoiSelector(ByVal hCameraHandle As IntPtr, ByVal uiStackedRoiIdx As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetStackedRoiSelectedEnable(ByVal hCameraHandle As IntPtr, ByRef pemState As ENeptuneBoolean) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetStackedRoiSelectedEnable(ByVal hCameraHandle As IntPtr, ByVal emState As ENeptuneBoolean) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetStackedRoiOffsetX(ByVal hCameraHandle As IntPtr, ByRef puiOffsetX As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetStackedRoiOffsetX(ByVal hCameraHandle As IntPtr, ByVal uiOffsetX As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetStackedRoiOffsetXAll(ByVal hCameraHandle As IntPtr, ByVal uiOffsetX As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetStackedRoiWidth(ByVal hCameraHandle As IntPtr, ByRef puiWidth As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetStackedRoiWidth(ByVal hCameraHandle As IntPtr, ByVal uiWidth As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetStackedRoiWidthAll(ByVal hCameraHandle As IntPtr, ByVal uiWidth As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetStackedRoiOffsetY(ByVal hCameraHandle As IntPtr, ByRef puiOffsetY As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetStackedRoiOffsetY(ByVal hCameraHandle As IntPtr, ByVal uiOffsetY As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcGetStackedRoiHeight(ByVal hCameraHandle As IntPtr, ByRef puiHeight As UInt32) As ENeptuneError
        End Function

        <DllImport(strFileName)> _
        Public Shared Function ntcSetStackedRoiHeight(ByVal hCameraHandle As IntPtr, ByVal uiHeight As UInt32) As ENeptuneError
        End Function

    End Class
End Namespace