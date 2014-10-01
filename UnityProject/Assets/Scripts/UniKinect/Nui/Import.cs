using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;


namespace UniKinect.Nui
{

    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum NuiInitializeFlags : uint
    {
        None = 0,
        UsesDepthAndPlayerIndex = 0x00000001,
        UsesColor = 0x00000002,
        UsesSkeleton = 0x00000008,
        UsesDepth = 0x00000020,
        UsesHighQualityColor = 0x00000040,
    }

    public static partial class Import
    {
        const String DllPath = @"C:\Windows\System32\Kinect10.dll";
        public static int SkeletonCount = 6;
        public static int SkeletonMaxTracked = 2;

        [DllImport(DllPath, PreserveSig = true)]
        public static extern Int32 NuiInitialize(NuiInitializeFlags dwFlags);

        [DllImport(DllPath, PreserveSig = true)]
        public static extern void NuiShutdown();

        [DllImport(DllPath, PreserveSig = true)]
        public static extern Int32 NuiCameraElevationGetAngle(out Int32 angle);

        [DllImport(DllPath, PreserveSig = true)]
        public static extern Int32 NuiCameraElevationSetAngle(Int32 angle);
    }

    public enum NuiImageType
    {
        DepthAndPlayerIndex = 0,	// USHORT
        Color,						// RGB32 data
        ColorYUV,					// YUY2 stream from camera h/w, but converted to RGB32 before user getting it.
        ColorRawYUV,				// YUY2 stream from camera h/w.
        Depth						// USHORT
    }

    public enum NuiImageResolution
    {
        resolutionInvalid = -1,
        resolution80x60 = 0,
        resolution320x240,
        resolution640x480,
        resolution1280x1024                        // for hires color only
    }

    public struct NuiImageViewArea
    {
        int eDigitalZoom_NotUsed;
        long lCenterX_NotUsed;
        long lCenterY_NotUsed;
    }

