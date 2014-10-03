using System;
using System.Runtime.InteropServices;

namespace UniKinect.Nui
{
    public class KInectImageFrame : KinectBaseImageFrame
    {
        IntPtr _phStreamHandle;
        IntPtr _imageFramePtr;
        Nui.NuiLockedRect _rect = new Nui.NuiLockedRect();
        public Nui.NuiLockedRect Rect
        {
            get { return _rect; }
        }
        public Nui.NuiImageFrame Frame
        {
            get;
            private set;
        }

        public override IntPtr Buffer
        {
            get { return Rect.pBits; }
        }

        public override Int32 BufferSize
        {
            get { return Rect.size; }
        }

        public override int Pitch
        {
            get { return Rect.pitch; }
        }

        public override int Height
        {
            get { return Rect.size/Rect.pitch; }
        }

        public override int Width
        {

            // ?
            get { return Rect.pitch / 3; }
        }

        public KInectImageFrame(IntPtr phStreamHandle)
        {
            _phStreamHandle = phStreamHandle;
            Nui.Import.NuiImageStreamGetNextFrame(_phStreamHandle, 0, out _imageFramePtr).ThrowIfFail();
            if (_imageFramePtr == IntPtr.Zero)
            {
                return;
            }

            Frame = (Nui.NuiImageFrame)Marshal.PtrToStructure(_imageFramePtr, typeof(Nui.NuiImageFrame));
            Frame.pFrameTexture.LockRect(0, ref _rect, IntPtr.Zero, 0);
        }

        protected override void OnDispose()
        {
            // Free any other managed objects here.
            Nui.Import.NuiImageStreamReleaseFrame(_phStreamHandle, _imageFramePtr);
        }
    }
}
