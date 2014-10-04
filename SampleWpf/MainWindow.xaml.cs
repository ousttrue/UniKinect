using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UniKinect;
using UniKinect.V2PublicPreview;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;


namespace SampleWpf
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Gets the bitmap to display
        /// </summary>
        WriteableBitmap _depthSource;
        public ImageSource DepthSource
        {
            get { return _depthSource; }
        }

        KinectBaseSensor _sensor;

        public MainWindow()
        {
            var sensor = V2Sensor.GetDefault();
            _sensor = sensor;

#if true
            {
                // setup depth stream
                var depthStream = new V2DepthStream(sensor.Sensor);

                // create the bitmap to display
                _depthSource = new WriteableBitmap(
                    depthStream.Resolution.Width(),
                    depthStream.Resolution.Height(),
                    96.0, 96.0, PixelFormats.Gray16, null);

                var depthWaitHandle = new ManualResetEvent(false);
                depthWaitHandle.SafeWaitHandle = new Microsoft.Win32.SafeHandles.SafeWaitHandle(
                    depthStream.CreateWaitHandle(), false);

                StartUpdating(depthWaitHandle, depthStream);
            }
#endif

#if false
            {
                // setup image stream
                var imageStream = new V2ImageStream(sensor.Sensor);

                // create the bitmap to display
                DepthSource = new WriteableBitmap(
                    imageStream.Width,
                    imageStream.Height,
                    96.0, 96.0, PixelFormats.Bgr32, null);

                var waitHandle = new ManualResetEvent(false);
                waitHandle.SafeWaitHandle = new Microsoft.Win32.SafeHandles.SafeWaitHandle(
                    imageStream.CreateWaitHandle(), false);

                StartUpdating(waitHandle, imageStream);
            }
#endif

            InitializeComponent();
        }

        void StartUpdating(WaitHandle waitHandle, KinectBaseImageStream stream)
        {
            var task = waitHandle.WaitTask(Timeout.Infinite);
            task.ToObservable()
                .ObserveOnDispatcher()
                .SelectMany(_ => Observable.Using(
                    () => stream.GetFrame(waitHandle.Handle)
                        , frame => Observable.Return(frame))
                )
                .Where(frame => frame != null)
                .Subscribe(
                frame => _depthSource.WritePixels(
                        new Int32Rect(0, 0, frame.Width, frame.Height),
                        frame.Ptr,
                        frame.BufferSize,
                        frame.Pitch)
                , ex => {
                    Console.WriteLine(ex);
                    StartUpdating(waitHandle, stream);
                }
                , () => StartUpdating(waitHandle, stream)
                )
                ;
        }
    }
}
