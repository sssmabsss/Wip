﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class title_screen : MonoBehaviour
{

    [Header("background")]
    public GameObject screen;
    public Color color;
    public bool fading;
    public float minfade, maxfade;
    public float smoothVelocity;

    [Header("title")]
    public GameObject wip, alchemist;
    public Vector3 endwip = new Vector3(0, 1, 0), endalche = new Vector3(0, -1, 0);
    public GameObject mainMenu;

    [Header("start")]
    public GameObject start;
    public Color startcolor;
    public float counter;
    public bool isActive;
    public bool isVisible;

    [Header("canvas")]
    public GameObject canvas;

    [Header("Options Menu")]
    public GameObject optionsMenu;
    public GameObject selectMenu;
    public bool optionsIsvisible;


    // Use this for initialization
    void Start()
    {

        fading = true;
        isActive = false;
        canvas.SetActive(false);
        optionsMenu.SetActive(false);
        isVisible = true;
        optionsIsvisible = false; 
    }

    // Update is called once per frame
    void Update()
    {


        screen.GetComponent<SpriteRenderer>().color = color;
        start.GetComponent<SpriteRenderer>().color = startcolor;

        if (fading)
        {

            color.a += Time.deltaTime * smoothVelocity;
            if (color.a > maxfade)
                showtitle();
        }
        else
        {
            color.a -= Time.deltaTime * smoothVelocity;
            if (color.a < minfade) showtitle();

        }
        counter += Time.deltaTime;

        if (isActive) startcolor.a = 1;
        else startcolor.a = 0;

        if (optionsIsvisible && Input.GetKeyDown("escape"))
        {
            optionsIsvisible = false;
            optionsMenu.SetActive(false);
            mainMenu.SetActive(true);
            isVisible = true;
        }

    }

    public void showtitle()
    {
        if (wip.transform.position.x > endwip.x) wip.transform.Translate(Vector3.left * Time.deltaTime * 3.3f);

        if (alchemist.transform.position.x < endalche.x) alchemist.transform.Translate(Vector3.right * Time.deltaTime * 3.3f);
        else pressStart();

    }

    public void pressStart()
    {
        startcolor.a = 0;

        if (Input.anyKey)
        {
            canvas.SetActive(true);
            isVisible = false;
            start.SetActive(false);
        }

        if (.8 <= counter && isVisible)
        {
            counter = 0;
            isActive = !isActive;
        }


    }

    public void onclicknew()
    {
        SceneManager.LoadScene("Prototype");
    }
    public void onclickselect()
    {
        SceneManager.LoadScene("test_level");
    }
    public void onclickoptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        optionsIsvisible = true;
    }
    public void onclickexit()
    {
        Application.Quit();
    }

}
