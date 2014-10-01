
namespace UniKinect.Nui
{
    public class KinectSkeletonFrame
    {
        public Nui.NuiSkeletonFrame Frame;

        public KinectSkeletonFrame()
        {
            Nui.Import.NuiSkeletonGetNextFrame(0, ref Frame);
        }
    }
}
