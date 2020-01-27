// This source code was generated by regenerator"
using System;
using System.Runtime.InteropServices;

namespace KinectSDK20 {
    public class IDepthFrame: IUnknown
    {
        static Guid s_uuid = new Guid("d8600853-8835-44f9-84a7-e617cdd7dfdd");
        public static new ref Guid IID =>ref s_uuid;
        public override ref Guid GetIID(){ return ref s_uuid; }
                
        public virtual int CopyFrameDataToArray(
            uint capacity,
            out ushort frameData
        ){
            var fp = GetFunctionPointer(3);
            if(m_CopyFrameDataToArrayFunc==null) m_CopyFrameDataToArrayFunc = (CopyFrameDataToArrayFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(CopyFrameDataToArrayFunc));
            
            return m_CopyFrameDataToArrayFunc(m_ptr, capacity, out frameData);
        }
        delegate int CopyFrameDataToArrayFunc(IntPtr self, uint capacity, out ushort frameData);
        CopyFrameDataToArrayFunc m_CopyFrameDataToArrayFunc;

        public virtual int AccessUnderlyingBuffer(
            out uint capacity,
            out IntPtr buffer
        ){
            var fp = GetFunctionPointer(4);
            if(m_AccessUnderlyingBufferFunc==null) m_AccessUnderlyingBufferFunc = (AccessUnderlyingBufferFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(AccessUnderlyingBufferFunc));
            
            return m_AccessUnderlyingBufferFunc(m_ptr, out capacity, out buffer);
        }
        delegate int AccessUnderlyingBufferFunc(IntPtr self, out uint capacity, out IntPtr buffer);
        AccessUnderlyingBufferFunc m_AccessUnderlyingBufferFunc;

        public virtual int get_FrameDescription(
            out IFrameDescription frameDescription
        ){
            var fp = GetFunctionPointer(5);
            if(m_get_FrameDescriptionFunc==null) m_get_FrameDescriptionFunc = (get_FrameDescriptionFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_FrameDescriptionFunc));
            frameDescription = new IFrameDescription();
            return m_get_FrameDescriptionFunc(m_ptr, out frameDescription.PtrForNew);
        }
        delegate int get_FrameDescriptionFunc(IntPtr self, out IntPtr frameDescription);
        get_FrameDescriptionFunc m_get_FrameDescriptionFunc;

        public virtual int get_RelativeTime(
            out long relativeTime
        ){
            var fp = GetFunctionPointer(6);
            if(m_get_RelativeTimeFunc==null) m_get_RelativeTimeFunc = (get_RelativeTimeFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_RelativeTimeFunc));
            
            return m_get_RelativeTimeFunc(m_ptr, out relativeTime);
        }
        delegate int get_RelativeTimeFunc(IntPtr self, out long relativeTime);
        get_RelativeTimeFunc m_get_RelativeTimeFunc;

        public virtual int get_DepthFrameSource(
            out IDepthFrameSource depthFrameSource
        ){
            var fp = GetFunctionPointer(7);
            if(m_get_DepthFrameSourceFunc==null) m_get_DepthFrameSourceFunc = (get_DepthFrameSourceFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_DepthFrameSourceFunc));
            depthFrameSource = new IDepthFrameSource();
            return m_get_DepthFrameSourceFunc(m_ptr, out depthFrameSource.PtrForNew);
        }
        delegate int get_DepthFrameSourceFunc(IntPtr self, out IntPtr depthFrameSource);
        get_DepthFrameSourceFunc m_get_DepthFrameSourceFunc;

        public virtual int get_DepthMinReliableDistance(
            out ushort depthMinReliableDistance
        ){
            var fp = GetFunctionPointer(8);
            if(m_get_DepthMinReliableDistanceFunc==null) m_get_DepthMinReliableDistanceFunc = (get_DepthMinReliableDistanceFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_DepthMinReliableDistanceFunc));
            
            return m_get_DepthMinReliableDistanceFunc(m_ptr, out depthMinReliableDistance);
        }
        delegate int get_DepthMinReliableDistanceFunc(IntPtr self, out ushort depthMinReliableDistance);
        get_DepthMinReliableDistanceFunc m_get_DepthMinReliableDistanceFunc;

        public virtual int get_DepthMaxReliableDistance(
            out ushort depthMaxReliableDistance
        ){
            var fp = GetFunctionPointer(9);
            if(m_get_DepthMaxReliableDistanceFunc==null) m_get_DepthMaxReliableDistanceFunc = (get_DepthMaxReliableDistanceFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_DepthMaxReliableDistanceFunc));
            
            return m_get_DepthMaxReliableDistanceFunc(m_ptr, out depthMaxReliableDistance);
        }
        delegate int get_DepthMaxReliableDistanceFunc(IntPtr self, out ushort depthMaxReliableDistance);
        get_DepthMaxReliableDistanceFunc m_get_DepthMaxReliableDistanceFunc;

    }
}