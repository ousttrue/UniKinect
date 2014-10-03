using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SampleForm
{
    public static class BitmapExtensions
    {
        public static void SetPixels(this Bitmap bitmap, Byte[] buffer)
        {
            var data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height)
            , System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

            Marshal.Copy(buffer, 0, data.Scan0, buffer.Length);

            bitmap.UnlockBits(data);
        }
    }
}
