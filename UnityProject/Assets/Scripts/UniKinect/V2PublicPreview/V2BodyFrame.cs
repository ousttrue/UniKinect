using System;
using System.Linq;
using KinectSDK20;

namespace UniKinect.V2PublicPreview
{
    public class V2BodyFrame : IDisposable
    {
        Boolean _initialized;

        IBodyFrame _frame;

        public Int64 Time
        {
            get
            {
                _frame.get_RelativeTime(out long relativeTime).ThrowIfFailed();
                return relativeTime;
            }
        }

        public V2Body[] Bodies
        {
            get;
            private set;
        }

        public V2BodyFrame(IBodyFrame frame)
        {
            _frame = frame;
            _initialized = true;

            var bodies = new IBody[6];
            _frame.GetAndRefreshBodyData(6, out bodies[0]);

            Bodies = bodies.Select(x => new V2Body(x)).ToArray();
        }

        // Flag: Has Dispose already been called?
        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
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
                    foreach (var body in Bodies)
                    {
                        body.Dispose();
                    }
                    _frame?.Dispose();
                }
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
    }
}
