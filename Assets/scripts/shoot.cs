using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

    // Use this for initialization


    public float speed;
    public Vector3 bulletdistance;



    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 var = new Vector3(0,speed,0);

        gameObject.transform.localPosition += var;

    }

    public void reset()
    {

        gameObject.SetActive(false);
        gameObject.transform.localPosition = new Vector3(0, 0, 0);
    }
}
