using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniKinect.V2PublicPreview;

namespace V2SampleForm
{
    public partial class Form1 : Form
    {
        IKinectSensor m_sensor;
        IColorFrameReader m_reader;

        public Form1()
        {
            InitializeComponent();

            m_sensor = Import.GetDefaultKinectSensor();
            m_sensor.Open();
            if (!m_sensor.get_IsOpen())
            {
                return;
            }

            var source = m_sensor.get_ColorFrameSource();
            m_reader = source.OpenReader();

            timer1.Tick+=OnTick;
            timer1.Interval = 100;
            timer1.Start();
        }

        Byte[] m_buffer;

        void OnTick(Object o, EventArgs e)
        {
            try
            {
                var frame = m_reader.AcquireLatestFrame();
                var descripton = frame.get_FrameDescription();
                var time = frame.get_RelativeTime();
                var width = descripton.get_Width();
                var height = descripton.get_Height();
                var imageFormat = frame.get_RawColorImageFormat();

                if (imageFormat == ColorImageFormat.ColorImageFormat_Bgra)
                {
                    Int32 nBufferSize;
                    IntPtr pBuffer = IntPtr.Zero;
                    frame.AccessRawUnderlyingBuffer(out nBufferSize, out pBuffer);
                }
                else
                {
                    if (m_buffer == null)
                    {
                        var bytesPerPixel=descripton.get_BytesPerPixel();
                        m_buffer = new Byte[width * height * 4];
                    }
                    frame.CopyConvertedFrameDataToArray(m_buffer.Length, m_buffer, ColorImageFormat.ColorImageFormat_Bgra);

                    var gch=GCHandle.Alloc(m_buffer, GCHandleType.Pinned);

                    var bitmap=new Bitmap(width, height, width*4, System.Drawing.Imaging.PixelFormat.Format32bppRgb, gch.AddrOfPinnedObject());
                    pictureBox1.Image = bitmap;

                    gch.Free();
                }

                Marshal.ReleaseComObject(descripton);
                Marshal.ReleaseComObject(frame);
            }
            catch (COMException ex)
            {
                if ((UInt32)ex.HResult == 0x8000000A)
                {

                }
                else
                {
                    Console.WriteLine(ex);
                }
            }
            finally
            {
            }
        }
    }
}
