using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPropierties : MonoBehaviour {

    [Header("forces")]
    public int weight;
    public bool isTouchingWall;
    public Vector2 rbvelocity;
    public float normalAngle;
    public GameObject rayhit;
    public LayerMask hitmask;
    public float angulosZ;

    [Header("weights")]
    public Rigidbody2D rb;
    public int forcedown;

    [Header("Sprites")]
    private SpriteRenderer sp;
    public int spritecolor =3;
    public Sprite verde;
    public Sprite amarilla;
    public Sprite roja;

    [Header("initial values")]
    public Vector3 InitialPosition;
    public int InitialMaterial;



    // Use this for initialization
    void Start() {

        isTouchingWall = false;
        sp  = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        InitialPosition = gameObject.transform.position;
        InitialMaterial = spritecolor;
        rb.velocity = new Vector2(0,forcedown);

    }

    void Update() {

        changeMaterial();
        rbvelocity = rb.velocity;



        //getting normals
        
        Vector2 rayposition = new Vector2(transform.position.x, transform.position.y);

        Debug.DrawRay(rayposition, Vector2.down, Color.magenta);

        RaycastHit2D groundhit = Physics2D.Raycast(rayposition, Vector2.down, 1, hitmask);

        if (Vector2.Angle(groundhit.normal, Vector2.up) != 0) normalAngle = Vector2.Angle(groundhit.normal, Vector2.up);

        if (rayhit != null) rayhit = groundhit.transform.gameObject;

       // Vector3 anglerotate = new Vector3(0, 0, normalAngle);

        angulosZ = transform.rotation.z;

        // assigns the raycast's normal direction to the VisualMesh' up directio. this makes it look 'from the surface'
        // then use some lerping, to smooth it all out
        transform.up = Vector3.Lerp(transform.up, groundhit.normal, Time.deltaTime * 10);

        // this part makes sure the Y rotation is properly preserved from the parent gameObject as well
        transform.RotateAround(transform.position, transform.up, transform.localEulerAngles.y);

    }

    void changeMaterial()
    {
        switch (spritecolor)
        {
            case 0:
               // print("Material Ligero");
                sp.sprite = verde;
                rb.mass = 10;

                break;
            case 1:
              //  print("material mediano");
                sp.sprite = amarilla;
                rb.mass = 30;
                break;
            case 2:
              //  print("Material Pesado");
                sp.sprite = roja;
                rb.mass = 100;
                break;
            default:
              //  print("Material por defecto");
                break;
        }
    }

    public void respawn()
    {

        gameObject.transform.position = InitialPosition;
        spritecolor = InitialMaterial;

    }
}
