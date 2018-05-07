using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DigitalRuby.SoundManagerNamespace;

public class TrapController : MonoBehaviour {
	//public GameObject trap1, trap2, trap3, trap4, trap5, trap6;
	//SoundsSceneManager sounds;
	public GameObject boulder, freezeTrap, tarTrap;
	public Image Freezes, Boulders, Tars;
	public Text[] cooldownVisual;
	private float cooldowntimerBoulder, cooldowntimerFreeze, cooldowntimerTar; 
	public float BoulderCooldownSpeed = 3;
	private bool hasBoulderCooledDown = true;
	public float tarTrapCooldownSpeed = 3;
	public float freezeTrapCooldownSpeed = 3;
	private bool hasFreezeTrapCooledDown = true;
	private bool hasTarTrapCooledDown = true; 
	//private bool hasTrap1Cooled, hasTrap2Cooled, hasTrap3Cooled, hasTrap4Cooled, hasTrap5Cooled;
	//public float Trap1CoolSpeed, Trap2CoolSpeed, Trap3CoolSpeed, Trap4CoolSpeed, Trap5CoolSpeed;
	public float laneOne = 5.25f;                  //Representing the Y-value of lane 1
	public float laneTwo = 3.5f;                //Representing the Y-value of lane 2
	public float laneThree = 1.75f;                //Representing the Y-value of lane 3
	public float laneFour = 0f;              //Representing the Y-value of lane 4
	public float laneFive = -1.75f;                //Representing the Y-value of lane 5
	public float laneSix = -3.5f;                //Representing the Y-value of lane 5
	public float laneSeven = -5.25f;                //Representing the Y-value of lane 5
	private float laneDifference;
	private int tempTrapNum = 0; //this is just so that the cooldown doesnt spam start every time a trap is placed
	private bool isTrapReady = false;
	Vector3 mousePosition,targetPosition;
	private GameObject trapClone;
	float distance=10f;
	MouseRenderer mouse;
	Color col1, col2;

	void Start(){
		//sounds = GameObject.FindWithTag ("SoundManager").GetComponent<SoundsSceneManager> ();
		col1 = new Color (105/255.0F, 105/255.0F, 105/255.0F); //cooldown visual
		col2 = new Color (255/255.0F, 255/255.0F, 255/255.0F); //normal visual
		hasBoulderCooledDown = true;
		hasFreezeTrapCooledDown = true;
		hasTarTrapCooledDown = true;
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
		cooldowntimerBoulder = BoulderCooldownSpeed;
		cooldowntimerTar = tarTrapCooldownSpeed;
		cooldowntimerFreeze = freezeTrapCooldownSpeed;
		laneDifference = laneThree - laneFour;
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
		//setTrap();

		//on screen timer of the cooldowns
		if (hasBoulderCooledDown == false) {
			GUITimers (1);
		} else if (hasFreezeTrapCooledDown == false) {
			GUITimers (2);
		} else if (hasTarTrapCooledDown == false) {
			GUITimers (3);
		}
	}

	void GUITimers(int trapnum){
		if (trapnum == 1) {
			cooldowntimerBoulder -= Time.deltaTime;
			cooldownVisual [2].text = cooldowntimerBoulder.ToString ();
		} else if (trapnum == 2) {
			cooldowntimerFreeze -= Time.deltaTime;
			cooldownVisual [0].text = cooldowntimerFreeze.ToString ();
		} else if (trapnum == 3) {
			cooldowntimerTar -= Time.deltaTime;
			cooldownVisual [1].text = cooldowntimerTar.ToString ();
		}
	}
	//had as public for a different script but its not in use right now
	public void setTrap(){
		//If Left Button is clicked #was 0 also was trapClone.transform.position
		if (Input.GetButton("Fire1") && isTrapReady == true)
		{
			//boulder cooldown funcitonality
			if (tempTrapNum == 6) {
				if (hasBoulderCooledDown == true) {
					RecentreBoulder ();
					Instantiate (trapClone, targetPosition, Quaternion.identity);
					hasBoulderCooledDown = false;
					StartCoroutine (BoulderCooldown (hasBoulderCooledDown));
				}
				//normal functionality
			} else {
				switch (tempTrapNum)
				{
				case 4: //Freeze Trap
					if (hasFreezeTrapCooledDown == true) {
						RecentreTrap ();
						Instantiate (trapClone, targetPosition, Quaternion.identity);
						hasFreezeTrapCooledDown = false;
						StartCoroutine (TrapCoolDown (4, hasFreezeTrapCooledDown));
					}
					break;
				case 5:
					//Tar trap
					if (hasTarTrapCooledDown == true) {
						RecentreTrap ();
						Instantiate (trapClone, targetPosition, Quaternion.identity);
						hasTarTrapCooledDown = false;
						StartCoroutine (TrapCoolDown (5, hasTarTrapCooledDown));
					}
					break;
				}
			}
		}
	}

