using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float health;

	public void DamageTaken (float damage)
	{
		health -= damage;
		if (health <= 0) 
		{
			print ("Game object destroyed");
			Destroy ();
		} 

	}
	public void Destroy()
	{
		Destroy (gameObject);
	}
}
