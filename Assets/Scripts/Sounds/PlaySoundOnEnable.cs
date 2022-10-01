using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnEnable : MonoBehaviour
{
    [SerializeField] SoundEffect[] soundEffects;
    [SerializeField] bool playOnSecondFrame = true;

	bool hasPlayed = false;

	private void OnEnable()
	{
		if (!playOnSecondFrame)
		{
			PlaySound();
		}
	}

	private void Update()
	{
		if(playOnSecondFrame && !hasPlayed)
		{
			PlaySound();
		}
	}

	private void OnDisable()
	{
		hasPlayed = false;
	}

	private void PlaySound()
	{
		if(soundEffects.Length > 0)
		{
			SoundEffectPlayer soundEffectPlayer = FindObjectOfType<SoundEffectPlayer>();
			soundEffectPlayer.PlaySoundEffect(SelectSoundEffect());
		}
		hasPlayed = true;
	}

	private SoundEffect SelectSoundEffect()
	{
		int randomIndex = Random.Range(0, soundEffects.Length);
		return soundEffects[randomIndex];
	}
}
