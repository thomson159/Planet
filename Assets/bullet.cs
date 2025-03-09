using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public GameObject boom;
    
	void Start ()
    {
		
	}
	
	void Update ()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        Destroy(gameObject, 1.5f);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "meteor")
        {
            Destroy(collider.gameObject);
            Instantiate(boom, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
        }
    }
}
