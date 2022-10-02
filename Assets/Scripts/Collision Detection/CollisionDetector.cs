using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  CollisionDetector : MonoBehaviour
{
	[SerializeField] protected Layer[] hitLayers;
	[HideInInspector] protected LayerMask mask;

	public delegate void OnHit(GameObject objectHit);
	public OnHit onHit;

	private void Awake()
	{
		mask = LayerUtilities.CreateMask(hitLayers);
		SetUp();
	}

	protected virtual void SetUp()
	{

	}

}
