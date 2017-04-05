using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsFunctions : MonoBehaviour {

    [Header("Main Menu")]
    public GameObject mainMenu;

    [Header("Options Menu")]
    public GameObject optionsMenu;
    public bool optionsIsvisible;

    [Header("options Menu")]
    public AudioSource startSound;
    public AudioSource clickSound;




    // Use this for initialization
    void Start () {

        hideMainMenu();
        hideOptions();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onclicknew()
    {
        //nueva escena
        startSound.Play();
        
    }
    public void onclickselect()
    {
        //escena de props
        clickSound.Play();
    }
    public void onclickoptions()
    {
        hideMainMenu();
        showOptions();
        clickSound.Play();

    }
    public void onclickexit()
    {
        Application.Quit();
        clickSound.Play();
    }

    public void showMainMenu()
    {
        mainMenu.SetActive(true);
        optionsIsvisible = false;
        clickSound.Play();

    }

    public void hideMainMenu()
    {
        mainMenu.SetActive(false);
        optionsIsvisible = true;
        clickSound.Play();
    }

    public void showOptions()
    {
        optionsMenu.SetActive(true);
        optionsIsvisible = true;
        hideMainMenu();
        clickSound.Play();
    }

    public void hideOptions()
    {
        optionsMenu.SetActive(false);
        optionsIsvisible = false;
        clickSound.Play();
    }

    public void res720()
    {
        Screen.SetResolution(1280, 720, true, 60);
        Debug.Log("720p");
        Debug.Log("60Hz");
        clickSound.Play();
    }

    public void res1200()
    {
        Screen.SetResolution(1600, 1200, true, 60);
        Debug.Log("1200p");
        Debug.Log("60Hz");
        clickSound.Play();
    }

    public void res1080()
    {
        Screen.SetResolution(1920, 1080, true, 60);
        Debug.Log("1080p");
        Debug.Log("60Hz");
        clickSound.Play();
    }

    public void Fast()
    {
        QualitySettings.SetQualityLevel(0, true);
        clickSound.Play();
    }

    public void Good()
    {
        QualitySettings.SetQualityLevel(1, true);
        clickSound.Play();
    }

    public void Fantastic()
    {
        QualitySettings.SetQualityLevel(2, true);
        clickSound.Play();
    }

    public void Ultra()
    {
        QualitySettings.SetQualityLevel(3, true);
        clickSound.Play();
    }



}
