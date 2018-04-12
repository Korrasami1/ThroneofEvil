using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorRelease : MonoBehaviour {

	public string releaseButton;
	public string mode;
	public GameObject trapDoor;

	void Update () 
	{
		if (Input.GetKeyDown(releaseButton))
		{
			Destroy (gameObject);
			Instantiate (trapDoor, transform.position, transform.rotation);
			Debug.Log("Trap door activated!");
		}
	}
}