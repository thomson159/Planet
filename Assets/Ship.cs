using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Texture[] textures;
    public Renderer rend;

    public GameObject panel;

    public int skinnumber = 0;

    public float point;
    float cos;

    int rnd = -2;
    

    void Start ()
    {
        rend = GetComponent<Renderer>();
        rend.material.mainTexture = textures[0];

        point = PlayerPrefs.GetFloat("point");


        if(point > PlayerPrefs.GetFloat("granica"))
        {
            cos = PlayerPrefs.GetFloat("granica");

            cos += 50000;

            PlayerPrefs.SetFloat("granica", cos);

            rnd = Random.Range(1, 6);

            while(true)
            {
                if (rnd == PlayerPrefs.GetFloat("rnd1") || rnd == PlayerPrefs.GetFloat("rnd2") || rnd == PlayerPrefs.GetFloat("rnd3") || rnd == PlayerPrefs.GetFloat("rnd4") || rnd == PlayerPrefs.GetFloat("rnd5"))
                {
                    rnd = Random.Range(1, 6);
                }
                else
                {
                    break;
                }
            }

        }
    }
	
	void Update ()
    {
        
        if(skinnumber == 0)
        {
            panel.SetActive(false);
        }
        if(skinnumber == 1)
        {
            if (rnd == 1)
            {
                panel.SetActive(false);

                PlayerPrefs.SetFloat("rnd1", rnd);

            }
            if(PlayerPrefs.GetFloat("rnd1") == 1)
            {
                panel.SetActive(false);
            }
            else
            {
                panel.SetActive(true);
            }
        }
        if (skinnumber == 2)
        {
            if (rnd == 2)
            {
                panel.SetActive(false);

                PlayerPrefs.SetFloat("rnd2", rnd);
            }
            if(PlayerPrefs.GetFloat("rnd2") == 2)
            {
                panel.SetActive(false);
            }
            else
            {
                panel.SetActive(true);
            }
        }
        if (skinnumber == 3)
        {
            if (rnd == 3)
            {
                panel.SetActive(false);

                PlayerPrefs.SetFloat("rnd3", rnd);
            }
            if (PlayerPrefs.GetFloat("rnd3") == 3)
            {
                panel.SetActive(false);
            }
            else
            {
                panel.SetActive(true);
            }
        }
        if (skinnumber == 4)
        {
            if (rnd == 4)
            {
                panel.SetActive(false);

                PlayerPrefs.SetFloat("rnd4", rnd);
            }
            if (PlayerPrefs.GetFloat("rnd4") == 4)
            {
                panel.SetActive(false);
            }
            else
            {
                panel.SetActive(true);
            }
        }
        if (skinnumber == 5)
        {
            if (rnd == 5)
            {
                panel.SetActive(false);

                PlayerPrefs.SetFloat("rnd5", rnd);
            }
            if (PlayerPrefs.GetFloat("rnd5") == 5)
            {
                panel.SetActive(false);
            }
            else
            {
                panel.SetActive(true);
            }
        }

        rend.material.mainTexture = textures[skinnumber];
    }

    public void NextSkin()
    {
        skinnumber++;

        if (skinnumber > 5)
            skinnumber = 0;
    }

    public void BackSkin()
    {
        skinnumber--;

        if (skinnumber < 0)
            skinnumber = 5;
    }

    public void ThisShip()
    {
        PlayerPrefs.SetFloat("Ship", skinnumber);
    }
}
