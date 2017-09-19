using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour {

	private Attacker attacker;
	private bool beginAttacking;

	// Use this for initialization
	void Start () 
	{
		attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D collisionObject)
	{
		if (collisionObject.gameObject.GetComponent<Defender>())
		{
		//run some functions
		print (this + " collided with " + collisionObject.gameObject);
		}
	}
}
