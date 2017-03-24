using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour {

    public Vector3 startpoint, endpoint;
    public GameObject start;
    public LineRenderer lr;
    public Vector2 linewidth;
    public Vector3 dir;
    public LayerMask laserMask;
    public RaycastHit2D hit;
    public float distance;
    public Material m;
    public float tilling; 

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        
    }
    void Update()
    {
        Vector3 faraway = new Vector3(-100, 0, 0);
        startpoint = start.transform.position;
        // endpoint = transform.position;
        distance = endpoint.x - startpoint.x;

        hit = Physics2D.Linecast(startpoint + dir, faraway, laserMask);

        if (hit)
        {
            Debug.DrawLine(gameObject.transform.position + dir, hit.transform.position, Color.yellow);
            endpoint = hit.point;
            
        }
        else
        {
            Debug.DrawLine(gameObject.transform.position + dir, faraway, Color.yellow);
        }


        lr.SetPosition(0, startpoint);
        lr.SetPosition(1, endpoint);

        damage();
        tiling();

    }

    public void damage()
    {
        if (hit.transform.gameObject.tag == "Player") hit.transform.gameObject.GetComponent<plyer>().takingdamage();
        else if (hit.transform.gameObject.tag == "Danger") hit.transform.gameObject.GetComponent<patruller>().respawn();
        else if (hit.transform.gameObject.tag == "Box")
        {
            if (hit.transform.gameObject.GetComponent<BoxPropierties>().spritecolor < 1)
            {
                hit.transform.gameObject.GetComponent<BoxPropierties>().respawn();
            }
        }
    }

    public void tiling()
    {
        m.SetTextureScale("_MainTex", new Vector2(distance/3, 1));

    }
}