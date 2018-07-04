using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthBehaviour : MonoBehaviour {

    public BehaviourController controller;

	public void StartSinking()
    {
        controller.isSinkingStarted = true;
    }

    public void StartRising()
    {
        controller.isRisingStarted = true;
    }

    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}
