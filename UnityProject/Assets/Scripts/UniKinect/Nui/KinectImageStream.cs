using System;
using System.Runtime.InteropServices;


namespace UniKinect.Nui
{
    public class KinectImageStream : KinectBaseStream
    {
        IntPtr _phStreamHandle;

        public Int32 Width { get; private set; }
        public Int32 Height { get; private set; }

        public KinectImageStream(Nui.NuiImageType type, Nui.NuiImageResolution resolution, IntPtr waitHandle):base(1000)
        {
            Nui.Import.NuiImageStreamOpen(type, resolution
                , 0, 2, waitHandle, out _phStreamHandle);

            switch (resolution)
            {
                case NuiImageResolution.resolution1280x1024:
                    Width = 1280;
                    Height = 1024;
                    break;

                case NuiImageResolution.resolution320x240:
                    Width = 320;
                    Height = 240;
                    break;

                case NuiImageResolution.resolution640x480:
                    Width = 640;
                    Height = 480;
                    break;

                case NuiImageResolution.resolution80x60:
                    Width = 80;
                    Height = 60;
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

        public KInectImageFrame GetFrame()
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
