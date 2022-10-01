using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
	[SerializeField] TrailRenderer[] trailRenderers;
	[SerializeField] MonoBehaviour[] behaviorsToDisable;
	[SerializeField] GameObject[] objectsToDisable;

	public void Disable()
	{
		for (int i = 0; i < trailRenderers.Length; i++)
		{
			trailRenderers[i].enabled = false;
			trailRenderers[i].Clear();
		}

		for(int i = 0; i < behaviorsToDisable.Length; i++)
		{
			behaviorsToDisable[i].enabled = false;
		}

		for(int i = 0; i < objectsToDisable.Length; i++)
		{
			objectsToDisable[i].SetActive(false);
		}
	}

	public void Enable()
	{
		for (int i = 0; i < trailRenderers.Length; i++)
		{
			trailRenderers[i].enabled = true;
		}

		for (int i = 0; i < behaviorsToDisable.Length; i++)
		{
			behaviorsToDisable[i].enabled = true;
		}

		for (int i = 0; i < objectsToDisable.Length; i++)
		{
			objectsToDisable[i].SetActive(true);
		}
	}
}
