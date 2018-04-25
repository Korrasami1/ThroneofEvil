using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTrapExplosion : MonoBehaviour {

	public float deletionTimer = 1f;
	ScoreManager scoreboard;
	void Start () {
		Destroy (gameObject, deletionTimer);
	}
}