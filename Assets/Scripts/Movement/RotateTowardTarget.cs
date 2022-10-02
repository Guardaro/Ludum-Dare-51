using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardTarget : MonoBehaviour
{
	public float degreesPerSecond;
	public Transform target;

	private void Update()
	{
		float angleToTarget = GetAngleToTarget();
		float rotationThisFrame = degreesPerSecond * Time.deltaTime;

		if (angleToTarget < 0)
		{
			rotationThisFrame *= -1f;
		}

		if (Mathf.Abs(rotationThisFrame) >= Mathf.Abs(angleToTarget))
		{
			rotationThisFrame = angleToTarget;
		}

		Vector3 rotationVector = new Vector3(0, 0, rotationThisFrame);
		transform.Rotate(rotationVector);
	}

	private float GetAngleToTarget()
	{
		Vector3 vectorToTarget = target.position - transform.position;
		vectorToTarget.z = 0f;

		float degreesBetween = Vector3.SignedAngle(transform.right, vectorToTarget, Vector3.forward);

		return degreesBetween;
	}
}
