using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

	
	public AudioClip[] levelMusicChangeArray;
	private AudioSource audioSource;

	void Start()//Level Manager Script
		{
			audioSource = GetComponent<AudioSource>();
			Debug.Log("Audio Source Detected");
		}

	void Awake()//Music Manager Script
		{ 
			DontDestroyOnLoad(gameObject);
			LevelManager.OnSceneChange += MusicChange;
			Debug.Log("Music Change initiated");
		}

	void MusicChange (int level)//OnLevelWasLoaded 
		{
			AudioClip curSceneMusic = levelMusicChangeArray[level];
			if (curSceneMusic) //if there is an audio clip attached to the [level] number in the array
				{
					audioSource.clip = curSceneMusic;
					audioSource.loop = true;
					audioSource.Play();
					Debug.Log("Playing audio for level " + level + " in build");
				}
		}
	void OnDestroy()
	{
		LevelManager.OnSceneChange -=MusicChange;
	}

	public void ChangeVolume (float selectedVolume)
	{
		audioSource.volume = selectedVolume;
		PlayerPrefsManager.SetMasterVolume(selectedVolume);
		Debug.Log ("Volume set to: " + selectedVolume);
	}
}
