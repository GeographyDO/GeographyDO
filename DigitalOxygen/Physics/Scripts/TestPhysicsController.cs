using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPhysicsController : MonoBehaviour {

    public GameObject landscape;
    public GameObject portrait;
    public GameObject[] buttons;
    public GameObject test;
    public GameObject vr;
 
	// Use this for initialization
	void Start ()
    {
        OrientationChangePhysic.OnOrientationChange += OrientationPlaneChange;
        OrientationPlaneChange(Input.deviceOrientation);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OrientationStartBut()
    {
        OrientationPlaneChange(Input.deviceOrientation);
    }

    void OrientationPlaneChange(DeviceOrientation orientation)
    {
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

    public void RightAnswer()
    {
        StartCoroutine(CloseTest());

    }

    IEnumerator CloseTest()
    {
        yield return new WaitForSeconds(2.0f);
        foreach (GameObject button in buttons)
        {
            button.GetComponent<Button>().image.color = new Color32(255, 255, 255, 255);
        }

        vr.SetActive(true);
        portrait.SetActive(false);
        landscape.SetActive(false);
        test.SetActive(false);
    }

    public void TestQuit()
    {
        foreach (GameObject button in buttons)
        {
            button.GetComponent<Button>().image.color = new Color32(255, 255, 255, 255);
        }
        vr.SetActive(true);
        portrait.SetActive(false);
        landscape.SetActive(false);
        test.SetActive(false);
    }
}
