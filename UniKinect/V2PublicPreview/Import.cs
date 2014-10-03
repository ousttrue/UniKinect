using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UniKinect.V2PublicPreview
{
    // to marshal the data from NuiImageFrame to this struct
    // reference: http://msdn.microsoft.com/en-us/library/microsoft.kinect.kinect.ikinectsensor.aspx
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport, Guid("3C6EBA94-0DE1-4360-B6D4-653A10794C8B")]
    public interface IKinectSensor
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        IntPtr SubscribeIsAvailableChanged();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void UnsubscribeIsAvailableChanged(
            [In]IntPtr waitableHandle);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.IUnknown)]
        Object GetIsAvailableChangedEventData(
            [In]IntPtr waitableHandle);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Open();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Close();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Bool)]
        Boolean get_IsOpen();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean get_IsAvailable();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IColorFrameSource get_ColorFrameSource();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IDepthFrameSource get_DepthFrameSource();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IBodyFrameSource get_BodyFrameSource();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IBodyIndexFrameSource get_BodyIndexFrameSource();
        
#if false
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IInfraredFrameSource get_InfraredFrameSource();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ILongExposureInfraredFrameSource get_LongExposureInfraredFrameSource();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IAudioSource get_AudioSource();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IMultiSourceFrameReader OpenMultiSourceFrameReader();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ICoordinateMapper get_CoordinateMapper();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.LPWStr)]
        String get_UniqueKinectId(UInt32 bufferSize);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        UInt32 get_KinectCapabilities();
