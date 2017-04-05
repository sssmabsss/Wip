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
    public bool isshooting;
    public AudioSource shoot;

    private SpriteAnimator sp;

    // Use this for initialization
    void Start ()
    {
        sp = GetComponent<SpriteAnimator>();

       sp.AddCustomEvent("Plant_attack_left", 6).AddListener(ShootFrame);
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
            isshooting = true;
        }
        else
        {
            isshooting = false;
        }


        if (isshooting)
        {
            sp.Play("Plant_attack_left", true);

        }
        else
        {
            sp.Play("Plant_idle_left");
        }

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

    public  void ShootFrame(BaseAnimator caller)
    {
        Shot();
        shoot.Play();

    }

    void Shot()
    {
        bullets[index].SetActive(true);
        index++;
        if (index >= bullets.Length) index = 0;
    }
}
