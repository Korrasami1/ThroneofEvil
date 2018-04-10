using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMenuBehaviours : MonoBehaviour {

	/*Vector3 mousePosition,targetPosition;
	private TrapController trapController;
	public float distance = 10f;

	void Start(){
		GameObject trapControllerObject = GameObject.FindWithTag("TrapController");
		if (trapControllerObject != null)
		{
			trapController = trapControllerObject.GetComponent<TrapController>();
		}
		if (trapController == null)
		{
			Debug.Log("Cannot find 'TrapController' script");
		}
	}

//might need to just instantiate in trap controller and then have it follow mouse then once changed then it will destroy and instantiate again.
	void Update () {
		//To get the current mouse position
		mousePosition = Input.mousePosition;

		if (trapController.tosetTrap == false) {
			//Convert the mousePosition according to World position
			transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (mousePosition.x, mousePosition.y, distance));
		} else {
			trapController.reCentreTrap ();
			trapController.tosetTrap = false;
		}
		//access to the trap controller script function
		//trapController.setTrap();
	}

	/*void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Enemy")) {
			Destroy (other.gameObject);
		} else {
			Destroy (gameObject, 5);
		}
	}*/
}
