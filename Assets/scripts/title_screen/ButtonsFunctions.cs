using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsFunctions : MonoBehaviour {

    [Header("Main Menu")]
    public GameObject mainMenu;

    [Header("Options Menu")]
    public GameObject optionsMenu;
    public GameObject selectMenu;
    public bool optionsIsvisible;
    


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
        SceneManager.LoadScene("Prototype");
    }
    public void onclickselect()
    {
        SceneManager.LoadScene("test_level");
    }
    public void onclickoptions()
    {
        hideMainMenu();
        showOptions();

    }
    public void onclickexit()
    {
        Application.Quit();
    }

    public void showMainMenu()
    {
        mainMenu.SetActive(true);
        optionsIsvisible = false;

    }

    public void hideMainMenu()
    {
        mainMenu.SetActive(false);
        optionsIsvisible = true;
    }

    public void showOptions()
    {
        optionsMenu.SetActive(true);
        optionsIsvisible = true;
    }

    public void hideOptions()
    {
        optionsMenu.SetActive(false);
        optionsIsvisible = false;
    }
}
