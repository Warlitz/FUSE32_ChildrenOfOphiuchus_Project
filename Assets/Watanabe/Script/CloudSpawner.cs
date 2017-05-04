using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{

    public GameObject Cloud;

    public float interval;

    public float positionRandamize;

    private Vector3 spawnPosition;



    // Use this for initialization
    IEnumerator Start()
    {

        spawnPosition = transform.position;

        while (true)
        {
            spawnPosition = new Vector3(Random.Range(positionRandamize, -positionRandamize), spawnPosition.y, spawnPosition.z);
            Instantiate(Cloud, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(interval);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
