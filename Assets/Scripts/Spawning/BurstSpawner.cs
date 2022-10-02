using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstSpawner : MonoBehaviour
{
	[SerializeField] int numberToSpawn;
	[SerializeField] float angleBetween = 15f;

	[SerializeField] BulletPool pool;

	public void Spawn()
	{
		float startingAngle = (angleBetween / 2f) * (1 - numberToSpawn);
		for(int i = 0; i < numberToSpawn; i++)
		{
			GameObject spawn = pool.GetPooledObject();
			PoolObject poolObject = spawn.GetComponent<PoolObject>();
			if(poolObject != null)
			{
				poolObject.Disable();
			}
			spawn.transform.position = transform.position;
			spawn.transform.rotation = transform.rotation;
			if (poolObject != null)
			{
				poolObject.Enable();
			}

			Vector3 rotateVector = Vector3.zero;
			rotateVector.z = startingAngle + angleBetween * i;
			spawn.transform.Rotate(rotateVector);
		}
	}
}
