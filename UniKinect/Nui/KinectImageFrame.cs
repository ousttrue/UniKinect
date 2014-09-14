﻿using System;
using System.Runtime.InteropServices;

namespace UniKinect.Nui
{
    public class KInectImageFrame : IDisposable
    {
        Boolean _initialized;
        IntPtr _phStreamHandle;
        IntPtr _imageFramePtr;
        Nui.NuiLockedRect _rect = new Nui.NuiLockedRect();
        public Nui.NuiLockedRect Rect
        {
            get { return _rect; }
        }
        public Nui.NuiImageFrame Frame
        {
            get;
            private set;
        }

        public KInectImageFrame(IntPtr phStreamHandle)
        {
            _phStreamHandle = phStreamHandle;
            _imageFramePtr=Nui.Import.NuiImageStreamGetNextFrame(_phStreamHandle, 0);
            if (_imageFramePtr == IntPtr.Zero)
            {
                return;
            }
            _initialized = true;

            Frame = (Nui.NuiImageFrame)Marshal.PtrToStructure(_imageFramePtr, typeof(Nui.NuiImageFrame));
            Frame.pFrameTexture.LockRect(0, ref _rect, IntPtr.Zero, 0);
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
                    Nui.Import.NuiImageStreamReleaseFrame(_phStreamHandle, _imageFramePtr);
                }
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
    }
}
