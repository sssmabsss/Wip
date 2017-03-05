using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castbar : MonoBehaviour {

    public float startPosition;
    public float endPosition;
    public float currentPosition;
    public float framesCounter;


    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void FixedUpdate () {

        

    }


    public void Charge_Bar(float coldown)
    {
        framesCounter += Time.deltaTime;

        if (framesCounter >= coldown*2) framesCounter = coldown*2;

        currentPosition = Easings.SineIn(framesCounter, startPosition, endPosition, coldown);

        GetComponent<RectTransform>().localScale = new Vector3(currentPosition, GetComponent<RectTransform>().localScale.y, GetComponent<RectTransform>().localScale.z);
    }

}
