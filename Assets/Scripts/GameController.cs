using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	MusicController musicController;
	StaffSpinner staffSpinner;
	StaffPulse staffPulse;

	float nextRefreshTime = 0f;

	float interval = 10f;

	private void Awake()
	{
		musicController = FindObjectOfType<MusicController>();
		staffSpinner = FindObjectOfType<StaffSpinner>();
		staffPulse = FindObjectOfType<StaffPulse>();
	}

	private void Update()
	{
		if(Time.time > nextRefreshTime)
		{
			NextInterval();
			nextRefreshTime += interval;
		}
	}

	private void NextInterval()
	{
		musicController.PlayNextClipSet();
		staffSpinner.RandomSpin();
		staffPulse.RandomSpeed();
	}
}
