using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearBehaviour : MonoBehaviour {
	Vector3 mousePosition,targetPosition;
	EnemyHealthController enemyHealth;
	public float fearSpeed = -3f;
	ScoreManager Scoreboard;
	GameObject healthObject;
	public float damage = 0;
	public float timetoDestroy = 1f;
	GameObject[] gameObjects;
	public float distance = 10f;

	void Start(){
		getEnemyHealthController ();
		getScoreManager ();
		//fearactivated = true;
		//To get the current mouse position
		mousePosition = Input.mousePosition;
		//Convert the mousePosition according to World position
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x,mousePosition.y,distance));
	}
	void FixedUpdate(){
		//To get the current mouse position
		mousePosition = Input.mousePosition;
	}

	void getEnemyHealthController(){
		healthObject = GameObject.FindWithTag("Enemy");
		if (healthObject != null)
		{
			enemyHealth = healthObject.GetComponent<EnemyHealthController>();
		}
		if (enemyHealth == null)
		{
			Debug.Log("Cannot find 'EnemyHealthController' script from fear Script");
		}
	}

	private void getScoreManager(){
		GameObject points = GameObject.FindWithTag("Scoreboard");
		if (points != null)
		{
			Scoreboard = points.GetComponent<ScoreManager>();
		}
		if (Scoreboard == null)
		{
			Debug.Log("Cannot find 'ScoreboardManager' script");
		}
	}

	void OnTriggerStay(Collider other) //was ontriggerenter
	{
		if (healthObject != null) {
			if (other.CompareTag ("Enemy")) {
				Scoreboard.killType = "Fear";
				other.GetComponent<EnemyHealthController>().DealDamage (damage);
				other.GetComponent<EnemyController> ().SwitchLanes ();
				other.GetComponent<EnemyController> ().MultiplySpeed(fearSpeed, 0f);
				other.GetComponent<ClothingController>().villagerOrientation = "left";
				collectCurrentEnemies ();
			}
		}
		Destroy (gameObject, timetoDestroy);
	}
	void collectCurrentEnemies(){
		gameObjects =  GameObject.FindGameObjectsWithTag ("Enemy");
		for (var i = 0; i < gameObjects.Length; i++) {
			gameObjects[i].GetComponent<EnemyController> ().SwitchLanes ();
			gameObjects [i].GetComponent<EnemyController> ().MultiplySpeed(fearSpeed, 0f);
			gameObjects [i].GetComponent<ClothingController>().villagerOrientation = "left";
		}
	}
}
