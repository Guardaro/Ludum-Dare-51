using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMenu : MonoBehaviour
{
	[SerializeField] GameObject[] masks;
	[SerializeField] GameObject selectEffect;

	int currentMenuPosition = 0;
	
	int numberOfMenuItems;

	private void Awake()
	{
		numberOfMenuItems = masks.Length;
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
	}
}
