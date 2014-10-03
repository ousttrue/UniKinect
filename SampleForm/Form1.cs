using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniKinect;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Threading;
#if false
// V1
using UniKinect.Nui;
#else
// V2
using UniKinect.V2PublicPreview;
#endif
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;


namespace SampleForm
{
    public partial class Form1 : Form,  INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        Font _font = new Font("ＭＳ ゴシック", 12);
        KinectBaseSensor _sensor;

        public Form1()
        {
            InitializeComponent();

#if false
            // v1
            _sensor = new KinectSensor();

            _imageStream = KinectImageStream.CreateImageStream(_imageWaitHandle.Handle);
            _depthStream = KinectImageStream.CreateDepthSteram(_depthWaitHandle.Handle);
            _skeletonStream = new KinectSkeletonStream(_skeletonWaitHandle.Handle);
            dataGridView2.DataSource = _skeletons;
#else
            // v2
            var sensor = new V2Sensor();
            _sensor = sensor;

           
            {
                var stream = new V2ImageStream(sensor.Sensor);

                var waitHandle = new ManualResetEvent(false);
                waitHandle.SafeWaitHandle = new Microsoft.Win32.SafeHandles.SafeWaitHandle(
                    stream.CreateWaitHandle(), false);

                var buffer = new Byte[stream.Width * stream.Height * stream.BytesPerPixel];
                var bitmap = new Bitmap(stream.Width, stream.Height);
                Action<KinectBaseImageFrame> assignFrame = frame =>
                {
                    Marshal.Copy(frame.Buffer, buffer, 0, buffer.Length);
                    bitmap.SetPixels(buffer);
                    pictureBox1.Image = bitmap;
                };

                StartUpdating(stream, waitHandle, assignFrame);
            }


            /*
            {
                var stream = new V2DepthStream(sensor.Sensor);

                var waitHandle = new ManualResetEvent(false);
                waitHandle.SafeWaitHandle = new Microsoft.Win32.SafeHandles.SafeWaitHandle(
                    stream.CreateWaitHandle(), false);

                var buffer = new Int16[stream.Width * stream.Height];
                var bitmap = new Bitmap(stream.Width, stream.Height);
                Action<KinectBaseImageFrame> assignFrame = frame =>
                {
                    Marshal.Copy(frame.Buffer, buffer, 0, buffer.Length);
                    bitmap.SetPixels(buffer.SelectMany(d => DepthToPixel(d)).ToArray());
                    pictureBox2.Image = bitmap;
                };

                StartUpdating(stream, waitHandle, assignFrame);
            }
            */
#endif
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MaxDepth = 1;
            maxDepth.DataBindings.Add("Text", this, "MaxDepth");

            colorFps.DataBindings.Add("Text", this, "ColorFps");
        }

        bool _closing;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _closing = true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_skeletonWaitHandle != null)
            {
                _skeletonWaitHandle.Dispose();
            }

            if (_skeletonStream != null)
            {
                _skeletonStream.Dispose();
            }

            if (_sensor != null)
            {
                _sensor.Dispose();
            }
        }

        void StartUpdating(KinectBaseImageStream stream, WaitHandle waitHandle, Action<KinectBaseImageFrame> assignFrame)
        {
            if (_closing)
            {
                Console.WriteLine("closing...");
                return;
            }
            var task = waitHandle.WaitTask(Timeout.Infinite);
            task.ToObservable()
                .ObserveOn(this)
                .Select(_ => stream.GetFrame(waitHandle.Handle))
                .Where(frame => frame != null)
                .Subscribe(
                frame =>
                {
                    assignFrame(frame);
                    ColorFps = stream.FPS;
                    frame.Dispose();
                }
                , ex =>
                {
                    Console.WriteLine(ex);
                    Console.WriteLine(V2ImageFrame.Counter);
                }
                , ()=> StartUpdating(stream, waitHandle, assignFrame)
                );
        }

        #region ImageStream
        Color[] ColorMap = new Color[]{
            Color.White,
            Color.Red,
            Color.Green,
            Color.Blue,
            Color.Cyan,
            Color.Magenta,
            Color.Yellow,
        };

        int _maxDepth;
        public int MaxDepth
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
                    Action action = () =>
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("MaxDepth"));
                    };
                    BeginInvoke(action);
                }
            }
        }

        int _tmpMaxDepth;
        Byte[] DepthToPixel(Int16 depth)
        {
            //var player = depth & 0x7;
            if (depth > (Int16)_tmpMaxDepth)
            {
                _tmpMaxDepth = depth;
            }

            // BGRA
            return new Byte[]{
                (Byte)(depth / MaxDepth)
                , (Byte)(depth / MaxDepth)
                , (Byte)(depth / MaxDepth)
                , 255
            };
        }

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

        int _colorFps;
        public int ColorFps
        {
            get { return _colorFps; }
            set
            {
                if (_colorFps == value)
                {
                    return;
                }
                _colorFps = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ColorFps"));
                }
            }
        }
        #endregion

        ManualResetEvent _skeletonWaitHandle;
        KinectBaseStream _skeletonStream;

        /*
        #region SkeletonStream

        class Skeleton : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            String name;
            public String Name
            {
                get { return name; }
                set
                {
                    if (name == value)
                    {
                        return;
                    }
                    name = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                    }
                }
            }

            NuiSkeletonTrackingState tracking;
            public NuiSkeletonTrackingState Tracking
            {
                get { return tracking; }
                set
                {
                    if (tracking == value)
                    {
                        return;
                    }
                    tracking = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Tracking"));
                    }
                }
            }

            public Skeleton()
            {
            }

            public override string ToString()
            {
                return String.Format("{0}:{1}", Name, Tracking);
            }
        }
        BindingList<Skeleton> _skeletons = new BindingList<Skeleton>
        {
            new Skeleton{
                Name="1",
            },
            new Skeleton{
                Name="2",
            },
            new Skeleton{
                Name="3",
            },
            new Skeleton{
                Name="4",
            },
            new Skeleton{
                Name="5",
            },
            new Skeleton{
                Name="6",
            },
        };

        delegate void SetSkeletonFrameDelegate(KinectSkeletonFrame frame);

        void SetSkeletonFrame(KinectSkeletonFrame frame)
        {
            int i = 0;
            foreach (var skeleton in frame.Frame.SkeletonData)
            {
                _skeletons[i++].Tracking = skeleton.eTrackingState;

                if (skeleton.eTrackingState == NuiSkeletonTrackingState.SkeletonTracked)
                {
                    listBox1.DataSource = skeleton.SkeletonPositions.ToList();
                }
            }
        }

        void UpdateSkeleton(KinectSkeletonStream src)
        {
            var frame = src.GetFrame();
            BeginInvoke(new SetSkeletonFrameDelegate(SetSkeletonFrame), new[] { frame });
        }
        #endregion
        */
    }
}
