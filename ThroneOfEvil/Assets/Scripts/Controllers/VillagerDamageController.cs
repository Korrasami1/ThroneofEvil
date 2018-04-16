using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerDamageController : MonoBehaviour {
	public float damageTraps = 100;
	public float damageDoor = 100;
	ScoreManager Scoreboard;

	void Start(){
		getScoreManager ();
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
		if (other.CompareTag ("Trap")) {
			Scoreboard.killType = "Other";
			GetComponent<EnemyHealthController> ().DealDamage (damageTraps);

		}
		if (other.CompareTag ("TrapDoor")) {
			Scoreboard.killType = "Trap Door";
			GetComponent<EnemyHealthController> ().DealDamage (damageDoor);
		}
		if (other.CompareTag ("Boulder")) {
			Scoreboard.killType = "Boulder";
			GetComponent<EnemyHealthController> ().DealDamage (damageDoor);
		}
	}
}
