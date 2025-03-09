using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planet2 : MonoBehaviour
{
    public GameObject wynik;
    public GameObject panel;
    bool start = false;

    public Texture[] textures;
    public Renderer rend;

    int rn;

    void Start()
    {
        rend = GetComponent<Renderer>();
        //wynik.SetActive(false);
        wynik.SetActive(true);
        panel.SetActive(false);
        start = true;
        a = 0;
        
        rn = Random.Range(0, 12);
        
    }
    int x = 0;
    public int a = 0;
    void Update()
    {
        if (a <= 1500 && start == true)
            transform.localScale -= new Vector3(0.002F, 0.002f, 0.002f);

        
        if(x==0)
        rend.material.mainTexture = textures[rn];
        x++;
        a++;
        
    }

    public void StartGame()
    {
        rn = Random.Range(0, 12);
        //rend.material.mainTexture = textures[rn];
    }



}
