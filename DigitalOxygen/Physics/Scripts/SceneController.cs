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
    public Text textPot;
    public Text textKin;

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

                }
            }

        }



        if (down)
        {
            if (uvOffset.y > offsetMaxDown)
            {
                uvOffset.y -= Time.deltaTime / 4f;
                meshBall.material.SetTextureOffset("_MainTex", uvOffset);
            }
            else
            {
                down = false;
               StartCoroutine(Wait());
            }
        }
        if (up)
        {
            if (uvOffset.y < offsetMaxUp)
            {
                uvOffset.y += Time.deltaTime / 4f;
                meshBall.material.SetTextureOffset("_MainTex", uvOffset);
                rigBall.gameObject.transform.Translate(Vector3.forward * Time.deltaTime * 4);
            }
            else
            {
                up = false;
                uvOffset = Vector2.zero;
                meshBall.material.SetTextureOffset("_MainTex", Vector2.zero);
                isTap = true;
                textKin.text = "E (к) = 0";
                textPot.text = "E (п) = x";
            }
        }


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

    }
}
