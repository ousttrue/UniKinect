using System;


namespace UniKinect.Nui
{
    public class KinectSensor : IDisposable
    {
        Boolean _initialized;
        Int32 _angle;

        public KinectSensor()
        {
            Nui.Import.NuiInitialize(Nui.NuiInitializeFlags.UsesColor
                | Nui.NuiInitializeFlags.UsesDepthAndPlayerIndex
                | Nui.NuiInitializeFlags.UsesSkeleton);

            _initialized = true;

            _angle=Nui.Import.NuiCameraElevationGetAngle();
        }

        // Flag: Has Dispose already been called?
        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Console.WriteLine("Dispose");

            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                if (_initialized)
                {
                    // Free any other managed objects here.
                    Nui.Import.NuiShutdown();
                }
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
    }
}
