﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningMagicBehaviour : MonoBehaviour {

	EnemyHealthController enemyHealth;
	Vector3 mousePosition,targetPosition;
	public float distance = 10f;
	public int timeDelay = 3;

	void Start(){
		//To get the current mouse position
		mousePosition = Input.mousePosition;

		//Convert the mousePosition according to World position
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x,mousePosition.y,distance));

		//getting the enemy health controller from the Enemy prefab
		getEnemyHealthController();
	}

	void Update () {
		//To get the current mouse position
		mousePosition = Input.mousePosition;

		//Convert the mousePosition according to World position
		//transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x,mousePosition.y,distance));
	}

	void getEnemyHealthController(){
		GameObject healthObject = GameObject.FindWithTag("Enemy");
		if (healthObject != null)
		{
			enemyHealth = healthObject.GetComponent<EnemyHealthController>();
		}
		if (enemyHealth == null)
		{
			Debug.Log("Cannot find 'EnemyHealthController' script");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Enemy")) {
			enemyHealth.DealDamage(30);
			Debug.Log ("current enemies health after Lightning " + enemyHealth.currentHealth);
			if (enemyHealth.currentHealth <= 0) {
				Destroy(other.gameObject);
			}
		} else {
			Destroy (gameObject, timeDelay);
		}
	}
}
