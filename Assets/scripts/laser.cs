using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour {

    public Vector3 startpoint, endpoint;
    public LineRenderer lr;
    public Vector2 linewidth;
    public Vector3 dir;
    public LayerMask laserMask;
    public RaycastHit2D hit;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        
    }
    void Update()
    {
        Vector3 faraway = new Vector3(-100, 0, 0);
        startpoint = transform.position;
        endpoint = transform.position;


        hit = Physics2D.Linecast(gameObject.transform.position + dir, faraway, laserMask);

        if (hit)
        {
            Debug.DrawLine(gameObject.transform.position + dir, hit.transform.position, Color.yellow);
            endpoint.x = hit.transform.position.x;
            
        }
        else
        {
            Debug.DrawLine(gameObject.transform.position + dir, faraway, Color.yellow);
        }


        lr.SetPosition(0, startpoint);
        lr.SetPosition(1, endpoint);

        damage();

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
}