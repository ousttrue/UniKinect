using System;
using KinectSDK20;

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

        public V2ImageStream(IKinectSensor sensor) : base(10000000)
        {
            sensor.get_ColorFrameSource(out m_source).ThrowIfFailed();
            m_source.OpenReader(out m_reader).ThrowIfFailed();

            m_source.get_FrameDescription(out IFrameDescription frameDesc).ThrowIfFailed();
            frameDesc.get_Width(out _width).ThrowIfFailed();
            frameDesc.get_Height(out _height).ThrowIfFailed();
        }

        IntPtr waitHandle;
        public IntPtr CreateWaitHandle()
        {
            m_reader.SubscribeFrameArrived(out long value).ThrowIfFailed();
            return waitHandle;
        }

        IColorFrameArrivedEventArgs m_data;
        IColorFrameReference m_frameRef;

        IColorFrame GetColorFrame()
        {
            if (waitHandle != null)
            {
                m_reader.GetFrameArrivedEventData(waitHandle.ToInt64(), out m_data).ThrowIfFailed();
                m_data.get_FrameReference(out m_frameRef).ThrowIfFailed();
                m_frameRef.AcquireFrame(out IColorFrame frame);
                return frame;
            }
            else
            {
                m_reader.AcquireLatestFrame(out IColorFrame frame).ThrowIfFailed();
                return frame;
            }
        }

        public override KinectBaseImageFrame GetFrame()
        {
            var frame = GetColorFrame();
            try
            {
                frame.get_RelativeTime(out long time).ThrowIfFailed();
                if (!NewTimeStamp(time))
                {
                    frame.Dispose();
                    return null;
                }
                return new V2ImageFrame(frame);
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
            m_frameRef?.Dispose();
            m_data?.Dispose();
            m_reader?.Dispose();
            m_source?.Dispose();
        }
    }
}
