using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
	public int time = 3;
	public int killstreak = 1;
	void Start(){
		Destroy (gameObject, time);
	}
}
