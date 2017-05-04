using UnityEngine;
using System.Collections;

public class PeopleSpawner : MonoBehaviour {

    public GameObject people;//enemyプレハブ

    public float interval;//敵の発生間隔

    public float positionRandamize;//発生位置をランダムにする幅の指定
    public float maxtime;
    public float mintime;
    public float latetime = 0.125f;
    private int count=0;
    private Vector3 spawnPosition;//Enemy Spawner の位置を取得

	// Use this for initialization
	IEnumerator Start () 
    {
        spawnPosition = transform.position;

        while (true)
        {
            //spawnPosition = transform.position;
            spawnPosition = new Vector3(spawnPosition.x + (Random.Range(positionRandamize, -positionRandamize)), spawnPosition.y, spawnPosition.z);

            Instantiate(people, spawnPosition, Quaternion.identity);
            count++;

            float randmax  = maxtime - count * latetime;
            if(randmax<=mintime)
            {
                randmax = mintime;
            }
            interval = Random.Range(mintime, randmax);
            yield return new WaitForSeconds(interval);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
