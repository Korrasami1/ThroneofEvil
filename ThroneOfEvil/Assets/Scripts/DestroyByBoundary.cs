using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {
	public ScoreManager scoreboard;

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

    void OnTriggerExit(Collider other)
    {
		if (other.CompareTag("Boulder") || other.CompareTag("Trap") || other.CompareTag("BurningBoulder") || other.CompareTag("TarredBoulder"))
        {
            Destroy(other.gameObject);
        }
		//this is this way so that the current health bars get deleted as well this is for the fear behaviour
		//and with the killtype i just put it there for now so that we dont have scores being added where players dont knw from.
		if (other.CompareTag ("Enemy") || other.CompareTag ("BurningEnemy") || other.CompareTag ("FrozenEnemy") || other.CompareTag ("TarredEnemy") || other.CompareTag ("FearedEnemy")) {
			scoreboard.killType = "Other";
			other.GetComponent<EnemyHealthController> ().DealDamage (102);
		}

    }
}
