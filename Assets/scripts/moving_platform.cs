using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_platform : MonoBehaviour
{

    public Transform target;
    public Transform startposition;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    public bool movingleft, movingright;
    public float timer;
    public float framescounter;

    // Use this for initialization
    void Start()
    {
        movingright = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!movingright) transform.position = Vector3.SmoothDamp(transform.position, startposition.position, ref velocity, smoothTime);
        if (movingright) transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
    }
}
