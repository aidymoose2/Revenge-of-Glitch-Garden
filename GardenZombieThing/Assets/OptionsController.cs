﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider difficultySlider;
	public LevelManager levelManager;

	private MusicManager musicManager;
	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		Debug.Log(musicManager);

		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty();
		
	}
	
	// Update is called once per frame
	void Update () {
		musicManager.ChangeVolume(volumeSlider.value);
	}

	public void SaveAndExit()
	{
		PlayerPrefsManager.SetMasterVolume (volumeSlider.value);
		Debug.Log("Final volume: " +volumeSlider.value);

		PlayerPrefsManager.SetDifficulty(difficultySlider.value);
		Debug.Log("Difficulty chosen: " + difficultySlider.value);

		levelManager.LoadLevel("01a Start");

	}

	public void SetDefaults ()
	{
		volumeSlider.value = 0.8f;
		difficultySlider.value = 2f;
	}
}