using UnityEngine;
using System.Collections;

public class bombbehaviour : MonoBehaviour {
    public ParticleSystem pr1;
    public ParticleSystem pr2;
    public GameObject boomb;
    public AudioSource bomb;
    public AudioSource n;
    public bool active;

    // Use this for initialization
    void Start () {

        active = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space") && active)
        {
            pr1.Play();
            pr2.Play();
            boomb.SetActive(false);
            active = false;

        }

        /*if (Input.GetButton("Fire1") && !active)
        {
            n.Play();
            n.Play(44100);
            boomb.SetActive(true);
            active = true;

        }*/
    }
}
