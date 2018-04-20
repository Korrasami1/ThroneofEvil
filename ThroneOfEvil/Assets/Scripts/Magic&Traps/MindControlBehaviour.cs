using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindControlBehaviour : MonoBehaviour {

	EnemyHealthController enemyHealth;
	ScoreManager Scoreboard;
	GameObject healthObject;
	public GameObject mindcontrolattack;
	Vector3 mousePosition,targetPosition;
	public float distance = 10f;
	public float damage = 0;

	void Start(){
		mindcontrolattack.SetActive (false);
		//To get the current mouse position
		mousePosition = Input.mousePosition;

		//Convert the mousePosition according to World position
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x,mousePosition.y,distance));

		getEnemyHealthController ();
		getScoreManager ();
		//fearactivated = true;
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
			Debug.Log("Cannot find 'EnemyHealthController' script from Mind Control Script");
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
				other.GetComponent<EnemyController> ().speed = 0;
				other.GetComponent<ClothingController>().villagerOrientation = "left";
				mindcontrolattack.SetActive (true);
			}
		}
		Destroy (gameObject, 2);
	}
}
