using System.Collections;
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

    [Header("start")]
    public GameObject start;
    public Color startcolor;
    public float counter;
    public bool isActive;

    [Header("canvas")]
    public GameObject canvas;


    // Use this for initialization
    void Start()
    {

        fading = true;
        isActive = false;
        canvas.SetActive(false);
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

        if (Input.GetKeyDown(KeyCode.Return))
        {
            canvas.SetActive(true);
            isActive = false;
        }

        if (.8 <= counter)
        {
            counter = 0;
            isActive = !isActive;
        }


    }

    public void onclicknew()
    {
        SceneManager.LoadScene("level_debug");
    }
    public void onclickselect()
    {
        SceneManager.LoadScene("level_debug");
    }
    public void onclickoptions()
    {

    }
    public void onclickexit()
    {
        Application.Quit();
    }

}
