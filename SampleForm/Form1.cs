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

            _imageWaitHandle = new ManualResetEvent(false);
            _depthWaitHandle = new ManualResetEvent(false);
            _skeletonWaitHandle = new ManualResetEvent(false);

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
                var imageStream = new V2ImageStream(sensor.Sensor);

                var imageWaitHandle = new ManualResetEvent(false);
                imageWaitHandle.SafeWaitHandle = new Microsoft.Win32.SafeHandles.SafeWaitHandle(
                    imageStream.CreateWaitHandle(), false);

                StartUpdating(imageStream, imageWaitHandle, pictureBox1);
            }

            if(false)
            {
                var stream = new V2DepthStream(sensor.Sensor);

                var waitHandle = new ManualResetEvent(false);
                waitHandle.SafeWaitHandle = new Microsoft.Win32.SafeHandles.SafeWaitHandle(
                    stream.CreateWaitHandle(), false);

                StartUpdating(stream, waitHandle, pictureBox2);
            }
#endif
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MaxDepth = 1;
            maxDepth.DataBindings.Add("Text", this, "MaxDepth");

            colorFps.DataBindings.Add("Text", this, "ColorFps");

            var handles = new WaitHandle[] { 
                _imageWaitHandle
                , _depthWaitHandle 
                , _skeletonWaitHandle
            };
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
            if (_depthWaitHandle != null)
            {
                _depthWaitHandle.Dispose();
            }
            if (_imageWaitHandle != null)
            {
                _imageWaitHandle.Dispose();
            }
            if (_skeletonStream != null)
            {
                _skeletonStream.Dispose();
            }
            if (_depthStream != null)
            {
                _depthStream.Dispose();
            }
            if (_imageStream != null)
            {
                _imageStream.Dispose();
            }
            if (_sensor != null)
            {
                _sensor.Dispose();
            }
        }

        void StartUpdating(KinectBaseImageStream stream, WaitHandle waitHandle, PictureBox target)
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
                    target.Image = ImageToBitmap(frame);
                    frame.Dispose();
                }
                , ex =>
                {
                    Console.WriteLine(ex);
                    Console.WriteLine(V2ImageFrame.Counter);
                }
                , ()=> StartUpdating(stream, waitHandle, target)
                );
        }

        #region ImageStream
        KinectBaseImageStream _imageStream;
        WaitHandle _imageWaitHandle;

        KinectBaseImageStream _depthStream;
        WaitHandle _depthWaitHandle;

        delegate void SetBitmapDelegate(Bitmap bitmap);

        Bitmap ImageToBitmap(KinectBaseImageFrame frame)
        {
            return new Bitmap(frame.Width, frame.Height
                , frame.Pitch, PixelFormat.Format32bppRgb, frame.Buffer);
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
        Byte[] DepthToPixel(Int32 depth)
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

        Bitmap DepthToBitmap(KinectBaseImageFrame frame)
        {
            var depthBuffer = new Int16[320 * 240];
            Marshal.Copy(frame.Buffer, depthBuffer, 0, frame.Pitch * frame.Height / 2);

            var bitmap = new Bitmap(320, 240);
            var data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height)
                , ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
            Marshal.Copy(depthBuffer.SelectMany(s => DepthToPixel((UInt16)s)).ToArray()
                , 0, data.Scan0, 320 * 240 * 4);
            if (_tmpMaxDepth > MaxDepth)
            {
                MaxDepth = _tmpMaxDepth;
            }
            bitmap.UnlockBits(data);
            return bitmap;
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
