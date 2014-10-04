
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace UniKinect.V2PublicPreview
{
    public class V2Sensor : KinectBaseSensor
    {
        public override int ApiVersion
        {
            get { return 2; }
        }
        public IKinectSensor _sensor;
        public IKinectSensor Sensor { get { return _sensor; } }

        #region ColorImage
        public override IEnumerable<KinectImageResolution> ColorImageResolutions
        {
            get {
                return new List<KinectImageResolution>
                {
                    KinectImageResolution.None,
                    KinectImageResolution.Resolution_1920x1080,
                };
            }
        }

        public override KinectImageResolution ColorImageResolution
        {
            get
            {
                if (ColorImageStream == null)
                {
                    return KinectImageResolution.None;
                }
                return ColorImageStream.Resolution;
            }
            set
            {
                if (ColorImageStream != null && ColorImageStream.Resolution == value)
                {
                    return;
                }
                CreateColorImageStream(value);
            }
        }

        V2ImageStream _colorImageStream;
        public override KinectBaseImageStream ColorImageStream
        {
            get { return _colorImageStream; }
        }

        void CreateColorImageStream(KinectImageResolution resolution)
        {
            StopColorImage();
            if (resolution == KinectImageResolution.None)
            {
                return;
            }

            _colorImageStream = new V2ImageStream(Sensor);
        }

        void StopColorImage()
        {
            if (_colorImageStream != null)
            {
                _colorImageStream.Dispose();
                _colorImageStream = null;
            }
        }
        #endregion

        #region DepthImage
        public override IEnumerable<KinectImageResolution> DepthImageResolutions
        {
            get {
                return new List<KinectImageResolution>
                {
                    KinectImageResolution.None,
                    KinectImageResolution.Resolution_512x424,
                };
            }
        }

        public override KinectImageResolution DepthImageResolution
        {
            get
            {
                if (DepthImageStream == null)
                {
                    return KinectImageResolution.None;
                }
                return DepthImageStream.Resolution;
            }
            set
            {
                if (DepthImageStream != null && DepthImageStream.Resolution == value)
                {
                    return;
                }
                CreateDepthImageStream(value);
            }
        }

        V2DepthStream _depthImageStream;
        public override KinectBaseImageStream DepthImageStream
        {
            get { return _depthImageStream; }
        }

        void CreateDepthImageStream(KinectImageResolution resolution)
        {
            StopDepthImage();
            if (resolution == KinectImageResolution.None)
            {
                return;
            }

            _depthImageStream = new V2DepthStream(Sensor);
        }

        void StopDepthImage()
        {
            if (_depthImageStream != null)
            {
                _depthImageStream.Dispose();
                _depthImageStream = null;
            }
        }
        #endregion

        private V2Sensor(IKinectSensor sensor)
        {
            _sensor=sensor;
        }

        public static V2Sensor GetDefault()
        {
            IKinectSensor sensor;
            Import.GetDefaultKinectSensor(out sensor).ThrowIfFail();
            if(sensor==null){
                return null;
            }
            return new V2Sensor(sensor);
        }

        public static IEnumerable<V2Sensor> Enum()
        {
            // v2
            UniKinect.V2PublicPreview.IKinectSensorCollection collection;
            UniKinect.V2PublicPreview.Import.GetKinectSensorCollection(out collection);

            var enumerator = collection.get_Enumerator();
            try
            {
                Marshal.ReleaseComObject(collection);

                while (true)
                {
                    var sensor = enumerator.GetNext();
                    if (sensor == null)
                    {
                        break;
                    }
                    yield return new V2Sensor(sensor);
                }
            }
            finally
            {
                Marshal.ReleaseComObject(enumerator);
            }
        }

        public override void Initialize()
        {
            _sensor.Open();
        }

        public override void Stop()
        {
            StopColorImage();
            StopDepthImage();
            _sensor.Close();
        }

        protected override void OnDispose()
        {
            Stop();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(_sensor);
        }
    }
}
