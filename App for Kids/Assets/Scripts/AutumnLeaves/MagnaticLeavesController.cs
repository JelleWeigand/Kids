using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnaticLeavesController : MonoBehaviour
{

    public GameObject[] leaves = new GameObject[7];
    public GameObject basket;
    public float radius;
    public int maxCarry;

    private Vector2 initialTap;
    private float screenRatio;
    private Vector2 touchPos = new Vector2(0, 0);
    private bool objectHit = false;
    // change the number if more leaves are added
    private float[] offsetx = new float[7];
    private float[] offsety = new float[7];
    private bool[] isFollow = new bool[7];
    private bool[] inBasket = new bool[7];
    private int followCount = 0;
    private LeaveController[] leaveController = new LeaveController[7];
    private OverlapScript overlapScript;
    private Collider2D[] colliders;


    // start
    void Start()
    {
        overlapScript = basket.GetComponent<OverlapScript>();

        for (int i = 0; i < leaves.Length; i++)
        {
            leaveController[i] = leaves[i].GetComponent<LeaveController>();
            isFollow[i] = false;
            inBasket[i] = false;
        }

        screenRatio = 2 * Camera.main.orthographicSize / Screen.height;
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
                initialTap = Input.GetTouch(0).position;

                colliders = Physics2D.OverlapCircleAll(new Vector2(touchPos.x, touchPos.y), radius);

                for (int i = 0; i < colliders.Length; i++)
                {
                    int j = (colliders[i].GetComponent<LeaveController>()).ID;

                    if (!inBasket[j])
                    {
                        offsetx[j] = (leaves[j].gameObject.transform.position.x - touchPos.x);
                        offsety[j] = (leaves[j].gameObject.transform.position.y - touchPos.y);
                        if (followCount < maxCarry)
                        {
                            isFollow[j] = true;
                            followCount++;
                        }
                    }
                }
            }

            //On the end of the first touch
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                
                for (int i = 0; i < colliders.Length; i++)
                {
                        int j = (colliders[i].GetComponent<LeaveController>()).ID;
                        isFollow[j] = false;
                        followCount = 0;
                    if (!inBasket[j])
                    {
                        if (overlapScript.index[j])
                        {
                            inBasket[j] = true;
                            Debug.Log("disable");
                            DisableRagdoll((leaves[j].GetComponent<Rigidbody2D>()));
                        } else
                        {
                            EnableRagdoll((leaves[j].GetComponent<Rigidbody2D>()));
                            Debug.Log("disable");
                        }

                    }   
                }       
            }

            //If the touch is moving
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                colliders = Physics2D.OverlapCircleAll(new Vector2(touchPos.x, touchPos.y), radius);

                for (int i = 0; i < colliders.Length; i++)
                {
                    int j = (colliders[i].GetComponent<LeaveController>()).ID;
                    DisableRagdoll((leaves[j].GetComponent<Rigidbody2D>()));
                    if (!inBasket[j])
                    {
                        if (isFollow[j] == false)
                        {
                            offsetx[j] = (leaves[j].gameObject.transform.position.x - touchPos.x);
                            offsety[j] = (leaves[j].gameObject.transform.position.y - touchPos.y);
                            if (followCount < maxCarry)
                            {
                                isFollow[j] = true;
                                followCount++;
                            }
                        }
                    }
                                    
                }

                for (int i = 0; i < leaves.Length; i++)
                {
                    if (!inBasket[i])
                    {
                        if (isFollow[i])
                        {
                            leaves[i].transform.position = new Vector3((touchPos.x + offsetx[i]), (touchPos.y + offsety[i]), 1);
                        }
                    }
                        
                }

            }
        }
    }

    void FixedUpdate()
    {
        for(int i = 0; i < leaves.Length; i++)
        {
            if (inBasket[i] == true)
            {
                MoveToBasket(i);
            }
        }
        
    }
    void MoveToBasket(int i)
    {
        if (leaves[i].transform.position.y > -10)
        {
            leaves[i].transform.Translate(Vector3.down *14 * Time.deltaTime);
        }
        
    }

    void DisableRagdoll(Rigidbody2D rb)
    {
        rb.isKinematic = true;
       
    }

    void EnableRagdoll(Rigidbody2D rb)
    {
        rb.isKinematic = false;
        // Debug.Log("enable");
    }

}
