using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesParrent : MonoBehaviour {
    public 
	// Use this for initialization
	void Start () {
		
	}
    void OnMouseDrag() {
        if (ClothesController.snap) {
            transform.position = new Vector3(ClothesController.snapObject.transform.position.x, ClothesController.snapObject.transform.position.y, transform.position.z);
            transform.rotation = ClothesController.snapObject.transform.rotation;
        }
        else {
            transform.position = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Debug.Log(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position));
            Debug.Log(Input.GetTouch(0).position);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
