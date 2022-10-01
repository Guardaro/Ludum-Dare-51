using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFade : MonoBehaviour
{
	[SerializeField] TextMeshPro itemToColor;

	Color32 priorColor;
	Color32 currentColor;
	Color32 targetColor;

	float fadeRate = 0f;
	float currentFade = 1f;

	private void Awake()
	{
		priorColor = itemToColor.color;
	}

	private void Update()
	{
		if(currentFade < 1)
		{
			Fade();
		}
	}

	private void Fade()
	{
		currentFade += fadeRate * Time.deltaTime;
		currentColor = Color32.Lerp(priorColor, targetColor, currentFade);
		itemToColor.color = currentColor;
		if(currentFade >= 1)
		{
			priorColor = targetColor;
		}
	}

	public void BeginFade(Color32 newColor, float secondsToFade)
	{
		currentFade = 0f;
		targetColor = newColor;
		priorColor = itemToColor.color;
		fadeRate = 1f / secondsToFade;
	}

	public void DebugFadeIn()
	{
		Color32 fadeColor = new Color32(255, 255, 255, 255);
		BeginFade(fadeColor, 3f);
	}

	public void DebugFadeOut()
	{
		Color32 fadeColor = new Color32(0, 0, 0, 0);
		BeginFade(fadeColor, 2f);
	}
}
