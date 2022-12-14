using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BulletPool : MonoBehaviour
{
	[SerializeField] GameObject prefab;
	[SerializeField] int poolSize = 10;
	[SerializeField] int growPoolBy = 10;
	[SerializeField] bool populateOnAwake = false;

	public GameObject[] pooledObjects = new GameObject[0];

	int currentIndex = 0;

	float damageAmount = 10f;
	float damageMultiplier = 1.185f;

	float sineRotationAmplitude = 0f;
	float sineAmplitudeIncrement = 11.25f;

	float stunAmount = 0f;
	float stunIncrement = 0.25f;

	private void Awake()
	{
		if (populateOnAwake) { PopulatePool(); }
	}

	public virtual void PopulatePool()
	{
		pooledObjects = new GameObject[poolSize];

		for (int i = 0; i < poolSize; i++)
		{
			pooledObjects[i] = Instantiate(prefab);
			pooledObjects[i].transform.parent = transform;
			Bullet bullet = pooledObjects[i].GetComponent<Bullet>();
			bullet.SetDamage(damageAmount);
			bullet.SetSineRotationAmplitude(sineRotationAmplitude);
			PoolObject poolObject = pooledObjects[i].GetComponent<PoolObject>();
			if (poolObject != null)
			{
				poolObject.Disable();
			}
			pooledObjects[i].SetActive(false);
		}
	}

	public virtual void PopulatePool(GameObject newPrefab)
	{
		prefab = newPrefab;
		PopulatePool();
	}

	public virtual GameObject GetPooledObject()
	{
		GameObject nextInactiveObject = GetNextInactiveObject();

		if (nextInactiveObject == null)
		{
			GrowPool();
			nextInactiveObject = GetNextInactiveObject();
		}

		return nextInactiveObject;
	}

	private GameObject GetNextInactiveObject()
	{
		GameObject nextInactiveObject = null;
		int numberOfAttempts = 0;
		while (numberOfAttempts < poolSize && nextInactiveObject == null)
		{
			if (pooledObjects[currentIndex].activeSelf == false)
			{
				nextInactiveObject = pooledObjects[currentIndex];
				nextInactiveObject.SetActive(true);
			}
			else
			{
				numberOfAttempts++;
				currentIndex++;
				if (currentIndex >= poolSize)
				{
					currentIndex = 0;
				}
			}
		}
		return nextInactiveObject;
	}

	public virtual void GrowPool()
	{
		GameObject[] objectsToPool = new GameObject[growPoolBy];
		for (int i = 0; i < growPoolBy; i++)
		{
			objectsToPool[i] = Instantiate(prefab);
			objectsToPool[i].transform.parent = transform;
			Bullet bullet = objectsToPool[i].GetComponent<Bullet>();
			bullet.SetDamage(damageAmount);
			bullet.SetSineRotationAmplitude(sineRotationAmplitude);
			objectsToPool[i].SetActive(false);
			PoolObject poolObject = objectsToPool[i].GetComponent<PoolObject>();
			if (poolObject != null)
			{
				poolObject.Disable();
			}
		}
		pooledObjects = pooledObjects.Concat(objectsToPool).ToArray();
		poolSize = pooledObjects.Length;
	}

	public void IncreaseDamage()
	{
		damageAmount *= damageMultiplier;
		for(int i = 0; i < pooledObjects.Length; i++)
		{
			Bullet currentBullet = pooledObjects[i].GetComponent<Bullet>();
			currentBullet.SetDamage(damageAmount);
		}
	}

	public void HalveDamage()
	{
		damageAmount *= 0.5f;
		for (int i = 0; i < pooledObjects.Length; i++)
		{
			Bullet currentBullet = pooledObjects[i].GetComponent<Bullet>();
			currentBullet.SetDamage(damageAmount);
		}
	}

	public void IncreaseSineRotation()
	{
		sineRotationAmplitude += sineAmplitudeIncrement;
		for (int i = 0; i < pooledObjects.Length; i++)
		{
			Bullet currentBullet = pooledObjects[i].GetComponent<Bullet>();
			currentBullet.SetSineRotationAmplitude(sineRotationAmplitude);
		}
	}

	public void IncreaseStun()
	{
		stunAmount += stunIncrement;
		for (int i = 0; i < pooledObjects.Length; i++)
		{
			Bullet currentBullet = pooledObjects[i].GetComponent<Bullet>();
			currentBullet.SetStun(stunAmount);
		}
	}
}
