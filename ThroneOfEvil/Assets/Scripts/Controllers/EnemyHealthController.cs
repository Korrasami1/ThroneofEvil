using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour {

	public float currentHealth { get; set; }
	public float MaxHealth { get; set; }

	//float healthbar;

	// Use this for initialization
	void Start () {
		MaxHealth = 100f;
		//resetting health after every completed level
		currentHealth = MaxHealth;
		//healthbar = calculateHealth();
	}

	void Update()
	{

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
		Debug.Log("You Died!");

	}
		
}
