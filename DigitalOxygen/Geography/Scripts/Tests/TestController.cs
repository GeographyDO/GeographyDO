using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestController : MonoBehaviour
{

    public GameObject panelTestLandscape;
    public GameObject panelTestTwoLandscape;
    public GameObject panelTestThreeLandscape;
    public GameObject panelTestOnePortrait;
    public GameObject panelTestTwoPortrait;
    public GameObject panelTestThreePortrait;

    public Button buttonWrongOne;
    public Button[] buttonWrongTwo;
    public Button[] buttonwWrongThree;

    public Button buttonRightOne;
    public Button buttonRightTwo;
    public Button buttonRightThree;

    public Text tastTextOne;
    public Text tastTextTwo;
    public Text tastTextThree;
    public Text tastTextFour;

    public GameObject testScene;
    public GameObject vRScene;

    public GameObject landscape;
    public GameObject portrait;

    public Button buttonWrongOne1;
    public Button[] buttonWrongTwo1;
    public Button[] buttonwWrongThree1;

    public Button buttonRightOne1;
    public Button buttonRightTwo1;
    public Button buttonRightThree1;

    

    public Button buttonWrongOne2;
    public Button[] buttonWrongTwo2;
    public Button[] buttonwWrongThree2;

    public Button buttonRightOne2;
    public Button buttonRightTwo2;
    public Button buttonRightThree2;

    public Text tastTextOne1;
    public Text tastTextTwo1;
    public Text tastTextThree1;
      public Text tastTextFour1;

    public Text tastTextOne2;
    public Text tastTextTwo2;
    public Text tastTextThree2;
    public Text tastTextFour2;

    public int testNumber;

    public bool testStateOrientation;

    private void Awake()
    {
        OrientationChange.OnOrientationChange += OrientationPlaneChange;
        //OrientationPlaneChange(Input.deviceOrientation);
    }

    void OrientationPlaneChange(DeviceOrientation orientation)
    {
        if (orientation == DeviceOrientation.LandscapeRight || orientation == DeviceOrientation.LandscapeLeft)
        {
            if (!landscape.activeSelf)
            {
                
                landscape.SetActive(true);
                if (testNumber == 1 || testNumber ==2)
                {
                    panelTestLandscape.SetActive(true);
                    buttonRightOne = buttonRightOne1;
                    buttonWrongOne = buttonWrongOne1;
                    tastTextOne = tastTextOne1;
                    
                }
               if(testNumber == 3)
               {
                    panelTestTwoLandscape.SetActive(true);
                    buttonRightTwo = buttonRightTwo1;
                    for (int i = 0; i < buttonWrongTwo.Length; i++)
                    {
                        buttonWrongTwo[i] = buttonWrongTwo1[i];
                    }
                    tastTextTwo = tastTextTwo1;
                }
                if(testNumber == 4)
                {
                    panelTestThreeLandscape.SetActive(true);
                    buttonRightThree = buttonRightThree1;
                    for (int i = 0; i < buttonwWrongThree.Length; i++)
                    {
                        buttonwWrongThree[i] = buttonwWrongThree1[i];
                    }
                    tastTextThree = tastTextThree1;
                }
                ContentFill(testNumber);

            }
            portrait.SetActive(false);
        }
        else if (orientation == DeviceOrientation.Portrait || orientation == DeviceOrientation.PortraitUpsideDown)
        {
            if (!portrait.activeSelf)
            {
                portrait.SetActive(true);
                if (testNumber == 1 || testNumber == 2)
                {
                    panelTestOnePortrait.SetActive(true);
                    buttonRightOne = buttonRightOne2;
                    buttonRightOne.gameObject.SetActive(true);
                    buttonWrongOne = buttonWrongOne2;
                    tastTextOne = tastTextOne2;

                }
                if (testNumber == 3)
                {
                    panelTestTwoPortrait.SetActive(true);
                    buttonRightTwo = buttonRightTwo2;
                    for (int i = 0; i < buttonWrongTwo.Length; i++)
                    {
                        buttonWrongTwo[i] = buttonWrongTwo2[i];
                    }
                    tastTextTwo = tastTextTwo2;
                }
                if (testNumber == 4)
                {
                    panelTestThreePortrait.SetActive(true);
                    buttonRightThree = buttonRightThree2;
                    for (int i = 0; i < buttonwWrongThree.Length; i++)
                    {
                        buttonwWrongThree[i] = buttonwWrongThree2[i];
                    }
                    tastTextThree = tastTextThree2;
                }
                ContentFill(testNumber);
            }
            landscape.SetActive(false);
        }
        else
        {
            if (!portrait.activeSelf)
            {
                portrait.SetActive(true);
                if (testNumber == 1 || testNumber == 2)
                {
                    panelTestOnePortrait.SetActive(true);
                    buttonRightOne = buttonRightOne2;
                    buttonWrongOne = buttonWrongOne2;
                    tastTextOne = tastTextOne2;

                }
                if (testNumber == 3)
                {
                    panelTestTwoPortrait.SetActive(true);
                    buttonRightTwo = buttonRightTwo2;
                    for (int i = 0; i < buttonWrongTwo.Length; i++)
                    {
                        buttonWrongTwo[i] = buttonWrongTwo2[i];
                    }
                    tastTextTwo = tastTextTwo2;
                }
                if (testNumber == 4)
                {
                    panelTestThreePortrait.SetActive(true);
                    buttonRightThree = buttonRightThree2;
                    for (int i = 0; i < buttonwWrongThree.Length; i++)
                    {
                        buttonwWrongThree[i] = buttonwWrongThree2[i];
                    }
                    tastTextThree = tastTextThree2;
                }
                ContentFill(testNumber);
            }
            landscape.SetActive(false);
        }
    }

    public void RightAnswer()
    {
        StartCoroutine(SwitchScenes());
    }


    IEnumerator SwitchScenes()
    {
        yield return new WaitForSeconds(2.0f);
        if(testNumber == 1 || testNumber == 2)
        {
            buttonWrongOne.image.color = new Color32(255, 255, 255, 255);
            buttonRightOne.image.color = new Color32(255, 255, 255, 255);
        }
        else if(testNumber == 3)
        {
            foreach (Button button in buttonWrongTwo)
            {
                button.image.color = new Color32(255, 255, 255, 255);
            }
            buttonRightTwo.image.color = new Color32(255, 255, 255, 255);
        }
        else if(testNumber == 4)
        {
            foreach (Button button in buttonwWrongThree)
            {
                button.image.color = new Color32(255, 255, 255, 255);
                buttonRightThree.image.color = new Color32(255, 255, 255, 255);
            }
        }
        vRScene.SetActive(true);
        panelTestLandscape.SetActive(false);
        panelTestTwoLandscape.SetActive(false);
        panelTestThreeLandscape.SetActive(false);
        panelTestOnePortrait.SetActive(false);
        panelTestTwoPortrait.SetActive(false);
        panelTestThreeLandscape.SetActive(false);
        portrait.SetActive(false);
        landscape.SetActive(false);
        testScene.SetActive(false);
    }

    public void CloseTest()
    {
        if (testNumber == 1 || testNumber == 2)
        {
            buttonWrongOne.image.color = new Color32(255, 255, 255, 255);
            buttonRightOne.image.color = new Color32(255, 255, 255, 255);
        }
        else if (testNumber == 3)
        {
            foreach (Button button in buttonWrongTwo)
            {
                button.image.color = new Color32(255, 255, 255, 255);
            }
            buttonRightTwo.image.color = new Color32(255, 255, 255, 255);
        }
        else if (testNumber == 4)
        {
            foreach (Button button in buttonwWrongThree)
            {
                button.image.color = new Color32(255, 255, 255, 255);
                buttonRightThree.image.color = new Color32(255, 255, 255, 255);
            }
        }
        vRScene.SetActive(true);
        panelTestLandscape.SetActive(false);
        panelTestTwoLandscape.SetActive(false);
        panelTestThreeLandscape.SetActive(false);
        panelTestOnePortrait.SetActive(false);
        panelTestTwoPortrait.SetActive(false);
        panelTestThreeLandscape.SetActive(false);
        portrait.SetActive(false);
        landscape.SetActive(false);
        testScene.SetActive(false);
    }
    
    public void ContentFill(int testNum)
    {
        testNumber = testNum;
        OrientationPlaneChange(Input.deviceOrientation);
        StartCoroutine(Filling(testNum));
    }

    IEnumerator Filling(int testNum)
    {
        yield return new WaitForSeconds(1.0f);
        if (testNum == 1)
        {
            tastTextOne.text = "Из-за чего происходит  движение плит?";
            buttonWrongOne.GetComponentInChildren<Text>().text = "Из-за влияния  Луны на процессы, происходящие не Земле";
            buttonRightOne.GetComponentInChildren<Text>().text = "Из-за перемещения вещества в верхней мантии";
            testNumber = testNum;
        }
        else if (testNum == 2)
        {
            tastTextOne.text = "Как были образованы Анды?";
            buttonWrongOne.GetComponentInChildren<Text>().text = "Сближением двух материковых кор";
            buttonRightOne.GetComponentInChildren<Text>().text = "Сближением океанической и материковой коры";
            testNumber = testNum;
        }
        else if (testNum == 3)
        {
            tastTextTwo.text = "Cколько лет назад существовал всего один материк?";
            buttonWrongTwo[0].GetComponentInChildren<Text>().text = "250 млн.";
            buttonWrongTwo[1].GetComponentInChildren<Text>().text = "175 млн.";
            buttonWrongTwo[2].GetComponentInChildren<Text>().text = "130 млн.";
            buttonRightTwo.GetComponentInChildren<Text>().text = "200 млн.";
        }
        else if (testNum == 4)
        {
            tastTextThree.text = "Почему магма вырывается наружу?";
            buttonwWrongThree[0].GetComponentInChildren<Text>().text = "Из-за сближения материковых кор";
            buttonwWrongThree[1].GetComponentInChildren<Text>().text = "Из-за слишком большого количества накопленной магмы";
            buttonwWrongThree[2].GetComponentInChildren<Text>().text = "Из-за слабого атмосферного давления";
            buttonRightThree.GetComponentInChildren<Text>().text = "Из-за влияния содержащихся в магме газов";
        }
    }


}
