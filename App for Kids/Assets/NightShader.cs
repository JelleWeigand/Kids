using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightShader : MonoBehaviour {
    private SpriteRenderer sr;
	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update () {
        sr.color = new Color(0,0,0,SunScript.nightFac);
	}
}
