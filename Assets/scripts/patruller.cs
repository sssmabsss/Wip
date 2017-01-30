using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patruller : MonoBehaviour {

    private Rigidbody2D rb;
    public int speed;
    public int life;
    public Vector3 initialPosition;
    public int initialspeed;
    public bool isvertical;
    public bool ishorizontal;



    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
        initialPosition = gameObject.transform.position;
        initialspeed = speed;
    }

	
	// Update is called once per frame
	void FixedUpdate () {

        if (isvertical) rb.velocity = Vector2.up * speed;
        else if (ishorizontal) rb.velocity = Vector2.right * speed;

        if (life <= 0) death();
    }

    void death()
    {
        gameObject.SetActive(false);
    }

    public void respawn()
    {
        gameObject.transform.position = initialPosition;
        speed = initialspeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<plyer>().takingdamage();

            speed *= -1;

            if (other.gameObject.GetComponent<plyer>().life <= 0) respawn();
        }

        if (other.tag == "Land")
        {
            speed *= -1;
        }

        if (other.tag == "Box")
        {

            speed *= -1;
        }

        if (other.tag == "Danger")
        {
            respawn();
        }
    }
}
