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
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;


namespace SampleForm
{
    public partial class Form1 : Form
    {
        Font _font = new Font("ＭＳ ゴシック", 12);


        public Form1()
        {
            InitializeComponent();

            {
                // v1
                Int32 sensorCount;
                UniKinect.Nui.Import.NuiGetSensorCount(out sensorCount).ThrowIfFail();
                for (int i = 0; i < sensorCount; ++i)
                {
                    var sensor = UniKinect.Nui.KinectSensor.Get(i);
                    sensors.Items.Add(sensor);
                }
            }

            {
                foreach(UniKinect.V2PublicPreview.V2Sensor sensor in UniKinect.V2PublicPreview.V2Sensor.Enum())
                {
                    sensors.Items.Add(sensor);
                }
            }


            /*
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
                    //pictureBox1.Image = bitmap;
                };

                StartUpdating(stream, waitHandle, assignFrame);
            }
            {
                var stream = new V2DepthStream(sensor.Sensor);

                var waitHandle = new ManualResetEvent(false);
                waitHandle.SafeWaitHandle = new Microsoft.Win32.SafeHandles.SafeWaitHandle(
                    stream.CreateWaitHandle(), false);

                var bitmap = new Bitmap(stream.Width, stream.Height);
                Action<KinectBaseImageFrame> assignFrame = frame =>
                {
                    Marshal.Copy(frame.Buffer, buffer, 0, buffer.Length);
                    bitmap.SetPixels(buffer.SelectMany(d => DepthToPixel(d)).ToArray());
                    pictureBox2.Image = bitmap;
                };

                StartUpdating(stream, waitHandle, assignFrame);
            }

            {
                var stream = new V2BodyIndexStream(sensor.Sensor);

                var waitHandle = new ManualResetEvent(false);
                waitHandle.SafeWaitHandle = new Microsoft.Win32.SafeHandles.SafeWaitHandle(
                    stream.CreateWaitHandle(), false);

                var buffer = new Byte[stream.Width * stream.Height];
                var bitmap = new Bitmap(stream.Width, stream.Height, PixelFormat.Format8bppIndexed);
                Action<KinectBaseImageFrame> assignFrame = frame =>
                {
                    Marshal.Copy(frame.Buffer, buffer, 0, buffer.Length);
                    bitmap.SetPixels(buffer);
                    //pictureBox2.Image = bitmap;
                };

                StartUpdating(stream, waitHandle, assignFrame);
            }
            */
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        bool _closing;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _closing = true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach(KinectBaseSensor sensor in sensors.Items)
            {
                sensor.Dispose();
            }
        }

        private void sensors_SelectedIndexChanged(object sender, EventArgs e)
        {
            sensorControl1.Sensor = sensors.SelectedItem as KinectBaseSensor;
        }

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
