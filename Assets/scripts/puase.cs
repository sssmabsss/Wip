using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puase : MonoBehaviour {

    public bool IsPaused;

	void Start () {
        IsPaused = false;
	}
	

	void Update () {

        if(Input.GetKeyDown("escape")) IsPaused = !IsPaused;

    }
}
