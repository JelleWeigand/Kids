using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    public GameObject gameobject;

    float deltaX, deltaY;

    bool moveAllowed = false;
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            // get touch
            Touch touch = Input.GetTouch(0);
            // touch position
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
            case TouchPhase.Began:
                if (gameobject.GetComponent<Collider2D>() == Physics2D.OverlapPoint (touchPos))
                {
                   

                    deltaX = touchPos.x - gameobject.transform.position.x;
                    deltaY = touchPos.y - gameobject.transform.position.y;

                    moveAllowed = true;
                }
                break;

            case TouchPhase.Moved:
                if (moveAllowed)
                {



                        Vector2 dxy = new Vector2(touch.deltaPosition.x, touch.deltaPosition.y);
                        float distance = Vector2.Distance(new Vector2(0,0),dxy)/(Time.deltaTime*1000);
                        
                        float speed = touch.deltaPosition.x ;
                        Debug.Log(speed);
                        gameobject.transform.Translate(new Vector3(touchPos.x - deltaX, touchPos.y - deltaY, 0f) * Time.deltaTime);
                    
                }
                break;

            case TouchPhase.Ended:
                    moveAllowed = false;
                break;

            }
        }
    }
}

