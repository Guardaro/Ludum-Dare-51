using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TimedDisable))]

public class DamageIndicator : MonoBehaviour
{
	[SerializeField] TextMeshPro damageTextMesh;
	public float secondsBeforeDisable = 2f;

	TimedDisable disableTimer;

	float damageTotal = 0f;

	private void Awake()
	{
		disableTimer = GetComponent<TimedDisable>();
		Reset();
	}

	private void OnEnable()
	{
		Reset();
	}

	private void Reset()
	{
		damageTotal = 0f;
		damageTextMesh.text = "";
		disableTimer.SetDisableTime(secondsBeforeDisable);
	}

	public void AddDamage(float damageAmount)
	{
		damageTotal += damageAmount;
		int hitPointsLost = (int)Mathf.Round(damageTotal);
		damageTextMesh.text = hitPointsLost.ToString();
		disableTimer.SetDisableTime(secondsBeforeDisable);
	}
}
