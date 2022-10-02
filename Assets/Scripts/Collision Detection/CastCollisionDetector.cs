using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastCollisionDetector : CollisionDetector
{
	protected RaycastHit2D[] hits = new RaycastHit2D[8];
	public bool reportCollisionsAfterFirst = false;

	public virtual float AttemptMove(Vector2 moveAttempt)
	{
		Debug.Log(gameObject + " is using CastCollisionDetector. Use a detector that inherits from CastCollisionDetector instead.");
		return Mathf.Infinity;
	}

}
