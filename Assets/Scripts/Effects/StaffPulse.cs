using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffPulse : MonoBehaviour
{
	float minScale = 0.6f;
	float maxScale = 6f;

	float currentScale = 0.6f;

	float currentSpeed = 0f;
	float speed = 0.1875f;

	int maxSpeedMultiplier = 4;

	private void Update()
	{
		currentScale += currentSpeed * Time.deltaTime;
		currentScale = Mathf.Clamp(currentScale, minScale, maxScale);
		transform.localScale = Vector3.one * currentScale;
	}

	public void RandomSpeed()
	{
		currentSpeed = speed * (float)Random.Range(-1, maxSpeedMultiplier);
		if (Random.Range(0, 1f) > 0.5f)
		{
			float difference = maxScale - currentScale;
			float maxSpeed = difference / 10f;
			currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);
		}
		else
		{
			currentSpeed *= -1f;
			float difference = minScale - currentScale;
			float maxSpeed = difference / 10f;
			currentSpeed = Mathf.Clamp(currentSpeed, maxSpeed, 0f);
		}
	}
}
