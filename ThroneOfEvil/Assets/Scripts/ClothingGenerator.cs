using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothingGenerator : MonoBehaviour {
	public GameObject Shirt;
	public GameObject Skin;
	public GameObject Hair;
	public GameObject Hat;
	public Sprite[] childPants, manPants, womanPants;
	public Sprite[] childShirts, manShirts, womanShirts;
	public Sprite[] childHair, manHair, womanHair;
	public Sprite[] skins;
	private Sprite pant, shirt, hair, skin;
	private int vType; //villager Type
	private float pRed, pGreen, pBlue, sRed, sBlue, sGreen; // s stands for shirt, p stands for pants
	private float haRed, haGreen, haBlue, hRed, hBlue, hGreen; // ha stands for hat, h stands for hair
	Color pantsColour, shirtColour, HairColour, HatColour, SkinColour;
	private Vector3 Rshirt, Rpants, Rhair, Rskin; //placments of the body parts per villager type
	Color[] listofSkinRGB = {new Color(244,242,245), 
		new Color(236,235,233), 
		new Color(250,249,247), 
		new Color(253,251,230), 
		new Color(253,246,230), 
		new Color(254,247,229), 
		new Color(250,240,239), 
		new Color(243,234,229), 
		new Color(244,241,234), 
		new Color(251,252,244), 
		new Color(252,248,237), 
		new Color(254,246,225), 
		new Color(255,249,225), 
		new Color(255,249,225), 
		new Color(241,231,195), 
		new Color(239,226,173), 
		new Color(224,210,147), 
		new Color(242,226,151), 
		new Color(235,214,159), 
		new Color(235,217,133), 
		new Color(227,196,103), 
		new Color(225,193,106), 
		new Color(223,193,123), 
		new Color(222,184,119), 
		new Color(199,164,100), 
		new Color(188,151,098), 
		new Color(156,107,067), 
		new Color(142,088,062), 
		new Color(121,077,048), 
		new Color(100,049,022), 
		new Color(101,048,032), 
		new Color(096,049,033), 
		new Color(087,050,041), 
		new Color(064,032,021), 
		new Color(049,037,041), 
		new Color(027,028,046)};

	// Use this for initialization
	void Start () {
		RandomiseVillagerType ();
		RandomisePantsClothing ();
		RandomiseShirtClothing ();
		RandomiseSkins ();
		RandomiseHair ();
		RandomiseHat ();
	}

	void RandomisePantsClothing(){
		pRed = Random.Range (0f, 1f);
		pBlue = Random.Range (0f, 1f);
		Debug.Log (pBlue);
		pGreen = Random.Range (0f, 1f);
		pantsColour = new Color(pRed, pGreen, pBlue);
		GetComponent<SpriteRenderer>().color = pantsColour;
		switch (vType)
		{
		case 1: //child
			Rpants = new Vector3 (0.04f, -1.68f, 0f);
			transform.localPosition = Rpants;
			pant = childPants[Random.Range(0, childPants.Length)];
			GetComponent<SpriteRenderer> ().sprite = pant;

			break;
		case 2: //man
			Rpants = new Vector3 (0.19f, -2.01f, 0f);
			transform.localPosition = Rpants;
			pant = manPants[Random.Range(0, manPants.Length)];
			GetComponent<SpriteRenderer> ().sprite = pant;
			break;
		case 3: //woman
			Rpants = new Vector3 (-0.07f, -1.47f, 0f);
			transform.localPosition = Rpants;
			pant = womanPants[Random.Range(0, womanPants.Length)];
			GetComponent<SpriteRenderer> ().sprite = pant;
			break;
		}
	}

	void RandomiseShirtClothing(){
		sRed = Random.Range (0f, 1f);
		sBlue = Random.Range (0f, 1f);
		sGreen = Random.Range (0f, 1f);
		shirtColour = new Color(sRed, sGreen, sBlue);
		Shirt.GetComponent<SpriteRenderer> ().color = shirtColour;
		switch (vType)
		{
		case 1: //child
			shirt = childShirts[Random.Range(0, childShirts.Length)];
			Shirt.GetComponent<SpriteRenderer> ().sprite = shirt;
			Rshirt = new Vector3 (-0.11f, 0.87f, 0f);
			Shirt.transform.localPosition = Rshirt;
			break;
		case 2: //man
			shirt = manShirts[Random.Range(0, manShirts.Length)];
			Shirt.GetComponent<SpriteRenderer> ().sprite = shirt;
			Rshirt = new Vector3 (-0.11f, 0.87f, 0f);
			Shirt.transform.localPosition = Rshirt;
			break;
		case 3: //woman
			shirt = womanShirts[Random.Range(0, womanShirts.Length)];
			Shirt.GetComponent<SpriteRenderer> ().sprite = shirt;
			Rshirt = new Vector3 (-0.11f, 2.15f, 0f);
			Shirt.transform.localPosition = Rshirt;
			break;
		}
	}

	void RandomiseHair(){
		hRed = Random.Range (0f, 1f);
		hBlue = Random.Range (0f, 1f);
		hGreen = Random.Range (0f, 1f);
		HairColour = new Color(hRed, hGreen, hBlue);
		Hair.GetComponent<SpriteRenderer> ().color = HairColour;
		switch (vType)
		{
		case 1: //child
			hair = childHair[Random.Range(0, childHair.Length)];
			Hair.GetComponent<SpriteRenderer> ().sprite = hair;
			Rhair = new Vector3 (-0.13f, 1.61f, 0f);
			Hair.transform.localPosition = Rhair;
			break;
		case 2: //man
			hair = manHair[Random.Range(0, manHair.Length)];
			Hair.GetComponent<SpriteRenderer> ().sprite = hair;
			Rhair = new Vector3 (-0.2f, 2.86f, 0f);
			Hair.transform.localPosition = Rhair;
			break;
		case 3: //woman
			hair = womanHair[Random.Range(0, womanHair.Length)];
			Hair.GetComponent<SpriteRenderer> ().sprite = hair;
			Rhair = new Vector3 (-0.13f, 2.38f, 0f);
			Hair.transform.localPosition = Rhair;
			break;
		}
	}

	void RandomiseHat(){
		haRed = Random.Range (0f, 1f);
		haBlue = Random.Range (0f, 1f);
		haGreen = Random.Range (0f, 1f);
		HatColour = new Color(haRed, haGreen, haBlue);
		Hat.GetComponent<SpriteRenderer> ().color = HatColour;
		switch (vType)
		{
		case 1: //child
			Hat.SetActive(false);
			break;
		case 2: //man
			Hat.SetActive(true);
			break;
		case 3: //woman
			Hat.SetActive(false);
			break;
		}

	}

	void RandomiseSkins(){
		SkinColour = (listofSkinRGB [/*Random.Range (0, */listofSkinRGB.Length-1/*)*/]);
		Skin.GetComponent<SpriteRenderer> ().color = SkinColour;
		switch (vType)
		{
		case 1: //child
			skin = skins [0];
			Skin.GetComponent<SpriteRenderer> ().sprite = skin;
			Rskin = new Vector3 (0.12f, 0.61f, 0f);
			Skin.transform.localPosition = Rskin;
			break;
		case 2: //man
			skin = skins[1];
			Skin.GetComponent<SpriteRenderer> ().sprite = skin;
			Rskin = new Vector3 (-0.03f, 1.67f, 0f);
			Skin.transform.localPosition = Rskin;
			break;
		case 3: //woman
			skin = skins[2];
			Skin.GetComponent<SpriteRenderer> ().sprite = skin;
			Rskin = new Vector3 (0.23f, 1.75f, 0f);
			Skin.transform.localPosition = Rskin;
			break;
		}

	}

	int RandomiseVillagerType(){
		vType = Random.Range (1, 4);
		Debug.Log ("villager type = "+vType);
		return vType;
	}

}
