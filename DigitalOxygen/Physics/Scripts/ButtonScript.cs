using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

    public TestPhysicsController controller;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void WrongAnswer()
    {
        this.gameObject.GetComponent<Button>().image.color = new Color32(255, 163, 163, 255);
        StartCoroutine(ResetColor());
    }
    IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(2.0f);
        this.gameObject.GetComponent<Button>().image.color = new Color32(255, 255, 255, 255);
    }
    public void RightAnswer()
    {
        this.gameObject.GetComponent<Button>().image.color = new Color32(167, 255, 208, 255);
        controller.RightAnswer();
    }
}
