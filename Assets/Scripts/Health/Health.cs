using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField] float health;
	[SerializeField] float maxHealth;

	[SerializeField] DamageBehavior damageBehavior;

	ObjectPool explosionPool;

	private void Awake()
	{
		RefillHealth();
//		explosionPool = picker.FindPool(ObjectPoolType.Explosion1);
	}

	private void OnEnable()
	{
		RefillHealth();
	}

	private void Die()
	{
		gameObject.SetActive(false);
		GameObject explosion = explosionPool.GetPooledObject();
		explosion.transform.position = transform.position;
	}

	public void TakeDamage(float damageAmount)
	{
		health -= damageAmount;
		damageBehavior.TakeDamage(damageAmount);
		if(health <= 0)
		{
			Die();
		}
	}

	public float GetHealthFraction()
	{
		return health / maxHealth;
	}

	private void RefillHealth()
	{
		health = maxHealth;
	}
}
