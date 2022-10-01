using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
	AudioSource audioSource;

    bool[] isPlaying;

	private void Awake()
	{
		isPlaying = new bool[clips.Length];
		audioSource = GetComponent<AudioSource>();
	}

	public void PlayNextClipSet()
	{
		SelectClips();
		PlaySelectedClips();
	}

	private void SelectClips()
	{
		if(NumberOfClipsPlaying() <= 1)
		{
			int clipToPlay = Random.Range(0, clips.Length);
			isPlaying[clipToPlay] = true;
		}
		else
		{
			int clipToToggle = Random.Range(0, clips.Length);
			isPlaying[clipToToggle] = !isPlaying[clipToToggle];
		}
	}

	private void PlaySelectedClips()
	{
		for(int i = 0; i < clips.Length; i++)
		{
			if (isPlaying[i])
			{
				audioSource.PlayOneShot(clips[i]);
				audioSource.clip = clips[i];
			}
		}
	}

	private int NumberOfClipsPlaying()
	{
		int numberPlaying = 0;
		for(int i = 0; i < isPlaying.Length; i++)
		{
			if (isPlaying[i]) numberPlaying++;
		}
		return numberPlaying;
	}
}
