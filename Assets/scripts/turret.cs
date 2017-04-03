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

    private SpriteAnimator spriteAnimator;
    public bool shooting;

    // Use this for initialization
    void Start ()
    {
        spriteAnimator = GetComponent<SpriteAnimator>();

        spriteAnimator.AddCustomEvent("turret_attack", 14).AddListener(StepFrame);
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].SetActive(false);

        }
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        if(shooting)
        {
            if (!spriteAnimator.IsPlaying) shooting = false;
        }

        distance = Vector3.Distance(gameObject.transform.position, target.transform.position);

        framesCounter += Time.deltaTime;


        if (distance < shootRange && !shooting)
        {
            shooting = true;
            spriteAnimator.Play("turret_attack", true);          
        }
        else if(!shooting)spriteAnimator.Play("turret_idle");        

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
