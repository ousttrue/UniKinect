// This source code was generated by regenerator"
using System;
using System.Runtime.InteropServices;

namespace KinectSDK20 {
    public class IBodyFrameArrivedEventArgs: IUnknown
    {
        static Guid s_uuid = new Guid("bf5cca0e-00c1-4d48-837f-ab921e6aee01");
        public static new ref Guid IID =>ref s_uuid;
        public override ref Guid GetIID(){ return ref s_uuid; }
                
        public virtual int get_FrameReference(
            out IBodyFrameReference bodyFrameReference
        ){
            var fp = GetFunctionPointer(3);
            if(m_get_FrameReferenceFunc==null) m_get_FrameReferenceFunc = (get_FrameReferenceFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_FrameReferenceFunc));
            bodyFrameReference = new IBodyFrameReference();
            return m_get_FrameReferenceFunc(m_ptr, out bodyFrameReference.PtrForNew);
        }
        delegate int get_FrameReferenceFunc(IntPtr self, out IntPtr bodyFrameReference);
        get_FrameReferenceFunc m_get_FrameReferenceFunc;

    }
}