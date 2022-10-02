using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jitter : MonoBehaviour
{
	public float jitterSpeed = 1f;

	private void Update()
	{
		Vector3 randomDirection = Random.insideUnitCircle;
		transform.position += randomDirection * jitterSpeed * Time.deltaTime;
	}
}
