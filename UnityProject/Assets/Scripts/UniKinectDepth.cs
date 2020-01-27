using UnityEngine;

public class UniKinectDepth : MonoBehaviour
{
    public SensorObject Kinect;
    bool _initialized;

    // Update is called once per frame
    void Update()
    {
        if (Kinect == null)
        {
            return;
        }
        if (_initialized)
        {
            return;
        }
        if (Kinect.DepthTexture == null)
        {
            return;
        }

        GetComponent<Renderer>().material.mainTexture = Kinect.DepthTexture;
        _initialized = true;
    }
}
