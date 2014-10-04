using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniKinect;
using System.Reactive.Linq;
using System.Runtime.InteropServices;


namespace SampleForm
{
    public partial class SensorControl : UserControl
    {
        Timer _timer = new Timer();

        public SensorControl()
        {
            this.Disposed += (o, args) =>
            {
                DisposeSensor();
            };
            this.Disposed += (o, args) =>
            {
                DisposeColorImageHandler();
            };

            InitializeComponent();
        }

        IObservable<EventArgs> _timerEvent;
        private void SensorControl_Load(object sender, EventArgs e)
        {
            _timerEvent=_timer.TimerTickAsObservable().ObserveOn(this).Where(_ => _sensor!=null);

            // 30FPS
            _timer.Interval = 33;
            _timer.Start();
        }

        void DisposeSensor()
        {
            if (_sensor == null)
            {
                return;
            }
            _sensor.Dispose();
            _sensor = null;
        }
        
        KinectBaseSensor _sensor;
        public KinectBaseSensor Sensor
        {
            get { return _sensor; }
            set
            {
                if (_sensor == value)
                {
                    return;
                }

                DisposeSensor();

                colorImageResolutions.DataSource = new List<KinectImageResolution>
                {
                    KinectImageResolution.None,
                    KinectImageResolution.Resolution_640x480,
                    KinectImageResolution.Resolution_1280x960,
                };

                depthResolutions.DataSource = new List<KinectImageResolution>
                {
                    KinectImageResolution.None,
                    KinectImageResolution.Resolution_80x60,
                    KinectImageResolution.Resolution_320x240,
                    KinectImageResolution.Resolution_640x480,
                };

                _sensor = value;
                _sensor.Initialize();
            }
        }

        #region ColorImageStream
        private void colorImageResolutions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_sensor == null)
            {
                return;
            }
            var resolution = KinectImageResolution.None;
            if (colorImageResolutions.SelectedItem != null)
            {
                resolution = (KinectImageResolution)colorImageResolutions.SelectedItem;
            }
            _sensor.ColorImageResolution = resolution;
            if (resolution == KinectImageResolution.None)
            {
                return;
            }

            // cancel
            DisposeColorImageHandler();

            // new
            StartColorImageHandler(resolution);
        }

        IDisposable _colorImageHandler;
        void DisposeColorImageHandler()
        {
            if (_colorImageHandler == null)
            {
                return;
            }
            _colorImageHandler.Dispose();
            _colorImageHandler = null;
        }

        void StartColorImageHandler(KinectImageResolution resolution)
        {
            var bitmap = new Bitmap(resolution.Width(), resolution.Height());
            var buffer=new Byte[resolution.Width() * resolution.Height() *4 ];
            Action<KinectBaseImageFrame> UpdatePictureBox = frame =>
            {
                Marshal.Copy(frame.Buffer, buffer, 0, buffer.Length);
                bitmap.SetPixels(buffer);
                pictureBoxForImage.Image = bitmap;
            };

            _colorImageHandler = _timerEvent
                .Where(_ => _sensor.ColorImageStream != null)
                .Subscribe(_ => Observable.Using(
                    () => _sensor.ColorImageStream.GetFrame()
                    , frame => Observable.Return(frame)
                    )
                    .Where(frame => frame!=null)
                    .Subscribe(
                        frame => UpdatePictureBox(frame)
                        , ex => Console.WriteLine("error")
                    )
                )
                ;
        }
        #endregion

        #region DepthImageStream
        private void depthResolutions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_sensor == null)
            {
                return;
            }
            var resolution = KinectImageResolution.None;
            if (depthResolutions.SelectedItem != null)
            {
                resolution = (KinectImageResolution)depthResolutions.SelectedItem;
            }
            _sensor.DepthImageResolution = resolution;
            if (resolution == KinectImageResolution.None)
            {
                return;
            }

            // cancel
            DisposeDepthHandler();

            // new
            StartDepthHandler(resolution);
        }

        IDisposable _depthHandler;
        void DisposeDepthHandler()
        {
            if (_depthHandler == null)
            {
                return;
            }
            _depthHandler.Dispose();
            _depthHandler = null;
        }

        void StartDepthHandler(KinectImageResolution resolution)
        {
            var bitmap = new Bitmap(resolution.Width(), resolution.Height());
            var buffer = new Int16[resolution.Width() * resolution.Height()];
            Action<KinectBaseImageFrame> UpdatePictureBox = frame =>
            {
                Marshal.Copy(frame.Buffer, buffer, 0, buffer.Length);
                bitmap.SetPixels(buffer.SelectMany(d => {
                    var depth=((Int32)d)>>3;
                    return new Byte[]{
                        (Byte)depth
                        , (Byte)depth
                        , (Byte)depth
                        , (Byte)depth
                    };
                }).ToArray());
                pictureBoxForDepth.Image = bitmap;
            };

            _depthHandler = _timerEvent
                .Where(_ => _sensor.DepthImageStream != null)
                .Subscribe(_ => Observable.Using(
                    () => _sensor.DepthImageStream.GetFrame()
                    , frame => Observable.Return(frame)
                    )
                    .Where(frame => frame != null)
                    .Subscribe(
                        frame => UpdatePictureBox(frame)
                        , ex => Console.WriteLine("error")
                    )
                )
                ;
        }
        #endregion
    }
}
