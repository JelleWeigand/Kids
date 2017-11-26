using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour {
    //private variables
    private bool play = false;
    private bool up = true;
    private float left;
    private float right;
    private float x;
    private float start;
    private GameObject  position;
    private float fac;
    private float v;
    private float leap = 0f;

    //public variables
    public float curve;
    public float height;
    public float bump1;
    public float bump2;
    public float tranTime;
    public float gravity;
	// Use this for initialization
	void Start () {
        left = GameObject.Find("BorderLeft").transform.position.x;
        right = GameObject.Find("BorderRight").transform.position.x;
        position = GameObject.Find("PositionObject");
        fac = bump1 / Mathf.Pow((right-left)/2,curve);
        v = Mathf.Pow(gravity*bump2*2,0.5f);
    }

    void OnMouseUpAsButton() {
        if(TouchControl.touchTap&&!play) {
            play = true;
            up = !up;
            start = Time.time;
        }
    }
    
    // Update is called once per frame
    void Update () {
        if(play) {
            leap = (Time.time-start)*v-0.5f*gravity*Mathf.Pow((Time.time-start),2f);
            if (Time.time-start > tranTime) {
                play = false;
                if(up) {
                    leap = 0;
                }
                else {
                    leap = -100;
                }
            }
        }
        if(up||play) {
            x = position.transform.position.x;
            Vector3 pos = transform.position;
            pos[1] = height + bump1 - Mathf.Clamp(fac*Mathf.Pow((x-(right+left)/2),curve),0,bump1) + leap;
            transform.position = pos;
        }
    }
}
