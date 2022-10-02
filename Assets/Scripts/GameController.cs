using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	MusicController musicController;
	StaffSpinner staffSpinner;
	StaffPulse staffPulse;
	CardMenu cardMenu;
	EnemySpawner enemySpawner;

	[SerializeField] BurstSpawner[] guns;

	float nextRefreshTime = Mathf.Infinity;

	float interval = 10f;

	float nextFireTime = 0f;
	public float tempo = 8f;

	public float enemyHP = 12f;
	float enemyHPMultiplier = 1.055f;

	float enemySpawnTime = 4f;
	float enemySpawnTimeMultiplier = 0.9f;

	bool gameHasEnded = false;

	private void Awake()
	{
		//Cursor.visible = false;

		musicController = FindObjectOfType<MusicController>();
		staffSpinner = FindObjectOfType<StaffSpinner>();
		staffPulse = FindObjectOfType<StaffPulse>();
		cardMenu = FindObjectOfType<CardMenu>();
		enemySpawner = FindObjectOfType<EnemySpawner>();

		Initialize();
	}

	private void Update()
	{
		if (Time.time > nextRefreshTime)
		{
			nextRefreshTime += interval;
			NextInterval();
		}
		if (!gameHasEnded)
		{
			if (Time.time >= nextFireTime)
			{
				Fire();
				nextFireTime += interval / tempo;
			}
		}
	}

	private void Initialize()
	{
		nextRefreshTime = Time.time + interval;
		musicController.PlayNextClipSet();
	}

	private void NextInterval()
	{
		musicController.PlayNextClipSet();
		staffSpinner.RandomSpin();
		staffPulse.RandomSpeed();

		if (!gameHasEnded)
		{
			cardMenu.Select();
			IncreaseDifficulty();
		}
	}

	private void Fire()
	{
		for(int i = 0; i < guns.Length; i++)
		{
			guns[i].Spawn();
		}
	}

	public void IncreaseTempo()
	{
		tempo *= 1.1f;
	}

	public void DoubleTempo()
	{
		tempo *= 2f;
	}

	private void IncreaseDifficulty()
	{
		enemyHP *= enemyHPMultiplier;
		enemySpawnTime *= enemySpawnTimeMultiplier;
		enemySpawner.timeBetweenSpawns = enemySpawnTime;
	}

	public void EndGame()
	{
		gameHasEnded = true;
	}
}
