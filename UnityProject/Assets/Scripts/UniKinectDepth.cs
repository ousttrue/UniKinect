using UnityEngine;
using System.Collections;
using UniKinect.Nui;
using System;
using System.Linq;
using System.Runtime.InteropServices;

public class UniKinectDepth : MonoBehaviour {

    KinectSensor _sensor;

    KinectImageStream _depthStream;

    public Texture2D DepthTexture;

	// Use this for initialization
	void Start () {
	}

    Int16[] _depth;

	// Update is called once per frame
	void Update () {
        if (_sensor == null)
        {
            _sensor = new UniKinect.Nui.KinectSensor();
            _depthStream = KinectImageStream.CreateDepthSteram(IntPtr.Zero);
        }

        using (var frame = _depthStream.GetFrame())
        {
            if(frame==null){
                return;
            }

            if (DepthTexture == null)
            {
                DepthTexture = new Texture2D(
                    _depthStream.Width, _depthStream.Height, TextureFormat.ARGB32, false);

                DepthTexture.filterMode = FilterMode.Point;

                _depth = new Int16[_depthStream.Width * _depthStream.Height];


                renderer.material.mainTexture = DepthTexture;
            }

            Marshal.Copy(frame.Rect.pBits, _depth, 0, _depth.Length);

            var pixel32s = _depth.Select((Int16 d) =>
            {
                var b = (Byte)(UInt16)d;
                return new Color32(
                    b, b, b, 255
                );
            }).ToArray();
            Debug.Log(pixel32s.Length);
            DepthTexture.SetPixels32(pixel32s);
            DepthTexture.Apply();           
        }
	}

    void OnApplicationQuit()
    {
        if (_sensor != null)
        {
            _sensor.Dispose();
            _sensor = null;
        }
    }
}
