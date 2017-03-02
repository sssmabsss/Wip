using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterEaseScale : MonoBehaviour
{


    float initValueX;
    float finalValueX;
    float currentValueX;

    float initValueY;
    float finalValueY;
    float currentValueY;

    int framesCounter;
    int framesDuration;
    int initEase;

    bool blinking;
    int blinkTimer;

    // Use this for initialization
    void Start()
    {

        initValueX = transform.localScale.x;
        finalValueX = 1.06f;
        currentValueX = initValueX;

        initValueY = transform.localScale.y;
        finalValueY = 1.06f;
        currentValueY = initValueY;

        framesCounter = 0;
        framesDuration = 40;
        initEase = 0;

        blinking = false;
        blinkTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*blinkTimer++;

        if((blinkTimer / 30) == 0)
        {
            blinking = true;
        }
        else if((blinkTimer / 30) == 1)
        {
            blinking = false;
        }*/


        if (blinking == false)
        {
            framesCounter++;
            if (framesCounter <= framesDuration)
            {
                currentValueX = Easings.CubicIn(framesCounter, initValueX, finalValueX, framesDuration);
                currentValueY = Easings.CubicIn(framesCounter, initValueY, finalValueY, framesDuration);

                transform.localScale = new Vector3(currentValueX, currentValueY, 0);
            }

            if (framesCounter > framesDuration)
            {
                blinking = true;
                framesCounter = 0;
            }
        }

        if (blinking == true)
        {
            framesCounter++;
            if (framesCounter <= framesDuration)
            {
                currentValueX = Easings.CubicOut(framesCounter, initValueX, -finalValueX, framesDuration);
                currentValueY = Easings.CubicOut(framesCounter, initValueY, -finalValueY, framesDuration);

                transform.localScale = new Vector3(currentValueX, currentValueY, 0);
            }

            if (framesCounter > framesDuration)
            {
                blinking = false;
                framesCounter = 0;
            }
        }
    }
}