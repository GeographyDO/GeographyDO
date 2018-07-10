using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationController : MonoBehaviour {

    public GameObject landscape;
    public GameObject portrait;
    public SceneController controller;

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
                controller.canvasTextInfo = controller.canvasTextInfo1;
                controller.textTask = controller.textTask1;
                controller.textUp = controller.textUp1;
                controller.textDown = controller.textDown1;

            }
            portrait.SetActive(false);
        }
        else if (orientation == DeviceOrientation.Portrait || orientation == DeviceOrientation.PortraitUpsideDown)
        {
            if (!portrait.activeSelf)
            {
                portrait.SetActive(true);
                controller.canvasTextInfo = controller.canvasTextInfo2;
                controller.textTask = controller.textTask2;
                controller.textUp = controller.textUp2;
                controller.textDown = controller.textDown2;
            }
            landscape.SetActive(false);
        }
        else
        {
            if (!portrait.activeSelf)
            {
                portrait.SetActive(true);
                controller.canvasTextInfo = controller.canvasTextInfo2;
                controller.textTask = controller.textTask2;
                controller.textUp = controller.textUp2;
                controller.textDown = controller.textDown2;

            }
            landscape.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
