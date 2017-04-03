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
