using System;
using System.Runtime.InteropServices;

namespace UniKinect.V2PublicPreview
{
    public class V2ImageStream : KinectBaseImageStream
    {
        IColorFrameSource m_source;
        IColorFrameReader m_reader;

        int _width;
        public override int Width
        {
            get { return _width; }
        }

        int _height;
        public override int Height
        {
            get { return _height; }
        }

        public V2ImageStream(IKinectSensor sensor):base(10000000)
        {
            m_source = sensor.get_ColorFrameSource();
            m_reader = m_source.OpenReader();

            var frameDesc=m_source.get_FrameDescription();
            _width = frameDesc.get_Width();
            _height = frameDesc.get_Height();
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
