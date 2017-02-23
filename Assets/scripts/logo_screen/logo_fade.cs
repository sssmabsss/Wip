using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logo_fade : MonoBehaviour {


    public GameObject logo;
    public Color color;
    public bool fading;
    public float minfade, maxfade;
    public float smoothVelocity;

    // Use this for initialization
    void Start()
    {

        fading = true;
    }

    // Update is called once per frame
    void Update()
    {


        logo.GetComponent<SpriteRenderer>().color = color;

        if (fading)
        {

            color.a += Time.deltaTime * smoothVelocity;
            if (color.a > maxfade)
                fading = false;
        }
        else
        {
            color.a -= Time.deltaTime * smoothVelocity;
            if (color.a < minfade)
                SceneManager.LoadScene("title");
        }
    }
}

