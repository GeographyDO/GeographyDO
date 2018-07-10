using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class BehaviourController : MonoBehaviour {

    private GameObject textRising, textSinking, btnRising, btnSinking, handSinking, handRising;

    public Button exitBtn;
    public Button resetBtn1;
    public Button resetBtn2;

    public GameObject earthSection;
    public GameObject textRising1;//
    public GameObject textSinking1; //
    public GameObject btnRising1; //
    public GameObject btnSinking1; //
    public GameObject textRising2;//
    public GameObject textSinking2; //
    public GameObject btnRising2; //
    public GameObject btnSinking2; //
    public GameObject mid;
    public GameObject oj;
    public GameObject ands;
    public GameObject handSinking1;
    public GameObject handRising1;
    public GameObject handSinking2;
    public GameObject handRising2;//
    public GameObject portrait;
    public GameObject landscape;
    public GameObject lookAtLeft;
    public GameObject lookAtRight;

    public Text debugText; 


    public Animator animator;

    public SkinnedMeshRenderer earth;
    public SkinnedMeshRenderer arrowSinking;
    public SkinnedMeshRenderer arrowRising;
	public SkinnedMeshRenderer uvEarth;
	public SkinnedMeshRenderer uvEarthMid;
    public Animator sectionAnimator;
    public PlayableDirector pdEarth;

    public bool isRisingStarted = false;
    public bool isSinkingStarted = false;
    public bool testStateOrientation;

    [SerializeField]
    private bool isOnRight = true;
    [SerializeField]
    private bool isOnLeft = false;

    private float blendSinking = 0f;
    private float blendRising = 0f;
    private float textTimer = 7.0f;
    private float blendSpeed = 0.7f;

    public int counter;

	public Vector2 uvAnimationRate = new Vector2( 1.0f, 0.0f );
	Vector2 uvOffset = Vector2.zero;
    

	// Use this for initialization
	void Start ()
    {
        animator.enabled = false;
        OrientationChange.OnOrientationChange += OrientationPlaneChange;
        OrientationPlaneChange(Input.deviceOrientation);
        Invoke("SectionAnim", 2);
    }
	
	// Update is called once per frame
	void Update () {

		if (isRisingStarted) 
		{
			BlendRising();

		}

            
		if (isSinkingStarted) 
		{
			
			BlendSinking();
		}
            
            

	}

    void ButtonResize1()
    {
        Debug.Log("ResizeButt1");
        resetBtn1.GetComponent<RectTransform>().sizeDelta = exitBtn.GetComponent<RectTransform>().sizeDelta;
    }

    void ButtonResize2()
    {
        Debug.Log("ResizeButt2");
        resetBtn2.GetComponent<RectTransform>().sizeDelta = new Vector2(exitBtn.GetComponent<RectTransform>().sizeDelta.x, exitBtn.GetComponent<RectTransform>().sizeDelta.y) ;
    }

    void UVMove (float scale, float scaleMid)
	{
		uvOffset += (0.3f *uvAnimationRate * Time.deltaTime );
		uvEarth.materials [0].SetTextureOffset ("_MainTex", scale * uvOffset);
		uvEarthMid.materials [0].SetTextureOffset ("_MainTex", scaleMid * uvOffset);

	}

    void OrientationPlaneChange(DeviceOrientation orientation)
    {
        if (orientation == DeviceOrientation.LandscapeRight || orientation == DeviceOrientation.LandscapeLeft || testStateOrientation == true)
        {
            if (!landscape.activeSelf)
            {
                landscape.SetActive(true);
                textSinking = textSinking1;
                textRising = textRising1;
                btnSinking = btnSinking1;
                btnRising = btnRising1;
                handSinking = handSinking1;
                handRising = handRising1;
                ButtonResize1();
            }
            portrait.SetActive(false);
        }
        else if (orientation == DeviceOrientation.Portrait || orientation == DeviceOrientation.PortraitUpsideDown)
        {
            if (!portrait.activeSelf)
            {
                portrait.SetActive(true);
                textSinking = textSinking2;
                textRising = textRising2;
                btnSinking = btnSinking2;
                btnRising = btnRising2;
                handSinking = handSinking2;
                handRising = handRising2;
                ButtonResize2();
            }
            landscape.SetActive(false);
        }
        else
        {
            if (!portrait.activeSelf)
            {
                portrait.SetActive(true);
                textSinking = textSinking2;
                textRising = textRising2;
                btnSinking = btnSinking2;
                btnRising = btnRising2;
                handSinking = handSinking2;
                handRising = handRising2;
                ButtonResize2();
            }
            landscape.SetActive(false);
        }
    }

    public void EarthRoundLeft()
    {
        btnSinking.SetActive(false);
        textTimer = 7.0f;
        if (isOnRight)
        {
            animator.enabled = true;
            animator.SetTrigger("turnLeft");
            animator.ResetTrigger("turnRight");
            isOnLeft = true;
            isOnRight = false;
        }
        else
            isSinkingStarted = true;       
    }

    public void EarthRoundRight()
    {
        btnRising.SetActive(false);
        textTimer = 7.0f;
        if (isOnLeft)
        {
            animator.SetTrigger("turnRight");
            animator.ResetTrigger("turnLeft");
            isOnRight = true;
            isOnLeft = false;
        }
        else
            isRisingStarted = true;
            
    }

    public void HandSinkingTimer()
    {
        if (handSinking.activeSelf)
            handSinking.SetActive(false);
        else
            handSinking.SetActive(true);
        counter++;
    }

    public void HandRisingTimer()
    {
        if (handRising.activeSelf)
            handRising.SetActive(false);
        else
            handRising.SetActive(true);
        counter++;
    }

    public void SectionAnim()
    {
        sectionAnimator.enabled = true;
        InvokeRepeating("HandSinkingTimer", 2.0f, 2.0f);
    }

    public void BlendRising()
    {
        arrowRising.gameObject.SetActive(true);
        textRising.SetActive(true);
        btnSinking.SetActive(false);
        textTimer -= Time.deltaTime;
        mid.SetActive(true);
        CancelInvoke("HandRisingTimer");
        handRising.SetActive(false);

        if (textTimer < 0)
        {
            textRising.SetActive(false);
            btnSinking.SetActive(true);
            isRisingStarted = false;
            
        }
            
        
        if(blendRising < 100f)
        {
			earth.SetBlendShapeWeight (0, blendRising);
			uvEarthMid.gameObject.GetComponent<SkinnedMeshRenderer> ().SetBlendShapeWeight (0, blendRising);
			uvEarth.gameObject.GetComponent<SkinnedMeshRenderer> ().SetBlendShapeWeight (0, blendRising);
            arrowRising.SetBlendShapeWeight(0, blendRising);
            blendRising += blendSpeed;
			UVMove (-1, -1);
			animator.gameObject.GetComponent<AudioSource> ().enabled = true;
        }
		else
			animator.gameObject.GetComponent<AudioSource> ().enabled = false;
    }

    public void BlendSinking()
    {
        arrowSinking.gameObject.SetActive(true);
        textSinking.SetActive(true);
        textTimer -= Time.deltaTime;
        btnRising.SetActive(false);
        ands.SetActive(true);
        oj.SetActive(true);
        CancelInvoke("HandSinkingTimer");
        handSinking.SetActive(false);

        if (textTimer < 0)
        {
            textSinking.SetActive(false);
            btnRising.SetActive(true);
            isSinkingStarted = false;
            InvokeRepeating("HandRisingTimer", 2.0f, 2.0f);
        }

        if (blendSinking < 100f)
        {
            earth.SetBlendShapeWeight(1, blendSinking);
            arrowSinking.SetBlendShapeWeight(0, blendSinking);
            blendSinking += blendSpeed;
			UVMove (1, -1);
			animator.gameObject.GetComponent<AudioSource> ().enabled = true;
        }
		else
			animator.gameObject.GetComponent<AudioSource> ().enabled = false;
    }

    public void RestartEvent()
    {
        earth.SetBlendShapeWeight(0, 0);
        earth.SetBlendShapeWeight(1, 0);
        arrowRising.SetBlendShapeWeight(0, 0);
        arrowSinking.SetBlendShapeWeight(0, 0);
		uvEarth.gameObject.GetComponent<SkinnedMeshRenderer> ().SetBlendShapeWeight (0, 0);
		uvEarthMid.gameObject.GetComponent<SkinnedMeshRenderer> ().SetBlendShapeWeight (0, 0);
        oj.SetActive(false);
        ands.SetActive(false);
        mid.SetActive(false);
        isSinkingStarted = false;
        isRisingStarted = false;
        blendRising = 0;
        blendSinking = 0;
        arrowSinking.gameObject.SetActive(false);
        arrowRising.gameObject.SetActive(false);
        textSinking.SetActive(false);
        textRising.SetActive(false);
        btnRising.SetActive(true);
        btnSinking.SetActive(true);
        InvokeRepeating("HandSinkingTimer", 2.0f, 2.0f);
    }
}