	//had as public for a different script but its not in use right now
	public void RecentreTrap(){
		//lane one
		if (targetPosition.y >= laneOne - laneDifference) {
			targetPosition = new Vector3 (targetPosition.x, laneOne, 0f);
			//lane two
		} else if (targetPosition.y < laneTwo + laneDifference && targetPosition.y >= laneTwo - laneDifference) {
			targetPosition = new Vector3 (targetPosition.x, laneTwo, 0f);
			//lane three
		} else if (targetPosition.y < laneThree + laneDifference && targetPosition.y >= laneThree - laneDifference) {
			targetPosition = new Vector3 (targetPosition.x, laneThree, 0f);
			//lane four
		} else if (targetPosition.y < laneFour + laneDifference && targetPosition.y >= laneFour - laneDifference) {
			targetPosition = new Vector3 (targetPosition.x, laneFour, 0f);
			//lane five
		} else if (targetPosition.y < laneFive + laneDifference && targetPosition.y >= laneFive - laneDifference) {
			targetPosition = new Vector3 (targetPosition.x, laneFive, 0f);
			//lane six
		} else if (targetPosition.y < laneSix + laneDifference && targetPosition.y >= laneSix - laneDifference) {
			targetPosition = new Vector3 (targetPosition.x, laneSix, 0f);
			//lane seven
		} else if (targetPosition.y <= laneSeven + laneDifference) {
			targetPosition = new Vector3 (targetPosition.x, laneSeven, 0f);
		}
	}
	public void RecentreBoulder(){
		float boulderAdjustment = laneDifference / 2;
		//lane one/two
		if (targetPosition.y >= laneTwo) {
			targetPosition = new Vector3 (targetPosition.x, laneOne - boulderAdjustment, 0f);
			//lane two/three
		} else if (targetPosition.y < laneTwo && targetPosition.y >= laneThree) {
			targetPosition = new Vector3 (targetPosition.x, laneTwo - boulderAdjustment, 0f);
			//lane three/four
		} else if (targetPosition.y < laneThree && targetPosition.y >= laneFour) {
			targetPosition = new Vector3 (targetPosition.x, laneThree - boulderAdjustment, 0f);
			//lane four/five
		} else if (targetPosition.y < laneFour && targetPosition.y >= laneFive) {
			targetPosition = new Vector3 (targetPosition.x, laneFour - boulderAdjustment, 0f);
			//lane five/six
		} else if (targetPosition.y < laneFive && targetPosition.y >= laneSix) {
			targetPosition = new Vector3 (targetPosition.x, laneFive - boulderAdjustment, 0f);
			//lane six/seven
		} else if (targetPosition.y < laneSix && targetPosition.y >= laneSeven) {
			targetPosition = new Vector3 (targetPosition.x, laneSix - boulderAdjustment, 0f);
		}
	}

	IEnumerator BoulderCooldown(bool hasbeenCooled){
		if (hasbeenCooled == false) {
			Boulders.color = col1;
			yield return new WaitForSeconds (BoulderCooldownSpeed);
			hasBoulderCooledDown = true;
			Boulders.color = col2;
			cooldowntimerBoulder = BoulderCooldownSpeed;
			cooldownVisual [2].text = "";
		}
	}
	
	public void trapSelection(int trapNum){
		if (trapNum == 4) {
			//freeze trap
			isTrapReady = true;
			trapClone = freezeTrap;
			mouse.cursorChangeNum = 4;
			tempTrapNum = 4;
		} else if (trapNum == 5) {
			//mouse normal
			mouse.cursorChangeNum = 0;
		} else if (trapNum == 6) {
			//Boulder
			if (hasBoulderCooledDown == true) {
				isTrapReady = true;
				trapClone = boulder;
				mouse.cursorChangeNum = 5;
				tempTrapNum = 6;
			}
		} else if (trapNum == 7) {
			//Tar trap
			isTrapReady = true;
			trapClone = tarTrap;
			mouse.cursorChangeNum = 6;
			tempTrapNum = 5;
		}
	}

	public void trapSelection2(){
		
		if (Input.GetButton("TrapBtn1")) {
			//freeze trap
			isTrapReady = true;
			trapClone = freezeTrap;
			mouse.cursorChangeNum = 4;
			tempTrapNum = 4;
			if (hasFreezeTrapCooledDown == true) {
				//RecentreTrap ();
				Instantiate (trapClone, targetPosition, Quaternion.identity);
				hasFreezeTrapCooledDown = false;
				StartCoroutine (TrapCoolDown (4, hasFreezeTrapCooledDown));
			}
		}  else if (Input.GetButton("TrapBtn2")) {
			//Boulder
			if (hasBoulderCooledDown == true) {
				isTrapReady = true;
				trapClone = boulder;
				mouse.cursorChangeNum = 5;
				tempTrapNum = 6;
				RecentreBoulder ();
				Instantiate (trapClone, targetPosition, Quaternion.identity);
				hasBoulderCooledDown = false;
				StartCoroutine (BoulderCooldown (hasBoulderCooledDown));
			}
		}else if (Input.GetButton("TrapBtn3")) {
			//Tar trap
			isTrapReady = true;
			trapClone = tarTrap;
			mouse.cursorChangeNum = 6;
			tempTrapNum = 5;
			if (hasTarTrapCooledDown == true) {
				//RecentreTrap ();
				Instantiate (trapClone, targetPosition, Quaternion.identity);
				hasTarTrapCooledDown = false;
				StartCoroutine (TrapCoolDown (5, hasTarTrapCooledDown));
			}
		}else if (Input.GetButton("MouseSelect")) {
			//mouse normal
			mouse.cursorChangeNum = 0;
		}
	}	

	IEnumerator TrapCoolDown(int traptype, bool hasCooled){
		switch (traptype)
		{
		case 4: //Freeze Trap
			if (hasCooled == false) {
				Freezes.color = col1;
				yield return new WaitForSeconds (freezeTrapCooldownSpeed);
				hasFreezeTrapCooledDown = true;
				Freezes.color = col2;
				cooldowntimerFreeze = freezeTrapCooldownSpeed;
				cooldownVisual [0].text = "";
			}
			break;
		case 5:
			//Tar trap
			if (hasCooled == false) {
				Tars.color = col1;
				yield return new WaitForSeconds (tarTrapCooldownSpeed);
				hasTarTrapCooledDown = true;
				Tars.color = col2;
				cooldowntimerTar = tarTrapCooldownSpeed;
				cooldownVisual [1].text = "";
			}
			break;
		}
	}
}