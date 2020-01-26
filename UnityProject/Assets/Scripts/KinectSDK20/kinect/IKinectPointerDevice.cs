// This source code was generated by regenerator"
using System;
using System.Runtime.InteropServices;

namespace KinectSDK20 {
    public class IKinectPointerDevice: IUnknown
    {
        static Guid s_uuid = new Guid("c6f3a13d-16da-4556-ad25-c4cd73a2d625");
        public static new ref Guid IID =>ref s_uuid;
        public override ref Guid GetIID(){ return ref s_uuid; }
                
        public virtual int get_PointerDeviceType(
            out _PointerDeviceType value
        ){
            var fp = GetFunctionPointer(3);
            if(m_get_PointerDeviceTypeFunc==null) m_get_PointerDeviceTypeFunc = (get_PointerDeviceTypeFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_PointerDeviceTypeFunc));
            
            return m_get_PointerDeviceTypeFunc(m_ptr, out value);
        }
        delegate int get_PointerDeviceTypeFunc(IntPtr self, out _PointerDeviceType value);
        get_PointerDeviceTypeFunc m_get_PointerDeviceTypeFunc;

    }
}
