using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFlip : MonoBehaviour
{
	private void OnEnable()
	{
		if(Random.Range(0, 1f) > 0.5f)
		{
			transform.Rotate(new Vector3(0, 0, 180f));
		}
	}
}
