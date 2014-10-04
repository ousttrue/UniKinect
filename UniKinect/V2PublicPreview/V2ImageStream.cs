using System;
using System.Runtime.InteropServices;

namespace UniKinect.V2PublicPreview
{
    public class V2ImageStream : KinectBaseImageStream
    {
        IColorFrameSource m_source;
        IColorFrameReader m_reader;

        public override KinectImageResolution Resolution
        {
            get { return KinectImageResolution.Resolution_1920x1080; }
        }

        int _bytesPerPixel;
        public override int BytesPerPixel
        {
            get { return _bytesPerPixel; }
        }

        public V2ImageStream(IKinectSensor sensor):base(10000000)
        {
            m_source = sensor.get_ColorFrameSource();
            m_reader = m_source.OpenReader();

            var frameDesc=m_source.get_FrameDescription();
            _bytesPerPixel=(Int32)frameDesc.get_BytesPerPixel();
        }

        public IntPtr CreateWaitHandle()
        {
            return m_reader.SubscribeFrameArrived();
        }

        public override KinectBaseImageFrame GetFrame()
        {
            var frame = new V2ImageFrame(m_reader.AcquireLatestFrame());
            if (!NewTimeStamp(frame.Time))
            {
                frame.Dispose();
                return null;
            }
            return frame;
        }

        public override KinectBaseImageFrame GetFrame(IntPtr handle)
        {
            var frame = new V2ImageFrame(m_reader, handle);
            if (!NewTimeStamp(frame.Time))
            {
                frame.Dispose();
                return null;
            }
            return frame;
        }

        protected override void OnDispose()
        {
            Marshal.ReleaseComObject(m_reader);
            Marshal.ReleaseComObject(m_source);
        }


    }
}
