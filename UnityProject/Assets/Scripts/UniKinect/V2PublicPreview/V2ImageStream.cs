using System;
using System.Runtime.InteropServices;

namespace UniKinect.V2PublicPreview
{
    public class V2ImageStream : KinectBaseStream
    {
        IColorFrameReader m_reader;

        public V2ImageStream(IKinectSensor sensor):base(10000000)
        {
            var source = sensor.get_ColorFrameSource();
            m_reader = source.OpenReader();
        }

        public V2ImageFrame GetFrame()
        {
            try
            {
                var frame = new V2ImageFrame(m_reader.AcquireLatestFrame());
                if (!NewTimeStamp(frame.Time))
                {
                    return null;
                }
                return frame;
            }
            catch (COMException ex)
            {
                if ((UInt32)ex.ErrorCode == 0x8000000A)
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
