using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using DigitalRuby.SoundManagerNamespace;

public class MagicOrbController : MonoBehaviour {
	Vector3 mousePosition,targetPosition;
	SoundsSceneManager sounds;
	public GameObject Options, MagicOrbEquipment;
	public float distanceZaxis = 10f;
	public float sphereRotateSpeed;
	public GameObject menuOptions, menuPlay, menuExit; //i have it this way because each text is a different size with a different position
	public float changeMenuSelect1XPosition = 3f, changeMenuSelect2XPosition = -2f;

	// Use this for initialization
	void Start () {
		menuOptions.SetActive (false);
		menuExit.SetActive (false);
		sounds = GameObject.FindWithTag ("SoundManager").GetComponent<SoundsSceneManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		//To get the current mouse position
		mousePosition = Input.mousePosition;

		//Convert the mousePosition according to World position
		targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x,mousePosition.y,distanceZaxis));
		changeMenuSelection ();

	}

	void changeMenuSelection(){
		//Options orb select
		if (targetPosition.x >= changeMenuSelect2XPosition && targetPosition.x <= changeMenuSelect1XPosition) {
			menuOptions.SetActive (true);
			menuPlay.SetActive (false);
			menuExit.SetActive (false);
			if (Input.GetButton ("Fire1")) {
				sounds.PlaySound(2);
				Debug.Log ("Options has been selected");
				Options.SetActive(true);
				MagicOrbEquipment.SetActive (false);
				gameObject.SetActive (false);
			}
			//Play orb select
		} else if(targetPosition.x > changeMenuSelect1XPosition){
			menuOptions.SetActive (false);
			menuPlay.SetActive (true);
			menuExit.SetActive (false);
			transform.Rotate ((new Vector3(0.0f, 0.0f, -targetPosition.y)/** sphereRotateSpeed*/), Space.Self);
			if (Input.GetButton ("Fire1")) {
				sounds.PlaySound(2);
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			}
		//Exit orb Select
		}else if(targetPosition.x < changeMenuSelect2XPosition){
			menuOptions.SetActive (false);
			menuPlay.SetActive (false);
			menuExit.SetActive (true);
			transform.Rotate ((new Vector3(0.0f, 0.0f, targetPosition.y)/** sphereRotateSpeed*/), Space.Self);
			if (Input.GetButton ("Fire1")) {
				sounds.PlaySound(2);
				Debug.Log ("Exit has been selected");
				Application.Quit();
			}
		}
	}
}