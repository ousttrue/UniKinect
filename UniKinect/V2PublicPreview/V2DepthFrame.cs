using System;
using System.Runtime.InteropServices;

namespace UniKinect.V2PublicPreview
{
    public class V2DepthFrame : KinectBaseImageFrame
    {
        Boolean _initialized;

        IDepthFrame _frame;
        IDepthFrameReference _reference;

        IFrameDescription _description;

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


        public V2DepthFrame(IDepthFrame frame, IDepthFrameReference reference)
        {
            _frame = frame;
            _reference = reference;
            _initialized = true;
            _description = frame.get_FrameDescription();
            Time = frame.get_RelativeTime();
            UInt32 capacity;
            _buffer = _frame.AccessUnderlyingBuffer(out capacity);
        }

        protected override void OnDispose()
        {
            Marshal.ReleaseComObject(_description);
            Marshal.ReleaseComObject(_frame);
            Marshal.ReleaseComObject(_reference);
        }
    }
}
