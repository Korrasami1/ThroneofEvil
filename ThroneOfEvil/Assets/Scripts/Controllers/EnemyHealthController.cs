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
		if(currentHealth <= 0)
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
		gameController.villagerDeathCount ();
		Scoreboard.DealPoints (pointsPlacement);
		Debug.Log("Villager Killed!");
		Destroy(gameObject);
		if (healthbar.enabled == true) {
			Destroy (healthbar.gameObject);
		}
	}
		
}
