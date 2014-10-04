
namespace UniKinect.V2PublicPreview
{
    public class V2Sensor : KinectBaseSensor
    {
        public IKinectSensor _sensor;
        public IKinectSensor Sensor { get { return _sensor; } }

        public V2Sensor()
        {
            Import.GetDefaultKinectSensor(out _sensor).ThrowIfFail();

        }

        public override void Initialize()
        {
            _sensor.Open();
        }

        public override void Stop()
        {
            _sensor.Close();
        }

        protected override void OnDispose()
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(_sensor);
        }


        public override KinectImageResolution ColorImageResolution
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public override KinectBaseImageStream ColorImageStream
        {
            get { throw new System.NotImplementedException(); }
        }

        public override KinectImageResolution DepthImageResolution
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public override KinectBaseImageStream DepthImageStream
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
