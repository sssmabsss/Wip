using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decall : MonoBehaviour {


    public GameObject[] decals;
    public GameObject activedecal;
    public Vector3 hidePosition;
    public Color hideColor;




	// Use this for initialization
	void Start () {
        hidePosition = new Vector3(-10, 100, 0);
        hideColor = Color.white;

    }
	
	// Update is called once per frame
	void Update () {


        for (int i = 0; i < decals.Length; i++)
        {
            if (!decals[i].activeSelf) activedecal = decals[i];
        }



    }


    public void Show(Vector2 position, Color color)
    {
        activedecal.transform.position = position;
        activedecal.GetComponent<SpriteRenderer>().color = color;
        activedecal.SetActive(true);
    }

    public void Hide ()
    {
        activedecal.transform.position = hidePosition;
        activedecal.GetComponent<SpriteRenderer>().color = hideColor;
        activedecal.SetActive(false);
    }
}


/*
 * 
 * 
1
down vote
accepted
+50
Physics2D.OverlapArea(pointA, pointB) just returns which collider is under the area covered by a rectangle with pointA and pointB as corners.

This will not be useful for what you are trying to achieve. You will need a shader that combines the colors being rended.

You could create a new material, and use the "Particles->Multiply", then use this new material on your SpriteRenderers (if you are using sprites).

With this shader the colors will blend like you described, but keep in mind that it will blend with the backgroun too, so the background should be white to keep the colors of the sprites "clean".
*/