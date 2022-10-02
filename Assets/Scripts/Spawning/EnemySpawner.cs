using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] ObjectPoolType objectToSpawn = ObjectPoolType.Enemy;
	[SerializeField] Transform player;
	[SerializeField] Transform spawnPoint;

	public float timeBetweenSpawns = 10f;

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
		PoolObject poolObject = spawnObject.GetComponent<PoolObject>();
		poolObject.Disable();
		spawnObject.transform.position = spawnPoint.position;
		poolObject.Enable();

		ApproachTarget movement = spawnObject.GetComponent<ApproachTarget>();
		movement.target = player;
	}

}
