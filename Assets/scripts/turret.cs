using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour {


    public GameObject[] bullets;
    public int cadence;
    private int index = 0;
    public Vector3 direction;
    public int speed;

    // Use this for initialization
    void Start () {

        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].SetActive(false);

        }


    }

    // Update is called once per frame
    void Update () {

        for (int i = 0; i < bullets.Length; i++)
        {
            if (bullets[i].activeSelf)
            bullets[i].transform.position += direction * (speed * Time.deltaTime);
        }


        if (Input.GetKeyDown("space"))
        {
            bullets[index].SetActive(true);
            index++;

            if (index >= bullets.Length) index = 0;
        }


    }


    void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
    }
}
