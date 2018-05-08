using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothingGenerator : MonoBehaviour {
	public GameObject Shirt;
	public GameObject Skin;
	public GameObject Hair;
	public GameObject Accessorie;
	//public Sprite[] childPants, manPants, womanPants;
	//public Sprite[] childShirts, manShirts, womanShirts;
	//public Sprite[] childHair, manHair, womanHair;
	//public Sprite[] skins; //male or female or child versions
	public RuntimeAnimatorController[] AnimationHair, AnimationPants, AnimationSkin, AnimationShirt, AnimationCapeorScarf;
	//private Sprite pant, shirt, hair, skin;
	private int vType; //villager Type
	public int villagerType; //this is for the traps clothing in the clothing controller
	private float pRed, pGreen, pBlue, sRed, sBlue, sGreen; // s stands for shirt, p stands for pants
	private float haRed, haGreen, haBlue, hRed, hBlue, hGreen; // ha stands for hat, h stands for hair
	Color pantsColour, shirtColour, HairColour, HatColour, SkinColour;
	//private Vector3 Rshirt, Rpants, Rhair, Rskin; //placments of the body parts per villager type
	Color[] listofSkinRGB = {new Color(244/255.0F,242/255.0F,245/255.0F), 
		new Color(236/255.0F,235/255.0F,233/255.0F), 
		new Color(250/255.0F,249/255.0F,247/255.0F), 
		new Color(253/255.0F,251/255.0F,230/255.0F), 
		new Color(253/255.0F,246/255.0F,230/255.0F), 
		new Color(254/255.0F,247/255.0F,229/255.0F), 
		new Color(250/255.0F,240/255.0F,239/255.0F), 
		new Color(243/255.0F,234/255.0F,229/255.0F), 
		new Color(244/255.0F,241/255.0F,234/255.0F), 
		new Color(251/255.0F,252/255.0F,244/255.0F), 
		new Color(252/255.0F,248/255.0F,237/255.0F), 
		new Color(254/255.0F,246/255.0F,225/255.0F), 
		new Color(255/255.0F,249/255.0F,225/255.0F), 
		new Color(255/255.0F,249/255.0F,225/255.0F), 
		new Color(241/255.0F,231/255.0F,195/255.0F), 
		new Color(239/255.0F,226/255.0F,173/255.0F), 
		new Color(224/255.0F,210/255.0F,147/255.0F), 
		new Color(242/255.0F,226/255.0F,151/255.0F), 
		new Color(235/255.0F,214/255.0F,159/255.0F), 
		new Color(235/255.0F,217/255.0F,133/255.0F), 
		new Color(227/255.0F,196/255.0F,103/255.0F), 
		new Color(225/255.0F,193/255.0F,106/255.0F), 
		new Color(223/255.0F,193/255.0F,123/255.0F), 
		new Color(222/255.0F,184/255.0F,119/255.0F), 
		new Color(199/255.0F,164/255.0F,100/255.0F), 
		new Color(188/255.0F,151/255.0F,098/255.0F), 
		new Color(156/255.0F,107/255.0F,067/255.0F), 
		new Color(142/255.0F,088/255.0F,062/255.0F), 
		new Color(121/255.0F,077/255.0F,048/255.0F), 
		new Color(100/255.0F,049/255.0F,022/255.0F), 
		new Color(101/255.0F,048/255.0F,032/255.0F), 
		new Color(096/255.0F,049/255.0F,033/255.0F), 
		new Color(087/255.0F,050/255.0F,041/255.0F), 
		new Color(064/255.0F,032/255.0F,021/255.0F), 
		new Color(049/255.0F,037/255.0F,041/255.0F), 
		new Color(027/255.0F,028/255.0F,046/255.0F)};

	// Use this for initialization
	void Start () {
		RandomiseVillagerType ();
		RandomisePantsClothing ();
		RandomiseShirtClothing ();
		RandomiseSkins ();
		RandomiseHair ();
		RandomiseHat ();
	}

	void FixedUpdate(){
	}

	//reset clothing so that we can have back/front/left/right
	public bool Restart(bool isRestarting){
		if (isRestarting == true) {
			Start ();
			isRestarting = false;
		}
		return isRestarting;
	}
		
	void RandomisePantsClothing(){
		pRed = Random.Range (0f, 1f);
		pBlue = Random.Range (0f, 1f);
		pGreen = Random.Range (0f, 1f);
		pantsColour = new Color(pRed, pGreen, pBlue);
		GetComponent<SpriteRenderer>().color = pantsColour;
		switch (vType)
		{
		case 1: //elf
			//Rpants = new Vector3 (0.04f, -1.68f, 0f);
			//transform.localPosition = Rpants;
			//pant = childPants[Random.Range(0, childPants.Length)];
			//GetComponent<SpriteRenderer> ().sprite = pant;
			GetComponent<Animator> ().runtimeAnimatorController = AnimationPants[0] as RuntimeAnimatorController;
			break;
		case 2: //naar
			//Rpants = new Vector3 (0.19f, -2.01f, 0f);
			//transform.localPosition = Rpants;
			//pant = manPants[Random.Range(0, manPants.Length)];
			//GetComponent<SpriteRenderer> ().sprite = pant;
			GetComponent<Animator> ().runtimeAnimatorController = AnimationPants[1] as RuntimeAnimatorController;
			break;
		case 3: //woman
			//Rpants = new Vector3 (-0.07f, -1.47f, 0f);
			//transform.localPosition = Rpants;
			//pant = womanPants[Random.Range(0, womanPants.Length)];
			//GetComponent<SpriteRenderer> ().sprite = pant;
			GetComponent<Animator> ().runtimeAnimatorController = AnimationPants[2] as RuntimeAnimatorController;
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
		case 1: //elf
			//shirt = childShirts[Random.Range(0, childShirts.Length)];
			//Shirt.GetComponent<SpriteRenderer> ().sprite = shirt;
			//Rshirt = new Vector3 (-0.11f, 0.87f, 0f);
			//Shirt.transform.localPosition = Rshirt;
			Shirt.GetComponent<Animator> ().runtimeAnimatorController = AnimationShirt[0] as RuntimeAnimatorController;
			break;
		case 2: //naar
			//shirt = manShirts[Random.Range(0, manShirts.Length)];
			//Shirt.GetComponent<SpriteRenderer> ().sprite = shirt;
			//Rshirt = new Vector3 (-0.11f, 0.87f, 0f);
			//Shirt.transform.localPosition = Rshirt;
			Shirt.GetComponent<Animator> ().runtimeAnimatorController = AnimationShirt[1] as RuntimeAnimatorController;
			break;
		case 3: //woman
			//shirt = womanShirts[Random.Range(0, womanShirts.Length)];
			//Shirt.GetComponent<SpriteRenderer> ().sprite = shirt;
			//Rshirt = new Vector3 (-0.11f, 2.15f, 0f);
			//Shirt.transform.localPosition = Rshirt;
			Shirt.GetComponent<Animator> ().runtimeAnimatorController = AnimationShirt[2] as RuntimeAnimatorController;
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
		case 1: //elf
			//hair = childHair[Random.Range(0, childHair.Length)];
			//Hair.GetComponent<SpriteRenderer> ().sprite = hair;
			//Rhair = new Vector3 (-0.13f, 1.61f, 0f);
			//Hair.transform.localPosition = Rhair;
			Hair.GetComponent<Animator> ().runtimeAnimatorController = AnimationHair[0] as RuntimeAnimatorController;
			break;
		case 2: //naar
			//hair = manHair[Random.Range(0, manHair.Length)];
			//Hair.GetComponent<SpriteRenderer> ().sprite = hair;
			//Rhair = new Vector3 (-0.2f, 2.86f, 0f);
			//Hair.transform.localPosition = Rhair;
			Hair.GetComponent<Animator> ().runtimeAnimatorController = AnimationHair[1] as RuntimeAnimatorController;
			break;
		case 3: //woman
			//hair = womanHair[Random.Range(0, womanHair.Length)];
			//Hair.GetComponent<SpriteRenderer> ().sprite = hair;
			//Rhair = new Vector3 (-0.13f, 2.38f, 0f);
			//Hair.transform.localPosition = Rhair;
			Hair.GetComponent<Animator> ().runtimeAnimatorController = AnimationHair[2] as RuntimeAnimatorController;
			break;
		}
	}

	void RandomiseHat(){
		haRed = Random.Range (0f, 1f);
		haBlue = Random.Range (0f, 1f);
		haGreen = Random.Range (0f, 1f);
		HatColour = new Color(haRed, haGreen, haBlue);
		Accessorie.GetComponent<SpriteRenderer> ().color = HatColour;
		switch (vType)
		{
		case 1: //elf
			Accessorie.SetActive(true);
			Accessorie.GetComponent<Animator> ().runtimeAnimatorController = AnimationCapeorScarf[0] as RuntimeAnimatorController;
			break;
		case 2: //naar
			Accessorie.SetActive(true);
			Accessorie.GetComponent<Animator> ().runtimeAnimatorController = AnimationCapeorScarf[1] as RuntimeAnimatorController;
			break;
		case 3: //woman
			Accessorie.SetActive(true);
			Accessorie.GetComponent<Animator> ().runtimeAnimatorController = AnimationCapeorScarf[2] as RuntimeAnimatorController;
			break;
		}

	}

	void RandomiseSkins(){
		SkinColour = (listofSkinRGB [Random.Range (0, listofSkinRGB.Length)]);
		Skin.GetComponent<SpriteRenderer> ().color = SkinColour;
		switch (vType)
		{
		case 1: //elf
			//skin = skins [0];
			//Skin.GetComponent<SpriteRenderer> ().sprite = skin;
			//Rskin = new Vector3 (0.12f, 0.61f, 0f);
			//Skin.transform.localPosition = Rskin;
			Skin.GetComponent<Animator> ().runtimeAnimatorController = AnimationSkin[0];
			break;
		case 2: //naar
			//skin = skins[1];
			//Skin.GetComponent<SpriteRenderer> ().sprite = skin;
			//Rskin = new Vector3 (-0.03f, 1.67f, 0f);
			//Skin.transform.localPosition = Rskin;
			Skin.GetComponent<Animator> ().runtimeAnimatorController = AnimationSkin[1];
			break;
		case 3: //woman
			//skin = skins[2];
			//Skin.GetComponent<SpriteRenderer> ().sprite = skin;
			//Rskin = new Vector3 (0.23f, 1.75f, 0f);
			//Skin.transform.localPosition = Rskin;
			Skin.GetComponent<Animator> ().runtimeAnimatorController = AnimationSkin[2];
			break;
		}

	}

	int RandomiseVillagerType(){
		vType = Random.Range (1, 4);
		villagerType = vType;
		return vType;
	}

}
