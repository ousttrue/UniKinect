using System;
using KinectSDK20;

namespace UniKinect.V2PublicPreview
{
    public class V2Body : IDisposable
    {
        IBody _body;
        Boolean _initialized;

        public Boolean IsTracked
        {
            get;
            private set;
        }

        public V2Body(IBody body)
        {
            _body = body;
            //_body = (IBody)Marshal. GetObjectForIUnknown(p);
            _initialized = true;

            _body.get_IsTracked(out byte isTracked).ThrowIfFailed();
            IsTracked = isTracked != 0;
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
                    _body?.Dispose();
                }
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
    }
}
