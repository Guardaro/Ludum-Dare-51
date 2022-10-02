using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachTarget : MonoBehaviour
{
	public float moveSpeed = 2f;

	public Transform target = null;

	private void Update()
	{
		Vector3 difference = target.position - transform.position;
		transform.position += difference.normalized * moveSpeed * Time.deltaTime;
	}
}
