using System;


namespace UniKinect.Nui
{
    public class KinectSkeletonStream: KinectBaseStream
    {
        Boolean _initialized;
        public Nui.NuiTransformSmoothParameters SmoothingParams;

        public KinectSkeletonStream(IntPtr waitHandle)
        {
            Nui.Import.NuiSkeletonTrackingEnable(waitHandle, Nui.NuiSkeletonFlags.None);

            SmoothingParams.fSmoothing = 1.0f;
            SmoothingParams.fCorrection = 0.5f;
            SmoothingParams.fPrediction = 0.5f;
            SmoothingParams.fJitterRadius = 0.05f;
            SmoothingParams.fMaxDeviationRadius = 0.04f;

            _initialized = true;
        }

        protected override void OnDispose()
        {
            if (_initialized)
            {

            }
        }

        public KinectSkeletonFrame GetFrame()
        {
            var frame=new KinectSkeletonFrame();
            if (!NewTimeStamp(frame.Frame.liTimeStamp)){
                return null;
            }

            // smoothing
            Nui.Import.NuiTransformSmooth(ref frame.Frame, ref SmoothingParams);

            return frame;
        }
    }
}
