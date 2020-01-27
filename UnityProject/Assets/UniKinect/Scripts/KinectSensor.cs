using UnityEngine;
using System;
using System.Runtime.InteropServices;
using KinectSDK20;

public class KinectSensor : MonoBehaviour
{
    IKinectSensor _sensor;
    IDepthFrameReader _reader;
    Int32 _width;
    Int32 _height;
    long _lastTime;
    public Texture2D DepthTexture;
    Int16[] _depth;
    byte[] _rawTexture;
    public uint MinDepth;
    public uint MaxDepth;
    [Range(0.1f, 10.0f)]
    public float Factor = 255.0f / 1000;

    [Range(0, 800)]
    public uint DepthLimitCM = 800;

    public bool CopyTexture = true;
    const uint PLAYER_MASK = 0x7;
    const int PLAYER_MASK_WIDTH = 3;

    void OnValidate()
    {
        MaxDepth = 0;
    }

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
                    _width, _height, TextureFormat.BGRA32, false);
                DepthTexture.filterMode = FilterMode.Point;
                var length = _width * _height;
                _depth = new Int16[length];
                _rawTexture = new byte[length * 4];
            }

            if (!CopyTexture)
            {
                return;
            }

            // get depth buffer ptr
            frame.AccessUnderlyingBuffer(out uint bufferSize, out IntPtr ptr).ThrowIfFailed();
            // copy depth buffer to array
            Marshal.Copy(ptr, _depth, 0, _depth.Length);

            frame.get_DepthMinReliableDistance(out ushort min);
            frame.get_DepthMaxReliableDistance(out ushort max);

            MinDepth = ushort.MaxValue;
            // MaxDepth = 0;
            var span = MemoryMarshal.Cast<byte, uint>(_rawTexture.AsSpan());
            var p = 0;
            Factor = 1.0f / MaxDepth * 255;
            for (int i = 0; i < _depth.Length; ++i, p += 4)
            {
                var value = _depth[i];
                var player = value & PLAYER_MASK;
                var depth = (uint)(value >> PLAYER_MASK_WIDTH);
                if (depth > MaxDepth && depth < DepthLimitCM) MaxDepth = depth;
                else if (depth < MinDepth && depth > 0) MinDepth = depth;
                if (!float.IsInfinity(Factor))
                {
                    var intencity = (byte)(depth * Factor);
                    _rawTexture[p] = intencity;
                    _rawTexture[p + 1] = intencity;
                    _rawTexture[p + 2] = intencity;
                    _rawTexture[p + 3] = 255;
                }
                // span[i] = depth | 0xFF;
            }
            DepthTexture.LoadRawTextureData(_rawTexture);
            DepthTexture.Apply();
        }
    }

    void OnApplicationQuit()
    {
        _reader?.Dispose();
        _sensor?.Dispose();
    }
}
