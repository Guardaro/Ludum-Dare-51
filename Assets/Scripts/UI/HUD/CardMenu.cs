using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMenu : MonoBehaviour
{
	[SerializeField] Card[] cards;
	[SerializeField] GameObject[] masks;
	[SerializeField] GameObject selectEffect;

	[SerializeField] Upgrade[] upgrades;

	Upgrade[] cardUpgrades;

	int currentMenuPosition = 0;
	
	int numberOfMenuItems;

	BulletPool bulletPool;
	[SerializeField] BurstSpawner forwardGun;
	[SerializeField] BurstSpawner leftGun;
	[SerializeField] BurstSpawner rightGun;
	[SerializeField] BurstSpawner rearGun;
	[SerializeField] BurstSpawner glissandoGun;

	GameController gameController;

	IconDisplay iconDisplay;

	private void Awake()
	{
		numberOfMenuItems = masks.Length;
		cardUpgrades = new Upgrade[cards.Length];
		AssignRandomUpgrades();

		bulletPool = FindObjectOfType<BulletPool>();
		gameController = FindObjectOfType<GameController>();
		iconDisplay = FindObjectOfType<IconDisplay>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
		{
			NextItem();
		}
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
		{
			PriorItem();
		}
	}

	private void NextItem()
	{
		currentMenuPosition++;
		if (currentMenuPosition >= numberOfMenuItems) currentMenuPosition = 0;
		RefreshMasks();
	}

	private void PriorItem()
	{
		currentMenuPosition--;
		if (currentMenuPosition < 0) currentMenuPosition = numberOfMenuItems - 1;
		RefreshMasks();
	}

	private void RefreshMasks()
	{
		for (int i = 0; i < masks.Length; i++)
		{
			masks[i].SetActive(true);
		}
		masks[currentMenuPosition].SetActive(false);
	}

	public void Select()
	{
		selectEffect.transform.position = masks[currentMenuPosition].transform.position;
		selectEffect.SetActive(true);
		ApplyUpgrade();
		RefreshIconDisplay();
		AssignRandomUpgrades();
	}

	private void RefreshIconDisplay()
	{
		iconDisplay.SetIcon(cardUpgrades[currentMenuPosition]);
	}

	private void AssignRandomUpgrades()
	{
		for(int i = 0; i < cards.Length; i++)
		{
			int randomIndex = Random.Range(0, upgrades.Length);
			cardUpgrades[i] = upgrades[randomIndex];
			cards[i].RefreshDisplay(upgrades[randomIndex]);
		}
	}

	private void ApplyUpgrade()
	{
		UpgradeType upgradeType = cardUpgrades[currentMenuPosition].GetUpgradeType();
		switch (upgradeType)
		{
			case UpgradeType.Crescendo:
				bulletPool.IncreaseDamage();
				break;
			case UpgradeType.Acciaccatura:
				forwardGun.IncreaseSpawnAmount();
				break;
			case UpgradeType.OttavaAlta:
				leftGun.IncreaseSpawnAmount();
				break;
			case UpgradeType.OttavaBassa:
				rightGun.IncreaseSpawnAmount();
				break;
			case UpgradeType.Glissando:
				glissandoGun.IncreaseSpawnAmount();
				break;
			case UpgradeType.AllaBreve:
				gameController.IncreaseTempo();
				break;
			case UpgradeType.Vibrato:
				bulletPool.IncreaseSineRotation();
				break;
			case UpgradeType.Arpeggio:
				//Rotating Bullets
				break;
			case UpgradeType.Fermata:
				bulletPool.IncreaseStun();
				break;
			case UpgradeType.Segno:
				rearGun.IncreaseSpawnAmount();
				break;
			case UpgradeType.Tremolo:
				gameController.DoubleTempo();
				bulletPool.HalveDamage();
				break;
		}

	}
}
