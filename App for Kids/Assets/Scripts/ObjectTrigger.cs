using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour
{

    public GameObject positionObject;
    public float leftx;
    public float rightx;
    public float resetTimeSec;
    public bool isUnique;
    public bool isSound;
    public AudioSource sound;


    private float timer;
    private bool insideSeason;
    private bool isTriggered = false;
    private float x;

    // Update is called once per frame
    private void Start()
    {
        timer = 0f;
        insideSeason = false;
    }

    void Update()
    {

        x = positionObject.transform.position.x;
        // inside Season
        if (x > leftx && x < rightx)
        {
            insideSeason = true;
        }
        else
        {
            insideSeason = false;
            isTriggered = false;
        }
        // triggers all the triggers that only happen once when you're in a season
        // when you go out and in it triggers again after reset time
        if (insideSeason && timer <= 0 && !isTriggered && isUnique)
        {
            timer = resetTimeSec;
            Trigger();
            isTriggered = true;
        }
        // triggers all the triggers that happen every resetTime
        if (insideSeason && timer <= 0 && !isUnique)
        {
            timer = resetTimeSec;
            Trigger();
            isTriggered = true;
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

    }

    private void Trigger()
    {
        if (isSound)
        {
            sound.Play();
        } 
    }
}

