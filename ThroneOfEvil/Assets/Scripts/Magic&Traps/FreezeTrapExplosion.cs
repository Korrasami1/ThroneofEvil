using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTrapExplosion : MonoBehaviour {

	public float deletionTimer = 1f;
	public float freezeDurationSeconds = 3f;
	ScoreManager scoreboard;
	void Start () {
		Destroy (gameObject, deletionTimer);
	}
	IEnumerator FreezeCountdown(Collider other)
	{
		other.tag = "FrozenEnemy";
		yield return new WaitForSeconds (freezeDurationSeconds);
		other.tag = "Enemy";
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Enemy") || other.CompareTag ("TarredEnemy") || other.CompareTag("BurningEnemy")) {
			other.GetComponent<EnemyController>().CheckForTag();
			StartCoroutine(FreezeCountdown (other));
			other.GetComponent<EnemyController>().CheckForTag();
		}
	}
}