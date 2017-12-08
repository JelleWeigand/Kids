using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClotheScript : MonoBehaviour {

    //private variables
    private bool pickup = false;
    private Vector3 staticPos;
    private Vector3 initialPos;
    private Quaternion staticRot;
    private Quaternion initialRot;
    private Ray snapCheck;
    private bool snap;

    public string type;

	// Use this for initialization
	void Start () {
        initialPos = transform.position;
        staticPos = initialPos;
        initialRot = transform.rotation;
        staticRot = initialRot;
    }
	
	// Update is called once per frame
	void Update () {
		if(pickup) {
            transform.position = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            transform.rotation = initialRot;
            snap = false;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            Debug.DrawRay(ray.origin,ray.direction*15);
            if(Physics.Raycast(ray,out hit)) {
                if(hit.collider.gameObject.name.Substring(1,hit.collider.gameObject.name.Length-1) == "snap."+this.gameObject.name.Substring(0,this.gameObject.name.Length-1)) {
                    if(ClothesController.clothes[type] == null) {
                        transform.position = hit.transform.position;
                        transform.rotation = hit.transform.rotation;
                        snap = true;
                    }
                }
            }
        }
        else {
            transform.position = staticPos;
            transform.rotation = staticRot;
        }
	}

    void OnMouseDown() {
        pickup = true;
        transform.localScale *= ClothesController.scale;
        if(gameObject == ClothesController.clothes[type]) {
            ClothesController.clothes[type] = null;
        }
    }

    void OnMouseUp() {
        transform.localScale /= ClothesController.scale;
        pickup = false;
        if(snap) {
            staticPos = transform.position;
            staticRot = transform.rotation;
            ClothesController.clothes[type] = gameObject;
        }
        else {
            staticPos = initialPos;
            staticRot = initialRot;
        }
    }
}
