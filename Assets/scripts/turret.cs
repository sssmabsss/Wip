using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour {


    public GameObject[] bullets;
    public float framesCounter;
    private int index = 0;
    public Vector3 direction;
    public float speed;
    public float shootInterval;
    public Transform target;
    public float distance;
    public int bulletdistance;
    public float shootRange;

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
            if (bullets[i].activeSelf) bullets[i].transform.position += direction * speed;
        }

        distance = Vector3.Distance(gameObject.transform.position, target.transform.position);

        framesCounter += Time.deltaTime;

        if (distance < shootRange)
            {
            bullets[index].SetActive(true);

            if (framesCounter >= shootInterval)
            {
                index++;
                framesCounter = 0;
            }

            if (index >= bullets.Length) index = 0;
        }

        for (int i = 0; i < bullets.Length; i++)
        {

            if (bullets[i].transform.position.x <= bulletdistance) reset();
        }

    }

    public void reset()
    {
        for (int i = 0; i < bullets.Length; i++)
        {

            bullets[i].SetActive(false);
            bullets[i].transform.localPosition = new Vector3(0,0,0);

        }
    }
}
