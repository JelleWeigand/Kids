using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {
    //private variables
    private bool play = false;
    private float start;

    //public variables
    public float rotationSpeed;
	// Use this for initialization
	void Start () {
		
	}



    void OnMouseUpAsButton() {
        if(TouchControl.touchTap&&!play) {
            play = true;
            start = Time.time;
        }
    }
    // Update is called once per frame
    void Update () {
		if(play) {
            transform.Rotate(new Vector3(0,0,360*Time.deltaTime /rotationSpeed));
            if(Time.time > start + rotationSpeed) {
                play = false;
            }
        }
	}
}
