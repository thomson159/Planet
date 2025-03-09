using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planet : MonoBehaviour
{
    public GameObject wynik;
    public GameObject panel;
    bool start = false;
    
   
    void Start ()
    {
        wynik.SetActive(false);
       

    }
    public int a = 0;
	void Update ()
    {
        if(a <= 1500 && start == true)
        transform.localScale -= new Vector3(0.002F, 0.002f, 0.002f);

        a++;
        

    }

    public void StartGame()
    {
        wynik.SetActive(true);
        panel.SetActive(false);
        start = true;
        a = 0;
        
    }

}
