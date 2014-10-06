using System;
using System.Windows.Forms;
using UniKinect;


namespace SampleForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            try
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
            catch(DllNotFoundException)
            {
                // not installed
            }

            try
            {
                // v2
                foreach(UniKinect.V2PublicPreview.V2Sensor sensor in UniKinect.V2PublicPreview.V2Sensor.Enum())
                {
                    sensors.Items.Add(sensor);
                }
            }
            catch(EntryPointNotFoundException){
                // ?
                var sensor = UniKinect.V2PublicPreview.V2Sensor.GetDefault();
                if (sensor != null)
                {
                    sensors.Items.Add(sensor);
                }
            }
            catch(DllNotFoundException)
            {
                // not installed
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            sensorControl1.Sensor = null;
            foreach(KinectBaseSensor sensor in sensors.Items)
            {
                sensor.Dispose();
            }
            sensors.Items.Clear();
        }

        private void sensors_SelectedIndexChanged(object sender, EventArgs e)
        {
            sensorControl1.Sensor = sensors.SelectedItem as KinectBaseSensor;
        }
    }
}
