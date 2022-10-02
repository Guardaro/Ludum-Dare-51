using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
	[SerializeField] float checkRadius = 0.45f;
	[SerializeField] Layer[] checkLayers = new Layer[1] { Layer.Enemy };
	[SerializeField] GameObject endEffects;

	ContactFilter2D filter;

	Collider2D[] hits = new Collider2D[1];

	private void Awake()
	{
		filter = LayerUtilities.CreateFilter(checkLayers);		
	}

	private void Update()
	{
		if (Physics2D.OverlapCircle(transform.position, checkRadius, filter, hits) > 0)
		{
			Die();
		}
	}

	private void Die()
	{
		Timer timer = FindObjectOfType<Timer>();
		timer.Stop();

		ObjectPoolPicker picker = FindObjectOfType<ObjectPoolPicker>();
		picker.gameObject.SetActive(false);

		GameController gameController = FindObjectOfType<GameController>();
		gameController.EndGame();

		endEffects.SetActive(true);
	}
}
