using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UniKinect.V2;


namespace V2Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var sensor =Import.GetDefaultKinectSensor();
            sensor.Open();
            if (!sensor.get_IsOpen())
            {
                return;
            }
            var source=sensor.get_ColorFrameSource();
            var reader=source.OpenReader();

            Console.WriteLine(reader);
        }
    }
}
