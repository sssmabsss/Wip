using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    /*
    [Header("Movement")]
    public float speedwalk;
    public float speedRun;
    public float speed;
    public int jumpforce;
    private Rigidbody2D rb;
    private float move;
    public bool jump1;
    Vector3 mousePosition;


    [Header("Checkers")]
    public Transform groundChecker;
    public LayerMask groundMask;
    public Vector2 groundSize;
    public Transform wallChecker;
    public LayerMask wallMask;
    public Vector2 wallSize;
    public bool isGrounded;
    public bool isTouchingWall;
    public bool isTouchingObject;
    public GameObject TouchingObject;
    public GameObject dummy;
    public LayerMask raymask;
    public GameObject rayhit;


    [Header("Graphics")]
    public bool facingRight;
    public Transform graphicsTransform;

    [Header("animations")]
    public Animator anim;

    [Header("forces")]
    public int weight;
    public int power;
    public bool pushing;


    [System.Serializable]
    public class MaterialData
    {
        public bool Isactive;
        public int IdMaterial;
        public int Weight;
        public int Friction;
        public int resistance;
        public Sprite spriteMaterial;
    }

    public MaterialData[] Materials;

    [Header("gameobjects")]
    public GameObject[] tiles;



    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
    }

    void FixedUpdate()
    {


        Vector2 pointA = new Vector2(groundChecker.position.x - groundSize.x / 2, groundChecker.position.y - groundSize.y / 2);
        Vector2 pointB = new Vector2(groundChecker.position.x + groundSize.x / 2, groundChecker.position.y + groundSize.y / 2);
        Collider2D hitcolliderGround;
        Collider2D hitcollider;

        hitcolliderGround = Physics2D.OverlapArea(pointA, pointB, groundMask);
        if (hitcolliderGround != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        anim.SetBool("Falling", !isGrounded);

        pointA = new Vector2(wallChecker.position.x - wallSize.x / 2, wallChecker.position.y - wallSize.y / 2);
        pointB = new Vector2(wallChecker.position.x + wallSize.x / 2, wallChecker.position.y + wallSize.y / 2);


        hitcollider = Physics2D.OverlapArea(pointA, pointB, wallMask);
        if (hitcollider != null)
        {
            //Debug.Log(hitcollider.name);
            GameObject obj = hitcollider.gameObject;
            if (obj.tag == "objects") isTouchingObject = true;
            else
            {
                isTouchingObject = false;
            }
            isTouchingWall = true;
            TouchingObject = obj;


        }
        else
        {
            isTouchingWall = false;

        }

    }

    // Update is called once per frame
    void Update()
    {

        speedUpdate();



        mousePosition = Input.mousePosition;
        mousePosition.z = 0;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);


        if (Input.GetButtonDown("Coger Material"))
        {
            aimObject();

        }


        if (pushing) empujar();

        anim.SetBool("Action", pushing);

        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        if (Input.GetButtonDown("Empujar") && isTouchingObject)
        {
            pushing = !pushing;

        }

        if (Input.GetButtonDown("Jump"))
        {

            if (isGrounded && !pushing)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
                anim.SetBool("Jump", true);
                jump1 = true;
            }

            else
            {
                if (jump1)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
                    jump1 = false;
                }
            }
        }

        if (facingRight && move < 0 && !pushing) flip();
        else if (!facingRight && move > 0 && !pushing) flip();
    }

    void speedUpdate()
    {

        move = Input.GetAxis("Horizontal");
        if (move != 0) anim.SetBool("Moving", true);
        else anim.SetBool("Moving", false);

        if (isTouchingWall)
        {

            if (facingRight && move > 0) speed = 0;
            else if (!facingRight && move < 0) speed = 0;
            else speed = speedwalk;
        }
        else speed = speedwalk;

    }

    void flip()
    {
        Vector3 newScale = graphicsTransform.localScale;
        newScale.x *= -1;
        graphicsTransform.localScale = newScale;

        facingRight = !facingRight;
        TouchingObject = dummy;
        isTouchingObject = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(groundChecker.position, groundSize);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(wallChecker.position, wallSize);
    }

    void empujar()
    {
        Debug.Log("empujo");
        //move = Input.GetAxis("Horizontal");

        if (isTouchingObject && power > TouchingObject.GetComponent<ObjetoMovible>().weight && pushing)
        {
            Debug.Log("puedo empujar");
            if (TouchingObject.GetComponent<ObjetoMovible>().isTouchingWall == false)
            {
                if (facingRight)
                {
                    TouchingObject.transform.position = new Vector2(gameObject.transform.position.x + 1, TouchingObject.transform.position.y);
                    anim.SetBool("SameDir", true);
                    anim.SetBool("DifferentDir", false);
                }
                else
                {
                    TouchingObject.transform.position = new Vector2(gameObject.transform.position.x - 1, TouchingObject.transform.position.y);
                    anim.SetBool("SameDir", false);
                    anim.SetBool("DifferentDir", true);

                }
            }

            else if (TouchingObject.GetComponent<ObjetoMovible>().isTouchingWall)
            {
                if (facingRight)
                {

                    if (move > 0) TouchingObject.transform.position = new Vector2(TouchingObject.transform.position.x, TouchingObject.transform.position.y);
                    else TouchingObject.transform.position = new Vector2(gameObject.transform.position.x + 1, TouchingObject.transform.position.y);
                }
                else
                {
                    if (move < 0) TouchingObject.transform.position = new Vector2(TouchingObject.transform.position.x, TouchingObject.transform.position.y);
                    else TouchingObject.transform.position = new Vector2(gameObject.transform.position.x - 1, TouchingObject.transform.position.y);
                }
            }
        }
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Respawn") SceneManager.LoadScene ("main");
        if (other.tag == "Finish") SceneManager.LoadScene("menu");
    }

    void SaveMaterial()
    {
        if (TouchingObject.tag == "Material")
        {
            Materials[0].Isactive = true;
            Materials[0].IdMaterial = TouchingObject.GetComponent<tilesPropierties>().id;
            Materials[0].Weight = TouchingObject.GetComponent<tilesPropierties>().weight;
            Materials[0].Friction = TouchingObject.GetComponent<tilesPropierties>().friction;
            Materials[0].resistance = TouchingObject.GetComponent<tilesPropierties>().resistance;
            Materials[0].spriteMaterial = TouchingObject.GetComponent<SpriteRenderer>().sprite;
        }
    }

    void aimObject()
    {
        Vector3 dir = Vector3.zero;

        Vector3 direction = (transform.position - mousePosition).normalized;

        if (facingRight)
        {
            dir.x = 1;
            dir.y = .5f;
        }
        else
        {
            dir.x = -1;
            dir.y =  .5f;
        }

        Ray ray = new Ray(transform.position + dir, direction);

        Debug.DrawRay(ray.origin, -ray.direction * 100, Color.yellow, 10, false);


        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction * 100, raymask);

        rayhit = hit.transform.gameObject;

        GetComponentInChildren<TextMesh>().text = hit.transform.gameObject.name;
    }

*/
}
