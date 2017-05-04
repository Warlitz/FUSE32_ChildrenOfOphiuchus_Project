using UnityEngine;
using System.Collections;

public class EnamySpawner : MonoBehaviour {

    public GameObject people;//enemyプレハブ

    public float interval;//敵の発生間隔

    public float positionRanamize;//発生位置をランダムにする幅の指定
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
            spawnPosition.x += Random.Range(-positionRanamize, positionRanamize);
    
            Instantiate(people, spawnPosition, Quaternion.identity);
            count++;

            float randmax  = maxtime - count * latetime;
            if(randmax<=mintime)
            {
                randmax = mintime;
            }
            interval = Random.Range(0, randmax);
            yield return new WaitForSeconds(interval);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
