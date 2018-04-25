using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapController : MonoBehaviour {
	public GameObject trap1, trap2, trap3, trap4, trap5, trap6;
	public Image Freezes, Boulders, Tars;
	public Text[] cooldownVisual;
	public float BoulderCooldownSpeed = 3;
	private bool hasBoulderCooledDown = true;
	private bool hasTrap1Cooled, hasTrap2Cooled, hasTrap3Cooled, hasTrap4Cooled, hasTrap5Cooled;
	public float Trap1CoolSpeed, Trap2CoolSpeed, Trap3CoolSpeed, Trap4CoolSpeed, Trap5CoolSpeed;
	private int tempTrapNum = 0; //this is just so that the cooldown doesnt spam start every time a trap is placed
	private bool isTrapReady = false;
	Vector3 mousePosition,targetPosition;
	private GameObject trapClone;
	float distance=10f;
	float laneOne, laneTwo, laneThree, laneFour, laneFive;
	private float minLane, maxLane;
	MouseRenderer mouse;

	void Start(){
		laneOne = 5f;
		laneTwo = 2.5f;
		laneThree = 0f;
		laneFour = -2.5f;
		laneFive = -5f;
		minLane = 1.25f;
		maxLane = 3.75f;
		hasTrap1Cooled = true;
		hasTrap2Cooled = true;
		hasTrap3Cooled = true;
		hasTrap4Cooled = true;
		hasTrap5Cooled = true;
		GameObject mouseObject = GameObject.FindWithTag("Mouse");
		if (mouseObject != null)
		{
			mouse = mouseObject.GetComponent<MouseRenderer>();
		}
		if (mouse == null)
		{
			Debug.Log("Cannot find 'Mouse Renderer' script");
		}
		for (int i = 0; i < cooldownVisual.Length; i++) {
			cooldownVisual [i].text = "";
		}
	}
		
	// Update is called once per frame
	void FixedUpdate () {
		//To get the current mouse position
		mousePosition = Input.mousePosition;

		//Convert the mousePosition according to World position
		targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x,mousePosition.y,distance));

		//trap selection for buttons
		trapSelection2();

		//If Left Button is clicked #was 0 also was trapClone.transform.position
		setTrap();
	}
	//had as public for a different script but its not in use right now
	public void setTrap(){
		//If Left Button is clicked #was 0 also was trapClone.transform.position
		if (Input.GetMouseButtonUp(0) && isTrapReady == true)
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
				switch (tempTrapNum)
				{
				case 1: //Crate
					if (hasTrap1Cooled == true) {
						reCentreTrap ();
						Instantiate (trapClone, targetPosition, Quaternion.identity);
						hasTrap1Cooled = false;
						StartCoroutine (TrapCoolDown (1, hasTrap1Cooled));
					}
					break;
				case 2: //Banana Peel
					if (hasTrap2Cooled == true) {
						reCentreTrap ();
						Instantiate (trapClone, targetPosition, Quaternion.identity);
						hasTrap2Cooled = false;
						StartCoroutine (TrapCoolDown (2, hasTrap2Cooled));
					}
					break;
				case 3: //Dynamite
					if (hasTrap3Cooled == true) {
						reCentreTrap ();
						Instantiate (trapClone, targetPosition, Quaternion.identity);
						hasTrap3Cooled = false;
						StartCoroutine (TrapCoolDown (3, hasTrap3Cooled));
					}
					break;
				case 4: //Freeze Trap
					if (hasTrap4Cooled == true) {
						reCentreTrap ();
						Instantiate (trapClone, targetPosition, Quaternion.identity);
						hasTrap4Cooled = false;
						StartCoroutine (TrapCoolDown (4, hasTrap4Cooled));
					}
					break;
				case 5:
					//Tar trap
					if (hasTrap5Cooled == true) {
						reCentreTrap ();
						Instantiate (trapClone, targetPosition, Quaternion.identity);
						hasTrap5Cooled = false;
						StartCoroutine (TrapCoolDown (5, hasTrap5Cooled));
					}
					break;
				}
			}
		}
	}

	//had as public for a different script but its not in use right now
	public void reCentreTrap(){
		//lane one
		if (targetPosition.y >= laneOne || targetPosition.y >= maxLane && targetPosition.y <= laneOne) {
			targetPosition = new Vector3 (targetPosition.x, laneOne, 0f);
			//trapClone.transform.position = targetPosition;
		//lane two
		} else if (targetPosition.y < maxLane && targetPosition.y >= laneTwo || targetPosition.y <= laneTwo && targetPosition.y >= minLane) {
			targetPosition = new Vector3 (targetPosition.x, laneTwo, 0f);
			//trapClone.transform.position = targetPosition;
		//lane three
		} else if (targetPosition.y < minLane && targetPosition.y >= laneThree || targetPosition.y <= laneThree && targetPosition.y >= -minLane) {
			targetPosition = new Vector3 (targetPosition.x, laneThree, 0f);
			//trapClone.transform.position = targetPosition;
		//lane four
		} else if (targetPosition.y > -maxLane && targetPosition.y <= laneFour || targetPosition.y >= laneFour && targetPosition.y <= -minLane) {
			targetPosition = new Vector3 (targetPosition.x, laneFour, 0f);
			//trapClone.transform.position = targetPosition;
		//lane five
		} else if (targetPosition.y <= laneFive && targetPosition.y <= laneFive || targetPosition.y <= laneFive && targetPosition.y >= -maxLane) {
			targetPosition = new Vector3 (targetPosition.x, laneFive, 0f);
			//trapClone.transform.position = targetPosition;
		}
	}

	IEnumerator BoulderCooldown(bool hasbeenCooled){
		if (hasbeenCooled == false) {
			Boulders.color = new Color (105f, 105f, 105f, 1f);
			yield return new WaitForSeconds (BoulderCooldownSpeed);
			hasBoulderCooledDown = true;
			Boulders.color = new Color (255f, 255f, 255f, 1f);
		}
	}
	
	public void trapSelection(int trapNum){
		if (trapNum == 1 ) {
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
		} else if (trapNum == 5 ) {
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
		}else if (trapNum == 7) {
			//Tar trap
				isTrapReady = true;
				trapClone = trap6;
				mouse.cursorChangeNum = 6;
				tempTrapNum = 5;
		}
	}	

	public void trapSelection2(){
		
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			//bear trap
			isTrapReady = true;
			trapClone = trap4;
			mouse.cursorChangeNum = 4;
			tempTrapNum = 4;
		}  else if (Input.GetKeyDown(KeyCode.Alpha2)) {
			//Boulder
			if (hasBoulderCooledDown == true) {
				isTrapReady = true;
				trapClone = trap5;
				mouse.cursorChangeNum = 5;
				tempTrapNum = 6;
			}
		}else if (Input.GetKeyDown(KeyCode.Alpha3)) {
			//Tar trap
			isTrapReady = true;
			trapClone = trap6;
			mouse.cursorChangeNum = 6;
			tempTrapNum = 5;
		}else if (Input.GetKeyDown(KeyCode.Alpha4)) {
			//mouse normal
			mouse.cursorChangeNum = 0;
		}
	}	

	IEnumerator TrapCoolDown(int traptype, bool hasCooled){
		switch (traptype)
		{
		case 1: //Crate
			if (hasCooled == false) {
				yield return new WaitForSeconds (Trap1CoolSpeed);
				hasTrap1Cooled = true;
			}
			break;
		case 2: //Banana Peel
			if (hasCooled == false) {
				yield return new WaitForSeconds (Trap2CoolSpeed);
				hasTrap2Cooled = true;
			}
			break;
		case 3: //Dynamite
			if (hasCooled == false) {
				yield return new WaitForSeconds (Trap3CoolSpeed);
				hasTrap3Cooled = true;
			}
			break;
		case 4: //Freeze Trap
			if (hasCooled == false) {
				Freezes.color = new Color (105f, 105f, 105f, 1f);
				yield return new WaitForSeconds (Trap4CoolSpeed);
				hasTrap4Cooled = true;
				Freezes.color = new Color (255f, 255f, 255f, 1f);
			}
			break;
		case 5:
			//Tar trap
			if (hasCooled == false) {
				Tars.color = new Color (105f, 105f, 105f, 1f);
				yield return new WaitForSeconds (Trap5CoolSpeed);
				hasTrap5Cooled = true;
				Tars.color = new Color (255f, 255f, 255f, 1f);
			}
			break;
		}
	}
}
