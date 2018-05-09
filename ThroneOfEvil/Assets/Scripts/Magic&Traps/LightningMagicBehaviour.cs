using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningMagicBehaviour : MonoBehaviour {
	public GameObject explosion;
	Vector3 mousePosition,targetPosition;
	public float distance = 10f;
	public float deletionTimer = 3f;
	public int killstreak = 1;
	void Start(){
		killstreak = 1;
		//To get the current mouse position
		mousePosition = Input.mousePosition;
		//Convert the mousePosition according to World position
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x,mousePosition.y,distance));
		Vector3 exp = new Vector3 (transform.position.x, transform.position.y, -15.5f);
		Instantiate (explosion, exp, Quaternion.identity);
		Destroy (gameObject, deletionTimer);

	}
	void Update () {
		//To get the current mouse position
		mousePosition = Input.mousePosition;
		//Convert the mousePosition according to World position
		//transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x,mousePosition.y,distance));
	}
}
