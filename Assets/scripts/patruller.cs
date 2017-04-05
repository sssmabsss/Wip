using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patruller : MonoBehaviour {

    [Header("movement")]
    private Rigidbody2D rb;
    public int speed;
    public int life;
    public Vector3 initialPosition;
    public int initialspeed;
    public bool isvertical;
    public bool ishorizontal;

    [Header("Checkers")]
    public Transform groundChecker;
    public LayerMask groundMask;
    public Vector2 groundSize;
    public Transform wallChecker;
    public LayerMask wallMask;
    public Vector2 wallSize;
    public bool isGrounded;
    public bool isTouchingWall;
    public bool facingRight;
    public Transform graphicsTransform;



    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
        initialPosition = gameObject.transform.position;
        initialspeed = speed;
    }

	
	// Update is called once per frame
	void FixedUpdate () {

        if (isvertical)
        {
            rb.velocity = Vector2.up * speed;
        }
        else if (ishorizontal)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        if (life <= 0) death();


        Vector2 pointA = new Vector2(groundChecker.position.x - groundSize.x / 2, groundChecker.position.y - groundSize.y / 2);
        Vector2 pointB = new Vector2(groundChecker.position.x + groundSize.x / 2, groundChecker.position.y + groundSize.y / 2);
        Collider2D hitcolliderGround;
        Collider2D hitcolliderWall;

        hitcolliderGround = Physics2D.OverlapArea(pointA, pointB, groundMask);

        if (hitcolliderGround != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        pointA = new Vector2(wallChecker.position.x - wallSize.x / 2, wallChecker.position.y - wallSize.y / 2);
        pointB = new Vector2(wallChecker.position.x + wallSize.x / 2, wallChecker.position.y + wallSize.y / 2);


        hitcolliderWall = Physics2D.OverlapArea(pointA, pointB, wallMask);


        if (hitcolliderWall != null)
        {
            isTouchingWall = true;
        }
        else
        {
            isTouchingWall = false;
        }

        if (isTouchingWall)
        {
            speed *= -1;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(groundChecker.position, groundSize);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(wallChecker.position, wallSize);
    }

    void flip()
    {
        Vector3 newScale = graphicsTransform.localScale;
        newScale.x *= -1;
        graphicsTransform.localScale = newScale;

        facingRight = !facingRight;

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

            if (other.gameObject.GetComponent<plyer>().life <= 0) respawn();
        }

        if (other.tag == "Danger")
        {
            respawn();
        }
    }
}
