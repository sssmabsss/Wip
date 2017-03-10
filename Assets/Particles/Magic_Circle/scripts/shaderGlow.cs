using UnityEngine;
using System.Collections;

public class shaderGlow : MonoBehaviour {

	public Color color;
	public Material material;
	public float minGlow, maxGlow;
	public bool Glowing;
	public float smoothVelocity;

	// Use this for initialization
	void Start () {
	
		material = GetComponent<MeshRenderer> ().sharedMaterial;
		color = material.GetColor ("_TintColor");
		color.a = 0;
		material.SetColor ("_TintColor", color);

		Glowing = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (Glowing) {
		
			color.a += Time.deltaTime * smoothVelocity;
			if (color.a > maxGlow)
				Glowing = false;
		} else {
			color.a -= Time.deltaTime * smoothVelocity;
			if (color.a < minGlow)
				Glowing = true;
		}

		material.SetColor ("_TintColor", color);

	
	}
}
