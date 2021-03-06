// This source code was generated by regenerator"
using System;
using System.Runtime.InteropServices;

namespace KinectSDK20 {
    public class IKinectGestureRecognizer: IUnknown
    {
        static Guid s_uuid = new Guid("5f51a3c4-2400-4f6d-8a6c-25b96715eff1");
        public static new ref Guid IID =>ref s_uuid;
        public override ref Guid GetIID(){ return ref s_uuid; }
                
        public virtual int RegisterSelectionTappedHandler(
            IKinectGestureRecognizerSelectionHandler handler
        ){
            var fp = GetFunctionPointer(3);
            if(m_RegisterSelectionTappedHandlerFunc==null) m_RegisterSelectionTappedHandlerFunc = (RegisterSelectionTappedHandlerFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(RegisterSelectionTappedHandlerFunc));
            
            return m_RegisterSelectionTappedHandlerFunc(m_ptr, handler!=null ? handler.Ptr : IntPtr.Zero);
        }
        delegate int RegisterSelectionTappedHandlerFunc(IntPtr self, IntPtr handler);
        RegisterSelectionTappedHandlerFunc m_RegisterSelectionTappedHandlerFunc;

        public virtual int UnregisterSelectionTappedHandler(
        ){
            var fp = GetFunctionPointer(4);
            if(m_UnregisterSelectionTappedHandlerFunc==null) m_UnregisterSelectionTappedHandlerFunc = (UnregisterSelectionTappedHandlerFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(UnregisterSelectionTappedHandlerFunc));
            
            return m_UnregisterSelectionTappedHandlerFunc(m_ptr);
        }
        delegate int UnregisterSelectionTappedHandlerFunc(IntPtr self);
        UnregisterSelectionTappedHandlerFunc m_UnregisterSelectionTappedHandlerFunc;

        public virtual int RegisterSelectionHoldingHandler(
            IKinectGestureRecognizerSelectionHandler handler
        ){
            var fp = GetFunctionPointer(5);
            if(m_RegisterSelectionHoldingHandlerFunc==null) m_RegisterSelectionHoldingHandlerFunc = (RegisterSelectionHoldingHandlerFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(RegisterSelectionHoldingHandlerFunc));
            
            return m_RegisterSelectionHoldingHandlerFunc(m_ptr, handler!=null ? handler.Ptr : IntPtr.Zero);
        }
        delegate int RegisterSelectionHoldingHandlerFunc(IntPtr self, IntPtr handler);
        RegisterSelectionHoldingHandlerFunc m_RegisterSelectionHoldingHandlerFunc;

        public virtual int UnregisterSelectionHoldingHandler(
        ){
            var fp = GetFunctionPointer(6);
            if(m_UnregisterSelectionHoldingHandlerFunc==null) m_UnregisterSelectionHoldingHandlerFunc = (UnregisterSelectionHoldingHandlerFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(UnregisterSelectionHoldingHandlerFunc));
            
            return m_UnregisterSelectionHoldingHandlerFunc(m_ptr);
        }
        delegate int UnregisterSelectionHoldingHandlerFunc(IntPtr self);
        UnregisterSelectionHoldingHandlerFunc m_UnregisterSelectionHoldingHandlerFunc;

        public virtual int RegisterSelectionPressingStartedHandler(
            IKinectGestureRecognizerSelectionHandler handler
        ){
            var fp = GetFunctionPointer(7);
            if(m_RegisterSelectionPressingStartedHandlerFunc==null) m_RegisterSelectionPressingStartedHandlerFunc = (RegisterSelectionPressingStartedHandlerFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(RegisterSelectionPressingStartedHandlerFunc));
            
            return m_RegisterSelectionPressingStartedHandlerFunc(m_ptr, handler!=null ? handler.Ptr : IntPtr.Zero);
        }
        delegate int RegisterSelectionPressingStartedHandlerFunc(IntPtr self, IntPtr handler);
        RegisterSelectionPressingStartedHandlerFunc m_RegisterSelectionPressingStartedHandlerFunc;

        public virtual int UnregisterSelectionPressingStartedHandler(
        ){
            var fp = GetFunctionPointer(8);
            if(m_UnregisterSelectionPressingStartedHandlerFunc==null) m_UnregisterSelectionPressingStartedHandlerFunc = (UnregisterSelectionPressingStartedHandlerFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(UnregisterSelectionPressingStartedHandlerFunc));
            
            return m_UnregisterSelectionPressingStartedHandlerFunc(m_ptr);
        }
        delegate int UnregisterSelectionPressingStartedHandlerFunc(IntPtr self);
        UnregisterSelectionPressingStartedHandlerFunc m_UnregisterSelectionPressingStartedHandlerFunc;

