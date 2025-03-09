using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn2 : MonoBehaviour
{
    public GameObject meteorPrefab;

    bool start5 = false;

    void Start()
    {
        //if(start5==true)
        StartCoroutine(SpawnMeteor());

        start5 = true;
    }

    IEnumerator SpawnMeteor()
    {

        Vector3 pos = Random.onUnitSphere * 30;

        if (start5 == true)
        {
            Instantiate(meteorPrefab, pos, Quaternion.identity);
        }

        yield return new WaitForSeconds(1f);
        StartCoroutine(SpawnMeteor());

    }

    void Update()
    {

    }

    public void StartGame()
    {
        //start5 = true;
    }

}
