using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";

	public static void SetMasterVolume (float volume)
	{
		// Checks if volume float inputted is within accepted parameters of 0 and 1
		if (volume > 0f && volume < 1f)
		{
			//Assigns float value 'volume' to MASTER_VOLUME_KEY
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		}
		else
		{
			Debug.LogError("Master volume out of range");
		}
	}

	public static float GetMasterVolume ()
	{
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}

	//LEVEL_KEY is being used in place of a bool, with its value being set to 1 when the condition is met. 
	public static void UnlockLevel (int level)
	{
		// If the level being inputted is one that can be found in the build...
		if (level <= SceneManager.sceneCountInBuildSettings - 1)
		{
			// LEVEL_KEY is set to '1', signifying that the level inputted was a valid one
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); //Use 1 for true
		}
		else
		{
			Debug.LogError("Trying to unlock level not in build order");
		}
	}

	public static bool IsLevelUnlocked(int level)
	{
		// levelValue stores the current status of the LEVEL_KEY in player prefs
		int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
		// isLevelUnlocked checks levelValue and converts it into a bool
		bool isLevelUnlocked = (levelValue == 1);

		if(level <= SceneManager.sceneCountInBuildSettings - 1)
		{
			return isLevelUnlocked;
		}
		else
		{
			return false;
			Debug.LogError("Trying to query level not in build order");
		}
	}

	public static void SetDifficulty (float difficulty)
	{
		if (difficulty >= 1f && difficulty <= 3f)
		{
			PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
			Debug.Log("Difficulty set to " + DIFFICULTY_KEY + difficulty.ToString()); 
		}
		else
		{
			Debug.LogError("Difficulty outside of accepted range");
		}
	}

	public static float GetDifficulty ()
	{
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}
}
