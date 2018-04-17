using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour {

	public float currentHealth { get; set; }
	public float MaxHealth { get; set; }
	GameController gameController;
	GameObject gameKillcounter;
	ScoreManager Scoreboard;
	GameObject points;
	Transform pointsPlacement;
	//float healthbar;

	// Use this for initialization
	void Start () {
		MaxHealth = 100f;
		//resetting health after every completed level
		currentHealth = MaxHealth;
		//healthbar = calculateHealth();
		getGameController();
		getScoreManager ();
	}

	void Update()
	{
		pointsPlacement = gameObject.transform;
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
		//healthbar = calculateHealth();
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
	
	}
		
}
