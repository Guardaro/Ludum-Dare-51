using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NoteHealthDisplay : MonoBehaviour
{
	[SerializeField] TextMeshPro textMesh;
	public string[] displayStrings;
	float hitPointsPerBlock = 10f;

	public void RefreshDisplay(float currentHP)
	{
		textMesh.text = displayStrings[IndexFromHealth(currentHP)];
	}

	private int IndexFromHealth(float currentHP)
	{
		int rawIndex = (int)(currentHP / hitPointsPerBlock);
		int clampedIndex = Mathf.Clamp(rawIndex, 0, displayStrings.Length - 1);
		return clampedIndex;
	}
}
