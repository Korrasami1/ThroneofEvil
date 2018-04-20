﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningMagicBehaviour : MonoBehaviour {

	Vector3 mousePosition,targetPosition;
	public float distance = 10f;
	public float deletionTimer = 3f;
	void Start(){
		//To get the current mouse position
		mousePosition = Input.mousePosition;
		//Convert the mousePosition according to World position
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x,mousePosition.y,distance));
		Destroy (gameObject, deletionTimer);
	}
	void Update () {
		//To get the current mouse position
		mousePosition = Input.mousePosition;
		//Convert the mousePosition according to World position
		//transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x,mousePosition.y,distance));
	}
}
