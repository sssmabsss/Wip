using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

    // Use this for initialization


    public float speed;

    public Decall decall;
    public GameObject go;
    


    void Start ()
    {
        
        decall = go.GetComponent<Decall>();

	}
	
	// Update is called once per frame
	void Update () {

        Vector3 var = new Vector3(0,speed,0);

        gameObject.transform.localPosition += var;

    }

    public void reset()
    {

        gameObject.SetActive(false);
        gameObject.transform.localPosition = new Vector3(0, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {


      //  decall.Show(other.gameObject.transform.position, Color.red);


        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<plyer>().takingdamage();

            reset();
        }

        else if (other.tag == "Land")
        {
            Debug.Log("toco suelo");

            reset();
        }

        else if (other.tag == "Box")
        {
            if (other.gameObject.GetComponent<BoxPropierties>().spritecolor == 0)
            {
                other.gameObject.GetComponent<BoxPropierties>().respawn();
                reset();
            }
            else
            {
                reset();
            }
        }
    }
}
