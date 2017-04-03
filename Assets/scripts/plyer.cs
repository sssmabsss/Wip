using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class plyer : MonoBehaviour
{


    [Header("Movement")]
    public Rigidbody2D rb;
    public float move;
    public float movevertical;
    public bool Moving;
    public int speed;
    public int speedwalk;
    public int speedObject;
    public int jumpforce;
    public bool riding;
    public bool GodMode;


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
    public bool IsPaused;

    [Header("Graphics")]
    public bool facingRight;
    public Transform graphicsTransform;
    public GameObject graphics;
    public Color playercolor;
    public CameraController CC;
  //  public GameObject bar;

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
    public float getcoldown;
    public float setcoldown;


    [Header("life")]
    public int life;
    public int hitforce;
    public bool invencibility;
    public int invencibilityTime;
    public float framesCounter;
    public float framesCounterhit;

    [Header("Checkpoint")]
    public Vector3 lastcheckpoint;

    [Header("particles")]
    public GameObject lighting_particle;

    [Header("Ui")]
    public castbar castbar;
    public GameObject pause;


    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        lastcheckpoint = gameObject.transform.position;
        life = 3;
        invencibility = false;
        GodMode = false;
        IsPaused = false;
        pause.SetActive(false);
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
            mousePosition.z = CC.Zdistance;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            mousePosition2D.x = mousePosition.x;
            mousePosition2D.y = mousePosition.y;

            dir.y = .5f;

            if(facingRight)
            {
                dir.x = +1;
            }
            else
            {
                dir.x = -1;
            }


            //debugin linecast:

            if(Input.GetMouseButton(1)) Debug.DrawLine(gameObject.transform.position + dir, mousePosition, Color.yellow);

            if(Input.GetMouseButton(0)) Debug.DrawLine(mousePosition, gameObject.transform.position + dir, Color.green);

            //aiming logic

            if(Input.GetMouseButton(1))
            {
                aimObject();
                

            }
            else if(Input.GetMouseButtonUp(1))
            {
                framesCounter = 0;
            castbar.framesCounter = 0;

            }

            if(Input.GetMouseButton(0))
            {
                changeMaterial();
            }
            else if(Input.GetMouseButtonUp(1))
            {
                framesCounter = 0;
              //  bar.GetComponent<castbar>().down();
            }

        //pause logic

        if (Input.GetKeyDown("p")) IsPaused = !IsPaused;

        OnPause();

        //movement logic

        MovementUpdate();
            rb.velocity = new Vector2(speed * move, rb.velocity.y);

            if(GodMode)
            {
                rb.velocity = new Vector2(speed * movevertical, rb.velocity.y);
                rb.velocity = new Vector2(speed * move, rb.velocity.x);
                life = 10;
                invencibilityTime = 999;
            }
            else
            {
                life = 3;
                invencibilityTime = 3;
            }


            if(Input.GetKeyDown("f10")) GodMode = !GodMode;


            //Jump logic

            if(Input.GetKeyDown("up") || Input.GetKeyDown("w"))
            {
                if(isGrounded)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
                }
            }

            //pushing logic

            if(Input.GetKeyDown("space") && isTouchingObject) pushing = !pushing;



            if(pushing)
            {
                coger();
            }
            else
            {
                if(TouchingObject != null) TouchingObject.transform.parent = null;
            }


            //flip logic

            if(facingRight && move < 0) flip();
            else if(!facingRight && move > 0) flip();

            //restart logic

            if(life <= 0) restardCheckpoint();

            //invencibility logic

            if(invencibility)
            {
                framesCounterhit = 0;
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                framesCounter += Time.deltaTime;
                if(framesCounter >= invencibilityTime)
                {
                    invencibility = false;
                    framesCounter = 0;
                }
            }
            else gameObject.GetComponent<SpriteRenderer>().color = playercolor;
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
        if (GodMode) movevertical = Input.GetAxis("Vertical");
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
      if(TouchingObject != null)  TouchingObject.GetComponent<BoxPropierties>().rb.velocity = new Vector2(0, forcedown);

        if (TouchingObject.GetComponent<BoxPropierties>().spritecolor < 1 && pushing)
        {
            TouchingObject.transform.parent = graphics.transform;
            if (facingRight)
            {
                TouchingObject.transform.position = new Vector3(gameObject.transform.position.x + 1.1f, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            else
            {
                TouchingObject.transform.position = new Vector3(gameObject.transform.position.x - 1.1f, gameObject.transform.position.y, gameObject.transform.position.z);
            }
        }
        else
        {
            pushing = !pushing;
        }
    }

    void aimObject()
    {


        aimhit = Physics2D.Linecast(gameObject.transform.position + dir, mousePosition2D, raymask);


        if (aimhit)
        {
            rayhit = aimhit.transform.gameObject;
            print("he tocado algo");
            framesCounter += Time.deltaTime;
        }
        else
        {
            rayhit = null;
            framesCounter = 0;
        }

        if (rayhit != null && rayhit.tag == "Material")
        {

            castbar.Charge_Bar(getcoldown);

            if (framesCounter >= getcoldown)
            {
                saveMaterial = rayhit;
                print("he tocado un materiaL");
                framesCounter = 0;
            }
        }

        else castbar.framesCounter = 0;
    }

    void changeMaterial()
    {


       changehit = Physics2D.Linecast(gameObject.transform.position + dir, mousePosition2D, raymask);


        if (Physics2D.Linecast(gameObject.transform.position + dir, mousePosition2D, raymask))
        {

            objectToChange = changehit.transform.gameObject;
            framesCounter += Time.deltaTime;

          //  bar.GetComponent<castbar>().fastup();

            if (objectToChange.tag == "Box" && framesCounter >= setcoldown && saveMaterial != null)
            {

                castbar.framesCounter = 0;

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
        else
        {
            objectToChange = null;
            framesCounter = 0;
            //bar.GetComponent<castbar>().down();
        }

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


    void OnTriggerEnter(Collider other)
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

    public void OnPause()
    {

        if (IsPaused)
        {
            Time.timeScale = 0.0f;
            pause.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            pause.SetActive(false);
        }
    }
}
