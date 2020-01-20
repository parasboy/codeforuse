using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public EnemyBehaviour enemy;
	public Vector2 enemySpawnTimeMinMax;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnEnemy", Random.Range (enemySpawnTimeMinMax.x, enemySpawnTimeMinMax.y), Random.Range (enemySpawnTimeMinMax.x, enemySpawnTimeMinMax.y));
	}

	void SpawnEnemy (){
		Instantiate (enemy, transform.position, Quaternion.identity);
	}
}
