using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour {
    //private variables
    private bool play = false;
    private bool up = true;
    private float left;
    private float right;
    private float pos;
    private GameObject  position;
    private float fac;

    //public variables
    public float curve;
    public float height;
    public float bump1;
    public float bump2;
	// Use this for initialization
	void Start () {
        left = GameObject.Find("BorderLeft").transform.position.x;
        right = GameObject.Find("BorderRight").transform.position.x;
        position = GameObject.Find("PositionObject");
        fac = bump1 / Mathf.Pow((right-left)/2,curve);
    }

    void OnMouseUpAsButton() {
        if(TouchControl.touchTap&&!play) {
            play = true;
            up = !up;
        }
    }

    // Update is called once per frame
    void Update () {
        if(up) {
            
        }
    }
}
