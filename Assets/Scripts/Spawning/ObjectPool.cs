using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
	[SerializeField] GameObject prefab;
	[SerializeField] int poolSize = 10;
	[SerializeField] int growPoolBy = 10;
	[SerializeField] bool populateOnAwake = false;

	public GameObject[] pooledObjects = new GameObject[0];

	int currentIndex = 0;

	public ObjectPool(GameObject newPrefab, int newPoolSize, int newGrowPoolBy)
	{
		this.prefab = newPrefab;
		this.poolSize = newPoolSize;
		this.growPoolBy = newGrowPoolBy;
	}

	public ObjectPool(GameObject newPrefab)
	{
		int defaultPoolSize = 10;

		this.prefab = newPrefab;
		this.poolSize = defaultPoolSize;
		this.growPoolBy = defaultPoolSize;

		PopulatePool();
	}

	public ObjectPool() { }

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
			PoolObject poolObject = pooledObjects[i].GetComponent<PoolObject>();
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
			objectsToPool[i].SetActive(false);
		}

		pooledObjects = pooledObjects.Concat(objectsToPool).ToArray();
		poolSize = pooledObjects.Length;
	}

}
