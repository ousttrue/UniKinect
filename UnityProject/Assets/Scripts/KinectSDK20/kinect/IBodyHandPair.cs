// This source code was generated by regenerator"
using System;
using System.Runtime.InteropServices;

namespace KinectSDK20 {
    public class IBodyHandPair: IUnknown
    {
        static Guid s_uuid = new Guid("3f0c2e40-e9dc-4178-a8f5-5600e059c84c");
        public static new ref Guid IID =>ref s_uuid;
        public override ref Guid GetIID(){ return ref s_uuid; }
                
        public virtual int get_BodyTrackingId(
            out ulong value
        ){
            var fp = GetFunctionPointer(3);
            if(m_get_BodyTrackingIdFunc==null) m_get_BodyTrackingIdFunc = (get_BodyTrackingIdFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_BodyTrackingIdFunc));
            
            return m_get_BodyTrackingIdFunc(m_ptr, out value);
        }
        delegate int get_BodyTrackingIdFunc(IntPtr self, out ulong value);
        get_BodyTrackingIdFunc m_get_BodyTrackingIdFunc;

        public virtual int put_BodyTrackingId(
            ulong value
        ){
            var fp = GetFunctionPointer(4);
            if(m_put_BodyTrackingIdFunc==null) m_put_BodyTrackingIdFunc = (put_BodyTrackingIdFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(put_BodyTrackingIdFunc));
            
            return m_put_BodyTrackingIdFunc(m_ptr, value);
        }
        delegate int put_BodyTrackingIdFunc(IntPtr self, ulong value);
        put_BodyTrackingIdFunc m_put_BodyTrackingIdFunc;

        public virtual int get_HandType(
            out _HandType value
        ){
            var fp = GetFunctionPointer(5);
            if(m_get_HandTypeFunc==null) m_get_HandTypeFunc = (get_HandTypeFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_HandTypeFunc));
            
            return m_get_HandTypeFunc(m_ptr, out value);
        }
        delegate int get_HandTypeFunc(IntPtr self, out _HandType value);
        get_HandTypeFunc m_get_HandTypeFunc;

        public virtual int put_HandType(
            _HandType value
        ){
            var fp = GetFunctionPointer(6);
            if(m_put_HandTypeFunc==null) m_put_HandTypeFunc = (put_HandTypeFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(put_HandTypeFunc));
            
            return m_put_HandTypeFunc(m_ptr, value);
        }
        delegate int put_HandTypeFunc(IntPtr self, _HandType value);
        put_HandTypeFunc m_put_HandTypeFunc;

    }
}
