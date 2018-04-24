using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTrapExplosion : MonoBehaviour {

	public float deletionTimer = 1f;
	public float freezeDurationSeconds = 3f;
	ScoreManager scoreboard;
	Collider col;
	bool iscooldownactivated = false;
	void Start () {
		Destroy (gameObject, deletionTimer);
	}

	void FixedUpdate(){
		if (iscooldownactivated == true) {
			StartCoroutine (FreezeCountdown (col));
		}
	}
	IEnumerator FreezeCountdown(Collider other)
	{
		other.tag = "FrozenEnemy";
		other.GetComponent<EnemyController>().CheckForTag();
		yield return new WaitForSeconds (freezeDurationSeconds);
		other.tag = "Enemy";
		other.GetComponent<EnemyController>().CheckForTag();
		iscooldownactivated = false;
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Enemy") || other.CompareTag ("TarredEnemy") || other.CompareTag("BurningEnemy") || other.CompareTag("FearedEnemy")) {
			col = other;
			iscooldownactivated = true;
		}
	}
}