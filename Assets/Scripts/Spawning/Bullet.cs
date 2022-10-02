using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] ProjectileDamage damage;
	[SerializeField] ForwardMovement movement;

	public void SetDamage(float damageAmount)
	{
		damage.damageAmount = damageAmount;
	}

}
