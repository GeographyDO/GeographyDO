using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestController : MonoBehaviour
    {
    public Button buttonWrong;
    public Button buttonRight;
    public Text tastText;
    public GameObject testScene;
    public GameObject vRScene;

    public void WrongAnswer()
    {
        buttonWrong.image.color = new Color32(255, 163, 163, 255);
        StartCoroutine(ResetColor());
    }

    public void RightAnswer()
    {
        buttonRight.image.color = new Color32(167, 255, 208, 255);
        StartCoroutine(SwitchScenes());
    }


    IEnumerator SwitchScenes()
    {
        yield return new WaitForSeconds(2.0f);
        buttonRight.image.color = new Color32(255, 255, 255, 255);
        vRScene.SetActive(true);
        testScene.SetActive(false);
    }

    IEnumerator ResetColor()
    {
        
            yield return new WaitForSeconds(2.0f);
        buttonWrong.image.color = new Color32(255, 255, 255, 255);

    }
    
    public void ContentFill(int testNum)
    {
        if(testNum == 1)
        {
            tastText.text = "Из-за чего происходит  движение плит?";
            buttonWrong.GetComponentInChildren<Text>().text = "Из-за влияния  Луны на процессы, происходящие не Земле";
            buttonRight.GetComponentInChildren<Text>().text = "Из-за перемещения вещества в верхней мантии";
        }
        else
        {
            tastText.text = "Как были образованы Анды?";
            buttonWrong.GetComponentInChildren<Text>().text = "Сближением двух материковых кор";
            buttonRight.GetComponentInChildren<Text>().text = "Сближением океанической и материковой коры";
        }
    }


	}
