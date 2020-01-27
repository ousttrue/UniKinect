// This source code was generated by regenerator"
using System;
using System.Runtime.InteropServices;

namespace KinectSDK20 {
    public class IColorFrameArrivedEventArgs: IUnknown
    {
        static Guid s_uuid = new Guid("82a2e32f-4ae5-4614-88bb-dcc5ae0ceaed");
        public static new ref Guid IID =>ref s_uuid;
        public override ref Guid GetIID(){ return ref s_uuid; }
                
        public virtual int get_FrameReference(
            out IColorFrameReference colorFrameReference
        ){
            var fp = GetFunctionPointer(3);
            if(m_get_FrameReferenceFunc==null) m_get_FrameReferenceFunc = (get_FrameReferenceFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_FrameReferenceFunc));
            colorFrameReference = new IColorFrameReference();
            return m_get_FrameReferenceFunc(m_ptr, out colorFrameReference.PtrForNew);
        }
        delegate int get_FrameReferenceFunc(IntPtr self, out IntPtr colorFrameReference);
        get_FrameReferenceFunc m_get_FrameReferenceFunc;

    }
}