using System;

namespace UniKinect
{
    public abstract class KinectBaseStream: IDisposable
    {
        Int64 _timeStampForSecond;
        protected KinectBaseStream(Int64 timeStampForSecond)
        {
            _timeStampForSecond = timeStampForSecond;
        }

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

        protected Boolean AdvanceTimeStamp(Int64 delta)
        {
            return NewTimeStamp(TimeStamp + delta);
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

            if (DeltaTime >= _timeStampForSecond)
            {
                FPS = _frameCount;
                _frameCount = 0;
                DeltaTime = 0;
            }

            return true;
        }
    }

    public abstract class KinectBaseImageStream : KinectBaseStream
    {
        public abstract Int32 Width { get; }
        public abstract Int32 Height { get; }

        protected KinectBaseImageStream(Int64 timeStampForSecond)
            : base(timeStampForSecond)
        {
        }

        public abstract KinectBaseImageFrame GetFrame();
        public abstract KinectBaseImageFrame GetFrame(IntPtr handle);
    }
}
