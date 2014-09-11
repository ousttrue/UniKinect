using System;
using System.Runtime.InteropServices;


namespace UniKinect.Nui
{
    public class KinectImageStream : KinectBaseStream
    {
        Boolean _initialized;
        IntPtr _phStreamHandle;

        public KinectImageStream(Nui.NuiImageType type, Nui.NuiImageResolution resolution, IntPtr waitHandle)
        {
            Nui.Import.NuiImageStreamOpen(type, resolution
                , 0, 2, waitHandle, out _phStreamHandle);

            _initialized = true;
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
