using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour {

    public int Timetoattack;
    public int life;
    public bool isAttacking;
    public float framescounter;


    public Transform target;
    public float distance;
    public float range;

    public Vector3 position1;
    public Vector3 position2;
    public Vector3 position3;


    // Use this for initialization
    void Start () {

     life = 0;
     isAttacking = false;
        framescounter = 0;


}

    // Update is called once per frame
    void FixedUpdate()
    {
        framescounter += Time.deltaTime;
    }


    void Update () {

        distance = Vector3.Distance(transform.position, target.transform.position);

        if (range > distance)
        {
            transform.position = new Vector2(target.position.x, transform.position.y);
        }

        
        	
	}

    void attack()
    {
        framescounter = 0;

    }
}
