using System;
using KinectSDK20;

namespace UniKinect.V2PublicPreview
{
    public class V2DepthStream : KinectBaseImageStream
    {
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
            sensor.get_DepthFrameSource(out IDepthFrameSource source).ThrowIfFailed();
            source.OpenReader(out m_reader).ThrowIfFailed();

            source.get_FrameDescription(out IFrameDescription frameDesc).ThrowIfFailed();
            frameDesc.get_Width(out _width).ThrowIfFailed();
            frameDesc.get_Height(out _height).ThrowIfFailed();
        }

        public IntPtr CreateWaitHandle()
        {
            m_reader.SubscribeFrameArrived(out long value).ThrowIfFailed();
            return new IntPtr(value);
        }

        public override KinectBaseImageFrame GetFrame()
        {
            IDepthFrame frame = null;
            try
            {
                m_reader.AcquireLatestFrame(out frame).ThrowIfFailed();
                frame.get_RelativeTime(out long relativeTime).ThrowIfFailed();
                if (!NewTimeStamp(relativeTime))
                {
                    frame.Dispose();
                    return null;
                }
                return new V2DepthFrame(frame);
            }
            catch (KinectSDK20.ComException ex)
            {
                if ((UInt32)ex.HR == 0x8000000A)
                {

                }
                else
                {
                    Console.WriteLine(ex);
                }
                if (frame)
                {
                    frame.Dispose();
                }
                return null;
            }
        }

        protected override void OnDispose()
        {
            m_reader?.Dispose();
        }
    }
}
