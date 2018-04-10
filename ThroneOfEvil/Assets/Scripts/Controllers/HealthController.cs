using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {
	
	public float currentHealth { get; set; }
	public float MaxHealth { get; set; }

	public Slider healthbar;

	// Use this for initialization
	void Start () {
		MaxHealth = 100f;
		//resetting health after every completed level
		currentHealth = MaxHealth;

		healthbar.value = calculateHealth();
	}

	void Update()
	{
		
	}

	public void DealDamage(float damageValue)
	{
		currentHealth -= damageValue;
		healthbar.value = calculateHealth();
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

	//for use with a healing ability
	public void refillHealth()
	{
		currentHealth = MaxHealth;
		healthbar.value = calculateHealth();
	}
}
