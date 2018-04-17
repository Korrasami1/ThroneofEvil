using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTrapExplosion : MonoBehaviour {

	public float freezeExplosionDurationSeconds;
	public float freezeDurationSeconds;

	void Awake () {
		StartCoroutine (FreezeExplosion ());
	}

	private IEnumerator FreezeExplosion()
	{
		yield return new WaitForSeconds (freezeExplosionDurationSeconds);
		Destroy (gameObject);
	}
}