        public virtual int RegisterSelectionPressingUpdatedHandler(
            IKinectGestureRecognizerSelectionHandler handler
        ){
            var fp = GetFunctionPointer(9);
            if(m_RegisterSelectionPressingUpdatedHandlerFunc==null) m_RegisterSelectionPressingUpdatedHandlerFunc = (RegisterSelectionPressingUpdatedHandlerFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(RegisterSelectionPressingUpdatedHandlerFunc));
            
            return m_RegisterSelectionPressingUpdatedHandlerFunc(m_ptr, handler!=null ? handler.Ptr : IntPtr.Zero);
        }
        delegate int RegisterSelectionPressingUpdatedHandlerFunc(IntPtr self, IntPtr handler);
        RegisterSelectionPressingUpdatedHandlerFunc m_RegisterSelectionPressingUpdatedHandlerFunc;

        public virtual int UnregisterSelectionPressingUpdatedHandler(
        ){
            var fp = GetFunctionPointer(10);
            if(m_UnregisterSelectionPressingUpdatedHandlerFunc==null) m_UnregisterSelectionPressingUpdatedHandlerFunc = (UnregisterSelectionPressingUpdatedHandlerFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(UnregisterSelectionPressingUpdatedHandlerFunc));
            
            return m_UnregisterSelectionPressingUpdatedHandlerFunc(m_ptr);
        }
        delegate int UnregisterSelectionPressingUpdatedHandlerFunc(IntPtr self);
        UnregisterSelectionPressingUpdatedHandlerFunc m_UnregisterSelectionPressingUpdatedHandlerFunc;

        public virtual int RegisterSelectionPressingCompletedHandler(
            IKinectGestureRecognizerSelectionHandler handler
        ){
            var fp = GetFunctionPointer(11);
            if(m_RegisterSelectionPressingCompletedHandlerFunc==null) m_RegisterSelectionPressingCompletedHandlerFunc = (RegisterSelectionPressingCompletedHandlerFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(RegisterSelectionPressingCompletedHandlerFunc));
            
            return m_RegisterSelectionPressingCompletedHandlerFunc(m_ptr, handler!=null ? handler.Ptr : IntPtr.Zero);
        }
        delegate int RegisterSelectionPressingCompletedHandlerFunc(IntPtr self, IntPtr handler);
        RegisterSelectionPressingCompletedHandlerFunc m_RegisterSelectionPressingCompletedHandlerFunc;

        public virtual int UnregisterSelectionPressingCompletedHandler(
        ){
            var fp = GetFunctionPointer(12);
            if(m_UnregisterSelectionPressingCompletedHandlerFunc==null) m_UnregisterSelectionPressingCompletedHandlerFunc = (UnregisterSelectionPressingCompletedHandlerFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(UnregisterSelectionPressingCompletedHandlerFunc));
            
            return m_UnregisterSelectionPressingCompletedHandlerFunc(m_ptr);
        }
        delegate int UnregisterSelectionPressingCompletedHandlerFunc(IntPtr self);
        UnregisterSelectionPressingCompletedHandlerFunc m_UnregisterSelectionPressingCompletedHandlerFunc;

        public virtual int RegisterManipulationStartedHandler(
            IKinectGestureRecognizerManipulationHandler handler
        ){
            var fp = GetFunctionPointer(13);
            if(m_RegisterManipulationStartedHandlerFunc==null) m_RegisterManipulationStartedHandlerFunc = (RegisterManipulationStartedHandlerFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(RegisterManipulationStartedHandlerFunc));
            
            return m_RegisterManipulationStartedHandlerFunc(m_ptr, handler!=null ? handler.Ptr : IntPtr.Zero);
        }
        delegate int RegisterManipulationStartedHandlerFunc(IntPtr self, IntPtr handler);
        RegisterManipulationStartedHandlerFunc m_RegisterManipulationStartedHandlerFunc;

        public virtual int UnregisterManipulationStartedHandler(
        ){
            var fp = GetFunctionPointer(14);
            if(m_UnregisterManipulationStartedHandlerFunc==null) m_UnregisterManipulationStartedHandlerFunc = (UnregisterManipulationStartedHandlerFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(UnregisterManipulationStartedHandlerFunc));
            
            return m_UnregisterManipulationStartedHandlerFunc(m_ptr);
        }
        delegate int UnregisterManipulationStartedHandlerFunc(IntPtr self);
        UnregisterManipulationStartedHandlerFunc m_UnregisterManipulationStartedHandlerFunc;

