using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovement : MonoBehaviour
{
	public float moveSpeed = 5f;

	private void Update()
	{
		transform.position += transform.right * moveSpeed * Time.deltaTime;
	}
}
