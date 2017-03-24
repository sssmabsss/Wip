using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class material_anim : MonoBehaviour
{


    public Texture[] textures;
    public float changeInterval = 0.33F;
    public Material material;

    void Start()
    {

    }

    void Update()
    {
        if (textures.Length == 0)
            return;

        int index = Mathf.FloorToInt(Time.time / changeInterval);
        index = index % textures.Length;
        material.mainTexture = textures[index];
    }
}
