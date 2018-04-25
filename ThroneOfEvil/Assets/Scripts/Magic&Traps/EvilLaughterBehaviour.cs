using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilLaughterBehaviour : MonoBehaviour {
	GameObject evil;
	EvilMeterConrtoller evilmeter;
	public float evilNutrition = 35;
	//public GameObject EvilPromotionSplash; //onscreen small splash screen
	// Use this for initialization
	void Start () {
		getEvilMeterController ();
		evilmeter.dealNutrition (evilNutrition);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void getEvilMeterController(){
		evil = GameObject.FindWithTag("GameController");
		if (evil != null)
		{
			evilmeter = evil.GetComponent<EvilMeterConrtoller>();
		}
		if (evilmeter == null)
		{
			Debug.Log("Cannot find 'EvilMeterController' script from EvilLaughter");
		}
	}
}
