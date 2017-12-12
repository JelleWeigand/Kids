using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellController : MonoBehaviour {
    // public variables
    public Transform centre;
    public float turningSpeed = 1;
    public float radius = 2;
    //touch variables
    private Vector2 touchPos = new Vector2(0, 0);
    private float touchSpeed = 0f;
    private Vector2 relativeTouchPos = new Vector2(0, 0);
    private bool end = false;
    // handle variables
    private float z = 0f;
    private float distance = 0f;
    private float timer = 0f;


    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (distance > 300f)
        {
            end = true;
            timer += Time.deltaTime;
            if (timer > 1)
            {
                Application.LoadLevel("World1");
            }
        }

        z = Mathf.Abs(transform.eulerAngles.z);
        if (z > 180)
        {
            z -= 180;
            z = 180 - z;
        }

        // when you touch the screen
        if (Input.touchCount > 0)
        {
            touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            //initial touch
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
            }

            // end of touch
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
            }
            //during the touch
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                relativeTouchPos = new Vector2(touchPos.x - transform.position.x, touchPos.y - transform.position.y);
                touchSpeed = Input.GetTouch(0).deltaPosition.magnitude;
                float angle = Mathf.Atan2(relativeTouchPos.x, relativeTouchPos.y) * -180 / Mathf.PI;
                if (Mathf.Abs(Mathf.Abs(angle) - z) < 60)
                {
                    if (relativeTouchPos.magnitude < radius && !end)
                    {
                        transform.RotateAround(centre.position, Vector3.forward, touchSpeed * turningSpeed * Input.GetTouch(0).deltaTime);
                        distance += touchSpeed * Input.GetTouch(0).deltaTime;
                    }         
                }  
            }
        }
    }
}