        public virtual int RegisterManipulationUpdatedHandler(
            IKinectGestureRecognizerManipulationHandler handler
        ){
            var fp = GetFunctionPointer(15);
            if(m_RegisterManipulationUpdatedHandlerFunc==null) m_RegisterManipulationUpdatedHandlerFunc = (RegisterManipulationUpdatedHandlerFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(RegisterManipulationUpdatedHandlerFunc));
            
            return m_RegisterManipulationUpdatedHandlerFunc(m_ptr, handler!=null ? handler.Ptr : IntPtr.Zero);
        }
        delegate int RegisterManipulationUpdatedHandlerFunc(IntPtr self, IntPtr handler);
        RegisterManipulationUpdatedHandlerFunc m_RegisterManipulationUpdatedHandlerFunc;

        public virtual int UnregisterManipulationUpdatedHandler(
        ){
            var fp = GetFunctionPointer(16);
            if(m_UnregisterManipulationUpdatedHandlerFunc==null) m_UnregisterManipulationUpdatedHandlerFunc = (UnregisterManipulationUpdatedHandlerFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(UnregisterManipulationUpdatedHandlerFunc));
            
            return m_UnregisterManipulationUpdatedHandlerFunc(m_ptr);
        }
        delegate int UnregisterManipulationUpdatedHandlerFunc(IntPtr self);
        UnregisterManipulationUpdatedHandlerFunc m_UnregisterManipulationUpdatedHandlerFunc;

        public virtual int RegisterManipulationInertiaStartingHandler(
            IKinectGestureRecognizerManipulationHandler handler
        ){
            var fp = GetFunctionPointer(17);
            if(m_RegisterManipulationInertiaStartingHandlerFunc==null) m_RegisterManipulationInertiaStartingHandlerFunc = (RegisterManipulationInertiaStartingHandlerFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(RegisterManipulationInertiaStartingHandlerFunc));
            
            return m_RegisterManipulationInertiaStartingHandlerFunc(m_ptr, handler!=null ? handler.Ptr : IntPtr.Zero);
        }
        delegate int RegisterManipulationInertiaStartingHandlerFunc(IntPtr self, IntPtr handler);
        RegisterManipulationInertiaStartingHandlerFunc m_RegisterManipulationInertiaStartingHandlerFunc;

        public virtual int UnregisterManipulationInertiaStartingHandler(
        ){
            var fp = GetFunctionPointer(18);
            if(m_UnregisterManipulationInertiaStartingHandlerFunc==null) m_UnregisterManipulationInertiaStartingHandlerFunc = (UnregisterManipulationInertiaStartingHandlerFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(UnregisterManipulationInertiaStartingHandlerFunc));
            
            return m_UnregisterManipulationInertiaStartingHandlerFunc(m_ptr);
        }
        delegate int UnregisterManipulationInertiaStartingHandlerFunc(IntPtr self);
        UnregisterManipulationInertiaStartingHandlerFunc m_UnregisterManipulationInertiaStartingHandlerFunc;

        public virtual int RegisterManipulationCompletedHandler(
            IKinectGestureRecognizerManipulationHandler handler
        ){
            var fp = GetFunctionPointer(19);
            if(m_RegisterManipulationCompletedHandlerFunc==null) m_RegisterManipulationCompletedHandlerFunc = (RegisterManipulationCompletedHandlerFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(RegisterManipulationCompletedHandlerFunc));
            
            return m_RegisterManipulationCompletedHandlerFunc(m_ptr, handler!=null ? handler.Ptr : IntPtr.Zero);
        }
        delegate int RegisterManipulationCompletedHandlerFunc(IntPtr self, IntPtr handler);
        RegisterManipulationCompletedHandlerFunc m_RegisterManipulationCompletedHandlerFunc;

        public virtual int UnregisterManipulationCompletedHandler(
        ){
            var fp = GetFunctionPointer(20);
            if(m_UnregisterManipulationCompletedHandlerFunc==null) m_UnregisterManipulationCompletedHandlerFunc = (UnregisterManipulationCompletedHandlerFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(UnregisterManipulationCompletedHandlerFunc));
            
            return m_UnregisterManipulationCompletedHandlerFunc(m_ptr);
        }
        delegate int UnregisterManipulationCompletedHandlerFunc(IntPtr self);
        UnregisterManipulationCompletedHandlerFunc m_UnregisterManipulationCompletedHandlerFunc;

