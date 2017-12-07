using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesManager : MonoBehaviour {

    public GameObject leave1;
    public GameObject leave2;
    public GameObject leave3;
    public Transform[] spawnPoints;
    public GameObject[] endPoints = new GameObject[11];
    public float radius;
    public Transform basket;
    public int maxCarry = 1;

    private GameObject[] leaves = new GameObject[11];
    private bool[] leaveIsTouch = new bool[11];
    private int isTouchCount = 0;
    private Vector2 initialTap;
    private Vector2 touchPos = new Vector2(0, 0);
    private Collider2D[] colliders;
    private int colLen = 0;
    private int score = 0;
    // Use this for initialization
    void Start () {
        for (int i = 0; i< spawnPoints.Length; i++)
        {
            if (i % 3 == 0)
            {
                leaves[i] = Instantiate(leave1, spawnPoints[i].position, spawnPoints[i].rotation);
            }
            if (i % 3 == 1)
            {
                leaves[i] = Instantiate(leave2, spawnPoints[i].position, spawnPoints[i].rotation);
            }
            if (i % 3 == 2)
            {
                leaves[i] = Instantiate(leave3, spawnPoints[i].position, spawnPoints[i].rotation);
            }
            leaveIsTouch[i] = false;
        }
        
	}

    void Update()
    {
        Debug.Log(isTouchCount);
        if (score >= 11)
        {
            Application.LoadLevel("World1");
        }

        if (Input.touchCount > 0)
        {
            touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            //On first finger start of touch
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                initialTap = Input.GetTouch(0).position;

                colliders = Physics2D.OverlapCircleAll(new Vector2(touchPos.x, touchPos.y), radius);
            }

            //On the end of the touch
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                for (int i = 0; i < colliders.Length; i++)
                {
                    colliders[i].gameObject.transform.position = new Vector3(touchPos.x, touchPos.y, 0f);
                }
                if (touchPos.x < basket.position.x + 3 && touchPos.x > basket.position.x - 2 &&
                    touchPos.y < basket.position.y + 5)
                {
                    for (int i = 0; i < leaves.Length; i++)
                    {
                        if (leaveIsTouch[i])
                        {
                            Destroy(leaves[i]);
                            endPoints[score].SetActive(true);
                            score += 1;
                           
                        }

                    }
                }
                for (int i = 0; i < leaves.Length; i++)
                {
                    leaveIsTouch[i] = false;
                }
                isTouchCount = 0;

            }
            //If the touch is moving
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                 colliders = Physics2D.OverlapCircleAll(new Vector2(touchPos.x, touchPos.y), radius);

                if (colliders.Length != colLen)
                {
                    for (int i = 0; i < colliders.Length; i++)
                    {
                        for(int j = 0; j < leaves.Length; j++)
                        {
                            if(colliders[i].gameObject == leaves[j])
                            {
                                if (isTouchCount < maxCarry && !leaveIsTouch[j])
                                {
                                    leaveIsTouch[j] = true;
                                    isTouchCount++;
                                }
                                
                            }
                        }
                    }
                }

                for (int i = 0; i < leaves.Length; i++)
                {
                    if (leaveIsTouch[i])
                    {
                        leaves[i].transform.position = new Vector3(touchPos.x, touchPos.y, -1f);
                    }
                    
                }

                colLen = colliders.Length;
            }
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
