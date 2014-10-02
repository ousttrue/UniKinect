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

        IntPtr waitHandle;
        public IntPtr CreateWaitHandle()
        {
            if (waitHandle != null)
            {

            }
            waitHandle=m_reader.SubscribeFrameArrived();
            return waitHandle;
        }

        IColorFrameArrivedEventArgs m_data;
        IColorFrameReference m_frameRef;
        public override KinectBaseImageFrame GetFrame()
        {
            try
            {
                if (waitHandle != null)
                {
                    m_data = m_reader.GetFrameArrivedEventData(waitHandle);
                    m_frameRef = m_data.get_FrameReference();
                    var frame = new V2ImageFrame(m_frameRef.AcquireFrame());
                    if (!NewTimeStamp(frame.Time))
                    {
                        return null;
                    }
                    return frame;
                }
                else
                {
                    var frame = new V2ImageFrame(m_reader.AcquireLatestFrame());
                    if (!NewTimeStamp(frame.Time))
                    {
                        return null;
                    }
                    return frame;
                }
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
            Marshal.ReleaseComObject(m_frameRef);
            Marshal.ReleaseComObject(m_data);
            Marshal.ReleaseComObject(m_reader);
            Marshal.ReleaseComObject(m_source);
        }
    }
}
