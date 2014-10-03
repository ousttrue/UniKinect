using System;
using System.Runtime.InteropServices;

namespace UniKinect.V2PublicPreview
{
    public class V2ImageFrame : KinectBaseImageFrame
    {
        IColorFrame _frame;

        IFrameDescription _description;
        IColorFrameArrivedEventArgs _data;
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

        public static Int32 Counter;

        public V2ImageFrame(IColorFrame frame)
        {
            _frame = frame;
            _description = frame.get_FrameDescription();
            Time = frame.get_RelativeTime();
            UInt32 capacity;
            _buffer = _frame.AccessRawUnderlyingBuffer(out capacity);
        }

        public V2ImageFrame(IColorFrameReader reader, IntPtr handle)
        {
            ++Counter;

            try
            {
                _data = reader.GetFrameArrivedEventData(handle);
                _reference = _data.get_FrameReference();
                var frame = _reference.AcquireFrame();

                _frame = frame;
                _description = frame.get_FrameDescription();
                Time = frame.get_RelativeTime();
                UInt32 capacity;
                _buffer = _frame.AccessRawUnderlyingBuffer(out capacity);
            }
            catch (COMException)
            {
                Dispose();
            }
        }

        public void CopyConvertedFrameDataToArray(Int32 length, IntPtr data)
        {
            _frame.CopyConvertedFrameDataToArray(length, data, ColorImageFormat.ColorImageFormat_Bgra);
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

            --Counter;
        }
    }
}
