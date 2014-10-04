using System;
using System.Runtime.InteropServices;


namespace UniKinect.Nui
{
    public class KinectImageStream : KinectBaseImageStream
    {
        IntPtr _phStreamHandle;

        KinectImageResolution _resolution;
        public override KinectImageResolution Resolution
        {
            get { return _resolution; }
        }

        int _bytesPerPixel;
        public override int BytesPerPixel
        {
            get { return _bytesPerPixel; }
        }

        public KinectImageStream(IntPtr streamHandle, IntPtr waitHandle
            , KinectImageResolution resolution, int bytesPerPixel):base(1000)
        {
            _phStreamHandle = streamHandle;
            _resolution = resolution;
            _bytesPerPixel = bytesPerPixel;
        }

        protected override void OnDispose()
        {
        }

        public override KinectBaseImageFrame GetFrame()
        {
            var frame = new KInectImageFrame(_phStreamHandle, BytesPerPixel);
            if (!NewTimeStamp(frame.Frame.liTimeStamp))
            {
                return null;
            }
            return frame;
        }

        public override KinectBaseImageFrame GetFrame(IntPtr handle)
        {
            return GetFrame();
        }
    }
}
