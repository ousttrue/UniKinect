using System;

namespace UniKinect.V2PublicPreview
{
    public abstract class V2BaseImageFrame: KinectBaseImageFrame
    {
        public Int64 Time
        {
            get;
            protected set;
        }

        public ColorImageFormat Format
        {
            get;
            protected set;
        }

        public override Int32 BufferSize
        {
            get { return Pitch * Height; }
        }

        protected IntPtr _buffer;
        public override IntPtr Ptr
        {
            get { return _buffer; }
        }

        public override int Pitch
        {
            get { return (int)(Width * BytesPerPixel); }
        }

        protected Int32 _bytesPerPixel; 
        public override Int32 BytesPerPixel
        {
            get { return _bytesPerPixel; }
        }

        protected Int32 _width;
        public override Int32 Width
        {
            get { return _width; }
        }

        protected Int32 _height;
        public override Int32 Height
        {
            get { return _height; }
        }

        public override int ApiVersion
        {
            get { return 2; }
        }

    }
}
