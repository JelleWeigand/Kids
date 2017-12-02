using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapScript : MonoBehaviour {

    public float width;
    public float height;
    public Collider2D[] colliders;

    void Update()
    {
        colliders = Physics2D.OverlapBoxAll(new Vector2(transform.position.x, transform.position.y), new Vector2(width, height), 0f);

        foreach(Collider2D col in colliders)
        {
            // col.gameObject;
        }

    }
}
