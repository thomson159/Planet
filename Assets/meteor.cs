using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor : MonoBehaviour
{
    public GameObject gm;

    public GameObject armor;
    public GameObject rocket;

	void Start ()
    {
		
	}
    bool endit = false;
    public void FixedUpdate()
    {
        //if(endit == false)
        //DrawLine( gm.transform.position, Vector3.zero, Color.red, 0.1f);
    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        if(other.tag == "Planet")
        {
            endit = true;

            int r = Random.Range(0, 20);

            //yield return new WaitForSeconds(1f);
            //if (r == 1)
            //Instantiate(armor, gm.transform.position, Quaternion.identity);

            //armor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;

            yield return new WaitForSeconds(8f);
            if (r == 1)
                Instantiate(armor, gm.transform.position, Quaternion.identity);
            if (r == 2)
                Instantiate(rocket, gm.transform.position, Quaternion.identity);
            Destroy(gm.gameObject);
        }
    }

    //void DrawLine(Vector3 start, Vector3 end, Color color, float duration)
    //{
    //    GameObject myLine = new GameObject();

    //    myLine.transform.position = start;

    //    myLine.AddComponent<LineRenderer>();
    //    LineRenderer lr = myLine.GetComponent<LineRenderer>();
    //    lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
    //    lr.SetColors(color, color);
    //    lr.SetWidth(0.1f, 0.1f);
    //    lr.SetPosition(0, start);
    //    lr.SetPosition(1, end);
    //    GameObject.Destroy(myLine, duration);
    //}
}
