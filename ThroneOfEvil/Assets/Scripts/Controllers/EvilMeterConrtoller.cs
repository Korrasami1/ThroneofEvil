using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvilMeterConrtoller : MonoBehaviour {

	public float currentEvilness { get; set;}
	public float MaxEvilness { get; set; }
	public float MinEvilness { get; set;}
	VariableController variables;
	bool isPromoted;
	public Slider Evilbar;
	TrapController traps;
	public GameObject voicecommands;
	public float EvilPromotionEffectTime = 5;

	// Use this for initialization
	void Start () {
		isPromoted = false;
		MaxEvilness = 100f;
		MinEvilness = 0f;
		//resetting health after every completed level
		currentEvilness = MinEvilness;

		Evilbar.value = calculateEvilness();
		try {
			traps = GameObject.FindWithTag ("TrapController").GetComponent<TrapController> ();
			//voice = GameObject.FindWithTag ("TrapController").GetComponent<VoiceCommandController> ();
		} catch (System.Exception ex) {
			print (ex);
		} 
	}

	void FixedUpdate(){
		if (isPromoted) {
			
			StartCoroutine (promotioneffects());
		}
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
		Debug.Log("You have been Promoted!");
		traps.promotional ();
		voicecommands.GetComponent<VoiceCommandController> ().Promotion ();
		voicecommands.GetComponent<MutedVoiceCommands> ().Promotion ();
		isPromoted = true;
		resetEvilness ();
	}
		
	public void resetEvilness()
	{
		currentEvilness = MinEvilness;
		Evilbar.value = calculateEvilness();
	}

	IEnumerator promotioneffects(){
		yield return new WaitForSeconds (EvilPromotionEffectTime);
		Debug.Log ("yes");
		traps.backfromPromotion ();
		voicecommands.GetComponent<VoiceCommandController> ().BackfromPromotion ();
		voicecommands.GetComponent<MutedVoiceCommands> ().BackfromPromotion ();
		isPromoted = false;
	}
}
