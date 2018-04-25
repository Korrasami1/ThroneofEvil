using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvilMeterConrtoller : MonoBehaviour {

	public float currentEvilness { get; set;}
	public float MaxEvilness { get; set; }
	public float MinEvilness { get; set;}

	public Slider Evilbar;

	// Use this for initialization
	void Start () {
		MaxEvilness = 100f;
		MinEvilness = 0f;
		//resetting health after every completed level
		currentEvilness = MinEvilness;

		Evilbar.value = calculateEvilness();
	}
		
	public void dealNutrition(float evilValue)
	{
		currentEvilness += evilValue;
		Evilbar.value = calculateEvilness();
		if(currentEvilness >= 100)
		{
			EvilPromotion();
		}
	}

	float calculateEvilness()
	{
		return currentEvilness / MaxEvilness;
	}

	public float getEvilness()
	{
		return currentEvilness;
	}

	void EvilPromotion()
	{
		currentEvilness = 100;
		Debug.Log("You have been Promoted!");
	}
		
	public void resetEvilness()
	{
		currentEvilness = MinEvilness;
		Evilbar.value = calculateEvilness();
	}
}
