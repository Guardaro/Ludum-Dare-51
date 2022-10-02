using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHealthOnEnable : MonoBehaviour
{
    Health health;
	GameController gameController;

	private void Awake()
	{
		health = GetComponent<Health>();
		gameController = FindObjectOfType<GameController>();
	}

	private void OnEnable()
	{
		float newHealth = gameController.enemyHP;
		health.SetMaxHealth(newHealth);
		health.RefillHealth();
	}
}
