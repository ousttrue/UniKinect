using System;

namespace UniKinect
{
    public abstract class KinectBaseSensor: IDisposable
    {
        public abstract void Initialize();
        public abstract void Stop();

        public abstract KinectImageResolution ColorImageResolution { get; set; }
        public abstract KinectBaseImageStream ColorImageStream { get; }

        public abstract KinectImageResolution DepthImageResolution { get; set; }
        public abstract KinectBaseImageStream DepthImageStream { get; }

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
                OnDispose();
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        abstract protected void OnDispose();
    }
}
