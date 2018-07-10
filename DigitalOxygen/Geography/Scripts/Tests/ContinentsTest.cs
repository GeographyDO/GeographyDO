using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinentsTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
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

 
    }
    public void WrongAnswer(GameObject obj)
    {
        obj.GetComponent<Renderer>().materials[0].color = new Color32(255, 163, 163, 255);
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
        

    }
}
