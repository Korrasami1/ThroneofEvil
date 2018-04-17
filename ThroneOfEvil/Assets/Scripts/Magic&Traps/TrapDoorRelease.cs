using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorRelease : MonoBehaviour {

	public string releaseButton;
	public string mode;
	public float cooldown;
	public GameObject trapDoor;
	void Awake () {
		StartCoroutine (Cooldown ());
	}
	void Update () 
	{
		if (Input.GetKeyDown(releaseButton))
		{
			Instantiate (trapDoor, transform.position, transform.rotation);
			Destroy (gameObject);
			Debug.Log("Trap door activated!");
		}
	}
	private IEnumerator Cooldown()
	{
		yield return new WaitForSeconds (cooldown);
		Instantiate (trapDoor, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}