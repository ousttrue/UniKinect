using UnityEngine;

public class KinectTextureToMaterial : MonoBehaviour
{
    public KinectSensor Kinect;
    public Material Target;

    bool _initialized;

    void Reset()
    {
        Kinect = GameObject.FindObjectOfType<KinectSensor>();
    }

    void OnEnable()
    {
        if (Kinect == null)
        {
            Debug.LogWarning("require SensorObject");
            gameObject.SetActive(false);
        }
        if (Target == null)
        {
            Debug.LogWarning("require target");
            gameObject.SetActive(false);
        }
    }

    void OnDisable()
    {
        _initialized = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_initialized)
        {
            return;
        }
        if (Kinect.DepthTexture == null)
        {
            return;
        }

        Target.mainTexture = Kinect.DepthTexture;
        _initialized = true;

        // resize
        var h = transform.localScale.y;
        var w = h * (float)Kinect.DepthTexture.width / Kinect.DepthTexture.height;
        transform.localScale = new Vector3(w, h, 1.0f);
    }
}
