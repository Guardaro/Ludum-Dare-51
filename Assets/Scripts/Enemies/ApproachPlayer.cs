using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachPlayer : MonoBehaviour
{
	public float moveSpeed = 2f;

	public Transform target = null;

	private void Awake()
	{
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

	private void Update()
	{
		Vector3 difference = target.position - transform.position;

		transform.position += difference.normalized * moveSpeed * Time.deltaTime;
	}
}
