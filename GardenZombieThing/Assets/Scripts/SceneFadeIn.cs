using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFadeIn : MonoBehaviour {
	public float fadeDuration = 2f;
	private float endAlpha = 0f;
	private Image image;

	// Use this for initialization
	void Start () {
		//searches current object and finds image component, assigning it to 'image' variable
		image = GetComponent<Image>();
		Debug.Log("Current Alpha level: " + image.color.a);

	}
	
	// Update is called once per frame
	void Update () {
		//uses built in Unity time detection to see whether time since level was loaded is less than fade duration
		if (Time.timeSinceLevelLoad < fadeDuration)
		{
			FadeIn();
		}
		else
		{
			//if time elapsed since level load is greater than fade duration, game object is destroyed (for panel, this means it no longer blocks UI elements behind it)
			gameObject.SetActive(false);
		}
	}

	void FadeIn()
	{
		//Built-in unity function is attached to 'image'(so already knows image's starting alpha level), takes desired parameters to fade between start and end alpha levels
		image.CrossFadeAlpha(endAlpha,fadeDuration,false);
	}
}
