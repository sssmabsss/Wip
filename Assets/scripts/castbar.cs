using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castbar : MonoBehaviour {

    public Vector3 startPosition;
    public Vector3 endPosition;
    public Vector3 currentPosition;
    public float speed;


    // Use this for initialization
    void Start () {

        startPosition = new Vector3(-127, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
        endPosition = new Vector3(-0, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
        currentPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);

        speed = 127 / 100;

    }
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.localPosition = currentPosition;
	}

    public void up()
    {
        currentPosition.x += speed;

        if(currentPosition.x > endPosition.x) down();
    }

    public void down()
    {
         currentPosition.x = startPosition.x;
    }

    public void fastup()
    {
        currentPosition.x += speed *2.5f;

        if(currentPosition.x > endPosition.x) down();
    }
}
