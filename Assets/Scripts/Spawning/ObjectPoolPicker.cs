using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolPicker : MonoBehaviour
{
	public GameObject[] objectsToPool;
    ObjectPool[] objectPools = null;

	GameObject[] poolGameObjects;

	public ObjectPool FindPool(ObjectPoolType poolType)
	{
		if(objectPools == null)
		{
			SetUpPools();
		}

		int poolIndex = (int)poolType;

		if(objectPools[poolIndex] == null)
		{
			GameObject objectToPool = objectsToPool[poolIndex];			
			ObjectPool newPool = poolGameObjects[poolIndex].AddComponent<ObjectPool>();
			poolGameObjects[poolIndex].name = objectToPool.name + " Pool";
			newPool.PopulatePool(objectToPool);
			objectPools[poolIndex] = newPool;
		}
		return objectPools[poolIndex];
	}

	private void SetUpPools()
	{
		int numberOfPools = (int)ObjectPoolType.COUNT;
		poolGameObjects = new GameObject[numberOfPools];
		for(int i = 0; i < numberOfPools; i++)
		{
			poolGameObjects[i] = new GameObject();
			poolGameObjects[i].name = "Object Pool (" + i.ToString() + ")";
			poolGameObjects[i].transform.parent = transform;
		}
		objectPools = new ObjectPool[numberOfPools];
	}

}
