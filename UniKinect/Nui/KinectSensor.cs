using System;


namespace UniKinect.Nui
{
    public class KinectSensor : KinectBaseSensor
    {
        Int32 _angle;

        public KinectSensor()
        {
            Nui.Import.NuiInitialize(Nui.NuiInitializeFlags.UsesColor
                | Nui.NuiInitializeFlags.UsesDepthAndPlayerIndex
                | Nui.NuiInitializeFlags.UsesSkeleton).ThrowIfFail();

            Nui.Import.NuiCameraElevationGetAngle(out _angle).ThrowIfFail();
        }

        protected override void OnDispose()
        {
            // Free any other managed objects here.
            Nui.Import.NuiShutdown();
        }
    }
}
