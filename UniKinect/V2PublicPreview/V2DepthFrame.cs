using System;
using System.Runtime.InteropServices;

namespace UniKinect.V2PublicPreview
{
    public class V2DepthFrame : KinectBaseImageFrame
    {
        IDepthFrame _frame;
        IFrameDescription _description;
        IDepthFrameArrivedEventArgs _data;
        IDepthFrameReference _reference;

        public Int64 Time
        {
            get;
            private set;
        }

        public override Int32 BufferSize
        {
            get
            {
                return Pitch * Height;
            }
        }

        IntPtr _buffer;
        public override IntPtr Buffer
        {
            get { return _buffer; }
        }

        public override int Pitch
        {
            get { return (Int32)BytesPerPixel * Width; }
        }

        public UInt32 BytesPerPixel
        {
            get { return _description.get_BytesPerPixel(); }
        }

        public override Int32 Width
        {
            get { return _description.get_Width(); }
        }

        public override Int32 Height
        {
            get { return _description.get_Height(); }
        }


        public V2DepthFrame(IDepthFrame frame)
        {
            _frame = frame;
            _description = frame.get_FrameDescription();
            Time = frame.get_RelativeTime();
            UInt32 capacity;
            _buffer = _frame.AccessUnderlyingBuffer(out capacity);
        }

        public V2DepthFrame(IDepthFrameReader reader, IntPtr handle)
        {
            try
            {
                _data = reader.GetFrameArrivedEventData(handle);
                _reference = _data.get_FrameReference();
                _frame = _reference.AcquireFrame();

                _description = _frame.get_FrameDescription();
                Time = _frame.get_RelativeTime();
                UInt32 capacity;
                _buffer = _frame.AccessUnderlyingBuffer(out capacity);
            }
            catch (COMException)
            {
                Dispose();
            }
        }

        protected override void OnDispose()
        {
            if (_description != null)
            {
                Marshal.ReleaseComObject(_description);
                _description = null;
            }
            if (_frame != null)
            {
                Marshal.ReleaseComObject(_frame);
                _frame = null;
            }
            if (_reference != null)
            {
                Marshal.ReleaseComObject(_reference);
                _reference = null;
            }
            if (_data != null)
            {
                Marshal.ReleaseComObject(_data);
                _data = null;
            }
        }
    }
}
