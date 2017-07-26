using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;

	void Start ()
	{
		//checks whether currently loaded screen is splash screen. If it is, autoloads next level
		if (SceneManager.GetActiveScene().buildIndex == 0)
			{
				Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
			}
	}


	public void LoadLevel(string name)
	{
		Debug.Log ("Level load requested for: " + name);
		SceneManager.LoadScene (name);
	}

	public void QuitRequest()
	{
		Debug.Log ("Quit game requested");
		Application.Quit ();
	}

	public void LoadNextLevel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}
}
