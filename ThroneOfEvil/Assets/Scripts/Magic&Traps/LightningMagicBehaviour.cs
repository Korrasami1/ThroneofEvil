using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningMagicBehaviour : MonoBehaviour {

	EnemyHealthController enemyHealth;
	GameObject healthObject;
	public float damage = 30;
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
		healthObject = GameObject.FindWithTag("Enemy");
		if (healthObject != null)
		{
			enemyHealth = healthObject.GetComponent<EnemyHealthController>();
		}
		if (enemyHealth == null)
		{
			Debug.Log("Cannot find 'EnemyHealthController' script from Lightning Script");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (healthObject != null) {
			if (other.CompareTag ("Enemy")) {
				if (enemyHealth.currentHealth <= 0) {
					Destroy (other.gameObject);
				} else {
					enemyHealth.DealDamage (damage);
					Debug.Log ("current enemies health after Lightning " + enemyHealth.currentHealth);
				}
			}
		}
		Destroy (gameObject, timeDelay);
	}
}
