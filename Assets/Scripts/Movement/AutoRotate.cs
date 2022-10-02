using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
	[SerializeField] float rotateSpeed = 36f;

	private void Update()
	{
		Vector3 rotateVector = Vector3.zero;
		rotateVector.z = rotateSpeed * Time.deltaTime;
		transform.Rotate(rotateVector);
	}
}
