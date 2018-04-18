using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;

public class TrapDoorRelease : MonoBehaviour {

	public string releaseButton;
	public string mode;
	public float cooldown;
	public GameObject trapDoor;
	SoundsSceneManager sounds;
	void Awake () {
		StartCoroutine (Cooldown ());
	}
	void Start(){
		sounds = GameObject.FindWithTag ("SoundManager").GetComponent<SoundsSceneManager> ();
	}
	void Update () 
	{
		if (Input.GetKeyDown (releaseButton)) {
			Instantiate (trapDoor, transform.position, transform.rotation);
			sounds.PlaySound(4);
			Destroy (gameObject);
			Debug.Log ("Trap door activated!");
		}
	}

	private IEnumerator Cooldown()
	{
		yield return new WaitForSeconds (cooldown);
		sounds.PlaySound(5);
		Instantiate (trapDoor, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}