using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerDamageController : MonoBehaviour {
	public float trapDoorDamage = 100;
	public float boulderDamage = 50;
	public float boulderFrozenDamage = 100;
	public float burningBoulderDamage = 100;
	public float fireDamage = 25;
	public float fireFrozenDamage = 0;
	public float explosionDamage = 75;
	public float explosionFrozenDamage = 100;
	public float burningDamageOverTime = 5;
	public float lightningDamage = 50;
	public float lightningFrozenDamage = 100;
	public float minionDamage = 50;
	public float mindControlAttackDamage = 25;
	public float freezeDurationSeconds = 3f;
	public float slowDurationSeconds = 3f;
	public bool useDebugs = false;
	EnemyHealthController enemyHealth;
	ScoreManager scoreboard;
	private bool isBurned = false;
	//private bool isImmune = false;
	void Start(){
		GetEnemyHealthController ();
		GetScoreManager ();
	}
	void FixedUpdate() {
		if(gameObject.CompareTag("BurningEnemy") && !isBurned){
			StartCoroutine (BurningDamage ());
		}
	}
	IEnumerator BurningDamage()
	{
		enemyHealth.DealDamage (burningDamageOverTime);
		isBurned = true;
		yield return new WaitForSeconds (1f);
		isBurned = false;
		if (useDebugs) {
			Debug.Log ("Enemy took " + burningDamageOverTime + " burning damage!");
		}
	}
	void GetEnemyHealthController(){
		enemyHealth = gameObject.GetComponent<EnemyHealthController>();
		if (enemyHealth == null)
		{
			Debug.Log("Cannot find 'EnemyHealthController' script from VillagerDamageController script");
		}
	}
	private void GetScoreManager(){
		GameObject points = GameObject.FindWithTag("Scoreboard");
		if (points != null)
		{
			scoreboard = points.GetComponent<ScoreManager>();
		}
		if (scoreboard == null)
		{
			Debug.Log("Cannot find 'ScoreboardManager' script from VillagerDamageController script");
		}
	}
	IEnumerator TarCountdown(GameObject other)
	{
		other.tag = "TarredEnemy";
		//gameObject.GetComponent<EnemyController>().CheckForTag();
		gameObject.GetComponent<VillagerIdleMode>().CheckForTag();
		yield return new WaitForSeconds (slowDurationSeconds);
		other.tag = "Enemy";
		//gameObject.GetComponent<EnemyController>().CheckForTag();
		gameObject.GetComponent<VillagerIdleMode>().CheckForTag();
	}
	IEnumerator FreezeCountdown(GameObject other)
	{
		other.tag = "FrozenEnemy";
		//gameObject.GetComponent<EnemyController>().CheckForTag();
		gameObject.GetComponent<VillagerIdleMode>().CheckForTag();
		yield return new WaitForSeconds (freezeDurationSeconds);
		other.tag = "Enemy";
		//gameObject.GetComponent<EnemyController>().CheckForTag();
		gameObject.GetComponent<VillagerIdleMode>().CheckForTag();
	}
	void DebugHealth(string damager){
		if (useDebugs) {
			Debug.Log ("Health of enemy before " + damager + " damage is: " + enemyHealth.currentHealth);
		}
	}
	void DebugDamage(float damage, string damager){
		if (useDebugs) {
			Debug.Log ("Enemy took " + damage + " points of " + damager + " damage, while isFrozen was " + gameObject.CompareTag ("FrozenEnemy") + ", current health of enemy is: " + enemyHealth.currentHealth);
		}
	}
	void OnTriggerStay(Collider other)
	{
		string damagerDebug = other.tag;
		if (other.CompareTag ("TrapDoor")) {
			DebugHealth (damagerDebug); 
			scoreboard.killType = "Trap Door";
			enemyHealth.DealDamage (trapDoorDamage);
			DebugDamage (trapDoorDamage, damagerDebug);
		}
		if (other.CompareTag("Boulder") || other.CompareTag("TarredBoulder")){
			DebugHealth (damagerDebug);
			if (gameObject.CompareTag ("FrozenEnemy")) {
				scoreboard.killType = "Shatter";
				enemyHealth.DealDamage (boulderFrozenDamage);
				DebugDamage (boulderFrozenDamage, damagerDebug);
			} else {
				scoreboard.killType = "Boulder";
				enemyHealth.DealDamage (boulderDamage);
				DebugDamage (boulderDamage, damagerDebug);
			}
		}
		if (other.CompareTag("BurningBoulder")){
			DebugHealth (damagerDebug);
			if (gameObject.CompareTag ("FrozenEnemy")) {
				scoreboard.killType = "Shatter";
				enemyHealth.DealDamage (boulderFrozenDamage);
				DebugDamage (boulderFrozenDamage, damagerDebug);
			} else {
				scoreboard.killType = "Boulder";
				enemyHealth.DealDamage (burningBoulderDamage);
				DebugDamage (burningBoulderDamage, damagerDebug);
			}
		}
		if (other.CompareTag("Lightning")){
			DebugHealth (damagerDebug);
			if (gameObject.CompareTag ("FrozenEnemy")) {
				scoreboard.killType = "Shatter";
				enemyHealth.DealDamage (lightningFrozenDamage);
				DebugDamage (lightningFrozenDamage, damagerDebug);
			} else {
				scoreboard.killType = "Lightning";
				enemyHealth.DealDamage (lightningDamage);
				DebugDamage (lightningDamage, damagerDebug);
				gameObject.GetComponent<Animator> ().enabled = true; //will change to Play("Lightning") later
			}
		}
		if (other.CompareTag("Fire")){
			DebugHealth (damagerDebug);
			if (gameObject.CompareTag ("FrozenEnemy")) {
				gameObject.tag = "Enemy";
				//gameObject.GetComponent<EnemyController>().CheckForTag();
				gameObject.GetComponent<VillagerIdleMode>().CheckForTag();
				scoreboard.killType = "Shatter";
				enemyHealth.DealDamage (fireFrozenDamage);
				DebugDamage (fireFrozenDamage, damagerDebug);
			} else if (gameObject.CompareTag ("TarredEnemy")) {
				gameObject.tag = "BurningEnemy";
				//gameObject.GetComponent<EnemyController>().CheckForTag();
				gameObject.GetComponent<VillagerIdleMode>().CheckForTag();
				enemyHealth.DealDamage (fireDamage);
				DebugDamage (fireDamage, damagerDebug);
			}else {
				scoreboard.killType = "Fire";
				enemyHealth.DealDamage (fireDamage);
				DebugDamage (fireDamage, damagerDebug);
			}
		}
		if (other.CompareTag("Explosion")){
			DebugHealth (damagerDebug);
			if (gameObject.CompareTag ("FrozenEnemy")) {
				gameObject.tag = "Enemy";
				//gameObject.GetComponent<EnemyController>().CheckForTag();
				gameObject.GetComponent<VillagerIdleMode>().CheckForTag();
				scoreboard.killType = "Shatter";
				enemyHealth.DealDamage (explosionFrozenDamage);
				DebugDamage (explosionFrozenDamage, damagerDebug);
			} else if (gameObject.CompareTag ("TarredEnemy")) {
				gameObject.tag = "BurningEnemy";
				//gameObject.GetComponent<EnemyController>().CheckForTag();
				gameObject.GetComponent<VillagerIdleMode>().CheckForTag();
				enemyHealth.DealDamage (explosionDamage);
				DebugDamage (explosionDamage, damagerDebug);
			}else {
				scoreboard.killType = "Fire";
				enemyHealth.DealDamage (explosionDamage);
				DebugDamage (explosionDamage, damagerDebug);
			}
		}
		if (other.CompareTag("FreezeTrapExplosion")){
			DebugHealth (damagerDebug);
			if (gameObject.CompareTag ("BurningEnemy")) {
				gameObject.tag = "Enemy";
				//gameObject.GetComponent<EnemyController>().CheckForTag();
				gameObject.GetComponent<VillagerIdleMode>().CheckForTag();
			}else {
				StartCoroutine (FreezeCountdown (gameObject));
			}
		}
		if (other.CompareTag("TarPool")){
			DebugHealth (damagerDebug);
			if (gameObject.CompareTag ("TarredEnemy")) {
				return;
			} else {
				StartCoroutine (TarCountdown (gameObject));
			}
		}
		if (other.CompareTag ("Minion")) {
			DebugHealth (damagerDebug); 
			scoreboard.killType = "Minion";
			enemyHealth.DealDamage (minionDamage);
			DebugDamage (minionDamage, damagerDebug);
		}
		/*if (other.CompareTag ("MindControlAttack")) {
			DebugHealth (damagerDebug);
			scoreboard.killType = "MindControl";
			enemyHealth.DealDamage (mindControlAttackDamage);
			DebugDamage (mindControlAttackDamage, damagerDebug);
		}*/
	}
}
