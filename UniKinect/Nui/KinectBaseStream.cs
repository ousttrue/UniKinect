using System;

namespace UniKinect.Nui
{
    public abstract class KinectBaseStream: IDisposable
    {
        protected abstract void OnDispose();

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
                // Free any other managed objects here.
                OnDispose();
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        public Int64 TimeStamp
        {
            get;
            private set;
        }
        public Int64 DeltaTime
        {
            get;
            private set;
        }
        Int32 _frameCount;
        public Int32 FPS
        {
            get;
            private set;
        }

        protected Boolean NewTimeStamp(Int64 timeStamp)
        {
            var d = timeStamp - TimeStamp;
            if (d <= 0)
            {
                return false;
            }
            TimeStamp = timeStamp;

            _frameCount++;
            DeltaTime = DeltaTime + d;

            if (DeltaTime >= 1000)
            {
                FPS = _frameCount;
                _frameCount = 0;
                DeltaTime = 0;
            }

            return true;
        }
    }
}
