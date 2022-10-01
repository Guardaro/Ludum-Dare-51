using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchTargetPosition : MonoBehaviour
{
	[SerializeField] Transform followTarget;
	[SerializeField] bool fixedX = false;
	[SerializeField] bool fixedY = false;
	[SerializeField] bool fixedZ = true;

	private void FixedUpdate()
	{
		Vector3 currentPosition = transform.position;
		Vector3 newPosition = followTarget.position;
		if (fixedX) { newPosition.x = currentPosition.x; }
		if (fixedY) { newPosition.y = currentPosition.y; }
		if (fixedZ) { newPosition.z = currentPosition.z; }
		transform.position = newPosition;
	}
}
