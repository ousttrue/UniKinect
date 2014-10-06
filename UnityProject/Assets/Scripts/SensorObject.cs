using UnityEngine;
using System.Collections;
using UniKinect.V2PublicPreview;
using UniKinect;
using System;
using System.Linq;
using System.Runtime.InteropServices;


public class SensorObject : MonoBehaviour {

    KinectBaseSensor _sensor;

    KinectBaseImageStream _depthStream;

    public Texture2D DepthTexture;

    Int16[] _depth;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
        if (_sensor == null)
        {
            var sensor = new V2Sensor();
            _depthStream = new V2DepthStream(sensor.Sensor);
            _sensor = sensor;
        }

        using (var frame = _depthStream.GetFrame())
        {
            if (frame == null)
            {
                return;
            }

            if (DepthTexture == null)
            {
                DepthTexture = new Texture2D(
                    _depthStream.Width, _depthStream.Height, TextureFormat.ARGB32, false);

                DepthTexture.filterMode = FilterMode.Point;

                _depth = new Int16[_depthStream.Width * _depthStream.Height];
            }

            Marshal.Copy(frame.Buffer, _depth, 0, _depth.Length);

            var pixel32s = _depth.Select((Int16 d) =>
            {
                var b = (Byte)(UInt16)d;
                return new Color32(
                    b, b, b, 255
                );
            }).ToArray();
            //Debug.Log(pixel32s.Length);
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
