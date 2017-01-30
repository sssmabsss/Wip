using UnityEngine;
using System.Collections;

public class plyer : MonoBehaviour
{


    [Header("Movement")]
    public Rigidbody2D rb;
    public float move;
    public bool Moving;
    public int speed;
    public int speedwalk;
    public int speedObject;
    public int jumpforce;
    public bool riding;

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

    [Header("Graphics")]
    public bool facingRight;
    public Transform graphicsTransform;

    [Header("forces")]
    public int weight;
    public int power;
    public bool pushing;
    public int forcedown;

    [Header("Change Material")]
    public Vector3 mousePosition;
    public Vector2 mousePosition2D;
    public LayerMask raymask;
    public GameObject rayhit;
    public GameObject saveMaterial;
    public RaycastHit2D aimhit;
    public RaycastHit2D changehit;
    private Vector3 dir;
    public GameObject objectToChange;
    public int sprite;

    [Header("life")]
    public int life;
    public int hitforce;
    public bool invencibility;
    public int invencibilityTime;
    public float framesCounter;

    [Header("Checkpoint")]
    public Vector3 lastcheckpoint;




    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        lastcheckpoint = gameObject.transform.position;
        life = 3;
        invencibility = false;
    }

    void FixedUpdate()
    {
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
            //Debug.Log(hitcollider.name);
            isTouchingWall = true;

            if (hitcolliderWall.tag == "Box")
                {
                    isTouchingObject = true;
                    TouchingObject = hitcolliderWall.gameObject;
                }
        }
        else 
        {
            isTouchingWall = false;
            isTouchingObject = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //for aiming with the mouse

        mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        mousePosition2D.x = mousePosition.x;
        mousePosition2D.y = mousePosition.y;

        dir.y = .5f;

        if (facingRight)
        {
            dir.x =  + 1;
        }
        else
        {
            dir.x =  -1;
        }


        //debugin linecast:

        if (Input.GetMouseButton(1))     Debug.DrawLine(gameObject.transform.position + dir, mousePosition, Color.yellow);
        if (Input.GetMouseButton(0))     Debug.DrawLine(mousePosition, gameObject.transform.position + dir, Color.green);

        //aiming logic

        if (Input.GetMouseButtonDown(1))
        {
            aimObject();

        }

        if (Input.GetMouseButtonDown(0))
        {
            changeMaterial();
        }

        //movement logic

        MovementUpdate();
        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        //Jump logic

        if(Input.GetKeyDown("up"))
        {
            if(isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
            }
        }

        //pushing logic

        if (Input.GetKeyDown("space") && isTouchingObject) pushing = !pushing;



        if (pushing)
        {
            coger();

        }


        //flip logic

        if (facingRight && move < 0 && !pushing) flip();
        else if (!facingRight && move > 0 && !pushing) flip();

        //restart logic

        if (life <= 0) restardCheckpoint();

        //invencibility logic

        if (invencibility)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            framesCounter += Time.deltaTime;
            if (framesCounter >= invencibilityTime)
            {
                invencibility = false;
                framesCounter = 0;
            }
        }
        else gameObject.GetComponent<SpriteRenderer>().color = Color.white;

        }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(groundChecker.position, groundSize);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(wallChecker.position, wallSize);
    }
    void MovementUpdate()
    {


        move = Input.GetAxis("Horizontal");
        if (move != 0) Moving = true;
        else Moving = false;

        if (isTouchingWall)
        {

            if (facingRight && move > 0 && !pushing) speed = 0;
            else if (!facingRight && move < 0 && !pushing) speed = 0;
        }
        else speed = speedwalk;

        if (isTouchingObject) speed = speedObject;

    }

    void flip()
    {
        Vector3 newScale = graphicsTransform.localScale;
        newScale.x *= -1;
        graphicsTransform.localScale = newScale;

        facingRight = !facingRight;
        TouchingObject = null;
       
    }

    void coger()
    {
        TouchingObject.GetComponent<BoxPropierties>().rb.velocity = new Vector2(0, forcedown); ;

        if (TouchingObject.GetComponent<BoxPropierties>().spritecolor < 1 && pushing)
        {
            if (facingRight)
            {
                TouchingObject.transform.position = new Vector3(gameObject.transform.position.x + 1.1f, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            else
            {
                TouchingObject.transform.position = new Vector3(gameObject.transform.position.x - 1.1f, gameObject.transform.position.y, gameObject.transform.position.z);
            }
        }
        else pushing = !pushing;
    }

    void aimObject()
    {

        
        aimhit = Physics2D.Linecast(gameObject.transform.position + dir, mousePosition2D, raymask);


        if (aimhit)
        {
            rayhit = aimhit.transform.gameObject;
            print("he tocado algo");
        }
        else rayhit = null;


            // GetComponentInChildren<TextMesh>().text = hit.transform.gameObject.name;

        if (rayhit.tag == "Material")
        {
            saveMaterial = rayhit;
            print("he tocado un materiaL");
        }

    }

    void changeMaterial()
    {


       changehit = Physics2D.Linecast(gameObject.transform.position + dir, mousePosition2D, raymask);


        if (Physics2D.Linecast(gameObject.transform.position + dir, mousePosition2D, raymask))
        {

            objectToChange = changehit.transform.gameObject;

            if (objectToChange.tag == "Box")
            {

                if (saveMaterial.GetComponent<Material_propierties>().material == "Light")
                {
                    objectToChange.GetComponent<BoxPropierties>().spritecolor = 0;
                    print("cambio material");

                }
                else if (saveMaterial.GetComponent<Material_propierties>().material == "Medium")
                {
                    objectToChange.GetComponent<BoxPropierties>().spritecolor = 1;
                    print("cambio material");

                }
                if (saveMaterial.GetComponent<Material_propierties>().material == "Heavy")
                {
                    objectToChange.GetComponent<BoxPropierties>().spritecolor = 2;
                    print("cambio material");

                }
            }
        }
        else objectToChange = null;

    }

    public void takingdamage()
    {
        if (!invencibility)
        {
            life -= 1;
            if (life > 0) invencibility = true;
        }
    }

    public void restardCheckpoint()
    {
        gameObject.transform.position = lastcheckpoint;
        life = 3;
    }


    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "platform")
        {
            transform.parent = other.transform;
            riding = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "platform")
        {
            transform.parent = null;
            riding = false;
        }
    }
}
