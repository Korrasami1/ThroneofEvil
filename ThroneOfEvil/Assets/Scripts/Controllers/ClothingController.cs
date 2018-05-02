using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothingController : MonoBehaviour {
	public GameObject clothingRightView, clothingFrontView, clothingBackView;
	public GameObject[] Villager; //orientation purposes for left/right
	public Sprite[] trapClothingLeft, trapClothingRight, trapClothingFront, trapClothingBack;
	public string villagerOrientation;
	private string currentOrientation = "";
	private string previousOrientation = "";
	private Sprite trapcloth, trapclothTar;
	private int trapClothingNum, trapTarClothingNum;

	// Use this for initialization
	void Start () {
		//villagerOrientation = "right";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		updateOrientation ();
		updateClothing ();
	}
		
	void updateOrientation(){
		currentOrientation = villagerOrientation;
		if (villagerOrientation == "right") {
			if (previousOrientation == "left") {
				Villager [0].GetComponent<SpriteRenderer> ().flipX = false;
				Villager [1].GetComponent<SpriteRenderer> ().flipX = false;
				Villager [2].GetComponent<SpriteRenderer> ().flipX = false;
				Villager [3].GetComponent<SpriteRenderer> ().flipX = false;
				Villager [4].GetComponent<SpriteRenderer> ().flipX = false;
			}
			trapcloth = trapClothingRight [changeClothing (clothingRightView.GetComponent<ClothingGenerator> ().villagerType, 1)];
			trapclothTar = trapClothingRight [changeClothing (clothingRightView.GetComponent<ClothingGenerator> ().villagerType, 2)];
			clothingRightView.SetActive (true);
			clothingFrontView.SetActive (false);
			clothingBackView.SetActive (false);
			previousOrientation = currentOrientation;
		} else if (villagerOrientation == "left") {
			Villager [0].GetComponent<SpriteRenderer> ().flipX = true;
			Villager [1].GetComponent<SpriteRenderer> ().flipX = true;
			Villager [2].GetComponent<SpriteRenderer> ().flipX = true;
			Villager [3].GetComponent<SpriteRenderer> ().flipX = true;
			Villager [4].GetComponent<SpriteRenderer> ().flipX = true;
			clothingRightView.SetActive (true);
			trapcloth = trapClothingLeft [changeClothing (clothingRightView.GetComponent<ClothingGenerator> ().villagerType, 1)];
			trapclothTar = trapClothingLeft [changeClothing (clothingRightView.GetComponent<ClothingGenerator> ().villagerType, 2)];
			clothingFrontView.SetActive (false);
			clothingBackView.SetActive (false);
			previousOrientation = currentOrientation;
		} else if (villagerOrientation == "front") {
			trapcloth = trapClothingFront [changeClothing (clothingRightView.GetComponent<ClothingGenerator> ().villagerType, 1)];
			trapclothTar = trapClothingFront [changeClothing (clothingRightView.GetComponent<ClothingGenerator> ().villagerType, 2)];
			clothingRightView.SetActive (false);
			clothingFrontView.SetActive (true);
			clothingBackView.SetActive (false);
			previousOrientation = currentOrientation;
		} else if (villagerOrientation == "back") {
			trapcloth = trapClothingBack [changeClothing (clothingRightView.GetComponent<ClothingGenerator> ().villagerType, 1)];
			trapclothTar = trapClothingBack [changeClothing (clothingRightView.GetComponent<ClothingGenerator> ().villagerType, 2)];
			clothingRightView.SetActive (false);
			clothingFrontView.SetActive (false);
			clothingBackView.SetActive (true);
			previousOrientation = currentOrientation;
		}
		if (villagerOrientation == "Pause") {
			Villager [0].GetComponent<Animator> ().enabled = false;
			Villager [1].GetComponent<Animator> ().enabled = false;
			Villager [2].GetComponent<Animator> ().enabled = false;
			Villager [3].GetComponent<Animator> ().enabled = false;
			Villager [4].GetComponent<Animator> ().enabled = false;
			//clothingRightView.GetComponent<Animator> ().enabled = false;
			//clothingFrontView.GetComponent<Animator> ().enabled = false;
			//clothingBackView.GetComponent<Animator> ().enabled = false;
		} else {
			Villager [0].GetComponent<Animator> ().enabled = true;
			Villager [1].GetComponent<Animator> ().enabled = true;
			Villager [2].GetComponent<Animator> ().enabled = true;
			Villager [3].GetComponent<Animator> ().enabled = true;
			Villager [4].GetComponent<Animator> ().enabled = true;
			//clothingRightView.GetComponent<Animator> ().enabled = true;
			//clothingFrontView.GetComponent<Animator> ().enabled = true;
			//clothingBackView.GetComponent<Animator> ().enabled = true;
			villagerOrientation = previousOrientation;
		}
	}

	void updateClothing(){
		switch (gameObject.tag)
		{
		case "TarredEnemy":
			gameObject.GetComponent<SpriteRenderer> ().sprite = trapclothTar;
			break;
		case "FrozenEnemy":
			gameObject.GetComponent<SpriteRenderer> ().sprite = trapcloth;
			Villager [0].SetActive (false);
			Villager [1].SetActive (false);
			Villager [2].SetActive (false);
			Villager [3].SetActive (false);
			Villager [4].SetActive (false);
			//clothingFrontView.SetActive(false);
			//clothingBackView.SetActive(false);
			break;
		case "Enemy":
			gameObject.GetComponent<SpriteRenderer> ().sprite = null;
			Villager [0].SetActive (true);
			Villager [1].SetActive (true);
			Villager [2].SetActive (true);
			Villager [3].SetActive (true);
			Villager [4].SetActive (true);
			break;
		}
	}

	//this is to keep the original gender accociation
	int changeClothing (int type, int traptype){
		switch (type)
		{
		case 1:
			trapClothingNum = 0;
			trapTarClothingNum = 3;
			break;
		case 2:
			trapClothingNum = 1;
			trapTarClothingNum = 4;
			break;
		case 3:
			trapClothingNum = 2;
			trapTarClothingNum = 5;
			break;
		}
		if (traptype == 1) {
			return trapClothingNum;
		} else {
			return trapTarClothingNum;
		}
	}

}
