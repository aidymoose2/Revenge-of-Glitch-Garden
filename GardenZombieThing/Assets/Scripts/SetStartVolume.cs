using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour {

	private MusicManager musicManager;

	// Use this for initialization
	void Start () 
	{
		//storing master volume as new float, to be fed into music manager's change volume function
		float initialVolume = PlayerPrefsManager.GetMasterVolume();
		musicManager = GameObject.FindObjectOfType<MusicManager>();

		musicManager.ChangeVolume(initialVolume);
	}
}	

