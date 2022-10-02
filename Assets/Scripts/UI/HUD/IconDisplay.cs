using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IconDisplay : MonoBehaviour
{
	[SerializeField] GameObject icon;
	[SerializeField] int numberOfRows = 10;
	[SerializeField] int numberOfColumns = 3;
	[SerializeField] float rowSpacing = 1.5f;
	[SerializeField] float columnSpacing = 1.5f;

	int numberOfIcons;

	TextMeshPro[] iconTexts;

	int currentIcon = 0;

	private void Awake()
	{
		numberOfIcons = numberOfColumns * numberOfRows;
		iconTexts = new TextMeshPro[numberOfIcons];
		SpawnIcons();
	}

	private void SpawnIcons()
	{
		int iconNumber = 0;
		for(int row = 0; row < numberOfRows; row++)
		{
			for(int column = 0; column < numberOfColumns; column++)
			{
				GameObject thisIcon = Instantiate(icon);
				thisIcon.transform.position = PlacementPosition(row, column);
				thisIcon.transform.parent = transform;
				iconTexts[iconNumber] = thisIcon.GetComponentInChildren<TextMeshPro>();
				iconNumber++;
			}
		}
	}

	private Vector3 PlacementPosition(int row, int column)
	{
		Vector3 newPosition = transform.position + Vector3.right * column * columnSpacing + Vector3.down * row * rowSpacing;
		return newPosition;
	}

	public void SetIcon(Upgrade upgrade)
	{
		if (currentIcon >= numberOfIcons) return;
		string iconText = upgrade.GetSymbol();
		iconTexts[currentIcon].text = iconText;
		currentIcon++;
	}

}
