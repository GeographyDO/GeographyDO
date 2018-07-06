using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendControl : MonoBehaviour {

    public SkinnedMeshRenderer meshBall;
    public SkinnedMeshRenderer meshPlane;
    public SceneController sceneObj;

    void OnTriggerEnter(Collider other)
    {
        meshBall.SetBlendShapeWeight(0, 100);
        meshPlane.SetBlendShapeWeight(0, 100);
        meshBall.material.SetTextureOffset("_MainTex", Vector2.zero);
        sceneObj.isGround = true;
        sceneObj.canvasText.SetActive(false);
    }
    public void SetNull()
    {
        meshBall.SetBlendShapeWeight(0, 0);
        meshPlane.SetBlendShapeWeight(0, 0);
    }
}
