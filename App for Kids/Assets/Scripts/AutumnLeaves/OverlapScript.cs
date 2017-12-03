using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapScript : MonoBehaviour {

    public float width;
    public float height;
    public Collider2D[] colliders;
    public bool[] index = new bool[10];

    private LeaveController[] leaveController = new LeaveController[10];


    void Update()
    {
        colliders = Physics2D.OverlapBoxAll(new Vector2(transform.position.x, transform.position.y), new Vector2(width, height), 0f);

 

        foreach (Collider2D col in colliders)
        {
            if (col.gameObject.GetComponent<LeaveController>() != null)
            {
                int j = (col.gameObject.GetComponent<LeaveController>()).ID;
                index[j] = true;
                Debug.Log(index[j]);
            }
            
        }
    }
}
