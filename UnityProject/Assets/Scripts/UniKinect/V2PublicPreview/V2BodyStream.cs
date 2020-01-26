using System;
using KinectSDK20;

namespace UniKinect.V2PublicPreview
{
    public class V2BodyStream : KinectBaseStream
    {
        IBodyFrameReader m_reader;

        public V2BodyStream(IKinectSensor sensor)
            : base(10000000)
        {
            sensor.get_BodyFrameSource(out IBodyFrameSource source).ThrowIfFailed();
            source.OpenReader(out m_reader).ThrowIfFailed();
        }

        public V2BodyFrame GetFrame()
        {
            m_reader.AcquireLatestFrame(out IBodyFrame frame).ThrowIfFailed();
            try
            {
                frame.get_RelativeTime(out long relativeTime).ThrowIfFailed();
                if (!NewTimeStamp(relativeTime))
                {
                    frame.Dispose();
                    return null;
                }
                return new V2BodyFrame(frame);
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
