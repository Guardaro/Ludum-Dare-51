using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugRandomUpgrade : MonoBehaviour
{
	[SerializeField] Upgrade[] upgrades;
	[SerializeField] Card card;

	private void Awake()
	{
		int randomIndex = Random.Range(0, upgrades.Length);
		Upgrade randomUpgrade = upgrades[randomIndex];
		card.RefreshDisplay(randomUpgrade);
	}
}