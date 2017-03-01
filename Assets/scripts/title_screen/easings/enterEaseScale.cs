using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterEaseScale : MonoBehaviour
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

        initValueX = transform.localScale.x;
        finalValueX = 1.08f;
        currentValueX = initValueX;

        framesCounter = 0;
        framesDuration = 10;

        initEase = 0;
    }

    // Update is called once per frame
    void Update()
    {
        framesCounter++;
        if (framesCounter <= framesDuration)
        {
            currentValueX = Easings.CubicIn(framesCounter, initValueX, finalValueX, framesDuration);
            //currentValueX = Easings.CubicOut(framesCounter, initValueX, finalValueX, framesDuration);

            transform.localScale = new Vector3(currentValueX, transform.localScale.y, 0);
        }
    }
}