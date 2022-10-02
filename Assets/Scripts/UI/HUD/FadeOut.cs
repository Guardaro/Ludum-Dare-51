using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeOut : MonoBehaviour
{
	TextMeshProUGUI textMesh;

	[SerializeField] float secondsBeforeFade = 10f;
	[SerializeField] float fadeRate = 0.5f;

	float fadeStartTime;

	float currentOpacity = 1f;

	private void Awake()
	{
		textMesh = GetComponent<TextMeshProUGUI>();

	}

	private void Start()
	{
		fadeStartTime = Time.time + secondsBeforeFade;
	}

	private void Update()
	{
		if(Time.time > fadeStartTime)
		{
			currentOpacity -= fadeRate * Time.deltaTime;
			Color currentColor = textMesh.color;
			currentColor.a = currentOpacity;
			textMesh.color = currentColor;
		}
		if(currentOpacity < 0)
		{
			gameObject.SetActive(false);
		}
	}
}
