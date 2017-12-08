using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public static bool exit = false;
    public bool start = true;
    public float waitTime;
    public float waitTimeExit;
    public float zoomSpeed;

    private float startTime;
    private float endTime = 0;
    private GameObject cutOut;
    private float maxSize;
    // Use this for initialization
    void Start () {
        startTime = Time.time;
        cutOut = GameObject.Find("CutOut");
        maxSize = 2*Camera.main.orthographicSize*Mathf.Pow(Mathf.Pow(Camera.main.aspect,2)+1,0.5f)*3;

    }
	
	// Update is called once per frame
	void Update () {
        if(start) {
            if(Time.time > startTime + waitTime) {
                float x = (Time.time-startTime-waitTime)*zoomSpeed;
                if(x>maxSize) {
                    start = false;
                    x = maxSize;
                }
                cutOut.transform.localScale = new Vector3(x,x,1);
            }
        }
        if(exit) {
            if(endTime == 0) {
                endTime = Time.time;
            }
            if(Time.time>endTime+waitTimeExit) {
                float x = (Time.time-startTime-waitTime)*zoomSpeed;
                if(x>maxSize) {
                    start = false;
                    x = maxSize;
                }
                cutOut.transform.localScale = new Vector3(x,x,1);
            }
        }
        
		
	}
}
