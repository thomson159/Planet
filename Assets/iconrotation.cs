using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class iconrotation : MonoBehaviour
{
    int a = -2;
    int b = 0;
    int c = 0;
    public GameObject gm;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        b++;
        
        transform.Rotate(0, 0, a);

        if (b == 40)
        {
            a = a * -1;
            b = 0;
            c++;
        }

        if(c == 8)
        {
            gm.SetActive(false);
        }
    }

    public void StartGame()
    {
        gm.SetActive(true);
    }

}
