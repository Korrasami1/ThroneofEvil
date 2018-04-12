using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarPool : MonoBehaviour {

	public int uses;
	public float slowDurationSeconds;
	public float slowdown;

	void Update () {
		if (uses <= 0) {
			Destroy (gameObject);
		}
	}
	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Enemy") {
			uses -= 1;
		}
	}
}