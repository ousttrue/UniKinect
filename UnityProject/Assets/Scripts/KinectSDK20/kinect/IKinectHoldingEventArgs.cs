// This source code was generated by regenerator"
using System;
using System.Runtime.InteropServices;

namespace KinectSDK20 {
    public class IKinectHoldingEventArgs: IUnknown
    {
        static Guid s_uuid = new Guid("a7b4b8f4-55b5-4fb2-b7c4-83b7700748df");
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

        public virtual int get_Position(
            out _PointF value
        ){
            var fp = GetFunctionPointer(4);
            if(m_get_PositionFunc==null) m_get_PositionFunc = (get_PositionFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_PositionFunc));
            
            return m_get_PositionFunc(m_ptr, out value);
        }
        delegate int get_PositionFunc(IntPtr self, out _PointF value);
        get_PositionFunc m_get_PositionFunc;

        public virtual int get_HoldingState(
            out _KinectHoldingState value
        ){
            var fp = GetFunctionPointer(5);
            if(m_get_HoldingStateFunc==null) m_get_HoldingStateFunc = (get_HoldingStateFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_HoldingStateFunc));
            
            return m_get_HoldingStateFunc(m_ptr, out value);
        }
        delegate int get_HoldingStateFunc(IntPtr self, out _KinectHoldingState value);
        get_HoldingStateFunc m_get_HoldingStateFunc;

    }
}
