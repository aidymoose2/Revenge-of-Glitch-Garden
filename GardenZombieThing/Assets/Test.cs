﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print (PlayerPrefsManager.GetMasterVolume());
		PlayerPrefsManager.SetMasterVolume(0.3f);
		print (PlayerPrefsManager.GetMasterVolume());


		print (PlayerPrefsManager.IsLevelUnlocked(3));
		PlayerPrefsManager.UnlockLevel(3);
		print (PlayerPrefsManager.IsLevelUnlocked(3));

		print (PlayerPrefsManager.GetDifficulty());
		PlayerPrefsManager.SetDifficulty(0.8f);
		print(PlayerPrefsManager.GetDifficulty());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
