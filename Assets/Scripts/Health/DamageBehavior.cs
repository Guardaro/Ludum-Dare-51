using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBehavior : MonoBehaviour
{
	ObjectPool damagePool = null;

	public virtual void TakeDamage(float damageAmount)
	{
		CheckForExistingDamagePool();
		DamageIndicator damageIndicator = SpawnIndicator();
		damageIndicator.AddDamage(damageAmount);
	}

	private DamageIndicator SpawnIndicator()
	{
		GameObject indicatorSpawn = damagePool.GetPooledObject();
		indicatorSpawn.transform.position = transform.position;
		return indicatorSpawn.GetComponent<DamageIndicator>();
	}

	private void CheckForExistingDamagePool()
	{
		if (damagePool == null)
		{
			ObjectPoolPicker picker = FindObjectOfType<ObjectPoolPicker>();
			damagePool = picker.FindPool(ObjectPoolType.DamageIndicator);
		}
	}
}