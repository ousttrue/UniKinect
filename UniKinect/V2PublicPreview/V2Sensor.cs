using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniKinect.V2PublicPreview
{
    public class V2Sensor : KinectBaseSensor
    {
        public IKinectSensor _sensor;
        public IKinectSensor Sensor { get { return _sensor; } }

        public V2Sensor()
        {
            Import.GetDefaultKinectSensor(out _sensor).ThrowIfFail();

            _sensor.Open();
        }

        protected override void OnDispose()
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(_sensor);
        }
    }
}
