using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class SoundEffectPlayer : MonoBehaviour
{
	AudioSource audioSource;
	[SerializeField] bool playingSounds = true;
	[SerializeField] AudioClip[] audioClips;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	public void PlaySoundEffect(SoundEffect effect)
	{
		if (playingSounds)
		{
			AudioClip clip = audioClips[(int)effect];
			audioSource.PlayOneShot(clip);
		}
	}

	public void DebugPlayRandomSound()
	{
		SoundEffect soundEffect = (SoundEffect)(Random.Range(0, (int)SoundEffect.COUNT));
		PlaySoundEffect(soundEffect);
	}

}