    // Reference: http://msdn.microsoft.com/en-us/library/nuiimagecamera.nui_image_frame.aspx
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NuiImageFrame
    {
        public Int64 liTimeStamp;
        public uint dwFrameNumber;
        public NuiImageType eImageType;
        public NuiImageResolution eResolution;
        [MarshalAs(UnmanagedType.Interface)]
        public INuiFrameTexture pFrameTexture;
        public uint dwFrameFlags_NotUsed;
        public NuiImageViewArea ViewArea_NotUsed;
    }


    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NuiLockedRect
    {
        public int pitch;
        public int size;
        public IntPtr pBits;

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NuiSurfaceDesc
    {
        uint width;
        uint height;
    }

    // to marshal the data from NuiImageFrame to this struct
    // reference: http://msdn.microsoft.com/en-us/library/nuisensor.inuiframetexture.aspx
    [Guid("13ea17f5-ff2e-4670-9ee5-1297a6e880d1")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport()]
    public interface INuiFrameTexture
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig]
        int BufferLen();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig]
        int Pitch();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void LockRect(uint Level, ref NuiLockedRect pLockedRect, IntPtr pRect, uint Flags);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetLevelDesc(uint Level, ref NuiSurfaceDesc pDesc);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void UnlockRect(uint Level);
    }

    [Flags]
    public enum NuiImageStreamFlags : uint
    {
        None = 0x00000000,
        SupressNoFrameData = 0x0001000,
        EnableNearMode = 0x00020000,
        TooFarIsNonZero = 0x0004000
    }

    public static partial class Import
    {
        [DllImport(DllPath, PreserveSig = true)]
        public static extern Int32 NuiImageStreamOpen(
            NuiImageType eImageType, NuiImageResolution eResolution
            , uint dwImageFrameFlags_NotUsed, uint dwFrameLimit
            , IntPtr hNextFrameEvent, out IntPtr phStreamHandle);

        [DllImport(DllPath, PreserveSig = true)]
        public static extern Int32 NuiImageStreamGetNextFrame(
            IntPtr phStreamHandle, uint dwMillisecondsToWait, out IntPtr pFrame);

        [DllImport(DllPath, PreserveSig = true)]
        public static extern Int32 NuiImageStreamReleaseFrame(
            IntPtr phStreamHandle, IntPtr ppcImageFrame);

        [DllImport(DllPath, PreserveSig = true)]
        public static extern Int32 NuiImageStreamSetImageFrameFlags(
            IntPtr phStreamHandle, NuiImageStreamFlags dvImageFrameFlags);
    }

    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum NuiSkeletonFlags
    {
        None = 0,
        SUPPRESS_NO_FRAME_DATA = 0x00000001,
        TITLE_SETS_TRACKED_SKELETONS = 0x00000002,
        ENABLE_SEATED_SUPPORT = 0x00000004,
        ENABLE_IN_NEAR_RANGE = 0x00000008
    }

    public enum NuiSkeletonPositionIndex : int
    {
        HipCenter = 0,
        Spine = 1,
        ShoulderCenter = 2,
        Head = 3,
        ShoulderLeft = 4,
        ElbowLeft = 5,
        WristLeft = 6,
        HandLeft = 7,
        ShoulderRight = 8,
        ElbowRight = 9,
        WristRight = 10,
        HandRight = 11,
        HipLeft = 12,
        KneeLeft = 13,
        AnkleLeft = 14,
        FootLeft = 15,
        HipRight = 16,
        KneeRight = 17,
        AnkleRight = 18,
        FootRight = 19,
        Count = 20
    }

    public struct Vector4
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public override string ToString()
        {
            return String.Format("{0:F2}, {1:F2}, {2:F2}, {3:F2}", x, y, z, w);
        }
    }

    public enum NuiSkeletonPositionTrackingState
    {
        NotTracked = 0,
        Inferred,
        Tracked
    }

    public enum NuiSkeletonTrackingState
    {
        NotTracked = 0,
        PositionOnly,
        SkeletonTracked
    }

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NuiSkeletonData
    {
        public NuiSkeletonTrackingState eTrackingState;
        public uint dwTrackingID;
        public uint dwEnrollmentIndex_NotUsed;
        public uint dwUserIndex;
        public Vector4 Position;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.Struct)]
        public Vector4[] SkeletonPositions;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.Struct)]
        public NuiSkeletonPositionTrackingState[] eSkeletonPositionTrackingState;
        public uint dwQualityFlags;
    }

    public struct NuiSkeletonFrame
    {
        public Int64 liTimeStamp;
        public uint dwFrameNumber;
        public uint dwFlags;
        public Vector4 vFloorClipPlane;
        public Vector4 vNormalToGravity;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.Struct)]
        public NuiSkeletonData[] SkeletonData;
    }

    public struct NuiTransformSmoothParameters
    {
        public float fSmoothing;
        public float fCorrection;
        public float fPrediction;
        public float fJitterRadius;
        public float fMaxDeviationRadius;
    }

    public struct Matrix4
    {
        public float _11;
        public float _12;
        public float _13;
        public float _14;
        public float _21;
        public float _22;
        public float _23;
        public float _24;
        public float _31;
        public float _32;
        public float _33;
        public float _34;
        public float _41;
        public float _42;
        public float _43;
        public float _44;
    }

    // the struct based on http://msdn.microsoft.com/en-us/library/nuiskeleton.nui_skeleton_bone_rotation.aspx
    // kinect Sdk 1.7.0, June 2013, Jason Added
    public struct NuiSkeletonBoneRotation
    {
        public Matrix4 rotationMatrix;
        public Vector4 rotationQuaternion;
    }

    // the struct based on http://msdn.microsoft.com/en-us/library/nuiskeleton.nui_skeleton_bone_orientation.aspx
    // kinect Sdk 1.7.0, June 2013, Jason Added
    public struct NuiSkeletonBoneOrientation
    {
        public NuiSkeletonPositionIndex endJoint;
        public NuiSkeletonPositionIndex startJoint;
        public NuiSkeletonBoneRotation hierarchicalRotation; // local orientation
        public NuiSkeletonBoneRotation absoluteRotation; // world orientation
    }

    public static partial class Import
    {
        [DllImport(DllPath, PreserveSig = true)]
        public static extern Int32 NuiSkeletonTrackingEnable(IntPtr hNextFrameEvent, NuiSkeletonFlags dwFlags);

        [DllImport(DllPath, PreserveSig = true)]
        public static extern Int32 NuiSkeletonGetNextFrame(
            uint dwMillisecondsToWait, ref NuiSkeletonFrame pSkeletonFrame);

        [DllImport(DllPath, PreserveSig = true)]
        public static extern Int32 NuiTransformSmooth(
            ref NuiSkeletonFrame pSkeletonFrame, ref NuiTransformSmoothParameters pSmoothingParams);

        [DllImport(DllPath, PreserveSig = true)]
        public static extern Int32 NuiSkeletonCalculateBoneOrientations(
            ref NuiSkeletonData pSkeletonData, out NuiSkeletonBoneOrientation[] orientations);
    }
}
