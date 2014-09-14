using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UniKinect.V2PublicPreview
{
    public class V2ImageFrame : IDisposable
    {
        Boolean _initialized;

        IColorFrame _frame;

        IFrameDescription _description;

        public Int64 Time
        {
            get;
            private set;
        }

        public ColorImageFormat Format
        {
            get { return _frame.get_RawColorImageFormat(); }
        }

        Int32 _bufferSize;
        public Int32 BufferSize
        {
            get { return _bufferSize;  }
        }
        public IntPtr Buffer
        {
            get;
            private set;
        }

        public UInt32 BytesPerPixel
        {
            get { return _description.get_BytesPerPixel(); }
        }

        public Int32 Width
        {
            get { return _description.get_Width(); }
        }

        public Int32 Height
        {
            get { return _description.get_Height(); }
        }


        public V2ImageFrame(IColorFrame frame)
        {
            _frame = frame;
            _initialized = true;
            _description = frame.get_FrameDescription();
            Time = frame.get_RelativeTime();
            Buffer=_frame.AccessRawUnderlyingBuffer(out _bufferSize);
        }

        public void CopyConvertedFrameDataToArray(Int32 length, IntPtr data)
        {
            _frame.CopyConvertedFrameDataToArray(length, data, ColorImageFormat.ColorImageFormat_Bgra);
        }

        // Flag: Has Dispose already been called?
        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                if (_initialized)
                {
                    // Free any other managed objects here.
                    Marshal.ReleaseComObject(_description);
                    Marshal.ReleaseComObject(_frame);
                }
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
    }


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
