using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearBehaviour : MonoBehaviour {

	EnemyHealthController enemyHealth;
	public GameObject fearStopRadius;
	ScoreManager Scoreboard;
	GameObject healthObject;
	public float damage = 0;
	public float timetoDestroy = 1f;
	public int FearDuration = 3;

	void Start(){
		getEnemyHealthController ();
		getScoreManager ();
		//fearactivated = true;
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

	void OnTriggerEnter(Collider other)
	{
		if (healthObject != null) {
			if (other.CompareTag ("Enemy")) {
				Scoreboard.killType = "Fear";
				other.GetComponent<EnemyHealthController>().DealDamage (damage);
				other.GetComponent<EnemyController> ().speed *= -1;
				other.GetComponent<ClothingController>().villagerOrientation = "left";
			}
		}
		Destroy (gameObject, timetoDestroy);
	}
	/*void OnTriggerStay(Collider other)
	{
		if (healthObject != null) {
			if (other.CompareTag ("Enemy")) {
				Debug.Log("inside collider");
				Scoreboard.killType = "Fear";
				enemyHealth.DealDamage (damage);
				other.GetComponent<EnemyController> ().speed *= -1;
				other.GetComponent<ClothingController>().villagerOrientation = "left";
			}
		}
	}*/
		
}
