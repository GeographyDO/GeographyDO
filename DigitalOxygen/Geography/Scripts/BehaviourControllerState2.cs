using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourControllerState2 : MonoBehaviour {

    public GameObject exitBtn;
    public GameObject resetBtn1;
    public GameObject resetBtn2;

    public GameObject landscape;
    public GameObject portrait;
    public Animator continentAnim;
    public GameObject[] arrows;
    public GameObject[] stateTexts1;
    public GameObject[] stateTexts2;
    [HideInInspector]
    public GameObject[] stateTexts;
    public GameObject[] titles;
    public Renderer antarktida;

    public SkinnedMeshRenderer continentsShape;

    public bool isFourthStateStarted = false;
    public bool isEarlyStatesStarted;
    private bool isUVStarted;
    public float offset;

    public float timer;
    public float lastStateTimer = 3.0f;

    private float blendContinents = 0;

    // Use this for initialization
    void Start ()
    {
        antarktida.GetComponent<Renderer>();
        OrientationChange.OnOrientationChange += OrientationPlaneChange;
        OrientationPlaneChange(Input.deviceOrientation);
        stateTexts[0].SetActive(true);
        timer = 3.0f;
        isEarlyStatesStarted = true;
        titles[0].SetActive(true);
        titles[1].SetActive(true);

    }
	
	// Update is called once per frame
	void Update ()
    {
        TimeReset();

        if (isEarlyStatesStarted)
            timer -= Time.deltaTime;

        if (isFourthStateStarted)
            lastStateTimer -= Time.deltaTime;

    }

    void ButtonResize1()
    {
        Debug.Log("ResizeButt1");
        resetBtn1.GetComponent<RectTransform>().sizeDelta = exitBtn.GetComponent<RectTransform>().sizeDelta;
    }

    void ButtonResize2()
    {
        Debug.Log("ResizeButt2");
        resetBtn2.GetComponent<RectTransform>().sizeDelta = new Vector2(exitBtn.GetComponent<RectTransform>().sizeDelta.x, exitBtn.GetComponent<RectTransform>().sizeDelta.y);
    }


    void OrientationPlaneChange(DeviceOrientation orientation)
    {
        Debug.Log("123");
        if (orientation == DeviceOrientation.LandscapeRight || orientation == DeviceOrientation.LandscapeLeft)
        {
            if (!landscape.activeSelf)
            {
                landscape.SetActive(true);
                for(int i = 0; i < 4; i++)
                {
                    stateTexts[i] = stateTexts1[i];
                }
                ButtonResize1();
            }
            portrait.SetActive(false);
        }
        else if (orientation == DeviceOrientation.Portrait || orientation == DeviceOrientation.PortraitUpsideDown)
        {
            if (!portrait.activeSelf)
            {
                portrait.SetActive(true);
                for (int i = 0; i < 4; i++)
                {
                    stateTexts[i] = stateTexts2[i];
                }
                ButtonResize2();
            }
            landscape.SetActive(false);
        }
        else
        {
            if (!portrait.activeSelf)
            {
                portrait.SetActive(true);
                for (int i = 0; i < 4; i++)
                {
                    stateTexts[i] = stateTexts2[i];
                }
                ButtonResize2();
            }
            landscape.SetActive(false);
        }
    }


    public void SecondState()
    {
        foreach (GameObject arrow in arrows)
        {
            arrow.SetActive(false);
        }
        continentAnim.enabled = false;
        stateTexts[1].SetActive(true);
        timer = 3.0f;
        isUVStarted = true;
        titles[2].SetActive(true);
        titles[3].SetActive(true);

    }

    public void ThirdState()
    {
        foreach (GameObject arrow in arrows)
        {
            arrow.SetActive(false);
        }
        continentAnim.enabled = false;
        stateTexts[2].SetActive(true);
        timer = 3.0f;
        isFourthStateStarted = true;
        //isEarlyStatesStarted = false;
        //stateTexts[2].SetActive(true);
        //isFourthStateStarted = true;


    }

    public void FourthState()
    {
        continentAnim.enabled = false;
        stateTexts[3].SetActive(true);
        isFourthStateStarted = true;
        timer = 3.0f;
    }

    public void TimeReset()
    {
        if (timer < 0)
        {
            continentAnim.enabled = true;
            if (!isFourthStateStarted)
            {
                foreach (GameObject arrow in arrows)
                {
                    arrow.SetActive(true);
                }
                
            }
            foreach (GameObject text in stateTexts)
            {
                if (text.activeSelf)
                    text.SetActive(false);
            }

            foreach (GameObject title in titles)
            {
                if (title.activeSelf)
                    title.SetActive(false);
            }
            if(isUVStarted)
            {
                offset = offset + 0.002f;
                antarktida.materials[0].SetTextureOffset("_MainTex", new Vector2(0, offset));
                if (antarktida.materials[0].mainTextureOffset.y > 0.5f)
                    isUVStarted = false;
            }

        }
    }

    public void ResetEvent()
    {
        offset = 0;
        antarktida.materials[0].SetTextureOffset("_MainTex", new Vector2(0, 0));
        isUVStarted = false;
        timer = 3.0f;
        isFourthStateStarted = false;
        continentAnim.enabled = true;
        continentAnim.Play("earthAction", -1, 0f);
        //continentAnim.enabled = false;
        Invoke("EarthReset", 0.5f);
        
        stateTexts[0].SetActive(true);
    }

    public void EarthReset()
    {
        continentAnim.enabled = false;
    }
}
