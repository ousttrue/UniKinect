using System;
using System.Runtime.InteropServices;

namespace UniKinect.V2PublicPreview
{
    public class V2DepthStream : KinectBaseImageStream
    {
        IDepthFrameSource m_source;
        IDepthFrameReader m_reader;

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

        public V2DepthStream(IKinectSensor sensor)
            : base(10000000)
        {
            m_source = sensor.get_DepthFrameSource();
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
            var frame = new V2DepthFrame(m_reader.AcquireLatestFrame(), null);
            if (!NewTimeStamp(frame.Time))
            {
                frame.Dispose();
                return null;
            }
            return frame;
        }

        public override KinectBaseImageFrame GetFrame(IntPtr handle)
        {
            var data = m_reader.GetFrameArrivedEventData(handle);
            var frameRef = data.get_FrameReference();
            try
            {
                var frame = new V2DepthFrame(frameRef.AcquireFrame(), frameRef);
                if (!NewTimeStamp(frame.Time))
                {
                    frame.Dispose();
                    return null;
                }
                return frame;
            }
            finally
            {
                Marshal.ReleaseComObject(data);
            }
        }

        protected override void OnDispose()
        {
            Marshal.ReleaseComObject(m_reader);
            Marshal.ReleaseComObject(m_source);
        }
    }
}
