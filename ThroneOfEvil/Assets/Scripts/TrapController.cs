using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour {
	public GameObject trap1, trap2, trap3, trap4;
	public Transform trans1, trans2, trans3, trans4;
	private bool isTrapReady = false;
	Vector3 mousePosition,targetPosition;
	private GameObject trapClone;
	float distance=10f;

	// Update is called once per frame
	void Update () {

		//To get the current mouse position
		mousePosition = Input.mousePosition;

		//Convert the mousePosition according to World position
		targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x,mousePosition.y,distance));

		//If Left Button is clicked #was 0 also was trapClone.transform.position
		if(Input.GetMouseButtonUp(1) && isTrapReady == true)
		{
			reCentreTrap();
			Instantiate(trapClone,targetPosition, Quaternion.identity);
		}
	}

	//this function is currently hard coded to centre a trap in the appropriate lanes.
	void reCentreTrap(){
		//lane one
		if (targetPosition.y >= 5f || targetPosition.y >= 3.75f && targetPosition.y <= 5f) {
			targetPosition = new Vector3(targetPosition.x, 5f, 0f);
		//lane two
		} else if (targetPosition.y < 3.75f && targetPosition.y >= 2.5f || targetPosition.y <= 2.5f && targetPosition.y >= 1.25f) {
			targetPosition = new Vector3(targetPosition.x, 2.5f, 0f);
		//lane three
		} else if (targetPosition.y < 1.25f && targetPosition.y >= 0f || targetPosition.y <= 0f && targetPosition.y >= -1.25f) {
			targetPosition = new Vector3(targetPosition.x, 0f, 0f);
		//lane four
		} else if (targetPosition.y > -3.75f && targetPosition.y >= -2.5f || targetPosition.y <= -2.5f && targetPosition.y <= -1.25f) {
			targetPosition = new Vector3(targetPosition.x, -2.5f, 0f);
		//lane five
		} else if (targetPosition.y <= -5f || targetPosition.y >= -5f && targetPosition.y <= -3.75f) {
			targetPosition = new Vector3(targetPosition.x, -5f, 0f);
		}
	}
	
	public void trapSelection(int trapNum){
		if (trapNum == 1) {
			isTrapReady = true;	
			trans1.position = targetPosition;
			trapClone = trap1;
		} else if (trapNum == 2) {
			isTrapReady = true;
			trans2.position = targetPosition;
			trapClone = trap2;
		} else if (trapNum == 3) {
			isTrapReady = true;
			trans2.position = targetPosition;
			trapClone = trap3;
		} else if (trapNum == 4) {
			isTrapReady = true;
			trans2.position = targetPosition;
			trapClone = trap4;
		}
	}		
}
