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
        Font _font = new Font("ＭＳ ゴシック", 12);

        IKinectSensor m_sensor;

        V2ImageStream m_imageStream;

        public Form1()
        {
            InitializeComponent();

            m_sensor = Import.GetDefaultKinectSensor();
            m_sensor.Open();
            if (!m_sensor.get_IsOpen())
            {
                return;
            }

            m_imageStream = new V2ImageStream(m_sensor);

            timer1.Tick+=OnTick;
            timer1.Interval = 100;
            timer1.Start();
        }


        Bitmap m_bitmap;
        Bitmap Convert(V2ImageFrame frame)
        {
            if (frame.Format == ColorImageFormat.ColorImageFormat_Bgra)
            {
                throw new NotImplementedException();
            }
            else
            {
                if (m_bitmap == null)
                {
                    m_bitmap = new Bitmap(frame.Width, frame.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                }
                var data=m_bitmap.LockBits(new Rectangle(0, 0, m_bitmap.Width, m_bitmap.Height)
                    , System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                frame.CopyConvertedFrameDataToArray(data.Stride * data.Height, data.Scan0);
                m_bitmap.UnlockBits(data);
                return m_bitmap;
            }

        }

        void OnTick(Object o, EventArgs e)
        {
            using (var frame = m_imageStream.GetFrame())
            {
                if (frame == null)
                {
                    return;
                }
                var bitmap = Convert(frame);

                // draw fps
                Graphics g = Graphics.FromImage(bitmap);
                RectangleF rect = new RectangleF(0, 0, 200, 60);
                g.DrawString(String.Format("{0}", m_imageStream.FPS), _font, Brushes.Yellow, rect)
                    ;
                pictureBox1.Image = bitmap;
            }
        }
    }
}
