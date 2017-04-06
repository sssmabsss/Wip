using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour {

    public int Timetoattack;
    public int life;
    public bool isAttacking;
    public float framescounter;



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
	
        if (framescounter >= Timetoattack)
        {
            isAttacking = true;
            framescounter = 0;
        }
        
        	
	}

    void attack()
    {
        framescounter = 0;

    }
}
