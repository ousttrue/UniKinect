using System;
using System.Runtime.InteropServices;


namespace UniKinect.Nui
{
    public class KinectImageStream : KinectBaseImageStream
    {
        IntPtr _phStreamHandle;

        int _width;
        public override int Width
        {
            get { return _width; }
        }

        int _height;
        public override int Height
        {
            get { return _height; }
        }

        public KinectImageStream(Nui.NuiImageType type, Nui.NuiImageResolution resolution, IntPtr waitHandle):base(1000)
        {
            Nui.Import.NuiImageStreamOpen(type, resolution
                , 0, 2, waitHandle, out _phStreamHandle);

            switch (resolution)
            {
                case NuiImageResolution.resolution1280x1024:
                    _width = 1280;
                    _height = 1024;
                    break;

                case NuiImageResolution.resolution320x240:
                    _width = 320;
                    _height = 240;
                    break;

                case NuiImageResolution.resolution640x480:
                    _width = 640;
                    _height = 480;
                    break;

                case NuiImageResolution.resolution80x60:
                    _width = 80;
                    _height = 60;
                    break;

                default:
                    break;
            }
        }

        public static KinectImageStream CreateImageStream(IntPtr waitHandle)
        {
            return new KinectImageStream(Nui.NuiImageType.Color
                , Nui.NuiImageResolution.resolution640x480
                , waitHandle
                );
        }

        public static KinectImageStream CreateDepthSteram(IntPtr waitHandle)
        {
            return new KinectImageStream(Nui.NuiImageType.DepthAndPlayerIndex
                , Nui.NuiImageResolution.resolution320x240
                , waitHandle
                );
        
        }

        protected override void OnDispose()
        {
        }

        public override KinectBaseImageFrame GetFrame()
        {
            try
            {
                var frame = new KInectImageFrame(_phStreamHandle);
                if (!NewTimeStamp(frame.Frame.liTimeStamp))
                {
                    return null;
                }
                return frame;
            }
            catch(COMException ex)
            {
                return null;
            }
        }
    }
}
