using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wipEaseIntro : MonoBehaviour
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
        finalValue = -9.2f;
        currentValue = initValue;

        framesCounter = 0;
        framesDuration = 85;

        initEase = 0;
    }

    // Update is called once per frame
    void Update()
    {
        initEase++;
        if (initEase >= 180)
        {
            framesCounter++;
            if (framesCounter <= framesDuration)
            {
                currentValue = Easings.ElasticOut(framesCounter, initValue, finalValue, framesDuration);

                transform.position = new Vector3(0, currentValue, 0);
            }
        }
    }
}