using System;
using System.Collections.Generic;

namespace UniKinect
{
    public abstract class KinectBaseSensor: IDisposable
    {
        public abstract Int32 ApiVersion { get; }
        public abstract void Initialize();
        public abstract void Stop();

        public abstract IEnumerable<KinectImageResolution> ColorImageResolutions { get; }
        public abstract KinectImageResolution ColorImageResolution { get; set; }
        public abstract KinectBaseImageStream ColorImageStream { get; }

        public abstract IEnumerable<KinectImageResolution> DepthImageResolutions { get; }
        public abstract KinectImageResolution DepthImageResolution { get; set; }
        public abstract KinectBaseImageStream DepthImageStream { get; }

        // v2
        //public abstract IEnumerable<KinectImageResolution> IndexImageResolutions { get; }
        public abstract KinectImageResolution IndexImageResolution { get; set; }
        public abstract KinectBaseImageStream IndexImageStream { get; }

        // Flag: Has Dispose already been called?
        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Console.WriteLine(String.Format("{0}: Dispose", this));

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
                OnDispose();
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        abstract protected void OnDispose();
    }
}
