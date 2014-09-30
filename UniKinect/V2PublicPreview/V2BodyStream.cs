using System;
using System.Runtime.InteropServices;

namespace UniKinect.V2PublicPreview
{
    public class V2BodyStream : KinectBaseStream
    {
        IBodyFrameReader m_reader;

        public V2BodyStream(IKinectSensor sensor)
            : base(10000000)
        {
            var source = sensor.get_BodyFrameSource();
            m_reader = source.OpenReader();
        }

        public V2BodyFrame GetFrame()
        {
            try
            {
                var frame = new V2BodyFrame(m_reader.AcquireLatestFrame());
                if (!NewTimeStamp(frame.Time))
                {
                    return null;
                }
                return frame;
            }
            catch (COMException ex)
            {
                if ((UInt32)ex.HResult == 0x8000000A)
                {

                }
                else
                {
                    Console.WriteLine(ex);
                }
                return null;
            }
        }

        protected override void OnDispose()
        {
            Marshal.ReleaseComObject(m_reader);
        }
    }
}
