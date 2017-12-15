using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenScript : MonoBehaviour {


    private bool play = false;
    private bool press = false;
    private bool leave = false;
    private float speed;
    private float startTime;
    private float a;
    private float b;
    private float c;
    private float diagonal;
    private GameObject mask;


    public float pressSize;
    public float spinTime;
    public float initialSpeed;
    

	// Use this for initialization
	void Start () {
        speed = initialSpeed;
        b = 360+2*initialSpeed;
        c = Mathf.PI+2*Mathf.Acos(1-initialSpeed/b);
        a = 0.5f;
        mask = GameObject.Find("Mask");
    }
	

	// Update is called once per frame
	void Update () {
        if(press&&!leave&&!play) {
            if(Input.GetTouch(0).phase == TouchPhase.Ended) {
                transform.localScale = transform.localScale * pressSize;
                press = false;
            }
        }



        if(play) {
            float x = (Time.time-startTime)/spinTime;
            transform.Rotate(Vector3.forward * b*Mathf.Cos(c*(x-a)) * Time.deltaTime );
            float scale = Mathf.Clamp(diagonal *1.1f -diagonal*1.1f*x,0,diagonal*1.1f);
            mask.transform.localScale = new Vector3(scale,scale,1);
            if(x>1) {
                Application.LoadLevel("World1");
            }

        }
	}

    void OnMouseDown() {
        press = true;
        leave = false;
    }

    void OnMouseExit() {
        if(press&&!play) {
            leave = true;
            transform.localScale = transform.localScale * pressSize;
        }
    }
    void OnMouseEnter() {
        if(press&&!play) {
            leave = false;
            transform.localScale = transform.localScale / pressSize;
        }
    }

    void OnMouseUpAsButton() {
        if(!play) {
            transform.localScale = transform.localScale * pressSize;
            diagonal = 2*Camera.main.orthographicSize  * Mathf.Pow(Mathf.Pow(Camera.main.aspect,2)+1,0.5f);
            Debug.Log(Camera.main.aspect);
            play = true;
            startTime= Time.time;
        }
    }
}
