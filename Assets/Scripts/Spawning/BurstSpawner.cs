using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstSpawner : MonoBehaviour
{
	[SerializeField] ObjectPoolType objectToSpawn;
	[SerializeField] int numberToSpawn;
	[SerializeField] float angleBetween = 15f;

	ObjectPool pool;

	private void Awake()
	{
		ObjectPoolPicker picker = FindObjectOfType<ObjectPoolPicker>();
		pool = picker.FindPool(objectToSpawn);
	}

	public void Spawn()
	{
		float startingAngle = (angleBetween / 2f) * (1 - numberToSpawn);
		for(int i = 0; i < numberToSpawn; i++)
		{
			GameObject spawn = pool.GetPooledObject();
			spawn.transform.position = transform.position;
			spawn.transform.rotation = transform.rotation;
			Vector3 rotateVector = Vector3.zero;
			rotateVector.z = startingAngle + angleBetween * i;
			spawn.transform.Rotate(rotateVector);
		}
	}
}
