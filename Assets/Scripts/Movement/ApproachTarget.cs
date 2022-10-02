using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachTarget : MonoBehaviour
{
	public float moveSpeed = 2f;

	public Transform target = null;

	bool stunned = false;
	float stunUntil = -Mathf.Infinity;

	private void Update()
	{
		if (stunned)
		{
			if (Time.time > stunUntil) stunned = false;
		}
		else
		{
			Vector3 difference = target.position - transform.position;
			transform.position += difference.normalized * moveSpeed * Time.deltaTime;
		}
	}

	public void Stun(float stunAmount)
	{
		if (!stunned)
		{
			stunned = true;
			stunUntil = Time.time;
		}
		stunUntil += stunAmount;
	}

	private void OnEnable()
	{
		stunned = false;		
	}
}
