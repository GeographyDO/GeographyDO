using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Playables;

public class VufiraTargetTracker : MonoBehaviour, ITrackableEventHandler {

    protected TrackableBehaviour mTrackableBehaviour;
    public GameObject onTrackingFound;
    public GameObject onTrackingLost;
    public GameObject controller;
    public GameObject vulcan;

    // Use this for initialization
    void Start () {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {   if(!vulcan.activeSelf)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                onTrackingFound.SetActive(true);
                onTrackingLost.SetActive(false);
                //controller.pd.enabled = true;
                if (controller.GetComponent<Animator>() != null)
                {
                    controller.GetComponent<Animator>().enabled = true;
                    controller.SetActive(true);

                }
                else
                    controller.SetActive(true);

            }
            else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                     newStatus == TrackableBehaviour.Status.NOT_FOUND)
            {
                onTrackingLost.SetActive(true);
                onTrackingFound.SetActive(false);
                //controller.pd.enabled = true;
                if (controller.GetComponent<Animator>() != null)
                {
                    controller.GetComponent<Animator>().enabled = false;
                    controller.SetActive(false);
                }

                else
                    controller.SetActive(false);
            }
            else
            {
                onTrackingLost.SetActive(true);
                onTrackingFound.SetActive(false);
                //controller.pd.enabled = true;
                if (controller.GetComponent<Animator>() != null)
                {
                    controller.GetComponent<Animator>().enabled = false;
                    controller.SetActive(false);
                }

                else
                    controller.SetActive(false);

            }
        }
        

    }
}
