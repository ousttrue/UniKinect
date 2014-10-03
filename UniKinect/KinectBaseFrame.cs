using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniKinect
{
    public abstract class KinectBaseFrame: IDisposable
    {
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
                OnDispose();
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        protected abstract void OnDispose();
    }

    public abstract class KinectBaseImageFrame : KinectBaseFrame
    {
        public abstract Int32 Pitch { get; }
        public abstract Int32 BytesPerPixel { get; }
        public abstract Int32 Width { get; }
        public abstract Int32 Height { get; }
        public abstract IntPtr Buffer { get; }
        public abstract Int32 BufferSize { get; }
    }
}
