// This source code was generated by regenerator"
using System;
using System.Runtime.InteropServices;

namespace KinectSDK20 {
    public class IAudioSource: IUnknown
    {
        static Guid s_uuid = new Guid("52d1d743-aed1-4e61-8af8-19ef287a662c");
        public static new ref Guid IID =>ref s_uuid;
        public override ref Guid GetIID(){ return ref s_uuid; }
                
        public virtual int SubscribeFrameCaptured(
            out long waitableHandle
        ){
            var fp = GetFunctionPointer(3);
            if(m_SubscribeFrameCapturedFunc==null) m_SubscribeFrameCapturedFunc = (SubscribeFrameCapturedFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(SubscribeFrameCapturedFunc));
            
            return m_SubscribeFrameCapturedFunc(m_ptr, out waitableHandle);
        }
        delegate int SubscribeFrameCapturedFunc(IntPtr self, out long waitableHandle);
        SubscribeFrameCapturedFunc m_SubscribeFrameCapturedFunc;

        public virtual int UnsubscribeFrameCaptured(
            long waitableHandle
        ){
            var fp = GetFunctionPointer(4);
            if(m_UnsubscribeFrameCapturedFunc==null) m_UnsubscribeFrameCapturedFunc = (UnsubscribeFrameCapturedFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(UnsubscribeFrameCapturedFunc));
            
            return m_UnsubscribeFrameCapturedFunc(m_ptr, waitableHandle);
        }
        delegate int UnsubscribeFrameCapturedFunc(IntPtr self, long waitableHandle);
        UnsubscribeFrameCapturedFunc m_UnsubscribeFrameCapturedFunc;

        public virtual int GetFrameCapturedEventData(
            long waitableHandle,
            out IFrameCapturedEventArgs eventData
        ){
            var fp = GetFunctionPointer(5);
            if(m_GetFrameCapturedEventDataFunc==null) m_GetFrameCapturedEventDataFunc = (GetFrameCapturedEventDataFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(GetFrameCapturedEventDataFunc));
            eventData = new IFrameCapturedEventArgs();
            return m_GetFrameCapturedEventDataFunc(m_ptr, waitableHandle, out eventData.PtrForNew);
        }
        delegate int GetFrameCapturedEventDataFunc(IntPtr self, long waitableHandle, out IntPtr eventData);
        GetFrameCapturedEventDataFunc m_GetFrameCapturedEventDataFunc;

        public virtual int get_KinectSensor(
            out IKinectSensor sensor
        ){
            var fp = GetFunctionPointer(6);
            if(m_get_KinectSensorFunc==null) m_get_KinectSensorFunc = (get_KinectSensorFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_KinectSensorFunc));
            sensor = new IKinectSensor();
            return m_get_KinectSensorFunc(m_ptr, out sensor.PtrForNew);
        }
        delegate int get_KinectSensorFunc(IntPtr self, out IntPtr sensor);
        get_KinectSensorFunc m_get_KinectSensorFunc;

        public virtual int get_IsActive(
            out byte isActive
        ){
            var fp = GetFunctionPointer(7);
            if(m_get_IsActiveFunc==null) m_get_IsActiveFunc = (get_IsActiveFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_IsActiveFunc));
            
            return m_get_IsActiveFunc(m_ptr, out isActive);
        }
        delegate int get_IsActiveFunc(IntPtr self, out byte isActive);
        get_IsActiveFunc m_get_IsActiveFunc;

        public virtual int get_SubFrameLengthInBytes(
            out uint length
        ){
            var fp = GetFunctionPointer(8);
            if(m_get_SubFrameLengthInBytesFunc==null) m_get_SubFrameLengthInBytesFunc = (get_SubFrameLengthInBytesFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_SubFrameLengthInBytesFunc));
            
            return m_get_SubFrameLengthInBytesFunc(m_ptr, out length);
        }
        delegate int get_SubFrameLengthInBytesFunc(IntPtr self, out uint length);
        get_SubFrameLengthInBytesFunc m_get_SubFrameLengthInBytesFunc;

        public virtual int get_SubFrameDuration(
            out long duration
        ){
            var fp = GetFunctionPointer(9);
            if(m_get_SubFrameDurationFunc==null) m_get_SubFrameDurationFunc = (get_SubFrameDurationFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_SubFrameDurationFunc));
            
            return m_get_SubFrameDurationFunc(m_ptr, out duration);
        }
        delegate int get_SubFrameDurationFunc(IntPtr self, out long duration);
        get_SubFrameDurationFunc m_get_SubFrameDurationFunc;

        public virtual int get_MaxSubFrameCount(
            out uint count
        ){
            var fp = GetFunctionPointer(10);
            if(m_get_MaxSubFrameCountFunc==null) m_get_MaxSubFrameCountFunc = (get_MaxSubFrameCountFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_MaxSubFrameCountFunc));
            
            return m_get_MaxSubFrameCountFunc(m_ptr, out count);
        }
        delegate int get_MaxSubFrameCountFunc(IntPtr self, out uint count);
        get_MaxSubFrameCountFunc m_get_MaxSubFrameCountFunc;

        public virtual int OpenReader(
            out IAudioBeamFrameReader reader
        ){
            var fp = GetFunctionPointer(11);
            if(m_OpenReaderFunc==null) m_OpenReaderFunc = (OpenReaderFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(OpenReaderFunc));
            reader = new IAudioBeamFrameReader();
            return m_OpenReaderFunc(m_ptr, out reader.PtrForNew);
        }
        delegate int OpenReaderFunc(IntPtr self, out IntPtr reader);
        OpenReaderFunc m_OpenReaderFunc;

        public virtual int get_AudioBeams(
            out IAudioBeamList audioBeamList
        ){
            var fp = GetFunctionPointer(12);
            if(m_get_AudioBeamsFunc==null) m_get_AudioBeamsFunc = (get_AudioBeamsFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_AudioBeamsFunc));
            audioBeamList = new IAudioBeamList();
            return m_get_AudioBeamsFunc(m_ptr, out audioBeamList.PtrForNew);
        }
        delegate int get_AudioBeamsFunc(IntPtr self, out IntPtr audioBeamList);
        get_AudioBeamsFunc m_get_AudioBeamsFunc;

        public virtual int get_AudioCalibrationState(
            out _KinectAudioCalibrationState audioCalibrationState
        ){
            var fp = GetFunctionPointer(13);
            if(m_get_AudioCalibrationStateFunc==null) m_get_AudioCalibrationStateFunc = (get_AudioCalibrationStateFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_AudioCalibrationStateFunc));
            
            return m_get_AudioCalibrationStateFunc(m_ptr, out audioCalibrationState);
        }
        delegate int get_AudioCalibrationStateFunc(IntPtr self, out _KinectAudioCalibrationState audioCalibrationState);
        get_AudioCalibrationStateFunc m_get_AudioCalibrationStateFunc;

    }
}
