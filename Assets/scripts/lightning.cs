using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightning : MonoBehaviour {


    public ParticleSystem ps;
    public Color woodColor;
    public Color StoneColor;
    public Color MetalColor;
    public Vector3 mousePosition;

    public Transform Target;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);


        // Get Angle in Radians
        float AngleRad = Mathf.Atan2(mousePosition.y - gameObject.transform.position.y, mousePosition.x - gameObject.transform.position.x);
        // Get Angle in Degrees
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        // Rotate Object
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
    }

    void getWood()
    {
       var m = ps.main;

        ps.Play();
        m.startColor = woodColor;
    }

    void getStone()
    {
        var m = ps.main;

        ps.Play();
        m.startColor = woodColor;
    }

    void getMetal()
    {
        var m = ps.main;

        ps.Play();
        m.startColor = woodColor;
    }

    void setWood()
    {
        var m = ps.main;

        ps.Play();
        m.startColor = woodColor;
    }

    void setStone()
    {
        var m = ps.main;

        ps.Play();
        m.startColor = woodColor;
    }

    void setMetal()
    {
        var m = ps.main;

        ps.Play();
        m.startColor = woodColor;
    }
}
