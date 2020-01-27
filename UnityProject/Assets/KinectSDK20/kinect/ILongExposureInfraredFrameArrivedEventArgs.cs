// This source code was generated by regenerator"
using System;
using System.Runtime.InteropServices;

namespace KinectSDK20 {
    public class ILongExposureInfraredFrameArrivedEventArgs: IUnknown
    {
        static Guid s_uuid = new Guid("d73d4b5e-e329-4f04-894c-0c97482690d4");
        public static new ref Guid IID =>ref s_uuid;
        public override ref Guid GetIID(){ return ref s_uuid; }
                
        public virtual int get_FrameReference(
            out ILongExposureInfraredFrameReference longExposureInfraredFrameReference
        ){
            var fp = GetFunctionPointer(3);
            if(m_get_FrameReferenceFunc==null) m_get_FrameReferenceFunc = (get_FrameReferenceFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_FrameReferenceFunc));
            longExposureInfraredFrameReference = new ILongExposureInfraredFrameReference();
            return m_get_FrameReferenceFunc(m_ptr, out longExposureInfraredFrameReference.PtrForNew);
        }
        delegate int get_FrameReferenceFunc(IntPtr self, out IntPtr longExposureInfraredFrameReference);
        get_FrameReferenceFunc m_get_FrameReferenceFunc;

    }
}