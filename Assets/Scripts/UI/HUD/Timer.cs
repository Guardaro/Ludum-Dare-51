using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
	[SerializeField] TextMeshPro textMesh;
	public int currentTime = 0;
	float secondsSinceStart = 0f;

	bool timerIsRunning = true;

	private void Start()
	{
		secondsSinceStart = 0;
	}

	void Update()
	{
		if (timerIsRunning)
		{
			secondsSinceStart += Time.deltaTime;
			currentTime = (int)secondsSinceStart;
			textMesh.text = TimeToString();
		}
	}

	private string TimeToString()
	{
		int minutes = currentTime / 60;
		int seconds = currentTime % 60;

		string minuteString = "";
		string secondString = "";

		if (minutes < 10)
		{
			minuteString = "0";
		}
		minuteString += minutes.ToString();

		if (seconds < 10)
		{
			secondString = "0";
		}
		secondString += seconds.ToString();

		string returnString = minuteString + ":" + secondString;
		return returnString;
	}

	public void Stop()
	{
		timerIsRunning = false;
	}

}
