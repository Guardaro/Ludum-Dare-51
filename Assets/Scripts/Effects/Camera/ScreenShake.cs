using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
	public float constantShakeIntensity = 0f;

	private List<Shake> shakes = new List<Shake>();

	Camera mainCamera;
	float baseCameraSize;

	Vector3 homePosition;

	public class Shake
	{
		public float lateralIntensity = 1f;
		public float forwardIntensity = 1f;
		public float rotationalIntensity = 1f;
		public float shakeUntil = 1f;

		public Shake(float newLateralIntensity, float newForwardIntensity, float newRotationalIntensity, float duration)
		{
			lateralIntensity = newLateralIntensity;
			forwardIntensity = newForwardIntensity;
			rotationalIntensity = newRotationalIntensity;
			shakeUntil = Time.time + duration;
		}
	}

	private void Awake()
	{
		mainCamera = Camera.main;
		baseCameraSize = mainCamera.orthographicSize;
		homePosition = mainCamera.transform.localPosition;
	}

	private void FixedUpdate()
	{
		ResetPosition();

		HandleConstantShake();
		for (int i = shakes.Count - 1; i >= 0; i--)
		{
			Shake shake = shakes[i];
			if (shake.shakeUntil <= Time.time)
			{
				shakes.RemoveAt(i);
			}
			else
			{
				ProcessShake(shake);
				DampenIntensity(shake);
			}
		}
	}

	private void ResetPosition()
	{
		mainCamera.transform.localPosition = homePosition;
		mainCamera.orthographicSize = baseCameraSize;
		mainCamera.transform.rotation = Quaternion.identity;
	}

	private void HandleConstantShake()
	{
		Vector3 randomMove = Random.insideUnitCircle * constantShakeIntensity;
		mainCamera.transform.localPosition += randomMove;
	}

	public void SetConstantShakeIntensity(float newIntensity)
	{
		constantShakeIntensity = newIntensity;
	}

	private void ProcessShake(Shake shake)
	{
		Vector3 randomMove = Random.insideUnitCircle * shake.lateralIntensity;
		mainCamera.transform.localPosition += randomMove;

		float randomCameraSizeChange = Random.Range(-shake.forwardIntensity, -shake.forwardIntensity / 2f);
		mainCamera.orthographicSize += randomCameraSizeChange;

		float randomRotation = Random.Range(-shake.rotationalIntensity, shake.rotationalIntensity);
		Vector3 rotateVector = new Vector3(0, 0, randomRotation);
		mainCamera.transform.Rotate(rotateVector);
	}

	private void DampenIntensity(Shake shake)
	{
		float secondsRemaining = shake.shakeUntil - Time.time;

		float dampenPerSecond = shake.lateralIntensity / secondsRemaining;
		shake.lateralIntensity -= dampenPerSecond * Time.fixedDeltaTime;

		dampenPerSecond = shake.forwardIntensity / secondsRemaining;
		shake.forwardIntensity -= dampenPerSecond * Time.fixedDeltaTime;

		dampenPerSecond = shake.rotationalIntensity / secondsRemaining;
		shake.rotationalIntensity -= dampenPerSecond * Time.fixedDeltaTime;
	}

	public void AddLateralShake(float intensity, float duration)
	{
		Shake newShake = new Shake(intensity, 0, 0, duration);
		shakes.Add(newShake);
	}

	public void AddForwardShake(float intensity, float duration)
	{
		Shake newShake = new Shake(0, intensity, 0, duration);
		shakes.Add(newShake);
	}

	public void AddRotationalShake(float intensity, float duration)
	{
		Shake newShake = new Shake(0, 0, intensity, duration);
		shakes.Add(newShake);
	}

	public void StopAllShakes()
	{
		shakes = new List<Shake>();
		constantShakeIntensity = 0f;
	}

	public void DebugLateralShake()
	{
		AddLateralShake(1f, 0.5f);
	}

	public void DebugForwardShake()
	{
		AddForwardShake(4f, 0.5f);
	}

	public void DebugRotationalShake()
	{
		AddRotationalShake(15f, 0.5f);
	}
}
