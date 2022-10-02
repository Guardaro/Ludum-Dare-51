using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade")]

public class Upgrade : ScriptableObject
{
	[SerializeField] private UpgradeType upgradeType;
	[SerializeField] private string title;
	[SerializeField] private string symbol;
	[SerializeField] private string description;

	public UpgradeType GetUpgradeType() { return upgradeType; }
	public string GetTitle() { return title; }
	public string GetSymbol() { return symbol; }
	public string GetDescription() { return description; }
}
