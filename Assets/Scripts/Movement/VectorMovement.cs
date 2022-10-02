using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorMovement : MonoBehaviour
{
	Vector3 normalizedDirection = Vector3.right;
	bool needToRefreshDirection = true;

	float moveSpeed;

	public bool moving = false;

	private void Awake()
	{
		ForwardMovement forwardMovement = GetComponent<ForwardMovement>();
		moveSpeed = forwardMovement.moveSpeed;
	}

	private void OnEnable()
	{
		needToRefreshDirection = true;
	}

	private void Update()
	{
		if (moving)
		{
			transform.position += moveSpeed * Time.deltaTime * normalizedDirection;
		}
	}

	private void LateUpdate()
	{
		if (needToRefreshDirection)
		{
			normalizedDirection = transform.right.normalized;
			needToRefreshDirection = false;
		}
	}
}
