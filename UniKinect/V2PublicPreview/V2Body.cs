using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UniKinect.V2PublicPreview
{
    public class V2Body: IDisposable
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

            IsTracked=_body.get_IsTracked();
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
                    Marshal.ReleaseComObject(_body);
                }
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
    }
}
