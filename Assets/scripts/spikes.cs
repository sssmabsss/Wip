using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour
{

    public bool canhide;
    public float framesCounter;
    public float coldown;
    public bool ishide;
    public Vector3 initialPosition;
    public Vector3 hidePosition;




    // Use this for initialization
    void Start()
    {
        initialPosition = gameObject.transform.position;
        hidePosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1, gameObject.transform.position.z);
        ishide = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (!ishide) show();
        else hide();

        if (canhide)
        {
            framesCounter += Time.deltaTime;
            if (framesCounter >= coldown)
            {
                ishide = !ishide;
                framesCounter = 0;
            }
        }
    }

    public void show()
    {
        transform.position = Vector3.Lerp(gameObject.transform.position, initialPosition, .5f);
        //gameObject.transform.position = initialPosition;
    }


    public void hide()
    {
        transform.position = Vector3.Lerp(gameObject.transform.position, hidePosition, .5f);
        //gameObject.transform.position = hidePosition;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<plyer>().takingdamage();
        }
    }
}

