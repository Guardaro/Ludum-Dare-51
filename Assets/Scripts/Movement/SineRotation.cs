using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineRotation : MonoBehaviour
{
	public float amplitude = 45;
	public float period = 0.5f;
	public float phaseShift = 0f;

	float timeSinceEnable = 0f;

	private void OnEnable()
	{
		timeSinceEnable = 0;
	}

	private void FixedUpdate()
	{
		IncrementTimer();
		float angularVelocity = CalculateAngularVelocity();
		Vector3 rotateVector = Vector3.zero;
		rotateVector.z = angularVelocity * Time.deltaTime;
		transform.Rotate(rotateVector);
	}

	private void IncrementTimer()
	{
		timeSinceEnable += Time.fixedDeltaTime;
	}

	private float CalculateAngularVelocity()
	{
		float periodFactor = 2f * Mathf.PI / period;
		float angularVelocity = amplitude * periodFactor * Mathf.Cos(periodFactor * (timeSinceEnable + phaseShift));
		return angularVelocity;
	}
}
