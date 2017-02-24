using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade_Bheaviour : MonoBehaviour {

    [Header("background")]
    public GameObject screen;
    public Color color;
    public bool fading;
    public float minfade, maxfade;
    public float smoothVelocity;

    [Header("start")]
    public GameObject start;
    public Color startcolor;
    public float counter;
    public bool isActive;
    public bool isVisible;

    void Start () {

        fading = true;
        isActive = false;
        isVisible = true;
    }
	
	// Update is called once per frame
	void Update () {


        screen.GetComponent<SpriteRenderer>().color = color;
        start.GetComponent<SpriteRenderer>().color = startcolor;

        if (fading)
        {

            color.a += Time.deltaTime * smoothVelocity;
            if (color.a > maxfade)
                GetComponent<title_screen>().showtitle();

        }
        else
        {
            color.a -= Time.deltaTime * smoothVelocity;
            if (color.a < minfade) GetComponent<title_screen>().showtitle();

        }
        counter += Time.deltaTime;

        if (isActive) startcolor.a = 1;
        else startcolor.a = 0;


    }
}
