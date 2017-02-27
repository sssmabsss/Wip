﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class title_screen : MonoBehaviour
{


    [Header("title")]
    public GameObject wip, alchemist;
    public Vector3 endwip = new Vector3(0, 1, 0), endalche = new Vector3(0, -1, 0);
    public GameObject mainMenu;

    [Header("start")]
    public GameObject start;
    public Color startcolor;
    public float counter;
    public float counter2;
    public bool isActive;
    public bool isVisible;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        pressStart();

    }

    public void showtitle()
    {
        if (wip.transform.position.x > endwip.x) wip.transform.Translate(Vector3.left * Time.deltaTime * 3.3f);

        if (alchemist.transform.position.x < endalche.x) alchemist.transform.Translate(Vector3.right * Time.deltaTime * 3.3f);
    }

    public void pressStart()
    {
        counter += Time.deltaTime;
        startcolor.a = 0;

        if (Input.anyKey)
        {
            isVisible = false;
            start.SetActive(false);
            GetComponent<ButtonsFunctions>().showMainMenu();
        }

        if (.8 <= counter && isVisible)
        {
            counter = 0;
            isActive = !isActive;
        }

        if (GetComponent<ButtonsFunctions>().optionsIsvisible && Input.GetKeyDown("escape"))
        {
            GetComponent<ButtonsFunctions>().optionsIsvisible = false;
            isVisible = true;
            GetComponent<ButtonsFunctions>().hideOptions();
            GetComponent<ButtonsFunctions>().showMainMenu();
        }

        if(isActive) startcolor.a = 1;
        else startcolor.a = 0;
    }
    
   
}
