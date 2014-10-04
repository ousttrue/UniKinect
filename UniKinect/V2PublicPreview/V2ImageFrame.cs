using System;
using System.Runtime.InteropServices;

namespace UniKinect.V2PublicPreview
{
    public class V2ImageFrame : V2BaseImageFrame
    {
        IColorFrame _frame;
        IFrameDescription _description;
        IColorFrameArrivedEventArgs _data;
        IColorFrameReference _reference;

        public V2ImageFrame(IColorFrame frame)
        {
            SetFrame(frame);
        }

        void SetFrame(IColorFrame frame)
        {
            _frame = frame;
            Time = frame.get_RelativeTime();
            UInt32 capacity;
            _buffer = _frame.AccessRawUnderlyingBuffer(out capacity);

            _description = frame.get_FrameDescription();
            _bytesPerPixel=(Int32)_description.get_BytesPerPixel();
            _width=_description.get_Width();
            _height=_description.get_Height();
        }

        public override void CopyTo(byte[] buffer)
        {
            _frame.CopyConvertedFrameDataToArray(buffer.Length, buffer
                , ColorImageFormat.ColorImageFormat_Bgra);
        }

        public V2ImageFrame(IColorFrameReader reader, IntPtr handle)
        {
            try
            {
                _data = reader.GetFrameArrivedEventData(handle);
                _reference = _data.get_FrameReference();
                SetFrame(_reference.AcquireFrame());
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
