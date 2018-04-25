using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuToggling : MonoBehaviour {

	public GameObject voice;
	public Toggle tog1, tog2;

	void FixedUpdate ()
	{
		if (voice.GetComponent<VoiceCommandController> ().enabled == true) {
			tog1.isOn = true;
			tog2.isOn = false;
		} else if (voice.GetComponent<MutedVoiceCommands> ().enabled == true) {
			tog2.isOn = true;
			tog1.isOn = false;
		}
	}
}
