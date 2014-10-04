using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniKinect
{
    public enum KinectImageResolution
    {
        None,
        // v1
        Resolution_80x60,
        Resolution_320x240,
        Resolution_640x480,
        Resolution_1280x960,
        // v2
        Resolution_1920x1080,
        Resolution_512x424,
    }

    public static class KinectImageResolutionExtensions
    {
        public static Nui.NuiImageResolution ToNui(this KinectImageResolution resolution)
        {
            switch (resolution)
            {
                case KinectImageResolution.Resolution_80x60:
                    return Nui.NuiImageResolution.resolution80x60;

                case KinectImageResolution.Resolution_320x240:
                    return Nui.NuiImageResolution.resolution320x240;

                case KinectImageResolution.Resolution_640x480:
                    return Nui.NuiImageResolution.resolution640x480;

                case KinectImageResolution.Resolution_1280x960:
                    return Nui.NuiImageResolution.resolution1280x1024;

                default:
                    return Nui.NuiImageResolution.resolutionInvalid;
            }
        }

        public static int Width(this KinectImageResolution resolution)
        {
            switch (resolution)
            {
                case KinectImageResolution.Resolution_80x60:
                    return 80;

                case KinectImageResolution.Resolution_320x240:
                    return 320;

                case KinectImageResolution.Resolution_640x480:
                    return 640;

                case KinectImageResolution.Resolution_1280x960:
                    return 1280;

                case KinectImageResolution.Resolution_512x424:
                    return 512;

                case KinectImageResolution.Resolution_1920x1080:
                    return 1920;

                default:
                    return 0;
            }
        }

        public static int Height(this KinectImageResolution resolution)
        {
            switch (resolution)
            {
                case KinectImageResolution.Resolution_80x60:
                    return 60;

                case KinectImageResolution.Resolution_320x240:
                    return 240;

                case KinectImageResolution.Resolution_640x480:
                    return 480;

                case KinectImageResolution.Resolution_1280x960:
                    return 960;

                case KinectImageResolution.Resolution_512x424:
                    return 424;

                case KinectImageResolution.Resolution_1920x1080:
                    return 1080;

                default:
                    return 0;
            }
        }
    }
}
