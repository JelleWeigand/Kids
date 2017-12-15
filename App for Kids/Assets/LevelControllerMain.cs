using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelControllerMain : MonoBehaviour {

    private float diagonal;
    private GameObject mask;
    private float startTime;

    public bool enter = false;
    public bool exit = false;
    public bool load = true;
    public float transitionTime;
    public float loadTime;


	// Use this for initialization
	void Start () {
        diagonal = 2*Camera.main.orthographicSize  * Mathf.Pow(Mathf.Pow(Camera.main.aspect,2)+1,0.5f);
        mask = GameObject.Find("Mask");
        mask.transform.localScale = new Vector3(0,0,1);
        startTime = Time.time;
        SceneManager.UnloadScene("StartScreen");
	}
	
	// Update is called once per frame
	void Update () {
        if(load) {
            if(Time.time-startTime > loadTime) {
                startTime = Time.time;
                enter = true;
                load = false;
            }
        }
        if(enter) {
            float x = (Time.time - startTime)/transitionTime;
            float scale = x*1.1f*diagonal;
            mask.transform.localScale = new Vector3(scale,scale,1);
            if(x>1) {
                enter = false;
            }
        }
		
	}
}
