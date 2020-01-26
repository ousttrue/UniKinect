
using KinectSDK20;

namespace UniKinect.V2PublicPreview
{
    public class V2Sensor : KinectBaseSensor
    {
        public IKinectSensor _sensor;
        public IKinectSensor Sensor { get { return _sensor; } }

        public V2Sensor()
        {
            kinect.GetDefaultKinectSensor(out _sensor).ThrowIfFailed();
            _sensor.Open().ThrowIfFailed();
        }

        protected override void OnDispose()
        {
            _sensor?.Dispose();
        }
    }
}
