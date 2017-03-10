using UnityEngine;
using System.Collections;

public class rotar : MonoBehaviour {

	public Transform tr;
	public float AngularV;
	public Vector3 axis;
	// Use this for initialization
	void Start () {
	
		tr = this.transform;
	}
	
	// Update is called once per frame
	void Update () {

		tr.Rotate (axis * AngularV * Time.deltaTime, Space.World);
	
	}
}
