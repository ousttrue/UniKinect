using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UniKinect.V2
{
    // to marshal the data from NuiImageFrame to this struct
    // reference: http://msdn.microsoft.com/en-us/library/microsoft.kinect.kinect.ikinectsensor.aspx
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport, Guid("3C6EBA94-0DE1-4360-B6D4-653A10794C8B")]
    public interface IKinectSensor
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig]
        IntPtr SubscribeIsAvailableChanged();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig]
        void UnsubscribeIsAvailableChanged(
            [In]IntPtr waitableHandle);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.IUnknown)]
        Object GetIsAvailableChangedEventData( 
            [In]IntPtr waitableHandle);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig]
        void Open();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig]
        void Close();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig]
        Boolean get_IsOpen();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig]
        Boolean get_IsAvailable();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig]
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

    [Guid("57621D82-D8EE-4783-B412-F7E019C96CFD")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport()]
    public interface IColorFrameSource
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Interface)]
        IColorFrameReader OpenReader();
    }

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport, Guid("9BEA498C-C59C-4653-AAF9-D884BAB7C35B")]
    public interface IColorFrameReader
    {
    }

    public static partial class Import
    {
        const String DllPath=@"C:\Windows\System32\Kinect20.dll";

        [DllImport(DllPath, PreserveSig = false, CallingConvention=CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Interface)]
        public static extern IKinectSensor GetDefaultKinectSensor();
    }
}
