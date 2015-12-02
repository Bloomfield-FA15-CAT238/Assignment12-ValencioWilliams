using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class MyGameController : NetworkBehaviour {
	public GameObject enemyPrefab;
	
	private float spawnEnemyTime = 0;
	
	void Update () {
		// We only want the server to handle this...
		if(isServer) {
			if(Time.fixedTime>spawnEnemyTime) {
				SpawnEnemy();
			}
		}
	}
	
	[Server]
	public void SpawnEnemy() {
		Vector3 position = new Vector3(Random.Range(-6.75f,6.75f),Random.Range(1.0f,8.0f),4.5f);
		GameObject enemy = (GameObject)Instantiate(enemyPrefab, position, Quaternion.identity);
		NetworkServer.Spawn(enemy);
		spawnEnemyTime = Time.fixedTime + Random.Range(3,8);
	}
}