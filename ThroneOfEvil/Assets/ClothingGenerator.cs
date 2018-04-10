using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothingGenerator : MonoBehaviour {
	public Sprite[] Pants;
	public Sprite[] Shirts;

	// Use this for initialization
	void Start () {
		Sprite pant = Pants[Random.Range(0, Pants.Length)];
		//Sprite shirt = Shirts[Random.Range(0, Pants.Length)];
		GetComponent<SpriteRenderer> ().sprite = pant;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
