using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveController : MonoBehaviour {

    public float threshold = -4.5f;
    public float fallspeed;
    private Transform basket;
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
        basket = (GameObject.Find("Basket")).transform;
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
            xFunction = Mathf.Sin(time * 2.5f)+y/3;

            if (y > threshold && !(y < -3.2 && x < basket.position.x + 2 && x > basket.position.x - 2))
            {
                transform.position = new Vector3(x + xFunction, y - 0.03f, z);
                transform.Rotate(Vector3.forward *50*xFunction* Time.deltaTime);
            }
        } else
        {
            x = transform.position.x;
            fall = true;
        }
        
    }
 
}
