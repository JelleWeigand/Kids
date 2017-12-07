using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesManager : MonoBehaviour {

    public GameObject leave;
    public Transform[] spawnPoints;
    public float radius;
    public Transform basket;

    private GameObject[] leaves = new GameObject[5];
    private bool[] leaveIsTouch = new bool[5];
    private Vector2 initialTap;
    private Vector2 touchPos = new Vector2(0, 0);
    private Collider2D[] colliders;
    private int colLen = 0;
    private int score = 0;
    // Use this for initialization
    void Start () {
        for (int i = 0; i< spawnPoints.Length; i++)
        {
            leaves[i] = Instantiate(leave, spawnPoints[i].position, spawnPoints[i].rotation);
            leaveIsTouch[i] = false;
        }
        
	}

    void Update()
    {
        if (score >= 5)
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
                if (touchPos.x < basket.position.x + 5 && touchPos.x > basket.position.x - 5)
                {
                    for (int i = 0; i < leaves.Length; i++)
                    {
                        if (leaveIsTouch[i])
                        {
                            Destroy(leaves[i]);
                            score += 1;
                        }

                    }
                }
                for (int i = 0; i < leaves.Length; i++)
                {
                    leaveIsTouch[i] = false;
                }
                

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
                                leaveIsTouch[j] = true;
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
