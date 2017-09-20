using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour {

	private Attacker attacker;
	Animator animator;

	bool defenderCollision;

	// Use this for initialization
	void Start () 
	{
		attacker = GetComponent<Attacker>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D collisionObject)
	{
		if (collisionObject.gameObject.GetComponent<Defender>())
		{
			defenderCollision = true;
			animator.SetBool("IsAttacking", defenderCollision);
			print ("isAttacking: " + defenderCollision);
		print (this + " collided with " + collisionObject.gameObject);
		}
	}
}
