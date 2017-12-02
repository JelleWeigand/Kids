using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RakeController : MonoBehaviour {

    public GameObject gameobject;
    public float swipeTreshold;

    private bool touchTap;
    private Vector2 initialTap;
    private float screenRatio;
    private Vector2 touchPos = new Vector2(0,0);
    private bool firsthit = false;
    private float angle;
    private float deltaY;
    private float deltaX;


    // start
    void Start()
    {
        screenRatio = 2 * Camera.main.orthographicSize / Screen.height;
        Debug.Log(screenRatio);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            //On first finger start of touch
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                touchTap = true;
                initialTap = Input.GetTouch(0).position;
                firsthit = false;
            }

            //On the end of the first touch
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                firsthit = false;
                //If the touch was a tap
                if (touchTap)
                {
                }

                //If the touch was not a tap
                else
                {
                }
            }

            //If the touch is moving
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                deltaY = Input.GetTouch(0).position.y - initialTap.y;
                deltaX = Input.GetTouch(0).position.x - initialTap.x;
                
                if (Vector2.Distance(new Vector2(0,0),new Vector2(deltaX,deltaY)) > swipeTreshold)
                {
                    if (!firsthit)
                    {
                        firsthit = true;
                        angle = Mathf.Atan2(deltaY, deltaX) * 180 / Mathf.PI;
                        Quaternion target = Quaternion.Euler(0f, 0f, angle - 90);
                        gameobject.transform.rotation = target;
                    }
                    gameobject.transform.position = new Vector3(touchPos.x, touchPos.y, 0);
                }
            }
        }   
    }
}
