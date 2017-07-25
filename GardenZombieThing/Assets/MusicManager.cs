using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;
	private AudioSource audioSource;
	private int level;

	// Use this for initialization
	void Awake () {
	//Makes sure object is generated
		DontDestroyOnLoad (gameObject);
		Debug.Log("Don't destroy on load: " +name);
	}
	void Start(){
	//Generates audioSource private variable by searching for Ausio Source component alraedy present on the game object
		audioSource = GetComponent<AudioSource>();
		Debug.Log(levelMusicChangeArray);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//Detects which level is being loaded
	private void OnEnable (){
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		//Checks newly loaded level (active scene) against order of levels in build index, returning integer)
		level = SceneManager.GetActiveScene().buildIndex;
		Debug.Log ("Build index level loaded: " + level);
		SceneManager.sceneLoaded += OnSceneLoaded; //subscribe
		Debug.Log ("Playing clip: " + levelMusicChangeArray[level]);
		}
	}

	//private void onDisable (){
		//SceneManager.sceneLoaded -= OnSceneLoaded; //unsubscribe
	//}

	private delegate OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
	{
		if(thisLevelMusic) {//if there is an audio clip attached to the [level] number in the array
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
			Debug.Log("Playing level " + level + " audio");
	}
}
