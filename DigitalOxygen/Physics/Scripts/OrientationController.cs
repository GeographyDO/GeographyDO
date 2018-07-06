using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationController : MonoBehaviour {

    public GameObject landscape;
    public GameObject portrait;

	// Use this for initialization
	void Start ()
    {
        OrientationChangePhysic.OnOrientationChange += OrientationPlaneChange;
        OrientationPlaneChange(Input.deviceOrientation);
    }

    void OrientationPlaneChange(DeviceOrientation orientation)
    {
        Debug.Log("123");
        if (orientation == DeviceOrientation.LandscapeRight || orientation == DeviceOrientation.LandscapeLeft)
        {
            if (!landscape.activeSelf)
            {
                landscape.SetActive(true);

            }
            portrait.SetActive(false);
        }
        else if (orientation == DeviceOrientation.Portrait || orientation == DeviceOrientation.PortraitUpsideDown)
        {
            if (!portrait.activeSelf)
            {
                portrait.SetActive(true);
            }
            landscape.SetActive(false);
        }
        else
        {
            if (!portrait.activeSelf)
            {
                portrait.SetActive(true);

            }
            landscape.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
