using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSpawner : MonoBehaviour
{
	[SerializeField] ObjectPool objectPool;
	public Vector2 positionRandomness;

	public float interval = 1f;
	public float delayBeforeFirstSpawn = 0f;

	protected float nextSpawnTime;

	protected void Awake()
	{
		nextSpawnTime = Time.time + delayBeforeFirstSpawn;
	}

	private void FixedUpdate()
	{
		if(Time.time >= nextSpawnTime)
		{
			Spawn();
			nextSpawnTime = Time.time + interval;
		}
	}

	protected void Spawn()
	{
		GameObject spawn = objectPool.GetPooledObject();
		PoolObject poolObject = spawn.GetComponent<PoolObject>();
		if(poolObject != null) { poolObject.Disable(); }
		float xRandomness = Random.Range(-positionRandomness.x, positionRandomness.x);
		float yRandomness = Random.Range(-positionRandomness.y, positionRandomness.y);
		Vector3 randomAdjustment = new Vector2(xRandomness, yRandomness);
		spawn.transform.position = transform.position + randomAdjustment;
		spawn.transform.rotation = transform.rotation;
		if(poolObject != null) { poolObject.Enable(); }
	}

	public void ToggleActivation()
	{
		gameObject.SetActive(!gameObject.activeSelf);
	}

	private void OnEnable()
	{
		nextSpawnTime = Time.time + delayBeforeFirstSpawn;
	}
}
