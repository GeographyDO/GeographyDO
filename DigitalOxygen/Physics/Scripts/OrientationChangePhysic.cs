using System;
using System.Collections;
using UnityEngine;
 
public class OrientationChangePhysic : MonoBehaviour {

    public static event Action<DeviceOrientation> OnOrientationChange;
    public static float CheckDelay = 0.5f;        // How long to wait until we check again.

    static DeviceOrientation orientation;        // Current Device Orientation
    static bool isAlive = true;                    // Keep this script running?
 
    void Start() {
        StartCoroutine(CheckForChange());
    }
 
    IEnumerator CheckForChange(){

        orientation = Input.deviceOrientation;
 
        while (isAlive) {
 
            // Check for an Orientation Change
            switch (Input.deviceOrientation) {
                case DeviceOrientation.Unknown:            // Ignore
                case DeviceOrientation.FaceUp:            // Ignore
                case DeviceOrientation.FaceDown:        // Ignore
                    break;
                default:
                    if (orientation != Input.deviceOrientation) {
                        orientation = Input.deviceOrientation;
                        if (OnOrientationChange != null) OnOrientationChange(orientation);
                    }
                    break;
            }
 
            yield return new WaitForSeconds(CheckDelay);
        } 
    }
 
    void OnDestroy(){
        isAlive = false;
    }
 
}