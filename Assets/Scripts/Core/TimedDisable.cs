using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDisable : MonoBehaviour
{
	public float lifeSpan = 10f;
	public bool resetOnEnable = true;
	public DisableType disableType = DisableType.Disable;
	
	float disableTime;

	public enum DisableType
	{
		Disable = 0,
		Destroy = 1
	}

	private void Awake()
	{
		Reset();
	}

	private void OnEnable()
	{
		if (resetOnEnable) 
		{
			Reset(); 
		}
	}

	private void Reset()
	{
		disableTime = Time.time + lifeSpan;
	}

	private void FixedUpdate()
	{
		if(Time.time >= disableTime)
		{
			switch (disableType)
			{
				case DisableType.Disable:
					gameObject.SetActive(false);
					break;
				case DisableType.Destroy:
					Destroy(gameObject);
					break;
			}
		}
	}

	public void SetDisableTime(float newLifespan)
	{
		lifeSpan = newLifespan;
		Reset();
	}
}
