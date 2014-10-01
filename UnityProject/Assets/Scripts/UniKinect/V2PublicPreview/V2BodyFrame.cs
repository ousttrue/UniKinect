using System;
using System.Runtime.InteropServices;

namespace UniKinect.V2PublicPreview
{
    public class V2BodyFrame : IDisposable
    {
        Boolean _initialized;

        IBodyFrame _frame;

        public Int64 Time
        {
            get { return _frame.get_RelativeTime(); }
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

            var bodies=new Bodies();
            _frame.GetAndRefreshBodyData(6, ref bodies);

            Bodies = new V2Body[]{
                new V2Body(bodies._0),
                new V2Body(bodies._1),
                new V2Body(bodies._2),
                new V2Body(bodies._3),
                new V2Body(bodies._4),
                new V2Body(bodies._5),
            };
            //Bodies = Enumerable.Range(0, 6).Select(i => new V2Body(Marshal.ReadIntPtr(p, i))).ToArray();
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
                    Marshal.ReleaseComObject(_frame);
                }
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
    }
}
