using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicOrbController : MonoBehaviour {
	Vector3 mousePosition,targetPosition;
	public float distanceZaxis = 10f;
	public float sphereRotateSpeed;
	public GameObject menuOptions, menuPlay;
	// Use this for initialization
	void Start () {
		menuOptions.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		//To get the current mouse position
		mousePosition = Input.mousePosition;

		//Convert the mousePosition according to World position
		targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x,mousePosition.y,distanceZaxis));
		transform.Rotate ((new Vector3(0.0f, targetPosition.y, 0.0f)/** sphereRotateSpeed*/), Space.Self);

		if (targetPosition.x <= 2f) {
			menuOptions.SetActive (true);
			menuPlay.SetActive (false);
		} else if(targetPosition.x > 2f){
			menuOptions.SetActive (false);
			menuPlay.SetActive (true);
		}
	}

	void changeMenuSelection(){
		//i want to move sphere around on mouse movement
		if (targetPosition.x == 2f) {
			Debug.Log ("change sprite on mouse movement");
		}
	}
}
