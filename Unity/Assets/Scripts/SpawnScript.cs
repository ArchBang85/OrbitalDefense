using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	
	
	public GameObject[] enemyPreFab;
	public GameObject LeftEdge, RightEdge;
	
	private float spawnCounter;
	
	public float enemySpawnMax = 5f;
	public float enemySpawnMin = 0.5f;
	public bool canSpawn = true;
	
	// Use this for initialization
	void Start () {
		
		spawnCounter = Random.Range(enemySpawnMin, enemySpawnMax);
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (canSpawn) 
		{
			if (spawnCounter > 0)
			{
				spawnCounter -= Time.deltaTime;
			}
			else
			{
				Instantiate (enemyPreFab[Random.Range(0,enemyPreFab.Length)], 
					new Vector3(Random.Range(LeftEdge.transform.position.x, RightEdge.transform.position.x), 
					Random.Range(LeftEdge.transform.position.y, RightEdge.transform.position.y), Random.Range (0, 40)*0.1f), Quaternion.identity);
				spawnCounter = Random.Range (enemySpawnMin, enemySpawnMax);
			}
		}
		
	}
}
