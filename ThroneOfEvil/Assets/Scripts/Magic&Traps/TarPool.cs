using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarPool : MonoBehaviour {

	public int uses;
	public float slowDurationSeconds;
	public float slowdown;
	public GameObject explosion;
	void Update () {
		if (uses <= 0) {
			Destroy (gameObject);
		}
	}
	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Enemy" || collider.tag == "Boulder") {
			uses -= 1;
		}
		if (collider.tag == "Fire" || collider.tag == "Explosion") {
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}
}