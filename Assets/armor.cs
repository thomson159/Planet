using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armor : MonoBehaviour
{   
	void Start ()
    {
		
	}

	void Update ()
    {
        transform.Rotate(3, 3, 3);

    }

	IEnumerator OnTriggerEnter(Collider other)
	{
		if (other.tag == "Planet")
		{
			yield return new WaitForSeconds (10f);

			Destroy (this.gameObject);
		}
	}
}
