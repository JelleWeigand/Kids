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

    public float pressSize;
    public float spinTime;
    public float initialSpeed;
    private float b;

	// Use this for initialization
	void Start () {
        speed = initialSpeed;
        b = 12*(360-initialSpeed/2);
        a = b/2-initialSpeed;
	}
	

	// Update is called once per frame
	void Update () {
        if(press&&!leave) {
            if(Input.GetTouch(0).phase == TouchPhase.Ended) {
                transform.localScale = transform.localScale * pressSize;
                press = false;
            }
        }



        if(play) {
            transform.Rotate(Vector3.forward * speed * Time.deltaTime );
            float x = (Time.time-startTime);
            speed += (a-b*x/spinTime)*Time.deltaTime;
        }
	}

    void OnMouseDown() {
        press = true;
        leave = false;
    }

    void OnMouseExit() {
        if(press) {
            leave = true;
            transform.localScale = transform.localScale * pressSize;
        }
    }
    void OnMouseEnter() {
        if(press) {
            leave = false;
            transform.localScale = transform.localScale / pressSize;
        }
    }

    void OnMouseUpAsButton() {
        transform.localScale = transform.localScale * pressSize;
        play = true;
        startTime= Time.time;
    }
}
