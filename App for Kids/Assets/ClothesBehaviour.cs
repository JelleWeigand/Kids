using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnMouseOver() {
        ClothesController.snap = true;
        ClothesController.snapObject = this.gameObject;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
