using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardInherited : AttackerInherited {

	private AttackerInherited attackerInherited;
	Animator animator;
	public float lizardDamageCount;

	// Use this for initialization
	void Start () 
	{
		attackerInherited = GetComponent<AttackerInherited>();
		animator = GetComponent<Animator>();
		damageDealt = lizardDamageCount;
	}

	void OnTriggerEnter2D(Collider2D collider2D)
	{
		GameObject collisionObject = collider2D.gameObject;
		
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
}
