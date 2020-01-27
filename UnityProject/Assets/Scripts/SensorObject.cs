using UnityEngine;
using System;
using System.Runtime.InteropServices;
using KinectSDK20;

public class SensorObject : MonoBehaviour
{
    IKinectSensor _sensor;
    IDepthFrameReader _reader;
    Int32 _width;
    Int32 _height;
    long _lastTime;
    public Texture2D DepthTexture;
    Int16[] _depth;
    Color32[] _colors;

    public bool CopyTexture = true;

    // Update is called once per frame
    void Update()
    {
        if (_sensor == null)
        {
            kinect.GetDefaultKinectSensor(out _sensor).ThrowIfFailed();
            _sensor.Open().ThrowIfFailed();

            _sensor.get_DepthFrameSource(out IDepthFrameSource source).ThrowIfFailed();
            source.OpenReader(out _reader).ThrowIfFailed();

            source.get_FrameDescription(out IFrameDescription frameDesc).ThrowIfFailed();
            using (frameDesc)
            {
                frameDesc.get_Width(out _width).ThrowIfFailed();
                frameDesc.get_Height(out _height).ThrowIfFailed();
            }
        }

        var hr = _reader.AcquireLatestFrame(out IDepthFrame frame);
        if (hr != 0)
        {
            return;
        }

        using (frame)
        {
            frame.get_RelativeTime(out long relativeTime).ThrowIfFailed();
            if (relativeTime == _lastTime)
            {
                return;
            }
            _lastTime = relativeTime;

            if (DepthTexture == null)
            {
                DepthTexture = new Texture2D(
                    _width, _height, TextureFormat.ARGB32, false);
                DepthTexture.filterMode = FilterMode.Point;
                var length = _width * _height;
                _depth = new Int16[length];
                _colors = new Color32[length];
            }

            if (!CopyTexture)
            {
                return;
            }

            frame.AccessUnderlyingBuffer(out uint bufferSize, out IntPtr buffer).ThrowIfFailed();
            Marshal.Copy(buffer, _depth, 0, _depth.Length);
            for (int i = 0; i < _depth.Length; ++i)
            {
                var d = _depth[i];
                var b = (Byte)(UInt16)d;
                _colors[i] =
                new Color32(
                    b, b, b, 255
                );
            }
            DepthTexture.SetPixels32(_colors);
            DepthTexture.Apply();
        }
    }

    void OnApplicationQuit()
    {
        _reader?.Dispose();
        _sensor?.Dispose();
    }
}
