using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour {


    public GameObject[] bullets;
    public float framesCounter;
    private int index = 0;
    public Vector3 direction;
    public Vector2 shootspeed;
    public float shootInterval;
    public Transform target;
    public float distance;
    public int bulletdistance;
    public float shootRange;

    // Use this for initialization
    void Start ()
    {
        GetComponent<SpriteAnimator>().AddCustomEvent("turret_attack", 14).AddListener(StepFrame);
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].SetActive(false);

        }
    }

    // Update is called once per frame
    void FixedUpdate () {


        distance = Vector3.Distance(gameObject.transform.position, target.transform.position);

        framesCounter += Time.deltaTime;


        if (distance < shootRange)
        {
            GetComponent<SpriteAnimator>().Play("turret_attack");          
        }
        else GetComponent<SpriteAnimator>().Play("turret_idle");

        

        if (framesCounter >= 5) restart();

    }

    public void restart()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].SetActive(false);

        }

        index = 0;

        framesCounter = 0;
    }

    public  void StepFrame(BaseAnimator caller)
    {
        Shot();
    }

    void Shot()
    {
        bullets[index].SetActive(true);
        index++;
        if (index >= bullets.Length) index = 0;
    }
}
