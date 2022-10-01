using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] ObjectPoolType objectToSpawn = ObjectPoolType.Enemy;
	[SerializeField] Transform player;
	[SerializeField] Transform spawnPoint;

	float spawnDistance = 30f;

	float timeBetweenSpawns = .1f;

	float nextSpawnTime = 0f;

	ObjectPool pool;

	private void Awake()
	{
		ObjectPoolPicker poolPicker = FindObjectOfType<ObjectPoolPicker>();
		pool = poolPicker.FindPool(objectToSpawn);
	}

	private void Update()
	{
		if(Time.time >= nextSpawnTime)
		{
			Spawn();
			nextSpawnTime = Time.time + timeBetweenSpawns;
		}
	}

	private void Spawn()
	{
		float randomRotation = Random.Range(0, 360f);
		transform.Rotate(new Vector3(0, 0, randomRotation));

		GameObject spawnObject = pool.GetPooledObject();
		spawnObject.transform.position = spawnPoint.position;

		ApproachPlayer movement = spawnObject.GetComponent<ApproachPlayer>();
		movement.target = player;
	}

}
