using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;


namespace ContoursUtil
{
    public static class Import
    {

        [DllImport("ContoursUtil")]
        public static extern IntPtr ContoursDetector_Create();

        [DllImport("ContoursUtil")]
        public static extern void ContoursDetector_Destroy(IntPtr detector);

        [DllImport("ContoursUtil")]
        public static extern int ContoursDetector_Find(IntPtr detector
            , IntPtr data, int w, int h);

        [DllImport("ContoursUtil")]
        [return: MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
        public static extern int[] ContoursDetector_GetPoints(IntPtr detector, int contour_index, out int pointCount);
    }
}