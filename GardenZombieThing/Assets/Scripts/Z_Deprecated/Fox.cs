﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour {

	Animator animator;
	private GameObject collisionObject;
	private bool defenderCollision;
	private bool isGravestone;
	private bool isProjectile;

	// Use this for initialization
	void Start () {
		defenderCollision = false;
		isGravestone = false;
		isProjectile = false;
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D collider2D)
	{
		collisionObject = collider2D.gameObject;
		print ("collision object = " + collisionObject);

		if (collisionObject.GetComponent<Defender>())
		{
			defenderCollision = true;
			print ("Defender collision: " + defenderCollision + collisionObject);
			CheckDefenderType(collisionObject);
		}
	}

	void CheckDefenderType(GameObject collisionObject)
	{
		if (collisionObject.GetComponent<Gravestone>())
		{
			isGravestone = true;
		}
		//
	if (collisionObject.GetComponent<Projectile>())
		{
			isProjectile = true;
		}
		SetReactionToDefender();
	}

	void SetReactionToDefender()
	{
		if (isGravestone)
		{	
			
			Jump();
		}

		else if (isProjectile)
		{
			print ("Ignoring projectiles");
		}

		else
		{
			Attack();
			print (this + " attacking " + collisionObject);
		}
	}
	void Attack()
	{
		animator.SetBool("isAttacking", defenderCollision);
		print (this + "isAttacking: " + defenderCollision);
	}

	void Jump()
	{
		animator.SetBool ("isJumping", isGravestone);
		print ("Jump");
	}
	public void ResetDefenderBool()
	{
		defenderCollision = false;
		isGravestone = false;
		isProjectile = false;
		animator.SetBool ("isJumping", false);
		animator.SetBool ("isTriggered", false); 
	}
}
