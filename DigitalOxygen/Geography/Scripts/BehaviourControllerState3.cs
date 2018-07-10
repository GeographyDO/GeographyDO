using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourControllerState3 : MonoBehaviour {

    public GameObject exitBtn;
    public GameObject resetBtn1;
    public GameObject resetBtn2;

    public GameObject landscape;
    public GameObject portrait;
    public GameObject[] textFields1;
    public GameObject[] textFields2;
    public GameObject maskInside;
    public GameObject maskOutside;
    public GameObject section;
    //[HideInInspector]
    public GameObject[] textFields;
    public GameObject hand;
    public GameObject eruption;
    public bool isEventReady = false;
    public bool isUVStarted = false;
    private bool isInAction = false;
    public GameObject[] startpos;
    public int eventState;
    public Renderer lavaOutside;
    public Renderer lavaInside;
    public Texture magmaTexture;
    public Texture coldMagmaTexture;
    public float offset;
    public GameObject titles;
    public GameObject marks;
    public GameObject rocksExplosion;
   



    public Animator earthAnim;

    private void Start()
    {
        OrientationChange.OnOrientationChange += OrientationPlaneChange;
        OrientationPlaneChange(Input.deviceOrientation);
        earthAnim.enabled = true;
        startpos[0].transform.position = maskInside.transform.position;
        startpos[1].transform.position = maskOutside.transform.position;
    }

    private void Update()
    {
        if (isUVStarted)
        {
            MoveUV();
            Debug.Log("UV Started");
        }
            
        if (isInAction)
            hand.SetActive(false);
        if(isEventReady)
            if(Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "volcano")
                        StartEvent();
                }
            }
    }

    void ButtonResize1()
    {
        resetBtn1.GetComponent<RectTransform>().sizeDelta = exitBtn.GetComponent<RectTransform>().sizeDelta;
    }

    void ButtonResize2()
    {
        resetBtn2.GetComponent<RectTransform>().sizeDelta = new Vector2(exitBtn.GetComponent<RectTransform>().sizeDelta.x, exitBtn.GetComponent<RectTransform>().sizeDelta.y);
    }

    void OrientationPlaneChange(DeviceOrientation orientation)
    {
        if (orientation == DeviceOrientation.LandscapeRight || orientation == DeviceOrientation.LandscapeLeft)
        {
            Debug.Log("123");
            if (!landscape.activeSelf)
            {
                landscape.SetActive(true);
                for (int i = 0; i < 6; i++)
                {
                    textFields[i] = textFields1[i];
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
                for (int i = 0; i < 6; i++)
                {
                    textFields[i] = textFields2[i];
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
                for (int i = 0; i < 6; i++)
                {
                    textFields[i] = textFields2[i];
                }
                ButtonResize2();
            }
            landscape.SetActive(false);
        }
    }

    public void ReadyEvent(int currentEventState)
    {
        isInAction = false;
        eventState = currentEventState;
        if (eventState - 1 > 0)
            textFields[eventState - 1].SetActive(false);
        StartCoroutine(HandPointing());
        isEventReady = true;
        earthAnim.enabled = false;
        section.SetActive(false);
        textFields[eventState].SetActive(true);
    }

    public void StartEvent()
    {
        isInAction = true;
        textFields[eventState].SetActive(false);
        textFields[eventState + 1].SetActive(true);
        earthAnim.enabled = true;
        StopCoroutine(HandPointing());
        hand.SetActive(false);
    }

    public void FinalState()
    {
        //магма меняет цвет, рука перестает мигать
        lavaInside.materials[0].mainTexture = coldMagmaTexture;
        lavaOutside.materials[0].mainTexture = coldMagmaTexture;
        maskOutside.SetActive(false);
        isInAction = true;
        isUVStarted = false;
        earthAnim.enabled = false;
        
    }

    public void MoveUV()
    {
        offset = offset + 0.004f;
        if(lavaInside.materials[0].mainTexture != coldMagmaTexture)
            lavaInside.materials[0].SetTextureOffset("_MainTex", new Vector2(-offset, 0));
    }

    IEnumerator HandPointing()
    {
        while(isInAction == false)
        {
            yield return new WaitForSeconds(2.0f);
            if (hand.activeSelf)
                hand.SetActive(false);
            else
                hand.SetActive(true);
        }
    }

    public void Reset()
    {
        eruption.SetActive(false);
        titles.SetActive(true);
        eventState = 0;
        maskInside.SetActive(true);
        maskOutside.SetActive(true);
        maskInside.transform.position = startpos[0].transform.position;
        maskOutside.transform.position = startpos[1].transform.position;
        lavaInside.materials[0].mainTexture = magmaTexture;
        lavaOutside.materials[0].mainTexture = magmaTexture;
        earthAnim.enabled = true;
        earthAnim.Play("VolcanoAnim", -1, 0f);
        section.SetActive(true);
        rocksExplosion.SetActive(false);
        foreach(GameObject text in textFields)
        {
            text.SetActive(false);
        }
        ////continentAnim.enabled = false;
        //Invoke("EarthReset", 0.5f);
    }
    //public void EarthReset()
    //{
    //    earthAnim.enabled = false;
    //}

}
