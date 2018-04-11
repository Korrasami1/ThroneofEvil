using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothingGenerator : MonoBehaviour {
	public GameObject Cshirt;
	public Sprite[] Pants;
	public Sprite[] Shirts;
	private Sprite pant, shirt;
	private float pRed, pGreen, pBlue, sRed, sBlue, sGreen; // s stands for shirt, p stands for pants
	Color pantsColour, shirtColour;

	// Use this for initialization
	void Start () {
		RandomiseClothing ();
		GetComponent<SpriteRenderer> ().sprite = pant;
		GetComponent<SpriteRenderer>().color = pantsColour;
		Cshirt.GetComponent<SpriteRenderer> ().sprite = shirt;
		Cshirt.GetComponent<SpriteRenderer> ().color = shirtColour;
	}

	void RandomiseClothing(){
		pant = Pants[Random.Range(0, Pants.Length)];
		shirt = Shirts[Random.Range(0, Shirts.Length)];
		pRed = Random.Range (0f, 1f);
		pBlue = Random.Range (0f, 1f);
		pGreen = Random.Range (0f, 1f);
		pantsColour = new Color(pRed, pGreen, pBlue);
		sRed = Random.Range (0f, 1f);
		sBlue = Random.Range (0f, 1f);
		sGreen = Random.Range (0f, 1f);
		shirtColour = new Color(sRed, sBlue, sGreen);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
