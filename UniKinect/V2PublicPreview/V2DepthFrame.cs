using System;
using System.Runtime.InteropServices;

namespace UniKinect.V2PublicPreview
{
    public class V2DepthFrame : KinectBaseImageFrame
    {
        Boolean _initialized;

        IDepthFrame _frame;

        IFrameDescription _description;

        public Int64 Time
        {
            get;
            private set;
        }

        UInt32 _bufferSize;
        public UInt32 BufferSize
        {
            get { return _bufferSize; }
        }

        IntPtr _buffer;
        public override IntPtr Buffer
        {
            get { return _buffer; }
        }

        public override int Pitch
        {
            get { return (int)(BufferSize/Height); }
        }

        public UInt32 BytesPerPixel
        {
            get { return _description.get_BytesPerPixel(); }
        }

        public Int32 Width
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
            _initialized = true;
            _description = frame.get_FrameDescription();
            Time = frame.get_RelativeTime();
            _buffer = _frame.AccessUnderlyingBuffer(out _bufferSize);
        }

        protected override void OnDispose()
        {
            // Free any other managed objects here.
            Marshal.ReleaseComObject(_description);
            Marshal.ReleaseComObject(_frame);
        }
    }
}
