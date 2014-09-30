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
using UniKinect.Nui;


namespace SampleForm
{
    public partial class Form1 : Form
    {
        Font _font = new Font("ＭＳ ゴシック", 12);

        KinectSensor _sensor;

        KinectImageStream _imageStream;
        ManualResetEvent _imageWaitHandle = new ManualResetEvent(false);

        KinectImageStream _depthStream;
        ManualResetEvent _depthWaitHandle = new ManualResetEvent(false);

        KinectSkeletonStream _skeletonStream;
        ManualResetEvent _skeletonWaitHandle = new ManualResetEvent(false);


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

        public Form1()
        {
            InitializeComponent();

            _sensor = new KinectSensor();

            _imageStream = KinectImageStream.CreateImageStream(_imageWaitHandle.Handle);
            _depthStream = KinectImageStream.CreateDepthSteram(_depthWaitHandle.Handle);
            _skeletonStream = new KinectSkeletonStream(_skeletonWaitHandle.Handle);

            WaitUpdate(new WaitHandle[] { 
                _imageWaitHandle
                , _depthWaitHandle 
                , _skeletonWaitHandle
            });

            dataGridView2.DataSource = _skeletons;
        }

        delegate void SetBitmapDelegate(Bitmap bitmap);

        Bitmap ImageToBitmap(KInectImageFrame frame)
        {
            return new Bitmap(640, 480
                , frame.Rect.pitch, PixelFormat.Format32bppRgb, frame.Rect.pBits);
        }

        Byte[] DepthToPixel(Int32 depth)
        {
            depth = depth >> 3;
            return new Byte[]{
                (Byte)depth
                , (Byte)depth
                , (Byte)depth
                , 255
            };
        }

        Bitmap DepthToBitmap(KInectImageFrame frame)
        {
            var depthBuffer = new Int16[320 * 240];
            Marshal.Copy(frame.Rect.pBits, depthBuffer, 0, frame.Rect.size / 2);

            var bitmap = new Bitmap(320, 240);
            var data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height)
                , ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
            Marshal.Copy(depthBuffer.SelectMany(s => DepthToPixel((UInt16)s)).ToArray()
                , 0, data.Scan0, 320 * 240 * 4);
            bitmap.UnlockBits(data);
            return bitmap;
        }

        void WaitUpdate(WaitHandle[] handles)
        {
            try
            {
                var task = Task.Factory.StartNew(() =>
                {
                    var index = WaitHandle.WaitAny(handles);
                    switch (index)
                    {
                        case 0:
                            UpdatePictureBox(_imageStream, ImageToBitmap, pictureBox1);
                            break;

                        case 1:
                            UpdatePictureBox(_depthStream, DepthToBitmap, pictureBox2);
                            break;

                        case 2:
                            UpdateSkeleton(_skeletonStream);
                            break;
                    }

                    WaitUpdate(handles);

                });
            }
            catch (ObjectDisposedException)
            {
            }
        }

        delegate void SetSkeletonFrameDelegate(KinectSkeletonFrame frame);

        void SetSkeletonFrame(KinectSkeletonFrame frame)
        {
            int i = 0;
            foreach (var skeleton in frame.Frame.SkeletonData)
            {
                _skeletons[i++].Tracking=skeleton.eTrackingState;

                if (skeleton.eTrackingState == NuiSkeletonTrackingState.SkeletonTracked)
                {
                    listBox1.DataSource = skeleton.SkeletonPositions.ToList();
                }
            }
        }

        void UpdateSkeleton(KinectSkeletonStream src)
        {
            var frame=src.GetFrame();
            BeginInvoke(new SetSkeletonFrameDelegate(SetSkeletonFrame), new []{frame});
        }

        void UpdatePictureBox(KinectImageStream src, Func<KInectImageFrame, Bitmap> converter, PictureBox dst)
        {
            //Task.Factory.StartNew(() =>
            {
                using (var frame = src.GetFrame())
                {
                    if (frame == null)
                    {
                        return;
                    }
                    var converted = converter(frame);

                    // draw fps
                    Graphics g = Graphics.FromImage(converted);
                    RectangleF rect = new RectangleF(0, 0, 200, 60);
                    g.DrawString(String.Format("{0}", src.FPS), _font, Brushes.Yellow, rect);

                    BeginInvoke(new SetBitmapDelegate((Bitmap bitmap) =>
                    {
                        dst.Image = bitmap;
                    }), new Object[] { converted });
                }
            }
            //);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _skeletonWaitHandle.Dispose();
            _depthWaitHandle.Dispose();
            _imageWaitHandle.Dispose();
            _skeletonStream.Dispose();
            _depthStream.Dispose();
            _imageStream.Dispose();
            _sensor.Dispose();
        }
    }
}
