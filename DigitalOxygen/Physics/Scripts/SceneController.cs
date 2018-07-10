using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {

    public SkinnedMeshRenderer meshBall;
    public Rigidbody rigBall;
    public float offsetMaxDown = -0.3f;
    public float offsetMaxUp = 0.0f;
    Vector2 uvOffset = Vector2.zero;
    bool down = false;
    bool up = false;
    bool isTap = true;
    public bool isGround = false;
    public BlendControl blendObj;
    public GameObject canvasText;
    public Text textTask;
    public Text textPot;
    public Text textKin;
    public Text textUp;
    public Text textDown;
    public GameObject canvasTextInfo;
    public GameObject canvasTextInfo1;
    public Text textTask1;
    public Text textUp1;
    public Text textDown1;
    public GameObject canvasTextInfo2;
    public Text textTask2;
    public Text textUp2;
    public Text textDown2;
    public GameObject hand;
    public GameObject marks;
    public InteractiveMarks marksController;
    public GameObject testCross;
    public GameObject testCross1;
    public GameObject testCross2;

    private void Start()
    {
        InvokeRepeating("HandShowing", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {


        if ((Input.GetMouseButtonDown(0)) && isTap)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10000.0f))
            {
                if (hit.collider.gameObject.name == "ball")
                {
                    if (!isGround)
                    {
                        down = true;
                        rigBall.useGravity = true;
                    }
                    else
                    {
                        
                        up = true;
                        isGround = false;
                        uvOffset = new Vector3(0.0f, -0.3f);
                    }
                    isTap = false;
                    CancelInvoke();
                    canvasTextInfo.SetActive(false);
                    textUp.gameObject.SetActive(false);
                    hand.SetActive(false);

                }
            }

        }

        if (down)
        {
            if (uvOffset.y > offsetMaxDown)
            {
                uvOffset.y -= Time.deltaTime / 6f;
                meshBall.material.SetTextureOffset("_MainTex", uvOffset);
            }
            else
            {
                down = false;
                canvasTextInfo.SetActive(true);
                textDown.gameObject.SetActive(true);
               StartCoroutine(Wait());
            }
        }
        if (up)
        {
            if (uvOffset.y < offsetMaxUp)
            {
                uvOffset.y += Time.deltaTime / 6f;
                meshBall.material.SetTextureOffset("_MainTex", uvOffset);
                rigBall.gameObject.transform.Translate(Vector3.forward * Time.deltaTime * 15);
            }
            else
            {
                up = false;
                uvOffset = Vector2.zero;
                meshBall.material.SetTextureOffset("_MainTex", Vector2.zero);
                isTap = true;
                textKin.text = "E (к) = 0";
                textPot.text = "E (п) = x";
                Debug.Log("2234");
                InvokeRepeating("HandShowing", 2.0f, 2.0f);
                canvasTextInfo.SetActive(true);
                textUp.gameObject.SetActive(true);
            }
        }


    }

    public void TestInteractive()
    {
        canvasText.SetActive(true);
        textKin.enabled = false;
        textPot.enabled = false;
        rigBall.gameObject.SetActive(false);
        marks.SetActive(true);
        marksController.enabled = true;
        textTask.gameObject.SetActive(true);
        testCross.SetActive(true);
 
    }

    public void TestInteractiveStop()
    {
        textKin.enabled = true;
        textPot.enabled = true;
        rigBall.gameObject.SetActive(true);
        marks.SetActive(false);
        marksController.enabled = false;
        textTask.gameObject.SetActive(false);
        testCross.SetActive(false);
    }

    public void HandShowing()
    {
        if (hand.activeSelf)
            hand.SetActive(false);
        else
            hand.SetActive(true);
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(5.0f);
        rigBall.useGravity = false;
        textKin.text = "E (к) = x";
        textPot.text = "E (п) = 0";
        canvasText.SetActive(true);
        blendObj.SetNull();
        meshBall.material.SetTextureOffset("_MainTex", new Vector2(0.0f,-0.3f));
        meshBall.gameObject.transform.position = new Vector3(meshBall.gameObject.transform.position.x, meshBall.gameObject.transform.position.y + 0.4f, meshBall.gameObject.transform.position.z);
        isTap = true;
        canvasTextInfo.SetActive(false);
        textDown.gameObject.SetActive(false);
        InvokeRepeating("HandShowing", 2.0f, 2.0f);

    }
}
