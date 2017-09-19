using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

	[Range (0f,1.5f)] public float currentSpeed; 
	Animator animator;
	public bool defenderCollision;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D collisionObject)
	{
		if (collisionObject.gameObject.GetComponent<Defender>())
		{
			SetSpeed(0f);
			defenderCollision = true;
			animator.SetBool("IsAttacking", defenderCollision);
			print ("isAttacking: " + defenderCollision);
		}
	}
	public void SetSpeed(float speed)
	{
		currentSpeed = speed;
	}

	public void StrikeCurrentTarget(float damage)
	{
		print(this + " caused " + damage + " damage");
	}

}
