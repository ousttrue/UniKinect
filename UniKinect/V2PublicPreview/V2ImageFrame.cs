using System;
using System.Runtime.InteropServices;

namespace UniKinect.V2PublicPreview
{
    public class V2ImageFrame : KinectBaseImageFrame
    {
        IColorFrame _frame;

        IFrameDescription _description;
        IColorFrameReference _reference;

        public Int64 Time
        {
            get;
            private set;
        }

        public ColorImageFormat Format
        {
            get { return _frame.get_RawColorImageFormat(); }
        }

        public override Int32 BufferSize
        {
            get { return Pitch*Height; }
        }

        IntPtr _buffer;
        public override IntPtr Buffer
        {
            get{ return _buffer; }
        }

        public override int Pitch
        {
            get { return (int)(Width * BytesPerPixel); }
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


        public V2ImageFrame(IColorFrame frame, IColorFrameReference reference)
        {
            _frame = frame;
            _reference = reference;
            _description = frame.get_FrameDescription();
            Time = frame.get_RelativeTime();
            UInt32 capacity;
            _buffer = _frame.AccessRawUnderlyingBuffer(out capacity);
        }

        public void CopyConvertedFrameDataToArray(Int32 length, IntPtr data)
        {
            _frame.CopyConvertedFrameDataToArray(length, data, ColorImageFormat.ColorImageFormat_Bgra);
        }

        protected override void OnDispose()
        {
            Marshal.ReleaseComObject(_description);
            Marshal.ReleaseComObject(_frame);
            Marshal.ReleaseComObject(_reference);
        }
    }
}
