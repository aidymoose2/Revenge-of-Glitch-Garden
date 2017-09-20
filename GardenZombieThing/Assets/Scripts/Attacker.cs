using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

	[Range (0f,1.5f)] public float currentSpeed; 


	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D collisionObject)
	{
		if (collisionObject.gameObject.GetComponent<Defender>())
		{
			SetSpeed(0f);
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
