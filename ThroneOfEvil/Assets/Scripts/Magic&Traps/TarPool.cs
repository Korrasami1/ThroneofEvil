using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarPool : MonoBehaviour {
	

	public int uses = 3;
	public GameObject explosion;
	void Start () {
	}
	void Update () {
		if (uses <= 0) {
			Destroy (gameObject);
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Enemy") || other.CompareTag ("TarredEnemy")) {
			uses -= 1;
		}
		if (other.CompareTag ("Boulder")){
			uses -= 1;
		}
		if (other.CompareTag ("Fire") || other.CompareTag ("Explosion") || other.CompareTag ("BurningEnemy")) {
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}
}