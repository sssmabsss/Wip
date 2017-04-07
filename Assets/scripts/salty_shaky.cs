using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salty_shaky : MonoBehaviour {

  public  float initValue;
  public  float finalValue;
  public  float currentValue;

    int framesCounter;
    int framesDuration;
    int initEase;

    // Use this for initialization
    void Start()
    {

        initValue = transform.position.y;
        finalValue = +1;
        currentValue = initValue;

        framesCounter = 0;
        framesDuration = 30;

        initEase = 0;
    }

    // Update is called once per frame
    void Update()
    {
            framesCounter++;
            if (framesCounter >= framesDuration)
            {
                currentValue = Easings.ElasticOut(framesCounter, initValue, 1, framesDuration);

                transform.position = new Vector3(currentValue, currentValue, 0);
            }
        }
    }

