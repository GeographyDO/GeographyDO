using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinentsTest : MonoBehaviour {

    public GameObject continents;
    public BehaviourControllerState2 controller;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if(!controller.stateTexts[4].activeSelf)
            controller.stateTexts[4].SetActive(true);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "SouthAmerica")
                {
                    RightAnswer(0);
                }
                else if (hit.transform.name == "Eurasia")
                    RightAnswer(1);
                else if (hit.transform.name == "NorthAmerica")
                    WrongAnswer(2, hit.transform.gameObject);
                else if (hit.transform.name == "Australia")
                    WrongAnswer(3, hit.transform.gameObject);
                else if (hit.transform.name == "Africa")
                    WrongAnswer(4, hit.transform.gameObject);
                else if (hit.transform.name == "Arktic")
                    ArcticAnswer();
            }
        }
    }

    public void TestBegin()
    {
        controller.continentAnim.SetTrigger("StartTest");
        foreach (GameObject arrow in controller.arrows)
        {
            arrow.SetActive(false);  
        }
        
        

    }


    public void WrongAnswer(int num, GameObject obj)
    {
        Debug.Log("NAAAAAAME = ");
        continents.GetComponent<SkinnedMeshRenderer>().materials[num].color = Color.red;
        StartCoroutine(ResetColor(num, obj));

    }

    public void ArcticAnswer()
    {

    }

    public void RightAnswer(int num)
    {
        continents.GetComponent<SkinnedMeshRenderer>().materials[num].color = Color.green;

    }

    IEnumerator ResetColor(int num, GameObject obj)
    {
        yield return new WaitForSeconds(2.0f);
        continents.GetComponent<SkinnedMeshRenderer>().materials[num].color = new Color32(255, 255, 255, 255);
    }

    IEnumerator Succeeded(GameObject obj)
    {
        yield return new WaitForSeconds(2.0f);
        obj.GetComponent<Renderer>().materials[0].color = new Color32(255, 255, 255, 255);
        

    }
}
