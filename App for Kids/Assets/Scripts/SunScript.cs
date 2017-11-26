using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour {
    //private variables
    private float left;
    private float right;
    private float x;
    private GameObject  position;
    private float fac;
    private float v;
    private float vend;
    private float leap = 0f;
    private float initialLeap;

    //public variables
    public float curve;
    public float height;
    public float bump1;
    public float bump2;
    public float tranTime;
    public float gravity;
    public static bool night = false;
    public static bool playSun = false;
    public static float startTimeSun;
    public bool sun;
    // Use this for initialization
    void Start () {
        left = GameObject.Find("BorderLeft").transform.position.x;
        right = GameObject.Find("BorderRight").transform.position.x;
        position = GameObject.Find("PositionObject");
        fac = bump1 / Mathf.Pow((right-left)/2,curve);
        v = Mathf.Pow(gravity*bump2*2,0.5f);
        vend = -v+gravity*tranTime;
        initialLeap = v*tranTime-0.5f*gravity*tranTime*tranTime;
    }

    void OnMouseUpAsButton() {
        if(TouchControl.touchTap&&!playSun) {
            playSun = true;
            night = !night;
            startTimeSun = Time.time;
        }
    }
    
    // Update is called once per frame
    void Update () {
        Debug.Log(playSun);
        if(playSun) {
            if(night ^ sun) {
                leap = (Time.time-startTimeSun)*v-0.5f*gravity*Mathf.Pow((Time.time-startTimeSun),2f);
                if(Time.time-startTimeSun > tranTime) {
                    playSun = false;
                    leap = initialLeap;
                }
            }
            else {
                leap = (Time.time-startTimeSun)*vend-0.5f*gravity*Mathf.Pow((Time.time-startTimeSun),2f)+initialLeap;
                if(Time.time-startTimeSun > tranTime) {
                    playSun = false;
                    leap = 0;
                }
            }
        }
        if((night^sun)||playSun) {
            x = position.transform.position.x;
            Vector3 pos = transform.position;
            pos[1] = height + bump1 - Mathf.Clamp(fac*Mathf.Pow((x-(right+left)/2),curve),0,bump1) + leap;
            transform.position = pos;
        }
    }
}
