using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardInherited : AttackerInherited {

	private AttackerInherited attackerInherited;
	Animator animator;
	GameObject collisionObject;


	// Use this for initialization
	void Start () 
	{
		attackerInherited = GetComponent<AttackerInherited>();
		animator = GetComponent<Animator>();
	}

	void OnTriggerEnter2D(Collider2D collider2D)
	{
		collisionObject = collider2D.gameObject;
		
		if ((attackerInherited.CheckIfDefender(collisionObject)) && (!attackerInherited.CheckIfProjectile (collisionObject))) 
		{
			Attack (collisionObject);
		}
			
	}
	protected override void Attack(GameObject collisionObject)
	{
		base.Attack (collisionObject);
		animator.SetBool("IsAttacking", true);
		print ("isAttacking");

	}

	protected override void ResetAttackerBool()
	{
		base.ResetAttackerBool ();
		animator.SetBool ("IsAttacking", false); 
		animator.SetBool ("IsWalking", true);
	}
}
