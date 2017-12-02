using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveController : MonoBehaviour {

    public bool leaveHit = false;
    public int ID;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseDown()
    {
        leaveHit = true;
    }
    void OnMouseUp()
    {
        leaveHit = false;
    }
}
