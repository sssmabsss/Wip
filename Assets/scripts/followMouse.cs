using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followMouse : MonoBehaviour {


    public Vector3 mousePosition;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.position = mousePosition;

        mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

    }
}
