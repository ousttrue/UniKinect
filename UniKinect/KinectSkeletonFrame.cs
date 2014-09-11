
namespace UniKinect
{
    public class KinectSkeletonFrame
    {
        public Nui.NuiSkeletonFrame Frame;

        public KinectSkeletonFrame()
        {
            Nui.NuiSkeletonGetNextFrame(0, ref Frame);
        }
    }
}
