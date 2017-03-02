using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alchemistEaseIntro : MonoBehaviour
{


    float initValueX;
    float finalValueX;
    float currentValueX;

    int framesCounter;
    int framesDuration;
    int initEase;

    // Use this for initialization
    void Start()
    {

        initValueX = transform.position.x;
        finalValueX = 15;
        currentValueX = initValueX;

        framesCounter = 0;
        framesDuration = 120;

        initEase = 0;
    }

    // Update is called once per frame
    void Update()
    {
        initEase++;

        if (initEase >= 60)
        {
            framesCounter++;
            if (framesCounter <= framesDuration)
            {
                currentValueX = Easings.ElasticInOut(framesCounter, initValueX, finalValueX, framesDuration);

                transform.position = new Vector3(currentValueX, transform.position.y, 0);
            }
        }
    }
}