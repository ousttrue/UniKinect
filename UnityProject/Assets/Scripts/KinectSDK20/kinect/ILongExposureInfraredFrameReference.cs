// This source code was generated by regenerator"
using System;
using System.Runtime.InteropServices;

namespace KinectSDK20 {
    public class ILongExposureInfraredFrameReference: IUnknown
    {
        static Guid s_uuid = new Guid("10043a3e-0daa-409c-9944-a6fc66c85af7");
        public static new ref Guid IID =>ref s_uuid;
        public override ref Guid GetIID(){ return ref s_uuid; }
                
        public virtual int AcquireFrame(
            out ILongExposureInfraredFrame longExposureInfraredFrame
        ){
            var fp = GetFunctionPointer(3);
            if(m_AcquireFrameFunc==null) m_AcquireFrameFunc = (AcquireFrameFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(AcquireFrameFunc));
            longExposureInfraredFrame = new ILongExposureInfraredFrame();
            return m_AcquireFrameFunc(m_ptr, out longExposureInfraredFrame.PtrForNew);
        }
        delegate int AcquireFrameFunc(IntPtr self, out IntPtr longExposureInfraredFrame);
        AcquireFrameFunc m_AcquireFrameFunc;

        public virtual int get_RelativeTime(
            out long relativeTime
        ){
            var fp = GetFunctionPointer(4);
            if(m_get_RelativeTimeFunc==null) m_get_RelativeTimeFunc = (get_RelativeTimeFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_RelativeTimeFunc));
            
            return m_get_RelativeTimeFunc(m_ptr, out relativeTime);
        }
        delegate int get_RelativeTimeFunc(IntPtr self, out long relativeTime);
        get_RelativeTimeFunc m_get_RelativeTimeFunc;

    }
}
