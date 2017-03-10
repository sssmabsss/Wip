using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown("3")) SceneManager.LoadScene("blood");

        if (Input.GetKeyDown("1")) SceneManager.LoadScene("hoguera");

        if (Input.GetKeyDown("2")) SceneManager.LoadScene("circulo");

    }
}
