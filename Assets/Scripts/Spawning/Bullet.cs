using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] ProjectileDamage damage;
	[SerializeField] ForwardMovement movement;
	[SerializeField] SineRotation rotation;

	public void SetDamage(float damageAmount)
	{
		damage.damageAmount = damageAmount;
	}

	public void SetSineRotationAmplitude(float newAmplitude)
	{
		rotation.amplitude = newAmplitude;
	}

	public void SetStun(float stunAmount)
	{
		damage.stunAmount = stunAmount;
	}
}
