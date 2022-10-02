using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCollisionDetector : CastCollisionDetector
{
	public override float AttemptMove(Vector2 moveAttempt)
	{
		int numberOfHits = Physics2D.RaycastNonAlloc(transform.position, moveAttempt, hits, moveAttempt.magnitude, mask);
		if(numberOfHits > 0)
		{
			if(onHit != null)
			{
				if (reportCollisionsAfterFirst)
				{
					for (int i = 0; i < numberOfHits; i++)
					{
						GameObject objectHit = hits[i].collider.gameObject;
						onHit(objectHit);
					}
				}
				else
				{
					GameObject objectHit = hits[0].collider.gameObject;
					onHit(objectHit);
				}
			}
			return hits[0].distance;
		}
		else
		{
			return Mathf.Infinity;
		}
	}
}