        public virtual int get_GestureSettings(
            out _KinectGestureSettings value
        ){
            var fp = GetFunctionPointer(21);
            if(m_get_GestureSettingsFunc==null) m_get_GestureSettingsFunc = (get_GestureSettingsFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_GestureSettingsFunc));
            
            return m_get_GestureSettingsFunc(m_ptr, out value);
        }
        delegate int get_GestureSettingsFunc(IntPtr self, out _KinectGestureSettings value);
        get_GestureSettingsFunc m_get_GestureSettingsFunc;

        public virtual int put_GestureSettings(
            _KinectGestureSettings value
        ){
            var fp = GetFunctionPointer(22);
            if(m_put_GestureSettingsFunc==null) m_put_GestureSettingsFunc = (put_GestureSettingsFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(put_GestureSettingsFunc));
            
            return m_put_GestureSettingsFunc(m_ptr, value);
        }
        delegate int put_GestureSettingsFunc(IntPtr self, _KinectGestureSettings value);
        put_GestureSettingsFunc m_put_GestureSettingsFunc;

        public virtual int get_IsInertial(
            out byte value
        ){
            var fp = GetFunctionPointer(23);
            if(m_get_IsInertialFunc==null) m_get_IsInertialFunc = (get_IsInertialFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_IsInertialFunc));
            
