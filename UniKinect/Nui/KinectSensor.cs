using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace UniKinect.Nui
{
    public class KinectSensor : KinectBaseSensor
    {
        public override int ApiVersion
        {
            get { return 1; }
        }
        INuiSensor _sensor;

#region ColorImage
        public override System.Collections.Generic.IEnumerable<KinectImageResolution> ColorImageResolutions
        {
            get
            {
                return new List<KinectImageResolution>
                {
                    KinectImageResolution.None,
                    KinectImageResolution.Resolution_640x480,
                    KinectImageResolution.Resolution_1280x960,
                };
            }
        }

        KinectImageStream _colorImageStream;
        public override KinectBaseImageStream ColorImageStream
        {
            get { return _colorImageStream; }
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
                CreateColorImageStream(IntPtr.Zero, value);
            }
        }

        void CreateColorImageStream(IntPtr waitHandle, KinectImageResolution resolution)
        {
            StopColorImage();
            if (resolution == KinectImageResolution.None)
            {
                return;
            }

            var type = Nui.NuiImageType.Color;
            IntPtr phStreamHandle=_sensor.NuiImageStreamOpen(type, resolution.ToNui()
                , 0
                , 2, waitHandle);
            _colorImageStream = new KinectImageStream(phStreamHandle, waitHandle, resolution, 4);
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
                    KinectImageResolution.Resolution_80x60,
                    KinectImageResolution.Resolution_320x240,
                    KinectImageResolution.Resolution_640x480,
                };
            }
        }

        public KinectImageStream _depthImageStream;
        public override KinectBaseImageStream DepthImageStream
        {
            get { return _depthImageStream; }
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
                CreateDepthImageStream(IntPtr.Zero, value);
            }
        }


        void CreateDepthImageStream(IntPtr waitHandle, KinectImageResolution resolution)
        {
            StopDepthImage();
            if (resolution == KinectImageResolution.None)
            {
                return;
            }

            var type = Nui.NuiImageType.DepthAndPlayerIndex;
            IntPtr phStreamHandle = _sensor.NuiImageStreamOpen(type, resolution.ToNui()
                , 0, 2, waitHandle);
            _depthImageStream = new KinectImageStream(phStreamHandle, waitHandle, resolution, 2);
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

        public Int32 Angle
        {
            get
            {
                return _sensor.NuiCameraElevationGetAngle();
            }
            set
            {
                _sensor.NuiCameraElevationSetAngle(value);
            }
        }

        public String Id
        {
            get;
            private set;
        }

        private KinectSensor(INuiSensor sensor)
        {
            _sensor = sensor;
            Id = _sensor.NuiDeviceConnectionId();
            //Console.WriteLine(sensor.NuiStatus());
        }

        public override string ToString()
        {
            return String.Format("Sensor: {0}", Id);
        }

        protected override void OnDispose()
        {
            Stop();
            if (_sensor != null)
            {
                Marshal.ReleaseComObject(_sensor);
                _sensor = null;
            }
        }

        #region StaticFactory
        public static KinectSensor Get(int index)
        {
            INuiSensor sensor;
            Import.NuiCreateSensorByIndex(index, out sensor).ThrowIfFail();
            if (sensor == null)
            {
                return null;
            }
            return new KinectSensor(sensor);
        }

        public static KinectSensor Get(String id)
        {
            INuiSensor sensor;
            Import.NuiCreateSensorById(id, out sensor).ThrowIfFail();
            if (sensor == null)
            {
                return null;
            }
            return new KinectSensor(sensor);
        }

        public static KinectSensor GetDefault()
        {
            int sensorCount;
            Import.NuiGetSensorCount(out sensorCount).ThrowIfFail();
            for (int i = 0; i < sensorCount; ++i)
            {
                var sensor = Get(i);
                if (sensor != null)
                {
                    return sensor;
                }
            }
            return null;
        }
        #endregion

        public override void Initialize()
        {
            Console.WriteLine("Initialize...");
            _sensor.NuiInitialize(Nui.NuiInitializeFlags.UsesColor
                | NuiInitializeFlags.UsesDepthAndPlayerIndex
                | NuiInitializeFlags.UsesSkeleton
                );
        }

        public override void Stop()
        {
            StopColorImage();
            StopDepthImage();
            Console.WriteLine("Stop...");
            _sensor.NuiShutdown();
        }

        public override KinectImageResolution IndexImageResolution
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override KinectBaseImageStream IndexImageStream
        {
            get { throw new NotImplementedException(); }
        }
    }
}
