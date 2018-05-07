using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuToggling : MonoBehaviour {

	public GameObject voice;
	public Toggle tog1, tog2;
	public bool isOnPrefab;
	void Start(){
	}

	void FixedUpdate ()
	{
		if (isOnPrefab == false) {
			if (voice.GetComponent<VoiceCommandController> ().enabled == true) {
				tog1.isOn = true;
				tog2.isOn = false;
			} else if (voice.GetComponent<MutedVoiceCommands> ().enabled == true) {
				tog2.isOn = true;
				tog1.isOn = false;
			} else if (voice.GetComponent<MutedVoiceCommands> ().enabled == false && voice.GetComponent<VoiceCommandController> ().enabled == false) {
				tog1.isOn = true;
				tog2.isOn = false;
			}
		} else {
			if (voice.GetComponent<MutedVoiceCommands> ().enabled == false && voice.GetComponent<VoiceCommandController> ().enabled == false) {
				voice.GetComponent<MutedVoiceCommands> ().enabled = false;
				voice.GetComponent<VoiceCommandController> ().enabled = true;
			}
		}

	}
}
