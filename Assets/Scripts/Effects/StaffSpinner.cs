using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffSpinner : MonoBehaviour
{
	float spinSpeed = 18f;
	float spinMultiplier = 1;
	int maxSpinMultiplier = 4;

	SpinState spinState = SpinState.NotSpinning;

	public enum SpinState
	{
		NotSpinning = 0,
		SpinningRight = 1,
		SpinningLeft = 2,
		
		COUNT = 3
	}

	private void Update()
	{
		Vector3 rotateVector = Vector3.zero;
		if(spinState == SpinState.SpinningLeft)
		{
			rotateVector.z = spinSpeed * Time.deltaTime * spinMultiplier;
		}
		if(spinState == SpinState.SpinningRight)
		{
			rotateVector.z = -spinSpeed * Time.deltaTime * spinMultiplier;
		}
		transform.Rotate(rotateVector);
	}

	public void RandomSpin()
	{
		SpinState newState = (SpinState)Random.Range(0, (int)SpinState.COUNT);
		spinState = newState;
		spinMultiplier = (float)Random.Range(-1, maxSpinMultiplier);
	}
}
