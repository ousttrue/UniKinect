using UnityEngine;
using System.Collections;
using UniKinect;
//using UniKinect.Nui;
using UniKinect.V2PublicPreview;
using System;
using System.Linq;
using System.Runtime.InteropServices;

public class UniKinectDepth : MonoBehaviour {

    public SensorObject Kinect;
    bool _initialized;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
        if (Kinect == null)
        {
            return;
        }
        if (_initialized)
        {
            return;
        }
        if(Kinect.DepthTexture==null){
            return;
        }

        renderer.material.mainTexture = Kinect.DepthTexture;
        _initialized = true;
	}
}
