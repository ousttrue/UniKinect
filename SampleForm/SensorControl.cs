using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UniKinect;
using System.Reactive.Linq;
using System.Runtime.InteropServices;
using System.ComponentModel;


namespace SampleForm
{
    public partial class SensorControl : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        Timer _timer = new Timer();

        public SensorControl()
        {
            this.Disposed += (o, args) =>
            {
                DisposeSensor();
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

            maxDepth.DataBindings.Add("Text", this, "MaxDepth");
        }

        void DisposeSensor()
        {
            DisposeColorImageHandler();
            DisposeDepthHandler();

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

                _sensor = value;
                colorImageResolutions.DataSource = _sensor.ColorImageResolutions;
                depthResolutions.DataSource = _sensor.DepthImageResolutions;
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
                frame.CopyTo(buffer);
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
            StartDepthHandler(_sensor.ApiVersion, resolution);
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

        Color[] ColorMap = new Color[]{
            Color.White,
            Color.Red,
            Color.Green,
            Color.Blue,
            Color.Cyan,
            Color.Magenta,
            Color.Yellow,
        };

        int _tmpMaxDepth;
        Byte[] DepthToPixelWithIndex(Int32 depth)
        {
            var player = depth & 0x7;

            depth = depth >> 3;
            if (depth > _tmpMaxDepth)
            {
                _tmpMaxDepth = depth;
            }

            var color = ColorMap[player];

            return new Byte[]{
                255
                , (Byte)(depth / MaxDepth)
                , (Byte)(depth / MaxDepth)
                , (Byte)(depth / MaxDepth)
            };
        }

        Int32 _maxDepth = 1;
        public Int32 MaxDepth
        {
            get { return _maxDepth; }
            set
            {
                if (_maxDepth == value)
                {
                    return;
                }
                _maxDepth = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MaxDepth"));
                }
            }
        }

        void StartDepthHandler(Int32 apiVersion, KinectImageResolution resolution)
        {
            var bitmap = new Bitmap(resolution.Width(), resolution.Height());
            var buffer = new Int16[resolution.Width() * resolution.Height()];
            Action<KinectBaseImageFrame> UpdatePictureBox;

            if (apiVersion == 1)
            {
                UpdatePictureBox = frame =>
                {
                    Marshal.Copy(frame.Ptr, buffer, 0, buffer.Length);
                    bitmap.SetPixels(buffer.SelectMany(d =>
                    {
                        var depth = ((Int32)d) >> 3;
                        if (depth > _tmpMaxDepth)
                        {
                            _tmpMaxDepth = depth;
                        }

                        var player= ((Int32)d) & 0x7;
                        var color = ColorMap[player];

                        return new Byte[]{
                        (Byte)(color.R * depth / MaxDepth)
                        , (Byte)(color.G * depth / MaxDepth)
                        , (Byte)(color.B * depth / MaxDepth)
                        , 255
                    };
                    }).ToArray());

                    pictureBoxForDepth.Image = bitmap;
                    if (_tmpMaxDepth > MaxDepth)
                    {
                        MaxDepth = _tmpMaxDepth;
                    }
                };
            }
            else if(apiVersion==2)
            {
                UpdatePictureBox = frame =>
                {
                    Marshal.Copy(frame.Ptr, buffer, 0, buffer.Length);
                    bitmap.SetPixels(buffer.SelectMany(d =>
                    {
                        return new Byte[]{
                        (Byte)d
                        , (Byte)d
                        , (Byte)d
                        , (Byte)d
                    };
                    }).ToArray());
                    pictureBoxForDepth.Image = bitmap;
                    if (_tmpMaxDepth > MaxDepth)
                    {
                        MaxDepth = _tmpMaxDepth;
                    }
                };
            }
            else
            {
                throw new ArgumentException("apiVersion");
            }

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
