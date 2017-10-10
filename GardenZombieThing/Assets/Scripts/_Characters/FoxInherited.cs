using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxInherited : AttackerInherited{

	Animator animator;
	AttackerInherited attackerInherited;
	private GameObject collisionObject;


	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator>();
		attackerInherited = GetComponent<AttackerInherited> ();
	}

	void OnTriggerEnter2D(Collider2D collider2D)
	{
		collisionObject = collider2D.gameObject;
		CheckDefenderType (collisionObject);

	}

	protected override void CheckDefenderType (GameObject collisionObject)
	{
		base.CheckDefenderType (collisionObject);
		if (attackerInherited.CheckIfGravestone (collisionObject)) 
		{
			Jump ();
		}
		else if (attackerInherited.CheckIfProjectile (collisionObject)) 
		{
			print ("Ignoring projectiles");
		}
		else
		{
			Attack(collisionObject);
			print (this + " attacking " + collisionObject);
		}
	}
	protected override void Attack(GameObject collisionObject)
	{
		base.Attack (collisionObject);
		attackerInherited.SetSpeed(0f);
		animator.SetBool("isAttacking", true);
		print (this + "isAttacking");
	}

	void Jump()
	{
		animator.SetBool ("isJumping", true);
		print ("Jump");
	}
	protected override void ResetAttackerBool()
	{
		base.ResetAttackerBool ();
		animator.SetBool ("isJumping", false);
		animator.SetBool ("isAttacking", false); 
		animator.SetBool ("isWalking", true);
	}
}
