using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followMouse : MonoBehaviour {


    public Vector3 mousePosition;
    public bool visible;

	// Use this for initialization
	void Start () {

        visible = true;
    }
	
	// Update is called once per frame
	void Update () {

        Cursor.visible = visible;

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);

    }
}