            return m_get_IsInertialFunc(m_ptr, out value);
        }
        delegate int get_IsInertialFunc(IntPtr self, out byte value);
        get_IsInertialFunc m_get_IsInertialFunc;

        public virtual int get_IsActive(
            out byte value
        ){
            var fp = GetFunctionPointer(24);
            if(m_get_IsActiveFunc==null) m_get_IsActiveFunc = (get_IsActiveFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_IsActiveFunc));
            
            return m_get_IsActiveFunc(m_ptr, out value);
        }
        delegate int get_IsActiveFunc(IntPtr self, out byte value);
        get_IsActiveFunc m_get_IsActiveFunc;

        public virtual int get_InertiaTranslationDeceleration(
            out float value
        ){
            var fp = GetFunctionPointer(25);
            if(m_get_InertiaTranslationDecelerationFunc==null) m_get_InertiaTranslationDecelerationFunc = (get_InertiaTranslationDecelerationFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_InertiaTranslationDecelerationFunc));
            
            return m_get_InertiaTranslationDecelerationFunc(m_ptr, out value);
        }
        delegate int get_InertiaTranslationDecelerationFunc(IntPtr self, out float value);
        get_InertiaTranslationDecelerationFunc m_get_InertiaTranslationDecelerationFunc;

        public virtual int put_InertiaTranslationDeceleration(
            float value
        ){
            var fp = GetFunctionPointer(26);
            if(m_put_InertiaTranslationDecelerationFunc==null) m_put_InertiaTranslationDecelerationFunc = (put_InertiaTranslationDecelerationFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(put_InertiaTranslationDecelerationFunc));
            
            return m_put_InertiaTranslationDecelerationFunc(m_ptr, value);
        }
        delegate int put_InertiaTranslationDecelerationFunc(IntPtr self, float value);
        put_InertiaTranslationDecelerationFunc m_put_InertiaTranslationDecelerationFunc;

        public virtual int get_InertiaTranslationDisplacement(
            out float value
        ){
            var fp = GetFunctionPointer(27);
            if(m_get_InertiaTranslationDisplacementFunc==null) m_get_InertiaTranslationDisplacementFunc = (get_InertiaTranslationDisplacementFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_InertiaTranslationDisplacementFunc));
            
            return m_get_InertiaTranslationDisplacementFunc(m_ptr, out value);
        }
        delegate int get_InertiaTranslationDisplacementFunc(IntPtr self, out float value);
        get_InertiaTranslationDisplacementFunc m_get_InertiaTranslationDisplacementFunc;

        public virtual int put_InertiaTranslationDisplacement(
            float value
        ){
            var fp = GetFunctionPointer(28);
            if(m_put_InertiaTranslationDisplacementFunc==null) m_put_InertiaTranslationDisplacementFunc = (put_InertiaTranslationDisplacementFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(put_InertiaTranslationDisplacementFunc));
            
            return m_put_InertiaTranslationDisplacementFunc(m_ptr, value);
        }
        delegate int put_InertiaTranslationDisplacementFunc(IntPtr self, float value);
        put_InertiaTranslationDisplacementFunc m_put_InertiaTranslationDisplacementFunc;

        public virtual int get_AutoProcessInertia(
            out byte value
        ){
            var fp = GetFunctionPointer(29);
            if(m_get_AutoProcessInertiaFunc==null) m_get_AutoProcessInertiaFunc = (get_AutoProcessInertiaFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_AutoProcessInertiaFunc));
            
            return m_get_AutoProcessInertiaFunc(m_ptr, out value);
        }
        delegate int get_AutoProcessInertiaFunc(IntPtr self, out byte value);
        get_AutoProcessInertiaFunc m_get_AutoProcessInertiaFunc;

        public virtual int put_AutoProcessInertia(
            byte value
        ){
            var fp = GetFunctionPointer(30);
            if(m_put_AutoProcessInertiaFunc==null) m_put_AutoProcessInertiaFunc = (put_AutoProcessInertiaFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(put_AutoProcessInertiaFunc));
            
            return m_put_AutoProcessInertiaFunc(m_ptr, value);
        }
        delegate int put_AutoProcessInertiaFunc(IntPtr self, byte value);
        put_AutoProcessInertiaFunc m_put_AutoProcessInertiaFunc;

        public virtual int get_BoundingRect(
            out _RectF value
        ){
            var fp = GetFunctionPointer(31);
            if(m_get_BoundingRectFunc==null) m_get_BoundingRectFunc = (get_BoundingRectFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_BoundingRectFunc));
            
            return m_get_BoundingRectFunc(m_ptr, out value);
        }
        delegate int get_BoundingRectFunc(IntPtr self, out _RectF value);
        get_BoundingRectFunc m_get_BoundingRectFunc;

        public virtual int put_BoundingRect(
            _RectF value
        ){
            var fp = GetFunctionPointer(32);
            if(m_put_BoundingRectFunc==null) m_put_BoundingRectFunc = (put_BoundingRectFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(put_BoundingRectFunc));
            
            return m_put_BoundingRectFunc(m_ptr, value);
        }
        delegate int put_BoundingRectFunc(IntPtr self, _RectF value);
        put_BoundingRectFunc m_put_BoundingRectFunc;

        public virtual int ProcessDownEvent(
            IKinectPointerPoint value
        ){
            var fp = GetFunctionPointer(33);
            if(m_ProcessDownEventFunc==null) m_ProcessDownEventFunc = (ProcessDownEventFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(ProcessDownEventFunc));
            
            return m_ProcessDownEventFunc(m_ptr, value!=null ? value.Ptr : IntPtr.Zero);
        }
        delegate int ProcessDownEventFunc(IntPtr self, IntPtr value);
        ProcessDownEventFunc m_ProcessDownEventFunc;

        public virtual int ProcessUpEvent(
            IKinectPointerPoint value
        ){
            var fp = GetFunctionPointer(34);
            if(m_ProcessUpEventFunc==null) m_ProcessUpEventFunc = (ProcessUpEventFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(ProcessUpEventFunc));
            
            return m_ProcessUpEventFunc(m_ptr, value!=null ? value.Ptr : IntPtr.Zero);
        }
        delegate int ProcessUpEventFunc(IntPtr self, IntPtr value);
        ProcessUpEventFunc m_ProcessUpEventFunc;

        public virtual int ProcessMoveEvents(
            IKinectPointerPoint value
        ){
            var fp = GetFunctionPointer(35);
            if(m_ProcessMoveEventsFunc==null) m_ProcessMoveEventsFunc = (ProcessMoveEventsFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(ProcessMoveEventsFunc));
            
            return m_ProcessMoveEventsFunc(m_ptr, value!=null ? value.Ptr : IntPtr.Zero);
        }
        delegate int ProcessMoveEventsFunc(IntPtr self, IntPtr value);
        ProcessMoveEventsFunc m_ProcessMoveEventsFunc;

        public virtual int ProcessInertia(
        ){
            var fp = GetFunctionPointer(36);
            if(m_ProcessInertiaFunc==null) m_ProcessInertiaFunc = (ProcessInertiaFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(ProcessInertiaFunc));
            
            return m_ProcessInertiaFunc(m_ptr);
        }
        delegate int ProcessInertiaFunc(IntPtr self);
        ProcessInertiaFunc m_ProcessInertiaFunc;

        public virtual int CompleteGesture(
        ){
            var fp = GetFunctionPointer(37);
            if(m_CompleteGestureFunc==null) m_CompleteGestureFunc = (CompleteGestureFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(CompleteGestureFunc));
            
            return m_CompleteGestureFunc(m_ptr);
        }
        delegate int CompleteGestureFunc(IntPtr self);
        CompleteGestureFunc m_CompleteGestureFunc;

    }
}
