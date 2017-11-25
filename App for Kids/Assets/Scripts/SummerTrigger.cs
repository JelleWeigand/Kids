using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummerTrigger : MonoBehaviour {

    public GameObject zeroLayer;
    public GameObject leftBorder;
    public GameObject rightBorder;
    public float resetTimeSec;

    private float timer;
    private bool insideSeason;
    private bool isTriggered = false;
    private float x;
    private float tresholdL;
    private float tresholdR;

    // Update is called once per frame
    private void Start()
    {
        timer = 0f;
        insideSeason = false;
    }

    void Update () {

        x = zeroLayer.transform.position.x;
        tresholdL = leftBorder.transform.position.x;
        tresholdR = rightBorder.transform.position.x;
        // inside Season
        if (x > tresholdL && x < tresholdR)
        {
            insideSeason = true;
        } else
        {
            insideSeason = false;
            isTriggered = false;
        }
        // triggers all the triggers that only happen once when you're in a season
        // when you go out and in it triggers again after reset time
        if (insideSeason && timer <= 0 && !isTriggered)
        {
            timer = resetTimeSec;
            SeasonTriggerUnique();
            isTriggered = true;
        }
        // triggers all the triggers that happen every resetTime
        if (insideSeason && timer <= 0)
        {
            timer = resetTimeSec;
            SeasonTrigger();
            isTriggered = true;
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        
    }

    private void SeasonTriggerUnique ()
    {
        Debug.Log("hoi");
    }

    private void SeasonTrigger()
    {
        Debug.Log("hoi");
    }
}
