using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanager : MonoBehaviour {

    public float soundlevel;
    public float fxLevel;

    public AudioSource sound1;
    public AudioSource sound2;
    public AudioSource sound3;
    public AudioSource sound4;
    public AudioSource sound5;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        sound1.volume = fxLevel;
        sound2.volume = soundlevel;
        sound3.volume = soundlevel;
        sound4.volume = soundlevel;
        sound5.volume = soundlevel;

    }
}
