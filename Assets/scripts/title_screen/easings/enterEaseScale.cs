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
    int shrinkTimer;

    // Use this for initialization
    void Start()
    {

        initValueX = transform.localScale.x;
        finalValueX = 1.08f;
        currentValueX = initValueX;

        initValueY = transform.localScale.y;
        finalValueY = 1.08f;
        currentValueY = initValueY;

        

        framesCounter = 0;
        framesDuration = 35;
        initEase = 0;

        blinking = false;
        blinkTimer = 0;
        shrinkTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        initEase++;

        if (initEase >= 270)
        {
            if (blinking == true)
            {
                shrinkTimer++;
                framesCounter++;
                if (framesCounter <= framesDuration)
                {
                    currentValueX = Easings.ElasticOut(framesCounter, initValueX, -finalValueX, framesDuration);
                    currentValueY = Easings.ElasticOut(framesCounter, initValueY, -finalValueY, framesDuration);

                    transform.localScale = new Vector3(currentValueX, currentValueY, 0);
                }

                if (shrinkTimer >= 70)
                {
                    shrinkTimer = 0;
                    framesCounter = 0;
                    blinking = false;
                }

            }

            if (blinking == false)
            {
                shrinkTimer++;
                framesCounter++;
                if (framesCounter <= framesDuration)
                {
                    currentValueX = Easings.ElasticOut(framesCounter, initValueX, finalValueX + 0.2f, framesDuration);
                    currentValueY = Easings.ElasticOut(framesCounter, initValueY, finalValueY + 0.2f, framesDuration);

                    transform.localScale = new Vector3(currentValueX, currentValueY, 0);
                }

                if (shrinkTimer >= 70)
                {
                    shrinkTimer = 0;
                    framesCounter = 0;
                    blinking = false;
                }
            }
        }
    }

    public void movingWip()
    {

    }
    public void movinalchemist()
    {

    }
}