using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour {
	public GameObject trap1, trap2, trap3, trap4, trap5;
	public int BoulderCooldownSpeed = 3;
	private bool hasBoulderCooledDown = true;
	private int tempTrapNum = 0; //this is just so that the boulder cooldown doesnt start every time a trap is placed
	private bool isTrapReady = false;
	Vector3 mousePosition,targetPosition;
	private GameObject trapClone;
	float distance=10f;
	float laneOne, laneTwo, laneThree, laneFour, laneFive;
	MouseRenderer mouse;

	void Start(){
		laneOne = 5f;
		laneTwo = 2.5f;
		laneThree = 0f;
		laneFour = -2.5f;
		laneFive = -5f;
		GameObject mouseObject = GameObject.FindWithTag("Mouse");
		if (mouseObject != null)
		{
			mouse = mouseObject.GetComponent<MouseRenderer>();
		}
		if (mouse == null)
		{
			Debug.Log("Cannot find 'Mouse Renderer' script");
		}
	}

	// Update is called once per frame
	void FixedUpdate () {

		//To get the current mouse position
		mousePosition = Input.mousePosition;

		//Convert the mousePosition according to World position
		targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x,mousePosition.y,distance));

		//If Left Button is clicked #was 0 also was trapClone.transform.position
		setTrap();
	}
	//had as public for a different script but its not in use right now
	public void setTrap(){
		//If Left Button is clicked #was 0 also was trapClone.transform.position

		if (Input.GetMouseButtonUp(1) && isTrapReady == true)
		{
			//boulder cooldown funcitonality
			if (tempTrapNum == 6) {
				if (hasBoulderCooledDown == true) {
					reCentreTrap ();
					Instantiate (trapClone, targetPosition, Quaternion.identity);
					hasBoulderCooledDown = false;
					StartCoroutine (BoulderCooldown (hasBoulderCooledDown));
				}
			//normal functionality
			} else {
				reCentreTrap();
				Instantiate(trapClone,targetPosition, Quaternion.identity);
			}
		}
	}

	//had as public for a different script but its not in use right now
	public void reCentreTrap(){
		//lane one
		if (targetPosition.y >= laneOne || targetPosition.y >= 3.75f && targetPosition.y <= laneOne) {
			targetPosition = new Vector3 (targetPosition.x, laneOne, 0f);
			//trapClone.transform.position = targetPosition;
		//lane two
		} else if (targetPosition.y < 3.75f && targetPosition.y >= laneTwo || targetPosition.y <= laneTwo && targetPosition.y >= 1.25f) {
			targetPosition = new Vector3 (targetPosition.x, laneTwo, 0f);
			//trapClone.transform.position = targetPosition;
		//lane three
		} else if (targetPosition.y < 1.25f && targetPosition.y >= laneThree || targetPosition.y <= laneThree && targetPosition.y >= -1.25f) {
			targetPosition = new Vector3 (targetPosition.x, laneThree, 0f);
			//trapClone.transform.position = targetPosition;
		//lane four
		} else if (targetPosition.y > -3.75f && targetPosition.y <= laneFour || targetPosition.y >= laneFour && targetPosition.y <= -1.25f) {
			targetPosition = new Vector3 (targetPosition.x, laneFour, 0f);
			//trapClone.transform.position = targetPosition;
		//lane five
		} else if (targetPosition.y <= laneFive && targetPosition.y <= laneFive || targetPosition.y <= laneFive && targetPosition.y >= -3.75f) {
			targetPosition = new Vector3 (targetPosition.x, laneFive, 0f);
			//trapClone.transform.position = targetPosition;
		}
	}

	IEnumerator BoulderCooldown(bool hasbeenCooled){
		if (hasbeenCooled == false) {
			Debug.Log ("bouldercooldown has been activated");
			yield return new WaitForSeconds (BoulderCooldownSpeed);
			Debug.Log ("bouldercooldown has completed");
			hasBoulderCooledDown = true;
		}
	}
	
	public void trapSelection(int trapNum){
		if (trapNum == 1) {
			//crate trap
			isTrapReady = true;	
			trapClone = trap1;
			mouse.cursorChangeNum = 1;
			tempTrapNum = 1;
		} else if (trapNum == 2) {
			//banana peel
			isTrapReady = true;
			trapClone = trap2;
			mouse.cursorChangeNum = 2;
			tempTrapNum = 2;
		} else if (trapNum == 3) {
			//dynamite
			isTrapReady = true;
			trapClone = trap3;
			mouse.cursorChangeNum = 3;
			tempTrapNum = 3;
		} else if (trapNum == 4) {
			//bear trap
			isTrapReady = true;
			trapClone = trap4;
			mouse.cursorChangeNum = 4;
			tempTrapNum = 4;
		} else if (trapNum == 5) {
			//mouse normal
			mouse.cursorChangeNum = 0;
		} else if (trapNum == 6) {
			//Boulder
			if (hasBoulderCooledDown == true) {
				isTrapReady = true;
				trapClone = trap5;
				mouse.cursorChangeNum = 5;
				tempTrapNum = 6;
			}
		}
	}		
}
