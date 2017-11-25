using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummerTrigger : MonoBehaviour {

    public GameObject zeroLayer;
    public GameObject leftBorder;
    public GameObject rightBorder;
    public float timer;

    // Update is called once per frame
    private void Start()
    {
        timer = 0f;
    }

    void Update () {

        float x = zeroLayer.transform.position.x;
        float tresholdL = leftBorder.transform.position.x;
        float tresholdR = rightBorder.transform.position.x;

        if (x > tresholdL && x < tresholdR)
        {
            Debug.Log("hoi");
        } else
        {

        }
	}
}
