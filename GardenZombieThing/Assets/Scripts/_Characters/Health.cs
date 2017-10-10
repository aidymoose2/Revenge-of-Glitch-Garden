using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DamageTaken (float damageDealt)
	{
		float newHealth = health - damageDealt;
		print ("New health: " + newHealth);
		health = newHealth;
		print ("Health set to " + health);
		CheckIfDestroyed (health);
	}

	public bool CheckIfDestroyed (float health)
	{
		if (health <= 0) 
		{
			print ("Game object destroyed");
			Destroy ();
			return true;
		} 
		else 
		{
			return false;
		}
	}
	public void Destroy()
	{
		Destroy (gameObject);
	}
}
