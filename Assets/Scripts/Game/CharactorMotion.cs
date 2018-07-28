using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorMotion : MonoBehaviour {

    GameObject sphere;
    public float sphereScale = 0;
    public float cubeRotateSpeed = 0.3f;
	// Use this for initialization
	void Start () {
        sphere = transform.Find("Sphere").gameObject;

    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(cubeRotateSpeed, cubeRotateSpeed*0.8f, cubeRotateSpeed*0.3f));
        sphere.transform.localScale = new Vector3(sphereScale, sphereScale, sphereScale);
    }
}
