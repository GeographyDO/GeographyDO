using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volcano : MonoBehaviour {

    public BehaviourControllerState3 controller;
    

	// Use this for initialization
	void Start () {
        RocksNoExplosion();
        controller.rocksExplosion.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //ожидание клика
    public void FirstState()
    {
        controller.ReadyEvent(0);
        controller.isUVStarted = true;

    }

    public void DisableTexts()
    {
    }
    public void SecondState()
    {
        controller.ReadyEvent(1);
    }

    public void ThirdState()
    {
        controller.ReadyEvent(2);
    }

    public void FourthState()
    {
        controller.ReadyEvent(3);
    }

    public void FifthState()
    {
        controller.FinalState();
    }

    public void EnableEruption()
    {
        controller.eruption.SetActive(true);
    }

    public void DisableEruption()
    {
        controller.eruption.SetActive(false);
        RocksNoExplosion();
    }

    public void DisableMaskInsiide()
    {
        controller.isUVStarted = false;
        controller.maskInside.SetActive(false);
    }

    public void RocksExplosion()
    {
        controller.rocksExplosion.SetActive(true);
        this.gameObject.GetComponent<Animator>().ResetTrigger("rocksPause");
        this.gameObject.GetComponent<Animator>().SetTrigger("rocksPlay");
        
    }

    public void RocksNoExplosion()
    {
        this.gameObject.GetComponent<Animator>().ResetTrigger("rocksPlay");
        this.gameObject.GetComponent<Animator>().SetTrigger("rocksPause");
         controller.rocksExplosion.SetActive(false);
    }
}
