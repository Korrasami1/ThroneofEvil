using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMagicBehaviour : MonoBehaviour {
	Vector3 mousePosition,targetPosition;
	public float distance = 10f;
	public float deletionTimer = 5f;
	public int killstreak = 1;
	void Start(){
		killstreak = 1;
		//To get the current mouse position
		mousePosition = Input.mousePosition;
		//Convert the mousePosition according to World position
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x,mousePosition.y,distance));
		Destroy (gameObject, deletionTimer);
	}
	void Update () {
		//To get the current mouse position
		mousePosition = Input.mousePosition;
		//Convert the mousePosition according to World position
		//transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x,mousePosition.y,distance));
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("FreezeTrapExplosion") || other.CompareTag("TarPool")) {
			Destroy (gameObject);
		}
		if (other.CompareTag ("Enemy") || other.CompareTag ("FrozenEnemy") || other.CompareTag ("BurningEnemy") || other.CompareTag ("TarredEnemy") || other.CompareTag ("FearedEnemy")) {
			killstreak = killstreak+1;
		}
	}
}
