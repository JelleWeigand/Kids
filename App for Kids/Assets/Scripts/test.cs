﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    public GameObject gameobject;

    private bool touchTap;
    private Vector2 initialTap;
    private float moveSpeed;
    private Vector2 moveDistance;
    private float screenRatio;
    private double moveTrashhold = 20;
    private Vector2 touchPos = new Vector2(0,0);
    private bool firsthit = false;
    private float timer = 0f;
    private float angle;

    // start
    void Start()
    {
        screenRatio = 2 * Camera.main.orthographicSize / Screen.height;
        moveDistance = new Vector2(0, 0);
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
                moveSpeed = 0;
                moveDistance = new Vector2(0, 0);
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
                    moveSpeed = (Input.GetTouch(0).deltaPosition.x / Time.deltaTime + moveDistance.x) / 2;
                }
            }

            //If the touch is moving
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                if (!firsthit)
                {
                    timer += Time.deltaTime;
                }
                
                if (timer >= 0.05f)
                {
                    firsthit = true;
                    timer = 0f;
                    angle = Mathf.Atan2(Input.GetTouch(0).position.y - initialTap.y, Input.GetTouch(0).position.x - initialTap.x) *180/Mathf.PI;

                    // Debug.Log(angle);
                    Quaternion target = Quaternion.Euler(0f, 0f, angle-90);
                    
                    gameobject.transform.rotation = target;
                }
                
                //Check if it is out of the margin
                if ((Input.GetTouch(0).position - initialTap).magnitude > moveTrashhold)
                {
                    touchTap = false;
                    moveDistance = Input.GetTouch(0).deltaPosition;

                }
                gameobject.transform.position = new Vector3(touchPos.x, touchPos.y, 0);
                // gameobject.transform.Translate(moveDistance.x * screenRatio, moveDistance.y * screenRatio, 0);
            }
        }   
    }
}
