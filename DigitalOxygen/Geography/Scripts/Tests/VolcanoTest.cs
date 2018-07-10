using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoTest : MonoBehaviour {

    public BehaviourControllerState3 controller;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "wrong")
                {
                    Debug.Log(hit.transform.gameObject.name);
                    WrongAnswer(hit.transform.gameObject);

                }
                    
                else if (hit.transform.tag == "right")
                    RightAnswer(hit.transform.gameObject);
            }
        }
    }

    public void TestBegin()
    {
        controller.Reset();
        controller.earthAnim.enabled = false;
        controller.marks.SetActive(true);
        controller.titles.SetActive(false);
        controller.maskInside.SetActive(false);
        controller.maskOutside.SetActive(false);
        controller.section.SetActive(false);
        controller.lavaInside.gameObject.SetActive(false);
        controller.lavaOutside.gameObject.SetActive(false);
        controller.earthAnim.gameObject.GetComponent<Collider>().enabled = false;
        controller.textFields[5].SetActive(true);
    }

    public void WrongAnswer(GameObject obj)
    {
        obj.GetComponent<Renderer>().materials[0].color =  new Color32(255, 163, 163, 255);
        StartCoroutine(ResetColor(obj));
    }

    public void RightAnswer(GameObject obj)
    {
        obj.GetComponent<Renderer>().materials[0].color = new Color32(167, 255, 208, 255);
        StartCoroutine(Succeeded(obj));
    }

    IEnumerator ResetColor(GameObject obj)
    {
        yield return new WaitForSeconds(2.0f);
        obj.GetComponent<Renderer>().materials[0].color = new Color32(255, 255, 255, 255);
    }

    IEnumerator Succeeded(GameObject obj)
    {
        yield return new WaitForSeconds(2.0f);
        obj.GetComponent<Renderer>().materials[0].color = new Color32(255, 255, 255, 255);
        controller.titles.SetActive(true);
        controller.marks.SetActive(false);
        controller.lavaInside.gameObject.SetActive(true);
        controller.lavaOutside.gameObject.SetActive(true);
        controller.earthAnim.gameObject.GetComponent<Collider>().enabled = true;
        controller.Reset();
        controller.textFields[5].SetActive(false);

    }
}
