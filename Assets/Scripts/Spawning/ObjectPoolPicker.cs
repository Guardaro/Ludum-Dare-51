using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolPicker : MonoBehaviour
{
	public GameObject[] objectsToPool;
    ObjectPool[] objectPools = null;

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
			ObjectPool newPool = gameObject.AddComponent<ObjectPool>();
			newPool.PopulatePool(objectToPool);
			objectPools[poolIndex] = newPool;
		}
		return objectPools[poolIndex];
	}

	private void SetUpPools()
	{
		int numberOfPools = (int)ObjectPoolType.COUNT;
		objectPools = new ObjectPool[numberOfPools];
	}

}
