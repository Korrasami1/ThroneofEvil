using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTrap : MonoBehaviour {

	public FreezeTrapExplosion freezeExplosion;

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy") || other.CompareTag("TarredEnemy") || other.CompareTag("BurningEnemy") || other.CompareTag("Boulder") || other.CompareTag("TarredBoulder") || other.CompareTag("BurningBoulder") || other.CompareTag("Fire") || other.CompareTag("Lightning")) {
			Instantiate (freezeExplosion, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}