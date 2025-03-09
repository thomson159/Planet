using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textureship : MonoBehaviour
{

    public Texture[] textures;
    public Renderer rend;

    public float x;

    void Start ()
    {
        rend = GetComponent<Renderer>();

        x = PlayerPrefs.GetFloat("Ship");

        rend.material.mainTexture = textures[(int)x];
    }
	
	void Update ()
    {
		
	}
}
