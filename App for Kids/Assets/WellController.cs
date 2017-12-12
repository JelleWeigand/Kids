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
    private bool isPosGood = false;
    // handle variables
    private float z = 0f;


    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
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
                isPosGood = false;
            }
            //during the touch
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                relativeTouchPos = new Vector2(touchPos.x - transform.position.x, touchPos.y - transform.position.y);
                touchSpeed = Input.GetTouch(0).deltaPosition.magnitude;
                float angle = Mathf.Atan2(relativeTouchPos.x, relativeTouchPos.y) * -180 / Mathf.PI;
                Debug.Log(Mathf.Abs(Mathf.Abs(angle) - z));
                if (Mathf.Abs(Mathf.Abs(angle) - z) < 60)
                {
                    if (relativeTouchPos.magnitude < radius)
                    {
                        transform.RotateAround(centre.position, Vector3.forward, touchSpeed * turningSpeed * Input.GetTouch(0).deltaTime);
                    }         
                }  
            }
        }
    }
}
