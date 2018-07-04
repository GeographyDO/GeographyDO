using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinentBehaviour : MonoBehaviour
{

    public BehaviourControllerState2 controller;


    public void SecondStateEvent()
    {
        controller.SecondState();
    }

    public void ThirdStateEvent()
    {
        controller.ThirdState();
    }

    public void FourthStateEvent()
    {
        controller.FourthState();
    }
   
}
