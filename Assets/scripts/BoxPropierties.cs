using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPropierties : MonoBehaviour {

    [Header("forces")]
    public int weight;
    public bool isTouchingWall;
    public Vector2 rbvelocity;

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
