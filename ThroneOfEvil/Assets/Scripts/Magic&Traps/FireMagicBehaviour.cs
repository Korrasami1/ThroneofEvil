using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMagicBehaviour : MonoBehaviour {
	EnemyHealthController enemyHealth;
	ScoreManager Scoreboard;
	GameObject healthObject;
	public float damage = 20;
	Vector3 mousePosition,targetPosition;
	public float distance = 10f;
	public float timetoDestroy = 5f;

	void Start(){
		//To get the current mouse position
		mousePosition = Input.mousePosition;

		//Convert the mousePosition according to World position
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x,mousePosition.y,distance));

		//getting the enemy health controller from the Enemy prefab
		getEnemyHealthController();
		getScoreManager ();
	}

	void Update () {
		//To get the current mouse position
		mousePosition = Input.mousePosition;

		//Convert the mousePosition according to World position
		//transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x,mousePosition.y,distance));
	}

	void getEnemyHealthController(){
		healthObject = GameObject.FindWithTag("Enemy");
		if (healthObject != null)
		{
			enemyHealth = healthObject.GetComponent<EnemyHealthController>();
		}
		if (enemyHealth == null)
		{
			Debug.Log("Cannot find 'EnemyHealthController' script from fire Script");
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

	void OnTriggerEnter(Collider other)
	{
		if (healthObject != null) {
			if (other.CompareTag ("Enemy")) {
				Scoreboard.killType = "Fire";
				enemyHealth.DealDamage (damage);
				Debug.Log ("current enemies health after Fire " + enemyHealth.currentHealth);
			}
			if (other.CompareTag ("FreezeTrapExplosion") || other.CompareTag("TarPool")) {
				Destroy (gameObject);
			}
		}
		Destroy (gameObject, timetoDestroy);
	}
}
