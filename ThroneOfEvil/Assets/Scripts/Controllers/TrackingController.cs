using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingController : MonoBehaviour {

	EnemyHealthController enemyHealth;
	public float damage = 10;
	public float _speed = 5;
	public Transform target;
	private float _angleOffset = -90;
	// Use this for initialization
	void Start()
	{
		//getting the enemy health controller from the Enemy prefab
		getEnemyHealthController();
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 dir = target.position - transform.position; //was target.transform.position
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle + _angleOffset, Vector3.forward);

		transform.position += transform.up * _speed * Time.deltaTime;
	}

	void getEnemyHealthController(){
		GameObject healthObject = GameObject.FindWithTag("Enemy");
		if (healthObject != null)
		{
			enemyHealth = healthObject.GetComponent<EnemyHealthController>();
		}
		if (enemyHealth == null)
		{
			Debug.Log("Cannot find 'EnemyHealthController' script from MinionTracking Script");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Enemy")) {
			if (enemyHealth.currentHealth <= 0) {
				Destroy (other.gameObject);
			} else {
				enemyHealth.DealDamage(damage);
				Debug.Log ("current enemies health after Minions " + enemyHealth.currentHealth);
			}
		}
		if (other.CompareTag ("MinionTarget")) {
			Destroy (gameObject);
		}
	}
}
