using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
        
#if false
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_DepthFrameSource( 
            /* [annotation][out][retval] */ 
            _COM_Outptr_  IDepthFrameSource **depthFrameSource) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_BodyFrameSource( 
            /* [annotation][out][retval] */ 
            _COM_Outptr_  IBodyFrameSource **bodyFrameSource) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_BodyIndexFrameSource( 
            /* [annotation][out][retval] */ 
            _COM_Outptr_  IBodyIndexFrameSource **bodyIndexFrameSource) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_InfraredFrameSource( 
            /* [annotation][out][retval] */ 
            _COM_Outptr_  IInfraredFrameSource **infraredFrameSource) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_LongExposureInfraredFrameSource( 
            /* [annotation][out][retval] */ 
            _COM_Outptr_  ILongExposureInfraredFrameSource **longExposureInfraredFrameSource) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_AudioSource( 
            /* [annotation][out][retval] */ 
            _COM_Outptr_  IAudioSource **audioSource) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE OpenMultiSourceFrameReader( 
            DWORD enabledFrameSourceTypes,
            /* [annotation][out][retval] */ 
            _COM_Outptr_  IMultiSourceFrameReader **multiSourceFrameReader) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_CoordinateMapper( 
            /* [annotation][out][retval] */ 
            _COM_Outptr_  ICoordinateMapper **coordinateMapper) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_UniqueKinectId( 
            UINT bufferSize,
            /* [annotation][out][retval] */ 
            _Out_writes_z_(bufferSize)  WCHAR *uniqueKinectId) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_KinectCapabilities( 
            /* [annotation][out][retval] */ 
            _Out_  DWORD *capabilities) = 0;
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

    [Guid("57621D82-D8EE-4783-B412-F7E019C96CFD")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport()]
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
        [return: MarshalAs(UnmanagedType.IUnknown)]
        Object get_FrameDescription();
        
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
        [return: MarshalAs(UnmanagedType.IUnknown)]
        Object GetFrameArrivedEventData(IntPtr waitableHandle);
        
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
        IntPtr AccessRawUnderlyingBuffer(out Int32 capacity);
        
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

    public static partial class Import
    {
        const String DllPath=@"C:\Windows\System32\Kinect20.dll";

        [DllImport(DllPath, PreserveSig = false, CallingConvention=CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Interface)]
        public static extern IKinectSensor GetDefaultKinectSensor();
    }
}
