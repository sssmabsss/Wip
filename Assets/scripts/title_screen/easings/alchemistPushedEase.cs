using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alchemistPushedEase : MonoBehaviour
{


    float initValue;
    float finalValue;
    float currentValue;

    int framesCounter;
    int framesDuration;
    int initEase;

    // Use this for initialization
    void Start()
    {

        initValue = transform.position.y;
        finalValue = -1.2f;
        currentValue = initValue;

        framesCounter = 0;
        framesDuration = 70;

        initEase = 0;
    }

    // Update is called once per frame
    void Update()
    {
        initEase++;
        if (initEase >= 128)
        {
            framesCounter++;
            if (framesCounter <= framesDuration)
            {
                currentValue = Easings.ElasticOut(framesCounter, initValue, finalValue, 30);

                transform.position = new Vector3(0, currentValue, 0);
            }
        }
    }
}