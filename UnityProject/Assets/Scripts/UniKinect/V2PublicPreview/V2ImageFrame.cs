using System;
using System.Runtime.InteropServices;
using KinectSDK20;

namespace UniKinect.V2PublicPreview
{
    public class V2ImageFrame : KinectBaseImageFrame
    {
        IColorFrame _frame;

        IFrameDescription _description;

        public Int64 Time
        {
            get;
            private set;
        }

        public _ColorImageFormat Format
        {
            get
            {
                _frame.get_RawColorImageFormat(out _ColorImageFormat format).ThrowIfFailed();
                return format;
            }
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
            get { return (int)(BufferSize / Height); }
        }

        public UInt32 BytesPerPixel
        {
            get
            {
                _description.get_BytesPerPixel(out uint value).ThrowIfFailed();
                return value;
            }
        }

        public override Int32 Width
        {
            get
            {
                _description.get_Width(out int value).ThrowIfFailed();
                return value;
            }
        }

        public override Int32 Height
        {
            get
            {
                _description.get_Height(out int value).ThrowIfFailed();
                return value;
            }
        }

        public V2ImageFrame(IColorFrame frame)
        {
            _frame = frame;
            frame.get_FrameDescription(out _description).ThrowIfFailed();
            frame.get_RelativeTime(out long time).ThrowIfFailed();
            Time = time;
            _frame.AccessRawUnderlyingBuffer(out _bufferSize, out _buffer);
        }

        public void CopyConvertedFrameDataToArray(uint length, out byte data)
        {
            _frame.CopyConvertedFrameDataToArray(length, out data, _ColorImageFormat._Bgra).ThrowIfFailed();
        }

        protected override void OnDispose()
        {
            // Free any other managed objects here.
            _description?.Dispose();
            _frame?.Dispose();
        }
    }
}
