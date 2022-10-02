using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage: MonoBehaviour
{
	[SerializeField] Layer[] hitLayers;
	ForwardMovement forwardMovement;
	SineRotation sineRotation;
	public float damageAmount = 10;

	bool ableToDealDamage = true;
	public bool disableOnHit = true;

	protected RaycastHit2D[] hits = new RaycastHit2D[16];
	public bool reportCollisionsAfterFirst = false;

	public float stunAmount = 0f;

	LayerMask mask;

	private void Awake()
	{
		forwardMovement = GetComponent<ForwardMovement>();
		sineRotation = GetComponent<SineRotation>();
		mask = LayerUtilities.CreateMask(hitLayers);
	}

	private void Update()
	{
		CheckForHit();
	}

	private void OnEnable()
	{
		ableToDealDamage = true;
	}

	private void CheckForHit()
	{
		if (ableToDealDamage)
		{
			float moveSpeed = forwardMovement.moveSpeed;
			float moveThisFrame = moveSpeed * Time.deltaTime;
			int numberOfHits = Physics2D.RaycastNonAlloc(transform.position, transform.right, hits, moveThisFrame, mask);
			if (numberOfHits > 0)
			{
				if (reportCollisionsAfterFirst)
				{
					for (int i = 0; i < numberOfHits; i++)
					{
						GameObject objectHit = hits[i].collider.gameObject;
						DealDamage(objectHit);
					}
				}
				else
				{
					GameObject objectHit = hits[0].collider.gameObject;
					DealDamage(objectHit);
				}
				if (disableOnHit)
				{
					ableToDealDamage = false;
					forwardMovement.enabled = false;
					sineRotation.enabled = false;
				}
			}
		}
	}

	public void DealDamage(GameObject target)
	{
		Health targetHealth = target.GetComponent<Health>();
		targetHealth.TakeDamage(damageAmount);
		if(stunAmount > 0)
		{
			ApproachTarget targetMovement = target.GetComponent<ApproachTarget>();
			targetMovement.Stun(stunAmount);
		}
	}
}
