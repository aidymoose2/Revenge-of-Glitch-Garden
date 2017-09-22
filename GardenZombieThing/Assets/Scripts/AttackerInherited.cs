using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerInherited : MonoBehaviour {

	[Range (0f,1.5f)] public float currentSpeed; 
	protected float damageDealt;

	private GameObject collisionObject;
	private bool defenderCollision;


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

	//Check if object collider with has defender component
	public bool CheckIfDefender(GameObject collisionObject)
	{
		if (collisionObject.GetComponent<Defender> ()) 
		{
			print ("Defender collision: " + collisionObject);
			CheckDefenderType (collisionObject);
			return true;
		} 
		else 
		{
			return false;
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


	public void StrikeCurrentTarget(float damage)
	{
		print(this + " caused " + damage + " damage");
	}
	protected virtual void ResetAttackerBool()
	{
		
	}

	protected virtual void Attack(GameObject collisionObject)
	{

	}

}
