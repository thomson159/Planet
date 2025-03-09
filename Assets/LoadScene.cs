using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    
	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void Restart()
    {
        SceneManager.LoadScene("PlanetScene2");
    }

    public void Restart2()
    {
        SceneManager.LoadScene("PlanetScene");
    }

    public void Ships()
    {
        SceneManager.LoadScene("PlanetShips");
    }

	public void facebook()
	{
		Application.OpenURL("https://www.facebook.com/mbrothersgame/");
	}

	public void play()
	{
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.MBrothers.SpaceEscape");
	}
}
