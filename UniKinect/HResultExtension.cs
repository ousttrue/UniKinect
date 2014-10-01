using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniKinect
{
    static public class HResultExtension
    {
        public static void ThrowIfFail(this Int32 hr, String message="ComError")
        {
            if (hr == 0)
            {
                // S_OK
                return;
            }
            throw new System.Runtime.InteropServices.COMException(message, hr);
        }
    }
}
