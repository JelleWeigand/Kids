using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
    void OnMouseUpAsButton() {
        GameObject.Find("LevelController").GetComponent<LevelController>().Exit("BackButton");
        Debug.Log("Back Button Pressed");
    }

	// Update is called once per frame
	void Update () {
	
	}
}
