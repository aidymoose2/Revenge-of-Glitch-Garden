using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

	public delegate void SceneChange(int level);
	public static event SceneChange OnSceneChange;
	public AudioClip[] levelMusicChangeArray;
	private AudioSource audioSource;

	void Start()//Level Manager Script
		{
		audioSource = GetComponent<AudioSource>();
		if (OnSceneChange !=null)
			{
			OnSceneChange(SceneManager.GetActiveScene().buildIndex);
			}
		}

	void Awake()//Music Manager Script
		{
		DontDestroyOnLoad(gameObject);
		MusicManager.OnSceneChange += MusicChange;
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
}
