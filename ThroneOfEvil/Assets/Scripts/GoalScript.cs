using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour {
	public float damageToGate = 20;
	HealthController health;
	GameObject[] gameObjects;
	//GameObject[] villagers;
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
	void FixedUpdate(){

	}
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy") || other.CompareTag("TarredEnemy") || other.CompareTag("FrozenEnemy") || other.CompareTag("BurningEnemy"))
		{
			health.DealDamage (damageToGate);
			//other.GetComponent<EnemyController> ().isMovementPaused = true;
			other.GetComponent<EnemyController> ().isPaused = true;
			if (health.currentHealth <= 0) {
				other.tag = "Enemy";
				other.GetComponent<EnemyController> ().isPaused = false;
				collectCurrentEnemies ();
				Destroy (gameObject);
			}
		}
	}
	void collectCurrentEnemies(){
		gameObjects =  GameObject.FindGameObjectsWithTag ("Enemy");
		//villagers =  GameObject.FindGameObjectsWithTag ("Enemy"); //this is for next level copy and paste
		for (var i = 0; i < gameObjects.Length; i++) {
			gameObjects [i].GetComponent<EnemyController> ().isPaused = false;
		}
	}
}
