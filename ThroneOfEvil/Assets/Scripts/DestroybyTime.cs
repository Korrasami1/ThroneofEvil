using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroybyTime : MonoBehaviour {
	public int time = 3;
	void Start(){
		Destroy (gameObject, time);
	}
}
