using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthController : MonoBehaviour {

	public float currentHealth { get; set; }
	public float MaxHealth { get; set; }
	GameController gameController;
	GameObject gameKillcounter;
	ScoreManager Scoreboard;
	GameObject points;
	Transform pointsPlacement;
	//float health;
	public Slider healthbar;
	bool isdeath = false;

	// Use this for initialization
	void Start () {
		MaxHealth = 100f;
		//resetting health after every completed level
		currentHealth = MaxHealth;
		//health = calculateHealth ();
		if (healthbar.enabled == true) {
			healthbar.value = calculateHealth ();
		}
		getGameController();
		getScoreManager ();
	}

	void Update()
	{
		pointsPlacement = gameObject.transform;
		if (healthbar.enabled == true) {
			healthBarPlacement ();
		}
		if (isdeath) {
			StartCoroutine (death());
		}
	}
	void healthBarPlacement(){
		Vector3 toCamera = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		healthbar.transform.position = toCamera;
		healthbar.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, false);
		//healthbar.transform.position = toCamera;
	}

	private void getGameController(){
		gameKillcounter = GameObject.FindWithTag("GameController");
		if (gameKillcounter != null)
		{
			gameController = gameKillcounter.GetComponent<GameController>();
		}
		if (gameController == null)
		{
			Debug.Log("Cannot find 'GameController' script");
		}
	}

	private void getScoreManager(){
		points = GameObject.FindWithTag("Scoreboard");
		if (points != null)
		{
			Scoreboard = points.GetComponent<ScoreManager>();
		}
		if (Scoreboard == null)
		{
			Debug.Log("Cannot find 'ScoreboardManager' script");
		}
	}

	public void DealDamage(float damageValue)
	{
		currentHealth -= damageValue;
		//health = calculateHealth ();
		if (healthbar.enabled == true) {
			healthbar.value = calculateHealth ();
		}
		if(currentHealth <= 0 && isdeath == false)
		{
			Die();
		}
	}

	float calculateHealth()
	{
		return currentHealth / MaxHealth;
	}

	public float getHealth()
	{
		return currentHealth;
	}

	void Die()
	{
		currentHealth = 0;
		isdeath = true;
		Debug.Log("Villager Killed!");
		/*if (healthbar.enabled == true) {
			Destroy (healthbar.gameObject, 1);
		}*/
		//Destroy(gameObject, 1);
	}
	IEnumerator death(){
		yield return new WaitForSeconds (0.5f);
		gameController.villagerDeathCount ();
		Scoreboard.DealPoints (pointsPlacement);
		Destroy (gameObject);
		if (healthbar.enabled == true) {
			Destroy (healthbar.gameObject);
		}
		isdeath = false;
	}
}
