using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTrap : MonoBehaviour {

	public FreezeTrapExplosion freezeExplosion;
	public float zValue;
	//private Vector3 explosionPosition;

	void Start(){
		//explosionPosition = transform.position + new Vector3 (0f, 0f, zValue);
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy") || other.CompareTag("Boulder") || other.CompareTag("Fire") || other.CompareTag("Lightning")) {
			Instantiate (freezeExplosion, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}