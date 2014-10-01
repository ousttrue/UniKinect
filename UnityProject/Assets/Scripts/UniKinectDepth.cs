using UnityEngine;
using System.Collections;
//using UniKinect.Nui;
using UniKinect.V2PublicPreview;
using System;
using System.Linq;
using System.Runtime.InteropServices;

public class UniKinectDepth : MonoBehaviour {

    IKinectSensor _sensor;

    V2DepthStream _depthStream;

    public Texture2D DepthTexture;

	// Use this for initialization
	void Start () {
	}

    Int16[] _depth;

	// Update is called once per frame
	void Update () {
        if (_sensor == null)
        {
            UniKinect.ComHelper.ThrowIfFailed(Import.GetDefaultKinectSensor(out _sensor));
            _sensor.Open();
            if (!_sensor.get_IsOpen())
            {
                _sensor = null;
                return;
            }

            _depthStream = new V2DepthStream(_sensor);
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

            Marshal.Copy(frame.Buffer, _depth, 0, _depth.Length);

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
            Marshal.ReleaseComObject(_sensor);
            _sensor = null;
        }
    }
}
