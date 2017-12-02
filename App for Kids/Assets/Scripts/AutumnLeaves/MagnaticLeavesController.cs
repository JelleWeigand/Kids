using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnaticLeavesController : MonoBehaviour
{

    public GameObject[] leaves = new GameObject[7];
    public GameObject basket;
    public float radius;


    private bool touchTap;
    private Vector2 initialTap;
    private float screenRatio;
    private Vector2 touchPos = new Vector2(0, 0);
    private bool objectHit = false;
    // change the number if more leaves are added
    private float[] offsetx = new float[7];
    private float[] offsety = new float[7];
    private bool[] isFollow = new bool[7];
    private LeaveController[] leaveController = new LeaveController[7];
    private Collider2D[] colliders;

    // start
    void Start()
    {
        for (int i = 0; i < leaves.Length; i++)
        {
            leaveController[i] = leaves[i].GetComponent<LeaveController>();
            isFollow[i] = false;
        }
        screenRatio = 2 * Camera.main.orthographicSize / Screen.height;
    }


    // Update is called once per frame
    void OnMouseDown()
    {
        objectHit = true;
    }

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

                colliders = Physics2D.OverlapCircleAll(new Vector2(touchPos.x, touchPos.y), radius);

                for (int i = 0; i < colliders.Length; i++)
                {
                    int j = (colliders[i].GetComponent<LeaveController>()).ID;
                    
                    offsetx[j] = (leaves[j].gameObject.transform.position.x - touchPos.x);
                    offsety[j] = (leaves[j].gameObject.transform.position.y - touchPos.y);
                    isFollow[j] = true;
                }
            }

            //On the end of the first touch
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                //If the touch was a tap
                if (touchTap)
                {
                }

                //If the touch was not a tap
                else
                {
                }

                for (int i = 0; i < colliders.Length; i++)
                {
                    int j = (colliders[i].GetComponent<LeaveController>()).ID;
                    isFollow[j] = false;
                }
            }

            //If the touch is moving
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                colliders = Physics2D.OverlapCircleAll(new Vector2(touchPos.x, touchPos.y), radius);

                for (int i = 0; i < colliders.Length; i++)
                {
                    int j = (colliders[i].GetComponent<LeaveController>()).ID;

                    if (isFollow[j] == false)
                        {
                            offsetx[j] = (leaves[j].gameObject.transform.position.x - touchPos.x);
                            offsety[j] = (leaves[j].gameObject.transform.position.y - touchPos.y);
                            Debug.Log(j);
                            isFollow[j] = true;
                        }
                    
                    leaves[j].transform.position = new Vector3(touchPos.x + offsetx[j]/2, touchPos.y + offsety[j]/2, 0);       
                }
            }
        }
    }
}