#endif
    }

    public enum ColorImageFormat
    {
        ColorImageFormat_None = 0,
        ColorImageFormat_Rgba = 1,
        ColorImageFormat_Yuv = 2,
        ColorImageFormat_Bgra = 3,
        ColorImageFormat_Bayer = 4,
        ColorImageFormat_Yuy2 = 5
    };

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport, Guid("57621D82-D8EE-4783-B412-F7E019C96CFD")]
    public interface IColorFrameSource
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        IntPtr SubscribeFrameCaptured();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void UnsubscribeFrameCaptured(IntPtr waitableHandle);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.IUnknown)]
        Object GetFrameCapturedEventData(IntPtr waitableHandle);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Bool)]
        Boolean get_IsActive();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IColorFrameReader OpenReader();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.IUnknown)]
        Object CreateFrameDescription(ColorImageFormat format);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IFrameDescription get_FrameDescription();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IKinectSensor get_KinectSensor();
    }

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport, Guid("9BEA498C-C59C-4653-AAF9-D884BAB7C35B")]
    public interface IColorFrameReader
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        IntPtr SubscribeFrameArrived();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void UnsubscribeFrameArrived(IntPtr waitableHandle);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IColorFrameArrivedEventArgs GetFrameArrivedEventData(IntPtr waitableHandle);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IColorFrame AcquireLatestFrame();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Bool)]
        Boolean get_IsPaused();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void put_IsPaused([MarshalAs(UnmanagedType.Bool)]Boolean isPaused);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IColorFrameSource get_ColorFrameSource();
    }

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport, Guid("82A2E32F-4AE5-4614-88BB-DCC5AE0CEAED")]
    public interface IColorFrameArrivedEventArgs
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IColorFrameReference get_FrameReference();
    };

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport, Guid("5CC49E38-9BBD-48BE-A770-FD30EA405247")]
    public interface IColorFrameReference
    {
        //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IColorFrame AcquireFrame();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Int64 get_RelativeTime();        
    };

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport, Guid("39D05803-8803-4E86-AD9F-13F6954E4ACA")]
    public interface IColorFrame
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.I4)]
        ColorImageFormat get_RawColorImageFormat();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IFrameDescription get_FrameDescription();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CopyRawFrameDataToArray(Int32 capacity
            , [MarshalAs(UnmanagedType.LPArray)]Byte[] frameData);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        IntPtr AccessRawUnderlyingBuffer(out UInt32 capacity);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CopyConvertedFrameDataToArray(Int32 capacity
            , IntPtr frameData
            , ColorImageFormat colorFormat);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.IUnknown)]
        Object CreateFrameDescription(ColorImageFormat format);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.IUnknown)]
        Object get_ColorCameraSettings();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Int64 get_RelativeTime();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IColorFrameSource get_ColorFrameSource();
    }

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport, Guid("21F6EFB7-EB6D-48F4-9C08-181A87BF0C98")]
    public interface IFrameDescription
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Int32 get_Width();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Int32 get_Height();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Single get_HorizontalFieldOfView();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Single get_VerticalFieldOfView();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Single get_DiagonalFieldOfView();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        UInt32 get_LengthInPixels();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        UInt32 get_BytesPerPixel();
    };

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport, Guid("C428D558-5E46-490A-B699-D1DDDAA24150")]
    public interface IDepthFrameSource
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        IntPtr SubscribeFrameCaptured();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void UnsubscribeFrameCaptured(IntPtr waitableHandle);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        IFrameCapturedEventArgs GetFrameCapturedEventData(IntPtr waitableHandle);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Bool)]
        Boolean get_IsActive();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IDepthFrameReader OpenReader();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        UInt16 get_DepthMinReliableDistance();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        UInt16 get_DepthMaxReliableDistance();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IFrameDescription get_FrameDescription();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IKinectSensor get_KinectSensor();
    };

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport, Guid("81C0C0AB-6E6C-45CB-8625-A5F4D38759A4")]
    public interface IDepthFrameReader
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        IntPtr SubscribeFrameArrived();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void UnsubscribeFrameArrived(IntPtr waitableHandle);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IDepthFrameArrivedEventArgs GetFrameArrivedEventData(IntPtr waitableHandle);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IDepthFrame AcquireLatestFrame();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Bool)]
        Boolean get_IsPaused();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void put_IsPaused([MarshalAs(UnmanagedType.Bool)]Boolean isPaused);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IDepthFrameSource get_DepthFrameSource();
    };

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport, Guid("D8600853-8835-44F9-84A7-E617CDD7DFDD")]
    public interface IDepthFrame
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CopyFrameDataToArray(UInt32 capacity, IntPtr frameData);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        IntPtr AccessUnderlyingBuffer(out UInt32 capaticy);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IFrameDescription get_FrameDescription();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Int64 get_RelativeTime();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IDepthFrameSource get_DepthFrameSource();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        UInt16 get_DepthMinReliableDistance();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        UInt16 get_DepthMaxReliableDistance();
    };

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport, Guid("2B01BCB8-29D7-4726-860C-6DA56664AA81")]
    public interface IDepthFrameArrivedEventArgs
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IDepthFrameReference get_FrameReference();
    };

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport, Guid("20621E5E-ABC9-4EBD-A7EE-4C77EDD0152A")]
    public interface IDepthFrameReference
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IDepthFrame AcquireFrame();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Int64 get_RelativeTime();
    };

    [Flags]
    public enum FrameSourceTypes
    {
        FrameSourceTypes_None = 0,
        FrameSourceTypes_Color = 0x1,
        FrameSourceTypes_Infrared = 0x2,
        FrameSourceTypes_LongExposureInfrared = 0x4,
        FrameSourceTypes_Depth = 0x8,
        FrameSourceTypes_BodyIndex = 0x10,
        FrameSourceTypes_Body = 0x20,
        FrameSourceTypes_Audio = 0x40
    };

    public enum FrameCapturedStatus
    {
        FrameCapturedStatus_Unknown = 0,
        FrameCapturedStatus_Queued = 1,
        FrameCapturedStatus_Dropped = 2
    };

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport, Guid("24CBAB8E-DF1A-4FA8-827E-C1B27A44A3A1")]
    public interface IFrameCapturedEventArgs
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        FrameSourceTypes get_FrameType();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        FrameCapturedStatus get_FrameStatus();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Int64 get_RelativeTime();
    };

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport, Guid("BB94A78A-458C-4608-AC69-34FEAD1E3BAE")]
    public interface IBodyFrameSource
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        IntPtr SubscribeFrameCaptured();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void UnsubscribeFrameCaptured(IntPtr waitableHandle);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IFrameCapturedEventArgs GetFrameCapturedEventData(IntPtr waitableHandle);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Bool)]
        Boolean get_IsActive();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Int32 get_BodyCount();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IBodyFrameReader OpenReader();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IKinectSensor get_KinectSensor();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void OverrideHandTracking(UInt64 trackingId);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void OverrideAndReplaceHandTracking(UInt64 oldTrackingId, UInt64 newTrackingId);
    };

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport, Guid("45532DF5-A63C-418F-A39F-C567936BC051")]
    public interface IBodyFrameReader
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        IntPtr SubscribeFrameArrived();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void UnsubscribeFrameArrived(IntPtr waitableHandle);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IBodyFrameArrivedEventArgs GetFrameArrivedEventData(IntPtr waitableHandle);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IBodyFrame AcquireLatestFrame();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Bool)]
        Boolean get_IsPaused();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void put_IsPaused([MarshalAs(UnmanagedType.Bool)]Boolean isPaused);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IBodyFrameSource get_BodyFrameSource();
    };

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport, Guid("BF5CCA0E-00C1-4D48-837F-AB921E6AEE01")]
    public interface IBodyFrameArrivedEventArgs
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IBodyFrameReference get_FrameReference();
    };

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport, Guid("C3A1733C-5F84-443B-9659-2F2BE250C97D")]
    public interface IBodyFrameReference
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IBodyFrame AcquireFrame();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Int64 get_RelativeTime();
    };

    public struct Vector4
    {
        public Single x;
        public Single y;
        public Single z;
        public Single w;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Bodies
    {
        [MarshalAs(UnmanagedType.Interface)]
        public IBody _0;
        [MarshalAs(UnmanagedType.Interface)]
        public IBody _1;
        [MarshalAs(UnmanagedType.Interface)]
        public IBody _2;
        [MarshalAs(UnmanagedType.Interface)]
        public IBody _3;
        [MarshalAs(UnmanagedType.Interface)]
        public IBody _4;
        [MarshalAs(UnmanagedType.Interface)]
        public IBody _5;
    }

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport, Guid("52884F1F-94D7-4B57-BF87-9226950980D5")]
    public interface IBodyFrame
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetAndRefreshBodyData(UInt32 capacity, ref Bodies bodies);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Vector4 get_FloorClipPlane();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Int64 get_RelativeTime();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IBodyFrameSource get_BodyFrameSource();
    };

    public enum JointType
    {
        JointType_SpineBase = 0,
        JointType_SpineMid = 1,
        JointType_Neck = 2,
        JointType_Head = 3,
        JointType_ShoulderLeft = 4,
        JointType_ElbowLeft = 5,
        JointType_WristLeft = 6,
        JointType_HandLeft = 7,
        JointType_ShoulderRight = 8,
        JointType_ElbowRight = 9,
        JointType_WristRight = 10,
        JointType_HandRight = 11,
        JointType_HipLeft = 12,
        JointType_KneeLeft = 13,
        JointType_AnkleLeft = 14,
        JointType_FootLeft = 15,
        JointType_HipRight = 16,
        JointType_KneeRight = 17,
        JointType_AnkleRight = 18,
        JointType_FootRight = 19,
        JointType_SpineShoulder = 20,
        JointType_HandTipLeft = 21,
        JointType_ThumbLeft = 22,
        JointType_HandTipRight = 23,
        JointType_ThumbRight = 24,
        JointType_Count = (JointType_ThumbRight + 1)
    }

    public struct CameraSpacePoint
    {
        public float X;
        public float Y;
        public float Z;
    }

    public enum TrackingState
    {
        TrackingState_NotTracked = 0,
        TrackingState_Inferred = 1,
        TrackingState_Tracked = 2
    }

    public struct Joint
    {
        public JointType JointType;
        public CameraSpacePoint Position;
        public TrackingState TrackingState;
    }

    public struct JointOrientation
    {
        public JointType JointType;
        public Vector4 Orientation;
    }

    public enum DetectionResult
    {
        DetectionResult_Unknown = 0,
        DetectionResult_No = 1,
        DetectionResult_Maybe = 2,
        DetectionResult_Yes = 3
    }

    public enum HandState
    {
        HandState_Unknown = 0,
        HandState_NotTracked = 1,
        HandState_Open = 2,
        HandState_Closed = 3,
        HandState_Lasso = 4
    }

    public enum TrackingConfidence
    {
        TrackingConfidence_Low = 0,
        TrackingConfidence_High = 1
    }

    public struct PointF
    {
        public float X;
        public float Y;
    }

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport, Guid("46AEF731-98B0-4D18-827B-933758678F4A")]
    public interface IBody
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetJoints(UInt32 capacity, ref Joint[] joints);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetJointOrientations(UInt32 capacity, JointOrientation[] jointOrientations);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        DetectionResult get_Engaged();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        DetectionResult GetExpressionDetectionResults(UInt32 capacity);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        DetectionResult GetActivityDetectionResults(UInt32 capacity);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        DetectionResult GetAppearanceDetectionResults(UInt32 capacity);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HandState get_HandLeftState();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        TrackingConfidence get_HandLeftConfidence();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HandState get_HandRightState();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        TrackingConfidence get_HandRightConfidence();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        UInt32 get_ClippedEdges();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        UInt64 get_TrackingId();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Bool)]
        Boolean get_IsTracked();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Bool)]
        Boolean get_IsRestricted();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        PointF get_Lean();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        TrackingState get_LeanTrackingState();
    };

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport, Guid("010F2A40-DC58-44A5-8E57-329A583FEC08")]
    public interface IBodyIndexFrameSource
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        IntPtr SubscribeFrameCaptured();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void UnsubscribeFrameCaptured(IntPtr waitableHandle);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IFrameCapturedEventArgs GetFrameCapturedEventData(IntPtr waitableHandle);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean get_IsActive();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IBodyIndexFrameReader OpenReader();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IFrameDescription get_FrameDescription();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IKinectSensor get_KinectSensor();        
    };

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport, Guid("E9724AA1-EBFA-48F8-9044-E0BE33383B8B")]
    public interface IBodyIndexFrameReader
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        IntPtr SubscribeFrameArrived();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void UnsubscribeFrameArrived(IntPtr waitableHandle);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IBodyIndexFrameArrivedEventArgs GetFrameArrivedEventData(IntPtr waitableHandle);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IBodyIndexFrame AcquireLatestFrame();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean get_IsPaused();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void put_IsPaused(Boolean isPaused);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IBodyIndexFrameSource get_BodyIndexFrameSource();        
    };

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport, Guid("10B7E92E-B4F2-4A36-A459-06B2A4B249DF")]
    public interface IBodyIndexFrameArrivedEventArgs
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IBodyIndexFrameReference get_FrameReference();
    };
    
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport, Guid("D0EA0519-F7E7-4B1E-B3D8-03B3C002795F")]
    public interface IBodyIndexFrameReference
    {    
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IBodyIndexFrame AcquireFrame();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Int64 get_RelativeTime();        
    };

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport, Guid("2CEA0C07-F90C-44DF-A18C-F4D18075EA6B")]
    public interface IBodyIndexFrame
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CopyFrameDataToArray([In]UInt32 capacity, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex=0)]Byte[] frameData);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        IntPtr AccessUnderlyingBuffer([Out]out UInt32 capacity);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IFrameDescription get_FrameDescription();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Int64 get_RelativeTime();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IBodyIndexFrameSource get_BodyIndexFrameSource();        
    };


    public static partial class Import
    {
        const String DllPath = @"C:\Windows\System32\Kinect20.dll";
        public const Int32 BodyCount = 6;

        [DllImport(DllPath, PreserveSig = true, CallingConvention = CallingConvention.Winapi)]
        public static extern Int32 GetDefaultKinectSensor([MarshalAs(UnmanagedType.Interface)]out IKinectSensor sensor);
    }
}
