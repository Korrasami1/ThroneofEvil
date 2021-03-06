﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingController : MonoBehaviour {

	EnemyHealthController enemyHealth;
	ScoreManager Scoreboard;
	GameObject healthObject;
	public float damage = 10;
	public float _speed = 5;
	public Transform target;
	public int killstreak = 1;
//	private float _angleOffset = -90;
	// Use this for initialization
	void Start()
	{
		killstreak = 1;
		//getting the enemy health controller from the Enemy prefab
		getEnemyHealthController();
		getScoreManager ();
	}
	// Update is called once per frame
	void FixedUpdate()
	{
		/*Vector3 dir = target.position - transform.position; //was target.transform.position
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle + _angleOffset, Vector3.forward);*/
		transform.position += -transform.right * _speed * Time.deltaTime; //was -transform.up
	}
	void getEnemyHealthController(){
		healthObject = GameObject.FindWithTag("Enemy");
		if (healthObject != null)
		{
			enemyHealth = healthObject.GetComponent<EnemyHealthController>();
		}
		if (enemyHealth == null)
		{
			Debug.Log("Cannot find 'EnemyHealthController' script from MinionTracking Script");
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
		if (other.CompareTag ("Enemy") || other.CompareTag ("FrozenEnemy") || other.CompareTag ("BurningEnemy") || other.CompareTag ("TarredEnemy") || other.CompareTag ("FearedEnemy")) {
			killstreak = killstreak + 1;
		}
		if (other.CompareTag ("MinionTarget")) {
			Destroy (gameObject);
		}
	}
}
