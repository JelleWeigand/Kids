using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveController : MonoBehaviour {

    public float threshold = -4.5f;
    public float fallspeed;
    public bool fall = true;

    private float xFunction;
    private float x;
    private float z;
    private float y;
    private float time;
    // Use this for initialization
    void Start () {
        x = transform.position.x;
        z = transform.position.z;
    }
	
	// Update is called once per frame
	void Update () {

        if (transform.position.z != -1f)
        {
            if (fall)
            {
                time = 0f;
                fall = false;
            }
            time = time + Time.deltaTime;
            y = transform.position.y;
            xFunction = x + Mathf.Sin(time * 2.5f);

            if (y > threshold)
            {
                transform.position = new Vector3(xFunction, y - 0.03f, z);
            }
        } else
        {
            x = transform.position.x;
            fall = true;
        }
        
    }
 
}
