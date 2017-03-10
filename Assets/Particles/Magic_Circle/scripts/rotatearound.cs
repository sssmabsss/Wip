using UnityEngine;
using System.Collections;

public class rotatearound : MonoBehaviour {

	public float smoothVelocity;
	public Transform center;
	public float velocity;
	public Vector3 direction;
    public int max;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		direction = center.position - this.transform.position;
		direction = direction.normalized;

		gameObject.transform.RotateAround (Vector3.zero, Vector3.up, smoothVelocity * Time.deltaTime);
		gameObject.transform.Translate (direction * Time.deltaTime *velocity, Space.World);

		if (Vector3.Distance (center.position, this.transform.position) < 1) {
			
			velocity *= -1;
		}
		else if (Vector3.Distance (center.position, this.transform.position) > max) velocity *= -1;


		//print("Distance: " + Vector3.Distance(center.position, this.transform.position));
	
	}
}
