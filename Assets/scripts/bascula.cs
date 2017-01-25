using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bascula : MonoBehaviour
{
    public Vector3 angulos;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        angulos = gameObject.transform.rotation.eulerAngles;
        if (angulos.z >= 35) {

            transform.rotation = Quaternion.Euler(0, 0, 35);
        }
    }
}