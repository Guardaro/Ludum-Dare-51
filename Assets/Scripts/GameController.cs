using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	MusicController musicController;
	StaffSpinner staffSpinner;
	StaffPulse staffPulse;
	CardMenu cardMenu;

	[SerializeField] BurstSpawner[] guns;

	float nextRefreshTime = Mathf.Infinity;

	float interval = 10f;

	float nextFireTime = 0f;
	public float tempo = 8f;

	public float enemyHP = 12f;
	float enemyHPMultiplier = 1.06f;

	float enemySpawnRate = 4f;
	float enemySpawnRateMultiplier = 0.94f;

	private void Awake()
	{
		Cursor.visible = false;

		musicController = FindObjectOfType<MusicController>();
		staffSpinner = FindObjectOfType<StaffSpinner>();
		staffPulse = FindObjectOfType<StaffPulse>();
		cardMenu = FindObjectOfType<CardMenu>();

		Initialize();
	}

	private void Update()
	{
		if(Time.time > nextRefreshTime)
		{
			nextRefreshTime += interval;
			NextInterval();
		}
		if(Time.time >= nextFireTime)
		{
			Fire();
			nextFireTime += interval / tempo;
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
		cardMenu.Select();
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
}
