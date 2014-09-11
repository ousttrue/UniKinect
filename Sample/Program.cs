using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NKinect;
using System.Threading;


namespace Sample
{
    class KinectImageStream: IDisposable
    {
        Boolean _initialized;
        public KinectImageStream()
        {
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
                }
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
    }


    class KinectSensor: IDisposable
    {
        Boolean _initialized;
        Int32 _angle;

        public KinectSensor()
        {
            Nui.NuiInitialize(Nui.NuiInitializeFlags.UsesColor
                | Nui.NuiInitializeFlags.UsesDepthAndPlayerIndex
                | Nui.NuiInitializeFlags.UsesSkeleton);

            _initialized = true;

            Int32 angle;
            Nui.NuiCameraElevationGetAngle(out angle);
            _angle = angle;
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
                    Nui.NuiShutdown();
                }
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var kinect = new KinectSensor())
                {
                    using (var stream = new KinectImageStream())
                    {

                    }

                    Thread.Sleep(2000);
                }
            }
            catch(System.Runtime.InteropServices.COMException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
