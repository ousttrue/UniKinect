// This source code was generated by regenerator"
using System;
using System.Runtime.InteropServices;

namespace KinectSDK20 {
    public class IAudioBeamSubFrame: IUnknown
    {
        static Guid s_uuid = new Guid("0967db97-80d1-4bc5-bd2b-4685098d9795");
        public static new ref Guid IID =>ref s_uuid;
        public override ref Guid GetIID(){ return ref s_uuid; }
                
        public virtual int get_FrameLengthInBytes(
            out uint length
        ){
            var fp = GetFunctionPointer(3);
            if(m_get_FrameLengthInBytesFunc==null) m_get_FrameLengthInBytesFunc = (get_FrameLengthInBytesFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_FrameLengthInBytesFunc));
            
            return m_get_FrameLengthInBytesFunc(m_ptr, out length);
        }
        delegate int get_FrameLengthInBytesFunc(IntPtr self, out uint length);
        get_FrameLengthInBytesFunc m_get_FrameLengthInBytesFunc;

        public virtual int get_Duration(
            out long duration
        ){
            var fp = GetFunctionPointer(4);
            if(m_get_DurationFunc==null) m_get_DurationFunc = (get_DurationFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_DurationFunc));
            
            return m_get_DurationFunc(m_ptr, out duration);
        }
        delegate int get_DurationFunc(IntPtr self, out long duration);
        get_DurationFunc m_get_DurationFunc;

        public virtual int get_BeamAngle(
            out float beamAngle
        ){
            var fp = GetFunctionPointer(5);
            if(m_get_BeamAngleFunc==null) m_get_BeamAngleFunc = (get_BeamAngleFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_BeamAngleFunc));
            
            return m_get_BeamAngleFunc(m_ptr, out beamAngle);
        }
        delegate int get_BeamAngleFunc(IntPtr self, out float beamAngle);
        get_BeamAngleFunc m_get_BeamAngleFunc;

        public virtual int get_BeamAngleConfidence(
            out float beamAngleConfidence
        ){
            var fp = GetFunctionPointer(6);
            if(m_get_BeamAngleConfidenceFunc==null) m_get_BeamAngleConfidenceFunc = (get_BeamAngleConfidenceFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_BeamAngleConfidenceFunc));
            
            return m_get_BeamAngleConfidenceFunc(m_ptr, out beamAngleConfidence);
        }
        delegate int get_BeamAngleConfidenceFunc(IntPtr self, out float beamAngleConfidence);
        get_BeamAngleConfidenceFunc m_get_BeamAngleConfidenceFunc;

        public virtual int get_AudioBeamMode(
            out _AudioBeamMode audioBeamMode
        ){
            var fp = GetFunctionPointer(7);
            if(m_get_AudioBeamModeFunc==null) m_get_AudioBeamModeFunc = (get_AudioBeamModeFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_AudioBeamModeFunc));
            
            return m_get_AudioBeamModeFunc(m_ptr, out audioBeamMode);
        }
        delegate int get_AudioBeamModeFunc(IntPtr self, out _AudioBeamMode audioBeamMode);
        get_AudioBeamModeFunc m_get_AudioBeamModeFunc;

        public virtual int get_AudioBodyCorrelationCount(
            out uint pCount
        ){
            var fp = GetFunctionPointer(8);
            if(m_get_AudioBodyCorrelationCountFunc==null) m_get_AudioBodyCorrelationCountFunc = (get_AudioBodyCorrelationCountFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_AudioBodyCorrelationCountFunc));
            
            return m_get_AudioBodyCorrelationCountFunc(m_ptr, out pCount);
        }
        delegate int get_AudioBodyCorrelationCountFunc(IntPtr self, out uint pCount);
        get_AudioBodyCorrelationCountFunc m_get_AudioBodyCorrelationCountFunc;

        public virtual int GetAudioBodyCorrelation(
            uint index,
            out IAudioBodyCorrelation ppAudioBodyCorrelation
        ){
            var fp = GetFunctionPointer(9);
            if(m_GetAudioBodyCorrelationFunc==null) m_GetAudioBodyCorrelationFunc = (GetAudioBodyCorrelationFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(GetAudioBodyCorrelationFunc));
            ppAudioBodyCorrelation = new IAudioBodyCorrelation();
            return m_GetAudioBodyCorrelationFunc(m_ptr, index, out ppAudioBodyCorrelation.PtrForNew);
        }
        delegate int GetAudioBodyCorrelationFunc(IntPtr self, uint index, out IntPtr ppAudioBodyCorrelation);
        GetAudioBodyCorrelationFunc m_GetAudioBodyCorrelationFunc;

        public virtual int CopyFrameDataToArray(
            uint capacity,
            out byte frameData
        ){
            var fp = GetFunctionPointer(10);
            if(m_CopyFrameDataToArrayFunc==null) m_CopyFrameDataToArrayFunc = (CopyFrameDataToArrayFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(CopyFrameDataToArrayFunc));
            
            return m_CopyFrameDataToArrayFunc(m_ptr, capacity, out frameData);
        }
        delegate int CopyFrameDataToArrayFunc(IntPtr self, uint capacity, out byte frameData);
        CopyFrameDataToArrayFunc m_CopyFrameDataToArrayFunc;

        public virtual int AccessUnderlyingBuffer(
            out uint capacity,
            out IntPtr buffer
        ){
            var fp = GetFunctionPointer(11);
            if(m_AccessUnderlyingBufferFunc==null) m_AccessUnderlyingBufferFunc = (AccessUnderlyingBufferFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(AccessUnderlyingBufferFunc));
            
            return m_AccessUnderlyingBufferFunc(m_ptr, out capacity, out buffer);
        }
        delegate int AccessUnderlyingBufferFunc(IntPtr self, out uint capacity, out IntPtr buffer);
        AccessUnderlyingBufferFunc m_AccessUnderlyingBufferFunc;

        public virtual int get_RelativeTime(
            out long relativeTime
        ){
            var fp = GetFunctionPointer(12);
            if(m_get_RelativeTimeFunc==null) m_get_RelativeTimeFunc = (get_RelativeTimeFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(get_RelativeTimeFunc));
            
            return m_get_RelativeTimeFunc(m_ptr, out relativeTime);
        }
        delegate int get_RelativeTimeFunc(IntPtr self, out long relativeTime);
        get_RelativeTimeFunc m_get_RelativeTimeFunc;

    }
}
