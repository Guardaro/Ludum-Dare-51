using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
	[SerializeField] TextMeshPro title;
	[SerializeField] TextMeshPro symbol;
	[SerializeField] TextMeshPro description;

	public void RefreshDisplay(Upgrade upgrade)
	{
		title.text = upgrade.GetTitle();
		symbol.text = upgrade.GetSymbol();
		description.text = upgrade.GetDescription();
	}
}
