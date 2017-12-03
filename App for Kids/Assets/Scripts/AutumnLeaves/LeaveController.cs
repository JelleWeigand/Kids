using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveController : MonoBehaviour {


    public int ID;
    private Rigidbody2D rb;
    private Vector2 vel;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        vel = rb.velocity;
        if(vel.y != 0)
        {

        }
    }
 
}
