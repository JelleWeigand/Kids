using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLeaveController : MonoBehaviour {
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        Physics2D.IgnoreLayerCollision(8, 8, true);
        rb = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
