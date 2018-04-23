using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarPool : MonoBehaviour {
	
	public int uses = 3;
	public float slowDurationSeconds = 3;
	public GameObject explosion;
	ScoreManager scoreboard;
	void Start () {
		GetScoreManager ();
	}
	void Update () {
		if (uses <= 0) {
			Destroy (gameObject);
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
			Debug.Log("Cannot find 'ScoreboardManager' script");
		}
	}
	IEnumerator TarCountdown(Collider other)
	{
		other.tag = "TarredEnemy";
		yield return new WaitForSeconds (slowDurationSeconds);
		other.tag = "Enemy";
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Enemy") || other.CompareTag ("TarredEnemy")) {
			other.GetComponent<EnemyController>().CheckForTag();
			StartCoroutine(TarCountdown (other));
			other.GetComponent<EnemyController>().CheckForTag();
			uses -= 1;
		}
		if (other.CompareTag ("Boulder") || other.CompareTag("TarredBoulder")){
			uses -= 1;
		}
		if (other.CompareTag ("Fire") || other.CompareTag ("Explosion") || other.CompareTag ("BurningEnemy")) {
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}
}