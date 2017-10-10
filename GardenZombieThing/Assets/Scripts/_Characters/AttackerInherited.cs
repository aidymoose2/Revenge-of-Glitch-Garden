using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerInherited : MonoBehaviour {

	[Range (0f,1.5f)] public float currentSpeed; 
	public float damage;

	private GameObject collisionObject;
	private bool defenderCollision;
	private Health health;

	void Start ()
	{
		//animator = GetComponent<Animator>();
	}


	void Update () {
		//default motion to left of screen
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
	}

	//detects collision with another obeject/trigger
	void OnTriggerEnter2D(Collider2D collider2D)
	{
		collisionObject = collider2D.gameObject;
		CheckIfDefender (collisionObject);

	}

	void OnTriggerExit2D(Collider2D collider2D)
	{
		ResetAttackerBool ();
	}

	//Check if object collider with has defender component
	public bool CheckIfDefender(GameObject collisionObject)
	{
		if (!collisionObject.GetComponent<Defender> ()) 
		{
			return false;
		}

		else
		{
			print ("Defender collision: " + collisionObject);
			CheckDefenderType (collisionObject);
			health = collisionObject.GetComponent<Health> ();
			return true;
		} 
	}

	//Check which type of defender has been encountered
	protected virtual void CheckDefenderType(GameObject collisionObject)
	{		
		CheckIfProjectile (collisionObject);
	}

	public bool CheckIfGravestone(GameObject collisionObject)
	{
		if (collisionObject.GetComponent<Gravestone>())
		{
			return true;
		}
		else 
		{
			return false;
		}
	}

	public bool CheckIfProjectile(GameObject collisionObject)
	{
		if (collisionObject.GetComponent<Projectile>())
		{
			return true;
		}
		else 
		{
			return false;
		}
	}

	//script method for setting speed of sideways movement
	public void SetSpeed(float speed)
	{
		currentSpeed = speed;
	}




	protected virtual void Attack(GameObject collisionObject)
	{

	}

	protected virtual void StrikeCurrentTarget()
	{
		Health health = collisionObject.GetComponent<Health> ();
		health.DamageTaken (damage);
	}
		

	protected virtual void ResetAttackerBool()
	{

	}
}
