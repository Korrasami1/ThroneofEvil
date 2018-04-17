using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTrap : MonoBehaviour {

	public FreezeTrapExplosion freezeExplosion;
	public float zValue;

	private Vector3 explosionPosition;

	void Start(){
		explosionPosition = transform.position + new Vector3 (0f, 0f, zValue);
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Enemy" || collider.tag == "Boulder" || collider.tag == "Fire" || collider.tag == "Lightning") {
			Instantiate (freezeExplosion, explosionPosition, transform.rotation);
			Destroy(gameObject);
		}
	}
}