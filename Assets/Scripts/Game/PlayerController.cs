using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header("プレイヤーが1Pか2Pか"),Range(1,2)]
    public int playerSelector;

    GameObject cube;
    CharactorMotion cm;
    // Use this for initialization
    void Start () {
        cube = transform.Find("Cube").gameObject;
        cm = cube.GetComponent<CharactorMotion>();
    }
	
	// Update is called once per frame
	void Update () {
        if(InputConttoller.Charge(playerSelector))
        {
            if(cm.sphereScale<2)
            {
                cm.sphereScale += 0.05f;
                cm.cubeRotateSpeed += 0.5f;
            }
        }
        if(InputConttoller.Release(playerSelector))
        {
            cm.sphereScale = 0;
            cm.cubeRotateSpeed = 0.3f;
            transform.position += transform.forward * cm.sphereScale;
        }
    }
}
