using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField] float health;
	[SerializeField] float maxHealth;
	[SerializeField] NoteHealthDisplay healthDisplay;

	[SerializeField] DamageBehavior damageBehavior;

	ObjectPool explosionPool;

	private void Awake()
	{
		RefillHealth();
		ObjectPoolPicker picker = FindObjectOfType<ObjectPoolPicker>();
		explosionPool = picker.FindPool(ObjectPoolType.Explosion);
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
		if (healthDisplay)
		{
			healthDisplay.RefreshDisplay(health);
		}
		if(health <= 0)
		{
			Die();
		}
	}

	public float GetHealthFraction()
	{
		return health / maxHealth;
	}

	public void RefillHealth()
	{
		health = maxHealth;
		if (healthDisplay)
		{
			healthDisplay.RefreshDisplay(health);
		}
	}

	public void SetMaxHealth(float newMax)
	{
		maxHealth = newMax;
	}
}
