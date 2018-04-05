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
			Instantiate(trapClone,targetPosition, Quaternion.identity);    
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
