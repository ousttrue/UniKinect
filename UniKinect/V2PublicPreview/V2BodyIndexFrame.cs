using System;
using System.Runtime.InteropServices;

namespace UniKinect.V2PublicPreview
{
    public class V2BodyIndexFrame: V2BaseImageFrame
    {
        IBodyIndexFrame _frame;
        IFrameDescription _description;
        IBodyIndexFrameArrivedEventArgs _data;
        IBodyIndexFrameReference _reference;

        public V2BodyIndexFrame(IBodyIndexFrame frame)
        {
            SetFrame(frame);
        }    

        public V2BodyIndexFrame(IBodyIndexFrameReader reader, IntPtr handle)
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

        void SetFrame(IBodyIndexFrame frame)
        {
            _frame = frame;
            _description = frame.get_FrameDescription();
            _time = frame.get_RelativeTime();
            UInt32 capacity;
            _buffer = _frame.AccessUnderlyingBuffer(out capacity);

            _description = _frame.get_FrameDescription();
            _bytesPerPixel = (int)_description.get_BytesPerPixel();
            _width = _description.get_Width();
            _height = _description.get_Height();
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

        public override void CopyTo(byte[] buffer)
        {
            throw new NotImplementedException();
        }
    }
}
