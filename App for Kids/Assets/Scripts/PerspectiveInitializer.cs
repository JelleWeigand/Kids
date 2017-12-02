using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveInitializer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		foreach( TouchControl.Layers l in TouchControl.layers) {
            foreach(Transform child in l.l.transform) {
                Debug.Log(child);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
