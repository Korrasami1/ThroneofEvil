using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour {
	HealthController health;

	void Start(){
		GameObject healthObject = GameObject.FindWithTag("GameController");
		if (healthObject != null)
		{
			health = healthObject.GetComponent<HealthController>();
		}
		if (health == null)
		{
			Debug.Log("Cannot find 'HealthController' script");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			health.DealDamage (25);
			//other.GetComponent<EnemyController>().pa
			if (health.currentHealth <= 0) {
				other.GetComponent<EnemyController>().speed = 5;
			}
		}

	}
}
