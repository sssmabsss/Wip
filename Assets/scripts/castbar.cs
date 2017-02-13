using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castbar : MonoBehaviour {

    public Vector3 startPosition;
    public Vector3 endPosition;
    public Vector3 currentPosition;


    // Use this for initialization
    void Start () {

        startPosition = new Vector3(-127, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
        endPosition = new Vector3(-0, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
        currentPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);


    }
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.localPosition = currentPosition;
	}

    public void up()
    {
        currentPosition.x++;

        if (currentPosition.x > endPosition.x) currentPosition.x = endPosition.x;
    }

    public void down()
    {
        currentPosition.x--;

        if (currentPosition.x < startPosition.x) currentPosition.x = startPosition.x;
    }
}
